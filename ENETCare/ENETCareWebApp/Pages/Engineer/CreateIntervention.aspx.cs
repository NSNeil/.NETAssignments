using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.IMS.BusinessLogicLayer;
using ENETCare.IMS.DatabaseAccessLayer;

namespace ENETCare.IMS.WebFrontEnd.Pages.Engineer
{
    public partial class CreateIntervention : System.Web.UI.Page
    { 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ENETCareGlobal.allInterventionTypes == null)
            {
                ENETCareGlobal.allInterventionTypes = new InterventionTypeRepository().GetAll("");
            }
            if (!IsPostBack)
            {
                Session["selectedClientIdx"] = null;
            }
            ENETCareGlobal.allClients = new ClientRepository().GetList("");
        }
        
        protected void ShowCalendarBtn_Click(object sender, ImageClickEventArgs e)
        {
            InterventionCalendar.Visible = !InterventionCalendar.Visible;
        }

        protected void InterventionCalendar_SelectionChanged(object sender, EventArgs e)
        {
            InterventionCalendar.Visible = false;
            DateToPerformTextBox.Text = InterventionCalendar.SelectedDate.ToShortDateString();
        }

        protected void CreateBtn_Click(object sender, EventArgs e)
        {
            InterventionType selectedType = null;
            foreach (InterventionType type in ENETCareGlobal.allInterventionTypes)
            {
                if (type.Name == InterventionTypeDropDownList.SelectedValue)
                {
                    selectedType = type;
                }
            }

            int labourHours = -1;
            int.TryParse(LabourHoursTextBox.Text, out labourHours);
            decimal cost = -1;
            decimal.TryParse(CostTextBox.Text, out cost);

            if (DateToPerformTextBox.Text != "")
            {
                if (NoteTextBox.Text.Length < 100)
                {
                    DateTime dt = Convert.ToDateTime(DateToPerformTextBox.Text);

                    bool result = false;
                    string msg = "";

                    if (Session["selectedClientIdx"] != null)
                    {
                        Intervention newIntervention = new InterventionManager().CreateIntervention(selectedType,
                            StateDropDownList.SelectedValue, labourHours, cost, NoteTextBox.Text, dt,
                            ENETCareGlobal.allClients[(int) Session["selectedClientIdx"]], out msg,
                            out result);
                        if (result)
                        {
                            new InterventionRepository().Insert(newIntervention);
                            ErrorLabel.Text = "Success!";
                        }
                        else
                        {
                            ErrorLabel.Text = msg;
                        }
                    }
                    else
                    {
                        ErrorLabel.Text = "Please select a client!";
                    }
                }
                else
                {
                    ErrorLabel.Text = "Note too long, character limit is 100";

                }
            }
            else
            {
                ErrorLabel.Text = "Please select a date!";
            }
        }

        protected void ViewAllClientsBtn_Click(object sender, EventArgs e)
        {
            if (ClientGridView.DataSource == null)
            {
                ClientGridView.DataSource = ENETCareGlobal.allClients;
                ClientGridView.DataBind();
            }
        }

        protected void ChooseBtn_OnClick(object sender, EventArgs e)
        {

        }

        protected void ChooseBtn_OnCommand(object sender, CommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = ClientGridView.Rows[index];
            ClientTextBox.Text = row.Cells[2].Text;
            Session["selectedClientIdx"] = index;
        }
    }
}