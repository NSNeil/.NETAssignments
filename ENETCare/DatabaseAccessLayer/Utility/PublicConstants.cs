using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare.IMS.DatabaseAccessLayer.Utility
{
    public class PublicConstants
    {
        public static string ConnectionString
        {
            get
            {
                var connStr = ConfigurationManager.ConnectionStrings["ENETConnection"].ConnectionString;
                return connStr;
            }
        }
    }
}
