﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Model.Category;
using wellness.Model.User;
using wellness.Models.User;

namespace wellness.Service.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegisterRequest, Database.User>();
            //CreateMap<Database.User, User>();
            CreateMap<Database.User, User>().ForMember(dest=> dest.Role,opt=>opt.MapFrom(src=>src.Role.Name))
                                            .ForMember(dest=>dest.ShiftTime,opt=>opt.MapFrom(src=>src.Role.ShiftTime));
            CreateMap<Category, Database.Category>();
            CreateMap<Database.Category,Category>();

        }
    }
}
