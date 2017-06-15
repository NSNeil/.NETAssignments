using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare.IMS.BusinessLogicLayer
{
    public class UserResult
    {
        public bool Succeeded
        {
            get
            {
                if (Error != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            private set { }
        }
        public string Error { get; set; }
    }
}
