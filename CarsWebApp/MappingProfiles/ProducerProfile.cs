using AutoMapper;
using CarsWebApp.DTOs;
using CarsWebApp.Models;

namespace CarsWebApp.MappingProfiles
{
    public class ProducerProfile:Profile
    {
        public ProducerProfile()
        {
            CreateMap<Producer, ProducerDTO>();
            CreateMap<ProducerCreateDTO, Producer>();
            CreateMap<Dealer, DealerDTO>();
            CreateMap<Car, CarDTO>();
        }
    }
}
