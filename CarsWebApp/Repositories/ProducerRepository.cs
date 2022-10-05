using AutoMapper;
using CarsWebApp.DTOs;
using CarsWebApp.Interfaces;
using CarsWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsWebApp.Repositories
{
    public class ProducerRepository:IRepository<Producer>
    {
        private readonly CarContext _context;

        public ProducerRepository(CarContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Producer>> GetAll()
        {
            return await _context.Producers.Include(p => p.Dealers).ThenInclude(d => d.Cars).ToListAsync();
        }
        public async Task<Producer> GetAsync(int id)
        {
            return await _context.Producers.Include(d=>d.Dealers).ThenInclude(d=>d.Cars).FirstOrDefaultAsync(i=>i.Id==id);
        }
        public async Task<Producer> CreateAsync(Producer producer)
        {
            _context.Producers.Add(producer);
            await _context.SaveChangesAsync();
            return producer;
        }
        public async Task<Producer> DeleteAsync(int id)
        {
            var producer = await _context.Producers.FindAsync(id);
            IQueryable<Dealer> dealers = from db in _context.Dealers where db.ProducerId == id select db;
            foreach (Dealer dealer in dealers)
            {
                var dealerId = dealer.Id;
                IQueryable<Car> cars = from db in _context.Cars where db.DealerId == dealerId select db;
                foreach (Car car in cars)
                {
                    _context.Cars.Remove(car);
                }
                _context.Dealers.Remove(dealer);
            }
            _context.Producers.Remove(producer);
            await _context.SaveChangesAsync();
            return producer;
        }
        public async Task<Producer> UpdateAsync(int id, Producer producer)
        {
            if (id != producer.Id)
                throw new KeyNotFoundException("Producer is`t found");
            _context.Entry(producer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return producer;
        }
        public async Task<Producer> ChangeInfoAsync(int id, Producer producer)
        {
            var producerEntity = await _context.Producers.FirstOrDefaultAsync(i => i.Id == id);
            if (producerEntity is null)
                throw new KeyNotFoundException("Producer is`t found");
            producerEntity.Info = producer.Info;
            _context.Producers.Update(producerEntity);
            await _context.SaveChangesAsync();
            return producerEntity;
        }
        /*
        public async Task<IEnumerable<ProducerDTO>> GetAllProducers()
        {
            var producers = await _context.Producers.Include(p=>p.Dealers).ThenInclude(d=>d.Cars).ToListAsync();
            return _mapper.Map<IEnumerable<ProducerDTO>>(producers);
            
        }
        public async Task<ProducerDTO> GetProducerById(int id)
        {
            //var producer = await _context.Producers.FindAsync(id);
            var producer = await _context.Producers.Include(d => d.Dealers).ThenInclude(d=>d.Cars).FirstOrDefaultAsync(i=>i.Id==id);
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
            IQueryable<Dealer> dealers = from db in _context.Dealers where db.ProducerId == id select db;
            foreach (Dealer dealer in dealers)
            {
                var dealerId = dealer.Id;
                IQueryable<Car> cars = from db in _context.Cars where db.DealerId == dealerId select db;
                foreach (Car car in cars)
                {
                    _context.Cars.Remove(car);
                }
                _context.Dealers.Remove(dealer);
            }
            _context.Producers.Remove(producer);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProducerDTO>(producer);
        }

        public async Task UpdateProducer(int id, ProducerDTO producerDTO)
        {
            if(id!=producerDTO.Id)
                throw new KeyNotFoundException("Producer is`t found");
            var producer = _mapper.Map<Producer>(producerDTO);
            _context.Entry(producer).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        public async Task PatchProducer(ProducerDTO producerDTO) //
        {
            var producerEntity = await _context.Producers.FirstOrDefaultAsync(i=>i.Id == producerDTO.Id);
            if (producerEntity == null)
                throw new KeyNotFoundException("Producer is`t found");
            if (producerDTO.Label != null)
                producerEntity.Label = producerDTO.Label;
            if(producerDTO.Info!= null)
                producerEntity.Info= producerDTO.Info;
            if (producerEntity.Name != null)
                producerEntity.Name = producerDTO.Name;
            _context.Producers.Update(producerEntity);
            await _context.SaveChangesAsync();

        }*/
    }
}
