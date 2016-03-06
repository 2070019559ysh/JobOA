using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobOA.BLL;
using Ninject;
using JobOA.Model;

namespace JobOA.Controllers
{
    /// <summary>
    /// 行政管理信息处理控制器
    /// </summary>
    public class AdministrationController : Controller
    {
        [Inject]
        public IDepartmentManager DepartmentManager { get; set; }
        //
        // GET: /Administration/

        /// <summary>
        /// 进入部门信息管理页
        /// </summary>
        /// <returns>部门信息管理页</returns>
        public ActionResult Index()
        {
            List<Department> department=DepartmentManager.SearchAllDepartment();
            return View(department);
        }

        /// <summary>
        /// 新增部门信息
        /// </summary>
        /// <param name="department">部门</param>
        /// <returns>是否成功json</returns>
        [HttpGet]
        public ActionResult AddDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                if (DepartmentManager.AddDepartment(department))
                {
                    ViewData["mess"] = "新增部门成功";
                }
                else
                {
                    ViewData["mess"] = "新增部门失败";
                }
            }
            else
            {
                ViewData["mess"] = "部门名称不能多于10个字";
            }
            List<Department> departmentList = DepartmentManager.SearchAllDepartment();
            return View(departmentList);
        }

        /// <summary>
        /// 更新部门信息
        /// </summary>
        /// <param name="department">部门信息</param>
        /// <returns>是否成功json</returns>
        [HttpGet]
        public ActionResult UpdateDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                if (DepartmentManager.UpdateDepartment(department))
                {
                    ViewData["mess"] = "修改部门名称成功";
                }
                else
                {
                    ViewData["mess"] = "修改部门名称失败，请稍后再试";
                }
            }
            else
            {
                ViewData["mess"] = "部门名称不能多于10个字";
            }
            List<Department> departmentList = DepartmentManager.SearchAllDepartment();
            return View(departmentList);
        }

        /// <summary>
        /// 更新部门信息
        /// </summary>
        /// <param name="departmentId">部门信息Id</param>
        /// <returns>是否成功json</returns>
        [HttpGet]
        public ActionResult DelDepartment(int departmentId)
        {
            if (DepartmentManager.DeleteDepartment(departmentId))
            {
                ViewData["mess"] = "删除部门信息成功";
            }
            else
            {
                ViewData["mess"] = "删除部门信息失败，您可以确定部门下没有任务信息后再试";
            }
            List<Department> departmentList = DepartmentManager.SearchAllDepartment();
            return View(departmentList);
        }

    }
}
