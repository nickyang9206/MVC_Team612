using MVC_Team_Git_JooleMay_DAL;
using MVC_Team_Git_JooleMay_Repository.Class_Repository;
using MVC_Team_Git_JooleMay_Repository.Interface_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Team_Git_JooleMay_Service.Class_Service
{
    public class SearchService
    {
        IUnitOfWork unitOfWork = new UnitOfWork(new JooleMayEntities());

        public List<tblProductCategory> getAllCategories()
        {
            return unitOfWork.CategoryRepo.GetALL().ToList();
        }

        public List<tblProductSubCategory> getAllSubCategories()
        {
            return unitOfWork.SubCategoryRepo.GetALL().ToList();
        }

    }
}

