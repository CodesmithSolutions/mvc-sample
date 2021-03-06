﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Codesmith.MvcSample.DataAccess.EntityRepo
{
    [Table("UserProfile")]
    class UserProfileEntity
    {
        [Required, Key, ForeignKey("User")]
        public int UserProfileId { get; set; }
        [StringLength(255)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime LastUpdateDate { get; set; }

        public virtual UserEntity User { get; set; }
    }
}
