using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_V3_SDK.DataObject.Types
{
    public enum LabelPrintFormat
    {
        classic_label = 1,
        classic_a4 = 2
    }
    public enum LabelContentType
    {
        address = 1,
        address_costoms = 2,
        address_costoms_split = 3,
        address_remark = 4,
        address_customs_remark_split = 5,
    }
}
