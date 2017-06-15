using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENETCare.IMS.BusinessLogicLayer
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
    }
}