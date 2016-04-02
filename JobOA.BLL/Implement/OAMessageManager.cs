using JobOA.Common;
using JobOA.DAL;
using JobOA.Model;
using JobOA.Model.ViewModel;
using Ninject;
using System;
using System.Collections.Generic;

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
                _exceptionLog.RecordLog(ex);
            }
            return oaMessage;
        }

        /// <summary>
        /// ��ҳ��������OA֪ͨ����Ϣ
        /// </summary>
        /// <param name="pager">�����������ҳ��Ϣ����</param>
        /// <returns>OA֪ͨ����Ϣ����</returns>
        public List<OAMessage> SearchAllOAMessage(Pager pager)
        {
            List<OAMessage> oaMessList = null;
            try
            {
                oaMessList = OAMessageService.SearchAllOAMessage(pager);
                foreach (var e in oaMessList)
                {
                    if(e.FromEmployee.HeadPicture==null||!e.FromEmployee.HeadPicture.Contains("/Content/"))
                        e.FromEmployee.HeadPicture = HeadPictureHandle.GetHeadPicture(e.FromEmployee.HeadPicture );
                    //��յ������Ե�ֵ����json���л�ʱ������ѭ����������
                    e.FromEmployee.GetMessages = null;
                    e.ToEmployee.GetMessages = null;
                    e.FromEmployee.SendMessages = null;
                    e.ToEmployee.SendMessages = null;
                    e.FromEmployee.ArrangePersonSubTask = null;
                    e.FromEmployee.ArrangePersonTask = null;
                    e.FromEmployee.CheckPersonSubTask = null;
                    e.FromEmployee.CheckPersonTask = null;
                    e.FromEmployee.Department = null;
                    e.FromEmployee.ExePersonSubTask = null;
                    e.FromEmployee.ExePersonTask = null;
                    e.ToEmployee.ArrangePersonSubTask = null;
                    e.ToEmployee.ArrangePersonTask = null;
                    e.ToEmployee.CheckPersonSubTask = null;
                    e.ToEmployee.CheckPersonTask = null;
                    e.ToEmployee.Department = null;
                    e.ToEmployee.ExePersonSubTask = null;
                    e.ToEmployee.ExePersonTask = null;
                }
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(ex);
            }
            return oaMessList;
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
                oaMessage.SendDateTime = DateTime.Now;
                if (OAMessageService.AddOAMessage(oaMessage) > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(ex);
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
                _exceptionLog.RecordLog(ex);
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
                _exceptionLog.RecordLog(ex);
            }
            return isSuccess;
        }

        /// <summary>
        /// ��־OA֪ͨ����Ϣ�Ѿ������˲鿴��
        /// </summary>
        /// <param name="id">Ҫ��־�Ѳ鿴OA��Ϣ��Id</param>
        /// <returns>�Ƿ��־�ɹ�</returns>
        public bool LookUpOAMessage(int id)
        {
            bool isSuccess = false;
            try
            {
                if (OAMessageService.LookUpOAMessage(id) > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(ex);
            }
            return isSuccess;
        }
    }
}
