using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.Model.ViewModel
{
    /// <summary>
    /// 查找任务条件
    /// </summary>
    public class SearchTaskCondition
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页最大显示记录数
        /// </summary>
        public int PageMax { get; set; }

        /// <summary>
        /// 任务名
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// 部门Id
        /// </summary>
        public int DepantmentId { get; set; }

        /// <summary>
        /// 项目Id
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// 当前在线员工id
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// 查看类型枚举，0是所有任务，1是我的任务，2是安排的任务
        /// </summary>
        public LookUpMethod LookUpType { get; set; }
    }

    /// <summary>
    /// 查看的方式，0是所有任务，1是我的任务，2是安排的任务
    /// </summary>
    public enum LookUpMethod
    {
        /// <summary>
        /// 所有任务
        /// </summary>
        AllTask=0,
        /// <summary>
        /// 我的任务
        /// </summary>
        MineTask=1,
        /// <summary>
        /// 安排的任务
        /// </summary>
        ArrangeTask=2
    }
}
