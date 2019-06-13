using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Team_Git_JooleMay.Models
{
    public class VMUser
    {

        public VMUser()
        {

        }

        public int UserID { get; set; }
        [Required(ErrorMessage = "User name is empty")]
        [Range(5, 32)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is empty")]
        [Range(5, 32)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is empty")]
        [Range(8, 128)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is empty")]
        [Range(8, 128)]
        public string ConfirmPassword { get; set; }
        public string Image { get; set; }
    }


}