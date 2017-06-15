using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Host.SystemWeb;

namespace ENETCare.IMS.BusinessLogicLayer
{
    public class User
    {
        // private UserManager userManager = new UserManager();

        public int UserId { get; set; }
        private string LoginName { get; set; }
        public string Name { get; set; }

        public UserResult ValidateUserInfo(IUserManager userManager, string userName, string userPwd)
        {

            var userResult = new UserResult();
            var identityUser = userManager.ValidateIdentityUser(userName.ToLower(), userPwd);

            if (identityUser == null)
            {
                userResult.Error = "Invalid username or password.";
            }
            else
            {
                userManager.SignInIdentity(identityUser);
            }

            return userResult;
        }

        public UserResult ChangePassword(IUserManager userManager, string userId, string oldPassword, string newPassword, string verifyPassword)
        {
            var userResult = new UserResult();

            if (newPassword != verifyPassword)
            {
                userResult.Error = "Passwords do not match, please try again.";

                return userResult;
            }
            
            userResult = userManager.ChangePasswordAsync(userId, oldPassword, newPassword);

            return userResult;
        }
    }
}