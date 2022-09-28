using AutoMapper;
using CarsWebApp.DTOs;
using CarsWebApp.Models;

namespace CarsWebApp.MappingProfiles
{
    public class ProducerProfile:Profile
    {
        public ProducerProfile()
        {
            CreateMap<Producer, ProducerDTO>().ReverseMap();
            CreateMap<ProducerCreateDTO, Producer>();
        }
    }
}
