using System.Data.Entity;
using CodeSummit.Models;

namespace CodeSummit.Data
{
    public class CodeSummitContext: DbContext
    {
        public CodeSummitContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserRegistrationDbModel> UserRegistrations { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}