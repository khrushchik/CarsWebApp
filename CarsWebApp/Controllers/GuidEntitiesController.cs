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
    public class GuidEntitiesController : ControllerBase
    {
        private readonly GuidEntityRepository _repository;

        public GuidEntitiesController(GuidEntityRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuidEntity>>> GetAllGuidEntitiesAsync()
        {
            return Ok(await _repository.GetAllGuidEntitiesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GuidEntity>> GetGuidEntityByIdAsync(Guid id)
        {
            return Ok(await _repository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateGuidEntityAsync([FromBody] GuidEntity guidEntity)
        {
            var createdGuid = await _repository.CreateGuidEntityAsync(guidEntity);

            return Ok(createdGuid);
        }
    }
}
