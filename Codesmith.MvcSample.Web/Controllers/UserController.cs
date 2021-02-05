using System.Collections.Generic;
using System.Web.Mvc;
using Codesmith.MvcSample.Services;
using Codesmith.MvcSample.Web.Models;

namespace Codesmith.MvcSample.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

    }
}