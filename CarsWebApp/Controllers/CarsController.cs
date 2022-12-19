using AutoMapper;
using CarsWebApp.Domains;
using CarsWebApp.DTOs;
using CarsWebApp.Extensions;
using CarsWebApp.Interfaces;
using CarsWebApp.Models;
using CarsWebApp.Repositories;
using CarsWebApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "user, admin")]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;

        public CarsController(ICarService carService, IMapper mapper, INotificationService notificationService)
        {
            _carService = carService;
            _mapper = mapper;
            _notificationService = notificationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDTO>>> GetCarsAsync()
        {
            var cars = await _carService.GetCarsAsync();
            return Ok(_mapper.Map<IEnumerable<CarDTO>>(cars));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarDTO>> GetCarByIdAsync(int id)
        {
            var car = await _carService.GetCarByIdAsync(id);
            if (car is null)
                return NotFound();
            return Ok(_mapper.Map<CarDTO>(car));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarAsync(int id)
        {
            await _carService.DeleteCarAsync(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CarDTO>> CreateCarAsync([FromBody] CarCreateDTO dto)
        {
            var car = _mapper.Map<CarCreateDomain>(dto);
            return Ok(_mapper.Map<CarCreateDTO>(await _carService.CreateCarAsync(car)));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CarDTO>> UpdateCarAsync(int id, [FromBody] CarDTO dto)
        {
            var car = _mapper.Map<CarDomain>(dto);
            return Ok(_mapper.Map<CarDTO>(await _carService.UpdateCarAsync(id, car)));

        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<CarInfoDTO>> ChangeCarInfoAsync(int id, [FromBody] CarInfoDTO dto)
        {
            var carInfo = _mapper.Map<CarInfoDomain>(dto);
            return Ok(_mapper.Map<CarInfoDTO>(await _carService.ChangeCarInfoAsync(id, carInfo)));
        }

        [HttpGet("sendinfo/{id}")]
        public async Task<ActionResult> SendMessageAboutCarAsync(int id)
        {
            var userId = Int32.Parse(HttpContext.GetUserId());
            return Ok(await _notificationService.SendInfoAboutCarAsync(userId, id));
        }
    }
}
