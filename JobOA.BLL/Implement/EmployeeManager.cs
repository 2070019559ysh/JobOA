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
using System.IO;

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
        /// 查找所有员工信息
        /// </summary>
        /// <returns>所有员工信息</returns>
        public List<Employee> SearchAllEmployee()
        {
            List<Employee> employeeList=EmployeeService.SearchAllEmployee();
            foreach (var e in employeeList)
            {
                e.HeadPicture = GetHeadPicture(e.HeadPicture);
            }
            return employeeList;
        }

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
                employee.HeadPicture=GetHeadPicture(employee.HeadPicture);
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " 发生异常：" + ex.Message);
            }
            return employee;
        }

        /// <summary>
        /// 通过部门id查找部门的所有员工信息
        /// </summary>
        /// <param name="departmentId">部门id</param>
        /// <returns>员工信息集合</returns>
        public List<Employee> SearchEmployeeByDeparementId(int departmentId)
        {
            List<Employee> employeeList = EmployeeService.SearchEmployeeByDeparementId(departmentId);
            foreach (var e in employeeList)
            {
                e.HeadPicture=GetHeadPicture(e.HeadPicture);
            }
            return employeeList;
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
                Employee employee = SearchEmployeeByUserName(userName);
                password = MD5Encrypt.ConvertMD5String(password);//密码加密
                //密码正确并被HR审核通过确认可登录
                if (employee != null && employee.Password.Equals(password)&&employee.IsEnabled)
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
                employee.HeadPicture=GetHeadPicture(employee.HeadPicture);
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
                string regionImg = employee.HeadPicture;
                employee.HeadPicture = ResetHeadPicture(employee.HeadPicture);
                int row = EmployeeService.UpdateEmployee(employee);
                employee.HeadPicture = regionImg;
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
        /// 获取多个图片名连接的字符串,图片名包含目录
        /// </summary>
        /// <param name="headImg">多个图片名连接的字符串</param>
        /// <returns>多个图片名（包含目录字符串）连接的字符串</returns>
        private string GetHeadPicture(string headImg)
        {
            if (String.IsNullOrEmpty(headImg))
            {
                //没有头像，使用默认头像
                headImg = "/Content/images/oaui/default.jpg";
            }
            else
            {
                string[] headImgs = headImg.Split(',');
                for (int i = 0; i < headImgs.Length; i++)
                {
                    headImgs[i]="/Content/images/userImg/" + headImgs[i];
                }
                headImg = String.Join(",",headImgs);
            }
            return headImg;
        }
        /// <summary>
        /// 获取去掉图片名中的目录字符
        /// </summary>
        /// <param name="headImg">多个图片名（包含目录字符串）连接的字符串</param>
        /// <returns>去掉图片名中的目录字符</returns>
        private string ResetHeadPicture(string headImg)
        {
            if (!String.IsNullOrEmpty(headImg))
            {
                string[] headImgs = headImg.Split(',');
                if (headImgs.Length == 1 && headImgs[0].Equals("/Content/images/oaui/default.jpg"))
                {
                    //如果使用默认头像，则清空数据
                    headImg = null;
                }
                else
                {
                    for (int i = 0; i < headImgs.Length; i++)
                    {
                        headImgs[i] = Path.GetFileName(headImgs[i]);
                    }
                    headImg = String.Join(",", headImgs);
                }
            }
            return headImg;
        }

        /// <summary>
        /// 添加一个用户头像
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="headImg">头像名</param>
        /// <returns>新的用户信息</returns>
        public Employee AddHeadPicture(string userName,string headImg)
        {
            Employee employee = EmployeeService.SearchEmployeeByUserName(userName);
            if (String.IsNullOrEmpty(employee.HeadPicture))
            {
                employee.HeadPicture = headImg;
            }
            else
            {
                employee.HeadPicture += "," + headImg;
            }
            UpdateEmployee(employee);
            employee.HeadPicture = GetHeadPicture(employee.HeadPicture);
            return employee;
        }

        /// <summary>
        /// 移除用户的指定头像
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="root">项目根目录</param>
        /// <param name="headImg">头像名</param>
        /// <returns>新的用户信息</returns>
        public Employee RemoveHeadPicture(string userName,string root, string headImg)
        {
            Employee employee=null;
            try
            {
                employee = EmployeeService.SearchEmployeeByUserName(userName);
                if (!String.IsNullOrEmpty(employee.HeadPicture))
                {
                    string[] headPictures = employee.HeadPicture.Split(',');
                    //strBuilder重新保存要移除图片名外的其他图片名，再修改用户头像列信息
                    StringBuilder strBuilder = new StringBuilder();
                    for (int i = 0; i < headPictures.Length; i++)
                    {
                        headImg = Path.GetFileName(headImg);
                        if (headPictures[i].Equals(headImg))
                        {
                            string fileName = root + "Content/images/userImg/" + headImg;
                            if (File.Exists(fileName))
                                File.Delete(fileName);
                            continue;
                        }
                        if (String.IsNullOrEmpty(strBuilder.ToString()))
                        {
                            strBuilder.Append(headPictures[i]);
                        }
                        else
                        {
                            strBuilder.Append("," + headPictures[i]);
                        }
                    }
                    employee.HeadPicture = strBuilder.ToString();
                }
                UpdateEmployee(employee);
                employee.HeadPicture = GetHeadPicture(employee.HeadPicture);
            }
            catch (Exception ex)
            {
                 _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " 发生异常：" + ex.Message);
            }
            return employee;
        }

        /// <summary>
        /// 设置用户使用的头像，第一个即用户正使用头像
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="headImg">头像名</param>
        /// <returns>新的用户信息</returns>
        public Employee SetHeadPicture(string userName,string headImg)
        {
            Employee employee = EmployeeService.SearchEmployeeByUserName(userName);
            if (!String.IsNullOrEmpty(employee.HeadPicture))
            {
                string[] headPictures = employee.HeadPicture.Split(',');
                for (int i = 0; i < headPictures.Length; i++)
                {
                    if (headPictures[i].Equals(headImg))
                    {
                        string temp;
                        temp=headPictures[0];
                        headPictures[0] = headPictures[i];
                        headPictures[i] = temp;
                        break;
                    }
                }
                employee.HeadPicture=String.Join(",", headPictures);
            }
            UpdateEmployee(employee);
            employee.HeadPicture=GetHeadPicture(employee.HeadPicture);
            return employee;
        }
    }
}
