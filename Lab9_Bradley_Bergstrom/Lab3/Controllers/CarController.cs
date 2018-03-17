using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Lab3.Data;
using Lab3.Data.Entities;
using Lab3.Models.View;

namespace Lab3.Controllers
{
    public class CarController : Controller
    {
       
        public ActionResult List(int userId)
        {
            ViewBag.UserId = userId;

            var cars =  GetCarsForUser(userId);

            return View(cars);
            
        }

        [HttpGet]
        public ActionResult Create(int userId)
        {
            ViewBag.UserId = userId;

            return View();
        }

        [HttpPost]
        public ActionResult Create(CarViewModel carViewModel)
        {
            if (ModelState.IsValid)
            {
                Save(carViewModel);
                return RedirectToAction("List", new { UserId = carViewModel.UserId });
            }

            return View();
        }

        private ICollection<CarViewModel> GetCarsForUser(int userId)
        {
            var carViewModels = new List<CarViewModel>();

            var dbContext = new AppDbContext();

            var cars = dbContext.Cars.Where(car => car.UserId == userId).ToList();

            foreach (var car in cars)
            {
                var carViewModel = MapToCarViewModel(car);
                carViewModels.Add(carViewModel);
            }

            return carViewModels;
        }

        private Car GetCar(int carId)
        {
            var dbContext = new AppDbContext();

            return dbContext.Cars.Find(carId);
        }

        private void Save(CarViewModel carViewModel)
        {
            var dbContext = new AppDbContext();

            var pet = MapToCar(carViewModel);

            dbContext.Cars.Add(pet);

            dbContext.SaveChanges();
        }

        private Car MapToCar(CarViewModel CarViewModel)
        {
            return new Car
            {
                Id = CarViewModel.Id,
                Name = CarViewModel.Name,
                Model = CarViewModel.Model,
                LastCheckUp = CarViewModel.LastCheckUp,
                UserId = CarViewModel.UserId
            };
        }

        private CarViewModel MapToCarViewModel(Car car)
        {
            return new CarViewModel
            {
                Id = car.Id,
                Name = car.Name,
                Model = car.Model,
                LastCheckUp = car.LastCheckUp,
                UserId = car.UserId
            };
        }

    }
}