using Codesmith.MvcSample.Services.Contracts;
using Codesmith.MvcSample.DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codesmith.MvcSample.BusinessObjects;

namespace Codesmith.MvcSample.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserDto> GetUsers()
        {
            throw new NotImplementedException();
        }

        public bool UserExists(string username)
        {
            throw new NotImplementedException();
        }

        public UserDto CreateUser(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public UserDto UpdateUser(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public void GetUserById(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
