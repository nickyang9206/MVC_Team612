using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Team_Git_JooleMay.Models;
using MVC_Team_Git_JooleMay_Service.Class_Service;
using MVC_Team_Git_JooleMay_Service.Interface_Service;

namespace MVC_Team_Git_JooleMay.Controllers
{
    public partial class ProjectController : Controller
    {
        IService _service = new Service();

        public ViewResult Index()
        {
            return View();
        }


    }
}