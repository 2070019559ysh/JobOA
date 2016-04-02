using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.Model.ViewModel
{
    /// <summary>
    /// 存储发送消息的必要信息的视图模型
    /// </summary>
    public class MessageViewModel
    {
        /// <summary>
        /// 消息信息对象
        /// </summary>
        public OAMessage OaMess { get; set; }

        /// <summary>
        /// 发送目标用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 发送目标的邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 消息发送方式，请使用alert(弹窗),sms（短信）,email(邮箱)
        /// </summary>
        public string MessType { get; set; }
    }
}
