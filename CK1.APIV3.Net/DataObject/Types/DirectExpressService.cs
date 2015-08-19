using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_V3_SDK.DirectExpress.DataObject
{
    using Newtonsoft.Json;

    public class DirectExpressService
    {
        [JsonProperty(PropertyName = "type_id")]
        public int TypeId { get; set; }

        [JsonProperty(PropertyName = "symbol_code")]
        public string ServiceCode { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string ServiceName { get; set; }

        [JsonProperty(PropertyName = "can_import_tracking")]
        public bool CanImportTracking { get; set; }

        [JsonProperty(PropertyName = "can_show")]
        public bool CanShow { get; set; }

        [JsonProperty(PropertyName = "express_type")]
        public string ExpressType { get; set; }

        [JsonProperty(PropertyName = "force_tracking")]
        public bool IsTracking { get; set; }

        [JsonProperty(PropertyName = "in_service")]
        public bool InService { get; set; }

        [JsonProperty(PropertyName = "limitation_day_min")]
        public int LimitationDayMin { get; set; }
        
        [JsonProperty(PropertyName = "limitation_day_max")]
        public int LimitationDayMax { get; set; }

        [JsonProperty(PropertyName = "max_allow_packing_cm")]
        public string MaxAllowPacking { get; set; }

        [JsonProperty(PropertyName = "max_allow_weight_in_kg")]
        public decimal MaxAllowWeightInKg { get; set; }

        [JsonProperty(PropertyName = "need_calculate_volumeweight")]
        public bool NeedCalculateVolumeWeight { get; set; }
        
        [JsonProperty(PropertyName = "volumn_weight_factor_cm_to_gram")]
        public int VolumnWeightFactorCmToGram { get; set; }
    }
}
