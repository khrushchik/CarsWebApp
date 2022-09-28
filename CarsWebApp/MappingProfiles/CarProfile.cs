using AutoMapper;
using CarsWebApp.DTOs;
using CarsWebApp.Models;

namespace CarsWebApp.MappingProfiles
{
    public class CarProfile:Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarDTO>();
            CreateMap<CarCreateDTO, Car>();
            CreateMap<CarDTO, Car>();
        }
    }
}
