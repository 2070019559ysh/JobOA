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
    /// ������������ݿ�ӿ�
    /// </summary>
    public interface IMajorTaskService
    {
        /// <summary>
        /// ͨ��Id����������
        /// </summary>
        /// <param name="id">������Id</param>
        /// <returns>������</returns>
        MajorTask SearchMajorTaskById(int id);

        /// <summary>
        /// ͨ��������ģ������������
        /// </summary>
        /// <param name="name">��������</param>
        /// <returns>�����񼯺�</returns>
        List<MajorTask> SearchMajorTaskByName(string name);

        /// <summary>
        /// ���ݲ�ѯ����������������������
        /// </summary>
        /// <param name="searchCondition">��ѯ��������</param>
        /// <returns>����������ļ���</returns>
        List<MajorTask> SearchAllMajorTask(SearchTaskCondition searchCondition);

        /// <summary>
        /// ���ݷ�ҳ��������������
        /// </summary>
        /// <param name="pageIndex">��ǰҳ</param>
        /// <param name="pageMax">ÿҳ����¼��</param>
        /// <returns>��ǰҳ����������ļ���</returns>
        List<MajorTask> SearchAllMajorTask(int pageIndex, int pageMax);

        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="majorTask">������</param>
        /// <returns>��ӵļ�¼��</returns>
        int AddMajorTask(MajorTask majorTask);

        /// <summary>
        /// ɾ��������
        /// </summary>
        /// <param name="id">������Id</param>
        /// <returns>ɾ���ļ�¼��</returns>
        int DeleteMajorTask(int id);

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="majorTask">������</param>
        /// <returns>�޸ĵļ�¼��</returns>
        int UpdateMajorTask(MajorTask majorTask);

    }
}