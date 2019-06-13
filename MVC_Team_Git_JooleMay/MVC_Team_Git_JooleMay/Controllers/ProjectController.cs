using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Team_Git_JooleMay.Models;
using MVC_Team_Git_JooleMay_Service.Models;
using MVC_Team_Git_JooleMay_Service.Class_Service;
using MVC_Team_Git_JooleMay_Service.Interface_Service;
using System.Net;

namespace MVC_Team_Git_JooleMay.Controllers
{
    public partial class ProjectController : Controller
    {
        IService _service = new Service();
        public ActionResult Project(int? productID)
        {
            if(productID == null)
            {
                new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if(Session["UserId"] == null)
            {
                new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VMProject projectResult = new VMProject();
            int userID = (int)Session["UserId"];
            if(userID == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            projectResult.ProjectList = _service.GetProjectsByUserID(userID);
            projectResult.ProductDetails = _service.getDetails(productID);
            projectResult.ProductID = productID.GetValueOrDefault();

            if (projectResult.ProjectList == null || projectResult.ProductDetails == null || projectResult.ProductID == 0)
                return HttpNotFound();

            return View(projectResult);
        }

        public ActionResult Delete(int? projectID, int? productID)
        {
            if (projectID == null || productID == null)
            {
                new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int userID = (int)Session["UserId"];
            _service.DeleteProductFromProject(projectID, productID, userID);
            return RedirectToAction("Search", "Search");
        }

        public ActionResult AddToProject(int? projectID, int? productID)
        {
            if(projectID == null || productID == null)
            {
                new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int userID = (int)Session["UserId"];
            _service.SaveProject(projectID, productID, userID);
            return RedirectToAction("Search", "Search");
        }
    }
}