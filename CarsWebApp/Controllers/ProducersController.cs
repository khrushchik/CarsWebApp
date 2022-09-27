using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarsWebApp.Models;
using CarsWebApp.Services;
using CarsWebApp.DTOs;

namespace CarsWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducersController : ControllerBase
    {
        private readonly ProducerService _producerService;

        public ProducersController(ProducerService producerService)
        {
            _producerService = producerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producer>>> GetProducers()
        {
            return Ok(await _producerService.GetAllProducers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producer>> GetProducer(int id)
        {
            var producer = await _producerService.GetProducerById(id);

            if (producer == null)
            {
                return NotFound();
            }
            return Ok(producer);
        }

        [HttpPost]
        public async Task<ActionResult<ProducerDTO>> CreateProducer([FromBody] ProducerCreateDTO dto)
        {
            return Ok(await _producerService.CreateProducer(dto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducer(int id)
        {
            await _producerService.DeleteProducer(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<ProducerDTO>> EditProducer([FromBody] ProducerDTO dto)
        {
            await _producerService.EditProducer(dto);
            return NoContent();
        }

        [HttpPatch]
        public async Task<ActionResult<ProducerDTO>> PatchProducer([FromBody] ProducerDTO dto)
        {
            await _producerService.PatchProducer(dto);
            return NoContent();
        }
    }
}
