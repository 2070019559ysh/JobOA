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

        public ActionResult Index(int? pageIndex,string search)
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
            pager.Remarks = search;
            List<Project> projectList=ProjectManager.SearchProjectByPages(pager);
            ViewData["Pager"] = pager;
            return View(projectList);
        }

        /// <summary>
        /// 进入添加项目页面，给页面传递状态列表数据
        /// </summary>
        /// <returns>添加项目页面</returns>
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

        /// <summary>
        /// 进入添加项目页面，给页面传递状态列表数据
        /// </summary>
        /// <returns>添加项目页面</returns>
        [HttpGet]
        public ActionResult UpdateProject(int? projectId)
        {
            Project project = null;
            if (projectId.HasValue)
            {
                Dictionary<int, string> process = StateData.ProState;
                project = ProjectManager.SearchProjectById(projectId.Value);
                SelectList selectList= new SelectList(process, "Key", "Value",project.State);
                ViewData["list"] = selectList;
            }
            else
            {
                return RedirectToAction("Index","AdminProject");
            }
            return View(project);
        }

        /// <summary>
        /// 执行更新项目
        /// </summary>
        /// <param name="project">新项目信息</param>
        /// <returns>更新项目信息页面</returns>
        [HttpPost]
        public ActionResult UpdateProject(Project project)
        {
            if (ModelState.IsValid)
            {
                if (ProjectManager.UpdateProject(project))
                {
                    ViewBag.mess = "修改公司项目成功！";
                }
                else
                {
                    ViewBag.mess = "未能修改公司项目信息！请重试。";
                }
            }
            return View();
        }

        /// <summary>
        /// 根据projectId获取项目信息
        /// </summary>
        /// <param name="projectId">项目id</param>
        /// <returns>一条项目信息</returns>
        [AllowAnonymous]
        public JsonResult GetProject(int? projectId)
        {
            Project project = null;
            if (projectId.HasValue)
            {
                project = ProjectManager.SearchProjectById(projectId.Value);
            }
            return Json(project);
        }

        public ActionResult DelProject(int? projectId)
        {
            if (projectId.HasValue)
            {
                if (ProjectManager.DeleteProject(projectId.Value))
                {
                    TempData["mess"] = "成功删除一条公司项目信息。";
                }
                else
                {
                    TempData["mess"] = "无法删除这条公司项目信息，请确认是否有所属任务存在！";
                }
            }
            return Redirect("Index");
        }
    }
}
