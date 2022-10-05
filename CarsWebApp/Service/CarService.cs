using AutoMapper;
using CarsWebApp.Domains;
using CarsWebApp.Interfaces;
using CarsWebApp.Models;
using CarsWebApp.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarInfo = CarsWebApp.Domains.CarInfoDomain;
using CarCreate = CarsWebApp.Domains.CarCreateDomain;

namespace CarsWebApp.Service
{
    public class CarService:ICarService
    {
        private readonly IMapper _mapper;
        private readonly CarRepository _carRepository;
        public CarService(IMapper mapper, CarRepository carRepository)
        {
            _mapper = mapper;
            _carRepository = carRepository;
        }
        public async Task<CarInfo> ChangeCarInfoAsync(int id, CarInfo carInfoDomain)
        {
            var car = _mapper.Map<Car>(carInfoDomain);
            return _mapper.Map<CarInfo>(await _carRepository.ChangeInfoAsync(id, car));
        }

        public async Task<CarCreate> CreateCarAsync(CarCreate carCreateDomain)
        {
            var car = _mapper.Map<Car>(carCreateDomain);
            return _mapper.Map<CarCreate>(await _carRepository.CreateAsync(car));
        }

        public async Task<CarDomain> DeleteCarAsync(int id)
        {
            return _mapper.Map<CarDomain>(await _carRepository.DeleteAsync(id));
        }

        public async Task<CarDomain> GetCarByIdAsync(int id)
        {
            return _mapper.Map<CarDomain>(await _carRepository.GetAsync(id));
        }

        public async Task<IEnumerable<CarDomain>> GetCarsAsync()
        {
            return _mapper.Map<IEnumerable<CarDomain>>(await _carRepository.GetAll());
        }

        public async Task<CarDomain> UpdateCarAsync(int id, CarDomain carDomain)
        {
            var car = _mapper.Map<Car>(carDomain);
            return _mapper.Map<CarDomain>(await _carRepository.UpdateAsync(id, car));

        }
    }
}
