﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wellness.Models.User;

namespace wellness.Service.Services
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegisterRequest, Database.User>();
            CreateMap<Database.User, User>();

        }
    }
}
