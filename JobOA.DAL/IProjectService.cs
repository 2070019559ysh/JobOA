using JobOA.Model;
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
        /// <returns>项目信息</returns>
        Project SearchProjectById(int id);

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