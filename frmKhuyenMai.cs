using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmKhuyenMai : Form
    {
        private DatabaseHelper db;

        // Cấu hình thư mục lưu ảnh
        private string imagesFolder = @"C:\Images_TraSua";
        private string selectedImageFileName = "";
        private string sourceImagePath = ""; // Đường dẫn tạm thời của ảnh khi chọn từ máy

        public frmKhuyenMai()
        {
            InitializeComponent();
            db = new DatabaseHelper();
        }

        private void frmKhuyenMai_Load(object sender, EventArgs e)
        {
            // Tạo thư mục nếu chưa có
            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }

            LoadData(); // Đã thêm lại dòng này để load dữ liệu khi mở form
            ClearForm();
        }

        private void LoadData()
        {
            string query = "SELECT MaVoucher AS MaKhuyenMai, TenVoucher AS TenKhuyenMai, GiaTri AS PhanTramGiam, DonHangToiThieu AS DieuKien, HinhAnh, TrangThai FROM Voucher WHERE TrangThai = 1";
            DataTable dt = db.GetDataTable(query);

            // Thêm dòng kiểm tra này: Nếu dt bị null do lỗi SQL thì báo lỗi thay vì crash app
            if (dt == null)
            {
                MessageBox.Show("Lỗi lấy dữ liệu từ DB! Vui lòng kiểm tra xem bảng Voucher đã có cột HinhAnh chưa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Bật tự động tạo cột (phòng trường hợp form bị tắt tính năng này)
            dgvKhuyenMai.AutoGenerateColumns = true;
            dgvKhuyenMai.DataSource = dt;

            dgvKhuyenMai.Columns["MaKhuyenMai"].HeaderText = "Mã KM";
            dgvKhuyenMai.Columns["TenKhuyenMai"].HeaderText = "Tên khuyến mãi";
            dgvKhuyenMai.Columns["PhanTramGiam"].HeaderText = "% Giảm";
            dgvKhuyenMai.Columns["DieuKien"].HeaderText = "Đơn tối thiểu";

            if (dgvKhuyenMai.Columns.Contains("HinhAnh"))
                dgvKhuyenMai.Columns["HinhAnh"].Visible = false;

            dgvKhuyenMai.Columns["TrangThai"].HeaderText = "Trạng thái";
            dgvKhuyenMai.Columns["TrangThai"].Visible = false;
        }

        private void ClearForm()
        {
            txtMaKM.Clear();
            txtTenKM.Clear();
            txtPhanTramGiam.Clear();
            txtDieuKien.Clear();
            picHinhAnh.Image = null; // Xóa ảnh trên form
            selectedImageFileName = "";
            sourceImagePath = "";

            guna2Button5.Enabled = true;
            guna2Button1.DisabledState.FillColor = Color.Transparent;
            guna2Button2.DisabledState.FillColor = Color.Transparent;
            guna2Button1.Enabled = false;
            guna2Button2.Enabled = false;
            txtTenKM.Focus();
        }

        // Sự kiện cho nút Chọn Ảnh
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
            ofd.Title = "Chọn ảnh khuyến mãi";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                sourceImagePath = ofd.FileName;
                selectedImageFileName = Path.GetFileName(ofd.FileName);

                // Giải phóng ảnh cũ (nếu có) để tránh lỗi file đang được sử dụng
                if (picHinhAnh.Image != null)
                {
                    picHinhAnh.Image.Dispose();
                }

                // Hiển thị ảnh lên PictureBox bằng FileStream để không bị lock file
                using (FileStream fs = new FileStream(sourceImagePath, FileMode.Open, FileAccess.Read))
                {
                    picHinhAnh.Image = Image.FromStream(fs);
                }
            }
        }

        // Hàm hỗ trợ copy ảnh vào thư mục dự án
        private void SaveImageToFolder()
        {
            if (!string.IsNullOrEmpty(sourceImagePath) && !string.IsNullOrEmpty(selectedImageFileName))
            {
                string destinationPath = Path.Combine(imagesFolder, selectedImageFileName);
                // Nếu ảnh chưa tồn tại trong thư mục thì copy vào
                if (!File.Exists(destinationPath))
                {
                    File.Copy(sourceImagePath, destinationPath);
                }
            }
        }

        // Gom chung xử lý click vào DataGridView vào 1 hàm này
        private void dgvKhuyenMai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhuyenMai.Rows[e.RowIndex];
                txtMaKM.Text = row.Cells["MaKhuyenMai"].Value.ToString();
                txtTenKM.Text = row.Cells["TenKhuyenMai"].Value.ToString();
                txtPhanTramGiam.Text = row.Cells["PhanTramGiam"].Value.ToString();
                txtDieuKien.Text = Convert.ToDecimal(row.Cells["DieuKien"].Value).ToString("0");

                // Load Hình Ảnh
                selectedImageFileName = row.Cells["HinhAnh"].Value?.ToString() ?? "";
                sourceImagePath = ""; // Reset đường dẫn tạm vì ảnh đang lấy từ DB

                if (picHinhAnh.Image != null)
                {
                    picHinhAnh.Image.Dispose();
                    picHinhAnh.Image = null;
                }

                if (!string.IsNullOrEmpty(selectedImageFileName))
                {
                    string path = Path.Combine(imagesFolder, selectedImageFileName);
                    if (File.Exists(path))
                    {
                        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                        {
                            picHinhAnh.Image = Image.FromStream(fs);
                        }
                    }
                }

                guna2Button5.Enabled = false;
                guna2Button5.DisabledState.FillColor = Color.Transparent; 
                guna2Button1.Enabled = true;
                guna2Button2.Enabled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
          
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            
        }

        private void btnChonAnh_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string sourcePath = ofd.FileName;
                        // Tạo tên file mới bằng GUID để không bị trùng tên
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(sourcePath);
                        string destPath = Path.Combine(imagesFolder, fileName);

                        // Copy ảnh vào C:\Images_TraSua
                        File.Copy(sourcePath, destPath, true);
                        selectedImageFileName = fileName;

                        // Hiển thị lên PictureBox (Dùng Stream để không bị khóa file)
                        using (FileStream fs = new FileStream(destPath, FileMode.Open, FileAccess.Read))
                        {
                            picHinhAnh.Image = Image.FromStream(fs);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi chọn ảnh: " + ex.Message);
                    }
                }
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenKM.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập tên khuyến mãi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKM.Focus();
                return;
            }

            if (!int.TryParse(txtPhanTramGiam.Text, out int phanTram))
            {
                MessageBox.Show("% giảm giá không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhanTramGiam.Focus();
                return;
            }

            decimal donHangToiThieu = 0;
            decimal.TryParse(txtDieuKien.Text.Trim(), out donHangToiThieu);

            // Lưu file ảnh vào thư mục
            SaveImageToFolder();

            string maVoucher = "KM" + DateTime.Now.ToString("ddMMHHmmss");

            // Bổ sung HinhAnh vào câu INSERT
            string query = $"INSERT INTO Voucher (MaVoucher, TenVoucher, LoaiGiamGia, GiaTri, DonHangToiThieu, NgayBatDau, NgayKetThuc, TrangThai, HinhAnh) " +
                           $"VALUES ('{maVoucher}', N'{txtTenKM.Text.Trim()}', 'PhanTram', {phanTram}, {donHangToiThieu}, GETDATE(), DATEADD(month, 1, GETDATE()), 1, '{selectedImageFileName}')";

            try
            {
                db.ExecuteNonQuery(query);
                MessageBox.Show("Thêm khuyến mãi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData(); // Load lại data sau khi thêm
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKM.Text))
            {
                MessageBox.Show("Vui lòng chọn khuyến mãi cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khuyến mãi này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string query = $"UPDATE Voucher SET TrangThai = 0 WHERE MaVoucher = '{txtMaKM.Text}'";
                try
                {
                    db.ExecuteNonQuery(query);
                    MessageBox.Show("Xóa khuyến mãi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadData(); // Load lại data sau khi xóa
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKM.Text))
            {
                MessageBox.Show("Vui lòng chọn khuyến mãi cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtPhanTramGiam.Text, out int phanTram))
            {
                MessageBox.Show("% giảm giá không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhanTramGiam.Focus();
                return;
            }

            decimal donHangToiThieu = 0;
            decimal.TryParse(txtDieuKien.Text.Trim(), out donHangToiThieu);

            // Lưu file ảnh vào thư mục (nếu có chọn ảnh mới)
            SaveImageToFolder();

            // Cập nhật cả cột HinhAnh
            string query = $"UPDATE Voucher SET TenVoucher = N'{txtTenKM.Text.Trim()}', GiaTri = {phanTram}, DonHangToiThieu = {donHangToiThieu}, HinhAnh = '{selectedImageFileName}' WHERE MaVoucher = '{txtMaKM.Text}'";

            try
            {
                db.ExecuteNonQuery(query);
                MessageBox.Show("Cập nhật khuyến mãi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData(); // Load lại data sau khi sửa
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void grbThongTin_Enter(object sender, EventArgs e)
        {

        }
    }
}