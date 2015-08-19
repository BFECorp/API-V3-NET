namespace API_V3_SDK.DirectExpress
{
    using System;
    using System.Collections.Generic;

    using API_V3_SDK.DataObject.Actions;

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
    }
    
}
