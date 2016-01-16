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
    /// ��ɫ��Ϣҵ�������
    /// </summary>
    public class RoleManager:IRoleManager
    {
        /// <summary>
        /// Ninjectע��Ľ�ɫ��Ϣ�������ݿ�ӿ�
        /// </summary>
        [Inject]
        public IRoleService RoleService { get; set; }

        [Inject]
        public IAccessPathService AccessPathService { get; set; }

        [Inject]
        public IPermissionService PermissionService { get; set; }

        /// <summary>
        /// �쳣�������
        /// </summary>
        private readonly ExceptionLog _exceptionLog = new ExceptionLog();

        /// <summary>
        /// ͨ��Id���ҽ�ɫ��Ϣ
        /// </summary>
        /// <returns>��ɫ��Ϣ</returns>
        public Role SearchRoleById(int id)
        {
            Role role=null;
            try {
                role = RoleService.SearchRoleById(id);
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " �����쳣��" + ex.Message);
            }
            return role;
        }

        /// <summary>
        /// ���ݷ��ʷ�ʽ�ͷ���·�������漰�����н�ɫ
        /// </summary>
        /// <param name="httpMethod">���ʷ�ʽ���磺get,post</param>
        /// <param name="path">����·�����磺/Home/Index</param>
        /// <returns>�漰�����н�ɫ</returns>
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
        /// ͨ��Ȩ��Id�������й����Ľ�ɫ
        /// </summary>
        /// <param name="permissionId">Ȩ��Id</param>
        /// <returns>���й����Ľ�ɫ</returns>
        private List<Role> SearchRoleByPermissionId(int permissionId)
        {
            string permId = permissionId.ToString();
            List<Role> roleList = SearchAllRole();
            if (roleList == null) roleList = new List<Role>();
            //�������н�ɫ��ɾ����ָ��Ȩ��Id�޹صĽ�ɫ
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
        /// ���ݷ��ʷ�ʽ�ͷ���·�������漰�����н�ɫId
        /// </summary>
        /// <param name="httpMethod">���ʷ�ʽ���磺get,post</param>
        /// <param name="path">����·�����磺/Home/Index</param>
        /// <returns>�漰�����н�ɫId</returns>
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
        /// �������н�ɫ��Ϣ
        /// </summary>
        /// <returns>���н�ɫ��Ϣ�б�</returns>
        public List<Role> SearchAllRole()
        {
            List<Role> roleList = null;
            try
            {
                roleList = RoleService.SearchAllRole();
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " �����쳣��" + ex.Message);
            }
            return roleList;
        }

        /// <summary>
        /// ��ӽ�ɫ��Ϣ
        /// </summary>
        /// <param name="role">��ɫ��Ϣ</param>
        /// <returns>�Ƿ���ӳɹ�</returns>
        public bool AddRole(Role role)
        {
            bool isSuccess = false;
            try
            {
                isSuccess = RoleService.AddRole(role)>0;
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " �����쳣��" + ex.Message);
            }
            return isSuccess;
        }

        /// <summary>
        /// ɾ����ɫ��Ϣ
        /// </summary>
        /// <param name="id">��ɫId</param>
        /// <returns>�Ƿ�ɾ���ɹ�</returns>
        public bool DeleteRole(int id)
        {
            bool isSuccess = false;
            try
            {
                isSuccess = RoleService.DeleteRole(id) > 0;
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " �����쳣��" + ex.Message);
            }
            return isSuccess;
        }

        /// <summary>
        /// ���½�ɫ��Ϣ
        /// </summary>
        /// <param name="role">�½�ɫ��Ϣ</param>
        /// <returns>�Ƿ��޸ĳɹ�</returns>
        public bool UpdateRole(Role role)
        {
            bool isSuccess = false;
            try
            {
                isSuccess = RoleService.UpdateRole(role) > 0;
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " �����쳣��" + ex.Message);
            }
            return isSuccess;
        }
    }
}