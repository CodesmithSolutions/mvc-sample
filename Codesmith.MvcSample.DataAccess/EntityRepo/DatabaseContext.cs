using System;
using System.Data.Entity;

namespace Codesmith.MvcSample.DataAccess.EntityRepo
{
    class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=MvcSample")
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<IssueEntity>()
            //        .HasRequired(m => m.CreatedBy)
            //        .WithRequiredDependent(t => t.CreatedBy)
            //        .HasForeignKey(m => m.CreatedByUserId)
            //        .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Match>()
            //            .HasRequired(m => m.GuestTeam)
            //            .WithMany(t => t.AwayMatches)
            //            .HasForeignKey(m => m.GuestTeamId)
            //            .WillCascadeOnDelete(false);
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserProfileEntity> UserProfiles { get; set; }
        public DbSet<IssueEntity> Issues { get; set; }
    }
}
