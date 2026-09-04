using System;
using System.Data;
using System.Data.SqlClient;

namespace RestaurantManagementSystem.DataAccess
{
    public class DbConnection
    {
        // Line 11: Teacher changes connection string here if using standard SQL Server localhost
        private readonly string _conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RestaurantManagement;Integrated Security=True;";

        public SqlConnection GetConnection() => new SqlConnection(_conStr);

        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection con = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection con = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection con = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}