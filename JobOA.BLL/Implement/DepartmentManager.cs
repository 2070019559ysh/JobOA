using JobOA.Common;
using JobOA.DAL;
using JobOA.Model;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.BLL.Implement
{
    /// <summary>
    /// 部门信息业务管理类
    /// </summary>
    public class DepartmentManager:IDepartmentManager
    {
        /// <summary>
        /// Ninject注册的部门信息关联数据库接口
        /// </summary>
        [Inject]
        public IDepartmentService DepartmentService { get; set; }

        /// <summary>
        /// 异常处理对象
        /// </summary>
        private readonly ExceptionLog _exceptionLog = new ExceptionLog();

        /// <summary>
        /// 通过Id查找部门信息
        /// </summary>
        /// <returns>部门信息</returns>
        public Department SearchDepartmentById(int id)
        {
            return DepartmentService.SearchDepartmentById(id);
        }

        /// <summary>
        /// 查找所有部门信息
        /// </summary>
        /// <returns>所有部门信息列表</returns>
        public List<Department> SearchAllDepartment()
        {
            return DepartmentService.SearchAllDepartment();
        }

        /// <summary>
        /// 添加部门信息
        /// </summary>
        /// <param name="department">部门信息</param>
        /// <returns>添加的记录是否成功</returns>
        public bool AddDepartment(Department department)
        {
            bool isSuccess = false;
            try
            {
                if (DepartmentService.AddDepartment(department) > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(ex);
            }
            return isSuccess;
        }

        /// <summary>
        /// 删除部门信息
        /// </summary>
        /// <param name="id">部门Id</param>
        /// <returns>删除的记录是否成功</returns>
        public bool DeleteDepartment(int id)
        {
            bool isSuccess = false;
            try
            {
                if (DepartmentService.DeleteDepartment(id) > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(ex);
            }
            return isSuccess;
        }

        /// <summary>
        /// 更新部门信息
        /// </summary>
        /// <param name="department">新部门信息</param>
        /// <returns>修改的记录是否成功</returns>
        public bool UpdateDepartment(Department department)
        {
            bool isSuccess = false;
            try
            {
                if (DepartmentService.UpdateDepartment(department) > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(ex);
            }
            return isSuccess;
        }
    }
}