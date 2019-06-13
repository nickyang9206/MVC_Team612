using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Team_Git_JooleMay_Repository.Interface_Repository;
using MVC_Team_Git_JooleMay_DAL;
using System.Data.Entity;

namespace MVC_Team_Git_JooleMay_Repository.Class_Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DbContext _dbContext;
        protected readonly IDbSet<T> _dbset;
        public GenericRepository(JooleMayEntities dbContext)
        {
            _dbContext = dbContext;
            _dbset = _dbContext.Set<T>();
        }

        public GenericRepository()
        {
            _dbContext = new JooleMayEntities();
            _dbset = _dbContext.Set<T>();
        }

        public virtual IEnumerable<T> GetALL()
        {
            return _dbset.AsEnumerable<T>();
        }

        public T GetByID(object id)
        {
            return _dbset.Find(id);
        }

        public void Insert(T item)
        {
            _dbset.Add(item);
        }

        public void Update(T item)
        {
            _dbset.Attach(item);
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = _dbset.Find(id);
            _dbset.Remove(existing);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
