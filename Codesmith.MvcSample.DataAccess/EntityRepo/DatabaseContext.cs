using System;
using System.Data.Entity;

namespace Codesmith.MvcSample.DataAccess.EntityRepo
{
    class DatabaseContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserProfileEntity> UserProfiles { get; set; }
    }
}
