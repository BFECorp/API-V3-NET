using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API_V3_SDK.M2C;
using Xunit;
using API_V3_SDK.Express;

namespace API_V3_SDK.Test
{
    class SDK_Test
    {
        [Fact]
        public void TestCreateRequestUrl()
        {
            Package.Dispatcher["action"] = "delete";
            string RequestUrl = CK1API_SDK_Base.CreateRequestUrl(Package.Dispatcher);
            Assert.Equal(
                "http://api.chukou1.com/v3/direct-express/package/delete?token=887E99B5F89BB18BEA12B204B620D236&user_key=wr5qjqh4gj&", 
                RequestUrl);

            Package.Dispatcher["action"] = "pricing";
            RequestUrl = CK1API_SDK_Base.CreateRequestUrl(Package.Dispatcher);
            Assert.Equal(
                "http://api.chukou1.com/v3/direct-express/package/pricing?token=887E99B5F89BB18BEA12B204B620D236&user_key=wr5qjqh4gj&", 
                RequestUrl);
        }

        [Fact]
        public void TestSendDeletePackageRequest()
        {
            string sign = "SAP120829TST000071";
            Assert.True(Package.SendDeletePackageRequest(sign));

            sign = "SAP120829TST000073";
            Assert.True(Package.SendDeletePackageRequest(sign));
        }

        [Fact]
        public void TestSendPackagePricingRequest()
        {
            Assert.True(Package.SendPackagePricingRequest());
        }

        [Fact]
        public void TestSendListShareStockRequest()
        {
            Assert.True(Stock.SendListShareStockRequest());
        }
    }
}
