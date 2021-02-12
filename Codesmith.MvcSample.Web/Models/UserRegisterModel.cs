using System.ComponentModel.DataAnnotations;
using Codesmith.MvcSample.BusinessObjects;

namespace Codesmith.MvcSample.Web.Models
{
    public class UserRegisterModel
    {
        [Required, MinLength(3), MaxLength(255)]
        public string Username { get; set; }

        [Required, Compare("Password"), MinLength(6), MaxLength(255)]
        public string Password { get; set; }

        [Required, MinLength(6), MaxLength(255)]

        public string ConfirmPassword { get; set; }
    }
}