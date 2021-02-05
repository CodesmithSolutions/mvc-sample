using AutoMapper;
using Codesmith.MvcSample.DataAccess.EntityRepo;
using Codesmith.MvcSample.DataAccess.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Codesmith.MvcSample.DataAccess.Contracts;
using Codesmith.MvcSample.BusinessObjects;

namespace Codesmith.MvcSample.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;

        public UserRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public bool CheckUserExists(string username)
        {
            using (var context = new DatabaseContext())
            {
                return context.Users
                    .Any(x => x.Username == username);
            }
        }

        public UserDto GetUserById(int userId)
        {
            using (var context = new DatabaseContext())
            {
                return context.Users
                    .FirstOrDefault(x => x.Id == userId)
                    .ToDto(_mapper);
            }
        }

        public List<UserDto> GetUsers(bool isActiveOnly)
        {
            using (var context = new DatabaseContext())
            {
                var users = context.Users.AsQueryable();
                if (isActiveOnly)
                    users = users.Where(x => x.IsActive == true);
                
                return users
                    .ToList()
                    .Select(x => x.ToDto(_mapper))
                    .ToList();
            }
        }

        public UserDto UpdateUser(UserDto user)
        {
            using (var context = new DatabaseContext())
            {
                var entity = context.Users
                    .FirstOrDefault(x => x.Id == user.Id);

                if (entity == null)
                    return null;

                entity = _mapper.Map<UserEntity>(user);
                context.SaveChanges();

                return user;
            }
        }

        public UserDto CreateUser(UserDto user)
        {
            using (var context = new DatabaseContext())
            {
                var entity = user.ToEntity(_mapper);
                context.Users.Add(entity);
                context.SaveChanges();

                return entity.ToDto(_mapper);
            }
        }

        //public UserWithProfile GetUserWithProfile(int userId)
        //{
        //    using (var context = new DatabaseContext())
        //    {
        //        return context.Users
        //            .Include(x => x.UserProfile)
        //            .FirstOrDefault(x => x.Id == userId)
        //            .ToDto(_mapper);
        //    }
        //}
    }
}
