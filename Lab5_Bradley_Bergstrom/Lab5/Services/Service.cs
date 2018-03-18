using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab5.Data.Entities;
using Lab5.Models.View;
using Lab5.Repositories;

namespace Lab5.Services
{
    public class Service : iService
    {
        private readonly iRepository _repository;

        public Service(iRepository userRepository)
        {
            _repository = userRepository;

        }

        public UserViewModel GetUser(int id)
        {
            var user = _repository.GetUser(id);

            return (user.MapToUserViewModel());
        }

        public IEnumerable<UserViewModel> GetAllUsers()
        {
            var users = _repository.GetAllUsers();
            
            return users;
        }

        public void SaveUser(UserViewModel userViewModel)
        {
            _repository.SaveUser(userViewModel.MapToUser());
        }

        public void UpdateUser(UserViewModel userViewModel)
        {
            var user = _repository.GetUser(userViewModel.Id);
            CopyToUser(userViewModel, user);

            _repository.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            _repository.DeleteUser(id);
        }

        private void CopyToUser(UserViewModel userViewModel, User user)
        {
            user.FirstName = userViewModel.FirstName;
            user.MiddleName = userViewModel.MiddleName;
            user.LastName = userViewModel.LastName;
            user.EmailAddress = userViewModel.EmailAddress;
            user.NickName= userViewModel.NickName;
            user.YearsInSchool = userViewModel.YearsInSchool;
        }

        public void nameString(UserViewModel userViewModel)
        {
            String name = userViewModel.FirstName + " " + userViewModel.LastName + " has been in school for " + userViewModel.YearsInSchool;
            userViewModel.nameString = name;
           
        }

        ///Car Stuff
        ///
        public CarViewModel GetCar(int id)
        {
            var car = _repository.GetCar(id);
            
            return car.MapToCarViewModel();
        }

        public IEnumerable<CarViewModel> GetCarsForUser(int userId)
        {
            var cars = _repository.GetCarsForUser(userId);
            
            return cars;
        }

        public void SaveCar(CarViewModel carViewModel)
        {
            var car = carViewModel.MapToCar();

            _repository.SaveCar(car);
        }

        public void UpdateCar(CarViewModel carViewModel)
        {
            var car = _repository.GetCar(carViewModel.Id);

            CopyToCar(carViewModel, car);

            _repository.UpdateCar(car);
        }

        public void DeleteCar(int id)
        {
            _repository.DeleteCar(id);
        }


        private void CopyToCar(CarViewModel carViewModel, Car car)
        {
            car.Id = carViewModel.Id;
            car.Name = carViewModel.Name;
            car.Model = carViewModel.Model;
            car.LastCheckUp = carViewModel.LastCheckUp;
            car.UserId = carViewModel.UserId;
        }

    }
}