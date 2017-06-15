using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare.IMS.BusinessLogicLayer
{
    public class ENETCareGlobal
    {
        public static User CurrentUser { get; set; }
        public static UserType CurrentUserType { get; set; }
        public static List<InterventionType> allInterventionTypes { get; set; }
        public static List<Client> allClients { get; set; }
    }
}
