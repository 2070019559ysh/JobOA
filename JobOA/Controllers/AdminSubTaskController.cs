using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobOA.Model;
using JobOA.BLL;
using Ninject;
using JobOA.Model.ViewModel;
using System.IO;
using JobOA.Common;

namespace JobOA.Controllers
{
    /// <summary>
    /// 管理子任务信息控制器
    /// </summary>
    public class AdminSubTaskController : Controller
    {
        [Inject]
        public ISubTaskManager SubTaskManager { get; set; }

        [Inject]
        public IEmployeeManager EmployeeManager { get; set; }

        [Inject]
        public IMajorTaskManager MajorTaskManager { get; set; }

        [Inject]
        public IDepartmentManager DepartmentManager { get; set; }

        [Inject]
        public IProjectManager ProjectManager { get; set; }
        //
        // GET: /AdminSubTask/

        /// <summary>
        /// 进入子任务列表主页
        /// </summary>
        /// <param name="id">所属主任务id</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="search">查找内容</param>
        /// <returns></returns>
        public ActionResult Index(int? id,int? pageIndex,int? pageSize,string search)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (!pageSize.HasValue)
            {
                pageSize = 10;
            }
            Pager pager = new Pager(pageIndex.Value,pageSize.Value);
            pager.Remarks = search;
            List<SubTask> subTaskList=null;
            if (id.HasValue)
            {
                subTaskList = SubTaskManager.SearchSubTask(id.Value, pager);
            }
            ViewData["Pager"] = pager;
            return View(subTaskList);
        }

        /// <summary>
        /// 根据参与员工id,多个用，分隔 显示参与员工信息分布视图
        /// </summary>
        /// <param name="employeeIds">员工id,多个用，分隔</param>
        /// <returns>参与员工信息分布视图</returns>
        [AllowAnonymous]
        public ActionResult GetParticipatorInfo(string employeeIds)
        {
            List<Employee> employeeList = new List<Employee>();
            if (employeeIds != null)
            {
                string[] ids = employeeIds.Split(',');
                foreach (var id in ids)
                {
                    Employee employee = EmployeeManager.SearchEmployeeById(Convert.ToInt32(id));
                    employeeList.Add(employee);
                }
            }
            return PartialView("ParticipatorView", employeeList);
        }

        /// <summary>
        /// 进入添加子任务信息页面，给页面传递状态列表数据
        /// </summary>
        /// <returns>添加子任务信息页面</returns>
        [HttpGet]
        public ActionResult AddRecord()
        {
            Dictionary<int, string> process = StateData.ProState;
            ViewData["list"] = new SelectList(process, "Key", "Value");
            //查找所有部门
            List<Department> departmentList = DepartmentManager.SearchAllDepartment();
            ViewData["departmentList"] = departmentList;
            if (departmentList != null && departmentList.Count > 0)
            {
                List<Employee> employeeList = EmployeeManager.SearchEmployeeByDeparementId(departmentList[0].Id);
                ViewData["employeeList"] = employeeList;
            }
            Employee emp = Session["user"] as Employee;
            int empDepId=emp.DepartmentId;
            List<MajorTask> recordList = MajorTaskManager.SearchAllMajorTask(empDepId);
            ViewData["TaskList"] = recordList;
            return View("AddSubTask");
        }

        /// <summary>
        /// 执行新增子任务信息
        /// </summary>
        /// <param name="record">新子任务信息</param>
        /// <returns>新增页面</returns>
        [HttpPost]
        public ActionResult AddRecord(SubTask record)
        {
            if (ModelState.IsValid)
            {
                record.No = SubTaskManager.GetSubTaskNo(record.TaskId);
                record.CreateTime = DateTime.Now;
                record.Attachment = "";
                if (SubTaskManager.AddSubTask(record))
                {
                    ViewBag.mess = "新增子任务成功！";
                }
                else
                {
                    ViewBag.mess = "未能新增子任务！请稍后重试。";
                }
            }
            Dictionary<int, string> process = StateData.ProState;
            ViewData["list"] = new SelectList(process, "Key", "Value");
            //查找所有部门
            List<Department> departmentList = DepartmentManager.SearchAllDepartment();
            ViewData["departmentList"] = departmentList;
            if (departmentList != null && departmentList.Count > 0)
            {
                List<Employee> employeeList = EmployeeManager.SearchEmployeeByDeparementId(departmentList[0].Id);
                ViewData["employeeList"] = employeeList;
            }
            Employee emp = Session["user"] as Employee;
            int empDepId = emp.DepartmentId;
            List<MajorTask> recordList = MajorTaskManager.SearchAllMajorTask(empDepId);
            ViewData["TaskList"] = recordList;
            return View("AddSubTask");
        }

        /// <summary>
        /// 员工上传子任务附件
        /// </summary>
        /// <param name="file">子任务附件</param>
        /// <returns>是否上传成功</returns>
        [AllowAnonymous]
        public JsonResult UploadAttachment(HttpPostedFileBase file)
        {
            if (file != null)
            {
                HttpCookie cookie = Request.Cookies["SubTaskId"];
                int subTaskId=0;
                string subTaskIdStr = cookie.Value;
                int.TryParse(subTaskIdStr,out subTaskId);
                string filePath=SubTaskManager.GetAttachmentPath(subTaskId,Server.MapPath("~/"));//用户上传附件路径
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fileName;
                if (System.IO.File.Exists(filePath + file.FileName))
                {
                    string extension = Path.GetExtension(file.FileName);//上传文件的拓展名
                    //如果存在同名文件则使用Guid生成的名字
                    fileName = Guid.NewGuid().ToString() + extension;
                }
                else
                {
                    fileName = file.FileName;
                }
                SubTaskManager.UpdateSubTaskAttachment(subTaskId, fileName);//更新员工头像信息
                file.SaveAs(filePath + fileName);//保存上传的图片
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        /// <summary>
        /// 进入添加子任务信息页面，给页面传递状态列表数据
        /// </summary>
        /// <returns>添加子任务信息页面</returns>
        [HttpGet]
        public ActionResult UpdateRecord(int? id)
        {
            SubTask record = null;
            if (id.HasValue)
            {
                Dictionary<int, string> process = StateData.ProState;
                record = SubTaskManager.SearchSubTaskById(id.Value);
                SelectList selectList = new SelectList(process, "Key", "Value", record.State);
                ViewData["list"] = selectList;
            }
            else
            {
                return RedirectToAction("Index");
            }
            return View(record);
        }

        /// <summary>
        /// 执行更新子任务信息
        /// </summary>
        /// <param name="record">新子任务信息</param>
        /// <returns>更新子任务信息页面</returns>
        [HttpPost]
        public ActionResult UpdateRecord(SubTask record)
        {
            if (ModelState.IsValid)
            {
                if (SubTaskManager.UpdateSubTask(record))
                {
                    ViewBag.mess = "修改子任务信息成功！";
                }
                else
                {
                    ViewBag.mess = "未能修改子任务信息！请重试。";
                }
            }
            return View();
        }

        /// <summary>
        /// 根据子任务id获取子任务信息
        /// </summary>
        /// <param name="id">子任务id</param>
        /// <returns>一条项目信息</returns>
        [AllowAnonymous]
        public JsonResult GetRecord(int? id)
        {
            SubTask record = null;
            if (id.HasValue)
            {
                record = SubTaskManager.SearchSubTaskById(id.Value);
            }
            return Json(record);
        }

        public ActionResult DelRecord(int? id)
        {
            if (id.HasValue)
            {
                if (SubTaskManager.DeleteSubTask(id.Value))
                {
                    TempData["mess"] = "成功删除一条子任务信息。";
                }
                else
                {
                    TempData["mess"] = "无法删除这条子任务信息，请确认是否有每日更新消息存在！";
                }
            }
            return Redirect("Index");
        }
    }
}
