using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmMain : Form
    {
        private Form activeForm;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Phan quyen: NhanVien thi an cac nut khong duoc truy cap
            if (UserSession.VaiTro == "NhanVien")
            {
                guna2Button2.Visible = false;
                guna2Button3.Visible = false;
             
            }
            guna2Button1.HoverState.FillColor = Color.FromArgb(255, 228, 181);
            guna2Button2.HoverState.FillColor = Color.FromArgb(255, 228, 181)
                
                ;
            guna2Button3.HoverState.FillColor = Color.FromArgb(255, 228, 181);
            guna2Button11.HoverState.FillColor = Color.FromArgb(255, 228, 181);


            OpenChildForm(new frmSanPham());
        }

        public void OpenChildForm(Form childForm)
        {
            // Đóng form cũ nếu đang mở
            if (activeForm != null) activeForm.Close();

            activeForm = childForm;

            // Cấu hình form con
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            // Chỗ duy nhất được dùng Dock để Form con giãn vừa khít pnlDesktop
            childForm.Dock = DockStyle.Fill;

            // Thêm vào Panel
            pnlDesktop.Controls.Add(childForm);
            pnlDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
          
        }

        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
           
        }

        private void btnTopping_Click(object sender, EventArgs e)
        {
          
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
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

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult ds = MessageBox.Show("Bạn có muốn đăng xuất không", "GO SALO", MessageBoxButtons.YesNo
             , MessageBoxIcon.Error);
            if (ds == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmSanPham());
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTopping());
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
           
            OpenChildForm(new frmBaoCao());
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmKhuyenMai());
        }

        private void grbContent_Enter(object sender, EventArgs e)
        {

        }
    }
}
