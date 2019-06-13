using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Team_Git_JooleMay_Service.Interface_Service;
using MVC_Team_Git_JooleMay_Service.Models;

namespace MVC_Team_Git_JooleMay_Service.Class_Service
{
    public partial class Service : IService
    {
        public List<SMProductDetails> GetProductDetails(int? _subCategoryID)
        {
            List<SMProductDetails> smProductDetailsList = new List<SMProductDetails>();
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
                           where r2.SubCategoryID == _subCategoryID
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
            foreach (var item in smResult)
            {
                SMProductDetails smProductDetails = new SMProductDetails();
                smProductDetails.ProductID = item.ProductID;
                smProductDetails.ManufactureName = item.Manufacture;
                smProductDetails.SeriesName = item.Series;
                smProductDetails.ModelName = item.ModelName;
                smProductDetails.ModelYear = item.ModelYear;
                smProductDetails.Accessories = item.Accessories;
                smProductDetails.UserType = item.UserType;
                smProductDetails.Application = item.Application;
                smProductDetails.MountainLocation = item.MountainLocation;
                smProductDetails.AirFlow = item.AirFlow;
                smProductDetails.PowerMin = item.PowerMin;
                smProductDetails.PowerMax = item.PowerMax;
                smProductDetails.VAC_Max = item.OperatingVoltageMax;
                smProductDetails.VAC_Min = item.OperatingVoltageMin;
                smProductDetails.FanSpeedMax = item.FanSpeedMax;
                smProductDetails.FanSpeedMin = item.FanSpeedMin;
                smProductDetails.NumberofFanSpeed = item.NumberOfFanSpeeds;
                smProductDetails.SoundAtMaxSpeed = item.SoundAtMaxSpeed;
                smProductDetails.FanSweepDiameter = item.Diameter;
                smProductDetails.HeightMax = item.HeightMax;
                smProductDetails.HeightMin = item.HeightMin;
                smProductDetails.Weight = item.Weight;
                smProductDetails.ProductImgUrl = item.ProductImgUrl;
                smProductDetailsList.Add(smProductDetails);
            }


            return smProductDetailsList;
        }

        public List<ModelTechFilter> GetModelTechFilters(int? _sbuCategoryID)
        {
            List<ModelTechFilter> modelTechFilters = new List<ModelTechFilter>();
            var result1 = unitOfWork.ProductPropertyRepo.GetALL();
            var result2 = unitOfWork.TechSpecFilterRepo.GetALL();
            var smResult = from r2 in result2
                           join r1 in result1 on r2.PropertyID equals r1.PropertyID
                           where r2.SubCategoryID == _sbuCategoryID
                           && r2.IsActive == true
                           && r1.IsTechSpec == true
                           select new
                           {
                               PropertyID = r1.PropertyID,
                               SubCategoryID = r2.SubCategoryID,
                               MaxValue = r2.MaxValue,
                               MinValue = r2.MinValue,
                               IsActive = r2.IsActive,
                               PropertyName = r1.PropertyName,
                               IsTechSpec = r1.IsTechSpec
                           };
            foreach (var item in smResult)
            {
                ModelTechFilter modelTechFilter = new ModelTechFilter();
                modelTechFilter.PropertyName = item.PropertyName;
                modelTechFilter.PropertyID = item.PropertyID;
                modelTechFilter.MaxValue = item.MaxValue;
                modelTechFilter.MinValue = item.MinValue;
                modelTechFilter.IsActive = item.IsActive;
                modelTechFilters.Add(modelTechFilter);
            }
            return modelTechFilters;

        }
    }
}
