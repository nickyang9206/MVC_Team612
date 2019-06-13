using MVC_Team_Git_JooleMay_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MVC_Team_Git_JooleMay_Service.Interface_Service
{
    public partial interface IService
    {
        string checkUserLogin(string userName, string password);

        string Insert(tblUser userDB);

        
    }
}
