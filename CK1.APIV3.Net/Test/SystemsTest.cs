using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace API_V3_SDK.Test
{
    using API_V3_SDK.Systems;

    using Newtonsoft.Json;

    class SystemsTest
    {
        private readonly Tracking trackingService;

        public SystemsTest()
        {
            trackingService = new Tracking(ApiConfig.API_BASE_URL, ApiConfig.AuthParams);
        }

        [Fact]
        public void TestGetTracking()
        {
            var parameters = new Dictionary<string, string>
                                 {
                                     { "package_sn", "DHL140620TST000004" },
                                 };

            var response = this.trackingService.GetTracking(parameters);

            Console.WriteLine(this.trackingService.BaseUrl);
            Console.WriteLine(JsonConvert.SerializeObject(parameters));
            Console.WriteLine(JsonConvert.SerializeObject(response));
        }
    }
}
