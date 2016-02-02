using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobOA.BLL;
using Ninject;
using JobOA.Model.ViewModel;
using JobOA.Model;

namespace JobOA.Controllers
{
    public class AdminProjectController : Controller
    {
        /// <summary>
        /// 依赖项目信息业务处理
        /// </summary>
        [Inject]
        public IProjectManager ProjectManager { get; set; }

        public ActionResult Index(int? pageIndex,string projectName)
        {
            Pager pager;
            if (pageIndex.HasValue)
            {
                pager=new Pager(pageIndex.Value,10);
            }
            else
            {
                pager = new Pager(1, 10);
            }
            pager.Remarks = projectName;
            List<Project> projectList=ProjectManager.SearchProjectByPages(pager);
            ViewData["Pager"] = pager;
            return View(projectList);
        }

        [HttpGet]
        public ActionResult AddProject()
        {
            Dictionary<int, string> process = StateData.ProState;
            ViewData["list"] = new SelectList(process, "Key", "Value");
            return View();
        }

        /// <summary>
        /// 执行新增项目
        /// </summary>
        /// <param name="project">新项目信息</param>
        /// <returns>新增页面</returns>
        [HttpPost]
        public ActionResult AddProject(Project project)
        {
            if (ModelState.IsValid)
            {
                if (ProjectManager.AddProject(project))
                {
                    ViewBag.mess = "新增公司项目成功！";
                }
                else
                {
                    ViewBag.mess = "未能新增公司项目！请重试。";
                }
            }
            return View();
        }

    }
}
