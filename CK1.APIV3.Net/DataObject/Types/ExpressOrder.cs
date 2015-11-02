using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_V3_SDK.DataObject.Types
{
     public class ExpressOrder
    {
        /// <summary>
        /// 揽收方式: 0:上门揽收; 1:卖家自送
        /// </summary>
        public int PickupType { get; set; }
         
        /// <summary>
        /// 处理点(可用值: 广州; 深圳; 上海)
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 是否挂号
        /// </summary>
        public bool IsTracking { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 包裹信息
        /// </summary>
        public List<ExpressPackage> PackageList { get; set; }

        /// <summary>
        /// 是否广州仓共享
        /// </summary>
        public bool? IsGzShare { get; set; }
    }

    /// <summary>
    /// 直发包裹
    /// </summary>
    public class ExpressPackage 
    {
        /// <summary>
        /// 自定义参考号
        /// </summary>
        public string Custom { get; set; }
        
        /// <summary>
        /// 投递地址
        /// </summary>
        public ShipToAddress ShipToAddress { get; set; }

        /// <summary>
        /// 包装规格
        /// </summary>
        public Packing Packing { get; set; }

        /// <summary>
        /// 包裹重量，单位（克）
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// 客户包裹ID, 用于出错时客户系统标识包裹
        /// </summary>
        public string ClientPackageId { get; set; }

        /// <summary>
        /// 包裹状态
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 包裹追踪号
        /// </summary>
        public string TrackCode { get; set; }

        /// <summary>
        /// 包裹备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 包裹物品列表
        /// </summary>
        public List<ExpressProduct> ProductList { get; set; }

        /// <summary>
        /// 第三方单号
        /// </summary>
        public string RefNo { get; set; }

        /// <summary>
        /// 检查第三方单号是否重复(WebService增加的参数请使用字符类型，其他类型在Get对象时，未刷新客户端代码的会报错)
        /// </summary>
        public string CheckRepeatRefNo { get; set; }
    }

   public class ExpressProduct
    {
        /// <summary>
        /// 产品SKU
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// 库存编码
        /// </summary>
        public string StorageNo { get; set; }

        /// <summary>
        /// 产品申报价值
        /// </summary>
        public decimal DeclareValue { get; set; }

        /// <summary>
        /// 重量
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 中文报关名称(可选项)
        /// </summary>
        public string CustomsTitleCN { get; set; }

        /// <summary>
        /// 英文报关名称
        /// </summary>
        public string CustomsTitleEN { get; set; }

        public virtual StringBuilder Validate(string prefix = null)
        {
            var sbResult = new StringBuilder();

            if (String.IsNullOrEmpty(SKU))
            {
                sbResult.AppendLine(string.Format("{0}SKU 不能为空", prefix));
            }

            if (String.IsNullOrEmpty(CustomsTitleEN))
            {
                sbResult.AppendLine(string.Format("{0}CustomsTitleEN 不能为空", prefix));
            }

            return sbResult;
        }
    }
}
