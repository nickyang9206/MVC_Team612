using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Team_Git_JooleMay.Models
{
    public class VMSearchModel
    {
        public int CategoryID { get; set; }
        public string SubCategoryID { get; set; }
        public int ProductID { get; set; }

        public List<SelectListItem> CategoriesList { get; set; }
    }
}