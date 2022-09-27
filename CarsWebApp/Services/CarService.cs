using AutoMapper;
using CarsWebApp.DTOs;
using CarsWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsWebApp.Services
{
    public class CarService
    {
        private readonly CarContext _context;
        private readonly IMapper _mapper;

        public CarService(CarContext carContext, IMapper mapper)
        {
            _context = carContext;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<CarDTO>> GetAllCars()
        {
            var cars = await _context.Cars.ToListAsync();
            return _mapper.Map<IEnumerable<CarDTO>>(cars);
        }
        public async Task<CarDTO> GetCarById(int id)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(i=>i.Id==id);
            return _mapper.Map<CarDTO>(car);
        }
        public async Task<CarDTO> CreateCar(CarCreateDTO carCreateDTO)
        {
            var carEntity = _mapper.Map<Car>(carCreateDTO);
            await _context.SaveChangesAsync();
            var createdCar = await _context.Cars.FirstAsync(p => p.Id == carEntity.Id);
            return _mapper.Map<CarDTO>(createdCar);
        }
        public async Task<CarDTO> DeleteCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return _mapper.Map<CarDTO>(car);
        }
        public async Task EditCar(CarDTO dto)
        {
            var carEntity = await _context.Cars.FirstOrDefaultAsync(i => i.Id == dto.Id);
            if (carEntity == null)
                throw new KeyNotFoundException("Car is`t found");
            carEntity.Info = dto.Info;
            carEntity.Photo = dto.Photo;
            carEntity.Transmission = dto.Transmission;
            carEntity.Body = dto.Transmission;
            carEntity.Color = dto.Color;
            carEntity.DealerId = dto.DealerId;
            carEntity.Year = dto.Year;
            _context.Cars.Update(carEntity);
            await _context.SaveChangesAsync();
        }
    }
}
