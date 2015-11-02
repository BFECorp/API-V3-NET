using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_V3_SDK.DataObject.Types
{
    using API_V3_SDK.DataObject.Types;

    using Newtonsoft.Json;

    /// <summary>
    /// 出库包裹(V3 API)
    /// </summary>
    public class OutStorePackage
    {
        public OutStorePackage()
        {
            this.Sign = string.Empty;
            this.State = "Initial";
            this.Custom = string.Empty;
            this.TrackingNumber = string.Empty;
            this.Services = string.Empty;
            this.ProductList = new List<OutStoreProduct>();
            this.Remark = string.Empty;
            this.BuyerEmail = string.Empty;
            this.BuyerID = string.Empty;
            this.ItemID = string.Empty;
            this.IsInsured = false;
            this.InsuredRate = 0;
            this.Shipping = string.Empty;
            this.ClientPackageId = string.Empty;
            this.SellPrice = 0;
            this.SellPriceCurrency = string.Empty;
            this.RefNo = string.Empty;
        }

        /// <summary>
        /// 处理号
        /// </summary>
        [JsonProperty(PropertyName = "Sign")]
        public string Sign { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 客户自定义参考号
        /// </summary>
        [JsonProperty(PropertyName = "Custom")]
        public string Custom { get; set; }

        /// <summary>
        /// 跟踪号
        /// </summary>
        [JsonProperty(PropertyName = "Tracking_Number")]
        public string TrackingNumber { get; set; }

        /// <summary>
        /// 服务类型(string)
        /// </summary>
        [JsonProperty(PropertyName = "service_code")]
        public string Shipping { get; set; }
        
        /// <summary>
        /// 物流服务(多种服务用逗号隔开)
        /// </summary>
        [JsonProperty(PropertyName = "Services")]
        public string Services { get; set; }

        /// <summary>
        /// 投递信息
        /// </summary>
        [JsonProperty(PropertyName = "ship_to_address")]
        public ShipToAddress ShipToAddress { get; set; }

        /// <summary>
        /// 货品信息
        /// </summary>
        [JsonProperty(PropertyName = "product_list")]
        public List<OutStoreProduct> ProductList { get; set; }

        /// <summary>
        /// 包裹备注
        /// </summary>
        [JsonProperty(PropertyName = "Remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 买家ID
        /// </summary>
        [JsonProperty(PropertyName = "Buyer_ID")]
        public string BuyerID { get; set; }

        /// <summary>
        /// Ebay物品ID
        /// </summary>
        [JsonProperty(PropertyName = "Item_ID")]
        public string ItemID { get; set; }

        /// <summary>
        /// 买家邮箱
        /// </summary>
        [JsonProperty(PropertyName = "Buyer_Email")]
        public string BuyerEmail { get; set; }

        /// <summary>
        /// 是否保价
        /// </summary>
        [JsonProperty(PropertyName = "Is_Insured")]
        public bool? IsInsured { get; set; }

        /// <summary>
        /// 保价系数
        /// </summary>
        [JsonProperty(PropertyName = "Insured_Rate")]
        public decimal? InsuredRate { get; set; }

        /// <summary>
        /// 客户包裹ID, 用于出错时客户系统标识包裹
        /// </summary>
        [JsonProperty(PropertyName = "Client_Package_Id")]
        public string ClientPackageId { get; set; }

        /// <summary>
        /// 销售价格
        /// </summary>
        [JsonProperty(PropertyName = "sell_price")]
        public Decimal? SellPrice { get; set; }

        /// <summary>
        /// 销售货币
        /// </summary>
        [JsonProperty(PropertyName = "sell_price_currency")]
        public string SellPriceCurrency { get; set; }

        /// <summary>
        /// 第三方单号
        /// </summary>
        [JsonProperty(PropertyName = "RefNo")]
        public string RefNo { get; set; }

        /// <summary>
        /// 检查第三方单号是否重复
        /// </summary>
        public string CheckRepeatRefNo { get; set; }
    }

    /// <summary>
    /// 出库产品
    /// </summary>
    public class OutStoreProduct
    {
        public OutStoreProduct()
        {
            SKU = "";
            StorageNo = "";
            Quantity = 0;
            DeclareName = "";
            //DeclareValue = "";
        }

        private string _declareValue = string.Empty;

        /// <summary>
        /// 产品SKU
        /// </summary>
        [JsonProperty(PropertyName = "SKU")]
        public string SKU { get; set; }

        /// <summary>
        /// 出口易库存编码
        /// </summary>
        [JsonProperty(PropertyName = "Storage_No")]
        public string StorageNo { get; set; }

        /// <summary>
        /// 产品数量
        /// </summary>
        [JsonProperty(PropertyName = "Quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// 产品申报名称
        /// </summary>
        [JsonProperty(PropertyName = "Declare_Name")]
        public string DeclareName { get; set; }

        /// <summary>
        /// 产品申报价值
        /// </summary>
        [JsonProperty(PropertyName = "Declare_Value")]
        public string DeclareValue
        {
            get { return _declareValue; }
            set
            {
                try
                {
                    Convert.ToDecimal(value);
                }
                catch
                {
                    _declareValue = "0";
                }
                _declareValue = value;
            }
        }
        
    }

}
