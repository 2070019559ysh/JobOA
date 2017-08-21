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
        /// �쳣�������
        /// </summary>
        private readonly ExceptionLog _exceptionLog = new ExceptionLog();

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
        /// <returns>��ӵļ�¼�Ƿ�ɹ�</returns>
        public bool AddDepartment(Department department)
        {
            bool isSuccess = false;
            try
            {
                if (DepartmentService.AddDepartment(department) > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(ex);
            }
            return isSuccess;
        }

        /// <summary>
        /// ɾ��������Ϣ
        /// </summary>
        /// <param name="id">����Id</param>
        /// <returns>ɾ���ļ�¼�Ƿ�ɹ�</returns>
        public bool DeleteDepartment(int id)
        {
            bool isSuccess = false;
            try
            {
                if (DepartmentService.DeleteDepartment(id) > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(ex);
            }
            return isSuccess;
        }

        /// <summary>
        /// ���²�����Ϣ
        /// </summary>
        /// <param name="department">�²�����Ϣ</param>
        /// <returns>�޸ĵļ�¼�Ƿ�ɹ�</returns>
        public bool UpdateDepartment(Department department)
        {
            bool isSuccess = false;
            try
            {
                if (DepartmentService.UpdateDepartment(department) > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(ex);
            }
            return isSuccess;
        }
    }
}