using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ENETCare.IMS.WebFrontEnd.Pages.Accountant
{
    public partial class AccountantsAndManagersMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ViewManagersAndEngineers_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountantEngineersAndManagers.aspx");
        }
    }
}