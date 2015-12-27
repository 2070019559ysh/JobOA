using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL.Implement
{
    /// <summary>
    /// 权限信息关联数据库类
    /// </summary>
    public class PermissionService:IPermissionService
    {
        /// <summary>
        /// 通过Id查找权限信息
        /// </summary>
        /// <returns>权限信息</returns>
        public Permission SearchPermissionById(int id)
        {
            using (OaModel dbContext = new OaModel())
            {
                var permission = from p in dbContext.Permission
                           where p.Id==id
                           select p;
                return permission.SingleOrDefault();
            }
        }

        /// <summary>
        /// 通过可访问路径Id查找权限
        /// </summary>
        /// <param name="pathId">可访问路径Id</param>
        /// <returns>权限信息</returns>
        public Permission SearchPermissionByPathId(int pathId)
        {
            using (OaModel dbContext = new OaModel())
            {
                var permission = from p in dbContext.Permission
                                 where p.AccessPathId.Value==pathId
                                 select p;
                return permission.FirstOrDefault();
            }
        }

        /// <summary>
        /// 添加权限信息
        /// </summary>
        /// <param name="permission">权限信息</param>
        /// <returns>添加的记录数</returns>
        public int AddPermission(Permission permission)
        {
            using (OaModel dbContext = new OaModel())
            {
                dbContext.Permission.Add(permission);
                int rows = dbContext.SaveChanges();
                return rows;
            }
        }

        /// <summary>
        /// 删除权限信息
        /// </summary>
        /// <param name="id">权限Id</param>
        /// <returns>删除的记录数</returns>
        public int DeletePermission(int id)
        {
            using (OaModel dbContext = new OaModel())
            {
                Permission permission = new Permission() { Id = id };
                dbContext.Permission.Attach(permission);
                dbContext.Permission.Remove(permission);
                int rows = dbContext.SaveChanges();
                return rows;
            }
        }

        /// <summary>
        /// 更新权限信息
        /// </summary>
        /// <param name="permission">新权限信息</param>
        /// <returns>修改的记录数</returns>
        public int UpdatePermission(Permission permission)
        {
            using (OaModel dbContext = new OaModel())
            {
                var oldPermission = dbContext.Permission.Find(permission.Id);
                if (oldPermission != null)
                {
                    oldPermission.AccessPathId = permission.AccessPathId;
                    oldPermission.Description = permission.Description;
                    int rows = dbContext.SaveChanges();
                    return rows;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}