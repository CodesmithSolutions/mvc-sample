using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Codesmith.MvcSample.BusinessObjects;
using Codesmith.MvcSample.DataAccess.Entities;
using Codesmith.MvcSample.DataAccess.EntityRepo;

namespace Codesmith.MvcSample.DataAccess.Infrastructure
{
    public class AutoMapperServiceProfile : Profile
    {
        public AutoMapperServiceProfile()
        {
            CreateMap<UserDto, UserEntity>();


            CreateMap<UserEntity, UserDto>();


            //CreateMap<BusinessObjects.Document, Document>()
            //    .ForMember(dest => dest.CreateDate, opt => opt.Ignore())
            //    .ForMember(dest => dest.LastUpdateDate, opt => opt.Ignore());
        }
    }
}
