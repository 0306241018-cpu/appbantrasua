using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public class DatabaseHelper
    {
        private string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=QuanLyTraSua_DB;Integrated Security=True";

        public DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.Fill(dt);
            }
            return dt;
        }

        public void ExecuteNonQuery(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public object ExecuteScalar(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                return cmd.ExecuteScalar();
            }
        }
    }
}
