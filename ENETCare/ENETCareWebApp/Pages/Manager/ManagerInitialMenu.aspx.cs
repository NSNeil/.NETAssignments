using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.IMS.BusinessLogicLayer;

namespace ENETCare.IMS.WebFrontEnd
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ChangePwdBtn_Click(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            // authenticationManager.SignOut();
            Response.Redirect("/Pages/Common/ChangePassword.aspx");
        }


        protected void ApproveBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/Manager/ApproveIntervention.aspx");
        }
    }
}