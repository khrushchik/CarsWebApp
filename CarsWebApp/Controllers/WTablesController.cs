using CarsWebApp.Models;
using CarsWebApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WTablesController : ControllerBase
    {
        private readonly WTableRepository _repository;

        public WTablesController(WTableRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WTable>>> GetAllGuidEntitiesAsync()
        {
            return Ok(await _repository.GetAllWTablesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GuidEntity>> GetGuidEntityByIdAsync(Guid id)
        {
            return Ok(await _repository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateGuidEntityAsync([FromBody] WTable guidEntity)
        {
            var createdGuid = await _repository.CreateWTableAsync(guidEntity);

            return Ok(createdGuid);
        }
    }
}
