using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ENETCare.IMS.BusinessLogicLayer;
using ENETCare.IMS.DatabaseAccessLayer;

namespace ENETCare.IMS.WebFrontEnd.Pages.Engineer
{
    public partial class ViewAllClients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
            }
        }

        protected void AllClientsODS_OnSelecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters.Add("district", (ENETCareGlobal.CurrentUser as SiteEngineer).District);
        }

        protected void ShowDetailsBtn_OnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int clientId = int.Parse(ClientsGridView.Rows[row.RowIndex].Cells[1].Text);
            Session["SelectedClientId"] = clientId;
            Response.Redirect("~/Pages/Engineer/ClientAssociatedInterventions.aspx");
        }
    }
}