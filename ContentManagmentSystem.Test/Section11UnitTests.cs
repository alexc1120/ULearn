﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uLearnLibrary;
using System.Data.SqlClient;

namespace ContentManagmentSystem.Test
{
    [TestClass]
    public class Section11UnitTests
    {

        #region Authenticate Methods

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void AuthenticateUserTestCase1()
        {
            var isAuthenticated = false;
            try
            {
                UserManagement um = new UserManagement();
                isAuthenticated = um.Authenticate(null, null);
            }
            finally
            {
                Assert.IsFalse(isAuthenticated);
            }
        }
        [TestMethod]
        public void AuthenticateUserTestCase2()
        {
            var isAuthenticated = false;
            UserManagement um = new UserManagement();
            isAuthenticated = um.Authenticate(generateString(201), generateString(256));
            Assert.IsFalse(isAuthenticated);
            
        }

        [TestMethod]
        public void AuthenticateUserTestCase3()
        {
            UserManagement um = new UserManagement();
            var isAuthenticated_1 = um.Authenticate("ssimmons0", generateString(6));
            var isAuthenticated_2 = um.Authenticate("ssimmons0", generateString(100));
            var isAuthenticated_3 = um.Authenticate("ssimmons0", generateString(255));
            Assert.IsFalse(isAuthenticated_1);
            Assert.IsFalse(isAuthenticated_2);
            Assert.IsFalse(isAuthenticated_3);
        }
        [TestMethod]
        public void AuthenticateUserTestCase4()
        {
            var isAuthenticated = false;
            UserManagement um = new UserManagement();
            isAuthenticated = um.Authenticate(string.Empty, string.Empty);
            Assert.IsFalse(isAuthenticated);
        }



        #endregion

        #region Add Users Methods

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void  AddUserTestCase_1() {
            UserManagement um = new UserManagement();
            string username = null;
            string password = generateString(10);
            string email = "nik@hotmail.com";
            string role = "Learner";

            int? id = null;
            try
            {
                id = um.AddNewUser(username, email, password, role);
            }
            finally
            {
                Assert.IsNull(id);
            }
        }
        [TestMethod]
        public void AddUserTestCase_2()
        {
            UserManagement um = new UserManagement();
            string username = generateString(99);
            string password = generateString(6);
            string email = "nik1@hotmail.com";
            string role = "Learner";


            int? id_1 = um.AddNewUser(username, email, password, role);

            password = generateString(100);
            email = "nik2@hotmail.com";
            username = generateString(100);

            int? id_2 = um.AddNewUser(username, email, password, role);

            password = generateString(255);
            email = "nik3@hotmail.com";
            username = generateString(101);

            int? id_3 = um.AddNewUser(username, email, password, role);

            Assert.IsNotNull(id_1);
            Assert.IsNotNull(id_2);
            Assert.IsNotNull(id_3);

        }
        [TestMethod]
        public void AddUserTestCase_3()
        {
            UserManagement um = new UserManagement();
            string username = generateString(1);
            string password = generateString(6);
            string email = "nik1@hotmail.com";
            string role = "Learner";


            int? id_1 = um.AddNewUser(username, email, password, role);
            
            email = "nik2@hotmail.com";
            username = generateString(100);

            int? id_2 = um.AddNewUser(username, email, password, role);
            
            email = "nik3@hotmail.com";
            username = generateString(200);

            int? id_3 = um.AddNewUser(username, email, password, role);

            Assert.IsNotNull(id_1);
            Assert.IsNotNull(id_2);
            Assert.IsNotNull(id_3);
        }


        [TestMethod]
        public void AddUserTestCase_4()
        {
            UserManagement um = new UserManagement();
            string username = generateString(200);
            string password = generateString(6);
            string email = "nik@hotmail.com";
            string role = "Learner";

            int? id_1 = um.AddNewUser(username, email, password, role);

            Assert.IsNotNull(id_1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddUserTestCase_5()
        {
            UserManagement um = new UserManagement();
            string username = generateString(200);
            string password = generateString(6);
            string email = "nik.hotmail.com";
            string role = "Learner";
            int? id_1 = null;
            try
            {
                id_1 = um.AddNewUser(username, email, password, role);
            }
            finally
            {
                Assert.IsNull(id_1);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddUserTestCase_6()
        {
            UserManagement um = new UserManagement();
            string username = generateString(200);
            string password = generateString(6);
            string email = String.Empty;
            string role = "Learner";
            int? id_1 = null;
            try
            {
                id_1 = um.AddNewUser(username, email, password, role);
            }
            finally
            {
                Assert.IsNull(id_1);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddUserTestCase_7()
        {
            UserManagement um = new UserManagement();
            string username = generateString(200);
            string password = generateString(6);
            string email = null;
            string role = "Learner";
            int? id_1 = null;
            try
            {
                id_1 = um.AddNewUser(username, email, password, role);
            }
            finally
            {
                Assert.IsNull(id_1);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddUserTestCase_8()
        {
            UserManagement um = new UserManagement();
            string username = String.Empty;
            string password = generateString(6);
            string email = "nik@hotmail.com";
            string role = "Learner";
            int? id_1 = null;
            try
            {
                id_1 = um.AddNewUser(username, email, password, role);
            }
            finally
            {
                Assert.IsNull(id_1);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddUserTestCase_9()
        {
            UserManagement um = new UserManagement();
            string username = generateString(6);
            string password = string.Empty;
            string email = "nik@hotmail.com";
            string role = "Learner";
            int? id_1 = null;
            try
            {
                id_1 = um.AddNewUser(username, email, password, role);
            }
            finally
            {
                Assert.IsNull(id_1);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddUserTestCase_10()
        {
            UserManagement um = new UserManagement();
            string username = generateString(6);
            string password = null;
            string email = "nik@hotmail.com";
            string role = "Learner";
            int? id_1 = null;
            try
            {
                id_1 = um.AddNewUser(username, email, password, role);
            }
            finally
            {
                Assert.IsNull(id_1);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddUserTestCase_11()
        {
            UserManagement um = new UserManagement();
            string username = generateString(200);
            string password = generateString(6);
            string email = "nik@hotmail.com";
            string role = String.Empty;
            int? id_1 = null;
            try
            {
                id_1 = um.AddNewUser(username, email, password, role);
            }
            finally
            {
                Assert.IsNull(id_1);
            }
        }
        [TestMethod]
        public void AddUserTestCase_12()
        {
            UserManagement um = new UserManagement();
            string username = generateString(199);
            string password = generateString(6);
            string email = "nik@hotmail.com";
            string role = "Learner";

            int? id_1 = um.AddNewUser(username, email, password, role);

            username = generateString(200);
            email = "nik1@hotmail.com";
            role = "MaterialDeveloper";
            int? id_2 = um.AddNewUser(username, email, password, role);

            Assert.IsNotNull(id_1);
            Assert.IsNotNull(id_2);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddUserTestCase_13()
        {
            UserManagement um = new UserManagement();
            string username = generateString(200);
            string password = generateString(6);
            string email = "nik@hotmail.com";
            string role = null;
            int? id_1 = null;
            try
            {
                id_1 = um.AddNewUser(username, email, password, role);
            }
            finally
            {
                Assert.IsNull(id_1);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void AddUserTestCase_14()
        {
            UserManagement um = new UserManagement();
            string username = generateString(201);
            string password = generateString(6);
            string email = "nik@hotmail.com";
            string role = "Learner";
            int? id_1 = null;
            try
            {
                id_1 = um.AddNewUser(username, email, password, role);
            }
            finally
            {
                Assert.IsNull(id_1);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void AddUserTestCase_15()
        {
            UserManagement um = new UserManagement();
            string username = generateString(200);
            string password = generateString(256);
            string email = "nik@hotmail.com";
            string role = "Learner";
            int? id_1 = null;
            try
            {
                id_1 = um.AddNewUser(username, email, password, role);
            }
            finally
            {
                Assert.IsNull(id_1);
            }
        }
        #endregion

        #region Get Role By username

        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public void GetRoleByUsernameTestCase_1()
        {
            UserManagement um = new UserManagement();
            string username = generateString(201);
            string role = null;
            try
            {
                role = um.GetRoleByUsername(username) ;
            }
            finally
            {
                Assert.IsNull(role);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public void GetRoleByUsernameTestCase_2()
        {
            UserManagement um = new UserManagement();
            string username = String.Empty;
            string role = null;
            try
            {
                role = um.GetRoleByUsername(username);
            }
            finally
            {
                Assert.IsNull(role);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public void GetRoleByUsernameTestCase_3()
        {
            UserManagement um = new UserManagement();
            string username = "ssimmons001";
            string role = null;
            try
            {
                role = um.GetRoleByUsername(username);
            }
            finally
            {
                Assert.IsNull(role);
            }
        }
        [TestMethod]
        public void GetRoleByUsernameTestCase_4()
        {
            UserManagement um = new UserManagement();
            string username = "ssimmons0";
            string role = null;
            try
            {
                role = um.GetRoleByUsername(username);
            }
            finally
            {
                Assert.IsTrue(!String.IsNullOrEmpty(role));
            }
        }
        #endregion

        #region Update Password 
        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public void UpdatePasswordTestCase_1()
        {
            UserManagement um = new UserManagement();
            string username = generateString(201);
            string password = generateString(100);
            um.UpdateUserPassword(username,  password);
        }
        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public void UpdatePasswordTestCase_2()
        {
            UserManagement um = new UserManagement();
            string username = String.Empty;
            string password = generateString(100);
            um.UpdateUserPassword(username, password);
        }
        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public void UpdatePasswordTestCase_3()
        {
            UserManagement um = new UserManagement();
            string username = "simmons0";
            string password = generateString(100);
            um.UpdateUserPassword(username, password);
        }
        [TestMethod]
        public void UpdatePasswordTestCase_4()
        {
            UserManagement um = new UserManagement();
            string username1 = "ssimmons0";
            string username2 = "bgonzalez1";
            string username3 = "ldean2";

            string password = generateString(6);
            um.UpdateUserPassword(username1, password);

            string password1 = SQLManager.GetPasswordByUser(username1);

            password = generateString(100);
            um.UpdateUserPassword(username2, password);

            string password2 = SQLManager.GetPasswordByUser(username2);


            password = generateString(255);
            um.UpdateUserPassword(username3, password);

            string password3 = SQLManager.GetPasswordByUser(username3);

            Assert.IsTrue(password1.Equals(generateString(6)));
            Assert.IsTrue(password2.Equals(generateString(100)));
            Assert.IsTrue(password3.Equals(generateString(255)));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdatePasswordTestCase_5()
        {
            UserManagement um = new UserManagement();
            string username = "ssimmons0";
            string password = String.Empty;
            try
            {
                um.UpdateUserPassword(username, password);
            }
            finally {
                var updatedPass = SQLManager.GetPasswordByUser(username);

                Assert.AreNotEqual(updatedPass, string.Empty);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void UpdatePasswordTestCase_6()
        {
            UserManagement um = new UserManagement();
            string username = "ssimmons0";
            string password = generateString(256);
            try
            {
                um.UpdateUserPassword(username, password);
            }
            finally
            {
                var updatedPass = SQLManager.GetPasswordByUser(username);
                Assert.AreNotEqual(updatedPass, string.Empty);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void UpdatePasswordTestCase_7()
        {
            UserManagement um = new UserManagement();
            string username = "ssimmons0";
            string password = null;
            try
            {
                um.UpdateUserPassword(username, password);
            }
            finally
            {
                var updatedPass = SQLManager.GetPasswordByUser(username);
                Assert.AreNotEqual(updatedPass, string.Empty);
            }
        }
        #endregion
        [TestCleanup]
        public void Finalise()
        {
            SQLManager.ResetDatabase();
        }
        private string generateString(int num)
        {
            string generatedString = "";
            for (int i = 0; i < num; i++)
            {
                generatedString += "n";
            }
            return generatedString;
        }
    }
}
