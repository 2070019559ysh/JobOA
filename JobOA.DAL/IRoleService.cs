using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL
{
    /// <summary>
    /// 角色信息关联数据库接口
    /// </summary>
    public interface IRoleService
    {
        /// <summary>
        /// 通过Id查找角色信息
        /// </summary>
        /// <returns>角色信息</returns>
        Role SearchRoleById(int id);

        /// <summary>
        /// 查找所有角色信息
        /// </summary>
        /// <returns>所有角色信息列表</returns>
        List<Role> SearchAllRole();

        /// <summary>
        /// 添加角色信息
        /// </summary>
        /// <param name="role">角色信息</param>
        /// <returns>添加的记录数</returns>
        int AddRole(Role role);

        /// <summary>
        /// 删除角色信息
        /// </summary>
        /// <param name="id">角色Id</param>
        /// <returns>删除的记录数</returns>
        int DeleteRole(int id);

        /// <summary>
        /// 更新角色信息
        /// </summary>
        /// <param name="role">新角色信息</param>
        /// <returns>修改的记录数</returns>
        int UpdateRole(Role role);
    }
}