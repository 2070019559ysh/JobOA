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
    /// ��Ŀ��Ϣ�������ݿ���
    /// </summary>
    public class ProjectManageer : IProjectManager
    {
        /// <summary>
        /// ����ע��������������ݿ������
        /// </summary>
        [Inject]
        public IProjectService ProjectService { get; set; }

        /// <summary>
        /// �쳣�������
        /// </summary>
        private readonly ExceptionLog _exceptionLog = new ExceptionLog();

        /// <summary>
        /// ͨ��Id������Ŀ��Ϣ
        /// </summary>
        /// <returns>��Ŀ��Ϣ</returns>
        public Project SearchProjectById(int id)
        {
            Project project = null;
            try
            {
                project = ProjectService.SearchProjectById(id);
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " �����쳣��" + ex.Message);
            }
            return project;
        }

        /// <summary>
        /// ����������Ŀ
        /// </summary>
        /// <returns>������Ŀ�ļ���</returns>
        public List<Project> SearchAllProject()
        {
            List<Project> projectList = null;
            try
            {
                projectList = ProjectService.SearchAllProject();
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " �����쳣��" + ex.Message);
            }
            return projectList;
        }

        /// <summary>
        /// ���ݷ�ҳ������pager.Remarks����Ŀ��ģ����ѯ������Ŀ��Ϣ
        /// </summary>
        /// <param name="pager">��ҳ����</param>
        /// <returns>������Ŀ��Ϣ</returns>
        public List<Project> SearchProjectByPages(Pager pager)
        {
            if (pager.Remarks==null) pager.Remarks = String.Empty;
            pager.Total=ProjectService.AllProjectCount(pager.Remarks);
            List<Project> projectList=ProjectService.SearchAllProject(pager);
            return projectList;
        }

        /// <summary>
        /// �����Ŀ��Ϣ
        /// </summary>
        /// <param name="project">��Ŀ��Ϣ</param>
        /// <returns>��Ӽ�¼�Ƿ�ɹ�</returns>
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
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " �����쳣��" + ex.Message);
            }
            return isSuccess;
        }

        /// <summary>
        /// ɾ����Ŀ��Ϣ
        /// </summary>
        /// <param name="id">��ĿId</param>
        /// <returns>ɾ����¼�Ƿ�ɹ�</returns>
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
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " �����쳣��" + ex.Message);
            }
            return isSuccess;
        }

        /// <summary>
        /// ������Ŀ��Ϣ
        /// </summary>
        /// <param name="project">����Ŀ��Ϣ</param>
        /// <returns>�޸ĵļ�¼�Ƿ�ɹ�</returns>
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
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " �����쳣��" + ex.Message);
            }
            return isSuccess;
        }
    }
}