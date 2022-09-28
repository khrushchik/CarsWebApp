using AutoMapper;
using CarsWebApp.DTOs;
using CarsWebApp.Models;
using CarsWebApp.Domains;

namespace CarsWebApp.MappingProfiles
{
    public class ProducerProfile:Profile
    {
        public ProducerProfile()
        {
            CreateMap<Producer, ProducerDTO>().ReverseMap();
            
            CreateMap<ProducerCreateDTO, Producer>();
            
            CreateMap<ProducerInfoDTO, Producer>();
            
            CreateMap<ProducerDomain, ProducerDTO>();
            
            CreateMap<Producer, ProducerDomain>();
           
            CreateMap<ProducerInfoDomain, Producer>();
        }
    }
}
