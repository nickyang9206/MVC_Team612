using System;
﻿using MVC_Team_Git_JooleMay_Service.Class_Service;
using MVC_Team_Git_JooleMay_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_Team_Git_JooleMay.Controllers
{
    public partial class SearchController : Controller
    {
        [HttpGet]
        public ActionResult Compare()
        {
            List<int> productList = new List<int>();
            var products = (List<int>)TempData["products"];
            foreach (int i in products)
            {
                productList.Add(i);
            }
            return View(_service.GetProductDetailsForCompare(productList));
        }

        [HttpPost]
        public JsonResult Comparison(int[] ProductList)
        {
            TempData["products"] = ProductList.ToList();
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}