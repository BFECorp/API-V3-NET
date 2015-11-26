
using System.Collections.Generic;


namespace API_V3_SDK.DataObject.Actions
{
    using API_V3_SDK.DataObject.Types;

    using Newtonsoft.Json;

    class OutboundPricingAllSkusResponse : API_V3_Response
    {
        [JsonProperty(PropertyName = "body")]
        public new List<OutboundPricingAllInfo> body { get; set; }
    }
}
