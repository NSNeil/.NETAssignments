using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.IMS.BusinessLogicLayer;
using ENETCare.IMS.DatabaseAccessLayer;

namespace ENETCare.IMS.WebFrontEnd.Pages.Engineer
{
    public partial class ViewAllInterventions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                RangeDropDownList.SelectedIndex = 0;
                Session["currentRange"] = 0;
            }
        }
        
        protected void InterventionsGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string district = e.OldValues["ProposedBy.District"].ToString();
            string msg = "";
            int proposedById = int.Parse(e.OldValues["ProposedBy.SiteEngineerId"].ToString());
            bool result = new InterventionManager().EvaluateUpdates(proposedById, e.NewValues["Life"].ToString(), e.NewValues["State"] as string, e.OldValues["State"] as string, district, 
                int.Parse(e.OldValues["LabourHours"] as string), decimal.Parse(e.OldValues["Cost"] as string),out msg);

            if (e.NewValues["Note"].ToString().Length>=100)
            {
                ErrorLabel.Text = "Note too long, character limit is 100";
                e.Cancel = true;
            }

            if (result == false)
            {
                ErrorLabel.Text = msg;
                e.Cancel = true;
            }
        }

        protected void RangeDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["currentRange"] != null)
            {
                if ((int)Session["currentRange"] != RangeDropDownList.SelectedIndex)
                {
                    SiteEngineer currentEngineer = ENETCareGlobal.CurrentUser as SiteEngineer;
                    if (RangeDropDownList.SelectedIndex == 0)
                    {
                        InterventionsGridView.DataSourceID = "AllInterventionODS";
                        InterventionsGridView.DataBind();
                        Session["currentRange"] = 0;
                    }
                    else
                    {
                        InterventionsGridView.DataSourceID = "RegionInterventionODS";
                        InterventionsGridView.DataBind();
                        Session["currentRange"] = 1;
                    }
                }
            }
        }

        protected void InterventionRepository_Updating(object sender, ObjectDataSourceMethodEventArgs e)
        {
            ProcessInputParameters(e);
        }

        private void ProcessInputParameters(ObjectDataSourceMethodEventArgs e)
        {
            ErrorLabel.Text = "";
            string state = e.InputParameters["State"].ToString();
            int interventionId = int.Parse(e.InputParameters["original_InterventionId"].ToString());
            float life = float.Parse(e.InputParameters["Life"].ToString());
            string note = e.InputParameters["Note"].ToString();
            string mostRecentVisitDate = e.InputParameters["MostRecentVisitDate"].ToString();

            int approverId = -1;
            if (e.InputParameters["original_State"].ToString() == "Proposed")
            {
                if (state == "Approved" || state == "Complete" || state == "Cancelled")
                {
                    approverId = ENETCareGlobal.CurrentUser.UserId;
                }
            }
            
            for (int i = e.InputParameters.Count; i > 0; i--)
            {
                e.InputParameters.RemoveAt(0);
            }

            e.InputParameters.Add("approverId", approverId);
            e.InputParameters.Add("state", state);
            e.InputParameters.Add("interventionId", interventionId);
            e.InputParameters.Add("life", life);
            e.InputParameters.Add("note", note);
            e.InputParameters.Add("mostRecentVisitDate", mostRecentVisitDate);
        }

        protected void RegionInterventionODS_OnSelecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            SiteEngineer currentEngineer = ENETCareGlobal.CurrentUser as SiteEngineer;

            e.InputParameters.Add("district",currentEngineer.District);
        }

        protected void RegionInterventionODS_Updating(object sender, ObjectDataSourceMethodEventArgs e)
        {
            ProcessInputParameters(e);
        }

        protected void ShowCalendarBtn_OnClick(object sender, ImageClickEventArgs e)
        {
            GridViewRow row = (GridViewRow) ((ImageButton) sender).NamingContainer;
            Calendar calendar = (Calendar)InterventionsGridView.Rows[row.RowIndex].FindControl("InterventionCalendar");
            calendar.Visible = !calendar.Visible;
        }

        protected void InterventionCalendar_OnSelectionChanged(object sender, EventArgs e)
        {
            (sender as Calendar).Visible = false;
            GridViewRow row = (GridViewRow)((Calendar)sender).NamingContainer;
            TextBox tb = (TextBox)InterventionsGridView.Rows[row.RowIndex].FindControl("DateTextBox");
            tb.Text = (sender as Calendar).SelectedDate.ToShortDateString();
        }

        protected void InterventionsGridView_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            ErrorLabel.Text = "";
        }
    }
}