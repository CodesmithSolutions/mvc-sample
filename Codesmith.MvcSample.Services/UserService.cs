using Codesmith.MvcSample.Services.Contracts;
using Codesmith.MvcSample.DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Codesmith.MvcSample.BusinessObjects;
using Codesmith.MvcSample.DataAccess;

namespace Codesmith.MvcSample.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserDto> GetUsers(bool isActiveOnly)
        {
            return _userRepository.GetUsers(isActiveOnly);
        }

        public bool DoesUserExist(int userId, string username)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user == null)
                return false;

            return userId != user.UserId;
        }

        public UserDto VerifyUser(string username, string password)
        {
            var sha512CryptoProvider = new SHA512CryptoServiceProvider();
            var userEnteredPassword = Convert.ToBase64String(sha512CryptoProvider.ComputeHash(Encoding.ASCII.GetBytes(password)));

            var user = _userRepository.GetUserByUsername(username);
            if (user == null)
                return null;

            if (Convert.ToBase64String(user.PasswordHash) == userEnteredPassword)
                return user;

            return null;
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
