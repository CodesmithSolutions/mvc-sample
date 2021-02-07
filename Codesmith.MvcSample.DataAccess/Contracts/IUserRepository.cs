using Codesmith.MvcSample.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesmith.MvcSample.DataAccess.Contracts
{
    public interface IUserRepository
    {
        bool CheckUserExists(string username);

        UserDto GetUserById(int userId);
        List<UserDto> GetUsers(bool isActiveOnly);
        UserDto UpdateUser(UserDto user);
        UserDto CreateUser(UserDto user);
    }
}
