using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_V3_SDK.DataObject.Actions
{
    using API_V3_SDK.DataObject.Types;

    using Newtonsoft.Json;

    class SystemGetPackagesResponse : API_V3_Response
    {
        [JsonProperty(PropertyName = "body")]
        public new List<SystemGetPackageInfo> body { get; set; }
    }
}
