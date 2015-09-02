using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace API_V3_SDK.Test
{
    using System.IO;

    using API_V3_SDK.DataObject.Types;
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
        public void TestListDirectExpressService()
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
        #region 取得某个直发包裹信息的可用服务列表及所需运费

        [Fact]
        public void TestGetCompareCharge()
        {
            var parameters = new Dictionary<string, string>
                                 {
                                     { "Packing", "10*10*10" },
                                     { "weight_in_gram", "100" },
                                     { "Country", "United States" },
                                     { "province", "CA" },
                                     { "arrive", "GZ" },
                                     { "postcode", "12345" },
                                     { "tracking", "false" }
                                 };

            var response = this.packageService.GetPackageCompareCharge(parameters);

            Console.WriteLine(this.packageService.BaseUrl);
            Console.WriteLine(JsonConvert.SerializeObject(parameters));
            Console.WriteLine(JsonConvert.SerializeObject(response));
        }
        #endregion

        

        [Fact]
        public void TestPrintLabelOk()
        {
            const LabelPrintFormat format = LabelPrintFormat.classic_a4;
            const LabelContentType content = LabelContentType.address;
            var processNos = new[]
                                 {
                                     "AET150819TST000081",
                                     "AET150819TST000082",
                                 };

            var response = this.packageService.PrintLabel(format, content, processNos);

            Console.WriteLine(this.packageService.BaseUrl);
            Console.WriteLine(JsonConvert.SerializeObject(new { format, content, processNos }));
            if (response.meta.IsOKMeta())
            {
                var fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";

                using (var fs = new FileStream(
                    AppDomain.CurrentDomain.BaseDirectory + "\\" + fileName,
                    FileMode.Create))
                {
                    var data = response.body.ToArray();
                    // 开始写入
                    fs.Write(data, 0, data.Length);
                    // 清空缓冲区、关闭流
                    fs.Flush();
                    fs.Close();
                }

                Console.WriteLine("save file " + fileName);
            }
            else
            {
                Console.WriteLine(JsonConvert.SerializeObject(response));
            }
        }


        [Fact]
        public void TestPrintLabelError()
        {
            const LabelPrintFormat format = LabelPrintFormat.classic_a4;
            const LabelContentType content = LabelContentType.address;
            var processNos = new[]
                                 {
                                     "AET150819TST000081",
                                     "CUE150819TST000079",
                                 };

            var response = this.packageService.PrintLabel(format, content, processNos);

            Console.WriteLine(this.packageService.BaseUrl);
            Console.WriteLine(JsonConvert.SerializeObject(new { format, content, processNos }));
            if (response.meta.IsOKMeta())
            {
                var fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";

                using (var fs = new FileStream(
                    AppDomain.CurrentDomain.BaseDirectory + "\\" + fileName,
                    FileMode.Create))
                {
                    var data = response.body.ToArray();
                    // 开始写入
                    fs.Write(data, 0, data.Length);
                    // 清空缓冲区、关闭流
                    fs.Flush();
                    fs.Close();
                }

                Console.WriteLine("save file " + fileName);
            }
            else
            {
                Console.WriteLine(JsonConvert.SerializeObject(response));
            }
        }
    }
}
