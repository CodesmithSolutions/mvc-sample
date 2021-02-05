using System;

namespace Codesmith.MvcSample.DataAccess.EntityRepo
{
    class UserEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public Byte[] PasswordHash { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public virtual UserProfileEntity UserProfile { get; set; }
    }
}
