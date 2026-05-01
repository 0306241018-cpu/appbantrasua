using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace WindowsFormsApp3
{
    public partial class frmDonhang : Form
    {
        private string connStr = @"Data Source=.\SQLEXPRESS; Initial Catalog=QuanLyTraSua_DB; Integrated Security=True; TrustServerCertificate=True;";
        private int currentMaHD;
        private string infoKhachHang = "Khách vãng lai";
        private DataTable dtChiTietIn;

        public frmDonhang(int maHD)
        {
            InitializeComponent();
            currentMaHD = maHD;
            this.Text = $"CHI TIẾT ĐƠN HÀNG #{currentMaHD}";
            this.Size = new Size(500, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImage = Properties.Resources.pngtree_chinese_style_ink_tea_tea_shop_home_picture_image_1031072;
            LoadChiTietMon(currentMaHD);
        }

        private void LoadChiTietMon(int maHD)
        {
            this.Controls.Clear();

            Label lblTieuDe = new Label
            {
                Text = $"DANH SÁCH MÓN - MÃ HĐ: {maHD}",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(255, 128, 0),
                Location = new Point(20, 20),
                AutoSize = true
            };
            this.Controls.Add(lblTieuDe);

            ListView lv = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Location = new Point(20, 70),
                Size = new Size(440, 350),
                Font = new Font("Segoe UI", 10),
                BackColor = Color.LightYellow
            };
            lv.Columns.Add("Tên món", 150);
            lv.Columns.Add("SL", 40, HorizontalAlignment.Center);
            lv.Columns.Add("Size", 60, HorizontalAlignment.Center);
            lv.Columns.Add("Đá", 60, HorizontalAlignment.Center);
            lv.Columns.Add("Đường", 70, HorizontalAlignment.Center);
            lv.Columns.Add("Đơn giá", 80, HorizontalAlignment.Right);
            lv.Columns.Add("Thành tiền", 100, HorizontalAlignment.Right);
            this.Controls.Add(lv);

            Guna2Button btnXong = new Guna2Button
            {
                Text = "Xong & In Hóa Đơn",
                Size = new Size(220, 50),
                Location = new Point(130, 450),
                BorderRadius = 10,
                FillColor = Color.FromArgb(255, 128, 0),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnXong.Click += (s, e) => HoanThanhDon(maHD);
            this.Controls.Add(btnXong);
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string sql = @"
                SELECT 
                    ISNULL(sp.TenSP, tp.TenTopping) AS TenSP, 
                    ct.SoLuong, 
                    ISNULL(ct.Size, '-') AS Size,
                    ISNULL(ct.Da, '-') AS Da,
                    ISNULL(ct.Duong, '-') AS Duong,
                    ct.DonGia, 
                    ct.ThanhTienSP 
                FROM ChiTietHoaDon ct
                LEFT JOIN SanPham sp ON ct.MaSP = sp.MaSP
                LEFT JOIN Topping tp ON ct.MaTopping = tp.MaTopping
                WHERE ct.MaHD = @maHD";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maHD", maHD);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    dtChiTietIn = new DataTable();
                    da.Fill(dtChiTietIn);

                    lv.Items.Clear();
                    foreach (DataRow row in dtChiTietIn.Rows)
                    {
                        ListViewItem item = new ListViewItem(row["TenSP"].ToString());
                        item.SubItems.Add(row["SoLuong"].ToString());
                        item.SubItems.Add(row["Size"].ToString());
                        item.SubItems.Add(row["Da"].ToString());
                        item.SubItems.Add(row["Duong"].ToString());
                        item.SubItems.Add(Convert.ToDecimal(row["DonGia"]).ToString("N0"));
                        item.SubItems.Add(Convert.ToDecimal(row["ThanhTienSP"]).ToString("N0"));
                        lv.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message);
            }
        }
        private void HoanThanhDon(int maHD)
        {
            try
            {
                // In hóa đơn
                ThucHienInHoaDon();

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string sql = "UPDATE HoaDon SET TrangThai = N'DaXong' WHERE MaHD = @maHD";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@maHD", maHD);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Đơn hàng đã hoàn thành!", "GO SALO");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void ThucHienInHoaDon()
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += FormatTrangIn;

            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pd;
            ppd.ShowDialog();
        }
        private void FormatTrangIn(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font f = new Font("Arial", 12);
            Font fBold = new Font("Arial", 12, FontStyle.Bold);
            float y = 40;
            decimal tamTinh = 0; // Đổi tên biến 'tong' thành 'tamTinh' cho rõ nghĩa


            // 3. Vẽ chữ "GO SAGO MILK TEA" nằm bên phải hoặc bên dưới logo
            // Mình căn tọa độ Y dịch xuống một chút (y + 25) để chữ nằm giữa chiều cao của logo

            // 4. Tăng y lên một khoảng đủ lớn để dòng chữ/hình ảnh tiếp theo không bị đè lên logo
            y += 90;
            Image hinhNen = Properties.Resources.pngtree_chinese_style_ink_tea_tea_shop_home_picture_image_1031072;
            // Phóng to ảnh bằng toàn bộ chiều rộng và chiều cao của giấy in
            e.Graphics.DrawImage(hinhNen, 0, 0, e.PageBounds.Width, e.PageBounds.Height);

            // --- 2. LÀM MỜ HÌNH NỀN ĐỂ CHỮ KHÔNG BỊ CHÌM ---
            // Tạo một lớp màu trắng bán trong suốt đè lên (số 220 là độ đục, từ 0-255)
            SolidBrush whiteWash = new SolidBrush(Color.FromArgb(220, 255, 255, 255));
            e.Graphics.FillRectangle(whiteWash, e.PageBounds);

            // --- 3. BẮT ĐẦU VẼ CHỮ ĐÈ LÊN TRÊN HÌNH NỀN ---
            //int y = 20;

            // Lúc này chỉ cần in chữ thôi, không in ảnh nhỏ xíu nữa
            // Bạn có thể chỉnh lại tọa độ X (ví dụ 80) để chữ nằm ra giữa hóa đơn
            e.Graphics.DrawString("GO SAGO MILK TEA", new Font("Arial", 18, FontStyle.Bold), Brushes.Orange, 150, y);
            y += 40; // Tăng Y để xuống dòng

            e.Graphics.DrawString("Hóa đơn #201", new Font("Arial", 12), Brushes.Black, 40, y);
            y += 25;

            e.Graphics.DrawString("Khách: Khách vãng lai", new Font("Arial", 12), Brushes.Black, 40, y);
            y += 30;
            // Tiêu đề cột in
            g.DrawString("Sản phẩm", fBold, Brushes.Black, 40, y);
            g.DrawString("SL", fBold, Brushes.Black, 300, y);
            g.DrawString("Thành tiền", fBold, Brushes.Black, 400, y);
            y += 25;
            g.DrawString("---------------------------------------------------------------------------------", f, Brushes.Black, 40, y); y += 20;

            foreach (DataRow row in dtChiTietIn.Rows)
            {
                string ten = row["TenSP"].ToString();
                string opt = $"({row["Size"]}, {row["Da"]} đá, {row["Duong"]} đường)";
                int sl = Convert.ToInt32(row["SoLuong"]);
                decimal tt = Convert.ToDecimal(row["ThanhTienSP"]);
                tamTinh += tt; // Cộng dồn vào tạm tính

                // In tên món
                g.DrawString(ten, f, Brushes.Black, 40, y);
                g.DrawString(sl.ToString(), f, Brushes.Black, 300, y);
                g.DrawString(tt.ToString("N0") + "đ", f, Brushes.Black, 400, y);
                y += 20;

                // In tùy chọn (Size, đá, đường) ngay bên dưới tên món
                g.DrawString(opt, new Font("Arial", 10, FontStyle.Italic), Brushes.Gray, 50, y);
                y += 30; // Khoảng cách giữa các món
            }

            y += 10;
            g.DrawString("------------------------------------------------------------------------------", f, Brushes.Black, 40, y); y += 25;

            // --- BẮT ĐẦU PHẦN TÍNH THUẾ VÀ TỔNG TIỀN ---

            // 1. Tạm tính
            g.DrawString("Tạm tính:", fBold, Brushes.Black, 40, y);
            g.DrawString(tamTinh.ToString("N0") + " VNĐ", f, Brushes.Black, 380, y);
            y += 25;

            // 2. Tính Thuế VAT (Giả sử 10% - Bạn có thể sửa 0.1m thành 0.08m nếu là 8%)
            decimal thueVAT = tamTinh * 0.05m;
            g.DrawString("Thuế VAT (5%):", fBold, Brushes.Black, 40, y);
            g.DrawString(thueVAT.ToString("N0") + " VNĐ", f, Brushes.Black, 380, y);
            y += 25;

            // 3. Tổng cộng (Tạm tính + Thuế)
            decimal tongCong = tamTinh + thueVAT;
            g.DrawString("TỔNG THANH TOÁN:", fBold, Brushes.Black, 40, y);
            g.DrawString(tongCong.ToString("N0") + " VNĐ", fBold, Brushes.Black, 380, y);

            // --- KẾT THÚC PHẦN TÍNH THUẾ ---

            y += 40;
            g.DrawString(" GO SALO xin cảm ơn quý khách!", f, Brushes.Black, 150, y);
        }


        private void frmDonhang_Load(object sender, EventArgs e)
        {

        }
    }
}
