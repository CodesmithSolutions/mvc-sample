using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Codesmith.MvcSample.BusinessObjects;
using Codesmith.MvcSample.DataAccess.EntityRepo;

namespace Codesmith.MvcSample.DataAccess.Infrastructure
{
    public class AutoMapperEntityProfile : Profile
    {
        public AutoMapperEntityProfile()
        {
            // Entity to Dto Mappings
            CreateMap<UserEntity, UserDto>();
            CreateMap<IssueEntity, IssueDto>();
            CreateMap<UserProfileEntity, UserProfileDto>()
                .ForMember(dest => dest.UserProfileId, 
                    opt => opt.MapFrom(source => source.UserProfileId));

            // Dto to entity Mappings
            CreateMap<UserDto, UserEntity>()
                .ForMember(dest => dest.Profile, opt => opt.Ignore());
            CreateMap<IssueDto, IssueEntity>()
                .ForMember(dest => dest.Status,
                    opt => opt.MapFrom(source => Enum.GetName(typeof(IssueStatusType), source.Status)))
                .ForMember(dest => dest.Priority,
                    opt => opt.MapFrom(source => Enum.GetName(typeof(IssuePriorityType), source.Priority)))
                .ForMember(dest => dest.Type,
                    opt => opt.MapFrom(source => Enum.GetName(typeof(IssueType), source.Type)))
                .ForMember(dest => dest.CreateDate, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdateDate, opt => opt.Ignore()); 

        }
    }
}
