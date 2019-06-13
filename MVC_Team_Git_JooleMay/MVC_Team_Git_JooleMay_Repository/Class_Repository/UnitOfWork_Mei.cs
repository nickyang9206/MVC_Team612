using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Team_Git_JooleMay_Repository.Interface_Repository;

namespace MVC_Team_Git_JooleMay_Repository.Class_Repository
{
    public sealed partial class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IManufactureRepository _manufactureRepo;
        private IProductTypeDetailsRepository _productTypeDetaisRepo;
        private ISeryRepository _seryRepo;
        private ITechnicalSpecificationRepository _technicalSpecificationRepo;

        public IManufactureRepository ManufactureRepo { get { return _manufactureRepo ?? (_manufactureRepo = new ManufactureRepository(_dbContext)); } }

        public IProductTypeDetailsRepository ProductTypeDetailsRepo { get { return _productTypeDetaisRepo ?? (_productTypeDetaisRepo = new ProductTypeDetailsRepository(_dbContext)); } }

        public ISeryRepository SeryRepo { get { return _seryRepo ?? (_seryRepo = new SeryRepository(_dbContext)); } }

        public ITechnicalSpecificationRepository TechnicalSpecificationRepo { get { return _technicalSpecificationRepo ?? (_technicalSpecificationRepo = new TechnicalSpecificationRepository(_dbContext)); } }
        
    }
}
