using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uLearnLibrary;

namespace ContentManagmentSystem.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            UserManagement um = new UserManagement();
            um.AddNewUser("nik", "nik@n.n", "123456", "admin");
        }
    }
}
