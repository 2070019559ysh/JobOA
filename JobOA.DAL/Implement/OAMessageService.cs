using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL.Implement
{
    /// <summary>
    /// OA����Ϣ֪ͨ�Ĺ������ݿ���
    /// </summary>
    public class OAMessageService:IOAMessageService
    {
        /// <summary>
        /// ͨ��Id����OA֪ͨ����Ϣ
        /// </summary>
        /// <returns>OA֪ͨ����Ϣ</returns>
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
        /// ���OA֪ͨ����Ϣ
        /// </summary>
        /// <param name="oaMessage">OA֪ͨ����Ϣ</param>
        /// <returns>��ӵļ�¼��</returns>
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
        /// ɾ��OA֪ͨ����Ϣ
        /// </summary>
        /// <param name="id">OA֪ͨ��Id</param>
        /// <returns>ɾ���ļ�¼��</returns>
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
        /// ����OA֪ͨ����Ϣ
        /// </summary>
        /// <param name="oaMessage">��OA֪ͨ����Ϣ</param>
        /// <returns>�޸ĵļ�¼��</returns>
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
