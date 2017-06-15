using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare.IMS.BusinessLogicLayer
{
    public interface IUserManager
    {
        IdentityUser ValidateIdentityUser(string userName, string userPwd);
        void SignInIdentity(IdentityUser identityUser);
        UserResult ChangePasswordAsync(string userId, string oldPassword, string newPassword);

    }
}
