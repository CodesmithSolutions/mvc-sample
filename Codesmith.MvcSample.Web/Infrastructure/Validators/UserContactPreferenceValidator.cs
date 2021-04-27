using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Codesmith.MvcSample.Web.Models;
using FluentValidation;

namespace Codesmith.MvcSample.Web.Infrastructure.Validators
{
    public class UserContactPreferenceValidator : AbstractValidator<UserContactPreferenceModel>
    {
        public UserContactPreferenceValidator()
        {
            // If Contact Preference type is email then Email Address is Required
            RuleFor(x => x.EmailAddress)
                .NotEmpty()
                .EmailAddress()
                .Length(3, 255)
                .When(x => x.ContactPreferenceMethodType == ContactPreferenceMethodType.Email);

            // If Contact Preference type is phone then a phone number is Required
            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .Length(10)
                .When(x => x.ContactPreferenceMethodType == ContactPreferenceMethodType.Phone);
        }
    }
}