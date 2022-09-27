using AutoMapper;
using CarsWebApp.DTOs;
using CarsWebApp.Models;

namespace CarsWebApp.MappingProfiles
{
    public class DealerProfile:Profile
    {
        public DealerProfile()
        {
            CreateMap<Dealer, DealerDTO>();
            CreateMap<DealerCreateDTO, Dealer>();
            CreateMap<DealerDTO, Dealer>();
        }
    }
}
