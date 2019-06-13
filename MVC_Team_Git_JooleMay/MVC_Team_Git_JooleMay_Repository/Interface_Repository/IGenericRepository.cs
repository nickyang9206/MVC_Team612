using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Team_Git_JooleMay_Repository.Interface_Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetALL();
        T GetByID(object id);

        void Insert(T item);
        void Update(T item);
        void Delete(object id);
        void SaveChanges();

    }
}
