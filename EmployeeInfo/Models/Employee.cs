using System.Data;
using System.Data.SqlClient;

namespace EmployeeInfo.Models
{   
    public class EmployeeController
    {
        string connectionString = @"Data Source=DESKTOP-OE5C2KJ\SQLEXPRESS;Initial Catalog=EmployeeRecords;Integrated Security=True";

        public DataTable GetAllEmployee()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from employee", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable GetEmployeeInfo(int Id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Employee where Id=" + Id, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public int UpdateEmployee(int Id, string FirstName, string MiddleName, string LastName)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Update Employee SET FirstName=@FirstName, MiddleName=@MiddleName , LastName=@LastName where Id=@Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", MiddleName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                cmd.Parameters.AddWithValue("@Id", Id);
                return cmd.ExecuteNonQuery();
            }
        }

        public int InsertEmployee(string FirstName, string MiddleName, string LastName)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Insert into Employee(FirstName, MiddleName, LastName) values(@FirstName, @MiddleName, @LastName)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", MiddleName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                return cmd.ExecuteNonQuery();
            }
        }

        public int DeleteEmployee(int Id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "Delete from Employee where Id=@Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", Id);
                return cmd.ExecuteNonQuery();
            }
        }


    }
}
