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
                ModelTechFilter modelTechFilter = new ModelTechFilter
                {
                    PropertyName = item.PropertyName,
                    PropertyID = item.PropertyID,
                    MaxValue = item.MaxValue,
                    MinValue = item.MinValue,
                    IsActive = Convert.ToBoolean(item.IsActive)
                };
                modelTechFilters.Add(modelTechFilter);
            }
            return modelTechFilters;

            
        }
        public List<SMProductDetails> GetFiltered(SearchResultS_Model searchResultS_Model,int SubCategoryID)
        {
            //List<SMProductDetails> filteredProductDetails = GetProductDetails(SubCategoryID);
            // added on 0613 07:56 for product type filter
 
            List < SMProductDetails > filteredProductDetails1 = GetProductDetails(SubCategoryID);
            List<SMProductDetails> filteredProductDetails = new List<SMProductDetails>();
            //filteredProductDetails.Add(new SMProductDetails());
            for (int i = 0; i < searchResultS_Model.VMProductTypeChks.Count(); i++)
            {
                if (searchResultS_Model.VMProductTypeChks[i].IsProductTypeChecked)
                    filteredProductDetails.AddRange(filteredProductDetails1.Where(a => a.ProductType == searchResultS_Model.VMProductTypeChks[i].ProductTypeName));
            }

            //added on 0613 07:56 for model year filter

            filteredProductDetails = filteredProductDetails.Where(a => Convert.ToInt32(a.ModelYear) >= Convert.ToInt32(searchResultS_Model.YearStart) && Convert.ToInt32(a.ModelYear) <= Convert.ToInt32(searchResultS_Model.YearEnd)).ToList();


            //added on 0613 07:56 end
            for (int i = 0; i < searchResultS_Model.VMProductTypeChks.Count(); i++)
            {
                switch (searchResultS_Model.ModelTechFilters[i].PropertyID)
                {
                    case 1:
                        filteredProductDetails = filteredProductDetails.Where(a => a.AirFlow <= Convert.ToDecimal(searchResultS_Model.ModelTechFilters[i].MaxValue) && a.AirFlow >= Convert.ToDecimal(searchResultS_Model.ModelTechFilters[i].MinValue)).ToList();
                        break;
                    case 2:
                        filteredProductDetails = filteredProductDetails.Where(a => a.PowerMax <= Convert.ToDecimal(searchResultS_Model.ModelTechFilters[i].MaxValue) && a.PowerMax >= Convert.ToDecimal(searchResultS_Model.ModelTechFilters[i].MinValue)).ToList();
                        break;
                    case 3:
                        filteredProductDetails = filteredProductDetails.Where(a => a.SoundAtMaxSpeed <= Convert.ToInt32(searchResultS_Model.ModelTechFilters[i].MaxValue) && a.SoundAtMaxSpeed >= Convert.ToInt32(searchResultS_Model.ModelTechFilters[i].MinValue)).ToList();
                        break;
                    case 4:
                        filteredProductDetails = filteredProductDetails.Where(a => a.FanSweepDiameter <= Convert.ToDecimal(searchResultS_Model.ModelTechFilters[i].MaxValue) && a.FanSweepDiameter >= Convert.ToDecimal(searchResultS_Model.ModelTechFilters[i].MinValue)).ToList();
                        break;
                    case 5:
                        filteredProductDetails = filteredProductDetails.Where(a => a.HeightMax <= Convert.ToDecimal(searchResultS_Model.ModelTechFilters[i].MaxValue) && a.HeightMax >= Convert.ToDecimal(searchResultS_Model.ModelTechFilters[i].MinValue)).ToList();
                        break;
                    case 6:
                        filteredProductDetails = filteredProductDetails.Where(a => a.Weight <= Convert.ToDecimal(searchResultS_Model.ModelTechFilters[i].MaxValue) && a.Weight >= Convert.ToDecimal(searchResultS_Model.ModelTechFilters[i].MinValue)).ToList();
                        break;
                    case 7:
                        filteredProductDetails = filteredProductDetails.Where(a => a.VAC_Max <= Convert.ToDecimal(searchResultS_Model.ModelTechFilters[i].MaxValue) && a.VAC_Max >= Convert.ToDecimal(searchResultS_Model.ModelTechFilters[i].MinValue)).ToList();
                        break;
                    case 8:
                        filteredProductDetails = filteredProductDetails.Where(a => a.FanSpeedMax <= Convert.ToInt32(searchResultS_Model.ModelTechFilters[i].MaxValue) && a.FanSpeedMax >= Convert.ToInt32(searchResultS_Model.ModelTechFilters[i].MinValue)).ToList();
                        break;
                    case 9:
                        filteredProductDetails = filteredProductDetails.Where(a => a.NumberofFanSpeed <= Convert.ToInt32(searchResultS_Model.ModelTechFilters[i].MaxValue) && a.NumberofFanSpeed >= Convert.ToInt32(searchResultS_Model.ModelTechFilters[i].MinValue)).ToList();
                        break;
                    case 10:
                        filteredProductDetails = filteredProductDetails.Where(a => a.PowerMin <= Convert.ToDecimal(searchResultS_Model.ModelTechFilters[i].MaxValue) && a.PowerMin >= Convert.ToDecimal(searchResultS_Model.ModelTechFilters[i].MinValue)).ToList();
                        break;
                    case 11:
                        filteredProductDetails = filteredProductDetails.Where(a => a.VAC_Min <= Convert.ToDecimal(searchResultS_Model.ModelTechFilters[i].MaxValue) && a.VAC_Min >= Convert.ToDecimal(searchResultS_Model.ModelTechFilters[i].MinValue)).ToList();
                        break;
                    case 12:
                        filteredProductDetails = filteredProductDetails.Where(a => a.FanSpeedMin <= Convert.ToInt32(searchResultS_Model.ModelTechFilters[i].MaxValue) && a.FanSpeedMin >= Convert.ToInt32(searchResultS_Model.ModelTechFilters[i].MinValue)).ToList();
                        break;
                    case 13:
                        filteredProductDetails = filteredProductDetails.Where(a => a.HeightMin <= Convert.ToDecimal(searchResultS_Model.ModelTechFilters[i].MaxValue) && a.HeightMin >= Convert.ToDecimal(searchResultS_Model.ModelTechFilters[i].MinValue)).ToList();
                        break;
                    default:
                        break;
                }

            }
            return filteredProductDetails;
        }
    }
}
