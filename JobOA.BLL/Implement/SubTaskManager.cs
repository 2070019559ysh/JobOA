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
    /// 子任务信息业务处理
    /// </summary>
    public class SubTaskManager:ISubTaskManager
    {
        /// <summary>
        /// 依赖注入主任务关联数据库服务类
        /// </summary>
        [Inject]
        public ISubTaskService SubTaskService { get; set; }

        [Inject]
        public IEmployeeManager EmployeeManager { get; set; }

        [Inject]
        public IProjectManager ProjectManager { get; set; }

        /// <summary>
        /// 异常处理对象
        /// </summary>
        private readonly ExceptionLog _exceptionLog = new ExceptionLog();

        /// <summary>
        /// 通过Id查找子任务
        /// </summary>
        /// <param name="id">子任务Id</param>
        /// <returns>子任务</returns>
        public SubTask SearchSubTaskById(int id)
        {
            SubTask subTask=null;
            try 
	        {	        
		        subTask=SubTaskService.SearchSubTaskById(id);
	        }
	        catch (Exception ex)
	        {
                _exceptionLog.RecordLog(ex);
	        }
            return subTask;
        }

        /// <summary>
        /// 通过任务名模糊查找子任务
        /// </summary>
        /// <param name="name">子任务名</param>
        /// <returns>子任务集合</returns>
        public List<SubTask> SearchSubTaskByName(string name)
        {
            List<SubTask> subTaskList=null;
            try 
	        {	        
		        subTaskList=SubTaskService.SearchSubTaskByName(name);
	        }
	        catch (Exception ex)
	        {
                _exceptionLog.RecordLog(ex);
	        }
            return subTaskList;
        }

        /// <summary>
        /// 根据分页对象信息查找子任务列表信息
        /// </summary>
        /// <param name="id">主任务id</param>
        /// <param name="pager">分页对象信息</param>
        /// <returns>子任务列表信息</returns>
        public List<SubTask> SearchSubTask(int id,Pager pager)
        {
            List<SubTask> subTaskList = null;
            try
            {
                if (pager.Remarks == null) { pager.Remarks = String.Empty; }
                subTaskList=SubTaskService.SearchSubTask(id,pager);
                if (subTaskList != null)
                {
                    //给每条子任务信息添加员工信息并设置头像名为第一张头像
                    subTaskList.ForEach(subtask => {
                        Employee employee = null;
                        employee = EmployeeManager.SearchEmployeeById(subtask.ArrangePersonId);
                        if (employee != null)
                            employee.HeadPicture = HeadPictureHandle.GetFirstHeadPicture(employee.HeadPicture);
                        subtask.ArrangeEmployee = employee;
                        employee = EmployeeManager.SearchEmployeeById(subtask.ExePersonId);
                        if (employee != null)
                            employee.HeadPicture = HeadPictureHandle.GetFirstHeadPicture(employee.HeadPicture);
                        subtask.ExeEmployee = employee;
                        employee = EmployeeManager.SearchEmployeeById(subtask.CheckPersonId);
                        if (employee != null)
                            employee.HeadPicture = HeadPictureHandle.GetFirstHeadPicture(employee.HeadPicture);
                        subtask.CheckEmployee = employee;
                    });
                }
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(ex);
            }
            return subTaskList;
        }

        /// <summary>
        /// 获取子任务的编号No
        /// </summary>
        /// <param name="majorTaskId">主任务Id</param>
        /// <returns>子任务的编号No</returns>
        public string GetSubTaskNo(int majorTaskId)
        {
            string result=String.Empty;
            try
            {
               int count=SubTaskService.SubTaskCountByMajorTask(majorTaskId);
               result = majorTaskId + "-" + (count + 1);
            }
            catch (Exception ex)
            {
                _exceptionLog.RecordLog(ex);
            }
            return result;
        }

        /// <summary>
        /// 添加子任务
        /// </summary>
        /// <param name="SubTask">子任务</param>
        /// <returns>添加的记录是否成功</returns>
        public bool AddSubTask(SubTask subTask)
        {
            bool isSuccess=false;
            try 
	        {	        
		        if(SubTaskService.AddSubTask(subTask)>0){
                    isSuccess=true;
                }
	        }
	        catch (Exception ex)
	        {
                _exceptionLog.RecordLog(ex);
	        }
            return isSuccess;
        }

        /// <summary>
        /// 更加id删除子任务
        /// </summary>
        /// <param name="id">子任务Id</param>
        /// <returns>删除记录是否成功</returns>
        public bool DeleteSubTask(int id)
        {
            bool isSuccess=false;
            try
            {
                if(SubTaskService.DeleteSubTask(id)>0)
                {
                    isSuccess=true;
                }
            }
            catch(Exception ex){
                _exceptionLog.RecordLog(ex);
            }
            return isSuccess;
        }

        /// <summary>
        /// 更新子任务
        /// </summary>
        /// <param name="SubTask">子任务</param>
        /// <returns>修改记录是否成功</returns>
        public bool UpdateSubTask(SubTask subTask)
        {
            bool isSuccess = false;
            try
            {
                if (SubTaskService.UpdateSubTask(subTask) > 0)
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
        /// 根据子任务Id及服务器根路径获取当前项目的附件存放路径
        /// </summary>
        /// <param name="subTaskId">主任务Id</param>
        /// <param name="serverMapPath">服务器根路径</param>
        /// <returns></returns>
        public string GetAttachmentPath(int subTaskId,string serverMapPath)
        {
            Project project = ProjectManager.SearchProjectBySubTaskId(subTaskId);
            string path = project.Name;//把子任务名称作为项目
            if (project == null)
            {
                path = new VerificationCode().CreateRandomCode(12).ToLower();
            }
            string userImg = serverMapPath+"Content/ProjectFile/" + path + "/";//用户上传附件路径
            return path;
        }

        /// <summary>
        /// 更新子任务的附件名,返回是否更新成功
        /// </summary>
        /// <param name="subTaskId">子任务Id</param>
        /// <param name="fileName">附件文件名</param>
        /// <returns>是否更新成功</returns>
        public bool UpdateSubTaskAttachment(int subTaskId, string fileName)
        {
            bool isSuccess = false;
            try
            {
                if (SubTaskService.UpdateSubTaskAttachment(subTaskId,fileName) > 0)
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
