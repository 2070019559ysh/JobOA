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
    /// 权限信息关联数据库测试类
    /// </summary>
    [TestFixture]
    public class PermissionServiceTest
    {
        private PermissionService _permissionService = new PermissionService();
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
                Permission permission = new Permission() { AccessPathId=null,Description="单元测试" };
                dbContext.Permission.Add(permission);
                dbContext.SaveChanges();
                _deleteId[0] = permission.Id;
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
                        Permission permission = new Permission() { Id = _deleteId[i] };
                        dbContext.Permission.Attach(permission);
                        dbContext.Permission.Remove(permission);
                    }
                }
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// 通过Id查找权限信息测试
        /// </summary>
        [Test]
        public void SearchPermissionByIdTest()
        {
            Permission permission = _permissionService.SearchPermissionById(_deleteId[0]);
            Assert.IsNotNull(permission);
        }

        /// <summary>
        /// 添加权限信息测试
        /// </summary>
        [Test]
        public void AddPermissionTest()
        {
            Permission permission = new Permission() { AccessPathId = 1, Description = "添加单元测试" };
            int actual = _permissionService.AddPermission(permission);
            _deleteId[1] = permission.Id;//记录测试完成时要删除此记录
            Assert.AreEqual(1, actual);
        }

        /// <summary>
        /// 删除权限信息测试
        /// </summary>
        [Test]
        public void DeletePermissionTest()
        {
            int actual = _permissionService.DeletePermission(_deleteId[0]);
            _deleteId[0] = 0;//标志已经删除，测试完成时不要再重复删除此记录
            Assert.AreEqual(1, actual);
        }

        /// <summary>
        /// 更新权限信息测试
        /// </summary>
        [Test]
        public void UpdatePermissionTest()
        {
            Permission Permission = new Permission()
            {
                Id=_deleteId[0],
                AccessPathId = null,
                Description = "修改单元测试"
            };
            int actual = _permissionService.UpdatePermission(Permission);
            Assert.AreEqual(1, actual);
        }
    }
}
