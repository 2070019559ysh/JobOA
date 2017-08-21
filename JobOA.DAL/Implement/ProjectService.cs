using JobOA.Model;
using JobOA.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL.Implement
{
    /// <summary>
    /// 项目信息关联数据库类
    /// </summary>
    public class ProjectService:IProjectService
    {
        /// <summary>
        /// 通过Id查找项目信息
        /// </summary>
        /// <param name="id">项目Id</param>
        /// <returns>项目信息</returns>
        public Project SearchProjectById(int id)
        {
            using (OaModel dbContext = new OaModel())
            {
                dbContext.Configuration.ProxyCreationEnabled = false;
                var project = from p in dbContext.Project
                           where p.Id == id
                           select p;
                return project.SingleOrDefault();
            }
        }

        /// <summary>
        /// 通过主任务Id查找项目信息
        /// </summary>
        /// <param name="taskId">主任务Id</param>
        /// <returns>项目信息</returns>
        public Project SearchProjectByTaskId(int taskId)
        {
            using (OaModel dbContext = new OaModel())
            {
                dbContext.Configuration.ProxyCreationEnabled = false;
                var project = from p in dbContext.Project
                              join task in dbContext.MajorTask
                              on p.Id equals task.ProjectId
                              where task.Id==taskId
                              select p;
                return project.SingleOrDefault();
            }
        }

        /// <summary>
        /// 通过子任务Id查找项目信息
        /// </summary>
        /// <param name="subTaskId">子任务Id</param>
        /// <returns>项目信息</returns>
        public Project SearchProjectBySubTaskId(int subTaskId)
        {
            using (OaModel dbContext = new OaModel())
            {
                dbContext.Configuration.ProxyCreationEnabled = false;
                var project = from p in dbContext.Project
                              join task in dbContext.MajorTask
                              on p.Id equals task.ProjectId
                              join subTask in dbContext.SubTask
                              on task.Id equals subTask.TaskId
                              where subTask.Id==subTaskId
                              select p;
                return project.SingleOrDefault();
            }
        }

        /// <summary>
        /// 查找所有项目
        /// </summary>
        /// <returns>所有项目的集合</returns>
        public List<Project> SearchAllProject()
        {
            using (OaModel dbContext = new OaModel())
            {
                var project = from p in dbContext.Project
                              select p;
                return project.ToList();
            }
        }

        /// <summary>
        /// 查找所有项目,分页条件查询，pager.Remarks必须是项目名
        /// </summary>
        /// <returns>分页条件查询到的项目集合</returns>
        public List<Project> SearchAllProject(Pager pager)
        {
            using (OaModel dbContext = new OaModel())
            {
                var project = from p in dbContext.Project
                              where p.Name.Contains(pager.Remarks)
                              orderby p.Id ascending
                              select p;
                IQueryable<Project> projects=project.Skip((pager.PageIndex - 1) * pager.PageSize).Take(pager.PageSize);
                return projects.ToList();
            }
        }

        /// <summary>
        /// 模糊查找指定项目名的项目记录总数
        /// </summary>
        /// <returns>项目记录总数</returns>
        public int AllProjectCount(string projectName)
        {
            using (OaModel dbContext = new OaModel())
            {
                var project = from p in dbContext.Project
                              where p.Name.Contains(projectName)
                              select p;
                return project.Count();
            }
        }

        /// <summary>
        /// 添加项目信息
        /// </summary>
        /// <param name="project">项目信息</param>
        /// <returns>添加的记录数</returns>
        public int AddProject(Project project)
        {
            using (OaModel dbContext = new OaModel())
            {
                dbContext.Project.Add(project);
                int rows = dbContext.SaveChanges();
                return rows;
            }
        }

        /// <summary>
        /// 删除项目信息
        /// </summary>
        /// <param name="id">项目Id</param>
        /// <returns>删除的记录数</returns>
        public int DeleteProject(int id)
        {
            using (OaModel dbContext = new OaModel())
            {
                Project project = new Project() { Id = id };
                dbContext.Project.Attach(project);
                dbContext.Project.Remove(project);
                int rows = dbContext.SaveChanges();
                return rows;
            }
        }

        /// <summary>
        /// 更新项目信息
        /// </summary>
        /// <param name="project">新项目信息</param>
        /// <returns>修改的记录数</returns>
        public int UpdateProject(Project project)
        {
            using (OaModel dbContext = new OaModel())
            {
                var oldProject = dbContext.Project.Find(project.Id);
                if (oldProject != null)
                {
                    oldProject.Name = project.Name;
                    oldProject.IsSecrecy = project.IsSecrecy;
                    oldProject.State = project.State;
                    oldProject.Description = project.Description;
                    int rows = dbContext.SaveChanges();
                    return rows;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}