using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_V3_SDK.Systems
{
    using API_V3_SDK.DataObject.Actions;

    using Newtonsoft.Json;

    class Package: Chukou1V3Service
    {
        public Dictionary<string, string> Dispatcher =
                        new Dictionary<string, string>()
                        {
                            {"category", "system"},
                            {"handler", "package"},
                        };

        public Package(string baseUrl, Dictionary<string, string> authParams)
            : base(baseUrl, authParams)
        {
        }

        public SystemGetPackagesResponse GetPackages(Dictionary<String, String> parameters)
        {
            Dispatcher["action"] = "get-packages";
            var requestUrl = this.CreateRequestUrl(Dispatcher);

            var json = HttpHelper.HttpPost(requestUrl, parameters);

            return JsonConvert.DeserializeObject<SystemGetPackagesResponse>(json);
        }
    }
}
