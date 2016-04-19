using JobOA.Auxiliary;
using JobOA.BLL;
using JobOA.Model;
using JobOA.Model.ViewModel;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobOA.Controllers
{
    public class AdminUiInfoController : Controller
    {
        [Inject]
        public IOAUiManager OAUiManager { get; set; }

        /// <summary>
        /// ajax请求时进行权限确认
        /// </summary>
        AjaxPermission ajaxPerm = new AjaxPermission();
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
            pager.Remarks = search;
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
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddOaui(OAUi oaui,string uiType)
        {
            string selectVal = String.Empty;
            if (ModelState.IsValid)
            {
                oaui.UiTitle = uiType + "*" + oaui.UiTitle;
                if (OAUiManager.AddOAUi(oaui))
                {
                    ViewBag.Mess = "新增成功。";
                }
                else
                {
                    ViewBag.Mess = "新增失败！";
                    if (oaui != null)
                    {
                        int splitIndex = oaui.UiTitle.IndexOf('*');
                        selectVal = oaui.UiTitle.Substring(0, splitIndex);
                        oaui.UiTitle = oaui.UiTitle.Substring(splitIndex + 1);
                    }
                }
            }
            Dictionary<string, string> uiTypes = StateData.UiType;
            ViewData["list"] = new SelectList(uiTypes, "Key", "Value", selectVal);
            return View();
        }

        /// <summary>
        /// 上传系统图片
        /// </summary>
        /// <param name="file">文件对象</param>
        /// <returns>是否上传成功</returns>
        [AllowAnonymous]
        public JsonResult UploadSystemImg(HttpPostedFileBase file)
        {
            string permResult = ajaxPerm.IsAuthenticated(HttpContext);
            if (permResult.Equals("true")&&file != null)
            {
                string userImg = Server.MapPath("~/Content/images/oaui/");//用户上传图片路径
                string fileName;
                if (System.IO.File.Exists(userImg + file.FileName))
                {
                    string extension = Path.GetExtension(file.FileName);//上传文件的拓展名
                    //如果存在同名文件则使用Guid生成的名字
                    fileName = Guid.NewGuid().ToString() + extension;
                }
                else
                {
                    fileName = file.FileName;
                }
                file.SaveAs(userImg + fileName);//保存上传的图片
                return Json(new { result = true, fileName = fileName });
            }
            else
            {
                return Json(new { result = false, reason = permResult });
            }
        }

        /// <summary>
        /// 进入系统信息修改页面，GET: /AdminUiInfo/UpdateOaUi/5
        /// </summary>
        /// <param name="id">系统新id</param>
        /// <returns>系统信息修改页面</returns>
        [HttpGet]
        public ActionResult UpdateOaui(int? id)
        {
            if (!id.HasValue) { return Redirect("~/AdminUiInfo/Index"); }
            OAUi oaui=OAUiManager.SearchOAUiById(id.Value);
            string selectVal = String.Empty;
            if (oaui != null)
            {
                TempData["OriginImg"] = oaui.UiImg;
                int splitIndex = oaui.UiTitle.IndexOf('*');
                if (splitIndex > -1)
                {
                    selectVal = oaui.UiTitle.Substring(0, splitIndex);
                    oaui.UiTitle = oaui.UiTitle.Substring(splitIndex + 1);
                }
                else
                {
                    oaui.UiTitle = String.Empty;
                }
            }
            Dictionary<string, string> uiType = StateData.UiType;
            ViewData["list"] = new SelectList(uiType, "Key", "Value",selectVal);
            return View(oaui);
        }

        /// <summary>
        /// 执行更新系统界面信息操作
        /// </summary>
        /// <param name="oaui">新的oa界面信息</param>
        /// <param name="uiType">系统界面信息类型</param>
        /// <returns>系统信息修改页面</returns>
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdateOaui(OAUi oaui,string uiType)
        {
            string selectVal = String.Empty;
            if (ModelState.IsValid)
            {
                oaui.UiTitle = uiType + "*" + oaui.UiTitle;
                if (OAUiManager.UpdateOAUi(oaui))
                {
                    ViewBag.Mess = "修改成功。";
                    string originImg = TempData["OriginImg"] as string;
                    //删除旧图片
                    if (!String.IsNullOrEmpty(originImg)&&!oaui.UiImg.Equals(originImg))
                    {
                        string oaImgPath = Server.MapPath("~/Content/images/oaui/");//系统图片路径
                        if (System.IO.File.Exists(oaImgPath + originImg))
                        {
                            System.IO.File.Delete(oaImgPath + originImg);
                        }
                    }
                }
                else
                {
                    ViewBag.Mess = "修改失败！";
                    if (oaui != null)
                    {
                        int splitIndex = oaui.UiTitle.IndexOf('*');
                        if (splitIndex > -1)
                        {
                            selectVal = oaui.UiTitle.Substring(0, splitIndex);
                            oaui.UiTitle = oaui.UiTitle.Substring(splitIndex + 1);
                        }
                    }
                }
            }
            Dictionary<string, string> uiTypes = StateData.UiType;
            ViewData["list"] = new SelectList(uiTypes, "Key", "Value", selectVal);
            return View();
        }

        /// <summary>
        /// 根据id删除一条系统界面信息
        /// </summary>
        /// <param name="id">系统界面信息id</param>
        /// <returns>是否删除成功</returns>
        [HttpGet]
        public ActionResult DelOaui(int id)
        {
            string permResult=ajaxPerm.IsAuthenticated(HttpContext);
            if (permResult.Equals("true"))
            {
                OAUi delOaui = null;
                if (OAUiManager.DeleteOAUi(id,out delOaui))
                {
                    TempData["Mess"] = "删除成功。";
                    if (delOaui != null&&!String.IsNullOrEmpty(delOaui.UiImg))
                    {
                        //删除旧图片
                        string oaImgPath = Server.MapPath("~/Content/images/oaui/");//系统图片路径
                        if (System.IO.File.Exists(oaImgPath + delOaui.UiImg))
                        {
                            System.IO.File.Delete(oaImgPath + delOaui.UiImg);
                        }
                    }
                }
                else
                {
                    TempData["Mess"] = "删除失败！";
                }
            }
            return Redirect("/AdminUiInfo/Index");
        }
    }
}
