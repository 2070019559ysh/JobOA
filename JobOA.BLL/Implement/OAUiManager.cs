using JobOA.Common;
using JobOA.Common.Model;
using JobOA.DAL;
using JobOA.Model;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.BLL.Implement
{
    /// <summary>
    /// OA������Ϣ�������ݿ���
    /// </summary>
    public class OAUiManager:IOAUiManager
    {
        /// <summary>
        /// ����ע��Ա���������ݿ������
        /// </summary>
        [Inject]
        public IOAUiService OAUiService { get; set; }
        
        /// <summary>
        /// �쳣�������
        /// </summary>
        private readonly ExceptionLog _exceptionLog = new ExceptionLog();

        /// <summary>
        /// ͨ��Id����OA������Ϣ
        /// </summary>
        /// <returns>OA������Ϣ</returns>
        public OAUi SearchOAUiById(int id)
        {
            OAUi oaUi = null;
            try
            {
                oaUi = OAUiService.SearchOAUiById(id);
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(ex);
            }
            return oaUi;
        }

        /// <summary>
        /// ͨ��������׼ȷ����OA������Ϣ
        /// </summary>
        /// <param name="title">������������ģ��ƥ��</param>
        /// <returns>OA������Ϣ</returns>
        public OAUi SearchOAUiByTitle(string title)
        {
            OAUi oaUi = null;
            try
            {
                oaUi = OAUiService.SearchOAUiByTitle(title);
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(ex);
            }
            return oaUi;
        }

        /// <summary>
        /// ���OA������Ϣ
        /// </summary>
        /// <param name="oaUi">OA������Ϣ</param>
        /// <returns>����Ƿ�ɹ�</returns>
        public bool AddOAUi(OAUi oaUi)
        {
            bool success = false;//�Ƿ�ɹ�ִ��
            try
            {
                int row = OAUiService.AddOAUi(oaUi);
                if (row > 0)
                {
                    success = true;
                }
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(ex);
            }
            return success;
        }

        /// <summary>
        /// ���Ͷ��ţ�ʹ����joboa_System_sms��־�Ķ����˺�
        /// </summary>
        /// <param name="smsMob">����Ŀ�ĺ��룬����ֻ������ð�Ƕ��Ÿ���</param>
        /// <param name="smsText">��������</param>
        /// <returns>�Ƿ��Ѿ��ж��ŷ��ͳɹ�</returns>
        public bool SendSms(string smsMob,string smsText)
        {
            bool success = false;//�Ƿ�ɹ�ִ��
            try
            {
                OAUi smsoaUi = OAUiService.SearchOAUiByTitle("joboa_System_sms");
                string[] sms = smsoaUi.UiMess.Split(';');
                string smsUid = String.Empty;
                string smsKey = String.Empty;
                for (var i = 0; i < sms.Length; i++)
                {
                    if (sms[i].Contains("uid"))
                    {
                        smsUid = sms[i].Substring(4);
                    }
                    if (sms[i].Contains("key"))
                    {
                        smsKey = sms[i].Substring(4);
                    }
                }
                SmsInfo smsInfo = new SmsInfo(smsUid, smsKey);
                smsInfo.SmsMob = smsMob;
                smsInfo.SmsText = smsText;
                SendingSMS sendSms = new SendingSMS();
                int resultNum = 0;
                sendSms.SendSMS(smsInfo, out resultNum);
                success = resultNum > 0;
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(ex);
            }
            return success;
        }

        /// <summary>
        /// ����������Ϣ��ʹ����joboa_System_email��־�Ķ����˺�
        /// </summary>
        /// <param name="toSb">���͸�˭������</param>
        /// <param name="subject">����</param>
        /// <param name="body">����</param>
        /// <param name="fileList">�����ļ�������</param>
        /// <returns>�Ƿ��ͳɹ�</returns>
        public bool SendEmail(string toSb,string subject, string body, List<string> fileList=null)
        {
            bool success = false;//�Ƿ�ɹ�ִ��
            try
            {
                OAUi smsoaUi = OAUiService.SearchOAUiByTitle("joboa_System_email");
                string[] emailInfo = smsoaUi.UiMess.Split(';');
                string server = String.Empty;
                string from = String.Empty;
                string password = String.Empty;
                for (var i = 0; i < emailInfo.Length; i++)
                {
                    if (emailInfo[i].Contains("server"))
                    {
                        server = emailInfo[i].Substring(7);
                    }
                    if (emailInfo[i].Contains("from"))
                    {
                        from = emailInfo[i].Substring(5);
                    }
                    if (emailInfo[i].Contains("password"))
                    {
                        password = emailInfo[i].Substring(9);
                    }
                }
                SendingEmail sendEmail = new SendingEmail(server, from, password);
                sendEmail.Body = body;
                sendEmail.Subject = subject;
                if (fileList != null)
                    sendEmail.FileList = fileList;
                List<string> to = new List<string>();
                to.Add(toSb);
                sendEmail.ToList = to;
                sendEmail.SendEmailWithAttachment(false);
                success = true;
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(ex);
            }
            return success;
        }

        /// <summary>
        /// ɾ��OA������Ϣ
        /// </summary>
        /// <param name="id">OA����Id</param>
        /// <returns>ɾ���Ƿ�ɹ�</returns>
        public bool DeleteOAUi(int id)
        {
            bool success = false;//�Ƿ�ɹ�ִ��
            try
            {
                int row = OAUiService.DeleteOAUi(id);
                if (row > 0)
                {
                    success = true;
                }
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(ex);
            }
            return success;
        }

        /// <summary>
        /// ����OA������Ϣ
        /// </summary>
        /// <param name="oaUi">��OA������Ϣ</param>
        /// <returns>�޸��Ƿ�ɹ�</returns>
        public bool UpdateOAUi(OAUi oaUi)
        {
            bool success = false;//�Ƿ�ɹ�ִ��
            try
            {
                int row = OAUiService.UpdateOAUi(oaUi);
                if (row > 0)
                {
                    success = true;
                }
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(ex);
            }
            return success;
        }
    }
}