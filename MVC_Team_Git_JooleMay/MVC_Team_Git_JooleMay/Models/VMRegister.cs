using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MVC_Team_Git_JooleMay.Models
{
    public class VMRegister
    {
        public VMRegister()
        {

        }

        public int UserID { get; set; }
        [Required(ErrorMessage = "User name is empty")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is empty")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email name is empty")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Confirm password is empty")]
        [NotMapped]
        [Compare("Password")]
        [DisplayName("Confirm password")]
        public string ConfirmPassword { get; set; }
        public string ImageUrl { get; set; }
        public string ValidMessage { get; set; }










      


    }
}