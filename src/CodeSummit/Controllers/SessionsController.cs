using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CodeSummit.Filters;
using CodeSummit.Models;
using CodeSummit.Repository;
using WebMatrix.WebData;

namespace CodeSummit.Controllers
{
    [InitializeSimpleMembership]
    public class SessionsController : Controller
    {
        //
        // GET: /Session/

        public ActionResult Index()
        {
            var repository = new SessionRepository();
            List<UserProfile> users;
            using (var userDb = new UsersContext())
            {
                users = userDb.UserProfiles.ToList();
            }
            var sessions = repository
                .GetAll()
                .Select(session =>
                        new SessionListModel
                            {
                                Name = session.Name,
                                Description = session.Description,
                                Speaker = users.FirstOrDefault(profile => profile.UserId == session.PresenterId),
                                ScheduledTime = session.ScheduledTime
                            }
                );

            return View(sessions);
        }

        public ActionResult Display(string sessionSlug)
        {
            var repository = new SessionRepository();
            return View(repository.GetBySlug(sessionSlug));
        }

        public ActionResult Edit(string sessionSlug)
        {
            var repository = new SessionRepository();
            return View(repository.GetBySlug(sessionSlug));
        }

        [HttpPost]
        public ActionResult Edit(Session session)
        {
            return View(session);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AddSessionModel session)
        {
            var repository = new SessionRepository();
            repository.Save(
                new Session
                    {
                        Name = session.Name,
                        Description = session.Description,
                        PresenterId = WebSecurity.CurrentUserId,
                        Status = SessionStatus.Submitted.ToString()
                    }
                );

            return RedirectToAction("Index");
        }
    }
}
