using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab5.Data.Entities;
using Lab5.Models.View;

namespace Lab5.Repositories
{
    public interface iRepository
    {
        User GetUser(int id);

        IEnumerable<UserViewModel> GetAllUsers();

        void SaveUser(User user);

        void UpdateUser(User user);

        void DeleteUser(int id);



        Car GetCar(int id);

        IEnumerable<CarViewModel> GetCarsForUser(int userId);

        void SaveCar(Car car);

        void UpdateCar(Car user);

        void DeleteCar(int id);
    }
}