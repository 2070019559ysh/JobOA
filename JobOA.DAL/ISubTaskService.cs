using JobOA.Model;
using JobOA.Model.ViewModel;
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
        /// 根据分页对象信息查找子任务列表信息
        /// </summary>
        /// <param name="id">主任务id</param>
        /// <param name="pager">分页对象信息</param>
        /// <returns>子任务列表信息</returns>
        List<SubTask> SearchSubTask(int id, Pager pager);

        /// <summary>
        /// 统计当前主任务下的子任务一个有几个
        /// </summary>
        /// <param name="majorTaskId">主任务Id</param>
        /// <returns>子任务总数量</returns>
        int SubTaskCountByMajorTask(int majorTaskId);

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

        /// <summary>
        /// 更新子任务的附件名
        /// </summary>
        /// <param name="subTaskId">子任务Id</param>
        /// <param name="fileName">附件文件名</param>
        /// <returns>修改的记录数</returns>
        int UpdateSubTaskAttachment(int subTaskId, string fileName);
    }
}