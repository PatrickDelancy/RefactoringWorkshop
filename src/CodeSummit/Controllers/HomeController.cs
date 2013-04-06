using System.Web.Mvc;

namespace CodeSummit.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Code, friends and food. Who could ask for anything more?";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Reach the coordinators.";

            return View();
        }
    }
}
