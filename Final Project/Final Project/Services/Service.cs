using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Final_Project.Data.Entities;
using Final_Project.Models.View;
using Final_Project.Repositories;

namespace Final_Project.Services
{
    public class Service : iService
    {
        private readonly iRepository _repository;

        public Service(iRepository userRepository)
        {
            _repository = userRepository;

        }

        public FriendViewModel GetFriend(int id)
        {
            var friend = _repository.GetFriend(id);

            return (friend.MapToFriendViewModel());
        }

        public IEnumerable<FriendViewModel> GetAllFriends(String userId)
        {
            var friends = _repository.GetAllFriends(userId);
            
            return friends;
        }

        public void SaveFriend(FriendViewModel friendViewModel)
        {
            var friend = friendViewModel.MapToFriend();

            _repository.SaveFriend(friend);
        }

        public void UpdateFriend(FriendViewModel friendViewModel)
        {
            var friend = _repository.GetFriend(friendViewModel.Id);
            CopyToUser(friendViewModel, friend);

            _repository.UpdateFriend(friend);
        }

        public void DeleteFriend(int id)
        {
            _repository.DeleteFriend(id);
        }

        private void CopyToUser(FriendViewModel userViewModel, Friend friend)
        {
            friend.FirstName = userViewModel.FirstName;
            friend.MiddleName = userViewModel.MiddleName;
            friend.LastName = userViewModel.LastName;
            friend.EmailAddress = userViewModel.EmailAddress;
            friend.NickName= userViewModel.NickName;
            friend.YearsInSchool = userViewModel.YearsInSchool;
        }
        

        ///Car Stuff
        ///
        public CarViewModel GetCar(int id)
        {
            var car = _repository.GetCar(id);
            
            return car.MapToCarViewModel();
        }

        public IEnumerable<CarViewModel> GetCarsForUser(String userId)
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