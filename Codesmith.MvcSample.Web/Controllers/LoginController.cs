using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using Codesmith.MvcSample.BusinessObjects;
using Codesmith.MvcSample.Services;
using Codesmith.MvcSample.Services.Contracts;
using Codesmith.MvcSample.Web.Models;

namespace Codesmith.MvcSample.Web.Controllers
{
    [AllowAnonymous]
    public class LoginController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public LoginController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet, Route("login")]
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost, Route("login")]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", model);
            }

            var result = _userService.VerifyUser(model.Username, model.Password);
            if (result != null)
            {
                ModelState.AddModelError(string.Empty, "Invalid Login");
                return View("Login", model);
            }

            // create encryption cookie         
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1,
            model.Username, 
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
            return RedirectToRoute("Index", "Home");
        }

        [HttpGet, Route("register")]
        public ActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                //_userService.Register(_mapper.Map<UserDto>(model));
                return RedirectToAction("login");
            }

            return View("Register", model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToRoute("login");
        }
    }
}