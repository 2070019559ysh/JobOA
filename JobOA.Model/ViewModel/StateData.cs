using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.Model.ViewModel
{
    /// <summary>
    /// 固定数据
    /// </summary>
    public static class StateData
    {
        /// <summary>
        /// 项目或任务的进度字典
        /// </summary>
        public static Dictionary<int,string> ProState { get; set; }

        static StateData()
        {
            ProState = new Dictionary<int, string>()
            {
                {0,"未完成"},
                {1,"已完成"},
                {2,"已验收"},
                {3,"验收不通过"},
                {4,"终止"}
            };
        }
    }
}
