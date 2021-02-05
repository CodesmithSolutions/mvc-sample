using AutoMapper;
using Codesmith.MvcSample.BusinessObjects;
using Codesmith.MvcSample.DataAccess.EntityRepo;

namespace Codesmith.MvcSample.DataAccess.Infrastructure.Extensions
{
    static class EntityRepoExtensions
    {

        // Entity to DTO Mapping Extensions
        public static UserDto ToDto(this UserEntity user, IMapper mapper)
        {
            return mapper.Map<UserEntity, UserDto>(user);
        }


        // DTO to Entity Mapping Extensions
        public static UserEntity ToEntity(this UserDto user, IMapper mapper)
        {
            return mapper.Map<UserDto, UserEntity>(user);
        }

        //public static UserProfile ToDto(this UserProfileEntity user, IMapper mapper)
        //{
        //    return mapper.Map<UserProfileEntity, UserProfile>(user);
        //}
    }
}