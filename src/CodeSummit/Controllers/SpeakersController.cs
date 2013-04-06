using System.Web.Mvc;

namespace CodeSummit.Controllers
{
    public class SpeakersController : Controller
    {
        //
        // GET: /Speaker/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Display(string speakerSlug)
        {
            return View();
        }
    }
}
