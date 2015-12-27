using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.BLL
{
    /// <summary>
    /// 角色信息业务管理接口
    /// </summary>
    public interface IRoleManager
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
        /// 根据访问方式和访问路径查找涉及的所有角色
        /// </summary>
        /// <param name="httpMethod">访问方式，如：get,post</param>
        /// <param name="path">访问路径，如：/Home/Index</param>
        /// <returns>涉及的所有角色</returns>
        List<Role> SearchRolesByPath(string httpMethod, string path);

        /// <summary>
        /// 根据访问方式和访问路径查找涉及的所有角色Id
        /// </summary>
        /// <param name="httpMethod">访问方式，如：get,post</param>
        /// <param name="path">访问路径，如：/Home/Index</param>
        /// <returns>涉及的所有角色Id</returns>
        List<string> SearchRoleIdsByPath(string httpMethod, string path);

        /// <summary>
        /// 添加角色信息
        /// </summary>
        /// <param name="role">角色信息</param>
        /// <returns>是否添加成功</returns>
        bool AddRole(Role role);

        /// <summary>
        /// 删除角色信息
        /// </summary>
        /// <param name="id">角色Id</param>
        /// <returns>是否删除成功</returns>
        bool DeleteRole(int id);

        /// <summary>
        /// 更新角色信息
        /// </summary>
        /// <param name="role">新角色信息</param>
        /// <returns>是否修改成功</returns>
        bool UpdateRole(Role role);
    }
}