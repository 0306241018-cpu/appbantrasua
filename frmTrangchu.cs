using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class frmTrangchu : Form
    {
        

        // --- BIẾN TOÀN CỤC ---
        long _tongCongCuoiCung = 0;
        string connectionString = @"Data Source=ADMINISTRATOR\SQLEXPRESS; Initial Catalog=QuanLyTraSua_DB; Integrated Security=True; TrustServerCertificate=True;";

        List<SanPham> gioHang = new List<SanPham>();
        Dictionary<string, Image> hinhCache = new Dictionary<string, Image>();
        private Form activeForm;
        //class SmoothFlowLayoutPanel1 : FlowLayoutPanel
        //{
        //    public SmoothFlowLayoutPanel1()
        //    {
        //        this.DoubleBuffered = true;
        //        this.ResizeRedraw = true;
        //    }

            // ÉP WS_EX_COMPOSITED CHỈ CHO RIÊNG PANEL NÀY
            //protected override CreateParams CreateParams
            //{
            //    get
            //    {
            //        CreateParams cp = base.CreateParams;
            //        cp.ExStyle |= 0x02000000; // Bật chống giật, xé hình
            //        return cp;
            ////    }
            //}
        
        public class SanPham
        {
            public string TenMon { get; set; }
            public int SoLuong { get; set; }
            public double DonGia { get; set; }
            public double ThanhTien => SoLuong * DonGia;
        }

        class SmoothFlowLayoutPanel : FlowLayoutPanel
        {
            public SmoothFlowLayoutPanel()
            {
                this.DoubleBuffered = true;
                this.ResizeRedraw = true;
            }
        }

        public frmTrangchu()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.DoubleBuffered = true;

            // Bật DoubleBuffered cho panel chính
            SetDoubleBuffered(flowLayoutPanel1);

            // Tối ưu bắt sự kiện cuộn chuột
            flowLayoutPanel1.MouseWheel += (s, e) => {
                flowLayoutPanel1.Focus();
            };
        }

    
        private void SetupInterface()
        {
            guna2Button1.HoverState.FillColor = Color.FromArgb(255, 228, 181);
            guna2Button2.HoverState.FillColor = Color.FromArgb(255, 228, 181);
            guna2Button3.HoverState.FillColor = Color.FromArgb(255, 228, 181);
            guna2Button11.FillColor = Color.FromArgb(244, 164, 96);
            guna2Button11.HoverState.FillColor = Color.FromArgb(255, 228, 181);

            Guna2Button[] categoryButtons = { guna2Button5, guna2Button6, guna2Button7, guna2Button8, guna2Button9, guna2Button4, guna2Button12 };
            foreach (var btn in categoryButtons)
            {
                if (btn != null)
                {
                    btn.FillColor = Color.FromArgb(255, 239, 213);
                    btn.HoverState.FillColor = Color.FromArgb(250, 250, 210);
                }
            }

            if (guna2TextBox1 != null)
            {
                guna2TextBox1.BorderRadius = 25;
                guna2TextBox1.PlaceholderText = "Tìm kiếm trà sữa ưa thích";
                guna2TextBox1.FillColor = Color.WhiteSmoke;
                guna2TextBox1.ForeColor = Color.Black;
            }

            if (guna2HtmlLabel2 != null)
            {
                guna2HtmlLabel2.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy");
                guna2HtmlLabel2.Font = new Font("Times New Roman", 13.8f);
            }
        }

        private void SetDoubleBuffered(Control c)
        {
            var prop = typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (prop != null) prop.SetValue(c, true, null);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetupInterface();
            SetupListView();
            SetupFlowPanel();

       

            // CHỈ ĐĂNG KÝ SỰ KIỆN 1 LẦN DUY NHẤT Ở ĐÂY
            if (guna2Button5 != null) guna2Button5.Click += (s, ev) => LoadDanhSachMonBanDau("", "");
            if (guna2Button6 != null) guna2Button6.Click += (s, ev) => LoadDanhSachMonBanDau("", "TraSua");
            if (guna2Button7 != null) guna2Button7.Click += (s, ev) => LoadDanhSachMonBanDau("", "CaPhe");
            if (guna2Button4 != null) guna2Button4.Click += (s, ev) => LoadDanhSachMonBanDau("", "NuocEp");
            if (guna2Button12 != null) guna2Button12.Click += (s, ev) => LoadDanhSachMonBanDau("", "Topping");
            if (guna2Button9 != null) guna2Button9.Click += (s, ev) => LoadDanhSachMonBanDau("", "Khac");
            if (guna2Button8 != null) guna2Button8.Click += (s, ev) => LoadDanhSachMonBanDau("", "SinhTo");

            if (guna2TextBox1 != null) guna2TextBox1.TextChanged += guna2TextBox1_TextChanged;
            if (guna2Button11 != null) guna2Button11.Click += guna2Button11_Click_1;

            // Load dữ liệu lần đầu
            LoadDanhSachMonBanDau("", "");
        }

        private void SetupListView()
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Clear();
            listView1.Columns.Add("Tên món", 120); listView1.Columns.Add("Size", 40);
            listView1.Columns.Add("Đường", 50); listView1.Columns.Add("Đá", 50);
            listView1.Columns.Add("SL", 40); listView1.Columns.Add("Giá", 70);
            listView1.Columns.Add("Tổng", 80); listView1.Columns.Add("-", 30);
            listView1.Columns.Add("+", 30); listView1.Columns.Add("X", 30);
            listView1.BackColor = Color.LightYellow;
            listView1.MouseClick += (s, e) => {
                var info = listView1.HitTest(e.X, e.Y);
                if (info.Item != null)
                {
                    int col = info.Item.SubItems.IndexOf(info.SubItem);
                    int idx = info.Item.Index;
                    if (col == 7) { if (gioHang[idx].SoLuong > 1) gioHang[idx].SoLuong--; else gioHang.RemoveAt(idx); }
                    else if (col == 8) gioHang[idx].SoLuong++;
                    else if (col == 9) gioHang.RemoveAt(idx);
                    CapNhatGioHangVaInHoaDon();
                }
            };
        }

        public DataTable GetDataTableLocal(string sql, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd)) { da.Fill(dt); }
                }
            }
            return dt;
        }

        private Image LayAnhTuFolder(string hinhName)
        {
            if (string.IsNullOrEmpty(hinhName)) return null;

            if (hinhCache.ContainsKey(hinhName))
                return hinhCache[hinhName];

            string path = Path.Combine(@"C:\Images_TraSua", hinhName);

            if (File.Exists(path))
            {
                Image img;
                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    img = Image.FromStream(stream);
                }

                img = (Image)img.Clone(); // 🔥 tránh lock file
                hinhCache[hinhName] = img;
                return img;
            }

            return null;
        }

        // HÀM LỌC BỎ DẤU TIẾNG VIỆT ĐỂ TÌM KIẾM THÔNG MINH HƠN
        public static string LocDauTiengViet(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return str;
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = str.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        private async void LoadDanhSachMonBanDau(string tuKhoaTen = "", string tuKhoaLoai = "")
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtTop = null, dtSP = null, dtTopAll = null;

                // 1. Lấy dữ liệu
                await Task.Run(() => {
                    if (tuKhoaLoai == "Topping")
                    {
                        string sql = "SELECT TenTopping, Gia, HinhAnh, MoTa FROM Topping WHERE TrangThai = 1";
                        dtTop = GetDataTableLocal(sql);
                    }
                    else
                    {
                        string sql = "SELECT TenSP, GiaBan, HinhAnh, MoTa FROM SanPham WHERE TrangThai = 1";
                        List<SqlParameter> paras = new List<SqlParameter>();
                        if (!string.IsNullOrEmpty(tuKhoaLoai))
                        {
                            sql += " AND Loai LIKE @loai";
                            paras.Add(new SqlParameter("@loai", "%" + tuKhoaLoai + "%"));
                        }
                        dtSP = GetDataTableLocal(sql, paras.ToArray());

                        if (string.IsNullOrEmpty(tuKhoaLoai))
                            dtTopAll = GetDataTableLocal("SELECT TenTopping, Gia, HinhAnh, MoTa FROM Topping WHERE TrangThai = 1");
                    }
                });

                // 2. Lọc dữ liệu
                if (!string.IsNullOrEmpty(tuKhoaTen))
                {
                    string keyword = LocDauTiengViet(tuKhoaTen.ToLower());
                    if (dtTop != null) dtTop = LocDuLieu(dtTop, "TenTopping", keyword);
                    if (dtSP != null) dtSP = LocDuLieu(dtSP, "TenSP", keyword);
                    if (dtTopAll != null) dtTopAll = LocDuLieu(dtTopAll, "TenTopping", keyword);
                }

                // 3. Vẽ giao diện (Đã tối ưu bằng AddRange)
                flowLayoutPanel1.SuspendLayout();
                flowLayoutPanel1.Controls.Clear();

                List<Control> dsControls = new List<Control>();

                if (dtTop != null) foreach (DataRow row in dtTop.Rows)
                        dsControls.Add(TaoMon(row["TenTopping"].ToString(), row["Gia"].ToString(), LayAnhTuFolder(row["HinhAnh"].ToString()), row["MoTa"].ToString(), true));

                if (dtSP != null) foreach (DataRow row in dtSP.Rows)
                        dsControls.Add(TaoMon(row["TenSP"].ToString(), row["GiaBan"].ToString(), LayAnhTuFolder(row["HinhAnh"].ToString()), row["MoTa"].ToString(), false));

                if (dtTopAll != null) foreach (DataRow row in dtTopAll.Rows)
                        dsControls.Add(TaoMon(row["TenTopping"].ToString(), row["Gia"].ToString(), LayAnhTuFolder(row["HinhAnh"].ToString()), row["MoTa"].ToString(), true));

                flowLayoutPanel1.Controls.AddRange(dsControls.ToArray()); // Thêm một lần để tránh giật lag

                flowLayoutPanel1.ResumeLayout(true);

                // 4. Ép cuộn lên đầu bằng 3 cách cùng lúc trong BeginInvoke
                this.BeginInvoke((MethodInvoker)delegate {
                    flowLayoutPanel1.VerticalScroll.Value = 0;
                    flowLayoutPanel1.AutoScrollPosition = new Point(0, 0);

                    if (flowLayoutPanel1.Controls.Count > 0)
                    {
                        flowLayoutPanel1.ScrollControlIntoView(flowLayoutPanel1.Controls[0]);
                    }
                    flowLayoutPanel1.AutoSize = false;
                    flowLayoutPanel1.WrapContents = true;
                    flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
                });
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải danh sách: " + ex.Message); }
            finally { this.Cursor = Cursors.Default; }
        }

        private DataTable LocDuLieu(DataTable dt, string columnName, string keyword)
        {
            var filteredRows = dt.AsEnumerable().Where(r =>
                LocDauTiengViet(r.Field<string>(columnName).ToLower()).Contains(keyword)
            );
            return filteredRows.Any() ? filteredRows.CopyToDataTable() : dt.Clone();
        }

        // Đã đổi GroupBox thành Panel và bật DoubleBuffered
        private Panel TaoMon(string ten, string gia, Image hinh, string mota, bool isTopping)
        {
            Panel card = new Panel { Width = 155, Height = 250, BackColor = Color.White, Margin = new Padding(10), Cursor = Cursors.Hand };
            SetDoubleBuffered(card); // Chống giật cho Panel
            card.BorderStyle = BorderStyle.FixedSingle;
            PictureBox pic = new PictureBox { Dock = DockStyle.Top, Height = 100, SizeMode = PictureBoxSizeMode.Zoom, Image = hinh };
            Label lblTen = new Label { Text = ten, Size = new Size(135, 20), Location = new Point(10, 130), Font = new Font("Segoe UI", 9, FontStyle.Bold) };
            Label lblGia = new Label { Text = decimal.Parse(gia).ToString("N0") + "đ", Location = new Point(10, 150), ForeColor = Color.Red };
            Label lblXem = new Label { Text = "Xem chi tiết", Location = new Point(10, 170), ForeColor = Color.Blue, Font = new Font("Segoe UI", 7, FontStyle.Underline), Cursor = Cursors.Hand };
            Guna2Button btnAdd = new Guna2Button { Text = "+", Size = new Size(35, 35), Location = new Point(110, 175), BorderRadius = 8, FillColor = Color.Orange };

            btnAdd.Click += (s, e) =>
            {
                int giaInt = int.TryParse(gia, out int p) ? p : 0;
                if (isTopping)
                {
                    string maTopping = $"{ten}|-|-|-";
                    ThemSanPham(maTopping, giaInt, 1);
                }
                else
                {
                    frmChonchitiet f3 = new frmChonchitiet(ten, giaInt, hinh, mota, gioHang);
                    f3.ShowDialog();
                }
                CapNhatGioHangVaInHoaDon();
            };

            EventHandler moFormEvent = (s, e) => {
                int giaInt = (int)decimal.Parse(gia);
                using (frmChitiet f2 = new frmChitiet(ten, giaInt, hinh, mota, gioHang))
                {
                    if (f2.ShowDialog() == DialogResult.OK) CapNhatGioHangVaInHoaDon();
                }
            };

            card.Click += moFormEvent; pic.Click += moFormEvent; lblTen.Click += moFormEvent; lblXem.Click += moFormEvent;

            card.Controls.Add(pic); card.Controls.Add(lblTen); card.Controls.Add(lblGia); card.Controls.Add(lblXem); card.Controls.Add(btnAdd);
            return card;
        }

        public void ThemSanPham(string maMon, int giaMon, int sl)
        {
            var sp = gioHang.FirstOrDefault(p => p.TenMon == maMon);
            if (sp != null) sp.SoLuong += sl;
            else gioHang.Add(new SanPham { TenMon = maMon, DonGia = giaMon, SoLuong = sl });
            CapNhatGioHangVaInHoaDon();
        }

        public void CapNhatGioHangVaInHoaDon()
        {
            listView1.Items.Clear();
            long tong = 0;
            foreach (var sp in gioHang)
            {
                string[] p = sp.TenMon.Split('|');
                ListViewItem item = new ListViewItem(p[0]);
                item.SubItems.AddRange(new[] { p.Length > 1 ? p[1] : "S", p.Length > 2 ? p[2] : "100%", p.Length > 3 ? p[3] : "Có đá", sp.SoLuong.ToString(), sp.DonGia.ToString("N0"), sp.ThanhTien.ToString("N0"), "-", "+", "X" });
                listView1.Items.Add(item);
                tong += (long)sp.ThanhTien;
            }
            _tongCongCuoiCung = (long)(tong * 1.05); // Cộng thêm 5% thuế/phí
            textBox1.Text = tong.ToString("N0") + " VND";
            textBox2.Text = (tong * 0.05).ToString("N0") + " VND";
            textBox3.Text = _tongCongCuoiCung.ToString("N0") + " VND";
        }

        private void guna2Button11_Click_1(object sender, EventArgs e)
        {
            if (gioHang.Count == 0) return;

            int maHDMoi = LuuHoaDonVaoDatabase(_tongCongCuoiCung, gioHang);
            if (maHDMoi > 0)
            {
                frmHoadon fr4 = new frmHoadon("KH_VL", maHDMoi, (int)_tongCongCuoiCung, new List<SanPham>(gioHang));

                fr4.OnXacNhanThanhCong = () =>
                {
                    gioHang.Clear();
                    CapNhatGioHangVaInHoaDon();
                    MessageBox.Show("Đặt hàng thành công !", "GO SAGO");
                    MessageBox.Show("GO SAGO xin cảm ơn", "GO SAGO");
                };

                fr4.ShowDialog();
            }
        }

        private void SetupFlowPanel()
        {
            // 1. Ép kích thước theo khung cha để hiện thanh cuộn
            flowLayoutPanel1.Dock = DockStyle.Fill;

            // 2. Đảm bảo các thông số chuẩn
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.AutoSize = false;

            // 3. Đưa lên lớp trên cùng để không bị Panel khác đè mất thanh cuộn
            flowLayoutPanel1.BringToFront();
        }

        private int LuuHoaDonVaoDatabase(long tongTien, List<SanPham> dsHang)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string sqlHD = @"INSERT INTO HoaDon (MaNV, NgayLap, TenKH, TongTien, ThanhTien, TrangThai) 
                                VALUES (1, GETDATE(), N'Khách vãng lai', @tong, @tong, N'DaThanhToan');
                                SELECT CAST(SCOPE_IDENTITY() as int);";
                        SqlCommand cmdHD = new SqlCommand(sqlHD, conn, trans);
                        cmdHD.Parameters.AddWithValue("@tong", tongTien);
                        int maHD = (int)cmdHD.ExecuteScalar();

                        foreach (var sp in dsHang)
                        {
                            string[] p = sp.TenMon.Split('|');
                            string tenSPThucTe = p[0].Trim();
                            string size = p.Length > 1 ? p[1].Trim() : "";
                            string duong = p.Length > 2 ? p[2].Trim() : "";
                            string da = p.Length > 3 ? p[3].Trim() : "";

                            string sqlCT = @"
                            DECLARE @MaSP_Tim INT, @MaTP_Tim INT;

                            -- Kiểm tra xem món này có nằm trong bảng Topping không
                            SELECT TOP 1 @MaTP_Tim = MaTopping FROM Topping WHERE TenTopping = @tenCat;

                            IF @MaTP_Tim IS NOT NULL
                            BEGIN
                                -- NẾU LÀ TOPPING: Lưu vào cột MaTopping (MaSP để trống)
                                INSERT INTO ChiTietHoaDon (MaHD, MaTopping, SoLuong, DonGia, ThanhTienSP, Size, Da, Duong) 
                                VALUES (@mahd, @MaTP_Tim, @sl, @gia, @thanhtien, @size, @da, @duong);
                            END
                            ELSE
                            BEGIN
                                -- NẾU LÀ TRÀ SỮA: Lưu vào cột MaSP
                                SELECT TOP 1 @MaSP_Tim = MaSP FROM SanPham WHERE TenSP = @tenCat;
                                IF @MaSP_Tim IS NOT NULL
                                BEGIN
                                    INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong, DonGia, ThanhTienSP, Size, Da, Duong) 
                                    VALUES (@mahd, @MaSP_Tim, @sl, @gia, @thanhtien, @size, @da, @duong);
                                END
                            END";
                            SqlCommand cmdCT = new SqlCommand(sqlCT, conn, trans);
                            cmdCT.Parameters.AddWithValue("@mahd", maHD);
                            cmdCT.Parameters.AddWithValue("@tenCat", tenSPThucTe);
                            cmdCT.Parameters.AddWithValue("@sl", sp.SoLuong);
                            cmdCT.Parameters.AddWithValue("@gia", sp.DonGia);
                            cmdCT.Parameters.AddWithValue("@thanhtien", sp.ThanhTien);

                            cmdCT.Parameters.AddWithValue("@size", string.IsNullOrEmpty(size) || size == "-" ? (object)DBNull.Value : size);
                            cmdCT.Parameters.AddWithValue("@da", string.IsNullOrEmpty(da) || da == "-" ? (object)DBNull.Value : da);
                            cmdCT.Parameters.AddWithValue("@duong", string.IsNullOrEmpty(duong) || duong == "-" ? (object)DBNull.Value : duong);

                            cmdCT.ExecuteNonQuery();
                        }
                        trans.Commit();
                        return maHD;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show("Lỗi hệ thống: " + ex.Message);
                        return -1;
                    }
                }
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e) => LoadDanhSachMonBanDau(guna2TextBox1.Text.Trim(), "");

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            frmCuahang f5 = new frmCuahang();
            f5.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            frmKhuyenmai f6 = new frmKhuyenmai();
            f6.Show();
            this.Hide();
        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
//em da co gang het suc
