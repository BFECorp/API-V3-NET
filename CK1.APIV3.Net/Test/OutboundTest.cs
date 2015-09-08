using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace API_V3_SDK.Test
{
    using System.IO;

    using API_V3_SDK.DataObject.Types;
    using API_V3_SDK.Outbound;

    using Newtonsoft.Json;

    class OutboundTest
    {
        #region ///属性
        private readonly Package packageService;
        #endregion

        #region ///构造函数
        public OutboundTest()
        {
            packageService = new Package(ApiConfig.API_BASE_URL, ApiConfig.AuthParams);
        }
        #endregion
        

        #region 根据包裹信息计算包裹在某种发货方式下的运费

        [Fact]
        public void TestGetPackagePricing()
        {
            var parameters = new Dictionary<string, string>
                                 {
                                     { "express_service", "USNUS" },
                                     { "weight_in_gram", "100" },
                                     { "packing", "10*10*10" },
                                     { "warehouse", "US" },
                                     { "destination_type", "L" },
                                     { "to_region", "US" },
                                     { "to_zip_code", "34455" },
                                     { "to_city", "New York" }
                                 };

            var response = this.packageService.GetPackagePricing(parameters);

            Console.WriteLine(this.packageService.BaseUrl);
            Console.WriteLine(JsonConvert.SerializeObject(parameters));
            Console.WriteLine(JsonConvert.SerializeObject(response));
        }
        #endregion

        #region 根据包裹信息计算包裹在指定仓库所有可用发货方式的运费

        [Fact]
        public void TestGetPackagePricingAll()
        {
            var parameters = new Dictionary<string, string>
                                 {
                                     { "weight_in_gram", "100" },
                                     { "packing", "10*10*10" },
                                     { "warehouse", "US" },
                                     { "destination_type", "L" },
                                     { "to_region", "US" },
                                     { "to_zip_code", "34455" },
                                     { "to_city", "New York" }
                                 };

            var response = this.packageService.GetPackagePricingAll(parameters);

            Console.WriteLine(this.packageService.BaseUrl);
            Console.WriteLine(JsonConvert.SerializeObject(parameters));
            Console.WriteLine(JsonConvert.SerializeObject(response));
        }
        #endregion


    }
}
