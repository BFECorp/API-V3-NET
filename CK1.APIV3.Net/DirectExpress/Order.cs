using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

using API_V3_SDK.DataObject.Actions;
using API_V3_SDK.DataObject.Types;

using Newtonsoft.Json;

namespace API_V3_SDK.DirectExpress
{
    class Order : Chukou1V3Service
    {
        public Dictionary<string, string> Dispatcher =
                        new Dictionary<string, string>()
                        {
                            {"category", "direct-express"},
                            {"handler", "order"},
                        };

        public Order(string baseUrl, Dictionary<string, string> authParams) : base(baseUrl, authParams)
        {
        }


        public DirectExpressAddOrderResponse AddOrder(Dictionary<String, String> parameters)
        {
            this.Dispatcher["action"] = "add-order";
            var requestUrl = this.CreateRequestUrl(this.Dispatcher);

            var json = HttpHelper.HttpPost(requestUrl, parameters);

            return JsonConvert.DeserializeObject<DirectExpressAddOrderResponse>(json);
        }
    }
}
