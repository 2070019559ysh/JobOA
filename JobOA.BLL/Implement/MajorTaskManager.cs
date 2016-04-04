using JobOA.Common;
using JobOA.DAL;
using JobOA.Model;
using JobOA.Model.ViewModel;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.BLL.Implement
{
    /// <summary>
    /// 主任务业务逻辑类
    /// </summary>
    public class MajorTaskManager:IMajorTaskManager
    {
        /// <summary>
        /// 依赖注入主任务关联数据库服务类
        /// </summary>
        [Inject]
        public IMajorTaskService MajorTaskService { get; set; }

        /// <summary>
        /// 依赖注入员工信息关联数据库服务类
        /// </summary>
        [Inject]
        public IEmployeeManager EmployeeManager { get; set; }

        /// <summary>
        /// 异常处理对象
        /// </summary>
        private readonly ExceptionLog _exceptionLog = new ExceptionLog();

        /// <summary>
        /// 通过Id查找主任务
        /// </summary>
        /// <param name="id">主任务Id</param>
        /// <returns>主任务</returns>
        public MajorTask SearchMajorTaskById(int id)
        {
            MajorTask majorTask = null;
            try
            {
                majorTask=MajorTaskService.SearchMajorTaskById(id);
                if (majorTask.ArrangeEmployee == null)
                {
                    majorTask.ArrangeEmployee = EmployeeManager.SearchEmployeeById(majorTask.ArrangePersonId);
                }
                if (majorTask.CheckEmployee == null)
                {
                    majorTask.CheckEmployee = EmployeeManager.SearchEmployeeById(majorTask.CheckPersonId);
                }
                if (majorTask.ExeEmployee == null)
                {
                    majorTask.ExeEmployee = EmployeeManager.SearchEmployeeById(majorTask.ExePersonId);
                }
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(ex);
            }
            return majorTask;
        }

        /// <summary>
        /// 通过任务名模糊查找主任务
        /// </summary>
        /// <param name="name">主任务名</param>
        /// <returns>主任务集合</returns>
        public List<MajorTask> SearchMajorTaskByName(string name)
        {
            List<MajorTask> majorTaskList = null;
            try
            {
                majorTaskList = MajorTaskService.SearchMajorTaskByName(name);
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(ex);
            }
            return majorTaskList;
        }

        /// <summary>
        /// 根据查询任务条件查找所有主任务
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页最大记录数</param>
        /// <param name="search">查询任务条件,格式：projectId,departmentId,name</param>
        /// <returns>所有主任务的集合</returns>
        public List<MajorTask> SearchAllMajorTask(int pageIndex,int pageSize,string search)
        {
            List<MajorTask> majorTaskList = null;
            try
            {
                if (!String.IsNullOrEmpty(search))
                {   
                    //处理出查询条件
                    string[] searchCnds;
                    searchCnds = search.Split(',');
                    if (searchCnds.Length < 2)//确保2个查询条件
                        searchCnds = new string[] { "1", "1" };
                    int projectId = 1, departmentId = 1;
                    int.TryParse(searchCnds[0], out projectId);
                    int.TryParse(searchCnds[1], out departmentId);
                    //创建条件信息的对象
                    SearchTaskCondition searchCondition = new SearchTaskCondition()
                    {
                        PageIndex = pageIndex,
                        PageMax = pageSize,
                        ProjectId = projectId,
                        DepantmentId = departmentId,
                    }; 
                    if (searchCnds.Length == 2)
                    {   //刚好两个查询条件，第三个默认
                        searchCondition.TaskName = String.Empty;
                    }
                    else
                    {   //第三个查询条件
                        searchCondition.TaskName = searchCnds[2];
                    }
                    majorTaskList = MajorTaskService.SearchAllMajorTask(searchCondition);
                    //查找关联员工信息
                    majorTaskList.ForEach(majorTask =>
                    {
                        if (majorTask.ArrangeEmployee == null)
                        {
                            majorTask.ArrangeEmployee = EmployeeManager.SearchEmployeeById(majorTask.ArrangePersonId);
                        }
                        if (majorTask.CheckEmployee == null)
                        {
                            majorTask.CheckEmployee = EmployeeManager.SearchEmployeeById(majorTask.CheckPersonId);
                        }
                        if (majorTask.ExeEmployee == null)
                        {
                            majorTask.ExeEmployee = EmployeeManager.SearchEmployeeById(majorTask.ExePersonId);
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(ex);
            }
            return majorTaskList;
        }

        /// <summary>
        /// 根据条件查找主任务总记录数
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页最大记录数</param>
        /// <param name="search">查询任务条件,格式：projectId,departmentId,name</param>
        /// <returns>满足条件的主任务总记录数</returns>
        public int SearchAllMajorTaskCount(int pageIndex, int pageSize, string search)
        {
            int count = 0;
            if (!String.IsNullOrEmpty(search))
            {   
                //处理出查询条件
                string[] searchCnds;
                searchCnds = search.Split(',');
                if (searchCnds.Length < 2)//确保2个查询条件
                    searchCnds = new string[] { "1", "1" };
                int projectId = 1, departmentId = 1;
                int.TryParse(searchCnds[0], out projectId);
                int.TryParse(searchCnds[1], out departmentId);
                //创建条件信息的对象
                SearchTaskCondition searchCondition = new SearchTaskCondition()
                {
                    PageIndex = pageIndex,
                    PageMax = pageSize,
                    ProjectId = projectId,
                    DepantmentId = departmentId,
                };
                if (searchCnds.Length == 2)
                {   //刚好两个查询条件，第三个默认
                    searchCondition.TaskName = String.Empty;
                }
                else
                {   //第三个查询条件
                    searchCondition.TaskName = searchCnds[2];
                }
                count = MajorTaskService.SearchAllMajorTaskCount(searchCondition);
            }
            return count;
        }

        /// <summary>
        /// 根据分页查找所有主任务
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageMax">每页最大记录数</param>
        /// <returns>当前页所有主任务的集合</returns>
        public List<MajorTask> SearchAllMajorTask(int pageIndex,int pageMax)
        {
            List<MajorTask> majorTaskList = null;
            try
            {
                majorTaskList = MajorTaskService.SearchAllMajorTask(pageIndex, pageMax);
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(ex);
            }
            return majorTaskList;
        }

        /// <summary>
        /// 添加主任务
        /// </summary>
        /// <param name="majorTask">主任务</param>
        /// <returns>添加记录是否成功</returns>
        public bool AddMajorTask(MajorTask majorTask)
        {
            bool isSuccess = false;
            try
            {
                majorTask.CreateTime = DateTime.Now;
                if (MajorTaskService.AddMajorTask(majorTask) > 0)
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
        /// 删除主任务
        /// </summary>
        /// <param name="id">主任务Id</param>
        /// <returns>删除记录是否成功</returns>
        public bool DeleteMajorTask(int id)
        {
            bool isSuccess = false;
            try
            {
                if (MajorTaskService.DeleteMajorTask(id) > 0)
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
        /// 更新主任务
        /// </summary>
        /// <param name="majorTask">主任务</param>
        /// <returns>修改记录是否成功</returns>
        public bool UpdateMajorTask(MajorTask majorTask)
        {
            bool isSuccess = false;
            try
            {
                if (MajorTaskService.UpdateMajorTask(majorTask) > 0)
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
