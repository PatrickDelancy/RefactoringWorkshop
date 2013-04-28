using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeSummit.Data;
using CodeSummit.Models;
using CodeSummit.Repository;

namespace CodeSummit.Controllers
{
    public class UserRegistrationController : Controller
    {
        //
        // GET: /Registration/

        [HttpGet]
        public ActionResult Register()
        {
            var repository = new SessionRepository();
            var sessions = repository.GetAll();
            var sessionModel = new List<SessionModel>();
            foreach (var session in sessions)
                sessionModel.Add(new SessionModel()
                    {
                        Id = session.SessionId,
                        Name = session.Name,
                        ScheduledTime = session.ScheduledTime,
                        Selected = false
                    });

            return View(new UserRegistrationModel()
                {
                    Sessions = sessionModel
                });
        }

        [HttpPost]
        public void Register(UserRegistrationModel model)
        {
            var repository = new UserRegistrationRepository();
            repository.Create(HttpContext.User.Identity.Name, model.Sessions.Where(x => x.Selected).Select(x => x.Id));
        }
    }
}
