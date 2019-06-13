using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Team_Git_JooleMay_Repository.Interface_Repository;
using MVC_Team_Git_JooleMay_DAL;


namespace MVC_Team_Git_JooleMay_Repository.Class_Repository
{
    public sealed partial class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly JooleMayEntities _dbContext;
        private IProductRepository _productRepo;
        private ICategoryRepository _categoryRepo;
        private ISubCategoryRepository _subCategoryRepo;
        private IUserRepository _userRepo;
        private IProjectRepository _projectRepo;
        private IProject2ProductRepository _project2ProductRepo;
        

        public UnitOfWork(JooleMayEntities dbContext)
        {
            _dbContext = dbContext;
        }
        public IProductRepository ProductRepo { get { return _productRepo ?? (_productRepo = new ProductRepository(_dbContext)); } }

        public ICategoryRepository CategoryRepo { get { return _categoryRepo ?? (_categoryRepo = new CategoryRepository(_dbContext)); } }

        public ISubCategoryRepository SubCategoryRepo { get { return _subCategoryRepo ?? (_subCategoryRepo = new SubCategoryRepository(_dbContext)); } }

        public IUserRepository UserRepo { get { return _userRepo ?? (_userRepo = new UserRepository(_dbContext)); } }
        public IProjectRepository ProjectRepo{ get { return _projectRepo ?? (_projectRepo = new ProjectRepository(_dbContext)); } }
        public IProject2ProductRepository Project2ProductRepo { get { return _project2ProductRepo ?? (_project2ProductRepo = new Project2ProductRepository(_dbContext)); } }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _dbContext.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }
        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            System.GC.SuppressFinalize(this);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
