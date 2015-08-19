namespace API_V3_SDK.DirectExpress
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;

    using API_V3_SDK.DataObject.Actions;
    using API_V3_SDK.DataObject.Types;

    using Newtonsoft.Json;

    class Package : Chukou1V3Service
    {
        public Dictionary<string, string> Dispatcher =
                        new Dictionary<string, string>()
                        {
                            {"category", "direct-express"},
                            {"handler", "package"},
                        };

        public Package(string baseUrl, Dictionary<string, string> authParams)
            : base(baseUrl, authParams)
        {
        }

        public DirectExpressPricingResponse GetPackagePricing(Dictionary<String, String> parameters)
        {
            this.Dispatcher["action"] = "pricing";
            var requestUrl = this.CreateRequestUrl(this.Dispatcher);

            var json = HttpHelper.HttpGet(requestUrl, parameters);

            return JsonConvert.DeserializeObject<DirectExpressPricingResponse>(json);
        }

        public DirectExpressPrintLabelResponse PrintLabel(LabelPrintFormat format, LabelContentType content, params string[] processNos)
        {
            this.Dispatcher["action"] = "print-label";
            var requestUrl = this.CreateRequestUrl(this.Dispatcher);

            var parameters = new Dictionary<string, string>
                                 {
                                     { "format", format.ToString() },
                                     { "content", content.ToString() }
                                 };

            var postData = "package_sn=" + string.Join("&package_sn=", processNos);

            var result = HttpHelper.HttpPostStream(requestUrl, parameters, postData, Encoding.UTF8, 60 * 10);

            //重置流
            result.Position = 0;
            var streamReader = new StreamReader(result, Encoding.UTF8);

            // 检查返回页面
            API_V3_Response response = null;
            try
            {
                var json = streamReader.ReadToEnd();
                response = JsonConvert.DeserializeObject<API_V3_Response>(json);
            }
            catch (Exception ex)
            {
                // 处理异常
                // 不能处理为json结构，应为正常获取的pdf文件
            }

            if (response != null)
            {
                return new DirectExpressPrintLabelResponse()
                           {
                               meta = response.meta
                           };
            }

            // 重置流
            result.Position = 0;

            return new DirectExpressPrintLabelResponse()
                       {
                           meta = new API_V1_ResponseMeta() { },
                           body = result
                       };
        }

    }
    
}
