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
                loginUser = new VMRegister() {  UserName = model.UserName, Password = model.Password , ValidMessage = model.ValidMessage };

                if (model.ValidMessage == "Login successful")
                {
                    return RedirectToAction("SearchPage", "Search");
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
                IService userService = new Service();
                tblUser userTable = new tblUser();
                userTable = new tblUser() { UserName = model.UserName, Email = model.Email, Password = model.Password, PicUrl = userImage.FileName};
                userService.Insert(userTable);


            }


            bool isValidDoc = false;
            string[] formats = new string[] { ".jpg", ".png", ".gif", ".jpeg" };


            if (ModelState.IsValid)
            {
                using (JooleMayEntities db = new JooleMayEntities())
                {
                    tblUser userDB = new tblUser
                    {
                        UserID = model.UserID,
                        UserName = model.UserName,
                        Email = model.Email,
                        Password = model.Password,
                        PicUrl = model.ImageUrl
                    };



                    if (userImage != null && userImage.ContentLength > 0)
                    {
                        isValidDoc = formats.Any(
                            p => userImage.FileName.EndsWith(p, StringComparison.OrdinalIgnoreCase));
                    }

                    if (isValidDoc)
                    {
                        model.ImageUrl = Path.GetFileName(userImage.FileName);
                    }



                    /******************************************************/


                    if (model.UserID == 0)
                    {
                        db.tblUsers.Add(userDB);
                    }
                    else
                    {
                        db.Entry(model).State = EntityState.Modified;
                    }

                    //db.SaveChanges();

                    if (isValidDoc)
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

            return View(model);


        }

    }
}