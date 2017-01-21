using System.Data.SqlClient;
using System.IO;

namespace ContentManagmentSystem
{
    public static class SQLManager
    {
        public static string connectionString =
            System.Configuration.ConfigurationManager
            .ConnectionStrings["DBConnection"].ConnectionString;
        
        public static void ResetDatabase()
        {
            FileInfo file = new FileInfo("../../Scripts/DbScripts.sql");
            string script = file.OpenText().ReadToEnd();
            string resetIdScript = "DBCC CHECKIDENT('Users', RESEED, 0);DBCC CHECKIDENT('Roles', RESEED, 0); ";

            SqlConnection cnn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();    
            cmd.Connection = cnn;
            cmd.CommandTimeout = 1000;
            cmd.CommandText = "DELETE From Users;DELETE FROM Roles;"+ resetIdScript + script;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
         }
        public static string GetPasswordByUser(string username) {

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
        public static string GetPasswordFromEmail(string email)
        {

            string passwordFound = "";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand command = new SqlCommand("SELECT [Password] FROM Users WHERE Email=@Email;", conn);
            command.Parameters.AddWithValue("@Email", email);
            // int result = command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    passwordFound = reader.GetString(0);
                }
            }
            return passwordFound;
        }

    }
}
