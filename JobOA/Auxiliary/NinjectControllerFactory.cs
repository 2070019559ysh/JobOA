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
    /// 扩展默认控制器工厂类。默认情况下，ASP.NET MVC使用内置的Controller工厂类 DefaultControllerFactory来创建某个请求对应的Controller实例
    /// </summary>
    public class NinjectControllerFactory:IDependencyResolver, System.Web.Mvc.IDependencyResolver
    {
        private IKernel ninjectKernel;

        /// <summary>
        /// 异常处理对象
        /// </summary>
        private readonly ExceptionLog _exceptionLog = new ExceptionLog();

        /// <summary>
        /// 配置文件中指定的日志文件名
        /// </summary>
        private string logFileName;

        public NinjectControllerFactory()
        {
            if (ConfigurationManager.AppSettings["LogFileName"] != null)
            {
                logFileName = ConfigurationManager.AppSettings["LogFileName"].ToString();
            }
            else
            {
                //配置文件中不指定系统日志文件，则使用默认文件
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                //取得值file:///D:/C#/PathTest/TestProject1/bin/Debug/TestProject1.DLL
                //去掉头八个字符file///
                codeBase = codeBase.Substring(8, codeBase.Length - 8);
                logFileName = codeBase.Remove(codeBase.IndexOf("/bin")) + "/JobOAException/JobOA.log";
            }
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