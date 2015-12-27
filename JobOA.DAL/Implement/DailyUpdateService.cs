using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL.Implement
{
    /// <summary>
    /// ����ÿ�ո��¹������ݿ���
    /// </summary>
    public class DailyUpdateService:IDailyUpdateService
    {
        /// <summary>
        /// ͨ��Id����ÿ�ո�����Ϣ
        /// </summary>
        /// <returns>ÿ�ո�����Ϣ</returns>
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
        /// ���ÿ�ո�����Ϣ
        /// </summary>
        /// <param name="dailyUpdate">ÿ�ո�����Ϣ</param>
        /// <returns>��ӵļ�¼��</returns>
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
        /// ɾ��ÿ�ո�����Ϣ
        /// </summary>
        /// <param name="id">ÿ�ո���Id</param>
        /// <returns>ɾ���ļ�¼��</returns>
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
        /// ����ÿ�ո�����Ϣ
        /// </summary>
        /// <param name="dailyUpdate">��ÿ�ո�����Ϣ</param>
        /// <returns>�޸ĵļ�¼��</returns>
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
