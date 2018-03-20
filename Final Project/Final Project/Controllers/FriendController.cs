using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Final_Project.Data.Entities;
using Final_Project.Data;
using Final_Project.Models.View;
using Final_Project.Models;
using Final_Project.Repositories;
using Final_Project.Services;    

namespace Final_Project.Controllers
{
    [Authorize]
    public class FriendController : Controller
    {
        private readonly iService _Friend;

        public FriendController(iService friend)
        {
            _Friend = friend;
        }

        public ActionResult List()
        {

            ViewBag.UserId = User.Identity.GetUserId();

            var friends = _Friend.GetAllFriends(User.Identity.GetUserId());

            return View(friends);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.UserId = User.Identity.GetUserId();

            return View();
        }

        [HttpPost]
        public ActionResult Create(FriendViewModel friendViewModel)
        {
            if (ModelState.IsValid)
            {
                var friend = friendViewModel;


                _Friend.SaveFriend(friend);

                return RedirectToAction("List");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            var friendViewModel = _Friend.GetFriend(id);
            
            return View(friendViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var friend = _Friend.GetFriend(id);

            return View(friend);
        }

        [HttpPost]
        public ActionResult Edit(FriendViewModel friendViewModel)
        {
            if (ModelState.IsValid)
            {
                var friend = friendViewModel;

                _Friend.UpdateFriend(friend);

                return RedirectToAction("List");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            _Friend.DeleteFriend(id);

            return RedirectToAction("List");
        }




    }
}