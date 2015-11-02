using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_V3_SDK.DataObject.Types
{
    using API_V3_SDK.DataObject.Types;

    using Newtonsoft.Json;

    public class OutboundAddOrderInfo
    {
        /// <summary>
        /// 订单号
        /// </summary>
        [JsonProperty(PropertyName = "order_size")]
        public string OrderSize { get; set; }

        /// <summary>
        /// 订单详细项
        /// </summary>
        [JsonProperty(PropertyName = "item_list")]
        public List<FeedBackItem> Items { get; set; }
    }
}
