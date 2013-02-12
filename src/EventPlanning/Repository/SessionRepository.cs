using System.Collections.Generic;
using EventPlanning.Models;

namespace EventPlanning.Repository
{
    public class SessionRepository
    {
        public IEnumerable<SessionModel> GetAllForEvent(string eventId)
        {
            return new[]
                       {
                           new SessionModel { Name = "How to win with dynamics", Presenter = "Joe Raime", Description = "dynamic session description" }, 
                           new SessionModel { Name = "YAW8T (Yet another Win8 Talk)", Presenter = "Messy Ron", Description = "win8 session description" }, 
                       };
        }
    }
}
