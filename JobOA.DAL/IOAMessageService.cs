using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL
{
    /// <summary>
    /// OA����Ϣ֪ͨ�Ĺ������ݿ�ӿ�
    /// </summary>
    public interface IOAMessageService
    {
        /// <summary>
        /// ͨ��Id����OA֪ͨ����Ϣ
        /// </summary>
        /// <returns>OA֪ͨ����Ϣ</returns>
        OAMessage SearchOAMessageById(int id);

        /// <summary>
        /// ���OA֪ͨ����Ϣ
        /// </summary>
        /// <param name="oaMessage">OA֪ͨ����Ϣ</param>
        /// <returns>��ӵļ�¼��</returns>
        int AddOAMessage(OAMessage oaMessage);

        /// <summary>
        /// ɾ��OA֪ͨ����Ϣ
        /// </summary>
        /// <param name="id">OA֪ͨ��Id</param>
        /// <returns>ɾ���ļ�¼��</returns>
        int DeleteOAMessage(int id);

        /// <summary>
        /// ����OA֪ͨ����Ϣ
        /// </summary>
        /// <param name="oaMessage">��OA֪ͨ����Ϣ</param>
        /// <returns>�޸ĵļ�¼��</returns>
        int UpdateOAMessage(OAMessage oaMessage);
    }
}
