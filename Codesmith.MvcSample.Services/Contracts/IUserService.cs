﻿using Codesmith.MvcSample.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesmith.MvcSample.Services.Contracts
{
    public interface IUserService
    {
        UserDto GetUserById(int userId);

        UserDto VerifyUser(string username, string password);

        List<UserDto> GetUsers(bool activeOnly);

        bool DoesUserExist(int userId, string username);

        bool UserExists(string username);

        UserDto CreateUser(UserDto userDto);

        UserDto UpdateUser(UserDto userDto);
    }
}
