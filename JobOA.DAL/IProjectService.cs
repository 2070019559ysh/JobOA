using JobOA.Model;
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
        /// <returns>��Ŀ��Ϣ</returns>
        Project SearchProjectById(int id);

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