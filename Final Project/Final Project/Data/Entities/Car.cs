using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Final_Project.Data;
using Final_Project.Data.Entities;
using Final_Project.Models;
using Final_Project.Models.View;

using System.ComponentModel.DataAnnotations;

namespace Final_Project.Data.Entities
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Model { get; set; }

        public DateTime LastCheckUp { get; set; }
        
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("Driver")]
        public String UserId { get; set; }

        public ApplicationUser Driver { get; set; }

        public DateTime NextCheckup { get; set; }


        public CarViewModel MapToCarViewModel()
        {
            return new CarViewModel
            {
                Id = this.Id,
                Name = this.Name,
                Model = this.Model,
                LastCheckUp = this.LastCheckUp,
                NextCheckup = this.NextCheckup,
                UserId = this.UserId,
                CheckupAlert = (this.NextCheckup - DateTime.Now).Days < 14
        };
        }
    }
}