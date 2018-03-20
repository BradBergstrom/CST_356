using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Final_Project.Data;
using Final_Project.Data.Entities;
using Final_Project.Models.View;
using Final_Project.Models;

namespace Final_Project.Repositories
{
    public class Repository : iRepository
    {
        private readonly AppDbContext _dbContext;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Friend GetFriend(int id)
        {
            return _dbContext.Friends.Find(id);
        }

        public IEnumerable<FriendViewModel> GetAllFriends(String userId)
        {
            var friends = _dbContext.Friends.Where(friend => friend.UserId == userId).ToList();
            var friendViewModels = new List<FriendViewModel>();

            foreach( var friend in friends)
            {
                friendViewModels.Add(friend.MapToFriendViewModel());
            }
            return friendViewModels;
        }

        public void SaveFriend(Friend friend)
        {
            _dbContext.Friends.Add(friend);

            _dbContext.SaveChanges();
        }

        public void UpdateFriend(Friend friend)
        {
            _dbContext.SaveChanges();
        }

        public void DeleteFriend(int id)
        {
            var friend = _dbContext.Friends.Find(id);

            if (friend == null) return;

            _dbContext.Friends.Remove(friend);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Car Stufff
        /// </summary>
        

        public Car GetCar(int id)
        {

            return _dbContext.Cars.Find(id);
        }

        public IEnumerable<CarViewModel> GetCarsForUser(String userId)
        {
            var cars = _dbContext.Cars.Where(car => car.UserId == userId).ToList();
            var carViewModels = new List<CarViewModel>();

            foreach (var Car in cars)
            {
                carViewModels.Add(Car.MapToCarViewModel());
            }
            return carViewModels;
        }

        public void SaveCar(Car car)
        {
            _dbContext.Cars.Add(car);

            _dbContext.SaveChanges();
        }

        public void UpdateCar(Car car)
        {
            _dbContext.SaveChanges();
        }

        public void DeleteCar(int id)
        {
            var car = _dbContext.Cars.Find(id);

            if (car == null) return;

            _dbContext.Cars.Remove(car);
            _dbContext.SaveChanges();
        }
    }
}
