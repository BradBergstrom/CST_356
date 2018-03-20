using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Final_Project.Data.Entities;

namespace Final_Project.Data
{
    public static class InMemoryDatabase
    {
       // public static List<Friend> Friends = new List<Friend>();
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