using System.Collections.Generic;
using System.Linq;
using CodeSummit.Data;
using CodeSummit.Models;

namespace CodeSummit.Repository
{
    public class UserRegistrationRepository
    {
        public void Create(string username, IEnumerable<int> sessionIds)
        {
            using (var db = new CodeSummitContext())
            {
                var selectedSessions = sessionIds.Select(x => db.Sessions.Find(x)).ToList();
                var registration = new UserRegistrationDbModel()
                    {
                        UserName = username,
                        Sessions = selectedSessions
                    };
                db.UserRegistrations.Add(registration);
                db.SaveChanges();
            }
        }
    }
}