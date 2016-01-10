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
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页最大记录数</param>
        /// <param name="search">查询任务条件,格式：projectId,departmentId,name</param>
        /// <returns>主任务首页</returns>
        public ActionResult Index(Nullable<int> pageIndex,int? pageSize,string search)
        {
            //查找所有项目
            List<Project> projectList=ProjectManager.SearchAllProject();
            //查找所有部门
            List<Department> departmentList = DepartmentManager.SearchAllDepartment();
            //按分页、项目、部门和模糊任务名查找主任务
            if (!pageIndex.HasValue) pageIndex = 1;
            if (!pageSize.HasValue) pageSize = 5;
            if (String.IsNullOrEmpty(search))
            {
                //处理出查询条件
                string[] searchCnds;
                string projectId = "1", departmentId = "1";
                if (projectList.Count > 0)
                    projectId = projectList[0].Id.ToString();
                if (departmentList.Count > 0)
                    departmentId = departmentList[0].Id.ToString();
                searchCnds = new string[] { projectId, departmentId };
                search = String.Join(",", searchCnds);
            }
            List<MajorTask> majorTaskList = MajorTaskManager.SearchAllMajorTask(pageIndex.Value,pageSize.Value,search);
            //视图数据
            Pager pager = new Pager(pageIndex.Value, pageSize.Value, majorTaskList.Count);
            pager.Remarks = search+",";//保存查询条件
            ViewBag.Project = projectList;
            ViewBag.Department = departmentList;
            ViewBag.MajorTask = majorTaskList;
            ViewBag.Pager = pager;
            return View();
        }

    }
}
