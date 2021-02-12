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
    public class AutoMapperEntityProfileTests
    {
        private MapperConfiguration _mapperConfiguration;
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            _mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperEntityProfile>());
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
                CreatedByUserId = 2
            };

            var issueDto = _mapper.Map<IssueDto>(issueEntity);

            issueDto.IssueId.ShouldEqual(issueEntity.IssueId);
            issueDto.Type.ShouldEqual(IssueType.Bug);
            issueDto.Status.ShouldEqual(IssueStatusType.Open);
            issueDto.Priority.ShouldEqual(IssuePriorityType.High);
            issueDto.AssignedToUserId.ShouldEqual(issueEntity.AssignedToUserId);
            issueDto.CreatedByUserId.ShouldEqual(issueEntity.CreatedByUserId);
        }

        [Test]
        public void AutoMapper_UserEntityWithProfileAndCreatedByIssues_Maps_ToDto_ShouldBeValid()
        {
            var userEntity = new UserEntity
            {
                UserId = 1234,
                Username = "john.doe",
                Profile = new UserProfileEntity
                {
                    FirstName = "John",
                    LastName = "Doe",
                    EmailAddress = "john.doe@fake.com"
                },
                CreatedBy = new List<IssueEntity>
                {
                    new IssueEntity
                    {
                        IssueId =  1,
                        Status = "Open",
                    },
                    new IssueEntity
                    {
                        IssueId = 2,
                        Status = "InProgress"
                    }
                }
            };

            var userDto = _mapper.Map<UserDto>(userEntity);

            userDto.UserId.ShouldEqual(userEntity.UserId);
            userDto.Username.ShouldEqual(userEntity.Username);
            userDto.Profile.ShouldNotBeNull();
            userDto.Profile.FirstName.ShouldEqual("John");
            userDto.Profile.LastName.ShouldEqual("John");
            userDto.Profile.EmailAddress.ShouldEqual("john.doe@fake.com");
            userDto.CreatedBy.Count.ShouldEqual(2);
            userDto.CreatedBy[0].IssueId.ShouldEqual(1);
            userDto.CreatedBy[0].Status.ShouldEqual(IssueStatusType.Open);
            userDto.CreatedBy[1].IssueId.ShouldEqual(2);
            userDto.CreatedBy[1].Status.ShouldEqual(IssueStatusType.InProgress);
        }
    }
}

