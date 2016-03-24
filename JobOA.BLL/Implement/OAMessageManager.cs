using JobOA.Common;
using JobOA.DAL;
using JobOA.Model;
using Ninject;
using System;

namespace JobOA.BLL.Implement
{
    /// <summary>
    /// OA��Ϣ֪ͨ��ҵ���߼���
    /// </summary>
    public class OAMessageManager:IOAMessageManager
    {
        /// <summary>
        /// ����ע����Ϣ֪ͨ�������ݿ���
        /// </summary>
        [Inject]
        public IOAMessageService OAMessageService { get; set; }

        /// <summary>
        /// �쳣�������
        /// </summary>
        private readonly ExceptionLog _exceptionLog = new ExceptionLog();

        /// <summary>
        /// ͨ��Id����OA֪ͨ����Ϣ
        /// </summary>
        /// <param name="id">֪ͨ��Ϣ��Id</param>
        /// <returns>OA֪ͨ����Ϣ</returns>
        public OAMessage SearchOAMessageById(int id)
        {
            OAMessage oaMessage = null;
            try
            {
                oaMessage=OAMessageService.SearchOAMessageById(id);
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " �����쳣��" + ex.Message);
            }
            return oaMessage;
        }

        /// <summary>
        /// ���OA֪ͨ����Ϣ
        /// </summary>
        /// <param name="oaMessage">OA֪ͨ����Ϣ</param>
        /// <returns>��ӵļ�¼�Ƿ�ɹ�</returns>
        public bool AddOAMessage(OAMessage oaMessage)
        {
            bool isSuccess = false;
            try
            {
                if (OAMessageService.AddOAMessage(oaMessage) > 0)
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
        /// ɾ��OA֪ͨ����Ϣ
        /// </summary>
        /// <param name="id">OA֪ͨ��Id</param>
        /// <returns>ɾ���ļ�¼�Ƿ�ɹ�</returns>
        public bool DeleteOAMessage(int id)
        {
            bool isSuccess = false;
            try
            {
                if (OAMessageService.DeleteOAMessage(id) > 0)
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
        /// ����OA֪ͨ����Ϣ
        /// </summary>
        /// <param name="oaMessage">��OA֪ͨ����Ϣ</param>
        /// <returns>�޸ĵļ�¼�Ƿ�ɹ�</returns>
        public bool UpdateOAMessage(OAMessage oaMessage)
        {
            bool isSuccess = false;
            try
            {
                if (OAMessageService.UpdateOAMessage(oaMessage) > 0)
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
