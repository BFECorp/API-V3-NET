using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_V3_SDK.DirectExpress
{
    using API_V3_SDK.DataObject.Actions;

    using Newtonsoft.Json;

    class Misc : Chukou1V3Service
    {
        public Dictionary<string, string> Dispatcher =
                        new Dictionary<string, string>()
                        {
                            {"category", "direct-express"},
                            {"handler", "misc"},
                        };

        public Misc(string baseUrl, Dictionary<string, string> authParams)
            : base(baseUrl, authParams)
        {
        }

        public ListDirectExpressServiceResponse ListDirectExpressService()
        {
            Dispatcher["action"] = "list-all-service";
            var requestUrl = this.CreateRequestUrl(Dispatcher);

            var parameters = new Dictionary<String, String>();

            var json = HttpHelper.HttpGet(requestUrl, parameters);

            return JsonConvert.DeserializeObject<ListDirectExpressServiceResponse>(json);
        }
    }
}
