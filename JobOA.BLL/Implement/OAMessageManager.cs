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
    /// OA信息通知的业务逻辑类
    /// </summary>
    public class OAMessageManager:IOAMessageManager
    {
        /// <summary>
        /// 依赖注入消息通知关联数据库类
        /// </summary>
        [Inject]
        public IOAMessageService OAMessageService { get; set; }

        /// <summary>
        /// 异常处理对象
        /// </summary>
        private readonly ExceptionLog _exceptionLog = new ExceptionLog();

        /// <summary>
        /// 通过Id查找OA通知的信息
        /// </summary>
        /// <param name="id">通知消息的Id</param>
        /// <returns>OA通知的信息</returns>
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
        /// 分页查找所有OA通知的信息
        /// </summary>
        /// <param name="pager">输出参数，分页信息对象</param>
        /// <returns>OA通知的信息集合</returns>
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
                    //清空导航属性的值，让json序列化时不出错循环导航属性
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
        /// 添加OA通知的信息
        /// </summary>
        /// <param name="oaMessage">OA通知的信息</param>
        /// <returns>添加的记录是否成功</returns>
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
        /// 删除OA通知的信息
        /// </summary>
        /// <param name="id">OA通知的Id</param>
        /// <returns>删除的记录是否成功</returns>
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
        /// 更新OA通知的信息
        /// </summary>
        /// <param name="oaMessage">新OA通知的信息</param>
        /// <returns>修改的记录是否成功</returns>
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
        /// 标志OA通知的信息已经被主人查看过
        /// </summary>
        /// <param name="id">要标志已查看OA信息的Id</param>
        /// <returns>是否标志成功</returns>
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
