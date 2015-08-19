﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_V3_SDK.DataObject.Actions
{
    using System.IO;

    using API_V3_SDK.DataObject.Types;

    using Newtonsoft.Json;

    class DirectExpressPrintLabelResponse : API_V3_Response
    {
        [JsonProperty(PropertyName = "body")]
        public new MemoryStream body { get; set; }
    }
}