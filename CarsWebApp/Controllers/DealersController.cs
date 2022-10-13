using AutoMapper;
using CarsWebApp.Domains;
using CarsWebApp.DTOs;
using CarsWebApp.Interfaces;
using CarsWebApp.Models;
using CarsWebApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="admin")]
    public class DealersController : ControllerBase
    {
        private readonly IDealerService _dealerService;
        private readonly IMapper _mapper;
        public DealersController(IDealerService dealerService, IMapper mapper)
        {
            _dealerService = dealerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DealerDTO>>> GetDealersAsync()
        {
            var dealers = await _dealerService.GetDealersAsync();
            return Ok(_mapper.Map<IEnumerable<DealerDTO>>(dealers));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DealerDTO>> GetDealerByIdAsync(int id)
        {
            var dealer = await _dealerService.GetDealerByIdAsync(id);
            if (dealer is null)
                return NotFound();
            return Ok(_mapper.Map<DealerDTO>(dealer));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDealerAsync(int id)
        {
            await _dealerService.DeleteDealerAsync(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<DealerDTO>> CreateDealerAsync([FromBody] DealerCreateDTO dto)
        {
            var dealer = _mapper.Map<DealerCreateDomain>(dto);
            return Ok(_mapper.Map<DealerCreateDTO>(await _dealerService.CreateDealerAsync(dealer)));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DealerDTO>> UpdateDealerAsync(int id, [FromBody] DealerDTO dto)
        {
            var dealer = _mapper.Map<DealerDomain>(dto);
            return Ok(_mapper.Map<DealerDTO>(await _dealerService.UpdateDealerAsync(id, dealer)));

        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<DealerInfoDTO>> ChangeDealerInfoAsync(int id, [FromBody] DealerInfoDTO dto)
        {
            var dealerInfo = _mapper.Map<DealerInfoDomain>(dto);
            return Ok(_mapper.Map<DealerInfoDTO>(await _dealerService.ChangeDealerInfoAsync(id, dealerInfo)));
        }
        
    }
}
