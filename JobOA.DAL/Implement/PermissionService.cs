using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL.Implement
{
    /// <summary>
    /// Ȩ����Ϣ�������ݿ���
    /// </summary>
    public class PermissionService:IPermissionService
    {
        /// <summary>
        /// ͨ��Id����Ȩ����Ϣ
        /// </summary>
        /// <returns>Ȩ����Ϣ</returns>
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
        /// ͨ���ɷ���·��Id����Ȩ��
        /// </summary>
        /// <param name="pathId">�ɷ���·��Id</param>
        /// <returns>Ȩ����Ϣ</returns>
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
        /// ���Ȩ����Ϣ
        /// </summary>
        /// <param name="permission">Ȩ����Ϣ</param>
        /// <returns>��ӵļ�¼��</returns>
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
        /// ɾ��Ȩ����Ϣ
        /// </summary>
        /// <param name="id">Ȩ��Id</param>
        /// <returns>ɾ���ļ�¼��</returns>
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
        /// ����Ȩ����Ϣ
        /// </summary>
        /// <param name="permission">��Ȩ����Ϣ</param>
        /// <returns>�޸ĵļ�¼��</returns>
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