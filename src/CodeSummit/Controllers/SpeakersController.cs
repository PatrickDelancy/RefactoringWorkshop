using System.Linq;
using System.Web.Mvc;
using CodeSummit.Models;
using CodeSummit.Repository;

namespace CodeSummit.Controllers
{
    public class SpeakersController : Controller
    {
        //
        // GET: /Speaker/

        public ActionResult Index()
        {
            var respository = new SessionRepository();
            UserProfile[] speakers;
            using (var db = new UsersContext())
            {
                speakers = db.UserProfiles.ToArray();
                speakers = speakers
                             .Where(
                                 user =>
                                 respository.GetAllByPresenterId(user.UserId).Any(session => session.Status == "Approved"))
                             .ToArray();
            }
            return View(speakers);
        }

        public ActionResult Display(string speakerSlug)
        {
            return View();
        }
    }
}
