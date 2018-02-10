using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab3.Data.Entities;
using Lab3.Data;
using Lab3.Models.View;

namespace Lab3.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel userviewmodel)
        {
            if (ModelState.IsValid)
            {
                var user = MapToUser(userviewmodel);

                SaveUser(user);

                return RedirectToAction("List");
            }
            else
            {
                return View();
            }
        }
        private void SaveUser(User user)
        {
            var dbContext = new AppDbContext();

            dbContext.Users.Add(user);

            dbContext.SaveChanges();
        }

        public ActionResult List()
        {
            var users = getAllUsers();

            return View(users);
            // return View("Create");
        }

        private IEnumerable<UserViewModel> getAllUsers()
        {
            var userViewModels = new List<UserViewModel>();

            var dbContext = new AppDbContext();

            foreach (var user in dbContext.Users)
            {
                var userViewModel = MapToUserViewModel(user);
                userViewModels.Add(userViewModel);
            }

            return userViewModels;
        }

        private UserViewModel getUser(int id)
        {
            var dbContext = new AppDbContext();

            var user = dbContext.Users.Find(id);

            return MapToUserViewModel(user);
        }

        public ActionResult Details(int id)
        {
            var user = getUser(id);
            return View(user);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = getUser(id);

            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                UpdateUser(userViewModel);

                return RedirectToAction("List");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            var dbContext = new AppDbContext();

            var user = dbContext.Users.Find(id);

            if (user != null)
            {
                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
            }

            return RedirectToAction("List");
        }

        private void UpdateUser(UserViewModel userViewModel)
        {
            var dbContext = new AppDbContext();

            var user = dbContext.Users.Find(userViewModel.Id);

            CopyToUser(userViewModel, user);

            dbContext.SaveChanges();
        }

        private void CopyToUser(UserViewModel userViewModel, User user)
        {
            user.FirstName = userViewModel.FirstName;
            user.MiddleName = userViewModel.MiddleName;
            user.LastName = userViewModel.LastName;
            user.EmailAddress = userViewModel.EmailAddress;
            user.NickName = userViewModel.NickName;
            user.YearsInSchool = userViewModel.YearsInSchool;
        }

        private UserViewModel MapToUserViewModel(User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                NickName = user.NickName,
                YearsInSchool = user.YearsInSchool
            };
        }

        private User MapToUser(UserViewModel userViewModel)
        {
            return new User
            {
                Id = userViewModel.Id,
                FirstName = userViewModel.FirstName,
                MiddleName = userViewModel.MiddleName,
                LastName = userViewModel.LastName,
                EmailAddress = userViewModel.EmailAddress,
                NickName = userViewModel.NickName,
                YearsInSchool = userViewModel.YearsInSchool
            };
        }
    }

}