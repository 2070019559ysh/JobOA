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
    /// 主任务业务逻辑接口
    /// </summary>
    public interface IMajorTaskManager
    {
        /// <summary>
        /// 通过Id查找主任务
        /// </summary>
        /// <param name="id">主任务Id</param>
        /// <returns>主任务</returns>
        MajorTask SearchMajorTaskById(int id);

        /// <summary>
        /// 通过任务名模糊查找主任务
        /// </summary>
        /// <param name="name">主任务名</param>
        /// <returns>主任务集合</returns>
        List<MajorTask> SearchMajorTaskByName(string name);

        /// <summary>
        /// 查找所有指定部门下的主任务,不分页
        /// </summary>
        /// <param name="departmentId">部门id</param>
        /// <returns>指定部门下的所有主任务的集合</returns>
        List<MajorTask> SearchAllMajorTask(int departmentId);

        /// <summary>
        /// 根据查询任务条件查找所有主任务
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页最大记录数</param>
        /// <param name="search">查询任务条件,格式：projectId,departmentId,name</param>
        /// <param name="lookUpMethod">查看方式枚举</param>
        /// <param name="employeeId">当前员工id</param>
        /// <returns>所有主任务的集合</returns>
        List<MajorTask> SearchAllMajorTask(int pageIndex, int pageSize, string search, LookUpMethod lookUpMethod, int employeeId);

        /// <summary>
        /// 根据条件查找主任务总记录数
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页最大记录数</param>
        /// <param name="search">查询任务条件,格式：projectId,departmentId,name</param>
        /// <param name="lookUpMethod">查看方式枚举</param>
        /// <param name="employeeId">当前员工id</param>
        /// <returns>满足条件的主任务总记录数</returns>
        int SearchAllMajorTaskCount(int pageIndex, int pageSize, string search, LookUpMethod lookUpMethod, int employeeId);

        /// <summary>
        /// 根据分页查找所有主任务
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageMax">每页最大记录数</param>
        /// <returns>当前页所有主任务的集合</returns>
        List<MajorTask> SearchAllMajorTask(int pageIndex, int pageMax);

        /// <summary>
        /// 添加主任务
        /// </summary>
        /// <param name="majorTask">主任务</param>
        /// <returns>添加记录是否成功</returns>
        bool AddMajorTask(MajorTask majorTask);

        /// <summary>
        /// 删除主任务
        /// </summary>
        /// <param name="id">主任务Id</param>
        /// <returns>删除记录是否成功</returns>
        bool DeleteMajorTask(int id);

        /// <summary>
        /// 更新主任务
        /// </summary>
        /// <param name="majorTask">主任务</param>
        /// <returns>修改记录是否成功</returns>
        bool UpdateMajorTask(MajorTask majorTask);

        /// <summary>
        /// 根据主任务Id及服务器根路径获取当前项目的附件存放路径
        /// </summary>
        /// <param name="taskId">主任务Id</param>
        /// <param name="serverMapPath">服务器根路径</param>
        /// <returns></returns>
        string GetAttachmentPath(int taskId, string serverMapPath);
    }
}
