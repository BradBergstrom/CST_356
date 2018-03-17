using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Lab5.Data.Entities;
using Lab5.Data;
using Lab5.Models.View;
using Lab5.Repositories;
using Lab5.Services;    

namespace Lab5.Controllers
{
    public class UserController : Controller
    {
        private readonly iService _Users;

        public UserController(iService users)
        {
            _Users = users;
        }

        public ActionResult List()
        {
            var users = _Users.GetAllUsers();


            return View(users);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = userViewModel;


                _Users.SaveUser(user);

                return RedirectToAction("List");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            var userViewModel = _Users.GetUser(id);

            return View(userViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = _Users.GetUser(id);

            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = userViewModel;

                _Users.UpdateUser(user);

                return RedirectToAction("List");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            _Users.DeleteUser(id);

            return RedirectToAction("List");
        }




    }
}