using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
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
                .Where(x => x.Status == CodeSummit.Models.SessionStatus.Approved.ToString() 
                    || x.PresenterId == WebSecurity.CurrentUserId
                    || Roles.IsUserInRole("Administrator"))
                .Select(session =>
                        new SessionListModel
                            {
                                Name = session.Name,
                                Description = session.Description,
                                Speaker = users.FirstOrDefault(profile => profile.UserId == session.PresenterId),
                                ScheduledTime = session.ScheduledTime,
                                Slug = session.Slug,
                                Status = session.Status
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
            var repository = new SessionRepository();
            repository.Save(session);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string sessionSlug)
        {
            var repository = new SessionRepository();
            repository.DeleteBySlug(sessionSlug);
            return RedirectToAction("Index");
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
