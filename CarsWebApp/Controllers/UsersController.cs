using AutoMapper;
using CarsWebApp.Domains;
using CarsWebApp.DTOs;
using CarsWebApp.Helpers;
using CarsWebApp.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly SecurityHelper _securityHelper;

        public UsersController(IUserService userService, IMapper mapper, SecurityHelper securityHelper)
        {
            _userService = userService;
            _mapper = mapper;
            _securityHelper = securityHelper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUserDTO>>> GetUsersAsync()
        {
            var users = await _userService.GetUsersASync();
            return Ok(_mapper.Map<IEnumerable<GetUserDTO>>(users));
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserCreateDTO>> CreateUserAsync([FromBody] UserDTO dTO)
        {
            _securityHelper.CreatePasswordHash(dTO.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new UserCreateDTO
            {
                Email = dTO.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            var mappedUser = _mapper.Map<UserCreateDomain>(user);
            return Ok(_mapper.Map<UserCreateDTO>(await _userService.CreateUserAsync(mappedUser)));
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(UserDTO dTO)
        {
            var userEntity = await _userService.GetUserByEmailAsync(dTO.Email);
            if(userEntity is null)
            {
                return BadRequest("User not found");
            }
            if(!_securityHelper.VerifyPasswordHash(dTO.Password, userEntity.PasswordHash, userEntity.PasswordSalt))
            {
                return BadRequest("Wrong password");
            }
            return Ok(_securityHelper.CreateToken(userEntity));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserCreateDTO>> GetUserByIdAsync(int id)
        {
            return _mapper.Map<UserCreateDTO>(await _userService.GetUserByIdAsync(id));
        }
    }
}
