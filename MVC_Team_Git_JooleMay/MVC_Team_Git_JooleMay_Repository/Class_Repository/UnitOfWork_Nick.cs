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
        private IProductPropertyRepository _productPropertyRepo;
        private ITechSpecFilterRepository _techSpecFilterRepo;

        public IProductPropertyRepository ProductPropertyRepo { get { return _productPropertyRepo ?? (_productPropertyRepo = new ProductPropertyRepository(_dbContext)); } }
        public ITechSpecFilterRepository TechSpecFilterRepo { get { return _techSpecFilterRepo ?? (_techSpecFilterRepo = new TechSpecFilterRepository(_dbContext)); } }
    }
}
