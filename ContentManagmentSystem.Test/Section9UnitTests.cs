using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uLearnLibrary;
using System.Data;
using System.Linq;


namespace ContentManagmentSystem.Test
{
    [TestClass]
    public class Section9UnitTests
    {
        SQLManager sqlManager = new SQLManager();

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
            var data = !String.IsNullOrEmpty(role);
            Assert.IsTrue(data);    
        }
        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public void GetRoleByIncorrectUsername()
        {
            string userRole = "";
            UserManagement um = new UserManagement();
            userRole = um.GetRoleByUsername("nikola");
            
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
        public void AddNewUserShortPassword()
        {
            UserManagement um = new UserManagement();
            var user = um.AddNewUser("nikola", "nik@a.a", "123", "Learner");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNewUserIncorrectEmail()
        {
            UserManagement um = new UserManagement();
            var user = um.AddNewUser("nikola", "nik.a", "123456", "Learner");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNewUserExistingEmail()
        {
            UserManagement um = new UserManagement();
            var user = um.AddNewUser("nikola", "wjacobs0@nhs.uk", "123456", "Learner");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateUserPasswordShortLength()
        {
            UserManagement um = new UserManagement();
            um.UpdateUserPassword("ssimmons0", "ss0");
        }
        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public void UpdateUserPasswordUnavailableUser()
        {
            UserManagement um = new UserManagement();
            um.UpdateUserPassword("ssimmons0123", "ss0123312");
        }
        [TestMethod]
        public void UpdateUserPasswordCorrectLength()
        {

            string username = "ssimmons0";

            string oldPass = sqlManager.GetPasswordByUser(username);

            UserManagement um = new UserManagement();
            um.UpdateUserPassword(username, "123456");

            string newPass = sqlManager.GetPasswordByUser(username);

            Assert.AreNotEqual(oldPass, newPass);
        }

        [TestCleanup]
        public void Finalise() {
            SQLManager sqlManager = new SQLManager();
            sqlManager.ResetDatabase();
        }


    }
}


public static class DatabaseFunctions
{
    public static bool IsEqual(this DataTable dt1, DataTable dt2)
    {
        // if both tables are null, return true
        if (dt1 == null && dt2 == null)
            return true;

        // if only 1 table is null, return false
        if (dt1 == null)
            return false;
        if (dt2 == null)
            return false;

        // if we have different number of rows, return false
        if (dt1.Rows.Count != dt2.Rows.Count)
            return false;

        // if we have different number of columns, return false
        if (dt1.Columns.Count != dt2.Columns.Count)
            return false;

        // Check that each of the columns in dt1 is represented in dt2
        if (dt1.Columns.Cast<DataColumn>().Any(dc => !dt2.Columns.Contains(dc.ColumnName)))
        {
            return false;
        }

        // For each row in dt1
        for (int i = 0; i <= dt1.Rows.Count - 1; i++)
        {
            // check that the same row in dt2 has the same value in each of the columns

            if (dt1.Columns.Cast<DataColumn>().Any(dc1 => dt1.Rows[i][dc1.ColumnName].ToString() != dt2.Rows[i][dc1.ColumnName].ToString()))
            {
                return false;
            }
        }

        // all is ok
        return true;
    }
}