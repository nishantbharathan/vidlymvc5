﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using AutoMapper;
using Vidly.Dtos;
namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>().ForMember(c=>c.ID,opt=>opt.Ignore()) ;


            Mapper.CreateMap<Movie, MovieDTO>();
            Mapper.CreateMap<MovieDTO, Movie>().ForMember(m => m.Id, opt => opt.Ignore());


            Mapper.CreateMap<MemberShipType,MemberShipTypeDTO >();
            Mapper.CreateMap<Genre, GenreDTO>();
        }

    }
}