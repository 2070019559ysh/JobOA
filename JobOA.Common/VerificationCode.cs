using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.Common
{
    public class VerificationCode
    {
        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <param name="codeCount">指定字符个数</param>
        /// <returns>随机字符串</returns>
        public string CreateRandomCode(int codeCount)
        {
            //定义所有字符
            string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            //分割成字符串数组
            string[] allCharArry = allChar.Split(',');
            string randomCode = "";//保存要生成的随机字符串
            int temp = -1;//提示变量
            Random rand = new Random();//以时间作为种子的随机数对象
            for (int i = 0; i < codeCount; i++)//循环指定字符个数的次数
            {
                if (temp != -1)
                {
                    //以当前次数，temp和当前实例时间计时周期数的乘积为种子生成随机数(因为同一时间产生的随机数是一样的，程序运行时基本在同一时间点上)
                    rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(35);//产生0~34的随机数
                if (temp == t)//如果相邻两个随机数相等了，则重新进入一个获取随机字符串的方法
                {//直到要生成的字符串里两两不等了，依次返回该字符串，直到当前第一个方法
                    return CreateRandomCode(codeCount);
                }
                temp = t;//保存生成的随机数，方便与下一个随机数比较是否有重复
                randomCode += allCharArry[t];//把生成的随机数对应一个字符，依次连接成字符串
            }
            return randomCode;//没有出现过相邻重复的随机数,就直接返回
        }
        /// <summary>
        /// 创建验证码图片
        /// </summary>
        /// <param name="validateCode">验证码的字符串</param>
        /// <returns>二进制图片</returns>
        public byte[] CreateValidateGraphic(string validateCode)
        {
            //创建指定wide,height的位图，16.0指定调用double参数的方法
            Bitmap image = new Bitmap((int)Math.Ceiling(validateCode.Length * 17.0), 32);
            Graphics g = Graphics.FromImage(image);//以位图为基础创建绘图图面
            try
            {
                Random random = new Random();
                //用白色清空图片背景
                g.Clear(Color.White);
                //画图片的干扰线，共25条
                for (int i = 0; i < 25; i++)
                {
                    //随机产生图片范围内的两个坐标点
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    //利用绘图对象绘画连接连接两个坐标点的线
                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }
                //创建字体对象，指定字体类型、大小、样式加粗斜体
                Font font = new Font("Arial", 15, (FontStyle.Bold | FontStyle.Italic));
                //创建线性渐变笔刷，指定矩形位置宽度高度、起点颜色、终点颜色、渐变角度、渐变颜色是否受角度影响
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
                //从左上角3,2处开始以创建的字体、笔刷绘画出指定字符串
                g.DrawString(validateCode, font, brush, 3, 2);
                //画图片的前景干扰点
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                //保存图片数据
                MemoryStream stream = new MemoryStream();
                image.Save(stream, ImageFormat.Jpeg);
                //输出图片流
                return stream.ToArray();
            }
            finally
            {
                g.Dispose();//释放由Graphics占用的资源
                image.Dispose();//释放由image占用的资源
            }
        }
    }
}
