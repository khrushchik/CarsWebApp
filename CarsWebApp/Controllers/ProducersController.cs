using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarsWebApp.Models;
using CarsWebApp.Repositories;
using CarsWebApp.DTOs;
using CarsWebApp.Interfaces;
using AutoMapper;
using CarsWebApp.Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace CarsWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProducersController : ControllerBase
    {
        private readonly IProducerService _producerService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public ProducersController(IProducerService producerService, IMapper mapper, ILogger<ProducersController> logger)
        {
            _producerService = producerService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProducerDTO>>> GetProducersAsync()
        {
            _logger.LogInformation("ProducerController Get request");
            var producers = await _producerService.GetProducersAsync();
            return Ok( _mapper.Map<IEnumerable<ProducerDTO>>(producers));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProducerDTO>> GetProducerByIdAsync(int id)
        {
            _logger.LogError("test logger. display error");
            var producer = await _producerService.GetProducerByIdAsync(id);
            if (producer is null)
                return NotFound();
             return Ok( _mapper.Map<ProducerDTO>(producer));
        }
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducerAsync(int id)
        {
            await _producerService.DeleteProducerAsync(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ProducerDTO>> CreateProducerAsync([FromBody] ProducerCreateDTO dto)
        {
            var producer = _mapper.Map<ProducerCreateDomain>(dto);
            return Ok(_mapper.Map<ProducerDTO>(await _producerService.CreateProducerAsync(producer)));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProducerDTO>> UpdateProducerAsync(int id, [FromBody] ProducerDTO dto)
        {
            var producer = _mapper.Map<ProducerDomain>(dto);
            return Ok(_mapper.Map<ProducerDTO>(await _producerService.UpdateProducerAsync(id, producer)));

        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ProducerInfoDTO>> ChangeProducerInfoAsync(int id, [FromBody] ProducerInfoDTO dto)
        {
            var producerInfo = _mapper.Map<ProducerInfoDomain>(dto);
            return Ok(_mapper.Map<ProducerInfoDTO>( await _producerService.ChangeProducerInfoAsync(id, producerInfo)));
        }
    }
}
