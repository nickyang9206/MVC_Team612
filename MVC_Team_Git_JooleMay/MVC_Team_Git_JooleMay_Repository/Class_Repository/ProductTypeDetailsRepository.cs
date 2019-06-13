using MVC_Team_Git_JooleMay_DAL;
using MVC_Team_Git_JooleMay_Repository.Interface_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Team_Git_JooleMay_Repository.Class_Repository
{
    class ProductTypeDetailsRepository : GenericRepository<tblProductTypeDetail>, IProductTypeDetailsRepository
    {
        public ProductTypeDetailsRepository(JooleMayEntities dbContext) : base(dbContext)
        {

        }
    }
}

