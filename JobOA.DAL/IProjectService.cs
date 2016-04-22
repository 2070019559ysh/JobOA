using JobOA.Model;
using JobOA.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL
{
    /// <summary>
    /// ��Ŀ��Ϣ�������ݿ�ӿ�
    /// </summary>
    public interface IProjectService
    {
        /// <summary>
        /// ͨ��Id������Ŀ��Ϣ
        /// </summary>
        /// <param name="id">��ĿId</param>
        /// <returns>��Ŀ��Ϣ</returns>
        Project SearchProjectById(int id);

        /// <summary>
        /// ͨ��������Id������Ŀ��Ϣ
        /// </summary>
        /// <param name="subTaskId">������Id</param>
        /// <returns>��Ŀ��Ϣ</returns>
        Project SearchProjectBySubTaskId(int subTaskId);

        /// <summary>
        /// ͨ��������Id������Ŀ��Ϣ
        /// </summary>
        /// <param name="taskId">������Id</param>
        /// <returns>��Ŀ��Ϣ</returns>
        Project SearchProjectByTaskId(int taskId);

        /// <summary>
        /// ����������Ŀ
        /// </summary>
        /// <returns>������Ŀ�ļ���</returns>
        List<Project> SearchAllProject();

        /// <summary>
        /// ����������Ŀ,��ҳ������ѯ��pager.Remarks��������Ŀ��
        /// </summary>
        /// <returns>��ҳ������ѯ������Ŀ����</returns>
        List<Project> SearchAllProject(Pager pager);

        /// <summary>
        /// ģ������ָ����Ŀ������Ŀ��¼����
        /// </summary>
        /// <returns>��Ŀ��¼����</returns>
        int AllProjectCount(string projectName);

        /// <summary>
        /// �����Ŀ��Ϣ
        /// </summary>
        /// <param name="project">��Ŀ��Ϣ</param>
        /// <returns>��ӵļ�¼��</returns>
        int AddProject(Project project);

        /// <summary>
        /// ɾ����Ŀ��Ϣ
        /// </summary>
        /// <param name="id">��ĿId</param>
        /// <returns>ɾ���ļ�¼��</returns>
        int DeleteProject(int id);

        /// <summary>
        /// ������Ŀ��Ϣ
        /// </summary>
        /// <param name="project">����Ŀ��Ϣ</param>
        /// <returns>�޸ĵļ�¼��</returns>
        int UpdateProject(Project project);
    }
}