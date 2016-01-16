using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL.Implement
{
    /// <summary>
    /// ��ɫ��Ϣ�������ݿ���
    /// </summary>
    public class RoleService:IRoleService
    {
        /// <summary>
        /// ͨ��Id���ҽ�ɫ��Ϣ
        /// </summary>
        /// <returns>��ɫ��Ϣ</returns>
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
        /// �������н�ɫ��Ϣ
        /// </summary>
        /// <returns>���н�ɫ��Ϣ�б�</returns>
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
        /// ��ӽ�ɫ��Ϣ
        /// </summary>
        /// <param name="role">��ɫ��Ϣ</param>
        /// <returns>��ӵļ�¼��</returns>
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
        /// ɾ����ɫ��Ϣ
        /// </summary>
        /// <param name="id">��ɫId</param>
        /// <returns>ɾ���ļ�¼��</returns>
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
        /// ���½�ɫ��Ϣ
        /// </summary>
        /// <param name="role">�½�ɫ��Ϣ</param>
        /// <returns>�޸ĵļ�¼��</returns>
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