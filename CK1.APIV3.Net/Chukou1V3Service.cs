using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace API_V3_SDK
{
    public class Chukou1V3Service
    {
        public string BaseUrl { get; private set; }

        public Dictionary<string, string> AuthParams { get; private set; }

        public Chukou1V3Service(string baseUrl, Dictionary<string, string> authParams)
        {
            this.BaseUrl = baseUrl;
            this.AuthParams = authParams;
        }

        public string CreateRequestUrl(Dictionary<string, string> dispatcher)
        {
            var paramStr = new StringBuilder();

            foreach (var pair in AuthParams)
            {
                paramStr.AppendFormat("{0}={1}&", EncodingHelper.UrlEncodeU8(pair.Key.Trim()), EncodingHelper.UrlEncodeU8(pair.Value.Trim()));
            }

            return string.Format("{0}{1}?{2}", BaseUrl, 
                                    string.Join("/", dispatcher.Values.ToArray()), paramStr);
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class API_V1_ResponseMeta
    {
        public static readonly int OK_STATUS = 200;
        public static readonly int AUTH_FAIL_STATUS = 401;
        public static readonly int FORBIDDEN_STATUS = 403;
        public static readonly int MALFORM_REQ_STATUS = 400;
        public static readonly int NO_EXIST_STATUS = 404;
        public static readonly int SERVER_ERROR = 500;
        public static readonly String OK_REMARK = "OK";
        public static readonly String DEFAULT_CALLER = "N/A";

        [JsonProperty(PropertyName = "code")]
        public int code { get; set; }

        [JsonProperty(PropertyName = "link")]
        public String link { get; set; }

        [JsonProperty(PropertyName = "description")]
        public String description { get; set; }

        [JsonProperty(PropertyName = "caller")]
        public String caller { get; internal set; }

        public API_V1_ResponseMeta()
        {
            code = OK_STATUS;
            link = "";
            caller = DEFAULT_CALLER;
            description = OK_REMARK;
        }

        public bool IsOKMeta()
        {
            return code == OK_STATUS;
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class API_V3_Response
    {
        [JsonProperty(PropertyName = "meta")]
        public API_V1_ResponseMeta meta { get; set; }

        [JsonProperty(PropertyName = "body")]
        public Object body { get; set; }
    }

}
