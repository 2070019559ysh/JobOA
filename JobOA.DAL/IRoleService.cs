using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL
{
    /// <summary>
    /// ��ɫ��Ϣ�������ݿ�ӿ�
    /// </summary>
    public interface IRoleService
    {
        /// <summary>
        /// ͨ��Id���ҽ�ɫ��Ϣ
        /// </summary>
        /// <returns>��ɫ��Ϣ</returns>
        Role SearchRoleById(int id);

        /// <summary>
        /// �������н�ɫ��Ϣ
        /// </summary>
        /// <returns>���н�ɫ��Ϣ�б�</returns>
        List<Role> SearchAllRole();

        /// <summary>
        /// ��ӽ�ɫ��Ϣ
        /// </summary>
        /// <param name="role">��ɫ��Ϣ</param>
        /// <returns>��ӵļ�¼��</returns>
        int AddRole(Role role);

        /// <summary>
        /// ɾ����ɫ��Ϣ
        /// </summary>
        /// <param name="id">��ɫId</param>
        /// <returns>ɾ���ļ�¼��</returns>
        int DeleteRole(int id);

        /// <summary>
        /// ���½�ɫ��Ϣ
        /// </summary>
        /// <param name="role">�½�ɫ��Ϣ</param>
        /// <returns>�޸ĵļ�¼��</returns>
        int UpdateRole(Role role);
    }
}