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
    /// OA发信息通知的关联数据库测试类
    /// </summary>
    [TestFixture]
    public class OAMessageServiceTest
    {
        private OAMessageService _oaMessageService = new OAMessageService();
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
                OAMessage oaMessage = new OAMessage()
                {
                    ExtraMessage="我的单元测试任务已经完成",
                    TaskId=null
                };
                dbContext.OAMessage.Add(oaMessage);
                dbContext.SaveChanges();
                _deleteId[0] = oaMessage.Id;
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
                        OAMessage oaMessage = new OAMessage() { Id = _deleteId[i] };
                        dbContext.OAMessage.Attach(oaMessage);
                        dbContext.OAMessage.Remove(oaMessage);
                    }
                }
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// 通过Id查找OA通知的信息测试
        /// </summary>
        [Test]
        public void SearchOAMessageByIdTest()
        {
            OAMessage OAMessage = _oaMessageService.SearchOAMessageById(_deleteId[0]);
            Assert.IsNotNull(OAMessage);
        }

        /// <summary>
        /// 添加OA通知的信息测试
        /// </summary>
        [Test]
        public void AddOAMessageTest()
        {
            OAMessage oaMessage = new OAMessage()
            {
                ExtraMessage="单元测试",
                SubTaskId=2
            };
            int actual = _oaMessageService.AddOAMessage(oaMessage);
            _deleteId[1] = oaMessage.Id;//记录测试完成时要删除此记录
            Assert.AreEqual(1, actual);
        }

        /// <summary>
        /// 删除OA通知的信息测试
        /// </summary>
        [Test]
        public void DeleteOAMessageTest()
        {
            int actual = _oaMessageService.DeleteOAMessage(_deleteId[0]);
            _deleteId[0] = 0;//标志已经删除，测试完成时不要再重复删除此记录
            Assert.AreEqual(1, actual);
        }

        /// <summary>
        /// 更新OA通知的信息测试
        /// </summary>
        [Test]
        public void UpdateOAMessageTest()
        {
            OAMessage oaMessage = new OAMessage()
            {
                Id = _deleteId[0],
                ExtraMessage="完成NUnit Test",
                TaskId = 3
            };
            int actual = _oaMessageService.UpdateOAMessage(oaMessage);
            Assert.AreEqual(1, actual);
        }
    }
}
