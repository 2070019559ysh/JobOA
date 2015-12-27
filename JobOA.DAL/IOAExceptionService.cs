using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL
{
    /// <summary>
    /// OA系统异常信息关联数据库接口
    /// </summary>
    public interface IOAExceptionService
    {
        /// <summary>
        /// 通过Id查找OA系统异常信息
        /// </summary>
        /// <returns>OA系统异常信息</returns>
        OAException SearchOAExceptionById(int id);

        /// <summary>
        /// 添加OA系统异常信息
        /// </summary>
        /// <param name="oaException">OA系统异常信息</param>
        /// <returns>添加的记录数</returns>
        int AddOAException(OAException oaException);

        /// <summary>
        /// 删除OA系统异常信息
        /// </summary>
        /// <param name="id">OA系统异常Id</param>
        /// <returns>删除的记录数</returns>
        int DeleteOAException(int id);

        /// <summary>
        /// 更新OA系统异常信息
        /// </summary>
        /// <param name="oaException">新OA系统异常信息</param>
        /// <returns>更新的记录数</returns>
        int UpdateOAException(OAException oaException);
    }
}