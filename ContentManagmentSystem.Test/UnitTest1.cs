using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uLearnLibrary;

namespace ContentManagmentSystem.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AuthenticateUserCorrectCredentials()
        {
            UserManagement um = new UserManagement();
            var isAuthenticated = um.Authenticate("ssimmons0", "MtqOJc");
            Assert.IsTrue(isAuthenticated);

        }
        [TestMethod]
        public void AuthenticateUserInCorrectCredentials()
        {
            UserManagement um = new UserManagement();
            var isAuthenticated = um.Authenticate("ssimmons", "MtqO");
            Assert.IsFalse(isAuthenticated);
        }
        [TestMethod]
        public void GetRoleByUsername()
        {
            UserManagement um = new UserManagement();
            var role = um.GetRoleByUsername("ssimmons0");
            Assert.IsNotNull(role);
        }
        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public void GetRoleByIncorrectUsername()
        {
            string userRole = "";
            try
            {
                UserManagement um = new UserManagement();
                userRole = um.GetRoleByUsername("nikola");
            }
            finally
            {
                Assert.IsNull(userRole);
            }
        }
        [TestMethod]
        public void AddNewUser()
        {
            UserManagement um = new UserManagement();
            var user = um.AddNewUser("nikola", "nik@a.a", "123456", "Learner");
            Assert.IsNotNull(user);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateUserPassword()
        {
            UserManagement um = new UserManagement();
            um.UpdateUserPassword("ssimmons0", "ssimmons0");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateUserPasswordShortLength()
        {
            UserManagement um = new UserManagement();
            um.UpdateUserPassword("ssimmons0", "ss0");
        }

        [TestCleanup]
        public void Finalise() {
            SQLManager sqlManager = new SQLManager();
            sqlManager.ResetDatabase();
        }


    }
}
