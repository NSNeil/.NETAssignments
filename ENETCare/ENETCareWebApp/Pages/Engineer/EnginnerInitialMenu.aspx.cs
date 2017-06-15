using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace ENETCare.IMS.WebFrontEnd.Pages.Engineer
{
    public partial class EnginnerInitialMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.IsInRole("SiteEngineer"))
            {
                Response.Redirect("~/Pages/Common/Login.aspx");
            }
        }

        protected void ChangePwdBtn_Click(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            // authenticationManager.SignOut();
            Response.Redirect("/Pages/Common/ChangePassword.aspx");
        }

        protected void CreateClientBtn_Click(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            // authenticationManager.SignOut();
            Response.Redirect("/Pages/Engineer/CreateClient.aspx");
        }

        protected void CreateInterventionBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/Engineer/CreateIntervention.aspx");
        }

        protected void InterventionHistoryBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/Engineer/ViewAllInterventions.aspx");
        }

        protected void ViewAllClientsBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/Engineer/ViewAllClients.aspx");
        }
    }
}