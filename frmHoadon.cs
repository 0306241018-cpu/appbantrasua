using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class frmHoadon : Form
    {
        // Chuỗi kết nối Database
        private string connStr = @"Data Source=ADMINISTRATOR\SQLEXPRESS; Initial Catalog=QuanLyTraSua_DB; Integrated Security=True; TrustServerCertificate=True;";

        // Action thông báo
        public Action OnXacNhanThanhCong { get; set; }

        public frmHoadon()
        {
            InitializeComponent();
        }

        public frmHoadon(string maKH, int maHD, int tongTien, List<frmTrangchu.SanPham> gioHang)
        {
            InitializeComponent();
            string maKHFinal = TaoMaKhachHangTuDong();
            ThietKeGiaoDienHoaDon(maKHFinal, maHD, tongTien, gioHang);
        }

        private string TaoMaKhachHangTuDong()
        {
            return "KH" + DateTime.Now.ToString("yyMMddHHmmss");
        }

        private void ThietKeGiaoDienHoaDon(string maKH, int maHD, int tongTien, List<frmTrangchu.SanPham> gioHang)
        {
            // --- THIẾT KẾ GIAO DIỆN ---
            this.Text = "BIÊN LAI THANH TOÁN";
            this.Size = new Size(450, 680);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            Label lblStoreName = new Label();
            lblStoreName.Text = "GO SAGO MILK TEA";
            lblStoreName.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblStoreName.ForeColor = Color.FromArgb(255, 128, 0);
            lblStoreName.Dock = DockStyle.Top;
            lblStoreName.Height = 70;
            lblStoreName.BackColor = Color.Transparent;
            lblStoreName.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblStoreName);

            Panel pnlInfo = new Panel();
            pnlInfo.Location = new Point(25, 80);
            pnlInfo.Size = new Size(400, 90);

            Label lblDetails = new Label();
            lblDetails.Text = $"Mã Hóa Đơn : {maHD}\n" +
                              $"Mã Khách   : {maKH}\n" +
                              $"Thời Gian  : {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}";
            lblDetails.Font = new Font("Consolas", 10, FontStyle.Regular);
            lblDetails.AutoSize = true;
            pnlInfo.Controls.Add(lblDetails);
            pnlInfo.BackColor = Color.Transparent;
            this.Controls.Add(pnlInfo);

            ListView lv = new ListView();
            lv.View = View.Details;
            lv.Location = new Point(25, 180);
            lv.Size = new Size(385, 280);
            lv.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lv.BorderStyle = BorderStyle.None;
            lv.Columns.Add("Sản phẩm", 160);
            lv.Columns.Add("SL", 40, HorizontalAlignment.Center);
            lv.Columns.Add("Đơn giá", 85, HorizontalAlignment.Right);
            lv.Columns.Add("Thành tiền", 100, HorizontalAlignment.Right);

            foreach (var sp in gioHang)
            {
                string tenHienThi = sp.TenMon.Split('|')[0];
                ListViewItem item = new ListViewItem(tenHienThi);
                item.SubItems.Add(sp.SoLuong.ToString());
                item.SubItems.Add(sp.DonGia.ToString("N0"));
                item.SubItems.Add(sp.ThanhTien.ToString("N0"));
                lv.Items.Add(item);
            }
            this.Controls.Add(lv);

            Guna2Separator sep = new Guna2Separator();
            sep.Location = new Point(25, 470);
            sep.Size = new Size(385, 10);
            this.Controls.Add(sep);

            Label lblTong = new Label();
            lblTong.Text = $"TỔNG CỘNG: {tongTien.ToString("N0")} VNĐ";
            lblTong.Font = new Font("Segoe UI", 15, FontStyle.Bold);
            lblTong.ForeColor = Color.Red;
            lblTong.Size = new Size(385, 40);
            lblTong.TextAlign = ContentAlignment.MiddleRight;
            lblTong.Location = new Point(25, 490);
            lblTong.BackColor = Color.Transparent;
            this.Controls.Add(lblTong);

            Guna2Button btnClose = new Guna2Button();
            btnClose.Text = "Xác nhận";
            btnClose.Size = new Size(200, 45);
            btnClose.Location = new Point(125, 580);
            btnClose.BorderRadius = 8;
            btnClose.FillColor = Color.FromArgb(255, 128, 0);
            btnClose.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnClose.Cursor = Cursors.Hand;
            btnClose.BackColor = Color.Transparent;

            // --- NÚT BẤM ĐÃ ĐƯỢC TỐI GIẢN ---
            btnClose.Click += (s, e) => {
                // Form 1 đã lưu Database rồi, ở đây chỉ việc hoàn tất quy trình
                OnXacNhanThanhCong?.Invoke();
                this.Close();
            };

            this.Controls.Add(btnClose);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
        }
    
    }
}
