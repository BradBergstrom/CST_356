using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab5.Data;
using Lab5.Data.Entities;
using Lab5.Models.View;

namespace Lab5.Repositories
{
    public class Repository : iRepository
    {
        private readonly AppDbContext _dbContext;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetUser(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public IEnumerable<UserViewModel> GetAllUsers()
        {
            var users = _dbContext.Users;
            var userViewModels = new List<UserViewModel>();

            foreach( var user in users)
            {
                userViewModels.Add(user.MapToUserViewModel());
            }
            return userViewModels;
        }

        public void SaveUser(User user)
        {
            _dbContext.Users.Add(user);

            _dbContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _dbContext.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _dbContext.Users.Find(id);

            if (user == null) return;

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Car Stufff
        /// </summary>
        

        public Car GetCar(int id)
        {

            return _dbContext.Cars.Find(id);
        }

        public IEnumerable<CarViewModel> GetCarsForUser(int userId)
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
