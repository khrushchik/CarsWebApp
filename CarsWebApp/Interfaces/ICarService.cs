using CarsWebApp.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsWebApp.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<CarDomain>> GetCarsAsync();
        Task<CarDomain> GetCarByIdAsync(int id);
        Task<CarInfoDomain> GetCarInfo(int id);
        Task<CarCreateDomain> CreateCarAsync(CarCreateDomain carCreateDomain);
        Task<CarDomain> UpdateCarAsync(int id, CarDomain carDomain);
        Task<CarDomain> DeleteCarAsync(int id);
        Task<CarInfoDomain> ChangeCarInfoAsync(int id, CarInfoDomain carrInfoDomain);
    }
}
