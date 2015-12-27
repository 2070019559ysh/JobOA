using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL
{
    /// <summary>
    /// 员工关联数据库接口
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// 通过Id查找员工信息
        /// </summary>
        /// <returns>员工信息</returns>
        Employee SearchEmployeeById(int id);
        
        /// <summary>
        /// 通过手机号码用户名查找员工信息
        /// </summary>
        /// <returns>员工信息</returns>
        Employee SearchEmployeeByUserName(string userName);

        /// <summary>
        /// 添加员工信息
        /// </summary>
        /// <param name="employee">员工信息</param>
        /// <returns>添加的记录数</returns>
        int AddEmployee(Employee employee);

        /// <summary>
        /// 删除员工信息
        /// </summary>
        /// <param name="id">员工Id</param>
        /// <returns>删除的员工记录数量</returns>
        int DeleteEmployee(int id);

        /// <summary>
        /// 更新员工信息
        /// </summary>
        /// <param name="employee">新员工信息</param>
        /// <returns>更新的员工记录数量</returns>
        int UpdateEmployee(Employee employee);
    }
}
