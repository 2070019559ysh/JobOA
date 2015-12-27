using JobOA.Common.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.Common.Tests
{
    /// <summary>
    /// 测试发送短信类
    /// </summary>
    [TestFixture]
    class SendingSMSTest
    {
        private SendingSMS sendingSms;
        /// <summary>
        /// 启动测试进行初始化
        /// </summary>
        [SetUp]
        public void Setup()
        {
            sendingSms = new SendingSMS();
        }

        /// <summary>
        /// 测试发送短信(不加密码)
        /// </summary>
        [Test]
        public void SendSMSTest()
        {
            SmsInfo smsInfo=new SmsInfo("2070019559ysh","4bef75049eadb5c29cde",
                "13726216934","您好！欢迎注册破丰软件，您的验证码586922");
            int result=0;
            SendResult sendResult=sendingSms.SendSMS(smsInfo,out result,false);
            Assert.AreEqual(SendResult.成功, sendResult);
        }
        /// <summary>
        /// 测试发送短信(加密)
        /// </summary>
        [Test]
        public void SendSMSEncryptTest()
        {
            SmsInfo smsInfo = new SmsInfo("2070019559ysh", "4bef75049eadb5c29cde",
                "13726215483", "您好！欢迎注册破丰软件，您的验证码586922");
            int result = 0;
            SendResult sendResult = sendingSms.SendSMS(smsInfo, out result);
            Assert.AreEqual(SendResult.成功, sendResult);
        }

        /// <summary>
        /// 测试获取剩余短信数量(不加密)
        /// </summary>
        [Test]
        public void GetSMSNumTest()
        {
            SmsInfo smsInfo = new SmsInfo("2070019559ysh", "4bef75049eadb5c29cde");
            int result = 0;
            SendResult sendResult = sendingSms.GetSMSNum(smsInfo,out result, false);
            Assert.AreEqual(SendResult.成功, sendResult);
        }

        /// <summary>
        /// 测试获取剩余短信数量(加密)
        /// </summary>
        [Test]
        public void GetSMSNumEncryptTest()
        {
            SmsInfo smsInfo = new SmsInfo("2070019559ysh", "4bef75049eadb5c29cde");
            int result = 0;
            SendResult sendResult = sendingSms.GetSMSNum(smsInfo, out result);
            Assert.AreEqual(SendResult.成功, sendResult);
        }
    }
}
