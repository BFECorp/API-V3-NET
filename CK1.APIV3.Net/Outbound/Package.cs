﻿namespace API_V3_SDK.Outbound
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;

    using API_V3_SDK.DataObject.Actions;
    using API_V3_SDK.DataObject.Types;

    using Newtonsoft.Json;

    class Package : Chukou1V3Service
    {
        public Dictionary<string, string> Dispatcher =
                        new Dictionary<string, string>()
                        {
                            {"category", "outbound"},
                            {"handler", "package"},
                        };

        public Package(string baseUrl, Dictionary<string, string> authParams)
            : base(baseUrl, authParams)
        {
        }
        /// <summary>
        /// 根据包裹信息计算包裹在某种发货方式下的运费
        /// </summary>
        public OutboundPricingResponse GetPackagePricing(Dictionary<String, String> parameters)
        {
            this.Dispatcher["action"] = "pricing";
            var requestUrl = this.CreateRequestUrl(this.Dispatcher);

            var json = HttpHelper.HttpGet(requestUrl, parameters);
            return JsonConvert.DeserializeObject<OutboundPricingResponse>(json);
        }
        /// <summary>
        /// 根据包裹信息计算包裹在指定仓库所有可用发货方式的运费
        /// </summary>
        public OutboundPricingAllResponse GetPackagePricingAll(Dictionary<String, String> parameters)
        {
            this.Dispatcher["action"] = "pricing-all";
            var requestUrl = this.CreateRequestUrl(this.Dispatcher);

            var json = HttpHelper.HttpGet(requestUrl, parameters);
            return JsonConvert.DeserializeObject<OutboundPricingAllResponse>(json);
        }
        
    }

}