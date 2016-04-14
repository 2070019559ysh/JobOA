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

        /// <summary>
        /// 系统界面类型
        /// </summary>
        public static Dictionary<string, string> UiType { get; set; }

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
            UiType = new Dictionary<string, string>()
            {
                {"joboa_System_sms","系统短信配置信息"},
                {"joboa_System_email","系统邮箱配置信息"},
                {"joboa_System_PictureCarousel","系统图片轮播"},
                {"joboa_System_FootHead","系统脚部标题"},
                {"joboa_System_FootContent","系统脚部内容"},
                {"joboa_System_Notice","系统公告"},
                {"joboa_System_InfoList","系统信息列表"}
            };
        }
    }
}
