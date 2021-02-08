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

            // Dto to entity Mappings
            CreateMap<UserDto, UserEntity>()
                //.ForMember(dest => dest.UserProfile, opt => opt.Ignore())
                .ForMember(dest => dest.Issues, opt => opt.Ignore());
            CreateMap<IssueDto, IssueEntity>()
                .ForMember(dest => dest.Status,
                    opt => opt.MapFrom(source => Enum.GetName(typeof(IssueStatusType), source.Status)))
                .ForMember(dest => dest.Priority,
                    opt => opt.MapFrom(source => Enum.GetName(typeof(IssuePriorityType), source.Priority)))
                .ForMember(dest => dest.Type,
                    opt => opt.MapFrom(source => Enum.GetName(typeof(IssueType), source.Type)));




            //CreateMap<BusinessObjects.Document, Document>()
            //    .ForMember(dest => dest.CreateDate, opt => opt.Ignore())
            //    .ForMember(dest => dest.LastUpdateDate, opt => opt.Ignore());
        }
    }
}
