using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Team_Git_JooleMay_DAL;
using MVC_Team_Git_JooleMay_Service.Interface_Service;
using MVC_Team_Git_JooleMay_Service.Models;

namespace MVC_Team_Git_JooleMay_Service.Class_Service
{
    public partial class Service : IService
    {
        public List<tblProductCategory> getAllCategories()
        {
            return unitOfWork.CategoryRepo.GetALL().ToList();
        }

        public List<tblProductSubCategory> GetAllSubCategories()
        {
            return unitOfWork.SubCategoryRepo.GetALL().ToList();
        }

        public List<tblProduct> GetAllProducts()
        {
            return unitOfWork.ProductRepo.GetALL().ToList();
        }
       
        public List<SMProductList> SearchProducts(int? categoryID, int? subCategoryID)
        {
            List<SMProductList> productSearchResult = new List<SMProductList>();

            var products = unitOfWork.ProductRepo.GetALL().ToList();
            var techSpecs = unitOfWork.TechnicalSpecificationRepo.GetALL().ToList();

            var productList = from p in products
                              join t in techSpecs on p.TechnicalSpecificationID equals t.TechnicalSpecifationID
                              where p.CategoryID == categoryID && p.SubCategoryID == subCategoryID
                              select new
                              {
                                  ProductName = p.ProductName,
                                  ProductModel = p.ProductModel
                                  //add more todo Ruhsar
                              };

            foreach (var item in productList)
            {
                SMProductList product = new SMProductList();
                product.ProductName = product.ProductName;
                product.ProductModel = product.ProductModel;
                productSearchResult.Add(product);
            }
            return productSearchResult;
        }

        public List<SMProductDetails> GetProductDetailsForCompare(List<int> products)
        {
            List<SMProductDetails> productDetailsResult = new List<SMProductDetails>();
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
                           where products.Contains(r2.ProductID)
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
                smProductDetails.AirFlow = item.AirFlow.GetValueOrDefault();
                smProductDetails.PowerMin = item.PowerMin.GetValueOrDefault();
                smProductDetails.PowerMax = item.PowerMax.GetValueOrDefault();
                smProductDetails.VAC_Max = item.OperatingVoltageMax.GetValueOrDefault();
                smProductDetails.VAC_Min = item.OperatingVoltageMin.GetValueOrDefault();
                smProductDetails.FanSpeedMax = item.FanSpeedMax.GetValueOrDefault();
                smProductDetails.FanSpeedMin = item.FanSpeedMin.GetValueOrDefault();
                smProductDetails.NumberofFanSpeed = item.NumberOfFanSpeeds.GetValueOrDefault();
                smProductDetails.SoundAtMaxSpeed = item.SoundAtMaxSpeed.GetValueOrDefault();
                smProductDetails.FanSweepDiameter = item.Diameter.GetValueOrDefault();
                smProductDetails.HeightMax = item.HeightMax.GetValueOrDefault();
                smProductDetails.HeightMin = item.HeightMin.GetValueOrDefault();
                smProductDetails.Weight = item.Weight.GetValueOrDefault();
                smProductDetails.ProductImgUrl = item.ProductImgUrl;

                productDetailsResult.Add(smProductDetails);
            }

            return (productDetailsResult);

        }

        public void SaveProject(int? projectID, int? productID, int userID)
        {
            try
            {
                var random = new Random();
                int randomnumber = random.Next();
                tblProject2Product details = new tblProject2Product();
                details.ID = randomnumber;//projectID.GetValueOrDefault() + userID + productID.GetValueOrDefault();
                details.ProjectID = projectID.GetValueOrDefault();
                details.CreateDate = DateTime.Now;
                details.ProductID = productID.GetValueOrDefault();
                details.UserID = userID;

                unitOfWork.Project2ProductRepo.Insert(details);
                unitOfWork.Project2ProductRepo.SaveChanges();
            }
            catch(Exception e)
            {

            }
            
        }

        public void DeleteProductFromProject(int? projectID, int? productID, int userID)
        {
            try
            {
                var list = unitOfWork.Project2ProductRepo.GetALL();
                var productResult = from p in list
                                    where p.ProductID == productID && p.ProjectID == projectID && p.UserID == userID
                                    select new
                                    {
                                        ID = p.ID
                                    };
                unitOfWork.Project2ProductRepo.Delete(productResult.ToList()[0].ID);
                unitOfWork.Project2ProductRepo.SaveChanges();
            }
            catch (Exception e)
            {

            }

        }

        public List<SMProject> GetProjectsByUserID(int? userID)
        {
            List<SMProject> projectListResult = new List<SMProject>();
            var result = unitOfWork.ProjectRepo.GetALL().ToList();
            var projectList = from p in result
                              where p.UserID == userID
                              select new
                              {
                                  ProjectID = p.ProjectID,
                                  ProjectName = p.ProjectName,
                                  UserID = p.UserID
                              };

            foreach (var item in projectList)
            {
                SMProject project = new SMProject();
                project.ProjectID = item.ProjectID;
                project.ProjectName = item.ProjectName;
                project.UserID = item.UserID;

                projectListResult.Add(project);
            }
            return projectListResult;
        }
    }
}
