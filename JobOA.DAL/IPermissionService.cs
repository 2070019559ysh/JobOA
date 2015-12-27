using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL
{
    /// <summary>
    /// Ȩ����Ϣ�������ݿ�ӿ�
    /// </summary>
    public interface IPermissionService
    {
        /// <summary>
        /// ͨ��Id����Ȩ����Ϣ
        /// </summary>
        /// <returns>Ȩ����Ϣ</returns>
        Permission SearchPermissionById(int id);

        /// <summary>
        /// ͨ���ɷ���·��Id����Ȩ��
        /// </summary>
        /// <param name="pathId">�ɷ���·��Id</param>
        /// <returns>Ȩ����Ϣ</returns>
        Permission SearchPermissionByPathId(int pathId);
        /// <summary>
        /// ���Ȩ����Ϣ
        /// </summary>
        /// <param name="permission">Ȩ����Ϣ</param>
        /// <returns>��ӵļ�¼��</returns>
        int AddPermission(Permission permission);

        /// <summary>
        /// ɾ��Ȩ����Ϣ
        /// </summary>
        /// <param name="id">Ȩ��Id</param>
        /// <returns>ɾ���ļ�¼��</returns>
        int DeletePermission(int id);

        /// <summary>
        /// ����Ȩ����Ϣ
        /// </summary>
        /// <param name="permission">��Ȩ����Ϣ</param>
        /// <returns>�޸ĵļ�¼��</returns>
        int UpdatePermission(Permission permission);
    }
}