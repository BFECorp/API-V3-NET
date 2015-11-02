using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_V3_SDK.DataObject.Actions
{
    using API_V3_SDK.DataObject.Types;

    using Newtonsoft.Json;

    class DirectExpressAddOrderResponse : API_V3_Response
    {
        [JsonProperty(PropertyName = "body")]
        public new DirectExpressAddOrderInfo body { get; set; }
    }
}
