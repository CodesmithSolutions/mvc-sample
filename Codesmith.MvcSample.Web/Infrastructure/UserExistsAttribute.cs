using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Codesmith.MvcSample.Services.Contracts;

namespace Codesmith.MvcSample.Web.Infrastructure
{
    // NOT WORKING YET
    public class UserExistsAttribute : ValidationAttribute
    {
        private readonly IUserService _userService;

        public UserExistsAttribute(IUserService userService)
        {
            _userService = userService;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {   // NOTE THIS IS NOT WORKING YET!!!
            ErrorMessage = ErrorMessageString;
            var currentValue = (string)value;

            
            //if (currentValue > comparisonValue)
                return new ValidationResult("User Already Exists");

            //return ValidationResult.Success;
        }
    }
}