﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Restaurant.Domain.Dto;
using Restaurant.Domain.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.AutoMapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<IdentityUser, UserInfoDto>()
                .ForMember(pr=>pr.IsEmailConfirmed , req=>req.MapFrom(src=>src.EmailConfirmed))
                .ForMember(pr=>pr.UserName , req=>req.MapFrom(src=>src.UserName))
                .ForMember(pr=>pr.Phone , req=>req.MapFrom(src=>src.PhoneNumber))
                .ForMember(pr=>pr.Email , req=>req.MapFrom(src=>src.Email));



            CreateMap<CreateRestaurantDto, Domain.Enitites.Restaurant>()
                .ForMember(pr => pr.ContactDetails, req => req.MapFrom(src => new ContactDetails()
                {
                    Street = src.Street,
                    City = src.City,
                    PostalCode = src.PostalCode, 
                    PostalCity = src.PostalCity,
                    PhoneNumber = src.PhoneNumber,
                    Email = src.Email,
                    Country = src.Country

                }));



            CreateMap<Domain.Enitites.Restaurant, GetRestaurantDto>()
                .ForMember(pr => pr.Street, req => req.MapFrom(src => src.ContactDetails.Street))
                .ForMember(pr => pr.City, req => req.MapFrom(src => src.ContactDetails.City))
                .ForMember(pr => pr.PhoneNumber, req => req.MapFrom(src => src.ContactDetails.PhoneNumber))
                .ForMember(pr => pr.Email, req => req.MapFrom(src => src.ContactDetails.Email))
                .ForMember(pr => pr.Country, req => req.MapFrom(src => src.ContactDetails.Country));


            CreateMap<Domain.Enitites.Restaurant, ParticularGetRestaurantDto>()
               .ForMember(pr => pr.Street, req => req.MapFrom(src => src.ContactDetails.Street))
               .ForMember(pr => pr.City, req => req.MapFrom(src => src.ContactDetails.City))
               .ForMember(pr => pr.PhoneNumber, req => req.MapFrom(src => src.ContactDetails.PhoneNumber))
               .ForMember(pr => pr.Email, req => req.MapFrom(src => src.ContactDetails.Email))
               .ForMember(pr => pr.Country, req => req.MapFrom(src => src.ContactDetails.Country))
               .ForMember(pr=>pr.PostalCode, req=>req.MapFrom(src=>src.ContactDetails.PostalCode))
               .ForMember(pr=>pr.PostalCity, req=>req.MapFrom(src=>src.ContactDetails.PostalCity));

        }
    }
}