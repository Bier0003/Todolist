using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata;


namespace Todolist
{
    public class DBconnect
    {   
        private static string conn = @"Data Source=DESKTOP-PLCDDAP\SQLEXPRESS;Initial Catalog=todolist;User ID=Bier;Password=Beer-1993;Trusted_Connection=True;TrustServerCertificate=True;";

        private static SqlConnection _connection = new SqlConnection(conn);
        //SqlConnection conn;
        public DBconnect()
        {
           
        }
        // Connection string contains information about the database connection
        
        public static SqlConnection GetConnection() => _connection;
      

        public void ConnectDatabase()
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    // Open the database connection
                    connection.Open();

                    // Perform database operations here...

                    Console.WriteLine("Connection successful!");

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
       
        
    

    
