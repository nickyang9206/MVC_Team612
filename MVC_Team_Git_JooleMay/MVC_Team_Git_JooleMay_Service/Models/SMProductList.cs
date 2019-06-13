using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Team_Git_JooleMay_Service.Models
{
    public class SMProductList
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductModel { get; set; }
        public string ProductType { get; set; }
        public int CategoryID { get; set; }
        public int SubCategoryID { get; set; }
        public int ManufactureID { get; set; }
        public int SeriesID { get; set; }
        public int TechnicalSpecificationID { get; set; }
        public int ProductTypeDetailsID { get; set; }
        public string ProductImgUrl { get; set; }
        public Nullable<decimal> AirFlow { get; set; }
        public Nullable<decimal> PowerMin { get; set; }
        public Nullable<decimal> PowerMax { get; set; }
        public Nullable<decimal> VAC_Min { get; set; }
        public Nullable<decimal> VAC_Max { get; set; }
        public Nullable<int> FanSpeedMin { get; set; }
        public Nullable<int> FanSpeedMax { get; set; }
        public Nullable<int> NumberofFanSpeed { get; set; }
        public Nullable<int> SoundAtMaxSpeed { get; set; }
        public Nullable<decimal> FanSweepDiameter { get; set; }
        public Nullable<decimal> HeightMin { get; set; }
        public Nullable<decimal> HeightMax { get; set; }
        public Nullable<decimal> Weight { get; set; }

    }
}
