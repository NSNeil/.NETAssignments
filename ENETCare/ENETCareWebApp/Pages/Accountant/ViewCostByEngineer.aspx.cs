﻿using System;
using System.Data;
using System.Collections; 
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.IMS.BusinessLogicLayer;
using ENETCare.IMS.DatabaseAccessLayer;

namespace ENETCare.IMS.WebFrontEnd.Pages.Accountant
{
    public partial class ViewCostByEngineer : System.Web.UI.Page
    { 

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportsMenuPage.aspx");
        }

        protected void GenerateReport_Click(object sender, EventArgs e)
        {
            AccountantReportMaker accInstance = new AccountantReportMaker();
            InterventionRepository accDataBank = new InterventionRepository();
            //EngineerCostDummy accDataBank = new EngineerCostDummy(); 
            List<Intervention> accData = accDataBank.GetListAcc();

            DataTable reportTableData = accInstance.GetTotalCostPerEngineer(accData); 

            for (int i = 0; i < reportTableData.Rows.Count; i++)
            {
                TableRow t1 = new TableRow();
                TableCell c1 = new TableCell();
                TableCell c2 = new TableCell();
                TableCell c3 = new TableCell(); 
                c1.Text = reportTableData.Rows[i][0].ToString();
                c2.Text = reportTableData.Rows[i][1].ToString(); 
                c3.Text = reportTableData.Rows[i][2].ToString();
                t1.Cells.Add(c1);
                t1.Cells.Add(c2);
                t1.Cells.Add(c3);
                ReportOut.Rows.Add(t1);
            }
        }
    }
}