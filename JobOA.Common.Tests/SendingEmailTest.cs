using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.Common.Tests
{
    /// <summary>
    /// 发送邮件类测试
    /// </summary>
    [TestFixture]
    public class SendingEmailTest
    {
        /// <summary>
        /// 测试发送邮件
        /// </summary>
        [Test]
        public void SendMessageWithAttachmentTest()
        {
            SendingEmail sendEmail = new SendingEmail("smtp.qq.com", "2070019559@qq.com", "503104plkj");
            sendEmail.ToList.Add("clarence_feng@163.com");//2756161282@qq.com//smtp.163.com
            sendEmail.Subject = "迟来的光棍节祝贺";
            sendEmail.Body = "<h4>今天是2015年11月11日，祝单身的我们：光棍节快乐！</h4>";
            sendEmail.FileList.Add("F:\\Test\\happy.gif");
            sendEmail.SendEmailWithAttachment(true);
        }
    }
}
