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
    /// OA系统异常信息关联数据库测试类
    /// </summary>
    [TestFixture]
    public class OAExceptionTest
    {
        private OAExceptionService _oaExceptionService=new OAExceptionService();
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
                OAException oaException=new OAException(){ExTime=DateTime.Now,ExMessage="单元测试 发生异常！"};
                dbContext.OAException.Add(oaException);
                dbContext.SaveChanges();
                _deleteId[0] = oaException.Id;
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
                        OAException oaException = new OAException() { Id = _deleteId[i] };
                        dbContext.OAException.Attach(oaException);
                        dbContext.OAException.Remove(oaException);
                    }
                }
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// 通过Id查找OA系统异常信息测试
        /// </summary>
        [Test]
        public void SearchOAExceptionByIdTest()
        {
            OAException oaException = _oaExceptionService.SearchOAExceptionById(_deleteId[0]);
            Assert.IsNotNull(oaException);
        }

        /// <summary>
        /// 添加OA系统异常信息测试
        /// </summary>
        [Test]
        public void AddOAExceptionTest()
        {
            OAException oaException = new OAException() { ExTime = DateTime.Now, ExMessage = "添加 单元测试异常！" };
            int actual=_oaExceptionService.AddOAException(oaException);
            _deleteId[1] = oaException.Id;//记录测试完成时要删除此记录
            Assert.AreEqual(1, actual);
        }

        /// <summary>
        /// 删除OA系统异常信息测试
        /// </summary>
        [Test]
        public void DeleteOAExceptionTest()
        {
            int actual = _oaExceptionService.DeleteOAException(_deleteId[0]);
            _deleteId[0] = 0;//标志已经删除，测试完成时不要再重复删除此记录
            Assert.AreEqual(1, actual);
        }

        /// <summary>
        /// 更新OA系统异常信息测试
        /// </summary>
        [Test]
        public void UpdateOAExceptionTest()
        {
            OAException oaException = new OAException() { Id = _deleteId[0], ExTime = DateTime.Now, ExMessage = "修改 单元测试异常！" };
            int actual = _oaExceptionService.UpdateOAException(oaException);
            Assert.AreEqual(1, actual);
        }
    }
}
