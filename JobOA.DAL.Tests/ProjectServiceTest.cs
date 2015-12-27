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
    /// 项目信息关联数据库测试类
    /// </summary>
    [TestFixture]
    public class ProjectServiceTest
    {
        private ProjectService _projectService = new ProjectService();
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
                Project project = new Project() { 
                    Name = "单元测试",
                    Description="单元测试项目能测试方法是否能稳定运行，提高代码质量",
                    IsSecrecy=false,
                    State=(int)ProgressState.NotFinished 
                };
                dbContext.Project.Add(project);
                dbContext.SaveChanges();
                _deleteId[0] = project.Id;
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
                        Project project = new Project() { Id = _deleteId[i] };
                        dbContext.Project.Attach(project);
                        dbContext.Project.Remove(project);
                    }
                }
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// 通过Id查找项目信息测试
        /// </summary>
        [Test]
        public void SearchProjectByIdTest()
        {
            Project Project = _projectService.SearchProjectById(_deleteId[0]);
            Assert.IsNotNull(Project);
        }

        /// <summary>
        /// 添加项目信息测试
        /// </summary>
        [Test]
        public void AddProjectTest()
        {
            Project project = new Project() { 
                Name = "添加单元测试",
                Description = "单元测试项目能测试方法是否能稳定运行，提高代码质量",
                IsSecrecy = true,
                State = (int)ProgressState.Completed 
            };
            int actual = _projectService.AddProject(project);
            _deleteId[1] = project.Id;//记录测试完成时要删除此记录
            Assert.AreEqual(1, actual);
        }

        /// <summary>
        /// 删除项目信息测试
        /// </summary>
        [Test]
        public void DeleteProjectTest()
        {
            int actual = _projectService.DeleteProject(_deleteId[0]);
            _deleteId[0] = 0;//标志已经删除，测试完成时不要再重复删除此记录
            Assert.AreEqual(1, actual);
        }

        /// <summary>
        /// 更新项目信息测试
        /// </summary>
        [Test]
        public void UpdateProjectTest()
        {
            Project project = new Project()
            {
                Id = _deleteId[0],
                Name = "修改单元测试",
                Description = "单元测试项目能测试方法是否能稳定运行",
                IsSecrecy=true,
                State=(int)ProgressState.Acceptance
            };
            int actual = _projectService.UpdateProject(project);
            Assert.AreEqual(1, actual);
        }
    }
}
