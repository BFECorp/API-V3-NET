using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace API_V3_SDK.Express
{
    class Package
    {
        public static Dictionary<string, string> Dispatcher =
                        new Dictionary<string, string>()
                        {
                            {"category", "direct-express"},
                            {"handler", "package"},
                        };

        public static bool SendDeletePackageRequest(string packageSign)
        {
            Dispatcher["action"] = "delete";
            var requestUrl = CK1API_SDK_Base.CreateRequestUrl(Dispatcher);

            Dictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("package_sn", packageSign);

            string json = HttpHelper.HttpPost(requestUrl, parameters);

            var response = JsonConvert.DeserializeObject<API_V3_Response>(json);
            return response.meta.IsOKMeta();
        }

        public static bool SendPackagePricingRequest()
        {
            Dispatcher["action"] = "pricing";
            var requestUrl = CK1API_SDK_Base.CreateRequestUrl(Dispatcher);

            Dictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("service", "HTM");
            parameters.Add("country", "US");
            parameters.Add("packing", "1*1*1");
            parameters.Add("weight_in_gram", "50");

            string json = HttpHelper.HttpGet(requestUrl, parameters);

            var response = JsonConvert.DeserializeObject<PackagePricingResponse>(json);
            return response.meta.IsOKMeta();
        }
    }

    class PackagePricingResponse : API_V3_Response
    {
        [JsonProperty(PropertyName = "body")]
        new public PricingInfo body { get; set; }
    }

    class PricingInfo
    {
        [JsonProperty(PropertyName = "tracking")]
        public bool Tracking { get; set; }

        [JsonProperty(PropertyName = "service_code")]
        public string ServiceCode { get; set; }

        [JsonProperty(PropertyName = "service_name")]
        public string ServiceName { get; set; }

        [JsonProperty(PropertyName = "charge")]
        public ChargeInfo Charge { get; set; }
    }

    class ChargeInfo
    {
        [JsonProperty(PropertyName = "summary")]
        public SummaryInfo Summary { get; set; }

        [JsonProperty(PropertyName = "detail")]
        public List<DetailInfo> Detail { get; set; }
    }

    class SummaryInfo
    {
        [JsonProperty(PropertyName = "CNY")]
        public string CNY { get; set; }
    }

    class DetailInfo
    {
        [JsonProperty(PropertyName = "sn")]
        public string Sign { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public decimal Amount { get; set; }

        [JsonProperty(PropertyName = "remark")]
        public string Remark { get; set; }

        [JsonProperty(PropertyName = "charge_name")]
        public string ChargeName { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }
    }
}
