using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Security;
using System.Web;
using System.Web.Security;
using Codesmith.MvcSample.Services.Contracts;

namespace Codesmith.MvcSample.Web.Infrastructure
{
    public class SessionManager
    {
        private readonly IUserService _userService;

        public SessionManager(IUserService userService)
        {
            _userService = userService;
        }
        public bool Login(string username, string password)
        {
            var result = _userService.VerifyUser(username, password);
            if (result == null)
            {
                return false;
            }

            // create encryption cookie         
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1,
                username,
                DateTime.Now,
                DateTime.Now.AddDays(90),
                true,
                string.Empty);

            // add cookie to response stream         
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            System.Web.HttpCookie authCookie = new System.Web.HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            if (authTicket.IsPersistent)
            {
                authCookie.Expires = authTicket.Expiration;
            }
            System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);
            //FormsAuthentication.SetAuthCookie(model.Username, true);
            return true;
        }

        public void Logout()
        {

        }
    }
}