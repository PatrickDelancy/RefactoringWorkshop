using System.Web.Mvc;

namespace EventPlanning.Controllers
{
    public class SessionsController : Controller
    {
        //
        // GET: /Session/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Display(string sessionSlug)
        {
            return View();
        }

    }
}
