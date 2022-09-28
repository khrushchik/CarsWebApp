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
            _context.Cars.Add(carEntity);
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
        public async Task EditCar(int id, CarDTO dto)
        {
            if (id != dto.Id)
                throw new KeyNotFoundException("Car is`t found");
            var car = _mapper.Map<Car>(dto);
            _context.Entry(car).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task PatchCar(CarDTO dto)
        {
            var carEntity = await _context.Cars.FirstOrDefaultAsync(i => i.Id == dto.Id);
            if (carEntity == null)
                throw new KeyNotFoundException("Car is`t found");

            //how to replace it
            if (dto.Info != null)
                carEntity.Info = dto.Info;
            if (dto.Photo != null)
                carEntity.Photo = dto.Photo;
            if (dto.Body != null)
                carEntity.Body = dto.Body;
            if (dto.Color != null)
                carEntity.Color = dto.Color;
            if (dto.Name != null)
                carEntity.Name = dto.Name;
            if (dto.Transmission != null)
                carEntity.Transmission = dto.Transmission;
            if(dto.Year!=null)
                carEntity.Year=(int)dto.Year;
            if(dto.DealerId!=null)
                carEntity.DealerId=(int)dto.DealerId;
            _context.Cars.Update(carEntity);
            await _context.SaveChangesAsync();
        }
    }
}
