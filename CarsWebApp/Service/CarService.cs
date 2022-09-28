using AutoMapper;
using CarsWebApp.Domains;
using CarsWebApp.Interfaces;
using CarsWebApp.Models;
using CarsWebApp.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<CarInfoDomain> ChangeCarInfo(int id, CarInfoDomain carInfoDomain)
        {
            var car = _mapper.Map<Car>(carInfoDomain);
            return _mapper.Map<CarInfoDomain>(await _carRepository.ChangeInfo(id, car));
        }

        public async Task<CarCreateDomain> CreateCar(CarCreateDomain carCreateDomain)
        {
            var car = _mapper.Map<Car>(carCreateDomain);
            return _mapper.Map<CarCreateDomain>(await _carRepository.Create(car));
        }

        public async Task<CarDomain> DeleteCar(int id)
        {
            return _mapper.Map<CarDomain>(await _carRepository.Delete(id));
        }

        public async Task<CarDomain> GetCarById(int id)
        {
            return _mapper.Map<CarDomain>(await _carRepository.Get(id));
        }

        public async Task<IEnumerable<CarDomain>> GetCars()
        {
            return _mapper.Map<IEnumerable<CarDomain>>(await _carRepository.GetAll());
        }

        public async Task<CarDomain> UpdateCar(int id, CarDomain carDomain)
        {
            var car = _mapper.Map<Car>(carDomain);
            return _mapper.Map<CarDomain>(await _carRepository.Update(id, car));

        }
    }
}
