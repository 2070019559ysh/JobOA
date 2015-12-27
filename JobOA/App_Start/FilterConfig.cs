using JobOA.Auxiliary;
using System.Web;
using System.Web.Mvc;

namespace JobOA
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ExceptionFilterAttribute());
            filters.Add(new PermissionAuthorizeAttribute());
        }
    }
}