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
    public class MajorTaskManager
    {
        /// <summary>
        /// 依赖注入主任务关联数据库服务类
        /// </summary>
        [Inject]
        public IMajorTaskService MajorTaskService { get; set; }

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
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " 发生异常：" + ex.Message);
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
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " 发生异常：" + ex.Message);
            }
            return majorTaskList;
        }

        /// <summary>
        /// 根据查询任务条件查找所有主任务
        /// </summary>
        /// <param name="searchCondition">查询任务条件</param>
        /// <returns>所有主任务的集合</returns>
        public List<MajorTask> SearchAllMajorTask(SearchTaskCondition searchCondition)
        {
            List<MajorTask> majorTaskList = null;
            try
            {
                majorTaskList = MajorTaskService.SearchAllMajorTask(searchCondition);
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " 发生异常：" + ex.Message);
            }
            return majorTaskList;
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
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " 发生异常：" + ex.Message);
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
                if (MajorTaskService.AddMajorTask(majorTask) > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " 发生异常：" + ex.Message);
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
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " 发生异常：" + ex.Message);
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
                _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " 发生异常：" + ex.Message);
            }
            return isSuccess;
        }
    }
}
