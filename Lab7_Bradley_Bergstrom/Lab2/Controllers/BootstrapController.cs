using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab2.Data.Entities;
using Lab2.Data;


namespace Lab2.Controllers
{
    public class BootstrapController : Controller
    {
        // GET: Bootstrap
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            var users = InMemoryDatabase.Users;

            return View(users);

        }
    }
}