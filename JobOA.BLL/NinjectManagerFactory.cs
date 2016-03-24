using JobOA.DAL;
using JobOA.DAL.Implement;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.BLL
{
    public class NinjectManagerFactory
    {
        private IKernel ninjectKernel;
        public NinjectManagerFactory(IKernel kernel)
        {
            //创建Ninject内核实例
            ninjectKernel = kernel;
            AddBindings();
        }

        /// <summary>
        /// 添加此层的接口对具体实现类的绑定
        /// </summary>
        private void AddBindings()
        {
            ninjectKernel.Bind<IEmployeeService>().To<EmployeeService>();
            ninjectKernel.Bind<IAccessPathService>().To<AccessPathService>();
            ninjectKernel.Bind<IDailyUpdateService>().To<DailyUpdateService>();
            ninjectKernel.Bind<IDepartmentService>().To<DepartmentService>();
            ninjectKernel.Bind<IRoleService>().To<RoleService>();
            ninjectKernel.Bind<IOAUiService>().To<OAUiService>();
            ninjectKernel.Bind<IPermissionService>().To<PermissionService>();
            ninjectKernel.Bind<IMajorTaskService>().To<MajorTaskService>();
            ninjectKernel.Bind<IProjectService>().To<ProjectService>();
            ninjectKernel.Bind<IOAMessageService>().To<OAMessageService>();
        }
    }
}
