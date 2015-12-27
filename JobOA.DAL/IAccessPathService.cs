using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL
{
    /// <summary>
    /// �ɷ���·���������ݿ�ӿ�
    /// </summary>
    public interface IAccessPathService
    {
        /// <summary>
        /// ͨ��Id���ҿɷ���·����Ϣ
        /// </summary>
        /// <returns>�ɷ���·����Ϣ</returns>
        AccessPath SearchAccessPathById(int id);

        /// <summary>
        /// ͨ�����ʷ�ʽ�ͷ���·�����Ҿ���Ŀɷ���·����Ϣ
        /// </summary>
        /// <param name="httpMethod">���ʷ�ʽ���磺get,post</param>
        /// <param name="path">����·�����磺/Home/Index</param>
        /// <returns>�ɷ���·����Ϣ</returns>
        AccessPath SearchAccessPathByPath(string httpMethod, string path);
        /// <summary>
        /// ��ӿɷ���·����Ϣ
        /// </summary>
        /// <param name="accessPath">�ɷ���·����Ϣ</param>
        /// <returns>��ӵļ�¼��</returns>
        int AddAccessPath(AccessPath accessPath);

        /// <summary>
        /// ɾ���ɷ���·����Ϣ
        /// </summary>
        /// <param name="id">�ɷ���·��Id</param>
        /// <returns>ɾ���ļ�¼��</returns>
        int DeleteAccessPath(int id);

        /// <summary>
        /// ���¿ɷ���·����Ϣ
        /// </summary>
        /// <param name="accessPath">�¿ɷ���·����Ϣ</param>
        /// <returns>�޸ĵļ�¼��</returns>
        int UpdateAccessPath(AccessPath accessPath);
    }
}