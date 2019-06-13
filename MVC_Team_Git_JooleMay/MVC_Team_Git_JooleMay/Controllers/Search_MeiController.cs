using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Team_Git_JooleMay.Models;
using MVC_Team_Git_JooleMay_Service.Class_Service;
using MVC_Team_Git_JooleMay_Service.Interface_Service;
using MVC_Team_Git_JooleMay_Service.Models;

namespace MVC_Team_Git_JooleMay.Controllers
{
       
    public partial class SearchController : Controller
    {
        // GET: Search_Mei
        Service service = new Service();
        public ActionResult Index(int? _productID)
        {
            SMProductDetails serviceTry = new SMProductDetails();
            //if (_productID == null)
            //{
            //    return View(ProductListPage)
            //    if the product id is null, the page should go back to ListPage;
            //}
            return View(service.getDetails(66));
        }

        public ActionResult TrySearchResult()
        {
            
            return View();
        }

        public ActionResult TrySearchResultFromRuhsar()
        {

            return View();
        }
    }
}