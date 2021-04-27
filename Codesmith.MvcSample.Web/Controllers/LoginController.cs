using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using Codesmith.MvcSample.BusinessObjects;
using Codesmith.MvcSample.Services;
using Codesmith.MvcSample.Services.Contracts;
using Codesmith.MvcSample.Web.Infrastructure;
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

            var sessionManager = new SessionManager(_userService);
            var result = sessionManager.Login(model.Username, model.Password);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Invalid Login");
                return View("Login", model);
            }

            return RedirectToAction("Index", "Home");
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

        [HttpGet, Route("forgot-password")]
        public ActionResult ForgotPassword()
        {
            return View("ForgotPassword");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToRoute("login");
        }

        [HttpGet]
        public ActionResult UpdateContactPreferences()
        {
            return View("ContactPreferences", new UserContactPreferenceModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateContactPreferences(UserContactPreferenceModel model)
        {
            if (ModelState.IsValid)
            {
                //_userService.Register(_mapper.Map<UserDto>(model));
                return RedirectToAction("login");
            }

            return View("ContactPreferences", model);
        }
    }
}