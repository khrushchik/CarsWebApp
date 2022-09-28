using AutoMapper;
using CarsWebApp.Domains;
using CarsWebApp.DTOs;
using CarsWebApp.Models;

namespace CarsWebApp.MappingProfiles
{
    public class CarProfile:Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarDTO>().ReverseMap();
            CreateMap<CarCreateDTO, Car>();
            CreateMap<CarDTO, Car>();

            CreateMap<CarDomain, CarDTO>();

            CreateMap<Car, CarDomain>();

            CreateMap<Car, CarDTO>().ReverseMap();

            CreateMap<CarCreateDTO, Car>();

            CreateMap<CarInfoDTO, Car>();

            CreateMap<CarDomain, CarDTO>().ReverseMap();

            CreateMap<Car, CarDomain>();

            CreateMap<CarInfoDomain, Car>().ReverseMap();

            CreateMap<CarCreateDTO, CarCreateDomain>().ReverseMap();
            CreateMap<CarCreateDomain, Car>().ReverseMap();
            CreateMap<CarInfoDTO, CarInfoDomain>().ReverseMap();
        }
    }
}
