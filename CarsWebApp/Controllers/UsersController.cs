using AutoMapper;
using CarsWebApp.Domains;
using CarsWebApp.DTOs;
using CarsWebApp.Helpers;
using CarsWebApp.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult<LoginResponse>> LoginAsync(UserDTO dTO)
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
            var accessToken = _securityHelper.CreateToken(userEntity);
            return Ok(new LoginResponse
            {
                AccessToken = accessToken
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserCreateDTO>> GetUserByIdAsync(int id)
        {
            return _mapper.Map<UserCreateDTO>(await _userService.GetUserByIdAsync(id));
        }

        [HttpGet("getMe"), Authorize]
        public ActionResult<string> GetUserName()
        {
            return Ok(_userService.GetName());
        }

        [HttpGet("getMyRole"), Authorize]
        public ActionResult<string> GetUserRole()
        {
            return Ok(_userService.GetRole());
        }

        [HttpPatch("{id}/username"), Authorize]
        public async Task<ActionResult<UsernameDTO>> ChangeUserNameAsync(int id, [FromBody] UsernameDTO usernameDTO)
        {
            var username = _mapper.Map<UserUserNameDomain>(usernameDTO);
            return Ok(_mapper.Map<UsernameDTO>(await _userService.ChangeUserNameAsync(id, username)));
        }
    }
}
