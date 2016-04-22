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
    /// 项目信息关联数据库接口
    /// </summary>
    public interface IProjectService
    {
        /// <summary>
        /// 通过Id查找项目信息
        /// </summary>
        /// <param name="id">项目Id</param>
        /// <returns>项目信息</returns>
        Project SearchProjectById(int id);

        /// <summary>
        /// 通过子任务Id查找项目信息
        /// </summary>
        /// <param name="subTaskId">子任务Id</param>
        /// <returns>项目信息</returns>
        Project SearchProjectBySubTaskId(int subTaskId);

        /// <summary>
        /// 通过主任务Id查找项目信息
        /// </summary>
        /// <param name="taskId">主任务Id</param>
        /// <returns>项目信息</returns>
        Project SearchProjectByTaskId(int taskId);

        /// <summary>
        /// 查找所有项目
        /// </summary>
        /// <returns>所有项目的集合</returns>
        List<Project> SearchAllProject();

        /// <summary>
        /// 查找所有项目,分页条件查询，pager.Remarks必须是项目名
        /// </summary>
        /// <returns>分页条件查询到的项目集合</returns>
        List<Project> SearchAllProject(Pager pager);

        /// <summary>
        /// 模糊查找指定项目名的项目记录总数
        /// </summary>
        /// <returns>项目记录总数</returns>
        int AllProjectCount(string projectName);

        /// <summary>
        /// 添加项目信息
        /// </summary>
        /// <param name="project">项目信息</param>
        /// <returns>添加的记录数</returns>
        int AddProject(Project project);

        /// <summary>
        /// 删除项目信息
        /// </summary>
        /// <param name="id">项目Id</param>
        /// <returns>删除的记录数</returns>
        int DeleteProject(int id);

        /// <summary>
        /// 更新项目信息
        /// </summary>
        /// <param name="project">新项目信息</param>
        /// <returns>修改的记录数</returns>
        int UpdateProject(Project project);
    }
}