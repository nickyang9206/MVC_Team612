using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Team_Git_JooleMay.Models;
using MVC_Team_Git_JooleMay_Service.Models;
using MVC_Team_Git_JooleMay_Service.Class_Service;
using System.Net;

namespace MVC_Team_Git_JooleMay.Controllers
{
    public partial class ProjectController : Controller
    {
        Service _service = new Service();
        public ActionResult Project(int? productID)
        {
            VMProject projectResult = new VMProject();
            int userID = 1;
            Session["sessionUserID"] = userID;
            projectResult.ProjectList = _service.GetProjectsByUserID(userID);
            projectResult.ProductDetails = _service.getDetails(productID);
            projectResult.ProductID = productID.GetValueOrDefault();
            return View(projectResult);
        }

        public ActionResult Delete(int? projectID, int? productID)
        {
            int userID = 1;
            _service.DeleteProductFromProject(projectID, productID, userID);
            return RedirectToAction("Search", "Search");
        }

        public ActionResult AddToProject(int? projectID, int? productID)
        {
            int userID = 1;
            _service.SaveProject(projectID, productID, userID);
            return RedirectToAction("Search", "Search");
        }
    }
}