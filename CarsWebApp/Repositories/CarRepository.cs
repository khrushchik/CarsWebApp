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

        public async Task<Car> ChangeInfo(int id, Car car)
        {
            var carEntity = await _context.Cars.FirstOrDefaultAsync(i => i.Id == id);
            if (carEntity is null)
                throw new KeyNotFoundException("Car is`t found");
            carEntity.Info = car.Info;
            _context.Cars.Update(carEntity);
            await _context.SaveChangesAsync();
            return carEntity;
        }

        public async Task<Car> Create(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car> Delete(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car> Get(int id)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(i => i.Id == id);
            return car;
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            var cars = await _context.Cars.ToListAsync();
            return cars;
        }

        public async Task<Car> Update(int id, Car car)
        {
            if (id != car.Id)
                throw new KeyNotFoundException("Car is`t found");
            _context.Entry(car).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return car;
        }


        /*
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
        }*/
    }
}
