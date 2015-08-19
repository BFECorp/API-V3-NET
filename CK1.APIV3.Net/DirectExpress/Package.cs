using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace API_V3_SDK.Express
{
    using API_V3_SDK.DataObject.Actions;

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
            Dispatcher["action"] = "pricing";
            var requestUrl = this.CreateRequestUrl(Dispatcher);

            var json = HttpHelper.HttpGet(requestUrl, parameters);

            return JsonConvert.DeserializeObject<DirectExpressPricingResponse>(json);
        }
    }
    
}
