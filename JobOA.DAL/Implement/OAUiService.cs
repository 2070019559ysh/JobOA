using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL.Implement
{
    /// <summary>
    /// OA界面信息关联数据库类
    /// </summary>
    public class OAUiService:IOAUiService
    {
        /// <summary>
        /// 通过Id查找OA界面信息
        /// </summary>
        /// <returns>OA界面信息</returns>
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
        /// 通过标题名准确查找OA界面信息
        /// </summary>
        /// <param name="title">标题名，不能模糊匹配</param>
        /// <returns>OA界面信息</returns>
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
        /// 添加OA界面信息
        /// </summary>
        /// <param name="oaUi">OA界面信息</param>
        /// <returns>添加的记录数</returns>
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
        /// 删除OA界面信息
        /// </summary>
        /// <param name="id">OA界面Id</param>
        /// <returns>删除的记录数</returns>
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
        /// 更新OA界面信息
        /// </summary>
        /// <param name="oaUi">新OA界面信息</param>
        /// <returns>修改的记录数</returns>
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