using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobOA.BLL;
using JobOA.BLL.Implement;
using JobOA.Common;
using System.Configuration;
using System.Reflection;
using System.Web.Http.Dependencies;
using System.Web.Routing;

namespace JobOA.Auxiliary
{
    /// <summary>
    /// 表示依赖关系注入容器。定义可简化服务位置和依赖关系解析的方法。
    /// </summary>
    public class NinjectControllerFactory : System.Web.Mvc.DefaultControllerFactory,IDependencyResolver, System.Web.Mvc.IDependencyResolver
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        /// <summary>
        /// 添加此层的接口对具体实现类的绑定
        /// </summary>
        private void AddBindings()
        {
            //先添加业务逻辑层对数据访问层接口的绑定
            NinjectManagerFactory ninjectManager = new NinjectManagerFactory(ninjectKernel);
            ninjectKernel.Bind<IDepartmentManager>().To<DepartmentManager>();
            ninjectKernel.Bind<IRoleManager>().To<RoleManager>();
            //添加实现类绑定时，同时给构造函数赋值
            ninjectKernel.Bind<IEmployeeManager>().To<EmployeeManager>();
            //.WithConstructorArgument(HttpContext.Current.Server.MapPath("~/"));
            ninjectKernel.Bind<IOAUiManager>().To<OAUiManager>();
            ninjectKernel.Bind<IMajorTaskManager>().To<MajorTaskManager>();
            ninjectKernel.Bind<IProjectManager>().To<ProjectManageer>();
            ninjectKernel.Bind<IOAMessageManager>().To<OAMessageManager>();
        }

        /// <summary>
        /// 提供获取注入接口的实际实现类
        /// </summary>
        /// <param name="serviceType">serviceType</param>
        /// <returns>object</returns>
        public object GetService(Type serviceType)
        {
            return this.ninjectKernel.TryGet(serviceType);
        }

        /// <summary>
        /// 提供获取多个注入接口的实际实现类
        /// </summary>
        /// <param name="serviceType">serviceType</param>
        /// <returns>object集合</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.ninjectKernel.GetAll(serviceType);
        }

        /// <summary>
        /// 获取依赖项范围
        /// </summary>
        /// <returns>依赖项范围对象</returns>
        public IDependencyScope BeginScope()
        {
            return this; 
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 创建任何控制器实例都执行此方法获取，同时对控制器判断是否存在，不存在会重定向到404页面
        /// </summary>
        /// <param name="requestContext">请求上下文</param>
        /// <param name="controllerType">要获取的控制器类型</param>
        /// <returns>控制器实例</returns>
        protected override System.Web.Mvc.IController GetControllerInstance(RequestContext requestContext,Type controllerType)
        {
            if (controllerType == null)
            {
                requestContext.HttpContext.Response.Redirect("~/ErrorCatch/FileNotFound",true);
            }
            return controllerType == null ? null : (System.Web.Mvc.IController)ninjectKernel.Get(controllerType);
        }
    }
}