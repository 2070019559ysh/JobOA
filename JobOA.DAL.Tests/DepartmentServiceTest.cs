using JobOA.DAL.Implement;
using JobOA.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL.Tests
{
    /// <summary>
    /// 部门信息关联数据库测试类
    /// </summary>
    [TestFixture]
    public class DepartmentServiceTest
    {
        private DepartmentService _departmentService = new DepartmentService();
        private int[] _deleteId;//保存测试结束时要删除的记录Id

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
                Department department = new Department() { Name= "软件开发部" };
                dbContext.Department.Add(department);
                dbContext.SaveChanges();
                _deleteId[0] = department.Id;
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
                        Department department = new Department() { Id = _deleteId[i] };
                        dbContext.Department.Attach(department);
                        dbContext.Department.Remove(department);
                    }
                }
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// 通过Id查找部门信息测试
        /// </summary>
        [Test]
        public void SearchDepartmentByIdTest()
        {
            Department department = _departmentService.SearchDepartmentById(_deleteId[0]);
            Assert.IsNotNull(department);
        }

        /// <summary>
        /// 添加部门信息测试
        /// </summary>
        [Test]
        public void AddDepartmentTest()
        {
            Department department = new Department() { Name= "添加单元测试" };
            int actual = _departmentService.AddDepartment(department);
            _deleteId[1] = department.Id;//记录测试完成时要删除此记录
            Assert.AreEqual(1, actual);
        }

        /// <summary>
        /// 删除部门信息测试
        /// </summary>
        [Test]
        public void DeleteDepartmentTest()
        {
            int actual = _departmentService.DeleteDepartment(_deleteId[0]);
            _deleteId[0] = 0;//标志已经删除，测试完成时不要再重复删除此记录
            Assert.AreEqual(1, actual);
        }

        /// <summary>
        /// 更新部门信息测试
        /// </summary>
        [Test]
        public void UpdateDepartmentTest()
        {
            Department department = new Department()
            {
                Id=_deleteId[0],
                Name = "修改单元测试"
            };
            int actual = _departmentService.UpdateDepartment(department);
            Assert.AreEqual(1, actual);
        }
    }
}
