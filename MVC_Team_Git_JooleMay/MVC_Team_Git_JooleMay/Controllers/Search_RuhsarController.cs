using System;
﻿using MVC_Team_Git_JooleMay_Service.Class_Service;
using MVC_Team_Git_JooleMay_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Net;

namespace MVC_Team_Git_JooleMay.Controllers
{
    public partial class SearchController : Controller
    {
        [HttpGet]
        public ActionResult Compare()
        {
            List<int> productList = new List<int>();
            var products = (List<int>)TempData["products"];
            if(products == null)
            {
                return HttpNotFound();
            }
            foreach (int i in products)
            {
                productList.Add(i);
            }
            List<SMProductDetails> smProductList = _service.GetProductDetailsForCompare(productList);
            if (smProductList == null)
            {
                return HttpNotFound();
            }
            return View(smProductList);
        }

        [HttpPost]
        public JsonResult Comparison(int[] ProductList)
        {
            if(ProductList != null)
            {
                TempData["products"] = ProductList.ToList();
            }      
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}