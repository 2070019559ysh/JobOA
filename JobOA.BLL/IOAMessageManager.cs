using JobOA.Model;
using JobOA.Model.ViewModel;
using System;
using System.Collections.Generic;

namespace JobOA.BLL
{
    /// <summary>
    /// OA信息通知的业务逻辑接口
    /// </summary>
    public interface IOAMessageManager
    {
        /// <summary>
        /// 通过Id查找OA通知的信息
        /// </summary>
        /// <param name="id">通知消息的Id</param>
        /// <returns>OA通知的信息</returns>
        OAMessage SearchOAMessageById(int id);

        /// <summary>
        /// 分页查找所有OA通知的信息
        /// </summary>
        /// <param name="pager">输出参数，分页信息对象</param>
        /// <returns>OA通知的信息集合</returns>
        List<OAMessage> SearchAllOAMessage(Pager pager);

        /// <summary>
        /// 添加OA通知的信息
        /// </summary>
        /// <param name="oaMessage">OA通知的信息</param>
        /// <returns>添加的记录是否成功</returns>
        bool AddOAMessage(OAMessage oaMessage);

        /// <summary>
        /// 删除OA通知的信息
        /// </summary>
        /// <param name="id">OA通知的Id</param>
        /// <returns>删除的记录是否成功</returns>
        bool DeleteOAMessage(int id);

        /// <summary>
        /// 更新OA通知的信息
        /// </summary>
        /// <param name="oaMessage">新OA通知的信息</param>
        /// <returns>修改的记录是否成功</returns>
        bool UpdateOAMessage(OAMessage oaMessage);

        /// <summary>
        /// 标志OA通知的信息已经被主人查看过
        /// </summary>
        /// <param name="id">要标志已查看OA信息的Id</param>
        /// <returns>是否标志成功</returns>
        bool LookUpOAMessage(int id);
    }
}
