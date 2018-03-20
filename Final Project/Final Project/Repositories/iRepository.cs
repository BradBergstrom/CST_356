using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Final_Project.Data.Entities;
using Final_Project.Models.View;

namespace Final_Project.Repositories
{
    public interface iRepository
    {
        Friend GetFriend(int id);

        IEnumerable<FriendViewModel> GetAllFriends(String userId);

        void SaveFriend(Friend friend);

        void UpdateFriend(Friend friend);

        void DeleteFriend(int id);



        Car GetCar(int id);

        IEnumerable<CarViewModel> GetCarsForUser(String userId);

        void SaveCar(Car car);

        void UpdateCar(Car user);

        void DeleteCar(int id);
    }
}