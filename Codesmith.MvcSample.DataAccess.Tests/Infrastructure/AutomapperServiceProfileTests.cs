using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Codesmith.MvcSample.BusinessObjects;
using Codesmith.MvcSample.DataAccess.EntityRepo;
using Codesmith.MvcSample.DataAccess.Infrastructure;
using NUnit.Framework;
using Should;

namespace Codesmith.MvcSample.DataAccess.Tests.Infrastructure
{
    [TestFixture]
    public class AutoMapperServiceProfileTests
    {
        private MapperConfiguration _mapperConfiguration;
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            _mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperServiceProfile>());
            _mapper = _mapperConfiguration.CreateMapper();
        }

        [Test]
        public void AutoMapper_Configuration_IsValid()
        {
            _mapperConfiguration.AssertConfigurationIsValid();
        }

        [Test]
        public void AutoMapper_UserEntity_Maps_ToDto_ShouldBeValid()
        {
            var userEntity = new UserEntity
            {
                UserId = 1234,
                Username = "john.doe",
                //PasswordHash = xxx
                IsActive = true,
                CreateDate = new DateTime(2020, 5, 1, 2, 34, 15),
                LastUpdateDate = new DateTime(2021, 3, 6, 11, 43, 25),
                LastLoginDate = new DateTime(2021, 2, 1, 4, 6, 59),

            };

            var userDto = _mapper.Map<UserDto>(userEntity);

            userDto.UserId.ShouldEqual(userEntity.UserId);
            userDto.Username.ShouldEqual(userEntity.Username);
            userDto.IsActive.ShouldEqual(userEntity.IsActive);
            userDto.CreateDate.ShouldEqual(userEntity.CreateDate);
            userDto.LastUpdateDate.ShouldEqual(userEntity.LastUpdateDate);
            userDto.LastLoginDate.ShouldEqual(userEntity.LastLoginDate);
            //userDto.PasswordHash.ShouldEqual(userEntity.PasswordHash);
        }

        [Test]
        public void AutoMapper_IssueEntity_Maps_ToDto_ShouldBeValid()
        {
            var issueEntity = new IssueEntity
            {
                IssueId = 1234,
                Type = "Bug",
                Status = "Open",
                Priority = "High",
                AssignedToUserId = 1,
                CreatedByUserId = 2,
                CreateDate = new DateTime(2020, 5, 1, 2, 34, 15),
                LastUpdateDate = new DateTime(2021, 3, 6, 11, 43, 25),
            };

            var issueDto = _mapper.Map<IssueDto>(issueEntity);

            issueDto.IssueId.ShouldEqual(issueEntity.IssueId);
            issueDto.Type.ShouldEqual(IssueType.Bug);
            issueDto.Status.ShouldEqual(IssueStatusType.Open);
            issueDto.Priority.ShouldEqual(IssuePriorityType.High);
            issueDto.AssignedToUserId.ShouldEqual(issueEntity.AssignedToUserId);
            issueDto.CreatedByUserId.ShouldEqual(issueEntity.CreatedByUserId);
            issueDto.CreateDate.ShouldEqual(issueEntity.CreateDate);
            issueDto.LastUpdateDate.ShouldEqual(issueEntity.LastUpdateDate);
        }
    }
}
