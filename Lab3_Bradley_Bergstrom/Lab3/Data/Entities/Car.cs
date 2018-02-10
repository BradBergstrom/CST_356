using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Lab3.Data;
using Lab3.Data.Entities;

using System.ComponentModel.DataAnnotations;

namespace Lab3.Data.Entities
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Model { get; set; }

        public DateTime LastCheckUp { get; set; }

        public int UserId { get; set; }

        public User Driver { get; set; }
    }
}