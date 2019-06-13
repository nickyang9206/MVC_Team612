using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Team_Git_JooleMay.Models;
using MVC_Team_Git_JooleMay_Service.Class_Service;
using MVC_Team_Git_JooleMay_Service.Interface_Service;
using MVC_Team_Git_JooleMay_Service.Models;
using System.Net;

namespace MVC_Team_Git_JooleMay.Controllers
{

    public partial class SearchController : Controller
    {

        // GET: Search_Mei
        IService service = new Service();
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SMProductDetails smProductDetails = _service.getDetails(id);
            if (smProductDetails == null)
            {
                return HttpNotFound();
            }
            return View(smProductDetails);


        }
    }
}