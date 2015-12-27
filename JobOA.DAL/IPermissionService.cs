using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL
{
    /// <summary>
    /// 权限信息关联数据库接口
    /// </summary>
    public interface IPermissionService
    {
        /// <summary>
        /// 通过Id查找权限信息
        /// </summary>
        /// <returns>权限信息</returns>
        Permission SearchPermissionById(int id);

        /// <summary>
        /// 通过可访问路径Id查找权限
        /// </summary>
        /// <param name="pathId">可访问路径Id</param>
        /// <returns>权限信息</returns>
        Permission SearchPermissionByPathId(int pathId);
        /// <summary>
        /// 添加权限信息
        /// </summary>
        /// <param name="permission">权限信息</param>
        /// <returns>添加的记录数</returns>
        int AddPermission(Permission permission);

        /// <summary>
        /// 删除权限信息
        /// </summary>
        /// <param name="id">权限Id</param>
        /// <returns>删除的记录数</returns>
        int DeletePermission(int id);

        /// <summary>
        /// 更新权限信息
        /// </summary>
        /// <param name="permission">新权限信息</param>
        /// <returns>修改的记录数</returns>
        int UpdatePermission(Permission permission);
    }
}