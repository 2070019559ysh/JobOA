using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.BLL
{
    /// <summary>
    /// ������Ϣҵ�����ӿ�
    /// </summary>
    public interface IDepartmentManager
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
        /// <returns>��ӵļ�¼�Ƿ�ɹ�</returns>
        bool AddDepartment(Department department);

        /// <summary>
        /// ɾ��������Ϣ
        /// </summary>
        /// <param name="id">����Id</param>
        /// <returns>ɾ���ļ�¼�Ƿ�ɹ�</returns>
        bool DeleteDepartment(int id);

        /// <summary>
        /// ���²�����Ϣ
        /// </summary>
        /// <param name="department">�²�����Ϣ</param>
        /// <returns>�޸ĵļ�¼�Ƿ�ɹ�</returns>
        bool UpdateDepartment(Department department);
    }
}