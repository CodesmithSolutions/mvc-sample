using AutoMapper;
using Codesmith.MvcSample.DataAccess.EntityRepo;

namespace Codesmith.MvcSample.DataAccess.Infrastructure.Extensions
{
    static class EntityRepoExtensions
    {
        public static User ToDto(this UserEntity user, IMapper mapper)
        {
            return mapper.Map<UserEntity, User>(user);
        }

        //public static UserProfile ToDto(this UserProfileEntity user, IMapper mapper)
        //{
        //    return mapper.Map<UserProfileEntity, UserProfile>(user);
        //}
    }
}