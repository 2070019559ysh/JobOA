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
    /// 主任务关联数据库测试类
    /// </summary>
    [TestFixture]
    public class MajorTaskServiceTest
    {
        private MajorTaskService _majorTaskService = new MajorTaskService();
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
                dbContext.Configuration.ValidateOnSaveEnabled = false;
                MajorTask majorTask = new MajorTask() { 
                    Name = "单元测试" ,
                    ArrangePersonId=1,
                    CheckPersonId=1,
                    CompleteTime=DateTime.Now,
                    CreateTime=DateTime.Now,
                    ExePersonId=1,
                    IsNotice=true,
                    IsSecrecy=false,
                    ProjectId=1,
                    StartTime=DateTime.Now
                };
                dbContext.MajorTask.Add(majorTask);
                dbContext.SaveChanges();
                _deleteId[0] = majorTask.Id;
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
                        MajorTask majorTask = new MajorTask() { Id = _deleteId[i] };
                        dbContext.MajorTask.Attach(majorTask);
                        dbContext.MajorTask.Remove(majorTask);
                    }
                }
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// 通过Id查找主任务信息测试
        /// </summary>
        [Test]
        public void SearchMajorTaskByIdTest()
        {
            MajorTask MajorTask = _majorTaskService.SearchMajorTaskById(_deleteId[0]);
            Assert.IsNotNull(MajorTask);
        }

        /// <summary>
        /// 通过任务名模糊查找主任务测试
        /// </summary>
        [Test]
        public void SearchMajorTaskByNameTest()
        {
            List<MajorTask> majorTaskList = _majorTaskService.SearchMajorTaskByName("测");
            Assert.IsTrue(majorTaskList.Count > 0);
        }

        /// <summary>
        /// 添加主任务信息测试
        /// </summary>
        [Test]
        public void AddMajorTaskTest()
        {
            MajorTask majorTask = new MajorTask()
            {
                Name = "添加单元测试",
                ArrangePersonId = 1,
                CheckPersonId = 1,
                CompleteTime = DateTime.Now,
                CreateTime = DateTime.Now,
                ExePersonId = 1,
                IsNotice = true,
                IsSecrecy = false,
                ProjectId = 1,
                StartTime = DateTime.Now
            };
            int actual = _majorTaskService.AddMajorTask(majorTask);
            _deleteId[1] = majorTask.Id;//记录测试完成时要删除此记录
            Assert.AreEqual(1, actual);
        }

        /// <summary>
        /// 删除主任务信息测试
        /// </summary>
        [Test]
        public void DeleteMajorTaskTest()
        {
            int actual = _majorTaskService.DeleteMajorTask(_deleteId[0]);
            _deleteId[0] = 0;//标志已经删除，测试完成时不要再重复删除此记录
            Assert.AreEqual(1, actual);
        }

        /// <summary>
        /// 更新主任务信息测试
        /// </summary>
        [Test]
        public void UpdateMajorTaskTest()
        {
            MajorTask MajorTask = new MajorTask()
            {
                Id = _deleteId[0],
                Name = "修改单元测试",
                ArrangePersonId = 1,
                CheckPersonId = 1,
                CompleteTime = DateTime.Now,
                CreateTime = DateTime.Now,
                ExePersonId = 1,
                IsNotice = true,
                IsSecrecy = false,
                ProjectId = 1,
                StartTime = DateTime.Now
            };
            int actual = _majorTaskService.UpdateMajorTask(MajorTask);
            Assert.AreEqual(1, actual);
        }
    }
}
