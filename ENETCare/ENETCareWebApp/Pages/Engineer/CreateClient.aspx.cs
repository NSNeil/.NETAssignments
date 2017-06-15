using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Data.SqlClient;
using ENETCare.IMS.BusinessLogicLayer;
using ENETCare.IMS.DatabaseAccessLayer;

namespace ENETCare.IMS.WebFrontEnd.Pages.Engineer
{
    public partial class CreateClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DistrictLabel.Text = (ENETCareGlobal.CurrentUser as SiteEngineer).District;
            TextBox_ClientDescriptiveLocation.MaxLength = 100;
            TextBox_ClientName.MaxLength = 50;
        }

        protected void Button_CreateClient_Click(object sender, EventArgs e)
        {
            string clientName = TextBox_ClientName.Text;
            string clientDescLocation = TextBox_ClientDescriptiveLocation.Text;
            string msg = "";
            bool result = false;
            Client newClient = new ClientManager().CreateClient(clientDescLocation, clientName, out msg, out result);

            if (TextBox_ClientDescriptiveLocation.Text.Length < 100)
            {
                if (TextBox_ClientName.Text.Length < 50)
                {
                    if (result)
                    {
                        new ClientRepository().Insert(newClient);
                        ErrorLabel.Text = "Success";
                    }
                    else
                    {
                        ErrorLabel.Text = msg;
                    }
                }
                else
                {
                    ErrorLabel.Text = "Name too long, character limit is 50";
                }
            }
            else
            {
                ErrorLabel.Text = "Location too long, character limit is 100";
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox_ErrorMsg.Visible = false;
        }

        protected void DropDownList_ClientDistrict_DataBinding(object sender, EventArgs e)
        {
            
        }

        protected void DropDownList_ClientDistrict_CreatingModelDataSource(object sender, CreatingModelDataSourceEventArgs e)
        {

        }

        protected void DropDownList_ClientDistrict_CallingDataMethods(object sender, CallingDataMethodsEventArgs e)
        {
            
        }
    }
}