using JobOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL.Implement
{
    /// <summary>
    /// 部门信息关联数据库类
    /// </summary>
    public class DepartmentService:IDepartmentService
    {
        /// <summary>
        /// 通过Id查找部门信息
        /// </summary>
        /// <returns>部门信息</returns>
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
        /// 查找所有部门信息
        /// </summary>
        /// <returns>所有部门信息列表</returns>
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
        /// 添加部门信息
        /// </summary>
        /// <param name="department">部门信息</param>
        /// <returns>添加的记录数</returns>
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
        /// 删除部门信息
        /// </summary>
        /// <param name="id">部门Id</param>
        /// <returns>删除的记录数</returns>
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
        /// 更新部门信息
        /// </summary>
        /// <param name="department">新部门信息</param>
        /// <returns>修改的记录数</returns>
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