using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Lab5.Data;
using Lab5.Data.Entities;
using Lab5.Models.View;
using Lab5.Repositories;
using Lab5.Services;

namespace Lab5.Controllers
{
    public class CarController : Controller
    {

        private readonly iService _carService;

        public CarController(iService carService)
        {
            _carService = carService;
        }

        public ActionResult List(int userId)
        {
            ViewBag.UserId = userId;

            var cars = _carService.GetCarsForUser(userId);

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
                var car = carViewModel;
                _carService.SaveCar(car);
                return RedirectToAction("List", new { UserId = carViewModel.UserId });
            }

            return View();
        }
        


    }
}