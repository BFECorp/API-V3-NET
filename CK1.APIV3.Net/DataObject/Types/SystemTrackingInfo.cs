using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_V3_SDK.DataObject.Types
{
    using Newtonsoft.Json;

    public class SystemTrackingInfo
    {
        [JsonProperty(PropertyName = "track_no")]
        public string TrackingNumber { get; set; }
        
        [JsonProperty(PropertyName = "package_sn")]
        public string ProcessNo { get; set; }
        
        [JsonProperty(PropertyName = "carrier")]
        public string Carrier { get; set; }
        
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        
        [JsonProperty(PropertyName = "submit_time")]
        public string SubmitTime { get; set; }
        
        [JsonProperty(PropertyName = "address")]
        public SystemTrackingShippingAddressInfo ShippingAddress { get; set; }
        
        [JsonProperty(PropertyName = "details")]
        public List<SystemTrackingDetailInfo> TrackingDetails { get; set; }
    }

    public class SystemTrackingShippingAddressInfo
    {
        
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        
        [JsonProperty(PropertyName = "street")]
        public string Street { get; set; }
        
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }
        
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }
        
        [JsonProperty(PropertyName = "zipcode")]
        public string Zip { get; set; }
        
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
    }

    public class SystemTrackingDetailInfo
    {
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }
        
        [JsonProperty(PropertyName = "time")]
        public string Time { get; set; }
        
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }
        
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}
