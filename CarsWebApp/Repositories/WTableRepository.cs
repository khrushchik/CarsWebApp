using CarsWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsWebApp.Repositories
{
    public class WTableRepository
    {
        private readonly CarContext _context;
        public WTableRepository(CarContext carContext)
        {
            _context = carContext;
        }

        public async Task<WTable> CreateWTableAsync(WTable wTable)
        {
            _context.WTables.Add(wTable);
            await _context.SaveChangesAsync();
            return wTable;
        }
        public async Task<IEnumerable<WTable>> GetAllWTablesAsync()
        {
            var wTables = await _context.WTables.ToListAsync();
            return wTables;
        }
        public async Task<WTable> GetByIdAsync(Guid id)
        {
            var wTable = await _context.WTables.FindAsync(id);
            return wTable;
        }
    }
}
