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
            CreateMap<UserModel, UserDto>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.LastLoginDate, opt => opt.Ignore())
                .ForMember(dest => dest.CreateDate, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdateDate, opt => opt.Ignore())
                .ForMember(dest => dest.Issues, opt => opt.Ignore());
            CreateMap<UserEditModel, UserDto>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.LastLoginDate, opt => opt.Ignore())
                .ForMember(dest => dest.CreateDate, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdateDate, opt => opt.Ignore())
                .ForMember(dest => dest.Issues, opt => opt.Ignore());

            CreateMap<UserDto, UserModel>();
            CreateMap<UserDto, UserEditModel>()
                .ForMember(dest => dest.Password, opt => opt.Ignore());


        }
    }
}