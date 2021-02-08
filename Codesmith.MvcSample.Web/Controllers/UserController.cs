using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Codesmith.MvcSample.BusinessObjects;
using Codesmith.MvcSample.Services;
using Codesmith.MvcSample.Services.Contracts;
using Codesmith.MvcSample.Web.Models;

namespace Codesmith.MvcSample.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet, Route("users")]
        public ActionResult Index()
        {
            var users = _userService.GetUsers();
            return View("Index", _mapper.Map<List<UserModel>>(users));
        }

        [HttpGet, Route("users/new")]
        public ActionResult CreateUser()
        {
            return View("Edit", new UserEditModel());
        }

        [HttpGet, Route("users/{userId:int}")]
        public ActionResult EditUser(int userId)
        {
            var user = _userService.GetUserById(userId);
            return View("Edit", _mapper.Map<UserEditModel>(user));
        }

        [HttpPost, Route("users/update")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateUser(UserEditModel user)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", user);
            }

            if(user.UserId == 0)
                _userService.CreateUser(_mapper.Map<UserDto>(user));
            else
                _userService.UpdateUser(_mapper.Map<UserDto>(user));

            return RedirectToAction("Index");
        }
    }
}