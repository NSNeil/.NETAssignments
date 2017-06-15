using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity.Migrations.Sql;

namespace ENETCare.IMS.BusinessLogicLayer
{
    public class ClientManager
    {
        public Client CreateClient(string address, string name, out string msg, out bool result)
        {
            SiteEngineer currentEngineer = ENETCareGlobal.CurrentUser as SiteEngineer;            
    
            result = true;
            msg = "Client successfully created!";
            return new Client
            {
                Address = address,
                Name = name,
                District = (ENETCareGlobal.CurrentUser as SiteEngineer).District
            };
        }
    }
}