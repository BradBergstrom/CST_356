using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Final_Project.Data.Entities;

using System.ComponentModel.DataAnnotations;

namespace Final_Project.Models.View
{
    public class FriendViewModel
    {

        public int Id { get; set; }

        public String UserId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Nick Name")]
        public string NickName { get; set; }

        [Required]
        [Display(Name = "Years in School")]
        public int YearsInSchool { get; set; }
        
        public Friend MapToFriend()
        {
            return new Friend
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