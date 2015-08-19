using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_V3_SDK.Systems
{
    using API_V3_SDK.DataObject.Actions;

    using Newtonsoft.Json;

    class Tracking: Chukou1V3Service
    {
        public Dictionary<string, string> Dispatcher =
                        new Dictionary<string, string>()
                        {
                            {"category", "system"},
                            {"handler", "tracking"},
                        };

        public Tracking(string baseUrl, Dictionary<string, string> authParams)
            : base(baseUrl, authParams)
        {
        }

        public SystemGetTrackingResponse GetTracking(Dictionary<String, String> parameters)
        {
            Dispatcher["action"] = "get-tracking";
            var requestUrl = this.CreateRequestUrl(Dispatcher);

            var json = HttpHelper.HttpGet(requestUrl, parameters);

            return JsonConvert.DeserializeObject<SystemGetTrackingResponse>(json);
        }
    }
}
