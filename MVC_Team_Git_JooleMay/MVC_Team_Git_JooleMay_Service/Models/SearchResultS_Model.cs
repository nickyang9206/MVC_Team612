using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Team_Git_JooleMay_Service.Models;

namespace MVC_Team_Git_JooleMay_Service.Models
{
    public class SearchResultS_Model
    {
        public List<SMProductDetails>  SMProductDetails{ get; set; }
        public List<ModelTechFilter> ModelTechFilters{ get; set; }
        public List<ProductTypeChkS_Model> VMProductTypeChks { get; set; }
        public string YearStart { get; set; }
        public string YearEnd { get; set; }
    }
}