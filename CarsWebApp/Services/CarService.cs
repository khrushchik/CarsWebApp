using CarsWebApp.Models;
using System.Collections.Generic;

namespace CarsWebApp.Services
{
    public class CarService
    {
        private readonly CarContext _carContext;

        public CarService(CarContext carContext)
        {
            _carContext = carContext;
        }
        /*public as GetCars()
        {
            return await _carContext.Cars.ToListAsync();
        }*/
    }
}
