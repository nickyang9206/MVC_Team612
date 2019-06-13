using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Team_Git_JooleMay.Models;
using MVC_Team_Git_JooleMay_Service.Class_Service;


namespace MVC_Team_Git_JooleMay.Controllers
{
    public class ProductController : Controller
    {
        //JooleMayEntities db = new JooleMayEntities();
        // GET: Product
        public ActionResult Index()
        {
            ProductService productService = new ProductService();

            return View(productService.getAllProducts().ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            //ProductService db = new ProductService();
            //ProductService _productdetail = new ProductService();
            //SqlParameter param1 = new SqlParameter("@ProductID", id);

            //JooleMayEntityTwo _entity = new JooleMayEntityTwo();
            //return View(_entity.getStudentDetails(id));

            //var result = db.
            return View();
                
            //return View(result.ToList());
            //return View(result.getProductDetails(id).ToList());
    
                
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {

            return View();
        }

    }
}
