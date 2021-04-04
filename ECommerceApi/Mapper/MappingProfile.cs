using AutoMapper;
using ECommerceApi.DTO;
using ECommerceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApi.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Laptop, LaptopDTO>();
            CreateMap<LaptopDTO, Laptop>();

            CreateMap<Configuration, ConfigurationDTO>();
            CreateMap<ConfigurationDTO, Configuration>();

            CreateMap<ConfigugurationEnum, ConfigugurationEnumDTO>();
            CreateMap<ConfigugurationEnumDTO, ConfigugurationEnum>();


        }
    }
}
