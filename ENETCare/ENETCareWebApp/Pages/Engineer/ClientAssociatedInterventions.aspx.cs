using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ENETCare.IMS.WebFrontEnd.Pages.Engineer
{
    public partial class ClientAssociatedInterventions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void AssociatedInterventionODS_OnSelecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            if (Session["SelectedClientId"] != null)
            {
                e.InputParameters.Add("clientId", int.Parse(Session["SelectedClientId"].ToString()));
            }
            else
            {
                e.InputParameters.Add("clientId", -1);
            }
        }

        protected void OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Engineer/ViewAllClients.aspx");
        }
    }
}