using AutoMapper;
using Codesmith.MvcSample.DataAccess.EntityRepo;
using Codesmith.MvcSample.DataAccess.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Codesmith.MvcSample.DataAccess
{
    public class User
    {

    }
    public class UserRepository
    {
        private readonly IMapper _mapper;

        public UserRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public User GetUserById(int userId)
        {
            using (var context = new DatabaseContext())
            {
                return context.Users
                    .FirstOrDefault(x => x.Id == userId)
                    .ToDto(_mapper);
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
