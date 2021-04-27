using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using Codesmith.MvcSample.Services.Contracts;
using Codesmith.MvcSample.Web.Models;
using FluentValidation;
using FluentValidation.Results;

namespace Codesmith.MvcSample.Web.Infrastructure.Validators
{
    public class UserRegisterValidator : AbstractValidator<UserRegisterModel>
    {
        public UserRegisterValidator(IUserService userService)
        {
            RuleFor(x => x.Username).NotNull().Length(3, 12);
            RuleFor(x => x.Password).NotNull().Length(3, 12);
            RuleFor(x => x.ConfirmPassword).NotNull().Length(3, 12)
                .Equal(x => x.Password);
            RuleFor(x => x.FirstName).NotNull().Length(3, 12);
            RuleFor(x => x.LastName).NotNull().Length(3, 12);
            RuleFor(x => x.EmailAddress).NotNull().EmailAddress();

            Custom(rm =>
            {
                var exists = userService.DoesUserExist(0, rm.Username);

                if (exists)
                    return new ValidationFailure("Username", "This user name already exists");

                return null;
            });
        }
    }
}