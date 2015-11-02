using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_V3_SDK.DataObject.Types
{
    public class SystemGetPackageInfo
    {
        public bool Success { get; set; }

        public string ErrorMessage { get; set; }

        public PackageQueryItem OriginalItem { get; set; }

        public string ProcessNo { get; set; }

        public string RefNo { get; set; }

        public string PackageType { get; set; }

        public ShippingMethod ShippingMethod { get; set; }

        public ShipToAddress ToAddress { get; set; }

        public PackageInfo PackageInfo { get; set; }

        public bool IsTracking { get; set; }

        public TrackingInfo TrackingInfo { get; set; }

        public StatusInfo StatusInfo { get; set; }
    }

    public class PackageQueryItem
    {
        public string ProcessNo { get; set; }

        public string TrackingNumber { get; set; }

        public string RefNo { get; set; }
    }

    public class ShippingMethod
    {

        public string ServiceCode { get; set; }


        public string ServiceName { get; set; }
    }
    
    public class PackageInfo
    {
        public Packing Packing { get; set; }

        public decimal WeightInit { get; set; }

        public decimal WeightForCharge { get; set; }

        public string DeclareName { get; set; }

        public decimal DeclareValue { get; set; }

        public List<ProductInfo> ProductList { get; set; }

        public string Custom { get; set; }

        public string Remark { get; set; }
    }

    public class Packing
    {
        public decimal Length { get; set; }

        public decimal Width { get; set; }

        public decimal Height { get; set; }
    }

    public class ProductInfo
    {
        public string StorageSku { get; set; }

        public string CustomerSku { get; set; }

        public Packing Packing { get; set; }

        public decimal Weight { get; set; }

        public string DeclareName { get; set; }

        public decimal DeclareValue { get; set; }

        public int Quantity { get; set; }
    }

    public class TrackingInfo
    {
        public string Carrier { get; set; }

        public string TrackingNumber { get; set; }
    }

    public class StatusInfo
    {
        public string OriginalStatus { get; set; }

        public string ProcessStatus { get; set; }

        public UnDeliveryReason UnDeliveryReason { get; set; }
    }

    public class UnDeliveryReason
    {
        public string ReasonCode { get; set; }

        public string ReasonMessage { get; set; }
    }
}
