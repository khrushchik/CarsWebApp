using AutoMapper;
using CarsWebApp.DTOs;
using CarsWebApp.Interfaces;
using CarsWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsWebApp.Repositories
{
    public class DealerRepository:IRepository<Dealer>
    {
        private readonly CarContext _context;
        private readonly IMapper _mapper;
        public DealerRepository(CarContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Dealer> ChangeInfo(Dealer dealer)
        {
            var dealerEntity = await _context.Dealers.FirstOrDefaultAsync(i => i.Id == dealer.Id);
            if (dealerEntity == null)
                throw new KeyNotFoundException("Dealer is`t found");
                dealerEntity.Info = dealer.Info;
            _context.Dealers.Update(dealerEntity);
            await _context.SaveChangesAsync();
            return dealerEntity;
        }

        public async Task<Dealer> Create(Dealer dealer)
        {
            _context.Dealers.Add(dealer);
            await _context.SaveChangesAsync();
            return dealer;
        }

        public async Task<Dealer> Delete(int id)
        {
            var dealer = await _context.Dealers.FindAsync(id);

            IQueryable<Car> cars = from db in _context.Cars where db.DealerId == id select db;
            foreach (Car car in cars)
            {
                _context.Cars.Remove(car);
            }
            _context.Dealers.Remove(dealer);
            await _context.SaveChangesAsync();
            return dealer;
        }

        public async Task<Dealer> Get(int id)
        {
            var dealers = await _context.Dealers.Include(d => d.Cars).FirstOrDefaultAsync(i => i.Id == id);
            return dealers;
        }

        public async Task<IEnumerable<Dealer>> GetAll()
        {
            var dealers = await _context.Dealers.Include(d => d.Cars).ToListAsync();
            return dealers;
        }

        public async Task<Dealer> Update(int id, Dealer dealer)
        {
            if (id != dealer.Id)
                throw new KeyNotFoundException("Dealer is`t found");
            _context.Entry(dealer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return dealer;
        }


        /*public async Task<IEnumerable<DealerDTO>> GetAllDealers()
        {
            var dealers = await _context.Dealers.Include(d => d.Cars).ToListAsync();
            return  _mapper.Map<IEnumerable<DealerDTO>>(dealers);
        }
        public async Task<DealerDTO> GetDealerById(int id)
        {
            var dealers = await _context.Dealers.Include(d => d.Cars).FirstOrDefaultAsync(i => i.Id == id);
            return _mapper.Map<DealerDTO>(dealers);
        }
        public async Task<DealerDTO> CreateDealer(DealerCreateDTO dto)
        {
            var dealerEntity = _mapper.Map<Dealer>(dto);
            _context.Dealers.Add(dealerEntity);
            await _context.SaveChangesAsync();

            var createdDealer = await _context.Dealers.FirstAsync(p => p.Id == dealerEntity.Id);
            return _mapper.Map<DealerDTO>(createdDealer);
        }
        public async Task<DealerDTO> DeleteDealer(int id)
        {
            var dealer = await _context.Dealers.FindAsync(id);
            
            IQueryable<Car> cars = from db in _context.Cars where db.DealerId == id select db;
            foreach(Car car in cars)
            {
                _context.Cars.Remove(car);
            }
            _context.Dealers.Remove(dealer);
            await _context.SaveChangesAsync();
            return _mapper.Map<DealerDTO>(dealer);
        }
        public async Task EditDealer(int id, DealerDTO dto)
        {
            if (id != dto.Id)
                throw new KeyNotFoundException("Dealer is`t found");
            var dealer = _mapper.Map<Dealer>(dto);
            _context.Entry(dealer).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
        public async Task PatchDealer(DealerDTO dto)
        {
            var dealerEntity = await _context.Dealers.FirstOrDefaultAsync(i => i.Id == dto.Id);
            if (dealerEntity == null)
                throw new KeyNotFoundException("Dealer is`t found");
            if (dto.Address != null)
                dealerEntity.Address = dto.Address;
            if (dto.Icon != null)
                dealerEntity.Icon = dto.Icon;
            if (dto.Info != null)
                dealerEntity.Info = dto.Info;
            if(dto.Name!=null)
                dealerEntity.Name=dto.Name;
            if(dto.ProducerId!=null)
                dealerEntity.ProducerId=(int)dto.ProducerId;
            _context.Dealers.Update(dealerEntity);
            await _context.SaveChangesAsync();
        }*/
    }
}
