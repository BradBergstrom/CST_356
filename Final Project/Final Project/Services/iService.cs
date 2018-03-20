using System.Collections.Generic;
using Final_Project.Models.View;

using System;
using System.Linq;
using System.Web;

namespace Final_Project.Services
{
    public interface iService
    {
        FriendViewModel GetFriend(int id);

        IEnumerable<FriendViewModel> GetAllFriends(String userId);

        void SaveFriend(FriendViewModel friend);

        void UpdateFriend(FriendViewModel friend);

        void DeleteFriend(int id);
        
        ///CAr
        ///
        CarViewModel GetCar(int id);

        IEnumerable<CarViewModel> GetCarsForUser(String userId);

        void SaveCar(CarViewModel car);

        void UpdateCar(CarViewModel user);

        void DeleteCar(int id);
    }
}