using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab2.Data.Entities;
using Lab2.Data;

namespace Lab2.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            user.Id = InMemoryDatabase.NextId();
            InMemoryDatabase.Users.Add(user);

            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            var users = InMemoryDatabase.Users;

            return View(users);
        }

        public ActionResult Details(int id)
        {
            var user = InMemoryDatabase.Users[id];
            return View(user);
        }
    }
}