using JobOA.Common;
using JobOA.Common.Model;
using JobOA.DAL;
using JobOA.Model;
using JobOA.Model.ViewModel;
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
    /// OA界面信息关联数据库类
    /// </summary>
    public class OAUiManager:IOAUiManager
    {
        /// <summary>
        /// 依赖注入员工关联数据库服务类
        /// </summary>
        [Inject]
        public IOAUiService OAUiService { get; set; }
        
        /// <summary>
        /// 异常处理对象
        /// </summary>
        private readonly ExceptionLog _exceptionLog = new ExceptionLog();

        /// <summary>
        /// 通过Id查找OA界面信息
        /// </summary>
        /// <returns>OA界面信息</returns>
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
        /// 通过标题名准确查找OA界面信息
        /// </summary>
        /// <param name="title">标题名，不能模糊匹配</param>
        /// <returns>OA界面信息</returns>
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
        /// 根据分页信息查找所有oa系统界面信息,分页信息里的Remarks指查询标题信息
        /// </summary>
        /// <param name="pager">分页信息对象</param>
        /// <returns>oa系统界面信息集合</returns>
        public List<OAUi> SearchOAUiByPager(Pager pager)
        {
            List<OAUi> oauiList = null;
            try
            {
                if (pager.Remarks == null) pager.Remarks = String.Empty;
                oauiList=OAUiService.SearchOAUiByPager(pager);
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(ex);
            }
            return oauiList;
        }

        /// <summary>
        /// 添加OA界面信息
        /// </summary>
        /// <param name="oaUi">OA界面信息</param>
        /// <returns>添加是否成功</returns>
        public bool AddOAUi(OAUi oaUi)
        {
            bool success = false;//是否成功执行
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
        /// 发送短信，使用了joboa_System_sms标志的短信账号
        /// </summary>
        /// <param name="smsMob">发送目的号码，多个手机号请用半角逗号隔开</param>
        /// <param name="smsText">短信内容</param>
        /// <returns>是否已经有短信发送成功</returns>
        public bool SendSms(string smsMob,string smsText)
        {
            bool success = false;//是否成功执行
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
        /// 发送邮箱信息，使用了joboa_System_email标志的短信账号
        /// </summary>
        /// <param name="toSb">发送给谁的邮箱</param>
        /// <param name="subject">主题</param>
        /// <param name="body">内容</param>
        /// <param name="fileList">附件文件名集合</param>
        /// <returns>是否发送成功</returns>
        public bool SendEmail(string toSb,string subject, string body, List<string> fileList=null)
        {
            bool success = false;//是否成功执行
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
        /// 删除OA界面信息
        /// </summary>
        /// <param name="id">OA界面Id</param>
        /// <param name="delOaui">删除的oaui对象</param>
        /// <returns>删除是否成功</returns>
        public bool DeleteOAUi(int id,out OAUi delOaui)
        {
            bool success = false;//是否成功执行
            delOaui = null;
            try
            {
                int row = OAUiService.DeleteOAUi(id,out delOaui);
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
        /// 更新OA界面信息
        /// </summary>
        /// <param name="oaUi">新OA界面信息</param>
        /// <returns>修改是否成功</returns>
        public bool UpdateOAUi(OAUi oaUi)
        {
            bool success = false;//是否成功执行
            try
            {
                int row = OAUiService.UpdateOAUi(oaUi);
                if (row >= 0)
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
        /// 根据类型查找系统界面信息
        /// </summary>
        /// <param name="type">系统界面信息类型：{"joboa_System_sms","系统短信配置信息"},
        /// {"joboa_System_email","系统邮箱配置信息"},
        /// {"joboa_System_PictureCarousel","系统图片轮播"},
        /// {"joboa_System_FootHead","系统脚部标题"},
        /// {"joboa_System_FootContent","系统脚部内容"},
        /// {"joboa_System_Notice","系统公告"},
        /// {"joboa_System_InfoList","系统信息列表"}</param>
        /// <param name="limit">限制获取的数量,默认是4条记录</param>
        /// <returns>系统界面信息集合</returns>
        public List<OAUi> SearchOauiByType(string type, int limit = 4)
        {
            List<OAUi> oauiList = null;
            try
            {
                oauiList = OAUiService.SearchOauiByType(type, limit);
                oauiList.ForEach(uiInfo=>{
                    if (!String.IsNullOrEmpty(uiInfo.UiTitle)&&uiInfo.UiTitle.Contains("*"))
                    {
                        int splitIndex = uiInfo.UiTitle.IndexOf("*");
                        uiInfo.UiTitle = uiInfo.UiTitle.Substring(splitIndex + 1);
                    }
                });
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(ex);
            }
            return oauiList;
        }
    }
}