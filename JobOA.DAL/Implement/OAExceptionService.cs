using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL.Implement
{
    /// <summary>
    /// OA系统异常信息关联数据库实现类
    /// </summary>
    public class OAExceptionService:IOAExceptionService
    {
        /// <summary>
        /// 通过Id查找OA系统异常信息
        /// </summary>
        /// <returns>OA系统异常信息</returns>
        public OAException SearchOAExceptionById(int id)
        {
            using (OaModel dbContext = new OaModel())
            {
                var oaException = (from oaEx in dbContext.OAException
                                  where oaEx.Id == id
                                  select oaEx).SingleOrDefault();
                return oaException;
            }
        }

        /// <summary>
        /// 添加OA系统异常信息
        /// </summary>
        /// <param name="oaException">OA系统异常信息</param>
        /// <returns>添加的记录数</returns>
        public int AddOAException(OAException oaException)
        {
            using (OaModel dbContext = new OaModel())
            {
                dbContext.OAException.Add(oaException);
                int rows=dbContext.SaveChanges();
                return rows;
            }
        }

        /// <summary>
        /// 删除OA系统异常信息
        /// </summary>
        /// <param name="id">OA系统异常Id</param>
        /// <returns>删除的记录数</returns>
        public int DeleteOAException(int id)
        {
            using (OaModel dbContext = new OaModel())
            {
                OAException oaException = new OAException() { Id = id };
                dbContext.OAException.Attach(oaException);
                dbContext.OAException.Remove(oaException);
                int rows = dbContext.SaveChanges();
                return rows;
            }
        }

        /// <summary>
        /// 更新OA系统异常信息
        /// </summary>
        /// <param name="oaException">新OA系统异常信息</param>
        /// <returns>更新的记录数</returns>
        public int UpdateOAException(OAException oaException)
        {
            using (OaModel dbContext = new OaModel())
            {
                OAException oldException=dbContext.OAException.Find(oaException.Id);
                if (oldException != null)
                {
                    oldException.ExMessage = oaException.ExMessage;
                    oldException.ExTime = oaException.ExTime;
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
