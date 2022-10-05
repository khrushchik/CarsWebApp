using AutoMapper;
using CarsWebApp.Domains;
using CarsWebApp.DTOs;
using CarsWebApp.Models;

namespace CarsWebApp.MappingProfiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateDTO, UserCreateDomain>().ReverseMap();
            CreateMap<UserCreateDomain, User>().ReverseMap();
            CreateMap<UserDomain, User>().ReverseMap();
            CreateMap<GetUserDTO, UserDomain>().ReverseMap();
            CreateMap<UserCreateDTO, UserDomain>().ReverseMap();
        }
    }
}
