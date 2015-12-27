using JobOA.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobOA.Auxiliary
{
    /// <summary>
    /// 自定义异常特性
    /// </summary>
    public class ExceptionFilterAttribute : FilterAttribute, IExceptionFilter
    {
        /// <summary>
        /// 异常处理对象
        /// </summary>
        private readonly ExceptionLog _exceptionLog = new ExceptionLog();

        /// <summary>
        /// 在控制器异常发生时，对捕获的异常进行处理
        /// </summary>
        /// <param name="filterContext">异常过滤器上下文对象</param>
        public void OnException(ExceptionContext filterContext)
        {
            _exceptionLog.RecordLog(_exceptionLog.LogFileName, DateTime.Now + " 发生异常：" + filterContext.Exception.Message);
            UrlHelper url = new UrlHelper(filterContext.RequestContext);
            filterContext.ExceptionHandled = true;
            filterContext.Result = new RedirectResult(url.Action("Error","ErrorCatch"));
        }

    }
}