using JobOA.BLL;
using JobOA.Model;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobOA.Models
{
    public class EmployeeBinder:IModelBinder
    {

        public Object BindModel(ControllerContext controllerContext, ModelBindingContext modelBingdingContext)
        {
            var employee = (Employee)modelBingdingContext.Model ?? new Employee();
            employee.Id=GetValue<int>(modelBingdingContext,"Id");
            employee.UserName=GetValue<string>(modelBingdingContext,"UserName");
            employee.Email=GetValue<string>(modelBingdingContext,"Email");
            employee.DepartmentId=GetValue<int>(modelBingdingContext,"DepartmentId");
            employee.HeadPicture=GetValue<string>(modelBingdingContext,"HeadPicture");
            employee.Introduction=GetValue<string>(modelBingdingContext,"Introduction");
            employee.RealName = GetValue<string>(modelBingdingContext, "RealName");
            IEmployeeManager employeeManager = DependencyResolver.Current.GetService<IEmployeeManager>();
            Employee emp = employeeManager.SearchEmployeeById(employee.Id);
            employee.IsEnabled = emp.IsEnabled;
            employee.Password = emp.Password;
            employee.RoleIds = emp.RoleIds;
            employee.OnlineState = emp.OnlineState;
            employee.LastLoginTime = emp.LastLoginTime;
            return employee;
        }

        /// <summary>
        /// 获取上下文参数值的泛型辅助方法
        /// </summary>
        /// <typeparam name="T">值的类型</typeparam>
        /// <param name="bindingContext">上下文参数</param>
        /// <param name="key">值的键名</param>
        /// <returns>键的值</returns>
        private T GetValue<T>(ModelBindingContext bindingContext, string key)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(key);
            return (T)valueResult.ConvertTo(typeof(T));
        }
    }
}