using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENETCare.IMS.BusinessLogicLayer
{
    public class Manager : User
    {
        public int ManagerId { get; set; }
        public int MaxHours { get; set; }
        public decimal MaxCost { get; set; }
        public string District { get; set; }
    }
}