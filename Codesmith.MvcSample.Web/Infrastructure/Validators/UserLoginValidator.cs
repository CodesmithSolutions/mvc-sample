using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Codesmith.MvcSample.Web.Models;
using FluentValidation;

namespace Codesmith.MvcSample.Web.Infrastructure.Validators
{
    public class UserLoginValidator : AbstractValidator<UserLoginModel>
    {
        public UserLoginValidator()
        {
            RuleFor(x => x.Username).NotNull();
            RuleFor(x => x.Password).NotNull();
        }
    }
}