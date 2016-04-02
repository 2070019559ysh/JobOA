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
        /// ��ҳ��������OA֪ͨ����Ϣ
        /// </summary>
        /// <param name="Pager">��ҳ��Ϣ����,ע��pager.RemarksҪ��¼��ǰ�û�id���������</param>
        /// <returns>OA֪ͨ����Ϣ����</returns>
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
        /// ��־OA֪ͨ����Ϣ�Ѿ������˲鿴��
        /// </summary>
        /// <param name="id">Ҫ��־�Ѳ鿴OA��Ϣ��Id</param>
        /// <returns>�ѱ�־�ļ�¼��</returns>
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
