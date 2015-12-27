using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.Common.Tests
{
    /// <summary>
    /// 测试异常日志类
    /// </summary>
    [TestFixture]
    class ExceptionLogTest
    {
        private ExceptionLog exceptionLog;

        /// <summary>
        /// 启动测试时进行初始化
        /// </summary>
        [SetUp]
        public void Setup()
        {
            exceptionLog = new ExceptionLog(1);
        }

        /// <summary>
        /// 测试记录日志信息到指定文件
        /// </summary>
        [Test]
        public void RecordLogTest()
        {
            exceptionLog.RecordLog("F:\\Test\\JobOa.log",
                DateTime.Now + " 发生异常了！从数据流中读取每一行，直到文件的最后一行，并在richTextBox1中显示出内容");
            Assert.IsTrue(true);
        }
    }
}
