using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uLearnLibrary;
using System.Data;
using System.Linq;
using System.Data.SqlClient;

namespace ContentManagmentSystem.Test
{

    [TestClass]
    public class Section9UnitTests
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
            SqlDataAdapter adapter = new SqlDataAdapter("Select * FROM Users",
                SQLManager.connectionString);

            DataTable dtOriginal = new DataTable();
            adapter.Fill(dtOriginal);

            DataRow newRow = dtOriginal.NewRow();

            newRow["Username"] = "nikola";
            newRow["Email"] = "nik@a.a";
            newRow["Password"] = "123456";
            newRow["UserRole"] = 2;

            var user = um.AddNewUser("nikola", "nik@a.a", "123456", "MaterialDeveloper");
            newRow["Id"] = user;
            dtOriginal.Rows.Add(newRow);

            DataTable dtActual = new DataTable();
            adapter.Fill(dtActual);

            Assert.IsTrue(dtOriginal.IsEqual(dtActual));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNewUserShortPassword()
        {
            DataTable dtOriginal = null;
            DataTable dtActual = null;
            try
            {
                UserManagement um = new UserManagement();
                SqlDataAdapter adapter = new SqlDataAdapter("Select * FROM Users",
                    SQLManager.connectionString);

                dtOriginal = new DataTable();
                adapter.Fill(dtOriginal);

                DataRow newRow = dtOriginal.NewRow();

                newRow["Username"] = "nikola";
                newRow["Email"] = "nik@a.a";
                newRow["Password"] = "123";
                newRow["UserRole"] = 1;
                var user = um.AddNewUser("nikola", "nik@a.a", "123", "Learner");
                newRow["Id"] = user;
                dtOriginal.Rows.Add(newRow);

                dtActual = new DataTable();
                adapter.Fill(dtActual);
            }
            finally
            {
                Assert.IsFalse(dtOriginal.IsEqual(dtActual));
            }
            
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNewUserIncorrectEmail()
        {
            UserManagement um = new UserManagement();
            DataTable dtOriginal = null;
            DataTable dtActual = null;
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("Select * FROM Users",
                    SQLManager.connectionString);

                dtOriginal = new DataTable();
                adapter.Fill(dtOriginal);

                DataRow newRow = dtOriginal.NewRow();

                newRow["Username"] = "nikola";
                newRow["Email"] = "nik.a";
                newRow["Password"] = "123";
                newRow["UserRole"] = 1;
                var user = um.AddNewUser("nikola", "nik.a", "123456", "Learner");
                newRow["Id"] = user;
                dtOriginal.Rows.Add(newRow);

                dtActual = new DataTable();
                adapter.Fill(dtActual);
            }
            finally
            {
                Assert.IsFalse(dtOriginal.IsEqual(dtActual));
            }
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNewUserExistingEmail()
        {
            UserManagement um = new UserManagement();
            DataTable dtOriginal = null;
            DataTable dtActual = null;
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("Select * FROM Users",
                    SQLManager.connectionString);

                dtOriginal = new DataTable();
                adapter.Fill(dtOriginal);

                DataRow newRow = dtOriginal.NewRow();

                newRow["Username"] = "nikola";
                newRow["Email"] = "wjacobs0@nhs.uk";
                newRow["Password"] = "123456";
                newRow["UserRole"] = 1;
                var user = um.AddNewUser("nikola", "wjacobs0@nhs.uk", "123456", "Learner");
                newRow["Id"] = user;
                dtOriginal.Rows.Add(newRow);

                dtActual = new DataTable();
                adapter.Fill(dtActual);
            }
            finally
            {
                Assert.IsFalse(dtOriginal.IsEqual(dtActual));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateUserPasswordShortLength()
        {
            UserManagement um = new UserManagement();
            string username = "ssimmons0";
            try
            {
                um.UpdateUserPassword("ssimmons0", "ss0");
            }
            finally
            {
                string userPass = SQLManager.GetPasswordByUser(username);
                Assert.AreNotEqual("ss0", userPass);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public void UpdateUserPasswordUnavailableUser()
        {
            UserManagement um = new UserManagement();
            string username = "ssimmons0123";
            string email = "wjacobs0@nhs.uk";
            try
            {
                um.UpdateUserPassword(username, "ss0123312");
            }
            finally {
                var currentUserPass = SQLManager.GetPasswordFromEmail(email);

                Assert.AreNotEqual(currentUserPass, "ss0123312");
            }
        }
        [TestMethod]
        public void UpdateUserPasswordCorrectLength()
        {

            string username = "ssimmons0";

            UserManagement um = new UserManagement();
            um.UpdateUserPassword(username, "123456");

            string newPass = SQLManager.GetPasswordByUser(username);
            Assert.AreEqual(newPass, "123456");
        }

        [TestCleanup]
        public void Finalise() {
            SQLManager.ResetDatabase();
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