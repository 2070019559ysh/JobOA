using JobOA.Model;
using JobOA.Model.ViewModel;
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
        /// 分页查找所有OA通知的信息
        /// </summary>
        /// <param name="Pager">分页信息对象,注意pager.Remarks要记录当前用户id，否则出错</param>
        /// <returns>OA通知的信息集合</returns>
        public List<OAMessage> SearchAllOAMessage(Pager pager)
        {
            int userId=int.Parse(pager.Remarks);
            using (OaModel dbContext = new OaModel())
            {
                dbContext.Configuration.ProxyCreationEnabled = false;
                var oaMessage = from m in dbContext.OAMessage.Include("FromEmployee")
                                where m.ToEmployeeId==userId
                                orderby m.SendDateTime descending
                                select m;
                pager.Total = oaMessage.Count();
                var oaMessList=oaMessage.Skip((pager.PageIndex - 1) * pager.PageSize).Take(pager.PageSize).ToList();
                return oaMessList;
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
                    oldOAMessage.Title = oaMessage.Title;
                    oldOAMessage.ToEmployeeId = oaMessage.ToEmployeeId;
                    oldOAMessage.FromEmployeeId = oaMessage.FromEmployeeId;
                    oldOAMessage.IsLookUp = oaMessage.IsLookUp;
                    int rows = dbContext.SaveChanges();
                    return rows;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 标志OA通知的信息已经被主人查看过
        /// </summary>
        /// <param name="id">要标志已查看OA信息的Id</param>
        /// <returns>已标志的记录数</returns>
        public int LookUpOAMessage(int id)
        {
            using (OaModel dbContext = new OaModel())
            {
                var oldOAMessage = dbContext.OAMessage.Find(id);
                if (oldOAMessage != null)
                {
                    oldOAMessage.IsLookUp = true;
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
