using System.Data.SqlClient;
using System.IO;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace ContentManagmentSystem
{
    public class SQLManager
    {

        public void ResetDatabase()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            FileInfo file = new FileInfo("../../Scripts/Users.sql");
            string script = file.OpenText().ReadToEnd();
            string resetIdScript = "DBCC CHECKIDENT('Users', RESEED, 0); ";

            SqlConnection cnn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();    
            cmd.Connection = cnn;
            cmd.CommandTimeout = 1000;
            cmd.CommandText = "DELETE From Users;"+ resetIdScript + script;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
         }

    }
}
