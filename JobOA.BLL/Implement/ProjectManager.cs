using JobOA.Common;
using JobOA.DAL;
using JobOA.Model;
using JobOA.Model.ViewModel;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.BLL.Implement
{
    /// <summary>
    /// 项目信息关联数据库类
    /// </summary>
    public class ProjectManageer : IProjectManager
    {
        /// <summary>
        /// 依赖注入主任务关联数据库服务类
        /// </summary>
        [Inject]
        public IProjectService ProjectService { get; set; }

        /// <summary>
        /// 异常处理对象
        /// </summary>
        private readonly ExceptionLog _exceptionLog = new ExceptionLog();

        /// <summary>
        /// 通过Id查找项目信息
        /// </summary>
        /// <returns>项目信息</returns>
        public Project SearchProjectById(int id)
        {
            Project project = null;
            try
            {
                project = ProjectService.SearchProjectById(id);
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " 发生异常：" + ex.Message);
            }
            return project;
        }

        /// <summary>
        /// 查找所有项目
        /// </summary>
        /// <returns>所有项目的集合</returns>
        public List<Project> SearchAllProject()
        {
            List<Project> projectList = null;
            try
            {
                projectList = ProjectService.SearchAllProject();
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " 发生异常：" + ex.Message);
            }
            return projectList;
        }

        /// <summary>
        /// 根据分页条件及pager.Remarks的项目名模糊查询所有项目信息
        /// </summary>
        /// <param name="pager">分页对象</param>
        /// <returns>所有项目信息</returns>
        public List<Project> SearchProjectByPages(Pager pager)
        {
            if (pager.Remarks==null) pager.Remarks = String.Empty;
            pager.Total=ProjectService.AllProjectCount(pager.Remarks);
            List<Project> projectList=ProjectService.SearchAllProject(pager);
            return projectList;
        }

        /// <summary>
        /// 添加项目信息
        /// </summary>
        /// <param name="project">项目信息</param>
        /// <returns>添加记录是否成功</returns>
        public bool AddProject(Project project)
        {
            bool isSuccess = false;
            try
            {
                if (ProjectService.AddProject(project) > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " 发生异常：" + ex.Message);
            }
            return isSuccess;
        }

        /// <summary>
        /// 删除项目信息
        /// </summary>
        /// <param name="id">项目Id</param>
        /// <returns>删除记录是否成功</returns>
        public bool DeleteProject(int id)
        {
            bool isSuccess = false;
            try
            {
                if (ProjectService.DeleteProject(id) > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " 发生异常：" + ex.Message);
            }
            return isSuccess;
        }

        /// <summary>
        /// 更新项目信息
        /// </summary>
        /// <param name="project">新项目信息</param>
        /// <returns>修改的记录是否成功</returns>
        public bool UpdateProject(Project project)
        {
            bool isSuccess = false;
            try
            {
                if (ProjectService.UpdateProject(project) > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " 发生异常：" + ex.Message);
            }
            return isSuccess;
        }
    }
}