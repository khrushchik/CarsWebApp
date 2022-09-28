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

namespace CarsWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducersController : ControllerBase
    {
        private readonly IProducerService _producerService;
        private readonly IMapper _mapper;
        public ProducersController(IProducerService producerService, IMapper mapper)
        {
            _producerService = producerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProducerDTO>>> GetProducersAsync()
        {
            var producers = await _producerService.GetProducers();
            return Ok( _mapper.Map<IEnumerable<ProducerDTO>>(producers));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProducerDTO>> GetProducerByIdAsync(int id)
        {
            var producer = await _producerService.GetProducerById(id);
            if (producer is null)
                return NotFound();
             return Ok( _mapper.Map<ProducerDTO>(producer));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducer(int id)
        {
            await _producerService.DeleteProducer(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ProducerDTO>> CreateProducerAsync([FromBody] ProducerCreateDTO dto)
        {
            var producer = _mapper.Map<ProducerCreateDomain>(dto);
            return Ok(_mapper.Map<ProducerCreateDTO>(await _producerService.CreateProducer(producer)));
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ProducerDTO>> UpdateProducerAsync(int id, [FromBody] ProducerDTO dto)
        {
            var producer = _mapper.Map<ProducerDomain>(dto);
            return Ok(_mapper.Map<ProducerDTO>(await _producerService.UpdateProducer(id, producer)));

        }
        [HttpPatch("{id}")]
        public async Task<ActionResult<ProducerInfoDTO>> ChangeProducerInfoAsync(int id, [FromBody] ProducerInfoDTO dto)
        {
            var producerInfo = _mapper.Map<ProducerInfoDomain>(dto);
            return Ok(_mapper.Map<ProducerInfoDTO>( await _producerService.ChangeProducerInfo(id, producerInfo)));
        }
    }
}
