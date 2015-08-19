using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace API_V3_SDK.Test
{
    using API_V3_SDK.DataObject.Types;
    using API_V3_SDK.Systems;

    using Newtonsoft.Json;

    class SystemsTest
    {
        private readonly Tracking trackingService;
        private readonly Package packageService;

        public SystemsTest()
        {
            trackingService = new Tracking(ApiConfig.API_BASE_URL, ApiConfig.AuthParams);
            packageService = new Package(ApiConfig.API_BASE_URL, ApiConfig.AuthParams);
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

        [Fact]
        public void TestGetPackages()
        {
            var parameters = new Dictionary<string, string>
                                 {
                                     {
                                         "Items",
                                         JsonConvert.SerializeObject(
                                             new[]
                                                 {
                                                     new PackageQueryItem
                                                         {
                                                             ProcessNo = "CND150818TST000006",
                                                             TrackingNumber = "",
                                                             RefNo = "",
                                                         },
                                                     new PackageQueryItem
                                                         {
                                                             ProcessNo = "",
                                                             TrackingNumber = "20150810181006",
                                                             RefNo = "",
                                                         },
                                                     new PackageQueryItem
                                                         {
                                                             ProcessNo = "",
                                                             TrackingNumber = "",
                                                             RefNo = "TST201504101141",
                                                         },
                                                 })
                                     },
                                 };

            var response = this.packageService.GetPackages(parameters);

            Console.WriteLine(this.packageService.BaseUrl);
            Console.WriteLine(JsonConvert.SerializeObject(parameters));
            Console.WriteLine(JsonConvert.SerializeObject(response));
        }
    }
}
