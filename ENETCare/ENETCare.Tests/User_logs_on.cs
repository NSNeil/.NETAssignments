using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENETCare.IMS.BusinessLogicLayer;
using Moq;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ENETCare.Tests
{
    [TestClass]
    public class User_logs_on
    {
        private IdentityUser identityUser;
        private User user;
        private string username;
        private string password;
        private IUserManager userManager;

        // private User user;

        [TestInitialize]
        public void Setup()
        {
            username = "david";
            password = "123456";
            identityUser = new IdentityUser();
            identityUser.UserName = username;
            var userManagerMock = new Mock<IUserManager>();
            userManagerMock.Setup(u => u.ValidateIdentityUser(username, password)).Returns(identityUser);
            userManager = userManagerMock.Object;
            user = new User();
        }

        [TestMethod]
        public void Logon_succeeds_when_using_a_valid_user_password()
        {
            username = "david";
            password = "123456";

            var result = user.ValidateUserInfo(userManager, username, password);

            Assert.IsTrue(result.Succeeded);
            Assert.IsNull(result.Error);
        }

        [TestMethod]
        public void Logon_succeeds_when_using_a_valid_uppercase_USERNAME_password()
        {
            username = "DAVID";
            password = "123456";

            var result = user.ValidateUserInfo(userManager, username, password);

            Assert.IsTrue(result.Succeeded);
            Assert.IsNull(result.Error);
        }

        [TestMethod]
        public void Logon_fails_with_invalid_username()
        {
            username = "Davidd";
            password = "123456";

            var result = user.ValidateUserInfo(userManager, username, password);

            Assert.IsFalse(result.Succeeded);
            Assert.IsNotNull(result.Error);
        }

        [TestMethod]
        public void Logon_fails_with_invalid_password()
        {
            username = "David";
            password = "1234566";

            var result = user.ValidateUserInfo(userManager, username, password);

            Assert.IsFalse(result.Succeeded);
            Assert.IsNotNull(result.Error);
        }
    }
}
