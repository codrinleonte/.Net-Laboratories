using System;
using System.Collections.Generic;
using Model;

namespace Bussiness
{
    public interface ICarRepository
    {
        void AddCar(Car car);
        void EditCar(Car car);
        void DeleteCar(Guid id);
        IReadOnlyList<Car> GetAllCars();
        Car GetCarById(Guid id);
        IReadOnlyList<Car> GetElectricCars();
    }
}