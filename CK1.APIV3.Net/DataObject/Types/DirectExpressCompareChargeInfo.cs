using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_V3_SDK.DataObject.Types
{
    using Newtonsoft.Json;

    class DirectExpressCompareChargeInfo
    {
        [JsonProperty(PropertyName = "count")]
        public string Count { get; set; }

        [JsonProperty(PropertyName = "items")]
        public List<DirectExpressCompareChargeItems> Items { get; set; }
    }


    class DirectExpressCompareChargeItems
    {
        [JsonProperty(PropertyName = "tracking")]
        public bool Tracking { get; set; }

        [JsonProperty(PropertyName = "service_code")]
        public string ServiceCode { get; set; }

        [JsonProperty(PropertyName = "service_name")]
        public string ServiceName { get; set; }

        [JsonProperty(PropertyName = "charge")]
        public DirectExpressCompareChargeChargeInfo Charge { get; set; }
    }

    class DirectExpressCompareChargeChargeInfo
    {
        [JsonProperty(PropertyName = "summary")]
        public DirectExpressCompareChargeSummaryInfo Summary { get; set; }

        [JsonProperty(PropertyName = "detail")]
        public List<DirectExpressCompareChargeDetailInfo> Detail { get; set; }
    }

    class DirectExpressCompareChargeSummaryInfo
    {
        [JsonProperty(PropertyName = "CNY")]
        public string CNY { get; set; }
    }

    class DirectExpressCompareChargeDetailInfo
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
