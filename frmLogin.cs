using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = guna2TextBox1.Text.Trim();
            string password = guna2TextBox2.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "GO SALO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                guna2TextBox1.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "GO SALO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                guna2TextBox2.Focus();
                return;
            }

            DatabaseHelper db = new DatabaseHelper();
            string query = $"SELECT MaNV, TenDangNhap, HoTen, VaiTro FROM NhanVien WHERE TenDangNhap = '{username}' AND MatKhau = '{password}' AND TrangThai = 1";
            DataTable result = db.GetDataTable(query);

            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                UserSession.SetSession(
                    Convert.ToInt32(row["MaNV"]),
                    row["TenDangNhap"].ToString(),
                    row["HoTen"].ToString(),
                    row["VaiTro"].ToString()
                );

                MessageBox.Show("Đăng nhập thành công! Xin chào " + UserSession.HoTen, "GO SALO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmMain mainForm = new frmMain();
                this.Hide();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "GO SALO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2TextBox2.Clear();
                guna2TextBox2.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult ds = MessageBox.Show(
                "Bạn có muốn thoát chương trình không?",
                "GO SALO",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Error
                );

            if (ds == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            guna2TextBox1.Focus();
            guna2TextBox1.PlaceholderText = "Nhập tên đăng nhập";
            guna2TextBox1.FillColor = Color.WhiteSmoke;
            guna2TextBox1.ForeColor = Color.Black;
            guna2TextBox2.PlaceholderText = "Nhập mật khẩu";
            guna2TextBox2.FillColor = Color.WhiteSmoke;
            guna2TextBox2.ForeColor = Color.Black;
            guna2TextBox1.BackColor = Color.Transparent;
            guna2TextBox2.BackColor = Color.Transparent;
            lblTitle.BackColor = Color.Transparent;

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
