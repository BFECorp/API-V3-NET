using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_V3_SDK.Test
{
    using System.Configuration;

    public class ApiConfig
    {
        public static string API_BASE_URL
        {
            get
            {
                var url = ConfigurationManager.AppSettings["ck1:apiv3:url"];
                if (string.IsNullOrEmpty(url))
                {
                    url = "http://demo.chukou1.cn/v3/";
                }
                return url;
            }
        }

        public static Dictionary<string, string> AuthParams =
            new Dictionary<string, string>
                {
                    {"token", "887E99B5F89BB18BEA12B204B620D236"},
                    {"user_key", "wr5qjqh4gj"},
                };
    }
}
