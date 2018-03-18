using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Lab5.Data.Entities;

namespace Lab5.Models.View
{
    public class CarViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Car Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Car's Model")]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Last Checkup")]
        public DateTime LastCheckUp { get; set; }

        [Required]
        [Display(Name = "Next Checkup")]
        public DateTime NextCheckup { get; set; }

        public bool CheckupAlert { get; set; }

        public int UserId { get; set; }

        public Car MapToCar()
        {
            return new Car
            {
                Id = this.Id,
                Name = this.Name,
                Model = this.Model,
                LastCheckUp = this.LastCheckUp,
                NextCheckup = this.NextCheckup,
                UserId = this.UserId
            };
        }
    }
}