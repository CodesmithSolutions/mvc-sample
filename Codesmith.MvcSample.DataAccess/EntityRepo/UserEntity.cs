using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codesmith.MvcSample.DataAccess.EntityRepo
{
    [Table("User")]
    class UserEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required, StringLength(100)]
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        //public virtual UserProfileEntity UserProfile { get; set; }

        public virtual ICollection<IssueEntity> Issues { get; set; }
    }
}
