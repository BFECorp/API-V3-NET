using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using API_V3_SDK.Express;

namespace API_V3_SDK.Test
{
    using API_V3_SDK.DirectExpress;

    using Newtonsoft.Json;

    class DirectExpressTest
    {
        private readonly Misc miscService;
        private readonly Package packageService;

        public DirectExpressTest()
        {
            miscService = new Misc(ApiConfig.API_BASE_URL, ApiConfig.AuthParams);
            packageService = new Package(ApiConfig.API_BASE_URL, ApiConfig.AuthParams);
        }

        [Fact]
        public void TestCreateRequestUrl()
        {
            var response = this.miscService.ListDirectExpressService();

            Console.WriteLine(this.miscService.BaseUrl);
            Console.WriteLine(JsonConvert.SerializeObject(response));
        }

        [Fact]
        public void TestGetPackagePricing()
        {
            var parameters = new Dictionary<string, string>
                                 {
                                     { "service", "HTM" },
                                     { "country", "US" },
                                     { "packing", "1*1*1" },
                                     { "weight_in_gram", "50" }
                                 };

            var response = this.packageService.GetPackagePricing(parameters);

            Console.WriteLine(this.packageService.BaseUrl);
            Console.WriteLine(JsonConvert.SerializeObject(parameters));
            Console.WriteLine(JsonConvert.SerializeObject(response));
        }
    }
}
