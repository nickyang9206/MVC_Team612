using MVC_Team_Git_JooleMay.Models;
using MVC_Team_Git_JooleMay_DAL;
using MVC_Team_Git_JooleMay_Service.Class_Service;
using MVC_Team_Git_JooleMay_Service.Interface_Service;
using System;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Team_Git_JooleMay.Controllers
{
    public class LoginPageController : Controller
    {

        public ActionResult Login(VMLogin model)
        {
            VMRegister loginUser = new VMRegister();
            if (ModelState.IsValid)
            {
                IService userService = new Service();

                string userName = model.UserName;
                string password = model.Password;


                model.ValidMessage = userService.checkUserLogin(userName, password);
                loginUser = new VMRegister() { UserName = model.UserName, Password = model.Password, ValidMessage = model.ValidMessage };

                if (model.ValidMessage == "Login successful")
                {
                    Session["UserId"] = 1;
                    return RedirectToAction("Search", "Search");
                }
            }
            return View("DoLogin", "LoginPage", loginUser);
        }

        // GET: LoginPage
        public ActionResult DoLogin()
        {
            VMRegister loginUser = new VMRegister();

            loginUser = new VMRegister() { ValidMessage = "" };
            return View(loginUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandleError]
        public ActionResult DoLogin(VMRegister model, HttpPostedFileBase userImage)
        {


            if (ModelState.IsValid)
            {
                string msg = "";

                bool isValidImg = IsImageValid(model, userImage);

                IService userService = new Service();
                tblUser userTable = new tblUser();
                userTable = new tblUser() { UserName = model.UserName, Email = model.Email, Password = model.Password, PicUrl = model.ImageUrl };
                model.ValidMessage = userService.Insert(userTable);

                if (isValidImg)
                {
                    SaveImage(model, userImage);
                    return View(model);
                }

            }

            return View(model);


        }

        private static string GetImage(string imageUrl)
        {
            var imageUrlFormated = "/image/defaultImage.png";
            if (!string.IsNullOrEmpty(imageUrl))
            {
                imageUrlFormated = $"{ConfigurationManager.AppSettings["UserLoginImageUploadBase"].Replace("~", "")}{imageUrl}";
            }
            return imageUrlFormated;
        }


        private bool IsImageValid(VMRegister model, HttpPostedFileBase userImage)
        {
            bool isValidImg = false;
            string[] formats = new string[] { ".jpg", ".png", ".gif", ".jpeg" };

            if (userImage != null && userImage.ContentLength > 0)
            {
                isValidImg = formats.Any(
                    p => userImage.FileName.EndsWith(p, StringComparison.OrdinalIgnoreCase));
            }


            if (isValidImg)
            {
                model.ImageUrl = Path.GetFileName(userImage.FileName);
            }

            return isValidImg;
        }

        private void SaveImage(VMRegister model, HttpPostedFileBase userImage)
        {

            var fileDirectory =
                       Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["UserLoginImageUploadBase"]));

            Directory.CreateDirectory(fileDirectory);

            var filePath = Path.Combine(fileDirectory, model.ImageUrl);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            userImage.SaveAs(filePath);

        }
    }
}