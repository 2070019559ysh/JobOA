using JobOA.Model;
using JobOA.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.DAL
{
    /// <summary>
    /// OA界面信息关联数据库接口
    /// </summary>
    public interface IOAUiService
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
        /// 添加OA界面信息
        /// </summary>
        /// <param name="oaUi">OA界面信息</param>
        /// <returns>添加的记录数</returns>
        int AddOAUi(OAUi oaUi);

        /// <summary>
        /// 删除OA界面信息
        /// </summary>
        /// <param name="id">OA界面Id</param>
        /// <param name="delOaui">删除的oaui对象</param>
        /// <returns>删除的记录数</returns>
        int DeleteOAUi(int id,out OAUi delOaui);

        /// <summary>
        /// 更新OA界面信息
        /// </summary>
        /// <param name="oaUi">新OA界面信息</param>
        /// <returns>修改的记录数</returns>
        int UpdateOAUi(OAUi oaUi);

        /// <summary>
        /// 根据类型查找系统界面信息
        /// </summary>
        /// <param name="type">系统界面信息类型："joboa_System_sms","系统短信配置信息";
        ///"joboa_System_email","系统邮箱配置信息";
        ///"joboa_System_PictureCarousel","系统图片轮播";
        ///"joboa_System_FootHead","系统脚部标题";
        ///"joboa_System_FootContent","系统脚部内容";
        ///"joboa_System_Notice","系统公告";
        ///"joboa_System_InfoList","系统信息列表"</param>
        /// <param name="limit">限制获取的数量,默认是4条记录</param>
        /// <returns>系统界面信息集合</returns>
        List<OAUi> SearchOauiByType(string type, int limit = 4);
    }
}