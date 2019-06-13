using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Team_Git_JooleMay_Service.Models;

namespace MVC_Team_Git_JooleMay.Models
{
    public class VMSearchResult
    {
        public List<SMProductDetails>  SMProductDetails{ get; set; }
        public List<ModelTechFilter> ModelTechFilters{ get; set; }
        public List<VMProductTypeChk> VMProductTypeChks { get; set; }
        public string YearStart { get; set; }
        public string YearEnd { get; set; }
    }
}