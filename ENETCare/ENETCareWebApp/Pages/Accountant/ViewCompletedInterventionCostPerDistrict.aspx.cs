using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.IMS.DatabaseAccessLayer;
using ENETCare.IMS.BusinessLogicLayer;
using System.Data; 

namespace ENETCare.IMS.WebFrontEnd.Pages.Accountant
{
    public partial class ViewCompletedInterventionCostPerDistrict : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportsMenuPage.aspx"); 
        }

        protected void GetReport_Click(object sender, EventArgs e)
        {

            Decimal totalCost = 0; 
            AccountantReportMaker accInstance = new AccountantReportMaker();
            InterventionRepository accDataBank = new InterventionRepository();

            List<Intervention> accData = accDataBank.GetListAcc();

            DataTable reportTableData = accInstance.GetTotalCostForDistricts(accData, ref totalCost);

            for (int i = 0; i < reportTableData.Rows.Count; i++)
            {
                TableRow t1 = new TableRow();
                TableCell c1 = new TableCell();
                TableCell c2 = new TableCell();
                c1.Text = reportTableData.Rows[i][0].ToString();
                c2.Text = reportTableData.Rows[i][1].ToString();
                t1.Cells.Add(c1);
                t1.Cells.Add(c2);
                ReportOut.Rows.Add(t1);

            }

            TotalCostOut.Text = "Total Cost:" + (totalCost.ToString());
        }
    }
}