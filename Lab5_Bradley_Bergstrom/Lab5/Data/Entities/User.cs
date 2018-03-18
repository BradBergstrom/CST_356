using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab5.Models.View;

using System.ComponentModel.DataAnnotations;

namespace Lab5.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Nick Name")]
        public string NickName { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Required]
        [Display(Name = "Years in School")]
        public int YearsInSchool { get; set; }


        public UserViewModel MapToUserViewModel()
        {
            return new UserViewModel
            {
                Id = this.Id,
                FirstName = this.FirstName,
                MiddleName = this.MiddleName,
                LastName = this.LastName,
                EmailAddress = this.EmailAddress,
                NickName = this.NickName,
                YearsInSchool = this.YearsInSchool

            };
        }
    }
}
