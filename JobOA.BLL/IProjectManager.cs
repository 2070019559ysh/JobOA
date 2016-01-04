using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.BLL
{
    /// <summary>
    /// 项目管理业务接口
    /// </summary>
    public interface IProjectManager
    {
        /// <summary>
        /// 通过Id查找项目信息
        /// </summary>
        /// <returns>项目信息</returns>
        Project SearchProjectById(int id);

        /// <summary>
        /// 查找所有项目
        /// </summary>
        /// <returns>所有项目的集合</returns>
        List<Project> SearchAllProject();

        /// <summary>
        /// 添加项目信息
        /// </summary>
        /// <param name="project">项目信息</param>
        /// <returns>添加记录是否成功</returns>
        bool AddProject(Project project);

        /// <summary>
        /// 删除项目信息
        /// </summary>
        /// <param name="id">项目Id</param>
        /// <returns>删除记录是否成功</returns>
        bool DeleteProject(int id);

        /// <summary>
        /// 更新项目信息
        /// </summary>
        /// <param name="project">新项目信息</param>
        /// <returns>修改的记录是否成功</returns>
        bool UpdateProject(Project project);
    }
}
