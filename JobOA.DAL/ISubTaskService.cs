using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL
{
    /// <summary>
    /// 子任务信息关联数据库接口
    /// </summary>
    public interface ISubTaskService
    {
        /// <summary>
        /// 通过Id查找子任务
        /// </summary>
        /// <param name="id">子任务Id</param>
        /// <returns>子任务</returns>
        SubTask SearchSubTaskById(int id);

        /// <summary>
        /// 通过任务名模糊查找子任务
        /// </summary>
        /// <param name="name">子任务名</param>
        /// <returns>子任务集合</returns>
        List<SubTask> SearchSubTaskByName(string name);

        /// <summary>
        /// 添加子任务
        /// </summary>
        /// <param name="majorTask">子任务</param>
        /// <returns>添加的记录数</returns>
        int AddSubTask(SubTask subTask);

        /// <summary>
        /// 删除子任务
        /// </summary>
        /// <param name="id">子任务Id</param>
        /// <returns>删除的记录数</returns>
        int DeleteSubTask(int id);

        /// <summary>
        /// 更新子任务
        /// </summary>
        /// <param name="majorTask">子任务</param>
        /// <returns>修改的记录数</returns>
        int UpdateSubTask(SubTask subTask);
    }
}