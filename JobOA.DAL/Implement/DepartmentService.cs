using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL.Implement
{
    /// <summary>
    /// ������Ϣ�������ݿ���
    /// </summary>
    public class DepartmentService:IDepartmentService
    {
        /// <summary>
        /// ͨ��Id���Ҳ�����Ϣ
        /// </summary>
        /// <returns>������Ϣ</returns>
        public Department SearchDepartmentById(int id)
        {
            using (OaModel dbContext = new OaModel())
            {
                var department = from d in dbContext.Department
                                 where d.Id == id
                                 select d;
                return department.SingleOrDefault();
            }
        }

        /// <summary>
        /// �������в�����Ϣ
        /// </summary>
        /// <returns>���в�����Ϣ�б�</returns>
        public List<Department> SearchAllDepartment()
        {
            using (OaModel dbContext = new OaModel())
            {
                var department = from d in dbContext.Department
                                 orderby d.Id ascending
                                 select d;
                return department.ToList();
            }
        }

        /// <summary>
        /// ��Ӳ�����Ϣ
        /// </summary>
        /// <param name="department">������Ϣ</param>
        /// <returns>��ӵļ�¼��</returns>
        public int AddDepartment(Department department)
        {
            using (OaModel dbContext = new OaModel())
            {
                dbContext.Department.Add(department);
                int rows = dbContext.SaveChanges();
                return rows;
            }
        }

        /// <summary>
        /// ɾ��������Ϣ
        /// </summary>
        /// <param name="id">����Id</param>
        /// <returns>ɾ���ļ�¼��</returns>
        public int DeleteDepartment(int id)
        {
            using (OaModel dbContext = new OaModel())
            {
                Department department = new Department() { Id = id };
                dbContext.Department.Attach(department);
                dbContext.Department.Remove(department);
                int rows = dbContext.SaveChanges();
                return rows;
            }
        }

        /// <summary>
        /// ���²�����Ϣ
        /// </summary>
        /// <param name="department">�²�����Ϣ</param>
        /// <returns>�޸ĵļ�¼��</returns>
        public int UpdateDepartment(Department department)
        {
            using (OaModel dbContext = new OaModel())
            {
                var oldDepartment = dbContext.Department.Find(department.Id);
                if (oldDepartment != null)
                {
                    oldDepartment.Name = department.Name;
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