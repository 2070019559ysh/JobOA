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
    public class AdminUiInfoController : Controller
    {
        [Inject]
        public IOAUiManager OAUiManager { get; set; }
        //
        // GET: /UiInfo/

        /// <summary>
        /// 进入系统界面信息管理首页
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页最大记录数</param>
        /// <param name="search">查询文本</param>
        /// <returns></returns>
        public ActionResult Index(int? pageIndex,int? pageSize,string search)
        {
            pageIndex = pageIndex.HasValue ? pageIndex.Value : 1;
            pageSize = pageSize.HasValue ? pageSize.Value : 10;
            Pager pager = new Pager(pageIndex.Value,pageSize.Value);
            List<OAUi> oaUiList=OAUiManager.SearchOAUiByPager(pager);
            ViewBag.Pager = pager;
            return View(oaUiList);
        }

        /// <summary>
        /// 进入新增系统界面信息页
        /// </summary>
        /// <returns>新增系统界面信息页</returns>
        [HttpGet]
        public ActionResult AddOaui()
        {
            Dictionary<string, string> uiType = StateData.UiType;
            ViewData["list"] = new SelectList(uiType, "Key", "Value");
            return View();
        }

        /// <summary>
        /// 执行新增系统界面信息
        /// </summary>
        /// <param name="oaui">新的系统界面信息</param>
        /// <returns>新增系统界面信息，包含ViewBag.Mess</returns>
        [HttpPost]
        public ActionResult AddOaui(OAUi oaui)
        {
            if (ModelState.IsValid)
            {
                if (OAUiManager.AddOAUi(oaui))
                {
                    ViewBag.Mess = "新增成功。";
                }
                else
                {
                    ViewBag.Mess = "新增失败！";
                }
            }
            return View();
        }

        //
        // GET: /UiInfo/Details/5
        [HttpGet]
        public ActionResult UpdateOaui(int id)
        {
            OAUi oaui=OAUiManager.SearchOAUiById(id);
            return View(oaui);
        }

        [HttpPost]
        public ActionResult UpdateOaui(OAUi oaui)
        {
            if (ModelState.IsValid)
            {
                if (OAUiManager.UpdateOAUi(oaui))
                {
                    ViewBag.Mess = "修改成功。";
                }
                else
                {
                    ViewBag.Mess = "修改失败！";
                }
            }
            return View();
        }

        //
        // GET: /UiInfo/Delete/5

        public ActionResult Delete(int id)
        {
            if (OAUiManager.DeleteOAUi(id))
            {
                ViewBag.Mess = "删除成功。";
            }
            else
            {
                ViewBag.Mess = "删除失败！";
            }
            return View();
        }

        //
        // POST: /UiInfo/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
