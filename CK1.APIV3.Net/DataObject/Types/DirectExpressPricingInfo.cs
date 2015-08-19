using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_V3_SDK.DataObject.Types
{
    using Newtonsoft.Json;

    class DirectExpressPricingInfo
    {
        [JsonProperty(PropertyName = "tracking")]
        public bool Tracking { get; set; }

        [JsonProperty(PropertyName = "service_code")]
        public string ServiceCode { get; set; }

        [JsonProperty(PropertyName = "service_name")]
        public string ServiceName { get; set; }

        [JsonProperty(PropertyName = "charge")]
        public DirectExpressPricingChargeInfo Charge { get; set; }
    }

    class DirectExpressPricingChargeInfo
    {
        [JsonProperty(PropertyName = "summary")]
        public DirectExpressPricingSummaryInfo Summary { get; set; }

        [JsonProperty(PropertyName = "detail")]
        public List<DirectExpressPricingDetailInfo> Detail { get; set; }
    }

    class DirectExpressPricingSummaryInfo
    {
        [JsonProperty(PropertyName = "CNY")]
        public string CNY { get; set; }
    }

    class DirectExpressPricingDetailInfo
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
