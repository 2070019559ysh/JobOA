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
    /// 角色信息关联数据库测试类
    /// </summary>
    [TestFixture]
    public class RoleServiceTest
    {
        private RoleService _roleService = new RoleService();
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
                Role role = new Role() { Name = "单元测试",IsEnabled=false,PermissionIds="1,2" };
                dbContext.Role.Add(role);
                dbContext.SaveChanges();
                _deleteId[0] = role.Id;
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
                        Role role = new Role() { Id = _deleteId[i] };
                        dbContext.Role.Attach(role);
                        dbContext.Role.Remove(role);
                    }
                }
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// 通过Id查找角色信息测试
        /// </summary>
        [Test]
        public void SearchRoleByIdTest()
        {
            Role role = _roleService.SearchRoleById(_deleteId[0]);
            Assert.IsNotNull(role);
        }

        /// <summary>
        /// 添加角色信息测试
        /// </summary>
        [Test]
        public void AddRoleTest()
        {
            Role role = new Role() { Name = "添加单元测试",IsEnabled=false,PermissionIds="2,3" };
            int actual = _roleService.AddRole(role);
            _deleteId[1] = role.Id;//记录测试完成时要删除此记录
            Assert.AreEqual(1, actual);
        }

        /// <summary>
        /// 删除角色信息测试
        /// </summary>
        [Test]
        public void DeleteRoleTest()
        {
            int actual = _roleService.DeleteRole(_deleteId[0]);
            _deleteId[0] = 0;//标志已经删除，测试完成时不要再重复删除此记录
            Assert.AreEqual(1, actual);
        }

        /// <summary>
        /// 更新角色信息测试
        /// </summary>
        [Test]
        public void UpdateRoleTest()
        {
            Role role = new Role()
            {
                Id = _deleteId[0],
                Name = "修改单元测试",
                IsEnabled=true,
                PermissionIds="3,4"
            };
            int actual = _roleService.UpdateRole(role);
            Assert.AreEqual(1, actual);
        }
    }
}
