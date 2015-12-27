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
    /// ������Ϣҵ�������
    /// </summary>
    public class DepartmentManager:IDepartmentManager
    {
        /// <summary>
        /// Ninjectע��Ĳ�����Ϣ�������ݿ�ӿ�
        /// </summary>
        [Inject]
        public IDepartmentService DepartmentService { get; set; }

        /// <summary>
        /// ͨ��Id���Ҳ�����Ϣ
        /// </summary>
        /// <returns>������Ϣ</returns>
        public Department SearchDepartmentById(int id)
        {
            return DepartmentService.SearchDepartmentById(id);
        }

        /// <summary>
        /// �������в�����Ϣ
        /// </summary>
        /// <returns>���в�����Ϣ�б�</returns>
        public List<Department> SearchAllDepartment()
        {
            return DepartmentService.SearchAllDepartment();
        }

        /// <summary>
        /// ��Ӳ�����Ϣ
        /// </summary>
        /// <param name="department">������Ϣ</param>
        /// <returns>��ӵļ�¼��</returns>
        public int AddDepartment(Department department)
        {
            return DepartmentService.AddDepartment(department);
        }

        /// <summary>
        /// ɾ��������Ϣ
        /// </summary>
        /// <param name="id">����Id</param>
        /// <returns>ɾ���ļ�¼��</returns>
        public int DeleteDepartment(int id)
        {
            return DepartmentService.DeleteDepartment(id);
        }

        /// <summary>
        /// ���²�����Ϣ
        /// </summary>
        /// <param name="department">�²�����Ϣ</param>
        /// <returns>�޸ĵļ�¼��</returns>
        public int UpdateDepartment(Department department)
        {
            return DepartmentService.UpdateDepartment(department);
        }
    }
}