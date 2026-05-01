using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms; // Thêm để dùng MessageBox

namespace WindowsFormsApp1
{
    public class DatabaseHelper
    {
        // Kiểm tra kỹ tên Database trong Initial Catalog
        private string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=QuanLyTraSua_DB;Integrated Security=True";

        public DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        public void ExecuteNonQuery(string sql)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi SQL: " + ex.Message);
            }
        }

        public object ExecuteScalar(string sql)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ExecuteScalar: " + ex.Message);
                return null;
            }
        }
    }
}