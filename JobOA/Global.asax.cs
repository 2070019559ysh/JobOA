using JobOA.Auxiliary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace JobOA
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //设置Controller工厂,告诉MVC用我们的NinjectControllerFactory类来创建Controller对象
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
            // MVC 依赖
            DependencyResolver.SetResolver(new NinjectControllerFactory());
        }

        /// <summary>
        /// 自定义404页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex is HttpException && ((HttpException)ex).GetHttpCode() == 404)
            {
                //重定向到找不到文件页面
                Response.Redirect("/ErrorCatch/FileNotFound");
            }
        }
    }
}