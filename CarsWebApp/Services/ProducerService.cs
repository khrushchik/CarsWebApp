using AutoMapper;
using CarsWebApp.DTOs;
using CarsWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsWebApp.Services
{
    public class ProducerService
    {
        private readonly CarContext _context;
        private readonly IMapper _mapper;

        public ProducerService(CarContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProducerDTO>> GetAllProducers()
        {
            var producers = await _context.Producers.Include(p=>p.Dealers).ToListAsync();
            return _mapper.Map<IEnumerable<ProducerDTO>>(producers);
            
        }
        public async Task<ProducerDTO> GetProducerById(int id)
        {
            var producer = await _context.Producers.FindAsync(id);
            return _mapper.Map<ProducerDTO>(producer);
        }

        public async Task<ProducerDTO> CreateProducer(ProducerCreateDTO producerCreateDTO)
        {
            var producerEntity = _mapper.Map<Producer>(producerCreateDTO);
            _context.Producers.Add(producerEntity);
            await _context.SaveChangesAsync();

            var createdProducer = await _context.Producers.FirstAsync(p => p.Id == producerEntity.Id);
            return _mapper.Map<ProducerDTO>(createdProducer);

        }
        public async Task<ProducerDTO> DeleteProducer(int id)
        {
            var producer = await _context.Producers.FindAsync(id);
            _context.Producers.Remove(producer);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProducerDTO>(producer);
        }

        /*public async Task<ProducerDTO> EditProducer(ProducerDTO producerDTO)
        {
            var producerEntity = await _context.Producers.FirstOrDefaultAsync(p => p.Id == producerDTO.Id);
            if (producerEntity == null)
                throw new KeyNotFoundException("Producer is`t found");
            
        }*/
    }
}
