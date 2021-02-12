using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Codesmith.MvcSample.BusinessObjects;
using Codesmith.MvcSample.Web.Models;

namespace Codesmith.MvcSample.Web.Infrastructure
{
    public class AutoMapperModelProfile : Profile
    {
        public AutoMapperModelProfile()
        {
            // Model to Dto Mappings
            CreateMap<UserModel, UserDto>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.LastLoginDate, opt => opt.Ignore())
                .ForMember(dest => dest.CreateDate, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdateDate, opt => opt.Ignore())
                .ForMember(dest => dest.AssignedTo, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.Profile, opt => opt.Ignore());
            CreateMap<UserEditModel, UserDto>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.LastLoginDate, opt => opt.Ignore())
                .ForMember(dest => dest.CreateDate, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdateDate, opt => opt.Ignore())
                .ForMember(dest => dest.AssignedTo, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.Profile, opt => opt.Ignore());

            CreateMap<IssueModel, IssueDto>()
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.AssignedTo, opt => opt.Ignore());


            // Dto to Model Mappings
            CreateMap<UserDto, UserModel>();
            CreateMap<UserDto, UserEditModel>()
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                .ForMember(dest => dest.ConfirmPassword, opt => opt.Ignore());

            CreateMap<IssueDto, IssueModel>();
            // An Example of Model Flattening
            CreateMap<IssueDto, IssueSimpleModel>()
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(source => source.CreatedBy.Username))
                .ForMember(dest => dest.AssignedTo, opt => opt.MapFrom(source => source.AssignedTo == null ? "Unassigned" : source.AssignedTo.Username));
        }
    }
}