using System.Collections.Generic;
using Lab5.Models.View;

namespace Lab5.Services
{
    public interface iService
    {
        UserViewModel GetUser(int id);

        IEnumerable<UserViewModel> GetAllUsers();

        void SaveUser(UserViewModel user);

        void UpdateUser(UserViewModel user);

        void DeleteUser(int id);

        ///CAr
        ///
        CarViewModel GetCar(int id);

        IEnumerable<CarViewModel> GetCarsForUser(int userId);

        void SaveCar(CarViewModel car);

        void UpdateCar(CarViewModel user);

        void DeleteCar(int id);
    }
}