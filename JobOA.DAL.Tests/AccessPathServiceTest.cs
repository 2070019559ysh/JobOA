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
    /// 可访问路径关联数据库测试类
    /// </summary>
    [TestFixture]
    public class AccessPathServiceTest
    {
        private AccessPathService _accessPathService=new AccessPathService();
        private int[] _deleteId;//保存测试结束时要删除的记录Id

        /// <summary>
        /// 执行每个测试方法前，初始化数据，添加测试记录
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _deleteId = new int[] { 0, 0 };
            //添加用于查找、删除或修改的记录
            using(OaModel dbContext=new OaModel())
            {
                AccessPath accessPath=new AccessPath(){ HttpMethod="GET", Path="~/JobOA/Test"};
                dbContext.AccessPath.Add(accessPath);
                dbContext.SaveChanges();
                _deleteId[0] = accessPath.AccessPathId;
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
                        AccessPath accessPath = new AccessPath() { AccessPathId= _deleteId[i] };
                        dbContext.AccessPath.Attach(accessPath);
                        dbContext.AccessPath.Remove(accessPath);
                    }
                }
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// 通过Id查找可访问路径信息测试
        /// </summary>
        [Test]
        public void SearchAccessPathByIdTest()
        {
            AccessPath accessPath = _accessPathService.SearchAccessPathById(_deleteId[0]);
            Assert.IsNotNull(accessPath);
        }

        /// <summary>
        /// 添加可访问路径信息测试
        /// </summary>
        [Test]
        public void AddAccessPathTest()
        {
            AccessPath accessPath = new AccessPath() { HttpMethod="GET",Path="~/JobOA/UnitTest"};
            int actual=_accessPathService.AddAccessPath(accessPath);
            _deleteId[1] = accessPath.AccessPathId;//记录测试完成时要删除此记录
            Assert.AreEqual(1, actual);
        }

        /// <summary>
        /// 删除可访问路径信息测试
        /// </summary>
        [Test]
        public void DeleteAccessPathTest()
        {
            int actual = _accessPathService.DeleteAccessPath(_deleteId[0]);
            _deleteId[0] = 0;//标志已经删除，测试完成时不要再重复删除此记录
            Assert.AreEqual(1, actual);
        }

        /// <summary>
        /// 更新可访问路径信息测试
        /// </summary>
        [Test]
        public void UpdateAccessPathTest()
        {
            AccessPath accessPath = new AccessPath() { AccessPathId = _deleteId[0], HttpMethod="POST",Path="~/JobOA/UnitTest" };
            int actual = _accessPathService.UpdateAccessPath(accessPath);
            Assert.AreEqual(1, actual);
        }
    }
}
