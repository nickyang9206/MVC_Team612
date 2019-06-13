using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Team_Git_JooleMay_DAL;
using MVC_Team_Git_JooleMay_Repository.Interface_Repository;

namespace MVC_Team_Git_JooleMay_Repository.Class_Repository
{
    public class TechSpecFilterRepository:GenericRepository<tblTechSpecFilter>,ITechSpecFilterRepository
    {
        public TechSpecFilterRepository(JooleMayEntities dbContext) : base(dbContext)
        {

        }
    }
}
