using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BlogLand.DAL;
using BlogLand.Models;
using BlogLand.ViewModels;

namespace BlogLand.Controllers
{
    public class PostController : Controller
    {
        private readonly BlogContext _db = new BlogContext();

        // GET: Post
        public ActionResult Index()
        {
            var posts = _db.Posts.Include(p => p.Category);
            return View(posts.ToList());
        }

        // GET: Post/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var post = _db.Posts.Where(p => p.ID == id).Include(p => p.Category).Include(p => p.Tags).SingleOrDefault();
            if (post == null) return HttpNotFound();
            return View(post);
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            var post = new Post();
            post.Tags = new List<Tag>();
            ViewBag.CategoryID = new SelectList(_db.Categories, "ID", "Name");
            PopulateAssignedTagData(post);
            return View();
        }

        // POST: Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="Title,ShortDescription,Description,UrlSlug,Meta,Published,PostedOn,Modified,CategoryID")]
            Post post, string[] selectedTags)
        {
            if (selectedTags != null)
            {
                post.Tags = new List<Tag>();
                foreach (var tag in selectedTags)
                {
                    var tagToAdd = _db.Tags.Find(int.Parse(tag));
                    post.Tags.Add(tagToAdd);
                }

                if (ModelState.IsValid)
                {
                    _db.Posts.Add(post);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "Admin");
                }
            }

            ViewBag.CategoryID = new SelectList(_db.Categories, "ID", "Name", post.CategoryID);
            PopulateAssignedTagData(post);
            return View();
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var post = _db.Posts.Where(p => p.ID == id).Include(path => path.Category).Include(p => p.Tags)
                .SingleOrDefault();
            if (post == null) return HttpNotFound();
            ViewBag.CategoryID = new SelectList(_db.Categories, "ID", "Name", post.CategoryID);
            PopulateAssignedTagData(post);
            return View(post);
        }

        // POST: Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, string[] selectedTags)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var postToUpdate = _db.Posts
                .Where(i => i.ID == id)
                .Include(i => i.Category)
                .Include(i => i.Tags)
                .Single();
            if (TryUpdateModel(postToUpdate, "",
                new[]
                {
                    "Title", "ShortDescription", "Description", "UrlSlug", "Meta", "Published", "PostedOn", "Modified",
                    "CategoryID"
                }))
                try
                {
                    UpdatePostTags(selectedTags, postToUpdate);
                    _db.Entry(postToUpdate).State = EntityState.Modified;
                    _db.SaveChanges();
                    return RedirectToAction("Index", "Admin");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", @"Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }

            PopulateAssignedTagData(postToUpdate);
            return View(postToUpdate);
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            if (saveChangesError.GetValueOrDefault())
                ViewBag.ErrorMessage =
                    "Delete failed. Try again, and if the problem persists see your system administrator.";
            var post = _db.Posts.Find(id);
            if (post == null) return HttpNotFound();
            return View(post);
        }

        // POST: Post/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var post = _db.Posts.Find(id);
                _db.Posts.Remove(post);
                _db.SaveChanges();
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new
                {
                    id,
                    saveChangesError = true
                });
            }

            return RedirectToAction("Index", "Admin");
        }

        private void PopulateAssignedTagData(Post post)
        {
            var allTags = _db.Tags;
            var postTags = new HashSet<int>(post.Tags.Select(c =>
                c.ID));
            var viewModel = new List<AssignedTagData>();
            foreach (var tag in allTags)
                viewModel.Add(new AssignedTagData
                {
                    TagID = tag.ID,
                    TagName = tag.Name,
                    Assigned = postTags.Contains(tag.ID)
                });
            ViewBag.Tags = viewModel;
        }

        private void UpdatePostTags(string[] selectedTags, Post postToUpdate)
        {
            if (selectedTags == null)
            {
                postToUpdate.Tags = new List<Tag>();
                return;
            }

            var selectedTagsHs = new HashSet<string>(selectedTags);
            var postTags = new HashSet<int>(postToUpdate.Tags.Select(c => c.ID));
            foreach (var tag in _db.Tags)
                if (selectedTagsHs.Contains(tag.ID.ToString()))
                {
                    if (!postTags.Contains(tag.ID)) postToUpdate.Tags.Add(tag);
                }
                else
                {
                    if (postTags.Contains(tag.ID)) postToUpdate.Tags.Remove(tag);
                }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _db.Dispose();
            base.Dispose(disposing);
        }
    }
}