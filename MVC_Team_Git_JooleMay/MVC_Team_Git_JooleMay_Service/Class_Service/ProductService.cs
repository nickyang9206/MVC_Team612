using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Team_Git_JooleMay_Service.Interface_Service;
using MVC_Team_Git_JooleMay_Repository.Class_Repository;
using MVC_Team_Git_JooleMay_Repository.Interface_Repository;
using MVC_Team_Git_JooleMay_DAL;


namespace MVC_Team_Git_JooleMay_Service.Class_Service
{
    public class ProductService:IProductService
    {
        IUnitOfWork unitOfWork = new UnitOfWork(new JooleMayEntities());

        public List<tblProduct> getAllProducts()
        {
            return unitOfWork.ProductRepo.GetALL().ToList();
        }

        //public List<tblProduct> getProductDetails(int id)
        //{   
        //    //var result = ExecuteSqlCommand("spGetProductDetails",
        //    //                             id);
        //    return unitOfWork.ProductDetails.GetDetail(id).ToList();
        //}

        
    }
}
