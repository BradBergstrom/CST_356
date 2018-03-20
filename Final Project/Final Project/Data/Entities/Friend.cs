using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Final_Project.Models.View;
using Final_Project.Models;

using System.ComponentModel.DataAnnotations;

namespace Final_Project.Data.Entities
{
    public class Friend
    {
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("User")]
        public String UserId { get; set; }

        public ApplicationUser User { get; set; }

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
       

        public FriendViewModel MapToFriendViewModel()
        {
            return new FriendViewModel
            {
                Id = this.Id,
                UserId = this.UserId,
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
