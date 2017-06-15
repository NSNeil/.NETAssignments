using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ENETCare.IMS.WebFrontEnd.Pages.Accountant
{
    public partial class ReportsMenuPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountantInitialMenu.aspx");
        }

        protected void TotalCostByEngineer_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewCostByEngineer.aspx"); 
        }

        protected void AverageCostsByEngineer_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountantGetAverageCostNTime.aspx");
        }

        protected void CostPerDistrict_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewCompletedInterventionCostPerDistrict.aspx"); 
        }

        protected void MonthlyCostForDistrict_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountantViewCostPerMonth.aspx");
        }
    }
}