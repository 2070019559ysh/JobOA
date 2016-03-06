using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.BLL
{
    /// <summary>
    /// 部门信息业务管理接口
    /// </summary>
    public interface IDepartmentManager
    {
        /// <summary>
        /// 通过Id查找部门信息
        /// </summary>
        /// <returns>部门信息</returns>
        Department SearchDepartmentById(int id);

        /// <summary>
        /// 查找所有部门信息
        /// </summary>
        /// <returns>所有部门信息列表</returns>
        List<Department> SearchAllDepartment();

        /// <summary>
        /// 添加部门信息
        /// </summary>
        /// <param name="department">部门信息</param>
        /// <returns>添加的记录是否成功</returns>
        bool AddDepartment(Department department);

        /// <summary>
        /// 删除部门信息
        /// </summary>
        /// <param name="id">部门Id</param>
        /// <returns>删除的记录是否成功</returns>
        bool DeleteDepartment(int id);

        /// <summary>
        /// 更新部门信息
        /// </summary>
        /// <param name="department">新部门信息</param>
        /// <returns>修改的记录是否成功</returns>
        bool UpdateDepartment(Department department);
    }
}