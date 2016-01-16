using JobOA.Model;
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
        /// <returns>项目信息</returns>
        public Project SearchProjectById(int id)
        {
            using (OaModel dbContext = new OaModel())
            {
                var project = from p in dbContext.Project
                           where p.Id == id
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