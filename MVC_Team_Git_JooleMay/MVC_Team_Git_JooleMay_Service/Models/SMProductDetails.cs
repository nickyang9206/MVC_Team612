using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Team_Git_JooleMay_Service.Models
{
    public class SMProductDetails
    {
        public int ProductID { get; set; }
        public int ManufactureID { get; set; }
        public string ManufactureName { get; set; }

        public int SeriesID { get; set; }
        public string SeriesName { get; set; }
        public string ProductModel { get; set; }
        public int ProductTypeDetailsID { get; set; }
        public string UserType { get; set; }
        public string Application { get; set; }
        public string MountainLocation { get; set; }
        public string Accessories { get; set; }
        public string ModelYear { get; set; }
        public string ModelName { get; set; }
        public string ProductImgUrl { get; set; }
        public int TechnicalSpecifationID { get; set; }
        public decimal? AirFlow { get; set; }
        public decimal? PowerMin { get; set; }
        public decimal? PowerMax { get; set; }
        public decimal? VAC_Min { get; set; }
        public decimal? VAC_Max { get; set; }
        public int? FanSpeedMin { get; set; }
        public int? FanSpeedMax { get; set; }
        public int? NumberofFanSpeed { get; set; }
        public int? SoundAtMaxSpeed { get; set; }
        public decimal? FanSweepDiameter { get; set; }
        public decimal? HeightMin { get; set; }
        public decimal? HeightMax { get; set; }
        public decimal? Weight { get; set; }
    }
}
