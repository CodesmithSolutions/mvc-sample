using Codesmith.MvcSample.Web.Infrastructure.Validators;
using FluentValidation.Attributes;

namespace Codesmith.MvcSample.Web.Models
{
    public class UserContactPreferenceModel
    {
        public ContactPreferenceMethodType ContactPreferenceMethodType { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
