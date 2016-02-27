using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobOA.BLL;
using JobOA.Model;
using Ninject;
using System.IO;

namespace JobOA.Controllers
{
    public class PersonalInfoController : Controller
    {
        [Inject]
        public IEmployeeManager EmployeeManager { get; set; }

        [Inject]
        public IDepartmentManager DepartmentManager { get; set; }
        //
        // GET: /PersonalInfo/
        [ActionName("Information")]
        public ActionResult Index()
        {
            string userName=User.Identity.Name;
            Employee employee=EmployeeManager.SearchEmployeeByUserName(userName);
            List<Department> departmentList=DepartmentManager.SearchAllDepartment();
            ViewData["list"] = new SelectList(departmentList, "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        /// <summary>
        /// 员工上传自己的头像图片
        /// </summary>
        /// <param name="file">图片</param>
        /// <returns>是否上传成功</returns>
        [AllowAnonymous]
        public JsonResult UploadImg(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string userImg = Server.MapPath("~/Content/images/userImg/");//用户上传图片路径
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
                Session["user"]=EmployeeManager.AddHeadPicture(User.Identity.Name, fileName);//更新员工头像信息
                file.SaveAs(userImg + fileName);//保存上传的图片
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
    }
}
