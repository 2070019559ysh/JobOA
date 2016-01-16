using JobOA.Common;
using JobOA.DAL;
using JobOA.Model;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.BLL.Implement
{
    /// <summary>
    /// 角色信息业务管理类
    /// </summary>
    public class RoleManager:IRoleManager
    {
        /// <summary>
        /// Ninject注册的角色信息关联数据库接口
        /// </summary>
        [Inject]
        public IRoleService RoleService { get; set; }

        [Inject]
        public IAccessPathService AccessPathService { get; set; }

        [Inject]
        public IPermissionService PermissionService { get; set; }

        /// <summary>
        /// 异常处理对象
        /// </summary>
        private readonly ExceptionLog _exceptionLog = new ExceptionLog();

        /// <summary>
        /// 通过Id查找角色信息
        /// </summary>
        /// <returns>角色信息</returns>
        public Role SearchRoleById(int id)
        {
            Role role=null;
            try {
                role = RoleService.SearchRoleById(id);
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " 发生异常：" + ex.Message);
            }
            return role;
        }

        /// <summary>
        /// 根据访问方式和访问路径查找涉及的所有角色
        /// </summary>
        /// <param name="httpMethod">访问方式，如：get,post</param>
        /// <param name="path">访问路径，如：/Home/Index</param>
        /// <returns>涉及的所有角色</returns>
        public List<Role> SearchRolesByPath(string httpMethod, string path)
        {
            AccessPath accessPath=AccessPathService.SearchAccessPathByPath(httpMethod, path);
            List<Role> roleList = new List<Role>();
            if (accessPath != null)
            {
                Permission perm = PermissionService.SearchPermissionByPathId(accessPath.AccessPathId);
                roleList = SearchRoleByPermissionId(perm.Id);
            }
            return roleList;
        }

        /// <summary>
        /// 通过权限Id查找所有关联的角色
        /// </summary>
        /// <param name="permissionId">权限Id</param>
        /// <returns>所有关联的角色</returns>
        private List<Role> SearchRoleByPermissionId(int permissionId)
        {
            string permId = permissionId.ToString();
            List<Role> roleList = SearchAllRole();
            if (roleList == null) roleList = new List<Role>();
            //遍历所有角色，删除与指定权限Id无关的角色
            for (int i = 0; i < roleList.Count; i++)
            {
                if (roleList[i].PermissionIds == null)
                {
                    roleList.RemoveAt(i);
                    i--;
                }
                else
                {
                    string[] roleIds = roleList[i].PermissionIds.Split(',');
                    if (!roleIds.Contains(permId))
                    {
                        roleList.RemoveAt(i);
                        i--;
                    }
                }
            }
            return roleList;
        }

        /// <summary>
        /// 根据访问方式和访问路径查找涉及的所有角色Id
        /// </summary>
        /// <param name="httpMethod">访问方式，如：get,post</param>
        /// <param name="path">访问路径，如：/Home/Index</param>
        /// <returns>涉及的所有角色Id</returns>
        public List<string> SearchRoleIdsByPath(string httpMethod, string path)
        {
            List<Role> roleList=SearchRolesByPath(httpMethod, path);
            List<string> roleIdList = new List<string>();
            foreach (var role in roleList)
            {
                roleIdList.Add(role.Id.ToString());
            }
            return roleIdList;
        }

        /// <summary>
        /// 查找所有角色信息
        /// </summary>
        /// <returns>所有角色信息列表</returns>
        public List<Role> SearchAllRole()
        {
            List<Role> roleList = null;
            try
            {
                roleList = RoleService.SearchAllRole();
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " 发生异常：" + ex.Message);
            }
            return roleList;
        }

        /// <summary>
        /// 添加角色信息
        /// </summary>
        /// <param name="role">角色信息</param>
        /// <returns>是否添加成功</returns>
        public bool AddRole(Role role)
        {
            bool isSuccess = false;
            try
            {
                isSuccess = RoleService.AddRole(role)>0;
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " 发生异常：" + ex.Message);
            }
            return isSuccess;
        }

        /// <summary>
        /// 删除角色信息
        /// </summary>
        /// <param name="id">角色Id</param>
        /// <returns>是否删除成功</returns>
        public bool DeleteRole(int id)
        {
            bool isSuccess = false;
            try
            {
                isSuccess = RoleService.DeleteRole(id) > 0;
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " 发生异常：" + ex.Message);
            }
            return isSuccess;
        }

        /// <summary>
        /// 更新角色信息
        /// </summary>
        /// <param name="role">新角色信息</param>
        /// <returns>是否修改成功</returns>
        public bool UpdateRole(Role role)
        {
            bool isSuccess = false;
            try
            {
                isSuccess = RoleService.UpdateRole(role) > 0;
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " 发生异常：" + ex.Message);
            }
            return isSuccess;
        }
    }
}