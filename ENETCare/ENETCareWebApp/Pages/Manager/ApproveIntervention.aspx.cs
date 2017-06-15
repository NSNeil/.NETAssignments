using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.IMS.BusinessLogicLayer;
using ENETCare.IMS.DatabaseAccessLayer;

namespace ENETCare.IMS.WebFrontEnd.Pages.Manager
{
    public partial class ApproveIntervention : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ApproveInterventionODS_OnSelecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters.Add("manager", (ENETCareGlobal.CurrentUser as BusinessLogicLayer.Manager));
        }

        protected void ApproveButton_OnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int interventionId = int.Parse(ApproveInterventionsGridView.Rows[row.RowIndex].Cells[1].Text);
            new InterventionRepository().ApproveIntervention(interventionId);

            ApproveInterventionsGridView.DataBind();
        }
    }
}