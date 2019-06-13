using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Team_Git_JooleMay_DAL;
using MVC_Team_Git_JooleMay_Service.Models;

namespace MVC_Team_Git_JooleMay_Service.Interface_Service
{
    public partial interface IService
    {
        List<tblProductCategory> getAllCategories();
        List<tblProductSubCategory> GetAllSubCategories();
        List<tblProduct> GetAllProducts();
        List<SMProductDetails> GetProductDetailsForCompare(List<int> products);
        //tblProduct GetProductById(int? productID);
        List<SMProject> GetProjectsByUserID(int? userID);
        void SaveProject(int? projectID, int? productID, int userID);
        void DeleteProductFromProject(int? projectID, int? productID, int userID);
    }
}
