using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_V3_SDK.DataObject.Types
{
    using Newtonsoft.Json;

    class OutboundPricingAllInfo
    {
        [JsonProperty(PropertyName = "ProductCode")]
        public string ProductCode { get; set; }

        [JsonProperty(PropertyName = "ProductName")]
        public string ProductName { get; set; }

        [JsonProperty(PropertyName = "Success")]
        public string Success { get; set; }

        [JsonProperty(PropertyName = "Reason")]
        public string Reason { get; set; }

        [JsonProperty(PropertyName = "Fees")]
        public OutboundPricingAllFeesInfo Fees { get; set; }
    }

    class OutboundPricingAllFeesInfo
    {
        [JsonProperty(PropertyName = "summary")]
        public List<OutboundPricingAllSummaryInfo> Summary { get; set; }

        [JsonProperty(PropertyName = "detail")]
        public List<OutboundPricingAllDetailInfo> Detail { get; set; }
    }

    class OutboundPricingAllSummaryInfo
    {
        [JsonProperty(PropertyName = "currency_unit")]
        public string CurrencyUnit { get; set; }
        [JsonProperty(PropertyName = "money")]
        public string Money { get; set; }
    }

    class OutboundPricingAllDetailInfo
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
