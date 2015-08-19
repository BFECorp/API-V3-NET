using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace API_V3_SDK
{
    class HttpHelper
    {
        public static String HttpGet(string url, Dictionary<String, String> paramters)
        {
            var paramStr = new StringBuilder("");

            foreach (KeyValuePair<String, String> pair in paramters)
            {
                if (pair.Value != null)
                {
                    paramStr.AppendFormat("{0}={1}&", EncodingHelper.UrlEncodeU8(pair.Key.Trim()), EncodingHelper.UrlEncodeU8(pair.Value.Trim()));
                }
            }

            string requestAddress = string.Format("{0}{1}", url, paramStr);
            var webRequest = WebRequest.Create(requestAddress);
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "GET";

            //byte[] bytes = Encoding.ASCII.GetBytes(paramStr.ToString());
            Stream stream = null;
            try
            { 
                webRequest.ContentLength = 0;   
                //stream = webRequest.GetRequestStream();
                //stream.Write(bytes, 0, bytes.Length);

                var webResponse = webRequest.GetResponse();
                var sr = new StreamReader(webResponse.GetResponseStream());
                return sr.ReadToEnd().Trim();
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        } 

        public static String HttpPost(string uri, Dictionary<String, String> paramters)
        {
            var webRequest = WebRequest.Create(uri);
            var paramStr = new StringBuilder("");

            foreach (KeyValuePair<String, String> pair in paramters)
            {
                if (pair.Value != null)
                {
                    paramStr.AppendFormat("{0}={1}&", EncodingHelper.UrlEncodeU8(pair.Key.Trim()), EncodingHelper.UrlEncodeU8(pair.Value.Trim()));
                }
            }

            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";

            byte[] bytes = Encoding.ASCII.GetBytes(paramStr.ToString());
            Stream stream = null;
            try
            { 
                webRequest.ContentLength = bytes.Length;   
                stream = webRequest.GetRequestStream();
                stream.Write(bytes, 0, bytes.Length);         //Send it

                var webResponse = webRequest.GetResponse();
                var sr = new StreamReader(webResponse.GetResponseStream());
                return sr.ReadToEnd().Trim();
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }

        public static MemoryStream HttpPostStream(string url, Dictionary<String, String> paramters, string postData = null, Encoding encoding = null, int timeoutSeconds = 0)
        {
            MemoryStream result = null;
            Stream responseStream;

            if (encoding == null)
                encoding = Encoding.UTF8;

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            var paramStr = new StringBuilder("");

            if (paramters != null)
            {
                foreach (KeyValuePair<String, String> pair in paramters)
                {
                    if (pair.Value != null)
                    {
                        paramStr.AppendFormat(
                            "{0}={1}&",
                            EncodingHelper.UrlEncodeU8(pair.Key.Trim()),
                            EncodingHelper.UrlEncodeU8(pair.Value.Trim()));
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(postData))
            {
                paramStr.Append(postData);
            }

            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.Method = "POST";

            byte[] bytes = Encoding.ASCII.GetBytes(paramStr.ToString().TrimEnd('&'));
            Stream os = null;
            try
            {
                httpWebRequest.ContentLength = bytes.Length;
                if (timeoutSeconds > 0)
                {
                    httpWebRequest.Timeout = timeoutSeconds * 1000;
                }
                os = httpWebRequest.GetRequestStream();
                os.Write(bytes, 0, bytes.Length);         //Send it
            }
            catch (WebException ex)
            {
                throw ex;
            }
            finally
            {
                if (os != null)
                {
                    os.Close();
                }
            }

            #region 获取服务器的返回信息
            try
            {
                var httpWebRespones = (HttpWebResponse)httpWebRequest.GetResponse();
                responseStream = httpWebRespones.GetResponseStream();
            }
            //处理异常
            catch (Exception ex)
            {
                throw new OperationCanceledException(ex.Message);
            }
            #endregion

            const int bufferLength = 1024 * 10;

            var data = new byte[bufferLength];

            result = new MemoryStream();
            var bytesRead = responseStream.Read(data, 0, bufferLength);

            while (bytesRead > 0)
            {
                result.Write(data, 0, bytesRead);
                bytesRead = responseStream.Read(data, 0, bufferLength);
            }
            responseStream.Close();

            return result;
        }
    }
}
