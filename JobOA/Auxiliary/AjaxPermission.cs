using JobOA.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace JobOA.Auxiliary
{
    /// <summary>
    /// ajax异步请求的权限确认
    /// </summary>
    public class AjaxPermission
    {
        /// <summary>
        /// 确认当前请求是否具有访问权限
        /// </summary>
        /// <param name="httpContext">htt上下文对象</param>
        /// <returns>返回字符串信息，“true”代表有权限访问，其他为无权限的原因</returns>
        public string IsAuthenticated(HttpContextBase httpContext)
        {
            if (httpContext.User.Identity.IsAuthenticated)
            {
                //已经登录，继续确定用户的访问权限
                var roles = GetRolesByResource(httpContext);
                HttpCookie ticketContent = httpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(ticketContent.Value);
                string[] userData = ticket.UserData.Split(',');//当前用户的角色
                string passRole = roles.FirstOrDefault(role => userData.Contains(role));
                //有权访问的角色中其中一个是当前用户具有的，就有权访问，否则没权限访问
                if (passRole == null)
                {
                    // 登录但没权限
                    return "对不起！无权限进行此操作";
                }
            }
            else
            {
                return "未登录，无法确认身份";
            }
            return "true";
        }

        /// <summary>
        /// 根据过滤器上下文包含的当前访问路径信息查找有权访问的角色Id的集合
        /// </summary>
        /// <param name="filterContext">过滤器上下文</param>
        /// <returns>角色Id的集合</returns>
        private IEnumerable<string> GetRolesByResource(HttpContextBase httpContext)
        {
            // 根据资源名称获取授权的角色（该角色被授权使用该资源）

            String method = httpContext.Request.HttpMethod;
            String path = "/" + httpContext.Request.RequestContext.RouteData.Values["Controller"]
            +"/" + httpContext.Request.RequestContext.RouteData.Values["Action"];
            IRoleManager roleResouces = DependencyResolver.Current.GetService<IRoleManager>();
            if (null == roleResouces)
            {
                return new List<string>();
            }
            var roles = roleResouces.SearchRoleIdsByPath(method, path);
            return roles;
        }
    }
}