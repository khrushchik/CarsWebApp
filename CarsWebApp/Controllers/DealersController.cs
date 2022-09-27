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
    public class DealersController : ControllerBase
    {
        private readonly DealerService _dealerService;

        public DealersController(DealerService dealerService)
        {
            _dealerService = dealerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dealer>>> GetAllDealers()
        {
            return Ok(await _dealerService.GetAllDealers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dealer>> GetDealerById(int id)
        {
            var dealer = await _dealerService.GetDealerById(id);
            if(dealer == null)
                return NotFound();
            return Ok(dealer);
        }
        [HttpPost]
        public async Task<ActionResult<DealerDTO>> CreateDealer([FromBody] DealerCreateDTO dealerCreateDTO)
        {
            return Ok(await _dealerService.CreateDealer(dealerCreateDTO));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDealer(int id)
        {
            var dealer = await _dealerService.DeleteDealer(id);
            if (dealer == null)
                return NotFound();
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult<DealerDTO>> EditDealer([FromBody] DealerDTO dto)
        {
            await _dealerService.EditDealer(dto);
            return NoContent();
        }
    }
}
