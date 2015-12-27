using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using JobOA.BLL;
using JobOA.Model;

namespace JobOA.Auxiliary
{
    /// <summary>
    /// 权限身份验证特性
    /// </summary>
    public class PermissionAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 没有权限的登录地址
        /// </summary>
        private const string NoAuthority = "/Account/Index";
        private bool _isLogin;

        [Inject]
        public IRoleManager RoleManager { get; set; }

        [Inject]
        public IEmployeeManager EmployeeManager { get; set; }

        /// <summary>
        /// 确定当前用户是否已经登录授权
        /// </summary>
        /// <param name="httpContext">HTTP 上下文，它封装有关单个 HTTP 请求的所有 HTTP 特定的信息。</param>
        /// <returns>总是返回false,目的是执行HandleUnauthorizedRequest，确定访问权限</returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (base.AuthorizeCore(httpContext))//如果用户已经过授权，则为 true；否则为 false。
            {
                // 已经登录授权
                _isLogin = true;
            }
            else
            {
                //未登录授权
                _isLogin = false;
            }
            // AuthorizeCore 返回 false 时会执行HandleUnauthorizedRequest方法，进行访问权限控制
            return false;
        }

        /// <summary>
        /// AuthorizeCore 返回 false 时会执行这个方法,处理未能授权的 HTTP 请求
        /// </summary>
        /// <param name="filterContext">过滤器上下文</param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!_isLogin)
            {
                // 没有登录,进入<forms loginUrl="~/Account/Login" timeout="2880"/>的登录地址
                base.HandleUnauthorizedRequest(filterContext);
                return;
            }
            //已经登录，继续确定用户的访问权限
            var roles = GetRolesByResource(filterContext);
            //有权访问的角色中任何一个是当前用户具有的，就有权访问，否则没权限访问
            if (!roles.Any(role => filterContext.HttpContext.User.IsInRole(role)))
            {
                // 登录但没权限
                filterContext.HttpContext.Response.Redirect(NoAuthority);
            }
        }

        /// <summary>
        /// 根据过滤器上下文包含的当前访问路径信息查找有权访问的角色Id的集合
        /// </summary>
        /// <param name="filterContext">过滤器上下文</param>
        /// <returns>角色Id的集合</returns>
        private IEnumerable<string> GetRolesByResource(AuthorizationContext filterContext)
        {
            // 根据资源名称获取授权的角色（该角色被授权使用该资源）

            String method = filterContext.HttpContext.Request.HttpMethod;
            String path = "/" + filterContext.ActionDescriptor.ControllerDescriptor.ControllerName
                + "/" + filterContext.ActionDescriptor.ActionName;
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