using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lab3.Models.View
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

        public int UserId { get; set; }
    }
}