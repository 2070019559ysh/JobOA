using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL
{
    /// <summary>
    /// 部门信息关联数据库接口
    /// </summary>
    public interface IDepartmentService
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
        /// <returns>添加的记录数</returns>
        int AddDepartment(Department department);

        /// <summary>
        /// 删除部门信息
        /// </summary>
        /// <param name="id">部门Id</param>
        /// <returns>删除的记录数</returns>
        int DeleteDepartment(int id);

        /// <summary>
        /// 更新部门信息
        /// </summary>
        /// <param name="department">新部门信息</param>
        /// <returns>修改的记录数</returns>
        int UpdateDepartment(Department department);
    }
}