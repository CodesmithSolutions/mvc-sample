using System;
using System.Collections.Generic;
using System.Text;

namespace Codesmith.MvcSample.DataAccess.EntityRepo
{
    class UserProfileEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string EmailAddress { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public virtual UserEntity User { get; set; }
    }
}
