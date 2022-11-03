using System;
using CarsWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsWebApp.Repositories
{
    public class GuidEntityRepository
    {
        private readonly CarContext _context;
        public GuidEntityRepository(CarContext carContext)
        {
            _context = carContext;
        }

        public async Task<GuidEntity> CreateGuidEntityAsync(GuidEntity guidEntity)
        {
            _context.GuidEntities.Add(guidEntity);
            await _context.SaveChangesAsync();
            return guidEntity;
        }
        public async Task<IEnumerable<GuidEntity>> GetAllGuidEntitiesAsync()
        {
            var guidEntities = await _context.GuidEntities.ToListAsync();
            return guidEntities;
        }
        public async Task<GuidEntity> GetByIdAsync(Guid id)
        {
            var guidEntity = await _context.GuidEntities.FindAsync(id);
            return guidEntity;
        }
    }
}
