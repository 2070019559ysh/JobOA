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
    /// 子任务信息关联数据库测试类
    /// </summary>
    [TestFixture]
    public class SubTaskServiceTest
    {
        private SubTaskService _subTaskService = new SubTaskService();
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
                SubTask subTask = new SubTask()
                {
                    Name = "单元测试",
                    ArrangePersonId = 1,
                    CheckPersonId = 1,
                    CompleteTime = DateTime.Now,
                    CreateTime = DateTime.Now,
                    ExePersonId = 1,
                    IsSecrecy = false,
                    TaskId = 1,
                    StartTime = DateTime.Now
                };
                dbContext.SubTask.Add(subTask);
                dbContext.SaveChanges();
                _deleteId[0] = subTask.Id;
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
                        SubTask subTask = new SubTask() { Id = _deleteId[i] };
                        dbContext.SubTask.Attach(subTask);
                        dbContext.SubTask.Remove(subTask);
                    }
                }
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// 通过Id查找子任务信息测试
        /// </summary>
        [Test]
        public void SearchSubTaskByIdTest()
        {
            SubTask subTask = _subTaskService.SearchSubTaskById(_deleteId[0]);
            Assert.IsNotNull(subTask);
        }

        /// <summary>
        /// 通过任务名模糊查找子任务测试
        /// </summary>
        [Test]
        public void SearchSubTaskByNameTest()
        {
            List<SubTask> SubTaskList = _subTaskService.SearchSubTaskByName("测");
            Assert.IsTrue(SubTaskList.Count > 0);
        }

        /// <summary>
        /// 添加子任务信息测试
        /// </summary>
        [Test]
        public void AddSubTaskTest()
        {
            SubTask subTask = new SubTask()
            {
                Name = "添加单元测试",
                ArrangePersonId = 1,
                CheckPersonId = 1,
                CompleteTime = DateTime.Now,
                CreateTime = DateTime.Now,
                ExePersonId = 1,
                IsSecrecy = false,
                TaskId = 1,
                StartTime = DateTime.Now
            };
            int actual = _subTaskService.AddSubTask(subTask);
            _deleteId[1] = subTask.Id;//记录测试完成时要删除此记录
            Assert.AreEqual(1, actual);
        }

        /// <summary>
        /// 删除子任务信息测试
        /// </summary>
        [Test]
        public void DeleteSubTaskTest()
        {
            int actual = _subTaskService.DeleteSubTask(_deleteId[0]);
            _deleteId[0] = 0;//标志已经删除，测试完成时不要再重复删除此记录
            Assert.AreEqual(1, actual);
        }

        /// <summary>
        /// 更新子任务信息测试
        /// </summary>
        [Test]
        public void UpdateSubTaskTest()
        {
            SubTask SubTask = new SubTask()
            {
                Id = _deleteId[0],
                Name = "修改单元测试",
                ArrangePersonId = 1,
                CheckPersonId = 1,
                CompleteTime = DateTime.Now,
                CreateTime = DateTime.Now,
                ExePersonId = 1,
                IsSecrecy = false,
                TaskId = 1,
                StartTime = DateTime.Now
            };
            int actual = _subTaskService.UpdateSubTask(SubTask);
            Assert.AreEqual(1, actual);
        }
    }
}
