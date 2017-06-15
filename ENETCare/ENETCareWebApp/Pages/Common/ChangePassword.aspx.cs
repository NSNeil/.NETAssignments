using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ENETCare.IMS.BusinessLogicLayer;

namespace ENETCare.IMS.WebFrontEnd
{

    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!User.Identity.IsAuthenticated)
                {
                    Response.Redirect("~/Pages/Common/Login.aspx");
                }
                else
                {
                    PasswordForm.Visible = true;
                }
            }
        }

        protected void ChangePassword_Click(object sender, EventArgs e)
        {

            var userId = User.Identity.GetUserId();
            var oldPassword = OldPassword.Text;
            var newPassword = NewPassword.Text;
            var verifyPassword = VerifyNewPassword.Text;

            var user = new User();
            var userManager = new UserManager();
            var result = user.ChangePassword(userManager, userId, oldPassword, newPassword, verifyPassword);
            if (!result.Succeeded)
            {
                StatusText.Text = result.Error;
                PasswordStatus.Visible = true;
            }
            else
            {
                Response.Redirect("~/Pages/Common/Login.aspx");
            }
        }
    }
}