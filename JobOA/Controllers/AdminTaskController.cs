using JobOA.BLL;
using JobOA.Model;
using JobOA.Model.ViewModel;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobOA.Controllers
{
    public class AdminTaskController : Controller
    {
        [Inject]
        public IMajorTaskManager MajorTaskManager { get; set; }

        [Inject]
        public IDepartmentManager DepartmentManager { get; set; }

        [Inject]
        public IProjectManager ProjectManager { get; set; }
        //
        // GET: /AdminTask/
        /// <summary>
        /// 进入主任务首页，可以分页、条件查询，当search为null时显示第一页的记录
        /// </summary>
        /// <param name="search">查询任务条件,格式：pageIndex,pageSize,projectId,departmentId,name</param>
        /// <returns>主任务首页</returns>
        public ActionResult Index(string search)
        {
            //查找所有项目
            List<Project> projectList=ProjectManager.SearchAllProject();
            //查找所有部门
            List<Department> departmentList = DepartmentManager.SearchAllDepartment();
            //按分页、项目、部门和模糊任务名查找主任务
            List<MajorTask> majorTask=MajorTaskManager.SearchAllMajorTask(search);
            ViewBag.Project = projectList;
            ViewBag.Department = departmentList;
            ViewBag.MajorTask = majorTask;
            return View();
        }

    }
}
