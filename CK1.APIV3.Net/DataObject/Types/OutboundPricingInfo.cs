using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_V3_SDK.DataObject.Types
{
    using Newtonsoft.Json;

    class OutboundPricingInfo
    {
        [JsonProperty(PropertyName = "summary")]
        public List<OutboundPricingSummaryInfo> Summary { get; set; }

        [JsonProperty(PropertyName = "detail")]
        public List<OutboundPricingDetailInfo> Detail { get; set; }
    }

    class OutboundPricingSummaryInfo
    {
        [JsonProperty(PropertyName = "currency_unit")]
        public string CurrencyUnit { get; set; }
        [JsonProperty(PropertyName = "money")]
        public string Money { get; set; }
    }

    class OutboundPricingDetailInfo
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
