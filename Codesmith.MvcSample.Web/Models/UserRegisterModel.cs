using Codesmith.MvcSample.Web.Infrastructure.Validators;
using FluentValidation.Attributes;

namespace Codesmith.MvcSample.Web.Models
{
    public class UserRegisterModel
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}