using JobOA.Model;
using JobOA.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.BLL
{
    /// <summary>
    /// OA界面信息业务逻辑接口
    /// </summary>
    public interface IOAUiManager
    {
        /// <summary>
        /// 通过Id查找OA界面信息
        /// </summary>
        /// <returns>OA界面信息</returns>
        OAUi SearchOAUiById(int id);

        /// <summary>
        /// 通过标题名准确查找OA界面信息
        /// </summary>
        /// <param name="title">标题名，不能模糊匹配</param>
        /// <returns>OA界面信息</returns>
        OAUi SearchOAUiByTitle(string title);

        /// <summary>
        /// 根据分页信息查找所有oa系统界面信息,分页信息里的Remarks指查询标题信息
        /// </summary>
        /// <param name="pager">分页信息对象</param>
        /// <returns>oa系统界面信息集合</returns>
        List<OAUi> SearchOAUiByPager(Pager pager);

        /// <summary>
        /// 发送短信，使用了joboa_System_sms标志的短信账号
        /// </summary>
        /// <param name="smsMob">发送目的号码，多个手机号请用半角逗号隔开</param>
        /// <param name="smsText">短信内容</param>
        /// <returns>是否已经有短信发送成功</returns>
        bool SendSms(string smsMob, string smsText);

        /// <summary>
        /// 发送邮箱信息，使用了joboa_System_email标志的短信账号
        /// </summary>
        /// <param name="toSb">发送给谁的邮箱</param>
        /// <param name="subject">主题</param>
        /// <param name="body">内容</param>
        /// <param name="fileList">附件文件名集合</param>
        /// <returns>是否发送成功</returns>
        bool SendEmail(string toSb, string subject, string body, List<string> fileList = null);

        /// <summary>
        /// 添加OA界面信息
        /// </summary>
        /// <param name="oaUi">OA界面信息</param>
        /// <returns>添加是否成功</returns>
        bool AddOAUi(OAUi oaUi);

        /// <summary>
        /// 删除OA界面信息
        /// </summary>
        /// <param name="id">OA界面Id</param>
        /// <returns>删除是否成功</returns>
        bool DeleteOAUi(int id);

        /// <summary>
        /// 更新OA界面信息
        /// </summary>
        /// <param name="oaUi">新OA界面信息</param>
        /// <returns>修改是否成功</returns>
        bool UpdateOAUi(OAUi oaUi);
    }
}