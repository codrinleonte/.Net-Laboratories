using System;
using System.Collections.Generic;
using System.Linq;
using Context;
using Model;

namespace Business
{
    public class CarRepository : ICarRepository
    {
        private readonly IDatabaseService _databaseService;

        public CarRepository(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public void AddCar(Car car)
        {
            _databaseService.Cars.Add(car);
            _databaseService.SaveChanges();
        }

        public void EditCar(Car car)
        {
            _databaseService.Cars.Update(car);
            _databaseService.SaveChanges();
        }

        public void DeleteCar(Guid id)
        {
            var car = GetCarById(id);
            _databaseService.Cars.Remove(car);
            _databaseService.SaveChanges();
        }

        public IReadOnlyList<Car> GetAllCars()
        {
            return _databaseService.Cars.ToList();
        }

        public Car GetCarById(Guid id)
        {
            return _databaseService.Cars.FirstOrDefault(t => t.Id == id);
        }

        public IReadOnlyList<Car> GetElectricCars()
        {
            return _databaseService.Cars.Where(c => c.IsElectric).ToList();
        }
    }
}