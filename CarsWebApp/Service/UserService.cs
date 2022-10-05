using AutoMapper;
using CarsWebApp.Domains;
using CarsWebApp.Interfaces;
using CarsWebApp.Models;
using CarsWebApp.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsWebApp.Service
{
    public class UserService:IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserCreateDomain> CreateUserAsync(UserCreateDomain userCreateDomain)
        {
            var user = _mapper.Map<User>(userCreateDomain);
            return _mapper.Map<UserCreateDomain>(await _userRepository.Create(user));
        }

        public async Task<IEnumerable<UserDomain>> GetUsersASync()
        {
            return _mapper.Map<IEnumerable<UserDomain>>(await _userRepository.GetUsers());
        }

        public async Task<UserDomain> GetUserByEmailAsync(string email)
        {
            return _mapper.Map<UserDomain>(await _userRepository.GetUserByEmailAsync(email));
        }

        public async Task<UserDomain> GetUserByIdAsync(int id)
        {
            return _mapper.Map<UserDomain>(await _userRepository.GetUserByIdAsync(id));
        }
    }
}
