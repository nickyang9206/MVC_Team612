using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Team_Git_JooleMay_Service.Models;

namespace MVC_Team_Git_JooleMay_Service.Interface_Service
{
    public partial interface IService
    {
        List<SMProductDetails> GetProductDetails(int? _subCategoryID);
        List<ModelTechFilter> GetModelTechFilters(int? _sbuCategoryID);
        List<SMProductDetails> GetFiltered(SearchResultS_Model searchResultS_Model, int SubCategoryID);
    }
}
