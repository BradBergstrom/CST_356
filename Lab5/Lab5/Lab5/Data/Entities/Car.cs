using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Lab5.Data;
using Lab5.Data.Entities;

using Lab5.Models.View;

using System.ComponentModel.DataAnnotations;

namespace Lab5.Data.Entities
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


    

        public CarViewModel MapToCarViewModel()
        {
            return new CarViewModel
            {
                Id = this.Id,
                Name = this.Name,
                Model = this.Model,
                LastCheckUp = this.LastCheckUp,
                UserId = this.UserId
            };
        }
    }
}