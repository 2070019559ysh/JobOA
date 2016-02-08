using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.BLL
{
    /// <summary>
    /// 员工信息业务逻辑接口
    /// </summary>
    public interface IEmployeeManager
    {
        /// <summary>
        /// 通过Id查找员工信息
        /// </summary>
        /// <returns>员工信息</returns>
        Employee SearchEmployeeById(int id);

        /// <summary>
        /// 检查员工登录是否成功
        /// </summary>
        /// <param name="userName">用户名/手机号</param>
        /// <param name="password">密码</param>
        /// <returns>登录成功的员工信息</returns>
        Employee CheckEmployeeLogin(string userName, string password);
        
        /// <summary>
        /// 通过手机号码用户名查找员工信息
        /// </summary>
        /// <returns>员工信息</returns>
        Employee SearchEmployeeByUserName(string userName);

        /// <summary>
        /// 通过部门id查找部门的所有员工信息
        /// </summary>
        /// <param name="departmentId">部门id</param>
        /// <returns>员工信息集合</returns>
        List<Employee> SearchEmployeeByDeparementId(int departmentId);

        /// <summary>
        /// 添加员工信息
        /// </summary>
        /// <param name="employee">员工信息</param>
        /// <returns>是否添加成功</returns>
        bool AddEmployee(Employee employee);

        /// <summary>
        /// 删除员工信息
        /// </summary>
        /// <param name="id">员工Id</param>
        /// <returns>是否删除成功</returns>
        bool DeleteEmployee(int id);

        /// <summary>
        /// 更新员工信息
        /// </summary>
        /// <param name="employee">新员工信息</param>
        /// <returns>是否更新成功</returns>
        bool UpdateEmployee(Employee employee);
    }
}
