using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.Common
{
    /// <summary>
    /// 发送Email类
    /// </summary>
    public class SendingEmail
    {
        /// <summary>
        /// 实例化发送Email类，要指定stmp服务地址如：smtp.sina.com.cn，发件人地址及密码
        /// </summary>
        /// <param name="server">smtp服务地址</param>
        /// <param name="from">发件人地址</param>
        /// <param name="password">发件人密码</param>
        public SendingEmail(string server, string from,string password)
        {
            Server = server;
            FromNum = from;
            Password = password;
            ToList = new List<string>();
            FileList = new List<string>();
        }

        /// <summary>
        /// smtp服务地址
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// 发件人地址
        /// </summary>
        public string FromNum { get; set; }

        /// <summary>
        /// 发件人密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 接收人地址集合，可以发给一个或多个人
        /// </summary>
        public List<string> ToList { get; set; }

        /// <summary>
        /// 邮件主题
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 邮件内容
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 附件文件名列表
        /// </summary>
        public List<string> FileList { get; set; }

        /// <summary>
        /// 发送邮件并可发送附件
        /// </summary>
        /// <param name="isBodyHtml">发送的内容是否为html格式</param>
        public void SendEmailWithAttachment(bool isBodyHtml=false)
        {
            // SmtpClient要发送的邮件实例
            MailMessage message = new MailMessage();
            message.From = new MailAddress(FromNum);
            message.Subject = Subject;
            message.SubjectEncoding = Encoding.UTF8; //标题编码
            message.Body = Body;
            message.BodyEncoding = Encoding.UTF8; //邮件内容编码
            message.IsBodyHtml = isBodyHtml;
            foreach (var to in ToList)
            {
                //添加接收人地址
                message.To.Add(new MailAddress(to));
            }
            foreach (var file in FileList)
            {
                //添加附件
                // 为邮件创建文件附件对象
                Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
                // Add time stamp information for the file.
                //为文件添加时间戳信息。
                ContentDisposition disposition = data.ContentDisposition;
                disposition.CreationDate = System.IO.File.GetCreationTime(file);
                disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
                disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
                // Add the file attachment to this e-mail message.
                //将文件附件添加到该电子邮件。
                message.Attachments.Add(data);
                //data.Dispose();
            }
            //创建基于密码的身份验证方案
            NetworkCredential nc = new NetworkCredential(FromNum, Password);
            SmtpClient client = new SmtpClient(Server);
            //表示以当前登录用户的默认凭据进行身份验证
            client.UseDefaultCredentials = true;
            client.Credentials = nc;//设置验证发件人的身份凭证
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;//待发的电子邮件通过网络发送到smtp服务器
            //Send the message.
            //正式发送信息
            client.Send(message);
        }
    }
}
