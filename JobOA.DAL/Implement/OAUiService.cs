using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL.Implement
{
    /// <summary>
    /// OA������Ϣ�������ݿ���
    /// </summary>
    public class OAUiService:IOAUiService
    {
        /// <summary>
        /// ͨ��Id����OA������Ϣ
        /// </summary>
        /// <returns>OA������Ϣ</returns>
        public OAUi SearchOAUiById(int id)
        {
            using (OaModel dbContext = new OaModel())
            {
                var oaUi = from a in dbContext.OAUi
                                 where a.UiId == id
                                 select a;
                return oaUi.SingleOrDefault();
            }
        }

        /// <summary>
        /// ͨ��������׼ȷ����OA������Ϣ
        /// </summary>
        /// <param name="title">������������ģ��ƥ��</param>
        /// <returns>OA������Ϣ</returns>
        public OAUi SearchOAUiByTitle(string title)
        {
            using (OaModel dbContext = new OaModel())
            {
                var oaUi = from a in dbContext.OAUi
                           where a.UiTitle.Equals(title)
                           select a;
                return oaUi.FirstOrDefault();
            }
        }

        /// <summary>
        /// ���OA������Ϣ
        /// </summary>
        /// <param name="oaUi">OA������Ϣ</param>
        /// <returns>��ӵļ�¼��</returns>
        public int AddOAUi(OAUi oaUi)
        {
            using (OaModel dbContext = new OaModel())
            {
                dbContext.OAUi.Add(oaUi);
                int rows = dbContext.SaveChanges();
                return rows;
            }
        }

        /// <summary>
        /// ɾ��OA������Ϣ
        /// </summary>
        /// <param name="id">OA����Id</param>
        /// <returns>ɾ���ļ�¼��</returns>
        public int DeleteOAUi(int id)
        {
            using (OaModel dbContext = new OaModel())
            {
                OAUi oaUi = new OAUi() { UiId = id };
                dbContext.OAUi.Attach(oaUi);
                dbContext.OAUi.Remove(oaUi);
                int rows = dbContext.SaveChanges();
                return rows;
            }
        }

        /// <summary>
        /// ����OA������Ϣ
        /// </summary>
        /// <param name="oaUi">��OA������Ϣ</param>
        /// <returns>�޸ĵļ�¼��</returns>
        public int UpdateOAUi(OAUi oaUi)
        {
            using (OaModel dbContext = new OaModel())
            {
                var oldOAUi = dbContext.OAUi.Find(oaUi.UiId);
                if (oldOAUi != null)
                {
                    oldOAUi.UiImg = oaUi.UiImg;
                    oldOAUi.UiMess = oaUi.UiMess;
                    oldOAUi.UiTitle = oaUi.UiTitle;
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