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
            return _userRepository.GetUsers(false);
        }

        public bool UserExists(string username)
        {
            throw new NotImplementedException();
        }

        public UserDto CreateUser(UserDto userDto)
        {
            userDto.CreateDate = DateTime.Now;
            userDto.LastUpdateDate = DateTime.Now;
            return _userRepository.CreateUser(userDto);
        }

        public UserDto UpdateUser(UserDto userDto)
        {
            userDto.CreateDate = DateTime.Now;
            userDto.LastUpdateDate = DateTime.Now;
            return _userRepository.UpdateUser(userDto);
        }

        public UserDto GetUserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }
    }
}
