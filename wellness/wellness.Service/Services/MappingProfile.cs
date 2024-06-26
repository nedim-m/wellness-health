﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using wellness.Model.Category;
using wellness.Model.Membership;
using wellness.Model.MembershipType;
using wellness.Model.Rating;
using wellness.Model.Record;
using wellness.Model.Report;
using wellness.Model.Reservation;
using wellness.Model.Role;

using wellness.Model.Shift;
using wellness.Model.Transaction;
using wellness.Model.Treatment;
using wellness.Model.TreatmentType;
using wellness.Model.User;
using wellness.Models.User;
using wellness.Models.UserPostRequest;

namespace wellness.Service.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegisterRequest, Database.User>();
            CreateMap<UserUpdateRequest, Database.User>();
            CreateMap<UserPostRequest, Database.User>();
            CreateMap<UserDesktopInsert, Database.User>();
            CreateMap<UserEmployeeDesktopUpdate, Database.User>();

            CreateMap<Database.User, User>()
     .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Name))
     .ForMember(dest => dest.ShiftTime, opt => opt.MapFrom(src => src.Shift.WorkingHours))
     .ForMember(dest => dest.MembershipType, opt => opt.MapFrom(src => src.Memberships.FirstOrDefault().MemberShipType.Name));


            CreateMap<CategoryPostRequest, Database.Category>();
            CreateMap<Database.Category, Category>();

            CreateMap<TreatmentTypePostRequest, Database.TreatmentType>();
            CreateMap<Database.TreatmentType, TreatmentType>();

            CreateMap<TreatmentPostRequest, Database.Treatment>();
            CreateMap<Database.Treatment, Treatment>().ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
                                                      .ForMember(dest => dest.TreatmentType, opt => opt.MapFrom(src => src.TreatmentType.Name));

            CreateMap<Treatment, RecommendationTreatment>();
           





            CreateMap<MembershipTypePostRequest, Database.MembershipType>();
            CreateMap<Database.MembershipType, MembershipType>();

            CreateMap<RecordPostRequest, Database.Record>();
            CreateMap<Database.Record, Record>().ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                                                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                                                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.User.Phone))
                                                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));


            CreateMap<Database.Role, Role>();
            CreateMap<Database.Shift, Shift>();


            CreateMap<ReservationPostRequest, Database.Reservation>();
            CreateMap<ReservationUpdateRequest, Database.Reservation>();
            CreateMap<Database.Reservation, Reservation>().ForMember(dest => dest.Treatment, opt => opt.MapFrom(src => src.Treatment.Name))
                                                          .ForMember(dest => dest.TreatmentId, opt => opt.MapFrom(src => src.Treatment.Id))
                                                          .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                                                          .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                                                          .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.User.Phone));



            CreateMap<RatingPostRequest, Database.Rating>();
            CreateMap<RatingUpdateRequest, Database.Rating>();
            CreateMap<Database.Rating, Rating>();

            CreateMap<MembershipPostRequest, Database.Membership>();
            CreateMap<MembershipUpdateRequest, Database.Membership>();
            CreateMap<Database.Membership, Membership>().ForMember(dest => dest.MemberShipTypeName, opt => opt.MapFrom(src => src.MemberShipType.Name))
                                                        .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                                                        .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.MemberShipType.Price));

            CreateMap<Transaction, Database.Transaction>();
            CreateMap<Database.Transaction, Transaction>();

            CreateMap<ReportPostRequest, Database.Report>();
            CreateMap<Database.Report, Report>().ForMember(dest => dest.MemberShipTypeName, opt => opt.MapFrom(src => src.MemberShipType.Name));


        }
    }
}

