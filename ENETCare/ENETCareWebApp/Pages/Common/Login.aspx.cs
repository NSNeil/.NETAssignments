using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.IMS.BusinessLogicLayer;
using ENETCare.IMS.DatabaseAccessLayer;

namespace ENETCare.IMS.WebFrontEnd.Pages.Common
{
	public partial class Login : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                {
                    var userLogon = HttpContext.Current.User.Identity.GetUserName();

                    if (HttpContext.Current.User.IsInRole("Manager"))
                    {
                        ENETCareGlobal.CurrentUser = new ManagerRepository().GetOne(userLogon);
                        ENETCareGlobal.CurrentUserType = UserType.SiteEngineer;
                        Response.Redirect("~/Pages/Manager/ManagerInitialMenu.aspx");
                    }
                    else if (HttpContext.Current.User.IsInRole("SiteEngineer"))
                    {
                        SiteEngineerRepository siteEngineerRepository = new SiteEngineerRepository();
                        ENETCareGlobal.CurrentUser = siteEngineerRepository.GetOne(userLogon);
                        ENETCareGlobal.CurrentUserType = UserType.SiteEngineer;
                        Response.Redirect("~/Pages/Engineer/EnginnerInitialMenu.aspx");
                    }
                    else if (HttpContext.Current.User.IsInRole("Accountant"))
                    {
                        Response.Redirect("~/Pages/Accountant/AccountantInitialMenu.aspx");
                    }
                    else
                    {
                        throw new Exception("Error selecting user type");
                    }
                }
                else
                {
                    LoginForm.Visible = true;
                }
            }
            
        }

        protected void SignIn(object sender, EventArgs e)
        {
            User user = new User();
            UserManager userManager = new UserManager();
            var result = user.ValidateUserInfo(userManager, UserName.Text, Password.Text);
            if (result.Succeeded == true)
            {
                Response.Redirect("~/Pages/Common/Login.aspx");
            }
            else
            {
                StatusText.Text = result.Error;
                LoginStatus.Visible = true;
            }
        }
    }
}