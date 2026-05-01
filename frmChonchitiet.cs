using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class frmChonchitiet : Form
    {
        // KHAI BÁO BIẾN TOÀN CỤC
        string _ten;
        int _gia;
        Image _hinh;
        string _mota;
        List<frmTrangchu.SanPham> _gioHang;

        public frmChonchitiet(string ten, int gia, Image hinh, string mota, List<frmTrangchu.SanPham> gioHang)
        {
            InitializeComponent();
            _ten = ten;
            _gia = gia;
            _hinh = hinh;
            _mota = mota;
            _gioHang = gioHang;
          
            this.Load += Form3_Load;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (flowLayoutPanel2 == null) return;
            flowLayoutPanel2.Controls.Add(CreateCard());
        }

        private Control CreateCard()
        {
            Panel card = new Panel { Size = new Size(700, 600), BackColor = Color.White, BorderStyle = BorderStyle.FixedSingle };
            Font fontBold12 = new Font("Segoe UI", 12, FontStyle.Bold);

            // Tạo biến lưu giá hiện tại (bắt đầu bằng giá gốc của Size S)
            int giaHienTai = _gia;

            PictureBox pic = new PictureBox { Size = new Size(140, 140), Location = new Point(20, 20), SizeMode = PictureBoxSizeMode.StretchImage, Image = _hinh };
            Label lblTen = new Label { Text = _ten, Font = new Font("Segoe UI", 14, FontStyle.Bold), Location = new Point(180, 20), AutoSize = true };

            // Label Giá (sẽ tự động thay đổi số tiền)
            Label lblGia = new Label { Text = giaHienTai.ToString("N0") + " đ", Font = fontBold12, ForeColor = Color.Red, Location = new Point(180, 65), AutoSize = true };

            // ===== LỰA CHỌN MÓN =====
            // Khai báo các nút Size rõ ràng để dễ bắt sự kiện
            RadioButton rbSizeS = new RadioButton { Text = "S", Location = new Point(10, 25), Checked = true, AutoSize = true };
            RadioButton rbSizeM = new RadioButton { Text = "M", Location = new Point(70, 25), AutoSize = true };
            RadioButton rbSizeL = new RadioButton { Text = "L", Location = new Point(130, 25), AutoSize = true };

            // Logic tự động đổi giá khi bấm chọn Size
            EventHandler sizeChanged = (sender, e) =>
            {
                if (rbSizeS.Checked) giaHienTai = _gia; // Giá gốc
                else if (rbSizeM.Checked) giaHienTai = _gia + 5000;  // Size M cộng thêm 5k
                else if (rbSizeL.Checked) giaHienTai = _gia + 10000; // Size L cộng thêm 10k

                // Cập nhật lại số tiền hiển thị trên màn hình
                lblGia.Text = giaHienTai.ToString("N0") + " đ";
            };

            // Gắn sự kiện đổi giá vào 3 nút Size
            rbSizeS.CheckedChanged += sizeChanged;
            rbSizeM.CheckedChanged += sizeChanged;
            rbSizeL.CheckedChanged += sizeChanged;

            GroupBox gbSize = new GroupBox() { Text = "Size", Location = new Point(20, 200), Size = new Size(220, 60) };
            gbSize.Controls.AddRange(new Control[] { rbSizeS, rbSizeM, rbSizeL });

            GroupBox gbDuong = new GroupBox() { Text = "Đường", Location = new Point(260, 200), Size = new Size(220, 60) };
            gbDuong.Controls.AddRange(new Control[] {
                new RadioButton { Text = "0%", Location = new Point(10, 25), Checked = true, AutoSize = true },
                new RadioButton { Text = "50%", Location = new Point(70, 25), AutoSize = true },
                new RadioButton { Text = "100%", Location = new Point(130, 25), AutoSize = true }
            });

            GroupBox gbDa = new GroupBox() { Text = "Đá", Location = new Point(500, 200), Size = new Size(180, 60) };
            gbDa.Controls.AddRange(new Control[] {
                new RadioButton { Text = "Không đá", Location = new Point(10, 25), AutoSize = true },
                new RadioButton { Text = "Có đá", Location = new Point(100, 25), Checked = true, AutoSize = true }
            });

            NumericUpDown nudSoLuong = new NumericUpDown { Location = new Point(180, 105), Width = 80, Minimum = 1, Value = 1 };
            Button btnAdd = new Button { Text = "THÊM VÀO GIỎ", Size = new Size(200, 45), BackColor = Color.Orange, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 12, FontStyle.Bold) };
            Button btnclear = new Button { Text = "Xóa", Size = new Size(200, 45), BackColor = Color.Orange, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 12, FontStyle.Bold) };

            int toaDoX = (700 - btnAdd.Width) / 2;
            btnAdd.Location = new Point(toaDoX, 350);

            // Xử lý thêm vào giỏ hàng
            btnAdd.Click += (s, e) =>
            {
                // Lấy size hiện tại
                string size = rbSizeS.Checked ? "S" : (rbSizeM.Checked ? "M" : "L");
                string duong = gbDuong.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked)?.Text ?? "100%";
                string da = gbDa.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked)?.Text ?? "Có đá";
                string maMon = $"{_ten}|{size}|{duong}|{da}";

                // TRUYỀN 'giaHienTai' ĐÃ CỘNG TIỀN VÀO GIỎ HÀNG THAY VÌ GIÁ GỐC '_gia'
                ThemSanPham(maMon, giaHienTai, (int)nudSoLuong.Value);
                //MessageBox.Show("Đã thêm vào giỏ hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            };

            if (flowLayoutPanel2 != null && flowLayoutPanel2.Width > card.Width)
            {
                int leHaiBen = (flowLayoutPanel2.Width - card.Width) / 2;
                card.Margin = new Padding(leHaiBen, 20, leHaiBen, 20);
            }

            card.Controls.AddRange(new Control[] { pic, lblTen, lblGia, gbSize, gbDuong, gbDa, nudSoLuong, btnAdd });
            return card;
        }

        void ThemSanPham(string maMon, int giaMon, int sl)
        {
            var sp = _gioHang.FirstOrDefault(p => p.TenMon == maMon);
            if (sp != null) sp.SoLuong += sl;
            else _gioHang.Add(new frmTrangchu.SanPham { TenMon = maMon, DonGia = giaMon, SoLuong = sl });
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
     


private void flowLayoutPanel2_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}

        // Nút Back / Thoát
        //private void guna2Button1_