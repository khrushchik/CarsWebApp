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
        private readonly DealerRepository _dealerService;

        public DealersController(DealerRepository dealerService)
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

        [HttpPut("{id}")]
        public async Task<ActionResult<DealerDTO>> EditDealer(int id, [FromBody] DealerDTO dto)
        {
            await _dealerService.EditDealer(id, dto);
            return NoContent();
        }

        [HttpPatch]
        public async Task<ActionResult<DealerDTO>> PatchDealer([FromBody] DealerDTO dto)
        {
            await _dealerService.PatchDealer(dto);
            return NoContent();
        }
    }
}
