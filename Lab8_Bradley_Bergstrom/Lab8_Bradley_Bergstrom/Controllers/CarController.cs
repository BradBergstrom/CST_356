using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

using Lab8_Bradley_Bergstrom.Data;
using Lab8_Bradley_Bergstrom.Data.Entities;
using Lab8_Bradley_Bergstrom.Models.View;
using Lab8_Bradley_Bergstrom.Models;

namespace Lab8_Bradley_Bergstrom.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        
        public ActionResult List()
        {

            ViewBag.UserId = User.Identity.GetUserId();
            
            var cars = GetCarsForUser(User.Identity.GetUserId());

            return View(cars);

        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.UserId = User.Identity.GetUserId();

            return View();
        }

        [HttpPost]
        public ActionResult Create(CarViewModel carViewModel)
        {
            if (ModelState.IsValid)
            {
                Save(carViewModel, User.Identity.GetUserId());
                return RedirectToAction("List", new { UserId = carViewModel.UserId });
            }

            return View();
        }

        private ICollection<CarViewModel> GetCarsForUser(String userId)
        {
            var carViewModels = new List<CarViewModel>();

            var dbContext = new ApplicationDbContext();

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
            var dbContext = new ApplicationDbContext();

            return dbContext.Cars.Find(carId);
        }

        private void Save(CarViewModel carViewModel, String userId)
        {
            var dbContext = new ApplicationDbContext();

            var pet = MapToCar(carViewModel);
            pet.UserId = userId;
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