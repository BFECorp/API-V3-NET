using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace API_V3_SDK.DataObject.Types
{
    class DirectExpressAddOrderInfo
    {
        /// <summary>
        /// 订单号
        /// </summary>
        [JsonProperty(PropertyName = "OrderSign")]
        public string OrderSign { get; set; }

        /// <summary>
        /// 包裹信息回馈
        /// </summary>
        [JsonProperty(PropertyName = "Packages")]
        public List<FeedBackItem> Packages { get; set; }

        /// <summary>
        /// 警告信息
        /// </summary>
        [JsonProperty(PropertyName = "Message")]
        public string Message { get; set; }
    }

    public class FeedBackItem
    {
        public FeedBackItem()
        {
            Custom = string.Empty;
            ItemSign = string.Empty;
            Remark = string.Empty;
        }

        /// <summary>
        /// 自定义参考号
        /// </summary>
        public string Custom { get; set; }

        /// <summary>
        /// 出口易处理号
        /// </summary>
        public string ItemSign { get; set; }

        /// <summary>
        /// 备注(主要是Selling helper有些客户用这个字段记录处理号)
        /// </summary>
        public string Remark { get; set; }
    }

}
