using Codesmith.MvcSample.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesmith.MvcSample.Services.Contracts
{
    public interface IUserService
    {
        void GetUserById(int userId);

        List<UserDto> GetUsers();

        bool UserExists(string username);

        UserDto CreateUser(UserDto userDto);

        UserDto UpdateUser(UserDto userDto);
    }
}
