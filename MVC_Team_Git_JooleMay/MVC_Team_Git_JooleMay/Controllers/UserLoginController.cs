using MVC_Team_Git_JooleMay.Models;
using MVC_Team_Git_JooleMay_Service.Class_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Team_Git_JooleMay.Controllers
{
    public class UserLoginController : Controller
    {
        // GET: UserLogin
        public ActionResult DoLogin()
        {

            return View();
        }

        [HttpPost]
        public ActionResult DoLogin(VMUser model)
        {


            ProductService productService = new ProductService();
            productService.getAllProducts().ToList();



            return View();
        }

    }
}