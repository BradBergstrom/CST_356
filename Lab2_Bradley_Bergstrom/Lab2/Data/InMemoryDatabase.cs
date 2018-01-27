using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab2.Data.Entities;

namespace Lab2.Data
{
    public static class InMemoryDatabase
    {
        public static List<User> Users = new List<User>();
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