using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using JobOA.DAL.Implement;
using JobOA.Model;

namespace JobOA.DAL.Tests
{
    /// <summary>
    /// 员工关联数据库进行测试类
    /// </summary>
    [TestFixture]
    public class EmployeeServiceTest
    {
        EmployeeService _employeeService = new EmployeeService();
        int[] _deleteId;//保存测试结束时要删除的记录Id

        /// <summary>
        /// 执行每个测试方法前，初始化数据，添加测试记录
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _deleteId = new int[] { 0, 0 };
            //添加用于查找、删除或修改的记录
            using (OaModel dbContext = new OaModel())
            {
                dbContext.Configuration.ValidateOnSaveEnabled = false;
                Employee employee = new Employee() { 
                    UserName = "单元测试",
                    IsEnabled = false,
                    DepartmentId = 1 ,
                    HeadPicture=null,
                    Password="123456",
                    RealName="单元测试",
                    RoleIds=null
                };
                dbContext.Employee.Add(employee);
                dbContext.SaveChanges();
                _deleteId[0] = employee.Id;
            }
        }

        /// <summary>
        /// 执行每个测试方法后，释放占用的资源，删除测试中添加的记录
        /// </summary>
        [TearDown]
        public void Teardown()
        {
            //删除测试中添加的记录
            using (OaModel dbContext = new OaModel())
            {
                for (int i = 0; i < _deleteId.Length; i++)
                {
                    if (_deleteId[i] != 0)
                    {
                        Employee employee = new Employee() { Id = _deleteId[i] };
                        dbContext.Employee.Attach(employee);
                        dbContext.Employee.Remove(employee);
                    }
                }
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// 通过Id查找员工信息测试
        /// </summary>
        [Test]
        public void SearchEmployeeByIdTest()
        {
            Employee employee = _employeeService.SearchEmployeeById(_deleteId[0]);
            Assert.IsNotNull(employee);
        }

        /// <summary>
        /// 添加员工信息测试
        /// </summary>
        [Test]
        public void AddEmployeeTest()
        {
            Employee employee = new Employee() {
                UserName = "AddTest",
                IsEnabled = false,
                DepartmentId = 1,
                HeadPicture = null,
                Password = "451236",
                RealName = "添加单元测试",
                RoleIds = null
            };
            int actual = _employeeService.AddEmployee(employee);
            _deleteId[1] = employee.Id;//记录测试完成时要删除此记录
            Assert.AreEqual(1, actual);
        }

        /// <summary>
        /// 删除员工信息测试
        /// </summary>
        [Test]
        public void DeleteEmployeeTest()
        {
            int actual = _employeeService.DeleteEmployee(_deleteId[0]);
            _deleteId[0] = 0;//标志已经删除，测试完成时不要再重复删除此记录
            Assert.AreEqual(1, actual);
        }

        /// <summary>
        /// 更新员工信息测试
        /// </summary>
        [Test]
        public void UpdateEmployeeTest()
        {
            Employee Employee = new Employee()
            {
                Id = _deleteId[0],
                UserName = "UpdateTest",
                IsEnabled = false,
                DepartmentId = 1,
                HeadPicture = null,
                Password = "456789",
                RealName = "修改单元测试",
                RoleIds = null
            };
            int actual = _employeeService.UpdateEmployee(Employee);
            Assert.AreEqual(1, actual);
        }
    }
}
