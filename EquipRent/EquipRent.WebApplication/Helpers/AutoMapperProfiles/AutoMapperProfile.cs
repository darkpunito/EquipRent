﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO = EquipRent.Domain.DTO;
using Entities = EquipRent.Database.Entities;
using ViewModels = EquipRent.WebApplication.Models;

namespace EquipRent.WebApplication.Helpers.AutoMapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Entities.Model, DTO.ModelDTO>().ReverseMap();
            CreateMap<DTO.ModelDTO, ViewModels.ModelViewModel>().ReverseMap();
            CreateMap<Entities.Equipment, DTO.EquipmentDTO>().ReverseMap();
            CreateMap<DTO.EquipmentDTO, ViewModels.HireEquipmentViewModel>().ReverseMap();
            CreateMap<DTO.EquipmentDTO, ViewModels.EquipmentViewModel>().ReverseMap();

            CreateMap<Entities.Hire, DTO.HireDTO>().ReverseMap();
            CreateMap<DTO.HireDTO, ViewModels.EquipmentViewModel>().ReverseMap();

            //to do map to view model for equipments

            CreateMap<int, SelectListItem>()
                .ForMember(
                    dest => dest.Value,
                    opt => opt.MapFrom(src => src)
                )
                .ForMember(
                    dest => dest.Text,
                    opt => opt.MapFrom(src => src)
                );
            CreateMap<string, SelectListItem>()
                .ForMember(
                    dest => dest.Value,
                    opt => opt.MapFrom(src => src)
                )
                .ForMember(
                    dest => dest.Text,
                    opt => opt.MapFrom(src => src)
                );
        }
    }
}