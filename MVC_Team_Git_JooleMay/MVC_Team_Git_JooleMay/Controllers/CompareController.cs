using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Team_Git_JooleMay.Controllers
{
    public class CompareController : Controller
    {
        // GET: Compare
        public ActionResult Index()
        {

            return View("ComparePage");
        }
    }
}