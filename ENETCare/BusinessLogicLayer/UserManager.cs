using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.IO;
using Microsoft.Owin.Security;
using System.Web;

namespace ENETCare.IMS.BusinessLogicLayer
{
    public class UserManager : IUserManager
    {
        private static UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();
        private UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(userStore);
        private IdentityResult identityResult = new IdentityResult();

        private void CreateUser(string username, string password, string group, UserStore<IdentityUser> userStore, 
            RoleStore<IdentityRole> roleStore)
        {
            var userManager = new UserManager<IdentityUser>(userStore);
            var user = new IdentityUser() { UserName = username };
            identityResult = userManager.Create(user, password);

            var roleManager = new RoleManager<IdentityRole>(roleStore);
            if (!roleManager.RoleExists(group))
            {
                IdentityResult createResult = roleManager.Create(new IdentityRole { Name = group });
            }

            var user1Id = userManager.FindByName(username).Id;
            if (!userManager.IsInRole(user1Id, group))
            {
                IdentityResult roleResult = userManager.AddToRole(user1Id, group);
            }
        }

        private static void SetUpUser()
        {
            var userStore = new UserStore<IdentityUser>();
            var roleStore = new RoleStore<IdentityRole>();

            UserManager userManager = new UserManager();
            userManager.CreateUser("Dean", "123456", "SiteEngineer", userStore, roleStore);
            userManager.CreateUser("Kim", "123456", "SiteEngineer", userStore, roleStore);
            userManager.CreateUser("Sam", "123456", "Manager", userStore, roleStore);
            userManager.CreateUser("Mark", "123456", "Accountant", userStore, roleStore);
        }

        public static void SetupIdentityDB()
        {
            // var filePath = @"|DataDirectory|\WebFormsIdentity.mdf";
            var dataDirectory = AppDomain.CurrentDomain.GetData("DataDirectory");
            var filePath = dataDirectory + @"\WebFormsIdentity.mdf"; 
            if (!File.Exists(filePath))
            {
                // throw new Exception("error");
                SetUpUser();
            }
        }

        public IdentityUser ValidateIdentityUser(string userName, string userPwd)
        {
            var dbUser = userManager.Find(userName, userPwd);
            return dbUser;
        }

        public void SignInIdentity(IdentityUser identityUser)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            var userIdentity = userManager.CreateIdentity(identityUser, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);
        }

        public UserResult ChangePasswordAsync(string userId, string oldPassword, string newPassword)
        {
            var taskResult = userManager.ChangePasswordAsync(userId, oldPassword, newPassword);
            identityResult = taskResult.Result;
            var userResult = new UserResult();

            if (!identityResult.Succeeded)
            {
                string error = null;
                foreach (string e in identityResult.Errors)
                {
                    error = error + "; " + e;
                }
                userResult.Error = error;
            }
            return userResult;
        }
    }
}
