using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;
using Final_Project.Data;
using Final_Project.Data.Entities;
using Final_Project.Models.View;
using Final_Project.Models;
using Final_Project.Repositories;
using Final_Project.Services;

namespace Final_Project.Controllers
{

    [Authorize]
    public class CarController : Controller
    {

        private readonly iService _carService;

        public CarController(iService carService)
        {
            _carService = carService;
        }

        public ActionResult List()
        {
            ViewBag.UserId = User.Identity.GetUserId();

            var cars = _carService.GetCarsForUser(User.Identity.GetUserId());

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
                var car = carViewModel;
                _carService.SaveCar(car);
                return RedirectToAction("List", new { UserId = carViewModel.UserId });
            }

            return View();
        }
        


    }
}