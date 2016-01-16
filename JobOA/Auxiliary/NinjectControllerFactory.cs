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

namespace JobOA.Auxiliary
{
    /// <summary>
    /// 表示依赖关系注入容器。定义可简化服务位置和依赖关系解析的方法。
    /// </summary>
    public class NinjectControllerFactory:IDependencyResolver, System.Web.Mvc.IDependencyResolver
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
        }

        public object GetService(Type serviceType)
        {
            return this.ninjectKernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.ninjectKernel.GetAll(serviceType);
        }

        public IDependencyScope BeginScope()
        {
            return this; 
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}