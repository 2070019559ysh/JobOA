using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL
{
    /// <summary>
    /// ��������Ϣ�������ݿ�ӿ�
    /// </summary>
    public interface ISubTaskService
    {
        /// <summary>
        /// ͨ��Id����������
        /// </summary>
        /// <param name="id">������Id</param>
        /// <returns>������</returns>
        SubTask SearchSubTaskById(int id);

        /// <summary>
        /// ͨ��������ģ������������
        /// </summary>
        /// <param name="name">��������</param>
        /// <returns>�����񼯺�</returns>
        List<SubTask> SearchSubTaskByName(string name);

        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="majorTask">������</param>
        /// <returns>��ӵļ�¼��</returns>
        int AddSubTask(SubTask subTask);

        /// <summary>
        /// ɾ��������
        /// </summary>
        /// <param name="id">������Id</param>
        /// <returns>ɾ���ļ�¼��</returns>
        int DeleteSubTask(int id);

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="majorTask">������</param>
        /// <returns>�޸ĵļ�¼��</returns>
        int UpdateSubTask(SubTask subTask);
    }
}