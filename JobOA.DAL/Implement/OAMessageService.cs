using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL.Implement
{
    /// <summary>
    /// OA发信息通知的关联数据库类
    /// </summary>
    public class OAMessageService:IOAMessageService
    {
        /// <summary>
        /// 通过Id查找OA通知的信息
        /// </summary>
        /// <returns>OA通知的信息</returns>
        public OAMessage SearchOAMessageById(int id)
        {
            using (OaModel dbContext = new OaModel())
            {
                var oaMessage = from m in dbContext.OAMessage
                                  where m.Id == id
                                  select m;
                return oaMessage.SingleOrDefault();
            }
        }

        /// <summary>
        /// 添加OA通知的信息
        /// </summary>
        /// <param name="oaMessage">OA通知的信息</param>
        /// <returns>添加的记录数</returns>
        public int AddOAMessage(OAMessage oaMessage)
        {
            using (OaModel dbContext = new OaModel())
            {
                dbContext.OAMessage.Add(oaMessage);
                int rows = dbContext.SaveChanges();
                return rows;
            }
        }

        /// <summary>
        /// 删除OA通知的信息
        /// </summary>
        /// <param name="id">OA通知的Id</param>
        /// <returns>删除的记录数</returns>
        public int DeleteOAMessage(int id)
        {
            using (OaModel dbContext = new OaModel())
            {
                OAMessage oaMessage = new OAMessage() { Id = id };
                dbContext.OAMessage.Attach(oaMessage);
                dbContext.OAMessage.Remove(oaMessage);
                int rows = dbContext.SaveChanges();
                return rows;
            }
        }

        /// <summary>
        /// 更新OA通知的信息
        /// </summary>
        /// <param name="oaMessage">新OA通知的信息</param>
        /// <returns>修改的记录数</returns>
        public int UpdateOAMessage(OAMessage oaMessage)
        {
            using (OaModel dbContext = new OaModel())
            {
                var oldOAMessage = dbContext.OAMessage.Find(oaMessage.Id);
                if (oldOAMessage != null)
                {
                    oldOAMessage.ExtraMessage = oaMessage.ExtraMessage;
                    oldOAMessage.SubTaskId = oaMessage.SubTaskId;
                    oldOAMessage.TaskId = oaMessage.TaskId;
                    int rows = dbContext.SaveChanges();
                    return rows;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
