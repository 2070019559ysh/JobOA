using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL.Implement
{
    /// <summary>
    /// 任务每日更新关联数据库类
    /// </summary>
    public class DailyUpdateService:IDailyUpdateService
    {
        /// <summary>
        /// 通过Id查找每日更新信息
        /// </summary>
        /// <returns>每日更新信息</returns>
        public DailyUpdate SearchDailyUpdateById(int id)
        {
            using (OaModel dbContext = new OaModel())
            {
                var dailyUpdate = from d in dbContext.DailyUpdate
                                 where d.Id == id
                                 select d;
                return dailyUpdate.SingleOrDefault();
            }
        }

        /// <summary>
        /// 添加每日更新信息
        /// </summary>
        /// <param name="dailyUpdate">每日更新信息</param>
        /// <returns>添加的记录数</returns>
        public int AddDailyUpdate(DailyUpdate dailyUpdate)
        {
            using (OaModel dbContext = new OaModel())
            {
                dbContext.DailyUpdate.Add(dailyUpdate);
                int rows = dbContext.SaveChanges();
                return rows;
            }
        }

        /// <summary>
        /// 删除每日更新信息
        /// </summary>
        /// <param name="id">每日更新Id</param>
        /// <returns>删除的记录数</returns>
        public int DeleteDailyUpdate(int id)
        {
            using (OaModel dbContext = new OaModel())
            {
                DailyUpdate dailyUpdate = new DailyUpdate() { Id = id };
                dbContext.DailyUpdate.Attach(dailyUpdate);
                dbContext.DailyUpdate.Remove(dailyUpdate);
                int rows = dbContext.SaveChanges();
                return rows;
            }
        }

        /// <summary>
        /// 更新每日更新信息
        /// </summary>
        /// <param name="dailyUpdate">新每日更新信息</param>
        /// <returns>修改的记录数</returns>
        public int UpdateDailyUpdate(DailyUpdate dailyUpdate)
        {
            using (OaModel dbContext = new OaModel())
            {
                var oldDailyUpdate = dbContext.DailyUpdate.Find(dailyUpdate.Id);
                if (oldDailyUpdate != null)
                {
                    oldDailyUpdate.ExtraTask = dailyUpdate.ExtraTask;
                    oldDailyUpdate.SpendTime = dailyUpdate.SpendTime;
                    oldDailyUpdate.SubTaskId = dailyUpdate.SubTaskId;
                    oldDailyUpdate.Time = dailyUpdate.Time;
                    oldDailyUpdate.WorkContent = dailyUpdate.WorkContent;
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
