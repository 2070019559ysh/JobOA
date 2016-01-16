using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL.Implement
{
    /// <summary>
    /// ��Ŀ��Ϣ�������ݿ���
    /// </summary>
    public class ProjectService:IProjectService
    {
        /// <summary>
        /// ͨ��Id������Ŀ��Ϣ
        /// </summary>
        /// <returns>��Ŀ��Ϣ</returns>
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
        /// ����������Ŀ
        /// </summary>
        /// <returns>������Ŀ�ļ���</returns>
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
        /// �����Ŀ��Ϣ
        /// </summary>
        /// <param name="project">��Ŀ��Ϣ</param>
        /// <returns>��ӵļ�¼��</returns>
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
        /// ɾ����Ŀ��Ϣ
        /// </summary>
        /// <param name="id">��ĿId</param>
        /// <returns>ɾ���ļ�¼��</returns>
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
        /// ������Ŀ��Ϣ
        /// </summary>
        /// <param name="project">����Ŀ��Ϣ</param>
        /// <returns>�޸ĵļ�¼��</returns>
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