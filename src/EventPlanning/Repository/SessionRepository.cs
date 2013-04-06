using System.Collections.Generic;
using System.Linq;
using EventPlanning.Models;

namespace EventPlanning.Repository
{
    public class SessionRepository
    {
        public IEnumerable<Session> GetAll()
        {
            using (var db = new SessionContext())
            {
                return db.Sessions.ToList();
            }
        }

        public Session GetBySlug(string sessionSlug)
        {
            return GetAll().FirstOrDefault(x => x.Slug == sessionSlug);
        }

        public void Save(Session session)
        {
            using (var db = new SessionContext())
            {
                var existingSession = db.Sessions.FirstOrDefault(x => x.SessionId == session.SessionId);

                if (existingSession == null)
                {
                    db.Sessions.Add(session);
                }
                else
                {
                    existingSession.Name = session.Name;
                    existingSession.Description = session.Description;
                    existingSession.Slug = session.Slug;
                    existingSession.PresenterId = session.PresenterId;
                }
                db.SaveChanges();
            }
        }
    }
}
