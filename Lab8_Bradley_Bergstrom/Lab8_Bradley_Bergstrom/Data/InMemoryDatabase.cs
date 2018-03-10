using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab8_Bradley_Bergstrom.Data.Entities;

namespace Lab8_Bradley_Bergstrom.Data
{
    public static class InMemoryDatabase
    {
       // public static List<User> Users = new List<User>();
        public static int Id = 0;

        public static int NextId()
        {
            if (Id == 0)
            {
                Id++;
                return 0;
            }
            else
            {
                return Id;
            }
        }
    }

}