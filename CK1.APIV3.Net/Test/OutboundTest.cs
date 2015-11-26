using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API_V3_SDK.DataObject.Actions;
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
        private readonly Order orderService;
        #endregion

        #region ///构造函数
        public OutboundTest()
        {
            packageService = new Package(ApiConfig.API_BASE_URL, ApiConfig.AuthParams);
            orderService = new Order(ApiConfig.API_BASE_URL, ApiConfig.AuthParams);
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


        #region 计算多个SKU产品在指定仓库所有可用发货方式的运费

        [Fact]
        public void TestOutboundPricingAllSkus()
        {
            var request = new OutboundPricingAllSkusRequest()
            {
                DestinationType = "L",
                SkuArray = new List<string>()
                {
                    "carey*2",
                    "DE03*5"
                },
                ToCity = "New York",
                ToRegion = "US",
                ToZipCode = "34455",
                Warehouse = "US"
            };
            var response = this.packageService.OutboundPricingAllSkus(request);

            Console.WriteLine(this.packageService.BaseUrl);
            Console.WriteLine(JsonConvert.SerializeObject(request));
            Console.WriteLine(JsonConvert.SerializeObject(response));
        }
        #endregion


        #region ///二程出库

        [Fact]
        public void TestAddOrder()
        {
            var package_list = new List<OutStorePackage>()
            {
                new OutStorePackage()
                {
                    Custom = "test",
                    Shipping = "USRLS",
                    ShipToAddress = new ShipToAddress()
                    {
                        City = "WUHAN",
                        Street1 = "wuhn",
                        Phone = "13437267001",
                        PostCode = "12345",
                        Country = "United States",
                        Contact = "WUHAN",
                        Province = "WUHAN"
                    },
                    ProductList = new List<OutStoreProduct>()
                    {
                        new OutStoreProduct()
                        {
                            DeclareName = "123",
                            DeclareValue = "1",
                            SKU = "phone09",
                            Quantity = 1
                        }
                    }

                }
            };

            var parameters = new Dictionary<string, string>
                                 {
                                     { "Submit", "false" },
                                     { "warehouse", "US" },
                                     {"remark","test"},
                                     { "package_list", JsonConvert.SerializeObject(package_list) }
                                 };

            var response = this.orderService.AddOrder(parameters);

            Console.WriteLine(this.orderService.BaseUrl);
            Console.WriteLine(JsonConvert.SerializeObject(parameters));
            Console.WriteLine(JsonConvert.SerializeObject(response));
        }
        #endregion

    }
}
