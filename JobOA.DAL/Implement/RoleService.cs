using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL.Implement
{
    /// <summary>
    /// 角色信息关联数据库类
    /// </summary>
    public class RoleService:IRoleService
    {
        /// <summary>
        /// 通过Id查找角色信息
        /// </summary>
        /// <returns>角色信息</returns>
        public Role SearchRoleById(int id)
        {
            using (OaModel dbContext = new OaModel())
            {
                var role = from r in dbContext.Role
                                 where r.Id == id
                                 select r;
                return role.SingleOrDefault();
            }
        }

        /// <summary>
        /// 查找所有角色信息
        /// </summary>
        /// <returns>所有角色信息列表</returns>
        public List<Role> SearchAllRole()
        {
            using (OaModel dbContext = new OaModel())
            {
                var role = from r in dbContext.Role
                           orderby r.Id ascending
                           select r;
                return role.ToList();
            }
        }

        /// <summary>
        /// 添加角色信息
        /// </summary>
        /// <param name="role">角色信息</param>
        /// <returns>添加的记录数</returns>
        public int AddRole(Role role)
        {
            using (OaModel dbContext = new OaModel())
            {
                dbContext.Role.Add(role);
                int rows = dbContext.SaveChanges();
                return rows;
            }
        }

        /// <summary>
        /// 删除角色信息
        /// </summary>
        /// <param name="id">角色Id</param>
        /// <returns>删除的记录数</returns>
        public int DeleteRole(int id)
        {
            using (OaModel dbContext = new OaModel())
            {
                Role role = new Role() { Id = id };
                dbContext.Role.Attach(role);
                dbContext.Role.Remove(role);
                int rows = dbContext.SaveChanges();
                return rows;
            }
        }

        /// <summary>
        /// 更新角色信息
        /// </summary>
        /// <param name="role">新角色信息</param>
        /// <returns>修改的记录数</returns>
        public int UpdateRole(Role role)
        {
            using (OaModel dbContext = new OaModel())
            {
                var oldRole = dbContext.Role.Find(role.Id);
                if (oldRole != null) { 
                    oldRole.Name = role.Name;
                    oldRole.IsEnabled = role.IsEnabled;
                    oldRole.PermissionIds = role.PermissionIds;
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