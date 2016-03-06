using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.Common.Tests
{
    [TestFixture]
    public class MD5EncryptTest
    {
        /// <summary>
        /// 测试把字符串进行32位MD5加密
        /// </summary>
        [Test]
        public void ConvertMD5String()
        {
            string expected="2070019559plkj";
            string md5str=MD5Encrypt.ConvertMD5String(expected);
            Assert.IsNotNullOrEmpty(md5str);
            Assert.AreNotEqual(expected, md5str);
        }
    }
}
