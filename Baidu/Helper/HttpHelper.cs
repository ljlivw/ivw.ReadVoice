using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Baidu.Helper
{
    public class HttpHelper
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="sUri">Uri</param>
        /// <returns></returns>
        public static string Get(string sUri)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(sUri);
            httpWebRequest.Method = "GET";
            return Send(httpWebRequest);
        }
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="sUri">Uri</param>
        /// <param name="dicParams">参数集合</param>
        /// <returns></returns>
        public static string Get(string sUri, Dictionary<string, object> dicParams)
        {
            StringBuilder sb = new StringBuilder();
            bool bIsFirst = true;
            foreach (var item in dicParams)
            {
                if (!bIsFirst)
                {
                    sb.Append("&");
                }
                sb.AppendFormat("{0}={1}", item.Key, item.Value);
                bIsFirst = false;
            }
            if (sUri.Substring(sUri.Length - 1, 1) == "?")//判断最后一个字符是否是？号
            {
                sUri += sb.ToString();
            }
            else
            {
                sUri += "?" + sb.ToString();
            }
            return Get(sUri);
        }

        public static string Send(HttpWebRequest httpWebRequest)
        {
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (Stream stream = httpWebResponse.GetResponseStream())
            {
                using (StreamReader streamReader = new StreamReader(stream, Encoding.UTF8))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// 指定Post地址使用Get 方式获取全部字符串
        /// </summary>
        /// <param name="url">请求后台地址</param>
        /// <returns></returns>
        public static string Post(string url)
        {
            //string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

            return Send(req);
        }
        /// <summary>
        /// 指定Post地址使用Get 方式获取全部字符串
        /// </summary>
        /// <param name="url">请求后台地址</param>
        /// <param name="content">Post提交数据内容(utf-8编码的)</param>
        /// <returns></returns>
        public static string Post(string url, string content)
        {
            //string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

            #region 添加Post 参数
            byte[] data = Encoding.UTF8.GetBytes(content);
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            #endregion

            return Send(req);
        }
    }
}
