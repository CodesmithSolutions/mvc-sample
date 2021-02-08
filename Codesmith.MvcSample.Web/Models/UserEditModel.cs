using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Codesmith.MvcSample.Web.Infrastructure;

namespace Codesmith.MvcSample.Web.Models
{
    public class UserEditModel
    {
        [Required]
        public int UserId { get; set; }
        [Required, MinLength(3), MaxLength(255)]
        public string Username { get; set; }
        [Required, MinLength(6), MaxLength(255)]
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}