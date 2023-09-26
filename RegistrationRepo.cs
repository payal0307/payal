using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
namespace OlxDemo.Models
{
    public class RegistrationRepo
    {
        //private SqlConnection con;

        //private void connection()
        //{
        //    string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        //    con = new SqlConnection(constr);

        //}
        //public bool IsEmailAlreadyExists(string userEmail)
        //{
        //    string query = "SELECT COUNT(*) FROM Users WHERE userEmail = @userEmail";

        //    SqlCommand cmd = new SqlCommand(query, con);
        //    cmd.Parameters.AddWithValue("@userEmail", userEmail);

        //    if (con.State == ConnectionState.Closed)
        //        con.Open();

        //    int userCount = (int)cmd.ExecuteScalar();

        //    return userCount > 0; 
        //}


        //public void InsertUser(RegistrationModel obj)
        //{
        //    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
        //    {
        //        SqlCommand cmd = new SqlCommand("insertuser", con);


        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.AddWithValue("@firstName", obj.firstName);
        //        cmd.Parameters.AddWithValue("@lastName", obj.lastName);
        //        cmd.Parameters.AddWithValue("@userEmail", obj.userEmail);

        //        cmd.Parameters.AddWithValue("@Password", obj.Password);
        //        cmd.Parameters.AddWithValue("@MobileNo", obj.MobileNo);

        //        cmd.Parameters.AddWithValue("@Gender", obj.Gender);
        //        cmd.Parameters.AddWithValue("@Address", obj.Address);
        //        cmd.Parameters.AddWithValue("@City", obj.City);
        //        con.Open();
        //        int i = cmd.ExecuteNonQuery();
        //        con.Close();
        //    }
        public void InsertUser(RegistrationModel obj)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
            { 

                // Create a SqlCommand for the stored procedure
            SqlCommand cmd = new SqlCommand("insertuser", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Add parameters
            cmd.Parameters.AddWithValue("@firstName", obj.firstName);
            cmd.Parameters.AddWithValue("@lastName", obj.lastName);
            cmd.Parameters.AddWithValue("@userEmail", obj.userEmail);
            cmd.Parameters.AddWithValue("@Password", obj.Password);
            cmd.Parameters.AddWithValue("@MobileNo", obj.MobileNo);
            cmd.Parameters.AddWithValue("@Gender", obj.Gender);
            cmd.Parameters.AddWithValue("@Address", obj.Address);
            cmd.Parameters.AddWithValue("@City", obj.City);

            try
            {
                // Open the connection
                con.Open();

                // Execute the stored procedure
                int rowsAffected = cmd.ExecuteNonQuery();

                // Check the number of rows affected to determine if the insert was successful
                if (rowsAffected > 0)
                {
                    // Insert successful
                    Console.WriteLine("Data inserted successfully.");
                }
                else
                {
                    // Insert failed
                    Console.WriteLine("Data insertion failed.");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Close the connection
                con.Close();
            }
        }
    }
    }
}
