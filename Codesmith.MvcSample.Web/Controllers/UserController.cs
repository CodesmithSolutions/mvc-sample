using System.Collections.Generic;
using System.Web.Mvc;
using Codesmith.MvcSample.Services;
using Codesmith.MvcSample.Services.Contracts;
using Codesmith.MvcSample.Web.Models;

namespace Codesmith.MvcSample.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;

            
        }


        public ActionResult Index()
        {
            //var users = _userService.GetUsers();
            return View("Index");
        }

        public ActionResult Edit()
        {
            var model = new EditUserModel();
            return View("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(EditUserModel user)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", user);
            }

            return RedirectToAction("Index");
        }

    }
}