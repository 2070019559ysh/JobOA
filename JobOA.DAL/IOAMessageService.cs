using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL
{
    /// <summary>
    /// OA发信息通知的关联数据库接口
    /// </summary>
    public interface IOAMessageService
    {
        /// <summary>
        /// 通过Id查找OA通知的信息
        /// </summary>
        /// <returns>OA通知的信息</returns>
        OAMessage SearchOAMessageById(int id);

        /// <summary>
        /// 添加OA通知的信息
        /// </summary>
        /// <param name="oaMessage">OA通知的信息</param>
        /// <returns>添加的记录数</returns>
        int AddOAMessage(OAMessage oaMessage);

        /// <summary>
        /// 删除OA通知的信息
        /// </summary>
        /// <param name="id">OA通知的Id</param>
        /// <returns>删除的记录数</returns>
        int DeleteOAMessage(int id);

        /// <summary>
        /// 更新OA通知的信息
        /// </summary>
        /// <param name="oaMessage">新OA通知的信息</param>
        /// <returns>修改的记录数</returns>
        int UpdateOAMessage(OAMessage oaMessage);
    }
}
