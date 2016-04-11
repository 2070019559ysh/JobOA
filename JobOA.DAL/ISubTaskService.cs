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
        /// ���ݷ�ҳ������Ϣ�����������б���Ϣ
        /// </summary>
        /// <param name="id">������id</param>
        /// <param name="pager">��ҳ������Ϣ</param>
        /// <returns>�������б���Ϣ</returns>
        List<SubTask> SearchSubTask(int id, Pager pager);

        /// <summary>
        /// ͳ�Ƶ�ǰ�������µ�������һ���м���
        /// </summary>
        /// <param name="majorTaskId">������Id</param>
        /// <returns>������������</returns>
        int SubTaskCountByMajorTask(int majorTaskId);

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

        /// <summary>
        /// ����������ĸ�����
        /// </summary>
        /// <param name="subTaskId">������Id</param>
        /// <param name="fileName">�����ļ���</param>
        /// <returns>�޸ĵļ�¼��</returns>
        int UpdateSubTaskAttachment(int subTaskId, string fileName);
    }
}