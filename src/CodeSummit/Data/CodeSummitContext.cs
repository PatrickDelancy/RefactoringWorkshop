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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRegistrationDbModel>().HasMany(x => x.Sessions).WithMany(x => x.UserRegistrations).Map(m
                                                                                                                           =>
                {
                    m.ToTable("UserRegistrations_Sessions");
                    m.MapLeftKey("UserRegistrationId");
                    m.MapRightKey("SessionId");
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}