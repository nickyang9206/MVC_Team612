using MVC_Team_Git_JooleMay_DAL;
using MVC_Team_Git_JooleMay_Repository.Class_Repository;
using MVC_Team_Git_JooleMay_Repository.Interface_Repository;
using MVC_Team_Git_JooleMay_Service.Interface_Service;
using MVC_Team_Git_JooleMay_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Team_Git_JooleMay_Service.Class_Service
{
    public partial class Service : IService
    {

        public SMProductDetails getDetails(int? _productID)
        {
            SMProductDetails smProductDetails = new SMProductDetails();
            var result1 = unitOfWork.ManufactureRepo.GetALL().ToList();
            var result2 = unitOfWork.ProductRepo.GetALL().ToList();
            var result3 = unitOfWork.SeryRepo.GetALL().ToList();
            var result4 = unitOfWork.TechnicalSpecificationRepo.GetALL().ToList();
            var result5 = unitOfWork.ProductTypeDetailsRepo.GetALL().ToList();           

            var smResult = from r2 in result2
                           join r1 in result1 on r2.ManufactureID equals r1.ManufactureID
                           join r3 in result3 on r2.SeriesID equals r3.SeriesID
                           join r4 in result4 on r2.TechnicalSpecificationID equals r4.TechnicalSpecifationID
                           join r5 in result5 on r2.ProductTypeDetailsID equals r5.ProductTypeDetailsID
                           where r2.ProductID == _productID
                           select new
                           {
                               ProductID = r2.ProductID,
                               Manufacture = r1.ManufactureName,
                               Series = r3.SeriesName,
                               Model = r2.ProductModel,
                               UserType = r5.UserType,
                               Application = r5.Application,
                               MountainLocation = r5.MountainLocation,
                               Accessories = r5.Accessories,
                               ModelYear = r5.ModelYear,
                               ModelName = r2.ProductModel,
                               AirFlow = r4.AirFlow,
                               PowerMax = r4.PowerMax,
                               PowerMin = r4.PowerMin,
                               OperatingVoltageMax = r4.VAC_Max,
                               OperatingVoltageMin = r4.VAC_Min,
                               FanSpeedMax = r4.FanSpeedMax,
                               FanSpeedMin = r4.FanSpeedMin,
                               NumberOfFanSpeeds = r4.NumberofFanSpeed,
                               SoundAtMaxSpeed = r4.SoundAtMaxSpeed,
                               Diameter = r4.FanSweepDiameter,
                               HeightMax = r4.HeightMax,
                               HeightMin = r4.HeightMin,
                               Weight = r4.Weight,
                               ProductImgUrl = r2.ProductImgUrl
                           };
            smProductDetails.ProductID = smResult.ToList()[0].ProductID;
            smProductDetails.ManufactureName = smResult.ToList()[0].Manufacture;
            smProductDetails.SeriesName = smResult.ToList()[0].Series;
            smProductDetails.ModelName = smResult.ToList()[0].ModelName;
            smProductDetails.ModelYear = smResult.ToList()[0].ModelYear;
            smProductDetails.Accessories = smResult.ToList()[0].Accessories;
            smProductDetails.UserType = smResult.ToList()[0].UserType;
            smProductDetails.Application = smResult.ToList()[0].Application;
            smProductDetails.MountainLocation = smResult.ToList()[0].MountainLocation;
            smProductDetails.AirFlow = (smResult.ToList()[0].AirFlow).Value;
            smProductDetails.PowerMin = (smResult.ToList()[0].PowerMin).Value;
            smProductDetails.PowerMax = (smResult.ToList()[0].PowerMax).Value;
            smProductDetails.VAC_Max = (smResult.ToList()[0].OperatingVoltageMax).Value;
            smProductDetails.VAC_Min = (smResult.ToList()[0].OperatingVoltageMin).Value;
            smProductDetails.FanSpeedMax = (smResult.ToList()[0].FanSpeedMax).Value;
            smProductDetails.FanSpeedMin= (smResult.ToList()[0].FanSpeedMin).Value;
            smProductDetails.NumberofFanSpeed = (smResult.ToList()[0].NumberOfFanSpeeds).Value;
            smProductDetails.SoundAtMaxSpeed = (smResult.ToList()[0].SoundAtMaxSpeed).Value;
            smProductDetails.FanSweepDiameter = (smResult.ToList()[0].Diameter).Value;
            smProductDetails.HeightMax= (smResult.ToList()[0].HeightMax).Value;
            smProductDetails.HeightMin = (smResult.ToList()[0].HeightMin).Value;
            smProductDetails.Weight = (smResult.ToList()[0].Weight).Value;
            smProductDetails.ProductImgUrl = smResult.ToList()[0].ProductImgUrl;

            return (smProductDetails);
           
        }
      
    }
}
