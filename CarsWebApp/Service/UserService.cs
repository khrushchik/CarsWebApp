using AutoMapper;
using CarsWebApp.Domains;
using CarsWebApp.Interfaces;
using CarsWebApp.Models;
using CarsWebApp.Repositories;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using UserCreate = CarsWebApp.Domains.UserCreateDomain;

namespace CarsWebApp.Service
{
    public class UserService:IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IMapper mapper, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserCreate> CreateUserAsync(UserCreate userCreateDomain)
        {
            var user = _mapper.Map<User>(userCreateDomain);
            return _mapper.Map<UserCreate>(await _userRepository.CreateAsync(user));
        }

        public async Task<IEnumerable<UserDomain>> GetUsersASync()
        {
            return _mapper.Map<IEnumerable<UserDomain>>(await _userRepository.GetUsersAsync());
        }

        public async Task<UserUserNameDomain> ChangeUserNameAsync(int id, UserUserNameDomain usernameDomain)
        {
            var user = _mapper.Map<User>(usernameDomain);
            return _mapper.Map<UserUserNameDomain>(await _userRepository.AddUserNameAsync(id, user));
        }

        public async Task<UserDomain> GetUserByEmailAsync(string email)
        {
            return _mapper.Map<UserDomain>(await _userRepository.GetUserByEmailAsync(email));
        }

        public async Task<UserDomain> GetUserByIdAsync(int id)
        {
            return _mapper.Map<UserDomain>(await _userRepository.GetUserByIdAsync(id));
        }
        public string GetName()
        {
            var res = string.Empty;
            if (_httpContextAccessor.HttpContext != null)
            {
                res = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
            return res;
        }
        public string GetRole()
        {
            var res = string.Empty;
            if (_httpContextAccessor.HttpContext != null)
            {
                res = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
            }
            return res;
        }
    }
}
