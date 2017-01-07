using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using uLearnLibrary;

namespace ContentManagmentSystem.Models
{
    public class User
    {
        public IAbstractFactory IAbstractFactory
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public IContent IContent
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }
        public void AddUser() {
            UserManagement um = new UserManagement();
            um.AddNewUser("nik", "nik@n.n", "123", "admin");
        }
    }
}