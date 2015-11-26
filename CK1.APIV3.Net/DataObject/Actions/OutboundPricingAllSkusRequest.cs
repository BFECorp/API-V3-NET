using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_V3_SDK.DataObject.Actions
{
    public class OutboundPricingAllSkusRequest
    {
        /// <summary>
        /// 多个SKU与数量拼接
        /// </summary>
        public List<string> SkuArray { get; set; }
        /// <summary>
        /// 仓库代号
        /// </summary>
        public string Warehouse { get; set; }
        /// <summary>
        /// 快递类型
        /// </summary>
        public string DestinationType { get; set; }
        /// <summary>
        /// 发往国家(支持标准二字简称)
        /// </summary>
        public string ToRegion { get; set; }
        /// <summary>
        /// 发往地区邮编(发往当地时必填)
        /// </summary>
        public string ToZipCode { get; set; }
        /// <summary>
        /// 发往地区城市
        /// </summary>
        public string ToCity { get; set; }
    }
}
