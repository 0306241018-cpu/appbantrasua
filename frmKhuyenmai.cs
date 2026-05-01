using System;
using System.Data;
using System.Data.SqlClient; // Bắt buộc phải có để kết nối SQL
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    // ==========================================
    // PHẦN 1: CLASS CỦA FORM CHÍNH (FORM KHUYẾN MÃI)
    // ==========================================

    public partial class frmKhuyenmai : Form
    {
        // Chuỗi kết nối của bạn
        string connectionString = @"Data Source=ADMINISTRATOR\SQLEXPRESS;Initial Catalog=QuanLyTraSua_DB; Integrated Security=True; TrustServerCertificate=True;";

        public frmKhuyenmai()
        {
            InitializeComponent();
            LoadDanhSachKhuyenMai(); // Load dữ liệu khi mở Form
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            guna2TextBox1.BorderRadius = 25;
            guna2TextBox1.PlaceholderText = "Tìm kiếm khuyến mãi...";
            guna2HtmlLabel1.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy");
            guna2Button1.HoverState.FillColor = Color.FromArgb(255, 228, 181);
            guna2Button2.HoverState.FillColor = Color.FromArgb(255, 228, 181);
            guna2Button3.HoverState.FillColor = Color.FromArgb(255, 228, 181);
            flowLayoutPanel1.BackColor = Color.White;
        }

        // HÀM CHÍNH: LẤY DỮ LIỆU VOUCHER TỪ SQL VÀ ĐỔ VÀO PANEL
        private void LoadDanhSachKhuyenMai()
        {
            // 1. Xóa rỗng các control cũ trước khi thêm
            flowLayoutPanel1.Controls.Clear();

            // 2. Query lấy các Voucher đang hoạt động và chưa hết hạn
            string query = @"
                SELECT TenVoucher, LoaiGiamGia, GiaTri, DonHangToiThieu, HinhAnh
                FROM Voucher 
                WHERE TrangThai = 1 AND NgayKetThuc >= CAST(GETDATE() AS DATE)";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // 3. Duyệt qua từng dòng dữ liệu để tạo Thẻ (Card)
                    foreach (DataRow row in dt.Rows)
                    {
                        string ten = row["TenVoucher"].ToString();
                        string loai = row["LoaiGiamGia"].ToString();
                        decimal giaTri = Convert.ToDecimal(row["GiaTri"]);
                        decimal donToiThieu = Convert.ToDecimal(row["DonHangToiThieu"]);

                        // Lấy tên hình từ Database
                        string hinhName = row["HinhAnh"]?.ToString() ?? "";

                        // Xử lý hiển thị % hoặc số tiền đ
                        string giamGiaText = loai == "PhanTram" ? $"{giaTri}%" : $"{giaTri:N0} đ";

                        // Ghép chuỗi để hiển thị trên thẻ
                        string moTa = $"{ten}\r\nGiảm: {giamGiaText}\r\nĐơn tối thiểu: {donToiThieu:N0} đ";

                        // 4. Xử lý load hình ảnh từ thư mục
                        Image hinh = null;
                        if (!string.IsNullOrEmpty(hinhName))
                        {
                            string path = Path.Combine(@"C:\Images_TraSua", hinhName);
                            if (File.Exists(path))
                            {
                                try
                                {
                                    // Load qua Bitmap tạm để không bị lock file ảnh gốc
                                    using (var bmpTemp = new Bitmap(path))
                                    {
                                        hinh = new Bitmap(bmpTemp);
                                    }
                                }
                                catch { }
                            }
                        }

                        // 5. Tạo thẻ mới (Truyền hình ảnh và mô tả vào CardKhuyenMai)
                        CardKhuyenMai card = new CardKhuyenMai(moTa, hinh);

                        // Thêm thẻ vào khay
                        flowLayoutPanel1.Controls.Add(card);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // HÀM PHỤ: Hỗ trợ tìm kiếm tiếng Việt không dấu
        private string LocDauTiengViet(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        // SỰ KIỆN TÌM KIẾM (Đã gộp lại thành 1 sự kiện duy nhất, tối ưu, không giật lag)
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = LocDauTiengViet(guna2TextBox1.Text.Trim().ToLower());

            flowLayoutPanel1.SuspendLayout(); // Chống giật màn hình khi lọc

            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is CardKhuyenMai)
                {
                    CardKhuyenMai card = (CardKhuyenMai)ctrl;
                    string moTaThe = LocDauTiengViet(card.MoTa.ToLower());

                    if (string.IsNullOrEmpty(tuKhoa) || moTaThe.Contains(tuKhoa))
                    {
                        card.Visible = true;
                    }
                    else
                    {
                        card.Visible = false;
                    }
                }
            }

            flowLayoutPanel1.ResumeLayout();
        }

        // CHUYỂN TRANG
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmTrangchu f1 = new frmTrangchu();
            f1.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            frmCuahang f1 = new frmCuahang();
            f1.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            // Chức năng khác
        }
    }

    // ==========================================
    // PHẦN 2: CLASS CỦA THẺ KHUYẾN MÃI (USER CONTROL)
    // ==========================================
    public class CardKhuyenMai : UserControl
    {
        private PictureBox picImage;
        private Label lblDescription;

        // Lấy mô tả ra ngoài để Form chính tìm kiếm
        public string MoTa
        {
            get { return lblDescription.Text; }
        }

        public CardKhuyenMai(string description, Image hinh)
        {
            this.Width = 150;
            this.Height = 200;
            this.BackColor = Color.White;
            this.Margin = new Padding(15);
            this.BorderStyle = BorderStyle.FixedSingle;

            // Hình ảnh (Nếu hinh == null, nó sẽ chỉ hiện 1 khoảng trống màu trắng)
            picImage = new PictureBox();
            picImage.Dock = DockStyle.Top;
            picImage.Height = 100; // Đã thu nhỏ chiều cao hình lại để nhường chỗ cho chữ
            picImage.BackColor = Color.WhiteSmoke; // Đổi màu xám nhẹ để phân biệt vùng ảnh
            picImage.SizeMode = PictureBoxSizeMode.Zoom;
            if (hinh != null) picImage.Image = hinh;

            // Chữ mô tả (Chứa Tên Voucher, mức giảm, đơn tối thiểu)
            lblDescription = new Label();
            lblDescription.Dock = DockStyle.Fill;
            lblDescription.Text = description;
            lblDescription.TextAlign = ContentAlignment.MiddleCenter;
            lblDescription.Font = new Font("Segoe UI", 9F, FontStyle.Bold); // Chữ đậm dễ nhìn hơn
            lblDescription.Padding = new Padding(5);

            this.Controls.Add(lblDescription);
            this.Controls.Add(picImage);
        }
    }
}