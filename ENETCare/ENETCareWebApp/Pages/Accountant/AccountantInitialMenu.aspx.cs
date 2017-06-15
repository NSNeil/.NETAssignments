using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ENETCare.IMS.WebFrontEnd.Pages.Accountant
{
    public partial class AccountantInitialMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EngineersAndManagers_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountantEngineersAndManagers.aspx"); 
        }

        protected void Reports_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportsMenuPage.aspx"); 
        }

        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            // authenticationManager.SignOut();
            Response.Redirect("/Pages/Common/ChangePassword.aspx");
        }
    }
}