using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL
{
    /// <summary>
    /// 任务每日更新关联数据库接口
    /// </summary>
    public interface IDailyUpdateService
    {
        /// <summary>
        /// 通过Id查找每日更新信息
        /// </summary>
        /// <returns>每日更新信息</returns>
        DailyUpdate SearchDailyUpdateById(int id);

        /// <summary>
        /// 添加每日更新信息
        /// </summary>
        /// <param name="dailyUpdate">每日更新信息</param>
        /// <returns>添加的记录数</returns>
        int AddDailyUpdate(DailyUpdate dailyUpdate);

        /// <summary>
        /// 删除每日更新信息
        /// </summary>
        /// <param name="id">每日更新Id</param>
        /// <returns>删除的记录数</returns>
        int DeleteDailyUpdate(int id);

        /// <summary>
        /// 更新每日更新信息
        /// </summary>
        /// <param name="dailyUpdate">新每日更新信息</param>
        /// <returns>修改的记录数</returns>
        int UpdateDailyUpdate(DailyUpdate dailyUpdate);
    }
}
