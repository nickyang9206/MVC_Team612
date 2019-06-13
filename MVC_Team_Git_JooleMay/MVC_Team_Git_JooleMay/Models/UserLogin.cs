using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Team_Git_JooleMay.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Username or Email")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
        public string LoginErrorMessage { get; set; }

    }
}