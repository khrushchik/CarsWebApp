using CarsWebApp.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsWebApp.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<CarDomain>> GetCars();
        Task<CarDomain> GetCarById(int id);
        Task<CarCreateDomain> CreateCar(CarCreateDomain carCreateDomain);
        Task<CarDomain> UpdateCar(int id, CarDomain carDomain);
        Task<CarDomain> DeleteCar(int id);
        Task<CarInfoDomain> ChangeCarInfo(int id, CarInfoDomain carrInfoDomain);
    }
}
