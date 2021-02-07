using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Codesmith.MvcSample.DataAccess.EntityRepo
{
    [Table("UserProfile")]
    class UserProfileEntity
    {
        [Key, ForeignKey("User")]
        public int UserProfileId { get; set; }
        [Required, ForeignKey("User")]
        [StringLength(255)]
        public string EmailAddress { get; set; }
        public DateTime LastLoginDate { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime LastUpdateDate { get; set; }

        public virtual UserEntity User { get; set; }
    }
}
