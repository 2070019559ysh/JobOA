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
    /// 任务每日更新关联数据库测试类
    /// </summary>
    [TestFixture]
    public class DailyUpdateServiceTest
    {
        private DailyUpdateService _dailyUpdateService = new DailyUpdateService();
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
                DailyUpdate dailyUpdate = new DailyUpdate() { 
                    Time=DateTime.Now,
                    WorkContent="单元测试",
                    ExtraTask="单元测试",
                    SpendTime=20,
                    SubTaskId=1
                };
                dbContext.DailyUpdate.Add(dailyUpdate);
                dbContext.SaveChanges();
                _deleteId[0] = dailyUpdate.Id;
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
                        DailyUpdate dailyUpdate = new DailyUpdate() { Id = _deleteId[i] };
                        dbContext.DailyUpdate.Attach(dailyUpdate);
                        dbContext.DailyUpdate.Remove(dailyUpdate);
                    }
                }
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// 通过Id查找每日更新信息测试
        /// </summary>
        [Test]
        public void SearchDailyUpdateByIdTest()
        {
            DailyUpdate DailyUpdate = _dailyUpdateService.SearchDailyUpdateById(_deleteId[0]);
            Assert.IsNotNull(DailyUpdate);
        }

        /// <summary>
        /// 添加每日更新信息测试
        /// </summary>
        [Test]
        public void AddDailyUpdateTest()
        {
            DailyUpdate dailyUpdate = new DailyUpdate()
            {
                Time = DateTime.Now,
                WorkContent = "单元测试",
                SubTaskId = 1
            };
            int actual = _dailyUpdateService.AddDailyUpdate(dailyUpdate);
            _deleteId[1] = dailyUpdate.Id;//记录测试完成时要删除此记录
            Assert.AreEqual(1, actual);
        }

        /// <summary>
        /// 删除每日更新信息测试
        /// </summary>
        [Test]
        public void DeleteDailyUpdateTest()
        {
            int actual = _dailyUpdateService.DeleteDailyUpdate(_deleteId[0]);
            _deleteId[0] = 0;//标志已经删除，测试完成时不要再重复删除此记录
            Assert.AreEqual(1, actual);
        }

        /// <summary>
        /// 更新每日更新信息测试
        /// </summary>
        [Test]
        public void UpdateDailyUpdateTest()
        {
            DailyUpdate dailyUpdate = new DailyUpdate()
            {
                Id = _deleteId[0],
                Time = DateTime.Now,
                WorkContent = "单元测试",
                ExtraTask = "单元测试",
                SpendTime = 20,
                SubTaskId = 1
            };
            int actual = _dailyUpdateService.UpdateDailyUpdate(dailyUpdate);
            Assert.AreEqual(1, actual);
        }
    }
}
