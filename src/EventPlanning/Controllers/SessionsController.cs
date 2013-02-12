using System.Web.Mvc;
using EventPlanning.Repository;

namespace EventPlanning.Controllers
{
    public class SessionsController : Controller
    {
        //
        // GET: /Session/

        public ActionResult Index()
        {
            var repository = new SessionRepository();

            return View(repository.GetAllForEvent(""));
        }

        public ActionResult Display(string sessionSlug)
        {
            return View();
        }

    }
}
