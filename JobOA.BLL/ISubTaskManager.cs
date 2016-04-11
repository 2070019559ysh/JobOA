using JobOA.Model;
using JobOA.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.BLL
{
    /// <summary>
    /// 子任务信息业务管理接口
    /// </summary>
    public interface ISubTaskManager
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
        /// 获取子任务的编号No
        /// </summary>
        /// <param name="majorTaskId">主任务Id</param>
        /// <returns>子任务的编号No</returns>
        string GetSubTaskNo(int majorTaskId);

        /// <summary>
        /// 添加子任务
        /// </summary>
        /// <param name="SubTask">子任务</param>
        /// <returns>添加的记录是否成功</returns>
        bool AddSubTask(SubTask subTask);

        /// <summary>
        /// 更加id删除子任务
        /// </summary>
        /// <param name="id">子任务Id</param>
        /// <returns>删除记录是否成功</returns>
        bool DeleteSubTask(int id);

        /// <summary>
        /// 更新子任务
        /// </summary>
        /// <param name="SubTask">子任务</param>
        /// <returns>修改记录是否成功</returns>
        bool UpdateSubTask(SubTask subTask);

        /// <summary>
        /// 根据子任务Id及服务器根路径获取当前项目的附件存放路径
        /// </summary>
        /// <param name="subTaskId">主任务Id</param>
        /// <param name="serverMapPath">服务器根路径</param>
        /// <returns></returns>
        string GetAttachmentPath(int subTaskId, string serverMapPath);

        /// <summary>
        /// 更新子任务的附件名,返回是否更新成功
        /// </summary>
        /// <param name="subTaskId">子任务Id</param>
        /// <param name="fileName">附件文件名</param>
        /// <returns>是否更新成功</returns>
        bool UpdateSubTaskAttachment(int subTaskId, string fileName);
    }
}
