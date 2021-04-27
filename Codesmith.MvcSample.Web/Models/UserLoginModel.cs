using Codesmith.MvcSample.Web.Infrastructure.Validators;
using FluentValidation.Attributes;

namespace Codesmith.MvcSample.Web.Models
{
    public class UserLoginModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

    }
}