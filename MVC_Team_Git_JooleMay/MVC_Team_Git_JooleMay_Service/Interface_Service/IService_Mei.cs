using MVC_Team_Git_JooleMay_DAL;
using MVC_Team_Git_JooleMay_Repository.Class_Repository;
using MVC_Team_Git_JooleMay_Repository.Interface_Repository;
using MVC_Team_Git_JooleMay_Service.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVC_Team_Git_JooleMay_Service.Interface_Service
{
    public partial interface IService
    {
        SMProductDetails getDetails(int? _productID);
    }

}
