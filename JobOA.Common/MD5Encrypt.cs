using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JobOA.Common
{
    /// <summary>
    /// MD5加密类
    /// </summary>
    public class MD5Encrypt
    {
        /// <summary>
        /// 把字符串进行32位MD5加密
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <returns>加密的字符串</returns>
        public static String ConvertMD5String(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] strByte=Encoding.Default.GetBytes(str);
            byte[] md5Data=md5.ComputeHash(strByte);
            md5.Clear();
            StringBuilder strBuilder = new StringBuilder();
            for (var i = 0; i < md5Data.Length; i++)
            {
                strBuilder.Append(md5Data[i].ToString("X2"));
            }
            return strBuilder.ToString();
        }
    }
}
