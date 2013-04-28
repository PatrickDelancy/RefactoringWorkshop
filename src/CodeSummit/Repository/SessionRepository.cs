using System.Collections.Generic;
using System.Linq;
using CodeSummit.Data;
using CodeSummit.Models;

namespace CodeSummit.Repository
{
    public class SessionRepository
    {
        public IEnumerable<Session> GetAll()
        {
            using (var db = new CodeSummitContext())
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
            using (var db = new CodeSummitContext())
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
                    if (session.ScheduledTime.HasValue)
                        existingSession.ScheduledTime = session.ScheduledTime;
                    if (!string.IsNullOrEmpty(session.Status))
                        existingSession.Status = session.Status;
                }
                db.SaveChanges();
            }
        }

        public void DeleteBySlug(string sessionSlug)
        {
            using (var db = new CodeSummitContext())
            {
                var existingSession = db.Sessions.FirstOrDefault(x => x.Slug == sessionSlug);
                if (existingSession == null) return;

                db.Sessions.Remove(existingSession);
                db.SaveChanges();
            }
        }

        public IEnumerable<Session> GetAllByPresenterId(int userId)
        {
            using (var db = new CodeSummitContext())
            {
                return db.Sessions.Where(x => x.PresenterId == userId).ToArray();
            }
        }
    }
}
