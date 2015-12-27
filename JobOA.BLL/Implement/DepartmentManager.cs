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
        /// <returns>添加的记录数</returns>
        public int AddDepartment(Department department)
        {
            return DepartmentService.AddDepartment(department);
        }

        /// <summary>
        /// 删除部门信息
        /// </summary>
        /// <param name="id">部门Id</param>
        /// <returns>删除的记录数</returns>
        public int DeleteDepartment(int id)
        {
            return DepartmentService.DeleteDepartment(id);
        }

        /// <summary>
        /// 更新部门信息
        /// </summary>
        /// <param name="department">新部门信息</param>
        /// <returns>修改的记录数</returns>
        public int UpdateDepartment(Department department)
        {
            return DepartmentService.UpdateDepartment(department);
        }
    }
}