using JobOA.Model;
using JobOA.Model.ViewModel;
using System;
using System.Collections.Generic;

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
        /// ��ҳ��������OA֪ͨ����Ϣ
        /// </summary>
        /// <param name="pager">�����������ҳ��Ϣ����</param>
        /// <returns>OA֪ͨ����Ϣ����</returns>
        List<OAMessage> SearchAllOAMessage(Pager pager);

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

        /// <summary>
        /// ��־OA֪ͨ����Ϣ�Ѿ������˲鿴��
        /// </summary>
        /// <param name="id">Ҫ��־�Ѳ鿴OA��Ϣ��Id</param>
        /// <returns>�Ƿ��־�ɹ�</returns>
        bool LookUpOAMessage(int id);
    }
}
