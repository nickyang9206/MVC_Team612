using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Team_Git_JooleMay.Models
{
    public class VMLogin
    {
        [Required(ErrorMessage = "User name is empty")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is empty")]
        public string Password { get; set; }

        public string ValidMessage { get; set; }

    }
}