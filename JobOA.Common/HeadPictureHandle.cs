using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.Common
{
    /// <summary>
    /// 用户头像路径处理类，涉及头像名传实际物理文件名，和实际物理文件名传头像名
    /// </summary>
    public static class HeadPictureHandle
    {
        /// <summary>
        /// 获取多个图片名连接的字符串,图片名包含目录
        /// </summary>
        /// <param name="headImg">多个图片名连接的字符串</param>
        /// <returns>多个图片名（包含目录字符串）连接的字符串</returns>
        public static string GetHeadPicture(string headImg)
        {
            if (String.IsNullOrEmpty(headImg))
            {
                //没有头像，使用默认头像
                headImg = "/Content/images/oaui/default.jpg";
            }
            else
            {
                string[] headImgs = headImg.Split(',');
                for (int i = 0; i < headImgs.Length; i++)
                {
                    headImgs[i] = "/Content/images/userImg/" + headImgs[i];
                }
                headImg = String.Join(",", headImgs);
            }
            return headImg;
        }
        /// <summary>
        /// 获取去掉图片名中的目录字符
        /// </summary>
        /// <param name="headImg">多个图片名（包含目录字符串）连接的字符串</param>
        /// <returns>去掉图片名中的目录字符</returns>
        public static string ResetHeadPicture(string headImg)
        {
            if (!String.IsNullOrEmpty(headImg))
            {
                string[] headImgs = headImg.Split(',');
                if (headImgs.Length == 1 && headImgs[0].Equals("/Content/images/oaui/default.jpg"))
                {
                    //如果使用默认头像，则清空数据
                    headImg = null;
                }
                else
                {
                    for (int i = 0; i < headImgs.Length; i++)
                    {
                        headImgs[i] = Path.GetFileName(headImgs[i]);
                    }
                    headImg = String.Join(",", headImgs);
                }
            }
            return headImg;
        }
    }
}
