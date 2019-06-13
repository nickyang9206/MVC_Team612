using System.Web;
using System.Web.Mvc;

namespace MVC_Team_Git_JooleMay
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
