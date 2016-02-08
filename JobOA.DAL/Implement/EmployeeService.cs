using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL.Implement
{
    /// <summary>
    /// 员工关联数据库类
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        /// <summary>
        /// 通过手机号码Id查找员工信息
        /// </summary>
        /// <returns>员工信息</returns>
        public Employee SearchEmployeeById(int id)
        {
            using (OaModel dbContext = new OaModel())
            {
                var employee = (from e in dbContext.Employee
                               where e.Id == id
                               select e).SingleOrDefault();
                return employee;
            }
        }

        /// <summary>
        /// 通过手机号码用户名查找员工信息,一个员工的手机号码只能注册一个账号
        /// </summary>
        /// <returns>员工信息</returns>
        public Employee SearchEmployeeByUserName(string userName)
        {
            using (OaModel dbContext = new OaModel())
            {
                dbContext.Configuration.ProxyCreationEnabled = false;
                //一个员工的手机号码只能注册一个账号，以此查找唯一员工信息
                var employee = from e in dbContext.Employee
                               where e.UserName.Equals(userName)
                               select e;
                return employee.FirstOrDefault();
            }
        }

        /// <summary>
        /// 通过部门id查找部门的所有员工信息
        /// </summary>
        /// <param name="departmentId">部门id</param>
        /// <returns>员工信息集合</returns>
        public List<Employee> SearchEmployeeByDeparementId(int departmentId)
        {
            using (OaModel dbContext = new OaModel())
            {
                dbContext.Configuration.ProxyCreationEnabled = false;
                //一个员工的手机号码只能注册一个账号，以此查找唯一员工信息
                var employee = from e in dbContext.Employee
                               where e.DepartmentId==departmentId
                               select e;
                return employee.ToList();
            }
        }

        /// <summary>
        /// 添加员工信息
        /// </summary>
        /// <param name="employee">员工信息</param>
        /// <returns>添加的记录数</returns>
        public int AddEmployee(Employee employee)
        {
            using (OaModel dbContext = new OaModel())
            {
                dbContext.Employee.Add(employee);
                dbContext.Configuration.ValidateOnSaveEnabled = false;
                int row=dbContext.SaveChanges();
                return row;
            }
        }

        /// <summary>
        /// 删除员工信息
        /// </summary>
        /// <param name="id">员工Id</param>
        /// <returns>删除的记录数</returns>
        public int DeleteEmployee(int id)
        {
            using (OaModel dbContext = new OaModel())
            {
                Employee employee=new Employee(){Id=id};
                dbContext.Employee.Attach(employee);
                dbContext.Employee.Remove(employee);
                dbContext.Configuration.ValidateOnSaveEnabled = false;
                int row = dbContext.SaveChanges();
                return row;
            }
        }

        /// <summary>
        /// 更新员工信息
        /// </summary>
        /// <param name="employee">新员工信息</param>
        /// <returns>更新的记录数</returns>
        public int UpdateEmployee(Employee employee)
        {
            using(OaModel dbContext=new OaModel())
            {
                var oldEmployee=dbContext.Employee.Find(employee.Id);
                if (oldEmployee != null)
                {
                    oldEmployee.DepartmentId = employee.DepartmentId;
                    oldEmployee.Email = employee.Email;
                    oldEmployee.HeadPicture = employee.HeadPicture;
                    oldEmployee.Introduction = employee.Introduction;
                    oldEmployee.IsEnabled = employee.IsEnabled;
                    oldEmployee.LastLoginTime = employee.LastLoginTime;
                    oldEmployee.OnlineState = employee.OnlineState;
                    oldEmployee.Password = employee.Password;
                    oldEmployee.RealName = employee.RealName;
                    oldEmployee.RoleIds = employee.RoleIds;
                    oldEmployee.UserName = employee.UserName;
                    dbContext.Configuration.ValidateOnSaveEnabled = false;
                    return dbContext.SaveChanges();
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
