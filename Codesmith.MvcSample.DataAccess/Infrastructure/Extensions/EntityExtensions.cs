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
        public static IssueDto ToDto(this IssueEntity issue, IMapper mapper)
        {
            return mapper.Map<IssueEntity, IssueDto>(issue);
        }


        // DTO to Entity Mapping Extensions
        public static UserEntity ToEntity(this UserDto user, IMapper mapper)
        {
            return mapper.Map<UserDto, UserEntity>(user);
        }
        public static IssueEntity ToEntity(this IssueDto issue, IMapper mapper)
        {
            return mapper.Map<IssueDto, IssueEntity>(issue);
        }

        //public static UserProfile ToDto(this UserProfileEntity user, IMapper mapper)
        //{
        //    return mapper.Map<UserProfileEntity, UserProfile>(user);
        //}
    }
}