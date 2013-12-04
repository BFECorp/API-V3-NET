using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace API_V3_SDK.M2C
{
    class Stock
    {
        public static Dictionary<string, string> Dispatcher =
            new Dictionary<string, string>
                {
                    {"category", "m2c"},
                    {"handler", "stock"},
                };

        public static bool SendListShareStockRequest()
        {
            Dispatcher["action"] = "list-share-stock";
            var requestUrl = CK1API_SDK_Base.CreateRequestUrl(Dispatcher);

            var parameters = new Dictionary<string, string> {{"start_index", "1"}, {"count", "20"}};
            //parameters.Add("packing", "1*1*1");
            //parameters.Add("weight_in_gram", "50");

            var json = HttpHelper.HttpGet(requestUrl, parameters);

            var response = JsonConvert.DeserializeObject<ListShareStockResponse>(json);
            return response.meta.IsOKMeta();
        }
    }

    class ListShareStockResponse : API_V3_Response
    {
        [JsonProperty(PropertyName = "body")]
        public ShareStockInfo Body { get; set; }
    }

    class ShareStockInfo
    {
        [JsonProperty(PropertyName = "start_index")]
        public int StartIndex { get; set; }

        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }

        [JsonProperty(PropertyName = "show_all")]
        public bool ShowAll { get; set; }

        [JsonProperty(PropertyName = "warehouse")]
        public string Warehouse { get; set; }

        [JsonProperty(PropertyName = "begin_date")]
        public string BeginDate { get; set; }

        [JsonProperty(PropertyName = "end_date")]
        public string EndDate { get; set; }

        [JsonProperty(PropertyName = "total_count")]
        public int TotalCount { get; set; }

        [JsonProperty(PropertyName = "sharers")]
        public string Sharers { get; set; }

        [JsonProperty(PropertyName = "storage_nos")]
        public string StorageNos { get; set; }

        [JsonProperty(PropertyName = "products")]
        public List<ShareStockItem> Products { get; set; }
    }

    internal class ShareStockItem
    {
        [JsonProperty(PropertyName = "sku")]
        public string Sku { get; set; }

        [JsonProperty(PropertyName = "sharer")]
        public string Sharer { get; set; }

        [JsonProperty(PropertyName = "weight_in_gram")]
        public int WeightInGram { get; set; }

        [JsonProperty(PropertyName = "packing")]
        public string Packing { get; set; }

        [JsonProperty(PropertyName = "warehouse")]
        public string WarehouseCode { get; set; }

        [JsonProperty(PropertyName = "storage_no")]
        public string StorageNo { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "free_shipping")]
        public bool FreeShipping { get; set; }

        [JsonProperty(PropertyName = "avail_stock")]
        public int AvailableStock { get; set; }

        [JsonProperty(PropertyName = "share_stock")]
        public int ShareStock { get; set; }

        [JsonProperty(PropertyName = "start_date")]
        public string StartDateStr { get; set; }

        [JsonProperty(PropertyName = "expire_date")]
        public string ExpireDateStr { get; set; }
    }
}
