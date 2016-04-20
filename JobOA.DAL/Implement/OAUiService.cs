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
        /// ���ݷ�ҳ��Ϣ��������oaϵͳ������Ϣ,��ҳ��Ϣ���Remarksָ��ѯ������Ϣ
        /// </summary>
        /// <param name="pager">��ҳ��Ϣ����</param>
        /// <returns>oaϵͳ������Ϣ����</returns>
        public List<OAUi> SearchOAUiByPager(Pager pager)
        {
            using (OaModel dbContext = new OaModel())
            {
                var oauiQuery = from ui in dbContext.OAUi
                                where ui.UiTitle.Contains(pager.Remarks)
                                orderby ui.UiId
                                select ui;
                pager.Total = oauiQuery.Count();//�ܼ�¼��
                List<OAUi> oauiList=oauiQuery.Skip((pager.PageIndex - 1) * pager.PageSize).Take(pager.PageSize).ToList();
                return oauiList;
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
        /// <param name="delOaui">ɾ����oaui����</param>
        /// <returns>ɾ���ļ�¼��</returns>
        public int DeleteOAUi(int id,out OAUi delOaui)
        {
            using (OaModel dbContext = new OaModel())
            {
                delOaui=dbContext.OAUi.Find(id);
                dbContext.OAUi.Remove(delOaui);
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

        /// <summary>
        /// �������Ͳ���ϵͳ������Ϣ
        /// </summary>
        /// <param name="type">ϵͳ������Ϣ���ͣ�{"joboa_System_sms","ϵͳ����������Ϣ"},
        /// {"joboa_System_email","ϵͳ����������Ϣ"},
        /// {"joboa_System_PictureCarousel","ϵͳͼƬ�ֲ�"},
        /// {"joboa_System_FootHead","ϵͳ�Ų�����"},
        /// {"joboa_System_FootContent","ϵͳ�Ų�����"},
        /// {"joboa_System_Notice","ϵͳ����"},
        /// {"joboa_System_InfoList","ϵͳ��Ϣ�б�"}</param>
        /// <param name="limit">���ƻ�ȡ������,Ĭ����4����¼</param>
        /// <returns>ϵͳ������Ϣ����</returns>
        public List<OAUi> SearchOauiByType(string type,int limit=4)
        {
            using (OaModel dbContext = new OaModel())
            {
                var oauiQueryable = from oaui in dbContext.OAUi
                        where oaui.UiTitle.StartsWith(type + "*")
                        select oaui;
                List<OAUi> oauiList=oauiQueryable.Take(limit).ToList();
                return oauiList;
            }
        }
    }
}