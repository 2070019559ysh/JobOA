using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL
{
    /// <summary>
    /// ������Ϣ�������ݿ�ӿ�
    /// </summary>
    public interface IDepartmentService
    {
        /// <summary>
        /// ͨ��Id���Ҳ�����Ϣ
        /// </summary>
        /// <returns>������Ϣ</returns>
        Department SearchDepartmentById(int id);

        /// <summary>
        /// �������в�����Ϣ
        /// </summary>
        /// <returns>���в�����Ϣ�б�</returns>
        List<Department> SearchAllDepartment();

        /// <summary>
        /// ��Ӳ�����Ϣ
        /// </summary>
        /// <param name="department">������Ϣ</param>
        /// <returns>��ӵļ�¼��</returns>
        int AddDepartment(Department department);

        /// <summary>
        /// ɾ��������Ϣ
        /// </summary>
        /// <param name="id">����Id</param>
        /// <returns>ɾ���ļ�¼��</returns>
        int DeleteDepartment(int id);

        /// <summary>
        /// ���²�����Ϣ
        /// </summary>
        /// <param name="department">�²�����Ϣ</param>
        /// <returns>�޸ĵļ�¼��</returns>
        int UpdateDepartment(Department department);
    }
}