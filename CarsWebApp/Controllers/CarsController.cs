using CarsWebApp.DTOs;
using CarsWebApp.Models;
using CarsWebApp.Services;
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
        private readonly CarService _carService;

        public CarsController(CarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetAllCars()
        {
            return Ok(await _carService.GetAllCars());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCarById(int id)
        {
            var car = await _carService.GetCarById(id);
            if (car == null)
                return NotFound();
            return Ok(car);
        }
        [HttpPost]
        public async Task<ActionResult<CarDTO>> CreateCar([FromBody] CarCreateDTO carCreateDTO)
        {
            return Ok(await _carService.CreateCar(carCreateDTO));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _carService.DeleteCar(id);
            if (car == null)
                return NotFound();
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<CarDTO>> EditCar([FromBody] CarDTO dto)
        {
            await _carService.EditCar(dto);
            return NoContent();
        }

        [HttpPatch]
        public async Task<ActionResult<CarDTO>> PatchCar([FromBody] CarDTO dto)
        {
            await _carService.PatchCar(dto);
            return NoContent();
        }
    }
}
