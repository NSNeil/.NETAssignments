using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.IMS.DatabaseAccessLayer;
using ENETCare.IMS.BusinessLogicLayer; 
namespace ENETCare.IMS.WebFrontEnd.Pages.Accountant
{
    public partial class AccountantEngineersAndManagers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ViewSiteEngineers_Click(object sender, EventArgs e)
        {
            SiteEngineerRepository engineerDataRepo = new SiteEngineerRepository();
            List<SiteEngineer> siteEngineersForDisplay = engineerDataRepo.GetSiteEngineerList();
            for (int i = 0; i < siteEngineersForDisplay.Count; i++)
            {
                TableRow t1 = new TableRow();
                TableCell c1 = new TableCell();
                TableCell c2 = new TableCell();
                c1.Text = (siteEngineersForDisplay[i].SiteEngineerId).ToString(); 
                c2.Text = siteEngineersForDisplay[i].Name;
                t1.Cells.Add(c1);
                t1.Cells.Add(c2);
                ReportOut.Rows.Add(t1);

            }


        }

        protected void ViewManagers_Click(object sender, EventArgs e)
        {
            ManagerRepository managerDataRepo = new ManagerRepository();
            BusinessLogicLayer.Manager manager1 = new BusinessLogicLayer.Manager(); 
            List<BusinessLogicLayer.Manager> mangersForDisplay = managerDataRepo.GetManagerListFromDb();
            for (int i = 0; i < mangersForDisplay.Count; i++)
            {
                TableRow t1 = new TableRow();
                TableCell c1 = new TableCell();
                TableCell c2 = new TableCell();
                c1.Text = (mangersForDisplay[i].ManagerId).ToString();
                c2.Text = mangersForDisplay[i].Name;
                t1.Cells.Add(c1);
                t1.Cells.Add(c2);
                ReportOut.Rows.Add(t1);

            }
        }
    }
}