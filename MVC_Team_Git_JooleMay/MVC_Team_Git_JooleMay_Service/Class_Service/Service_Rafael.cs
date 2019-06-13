using MVC_Team_Git_JooleMay_DAL;
using MVC_Team_Git_JooleMay_Repository.Class_Repository;
using MVC_Team_Git_JooleMay_Repository.Interface_Repository;
using MVC_Team_Git_JooleMay_Service.Interface_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MVC_Team_Git_JooleMay_Service.Class_Service
{
    public partial class Service : IService
    {

        public string checkUserLogin(string userName, string Password)
        {
            string msg = "";


            var allUserDB = unitOfWork.UserRepo.GetALL().ToList();
            var singleUserDB = allUserDB.Where(p => (p.UserName == userName || p.Email == userName)).ToList();

            if (singleUserDB != null && singleUserDB.Count > 0)
            {
                foreach (var user in singleUserDB)
                {
                    if (user.UserName.ToLower() == userName.ToLower() || user.Email.ToLower() == userName.ToLower())
                    {
                        if (user.Password == Password)
                        {

                            msg = "Login successful";
                        }
                        else
                        {
                            msg = "Wrong User Name or Password";
                        }
                    }
                }
            }
            else
            {
                msg = "Wrong User Name or Password";
            }

            return msg;
        }

        public void Insert(tblUser userDB)
        {
            string msg = "";
            IUnitOfWork unitOfWork = new UnitOfWork(new JooleMayEntities());
            var allUserDB = unitOfWork.UserRepo.GetALL().ToList();
            var singleUserDB = allUserDB.Where(p => (p.Email == userDB.Email)).ToList();

            if (singleUserDB.Count < 1)
            {
                if (userDB.PicUrl == null)
                {
                    userDB.PicUrl = "defaultImage.png";
                }

                unitOfWork.UserRepo.Insert(userDB);
                //unitOfWork.UserRepo.SaveChanges();

            }
            else { msg = "User already exist"; }





            //cookie = new HttpCookie("UserLogin");
            //cookie["ID"] = user.UserID.ToString();
            //cookie["PicUrl"] = user.PicUrl.ToString();


        }
    }
}
