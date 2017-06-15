using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENETCare.IMS.BusinessLogicLayer
{
    public class InterventionType
    {
        public int InterventionTypeId { get; set; }
        //Default hours of labour for the type
        public int DefaultLabourHours { get; set; }
        //Default cost for the type
        public decimal DefaultCost { get; set; }
        public string Name { get; set; }
    }
}