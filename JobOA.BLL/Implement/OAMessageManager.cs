using JobOA.Common;
using JobOA.DAL;
using JobOA.Model;
using Ninject;
using System;

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
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " 发生异常：" + ex.Message);
            }
            return oaMessage;
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
                if (OAMessageService.AddOAMessage(oaMessage) > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " 发生异常：" + ex.Message);
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
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " 发生异常：" + ex.Message);
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
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " 发生异常：" + ex.Message);
            }
            return isSuccess;
        }
    }
}
