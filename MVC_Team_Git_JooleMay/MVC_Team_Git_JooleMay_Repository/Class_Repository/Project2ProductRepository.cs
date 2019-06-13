using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Team_Git_JooleMay_Repository.Interface_Repository;
using MVC_Team_Git_JooleMay_DAL;

namespace MVC_Team_Git_JooleMay_Repository.Class_Repository
{
    public class Project2ProductRepository:GenericRepository<tblProject2Product>,IProject2ProductRepository
    {
        public Project2ProductRepository(JooleMayEntities dbContext) : base(dbContext)
        {

        }
    }
}
