using JobOA.Common;
using JobOA.DAL;
using JobOA.Model;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;

namespace JobOA.BLL.Implement
{
    /// <summary>
    /// 员工信息业务逻辑类
    /// </summary>
    public class EmployeeManager: IEmployeeManager
    {
        /// <summary>
        /// 依赖注入员工关联数据库服务类
        /// </summary>
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        
        /// <summary>
        /// 异常处理对象
        /// </summary>
        private readonly ExceptionLog _exceptionLog = new ExceptionLog();

        /// <summary>
        /// 通过Id查找员工信息
        /// </summary>
        /// <returns>员工信息</returns>
        public Employee SearchEmployeeById(int id)
        {
            Employee employee=null;
            try
            {
                employee = EmployeeService.SearchEmployeeById(id);
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " 发生异常：" + ex.Message);
            }
            return employee;
        }

        /// <summary>
        /// 检查员工登录是否成功
        /// </summary>
        /// <param name="userName">用户名/手机号</param>
        /// <param name="password">密码</param>
        /// <returns>登录成功的员工信息</returns>
        public Employee CheckEmployeeLogin(string userName,string password)
        {
            Employee employeeLogin =null;//登录成功的员工信息
            try
            {
                Employee employee = EmployeeService.SearchEmployeeByUserName(userName);
                password = MD5Encrypt.ConvertMD5String(password);//密码加密
                if (employee != null && employee.Password.Equals(password))
                {
                    employeeLogin = employee;
                }
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " 发生异常：" + ex.Message);
            }
            return employeeLogin;
        }

        /// <summary>
        /// 通过手机号码用户名查找员工信息,一个员工的手机号码只能注册一个账号
        /// </summary>
        /// <returns>员工信息</returns>
        public Employee SearchEmployeeByUserName(string userName)
        {
            Employee employee=null;
            try
            {
                employee=EmployeeService.SearchEmployeeByUserName(userName);
                if (String.IsNullOrEmpty(employee.HeadPicture))
                {
                    //没有头像，使用默认头像
                    employee.HeadPicture = "/Content/images/oaui/default.jpg";
                }
                else
                {
                    employee.HeadPicture = "/Content/images/userImg/" + employee.HeadPicture;
                }
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " 发生异常：" + ex.Message);
            }
            return employee;
        }

        /// <summary>
        /// 添加员工信息
        /// </summary>
        /// <param name="employee">员工信息</param>
        /// <returns>是否添加成功</returns>
        public bool AddEmployee(Employee employee)
        {
            bool success = false;//是否成功执行
            try
            {
                employee.Password=MD5Encrypt.ConvertMD5String(employee.Password);//密码加密
                int row=EmployeeService.AddEmployee(employee);
                if (row > 0)
                {
                    success = true;
                }
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now+" 发生异常："+ex.Message);
            }
            return success;
        }

        /// <summary>
        /// 删除员工信息
        /// </summary>
        /// <param name="id">员工Id</param>
        /// <returns>是否删除成功</returns>
        public bool DeleteEmployee(int id)
        {
            bool success = false;//是否成功执行
            try
            {
                int row = EmployeeService.DeleteEmployee(id);
                if (row > 0)
                {
                    success = true;
                }
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " 发生异常：" + ex.Message);
            }
            return success;
        }

        /// <summary>
        /// 更新员工信息
        /// </summary>
        /// <param name="employee">新员工信息</param>
        /// <returns>是否更新成功</returns>
        public bool UpdateEmployee(Employee employee)
        {
            bool success = false;//是否成功执行
            try
            {
                int row = EmployeeService.UpdateEmployee(employee);
                if (row > 0)
                {
                    success = true;
                }
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " 发生异常：" + ex.Message);
            }
            return success;
        }
    }
}
