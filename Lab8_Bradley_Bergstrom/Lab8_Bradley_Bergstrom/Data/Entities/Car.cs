using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Lab8_Bradley_Bergstrom.Data;
using Lab8_Bradley_Bergstrom.Data.Entities;
using Lab8_Bradley_Bergstrom.Models;



using System.ComponentModel.DataAnnotations;

namespace Lab8_Bradley_Bergstrom.Data.Entities
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
    }
}