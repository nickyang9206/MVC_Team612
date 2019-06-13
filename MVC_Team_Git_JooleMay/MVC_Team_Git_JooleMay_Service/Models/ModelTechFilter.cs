using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Team_Git_JooleMay_Service.Models
{
    public class ModelTechFilter
    {
        public int PropertyID { get; set; }
        public string PropertyName { get; set; }
        public bool? IsTechSpech { get; set; }
        public int SubCategoryID { get; set; }
        public int? MinValue { get; set; }
        public int? MaxValue { get; set; }
        public bool? IsActive { get; set; }
    }
}
