using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BlogLand.DAL;
using BlogLand.Models;

namespace BlogLand.Controllers
{
    public class TagController : Controller
    {
        private readonly BlogContext _db = new BlogContext();

        // GET: Tag
        public ActionResult Index()
        {
            return View(_db.Tags.ToList());
        }

        // GET: Tag/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var tag = _db.Tags.Find(id);
            if (tag == null) return HttpNotFound();
            return View(tag);
        }

        // GET: Tag/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tag/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description,UrlSlug")]
            Tag tag)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Tags.Add(tag);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "Admin");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a li here to write a log.
                ModelState.AddModelError("",@"Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(tag);
        }

        // GET: Tag/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var tag = _db.Tags.Find(id);
            if (tag == null) return HttpNotFound();
            return View(tag);
        }

        // POST: Tag/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var tag = _db.Tags.Find(id);
            if (TryUpdateModel(tag, "", new[] {"Name", "Description", "UrlSlug"}))
                try
                {
                    _db.SaveChanges();
                    return RedirectToAction("Index", "Admin");
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("",@"Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }

            return View(tag);
        }

        // GET: Tag/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            if (saveChangesError.GetValueOrDefault())
                ViewBag.ErrorMessage =
                    "Delete failed. Try again, and if the problem persists see your system administrator.";
            var tag = _db.Tags.Find(id);
            if (tag == null) return HttpNotFound();
            return View(tag);
        }

        // POST: Tag/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var tag = _db.Tags.Find(id);
                _db.Tags.Remove(tag);
                _db.SaveChanges();
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new {id, saveChangesError = true});
            }

            return RedirectToAction("Index", "Admin");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _db.Dispose();
            base.Dispose(disposing);
        }
    }
}