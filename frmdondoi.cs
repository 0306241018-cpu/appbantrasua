using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class frmdondoi : Form
    {
        private string connStr = @"Data Source=ADMINISTRATOR\SQLEXPRESS; Initial Catalog=QuanLyTraSua_DB; Integrated Security=True; TrustServerCertificate=True;";
        private Timer timerAutoRefresh; // Khai báo biến toàn cục để điều khiển

        public frmdondoi()
        {
            InitializeComponent();
            this.Text = "BẢNG ĐIỀU KHIỂN BẾP - GO SAGO";

            // Kích hoạt DoubleBuffered cho flowLayoutPanel1 để chống giật khi xóa/nạp lại
            var property = typeof(FlowLayoutPanel).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            property.SetValue(flowLayoutPanel1, true, null);

            // Khởi tạo Timer
            timerAutoRefresh = new Timer();
            timerAutoRefresh.Interval = 3000;
            timerAutoRefresh.Tick += (s, e) => LoadDonHangDoi();
        }

        private void frmdondoi_Load(object sender, EventArgs e)
        {
            LoadDonHangDoi();
            timerAutoRefresh.Start();
            guna2HtmlLabel1.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy");
            guna2HtmlLabel1.Font = new Font("Times New Roman", 13.8f);
        }

        public void LoadDonHangDoi()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // Lấy các đơn hàng đang chờ pha chế
                    string sql = "SELECT MaHD, TongTien, NgayLap FROM HoaDon WHERE TrangThai = N'DaThanhToan' ORDER BY NgayLap ASC";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Tạm ngưng vẽ Layout để tăng tốc độ nạp
                    flowLayoutPanel1.SuspendLayout();
                    flowLayoutPanel1.Controls.Clear();

                    if (dt.Rows.Count == 0)
                    {
                        Label lblEmpty = new Label
                        {
                            Text = "Hiện tại chưa có đơn hàng nào cần pha chế...",
                            ForeColor = Color.Gray,
                            AutoSize = true,
                            Font = new Font("Segoe UI", 10, FontStyle.Italic),
                            Margin = new Padding(20)
                        };
                        flowLayoutPanel1.Controls.Add(lblEmpty);
                    }
                    else
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            int maHD = Convert.ToInt32(row["MaHD"]);
                            long tongTien = Convert.ToInt64(row["TongTien"]);
                            DateTime ngayLap = Convert.ToDateTime(row["NgayLap"]);

                            // Tạo nút hiển thị đơn hàng
                            Guna2Button btnDon = new Guna2Button();
                            btnDon.Text = $"ĐƠN #{maHD}\n{ngayLap.ToString("HH:mm")}\n\n{tongTien.ToString("N0")}đ";
                            btnDon.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                            btnDon.ForeColor = Color.SaddleBrown; // Màu nâu trà sữa
                            btnDon.Size = new Size(160, 130);
                            btnDon.FillColor = Color.FromArgb(255, 228, 181); // Màu cam nhạt
                            btnDon.BorderRadius = 15;
                            btnDon.BorderThickness = 1;
                            btnDon.BorderColor = Color.FromArgb(255, 128, 0); // Viền cam đậm
                            btnDon.ShadowDecoration.Enabled = true;
                            btnDon.Cursor = Cursors.Hand;
                            btnDon.Margin = new Padding(12);

                            // Xử lý sự kiện Click
                            btnDon.Click += (s, e) =>
                            {
                                timerAutoRefresh.Stop(); // Dừng quét đơn khi đang xem chi tiết

                                using (frmDonhang frmChiTiet = new frmDonhang(maHD))
                                {
                                    frmChiTiet.ShowDialog();
                                }

                                LoadDonHangDoi(); // Cập nhật lại danh sách ngay sau khi xử lý xong
                                timerAutoRefresh.Start(); // Chạy lại Timer
                            };

                            flowLayoutPanel1.Controls.Add(btnDon);
                        }
                    }
                    flowLayoutPanel1.ResumeLayout();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi LoadDonHangDoi: " + ex.Message);
            }
        }

        // Đảm bảo dừng Timer khi đóng Form để tránh lỗi bộ nhớ
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (timerAutoRefresh != null)
            {
                timerAutoRefresh.Stop();
                timerAutoRefresh.Dispose();
            }
            base.OnFormClosing(e);
        }

        // Các hàm rỗng có thể xóa nếu không sử dụng để code sạch hơn
        private void pnlDesktop_Paint(object sender, PaintEventArgs e) { }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {


        }
    }
}