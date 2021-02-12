using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Codesmith.MvcSample.BusinessObjects;
using Codesmith.MvcSample.DataAccess.Contracts;
using Moq;
using NUnit.Framework;
using Should;

namespace Codesmith.MvcSample.Services.Tests
{
    [TestFixture]
    public class UserServiceTest
    {
        [Test]
        public void VerifyUser_UserNotFound_ShouldReturn_False()
        {
            var userRepositoryMock = new Mock<IUserRepository>(MockBehavior.Strict);
            userRepositoryMock
                .Setup(m => m.GetUserByUsername(It.IsAny<string>()))
                .Returns((UserDto)null);

            var service = new UserService(userRepositoryMock.Object);

            var result = service.VerifyUser("test@fake.com", "Password123");
            result.ShouldBeFalse();

            userRepositoryMock.Verify(x => x.GetUserByUsername("test@fake.com"), Times.Once());
        }

        [Test]
        public void VerifyUser_InvalidPassword_ShouldReturn_False()
        {
            var userRepositoryMock = new Mock<IUserRepository>(MockBehavior.Strict);
            userRepositoryMock
                .Setup(m => m.GetUserByUsername(It.IsAny<string>()))
                .Returns((UserDto)null);

            var service = new UserService(userRepositoryMock.Object);

            var result = service.VerifyUser("test@fake.com", "SomeWrongPassword");
            result.ShouldBeFalse();

            userRepositoryMock.Verify(x => x.GetUserByUsername("test@fake.com"), Times.Once());
        }

        [Test]
        public void VerifyUser_ValidUserPassword_ShouldReturn_True()
        {
            var sha512CryptoProvider = new SHA512CryptoServiceProvider();

            var userRepositoryMock = new Mock<IUserRepository>(MockBehavior.Strict);
            userRepositoryMock
                .Setup(m => m.GetUserByUsername(It.IsAny<string>()))
                .Returns(new UserDto
                {
                    UserId = 12,
                    Username = "test@fake.com",
                    PasswordHash = sha512CryptoProvider.ComputeHash(Encoding.ASCII.GetBytes("Password123"))
                });

            var service = new UserService(userRepositoryMock.Object);

            var result = service.VerifyUser("test@fake.com", "Password123");

            result.ShouldBeTrue();

            userRepositoryMock.Verify(x => x.GetUserByUsername("test@fake.com"), Times.Once());
        }

    }
}
