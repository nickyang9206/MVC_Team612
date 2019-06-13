using MVC_Team_Git_JooleMay_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Team_Git_JooleMay_Service.Interface_Service
{
    public interface ISearchService
    {
        List<tblProductCategory> getAllCategories();
    }
}
