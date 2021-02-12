using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Codesmith.MvcSample.BusinessObjects;
using Codesmith.MvcSample.Services.Contracts;

namespace Codesmith.MvcSample.Web.Infrastructure.Helpers
{
    public class UserSelectListHelpers
    {

        private readonly IUserService _userService;

        public UserSelectListHelpers(IUserService userService)
        {
            _userService = userService;
        }

        public SelectList GetSelectList()
        {
            var users = _userService.GetUsers(true);

            var selectListItems = new List<SelectListItem>();
            foreach(var user in users)
            {
                selectListItems.Add(new SelectListItem
                {
                    Value = user.UserId.ToString(),
                    Text = user.Username
                });
            }

            return new SelectList(selectListItems, "Value", "Text");
        }
    }
}