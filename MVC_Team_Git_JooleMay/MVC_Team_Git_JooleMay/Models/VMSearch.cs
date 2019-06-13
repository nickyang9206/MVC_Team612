using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Team_Git_JooleMay.Models
{
    public class VMSearch
    {
        public IEnumerable<SelectListItem> Categories { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<SubCategory> SubCategories { get; set; }
        public int SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }
    }
}