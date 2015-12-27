using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.BLL
{
    /// <summary>
    /// ��ɫ��Ϣҵ�����ӿ�
    /// </summary>
    public interface IRoleManager
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
        /// ���ݷ��ʷ�ʽ�ͷ���·�������漰�����н�ɫ
        /// </summary>
        /// <param name="httpMethod">���ʷ�ʽ���磺get,post</param>
        /// <param name="path">����·�����磺/Home/Index</param>
        /// <returns>�漰�����н�ɫ</returns>
        List<Role> SearchRolesByPath(string httpMethod, string path);

        /// <summary>
        /// ���ݷ��ʷ�ʽ�ͷ���·�������漰�����н�ɫId
        /// </summary>
        /// <param name="httpMethod">���ʷ�ʽ���磺get,post</param>
        /// <param name="path">����·�����磺/Home/Index</param>
        /// <returns>�漰�����н�ɫId</returns>
        List<string> SearchRoleIdsByPath(string httpMethod, string path);

        /// <summary>
        /// ��ӽ�ɫ��Ϣ
        /// </summary>
        /// <param name="role">��ɫ��Ϣ</param>
        /// <returns>�Ƿ���ӳɹ�</returns>
        bool AddRole(Role role);

        /// <summary>
        /// ɾ����ɫ��Ϣ
        /// </summary>
        /// <param name="id">��ɫId</param>
        /// <returns>�Ƿ�ɾ���ɹ�</returns>
        bool DeleteRole(int id);

        /// <summary>
        /// ���½�ɫ��Ϣ
        /// </summary>
        /// <param name="role">�½�ɫ��Ϣ</param>
        /// <returns>�Ƿ��޸ĳɹ�</returns>
        bool UpdateRole(Role role);
    }
}