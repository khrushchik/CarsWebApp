using AutoMapper;
using CarsWebApp.Domains;
using CarsWebApp.DTOs;
using CarsWebApp.Models;

namespace CarsWebApp.MappingProfiles
{
    public class DealerProfile:Profile
    {
        public DealerProfile()
        {
            CreateMap<Dealer, DealerDTO>().ReverseMap();
            CreateMap<DealerCreateDTO, Dealer>();

            CreateMap<Dealer, DealerDomain>();


            CreateMap<DealerInfoDTO, Dealer>();

            CreateMap<DealerDomain, DealerDTO>().ReverseMap();


            CreateMap<DealerInfoDomain, Dealer>().ReverseMap();

            CreateMap<DealerCreateDTO, DealerCreateDomain>().ReverseMap();
            CreateMap<DealerCreateDomain, Dealer>().ReverseMap();
            CreateMap<DealerInfoDTO, DealerInfoDomain>().ReverseMap();
        }
    }
}
