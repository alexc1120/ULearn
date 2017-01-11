using System.Data.SqlClient;
using System.IO;

namespace ContentManagmentSystem
{
    public class SQLManager
    {
        string connectionString;
        public SQLManager() {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

        }

        public void ResetDatabase()
        {
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
        public string GetPasswordByUser(string username) {

            string passwordFound = "";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand command = new SqlCommand("SELECT [Password] FROM Users WHERE Username=@Username;", conn);
            command.Parameters.AddWithValue("@Username", username);
            // int result = command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read()) {
                    passwordFound = reader.GetString(0);
                }
            }
            return passwordFound;
        }

    }
}
