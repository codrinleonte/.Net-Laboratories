using System;
using Business;
using EnsureThat;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Lab5.Service
{
    [Route("api/cars")]
    public class CarsController : Controller
    {
        private readonly ICarRepository carService;

        public CarsController(ICarRepository carService)
        {
            EnsureArg.IsNotNull(carService);
            this.carService = carService;
        }
        [HttpGet("Electric")]
        public IActionResult GetElectricCars()
        {
            var cars = carService.GetElectricCars();
            if (cars == null)
            {
                return NotFound();
            }
            return Ok(cars);
        }
        [HttpGet]
        public IActionResult GetAllCars()
        {
            var cars = carService.GetAllCars();
            return Ok(cars);
        }

        [HttpGet("{id:Guid}")]
        public IActionResult GetCarById(Guid id)
        {
            EnsureArg.IsNotEmpty(id);
            var car = carService.GetCarById(id);
            if (car == null)
                return NotFound();
            return Ok(car);
        }

        [HttpPost]
        public IActionResult CreateCar([FromBody] Car carModel)
        {
            EnsureArg.IsNotNull(carModel);
            carService.AddCar(carModel);
            return Ok();
            //return CreatedAtRoute()
        }

        [HttpPut("{id:Guid}")]
        public IActionResult EditCar(Guid id, [FromBody] Car carModel)
        {
            EnsureArg.IsNotEmpty(id);
            EnsureArg.IsNotNull(carModel);

            var car = carService.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }
            car.Update(carModel.Name,carModel.IsElectric);
            carService.EditCar(car);
           
            return Ok();
        }

        [HttpDelete("{id:Guid}")]
        public IActionResult DeleteCar(Guid id)
        {
            carService.DeleteCar(id);
            return NoContent();
        }
    }
}