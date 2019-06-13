using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Team_Git_JooleMay_DAL;

namespace MVC_Team_Git_JooleMay_Repository.Interface_Repository
{
    public partial interface IUnitOfWork
    {
        IProductPropertyRepository ProductPropertyRepo { get; }
        ITechSpecFilterRepository TechSpecFilterRepo { get; }
        
    }
}
