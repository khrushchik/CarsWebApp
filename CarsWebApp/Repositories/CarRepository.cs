using AutoMapper;
using CarsWebApp.DTOs;
using CarsWebApp.Interfaces;
using CarsWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsWebApp.Repositories
{
    public class CarRepository:IRepository<Car>
    {
        private readonly CarContext _context;
        private readonly IMapper _mapper;

        public CarRepository(CarContext carContext, IMapper mapper)
        {
            _context = carContext;
            _mapper = mapper;
        }

        public async Task<Car> ChangeInfoAsync(int id, Car car)
        {
            var carEntity = await _context.Cars.FirstOrDefaultAsync(i => i.Id == id);
            if (carEntity is null)
                throw new KeyNotFoundException("Car is`t found");
            carEntity.Info = car.Info;
            _context.Cars.Update(carEntity);
            await _context.SaveChangesAsync();
            return carEntity;
        }

        public async Task<Car> CreateAsync(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car> DeleteAsync(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car> GetAsync(int id)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(i => i.Id == id);
            return car;
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            var cars = await _context.Cars.ToListAsync();
            return cars;
        }

        public async Task<Car> UpdateAsync(int id, Car car)
        {
            if (id != car.Id)
                throw new KeyNotFoundException("Car is`t found");
            _context.Entry(car).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return car;
        }
    }
}
