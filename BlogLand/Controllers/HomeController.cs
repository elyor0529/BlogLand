using System.Web;
using System.Web.Mvc;
using BlogLand.DAL;
using BlogLand.ViewModels;

namespace BlogLand.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlogRepository _repository = new BlogRepository();

        public ActionResult Posts(int p = 1)
        {
            var viewModel = new ListViewModel(_repository, p);
            ViewBag.Title = "Latest Posts";
            return View("List", viewModel);
        }

        public ActionResult Category(string category, int p = 1)
        {
            var viewModel = new ListViewModel(_repository, p, category, "Category");
            if (viewModel.Category == null) throw new HttpException(404, "Category not found!");
            ViewBag.Title = string.Format("Lates posts on {0} category", viewModel.Category.Name);
            return View("List", viewModel);
        }

        public ActionResult Tagy(string tag, int p = 1)
        {
            var viewModel = new ListViewModel(_repository, p, tag, "Tag");
            if (viewModel.Tag == null) throw new HttpException("Tag not found!");
            ViewBag.Title = string.Format("Latest posts on {0} topic", viewModel.Tag.Name);
            return View("List", viewModel);
        }

        public ActionResult Search(string search, int p = 1)
        {
            var viewModel = new ListViewModel(_repository, p, search, "Search");
            ViewBag.Title = string.Format("Posts based on search string: {0}", viewModel.Search);
            return View("List", viewModel);
        }


        public ActionResult Post(int year, int month, string title)
        {
            var post = _repository.GetPost(title, year, month);
            if (post == null) throw new HttpException("Post is not found!");
            return View(post);
        }

        [ChildActionOnly]
        public PartialViewResult Sidebars()
        {
            var viewModel = new WidgetViewModel(_repository);
            return PartialView("_SideBars", viewModel);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}