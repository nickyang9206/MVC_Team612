using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Team_Git_JooleMay_Service.Models;

namespace MVC_Team_Git_JooleMay.Models
{
    public class VMProject
    {
        public List<SMProject> ProjectList;
        public int? ProductID;
        public SMProductDetails ProductDetails;
    }
}