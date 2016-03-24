using JobOA.Model;
using System;

namespace JobOA.BLL
{
    /// <summary>
    /// OA��Ϣ֪ͨ��ҵ���߼��ӿ�
    /// </summary>
    public interface IOAMessageManager
    {
        /// <summary>
        /// ͨ��Id����OA֪ͨ����Ϣ
        /// </summary>
        /// <param name="id">֪ͨ��Ϣ��Id</param>
        /// <returns>OA֪ͨ����Ϣ</returns>
        OAMessage SearchOAMessageById(int id);

        /// <summary>
        /// ���OA֪ͨ����Ϣ
        /// </summary>
        /// <param name="oaMessage">OA֪ͨ����Ϣ</param>
        /// <returns>��ӵļ�¼�Ƿ�ɹ�</returns>
        bool AddOAMessage(OAMessage oaMessage);

        /// <summary>
        /// ɾ��OA֪ͨ����Ϣ
        /// </summary>
        /// <param name="id">OA֪ͨ��Id</param>
        /// <returns>ɾ���ļ�¼�Ƿ�ɹ�</returns>
        bool DeleteOAMessage(int id);

        /// <summary>
        /// ����OA֪ͨ����Ϣ
        /// </summary>
        /// <param name="oaMessage">��OA֪ͨ����Ϣ</param>
        /// <returns>�޸ĵļ�¼�Ƿ�ɹ�</returns>
        bool UpdateOAMessage(OAMessage oaMessage);
    }
}
