using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENETCare.IMS.BusinessLogicLayer;
using Moq;
using Microsoft.AspNet.Identity;

namespace ENETCare.Tests
{
    [TestClass]
    public class User_changes_password
    {
        // private IdentityUser identityUser;
        private User user;
        private string username;
        private string oldPassword;
        private IUserManager userManager;
        // private UserResult userResult;
        private string newPassword;
        private string verifyNewPassword;

        // private User user;

        [TestInitialize]
        public void Setup()
        {
            username = "david";
            oldPassword = "123456";

            var userManagerMock = new Mock<IUserManager>();

            userManagerMock.Setup(u => u.ChangePasswordAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new UserResult { Error = "some kind of error" });
            userManagerMock.Setup(u => u.ChangePasswordAsync(username, oldPassword, It.IsAny<string>())).Returns(new UserResult());
            userManager = userManagerMock.Object;
            user = new User();
        }

        [TestMethod]
        public void Password_change_succeeds_with_valid_user_pass()
        {
            username = "david";
            oldPassword = "123456";
            newPassword = "1234567";
            verifyNewPassword = "1234567";

            var result = user.ChangePassword(userManager, username, oldPassword, newPassword, verifyNewPassword);

            Assert.IsTrue(result.Succeeded);
            Assert.IsNull(result.Error);
        }

        [TestMethod]
        public void Password_change_fails_with_invalid_password()
        {
            username = "david";
            oldPassword = "blahblah";
            newPassword = "1234567";
            verifyNewPassword = "1234567";

            var result = user.ChangePassword(userManager, username, oldPassword, newPassword, verifyNewPassword);

            Assert.IsFalse(result.Succeeded);
            Assert.IsNotNull(result.Error);
        }

        [TestMethod]
        public void Password_change_fails_when_new_passwords_dont_match()
        {
            username = "david";
            oldPassword = "123456";
            newPassword = "1234567";
            verifyNewPassword = "12345678";

            var result = user.ChangePassword(userManager, username, oldPassword, newPassword, verifyNewPassword);

            Assert.IsFalse(result.Succeeded);
            Assert.IsNotNull(result.Error);
        }
    }
}
