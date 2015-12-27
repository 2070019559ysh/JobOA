using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL
{
    /// <summary>
    /// OA界面信息关联数据库接口
    /// </summary>
    public interface IOAUiService
    {
        /// <summary>
        /// 通过Id查找OA界面信息
        /// </summary>
        /// <returns>OA界面信息</returns>
        OAUi SearchOAUiById(int id);

        /// <summary>
        /// 通过标题名准确查找OA界面信息
        /// </summary>
        /// <param name="title">标题名，不能模糊匹配</param>
        /// <returns>OA界面信息</returns>
        OAUi SearchOAUiByTitle(string title);

        /// <summary>
        /// 添加OA界面信息
        /// </summary>
        /// <param name="oaUi">OA界面信息</param>
        /// <returns>添加的记录数</returns>
        int AddOAUi(OAUi oaUi);

        /// <summary>
        /// 删除OA界面信息
        /// </summary>
        /// <param name="id">OA界面Id</param>
        /// <returns>删除的记录数</returns>
        int DeleteOAUi(int id);

        /// <summary>
        /// 更新OA界面信息
        /// </summary>
        /// <param name="oaUi">新OA界面信息</param>
        /// <returns>修改的记录数</returns>
        int UpdateOAUi(OAUi oaUi);
    }
}