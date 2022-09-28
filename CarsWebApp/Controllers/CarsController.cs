﻿using AutoMapper;
using CarsWebApp.Domains;
using CarsWebApp.DTOs;
using CarsWebApp.Interfaces;
using CarsWebApp.Models;
using CarsWebApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;
        public CarsController(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDTO>>> GetCarsAsync()
        {
            var cars = await _carService.GetCars();
            return Ok(_mapper.Map<IEnumerable<CarDTO>>(cars));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarDTO>> GetCarByIdAsync(int id)
        {
            var car = await _carService.GetCarById(id);
            if (car is null)
                return NotFound();
            return Ok(_mapper.Map<CarDTO>(car));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _carService.DeleteCar(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CarDTO>> CreateCarAsync([FromBody] CarCreateDTO dto)
        {
            var car = _mapper.Map<CarCreateDomain>(dto);
            return Ok(_mapper.Map<CarCreateDTO>(await _carService.CreateCar(car)));
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<CarDTO>> UpdateCarAsync(int id, [FromBody] CarDTO dto)
        {
            var car = _mapper.Map<CarDomain>(dto);
            return Ok(_mapper.Map<CarDTO>(await _carService.UpdateCar(id, car)));

        }
        [HttpPatch("{id}")]
        public async Task<ActionResult<CarInfoDTO>> ChangeCarInfoAsync(int id, [FromBody] CarInfoDTO dto)
        {
            var carInfo = _mapper.Map<CarInfoDomain>(dto);
            return Ok(_mapper.Map<CarInfoDTO>(await _carService.ChangeCarInfo(id, carInfo)));
        }
    }
}
