using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;

namespace JobOA.Common
{
    /// <summary>
    /// 异常日志类，提供把异常信息记录到指定的文件功能
    /// </summary>
    public class ExceptionLog
    {
        /// <summary>
        /// 配置文件中指定的日志文件名
        /// </summary>
        private string _logFileName;

        /// <summary>
        /// 获取配置文件中指定的日志文件名，配置文件中没设置则使用默认值
        /// </summary>
        public string LogFileName
        {
            get 
            {
                if (ConfigurationManager.AppSettings["LogFileName"] != null)
                {
                    _logFileName = ConfigurationManager.AppSettings["LogFileName"].ToString();
                }
                else
                {
                    //配置文件中不指定系统日志文件，则使用默认文件
                    string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                    //取得值file:///D:/C#/PathTest/TestProject1/bin/Debug/TestProject1.DLL
                    //去掉头八个字符file///
                    codeBase = codeBase.Substring(8, codeBase.Length - 8);
                    _logFileName = codeBase.Remove(codeBase.IndexOf("/bin")) + "/JobOA.log";
                }
                return _logFileName;
            }
        }

        /// <summary>
        /// 无参构造函数，默认日志文件最大值100KB
        /// </summary>
        public ExceptionLog()
        {
            this.MaxSize = 100;
        }

        /// <summary>
        /// 有参构造函数，限制日志文件最大值KB
        /// </summary>
        /// <param name="maxSize">日志文件最大值KB</param>
        public ExceptionLog(int maxSize)
        {
            this.MaxSize = maxSize;
        }

        /// <summary>
        /// 日志文件的最大KB
        /// </summary>
        public int MaxSize { get; set; }

        /// <summary>
        /// 创建文件所在目录的路径
        /// </summary>
        /// <param name="fileName">包括路径的文件名</param>
        public void CreatePath(string fileName){
            //文件的目录不存在就创建
            int length=fileName.LastIndexOf('\\');//路径长度
            if(length<0){
                length=fileName.LastIndexOf('/');
            }
            string directory = fileName.Substring(0, length);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        /// <summary>
        /// 记录日志信息到指定文件
        /// </summary>
        /// <param name="fileName">文件路径名</param>
        /// <param name="exceptionMess">要记录的异常信息</param>
        /// <returns>是否成功记录到文件中</returns>
        public void RecordLog(string fileName,string exceptionMess)
        {
            //打开或创建文件,限制文件大小
            CreatePath(fileName);
            if (!File.Exists(fileName))
            {
                FileStream fileStream = new FileStream(fileName, FileMode.Create);
                fileStream.Dispose();
                fileStream.Close();
            }
            //判断文件大小，超过指定KB就删除掉一半信息
            FileInfo fileInfo = new FileInfo(fileName);
            if (fileInfo.Length > MaxSize * 1024)
            {
                //删除掉一半文件信息
                List<string> strList = ReadLines(fileName);//暂存原文件的每行信息
                strList.RemoveRange(0, strList.Count / 2);//删除掉一半信息
                WriteLines(fileName, strList);
            }
            WriteLine(fileName, exceptionMess);
        }

        /// <summary>
        /// 一行行读取文件数据，按行添加到集合里
        /// </summary>
        /// <param name="filePath">文件完整路径及名</param>
        /// <returns>按行保存的字符串集合</returns>
        private List<string> ReadLines(string filePath)
        {
            //创建打开或创建文件的文件流
            FileStream fileStream =null;
            List<string> strList = new List<string>();//暂存原文件的每行信息
            StreamReader streamReader = null;
            try
            {
                fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
                streamReader = new StreamReader(fileStream, Encoding.Default);
                string content = streamReader.ReadLine();
                while (content != null)
                {   //一行行读取暂存到内存
                    strList.Add(content);
                    content = streamReader.ReadLine();
                }
            }
            finally
            {
                //释放对系统文件的占用资源
                if (streamReader != null)
                {
                    streamReader.Dispose();
                    streamReader.Close();
                }
                if (fileStream != null)
                {
                    fileStream.Dispose();
                    fileStream.Close();
                }
            }
            return strList;
        }

        /// <summary>
        /// 集合里元素按行写入文件
        /// </summary>
        /// <param name="filePath">文件完整路径及名</param>
        /// <param name="strList">要写入文件的字符串集合</param>
        private void WriteLines(string filePath,List<string> strList)
        {
            //创建打开或创建文件的文件流
            FileStream fileStream = null;
            StreamWriter streamWriter = null;
            try
            {
                fileStream = new FileStream(filePath, FileMode.Truncate);
                streamWriter = new StreamWriter(fileStream, Encoding.Default);
                strList.ForEach(delegate(string s) { streamWriter.WriteLine(s); });
            }
            finally
            {
                //释放对系统文件的占用资源
                if (streamWriter != null)
                {
                    streamWriter.Dispose();
                    streamWriter.Close();
                }
                if (fileStream != null)
                {
                    fileStream.Dispose();
                    fileStream.Close();
                }
            }
        }

        /// <summary>
        /// 写一行字符串到文件
        /// </summary>
        /// <param name="filePath">文件完整路径及名</param>
        /// <param name="str">要写入文件的字符串</param>
        private void WriteLine(string filePath, string str)
        {
            //创建打开或创建文件的文件流
            FileStream fileStream = null;
            StreamWriter streamWriter = null;
            try
            {
                fileStream = new FileStream(filePath, FileMode.Append);
                streamWriter = new StreamWriter(fileStream, Encoding.Default);
                streamWriter.WriteLine(str);
            }
            finally
            {
                //释放对系统文件的占用资源
                if (streamWriter != null)
                {
                    streamWriter.Dispose();
                    streamWriter.Close();
                }
                if (fileStream != null)
                {
                    fileStream.Dispose();
                    fileStream.Close();
                }
            }
        }
    }
}
