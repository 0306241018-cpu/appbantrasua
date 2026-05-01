using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmSanPham : Form
    {
        private DatabaseHelper db;
        private string selectedImageFileName = "";

        // CỐ ĐỊNH THƯ MỤC ẢNH CHUNG CHO CẢ 2 APP
        private string imagesFolder = @"C:\Images_TraSua";

        public frmSanPham()
        {
            InitializeComponent();
            db = new DatabaseHelper();
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            // Tạo thư mục C:\Images_TraSua nếu máy chưa có
            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }

            LoadLoaiSanPham();
            LoadData();
            ClearForm();

            // Trang trí Guna
            guna2TextBox1.PlaceholderText = "Tìm kiếm sản phẩm của bạn";
            guna2Button1.HoverState.FillColor = Color.FromArgb(255, 228, 181);
            guna2Button2.HoverState.FillColor = Color.FromArgb(255, 228, 181);
            guna2Button3.HoverState.FillColor = Color.FromArgb(255, 228, 181);
            guna2Button5.HoverState.FillColor = Color.FromArgb(255, 228, 181);
            //guna2Button2.FillColor = Color.NavajoWhite;
        }

        // ============================================
        // HÀM LOAD DỮ LIỆU LÊN BẢNG
        // ============================================
        private void LoadData()
        {
            string query = "SELECT MaSP, TenSP, GiaBan, Loai, MoTa, HinhAnh, TrangThai FROM SanPham WHERE TrangThai = 1";
            DataTable dt = db.GetDataTable(query);
            dgvSanPham.DataSource = dt;

            dgvSanPham.Columns["MaSP"].HeaderText = "Mã SP";
            dgvSanPham.Columns["TenSP"].HeaderText = "Tên sản phẩm";
            dgvSanPham.Columns["GiaBan"].HeaderText = "Giá bán";
            dgvSanPham.Columns["Loai"].HeaderText = "Loại";
            dgvSanPham.Columns["MoTa"].HeaderText = "Mô tả";
            dgvSanPham.Columns["HinhAnh"].Visible = false;
            dgvSanPham.Columns["TrangThai"].Visible = false;
            dgvSanPham.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
        }

        // ============================================
        // HÀM CHỌN ẢNH VÀ COPY VÀO THƯ MỤC CHUNG
        // ============================================
        private void btnChonAnh_Click(object sender, EventArgs e)
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

        // ============================================
        // CLICK VÀO BẢNG THÌ HIỆN HÌNH LÊN PICTUREBOX
        // ============================================
        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];
                txtMaSP.Text = row.Cells["MaSP"].Value.ToString();
                txtTenSP.Text = row.Cells["TenSP"].Value.ToString();
                txtGia.Text = row.Cells["GiaBan"].Value.ToString();
                txtMoTa.Text = row.Cells["MoTa"].Value?.ToString() ?? "";
                cboLoai.Text = row.Cells["Loai"].Value?.ToString() ?? "TraSua";
                selectedImageFileName = row.Cells["HinhAnh"].Value?.ToString() ?? "";

                // Load hình từ thư mục C:\Images_TraSua
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
                    else picHinhAnh.Image = null;
                }
                else picHinhAnh.Image = null;

                guna2Button5.Enabled = false;
                guna2Button5.DisabledState.FillColor = Color.Transparent;
                // Khóa nút Thêm khi đang chọn sửa
            }
            guna2Button5.Enabled = false;
           
            guna2Button1.Enabled = true;

            guna2Button2.Enabled = true;
        }

        // ============================================
        // NÚT THÊM SẢN PHẨM (LƯU TÊN FILE VÀO SQL)
        // ============================================
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenSP.Text) ||

     string.IsNullOrEmpty(txtMoTa.Text) ||
     string.IsNullOrEmpty(txtGia.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!"); // Optional: Alert the user
                return;
            }
            string ten = txtTenSP.Text.Trim();
            decimal gia = decimal.Parse(txtGia.Text);
            string loai = cboLoai.Text;
            string mota = txtMoTa.Text.Trim();

            // Lưu cái tên file selectedImageFileName vào cột HinhAnh trong SQL
            string query = $"INSERT INTO SanPham (TenSP, GiaGoc, GiaBan, Loai, MoTa, HinhAnh, TrangThai) " +
                           $"VALUES (N'{ten}', {gia}, {gia}, N'{loai}', N'{mota}', N'{selectedImageFileName}', 1)";

            db.ExecuteNonQuery(query);
            MessageBox.Show("Thêm thành công!");
            LoadData();
            ClearForm();
        }

        // Các hàm phụ khác giữ nguyên...
        private void ClearForm()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtGia.Clear();
            txtMoTa.Clear();
            picHinhAnh.Image = null;
            selectedImageFileName = "";
            guna2Button5.Enabled = true;
            guna2Button1.DisabledState.FillColor = Color.Transparent;
            guna2Button2.DisabledState.FillColor = Color.Transparent ;
            guna2Button1.Enabled = false;
            guna2Button2.Enabled = false;

        }

        private void LoadLoaiSanPham()
        {
            cboLoai.Items.Clear();
            cboLoai.Items.AddRange(new string[] { "TraSua", "NuocEp", "SinhTo", "CaPhe", "Khac" });
            cboLoai.SelectedIndex = 0;
        }

        private void guna2Button3_Click(object sender, EventArgs e) => ClearForm();
        private void guna2Button2_Click(object sender, EventArgs e)
        {
         
        }


     
        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSP.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần cập nhật!", "GO SALO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtTenSP.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!", "GO SALO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSP.Focus();
                return;
            }

            if (!decimal.TryParse(txtGia.Text.Replace(",", ""), out decimal giaBan))
            {
                MessageBox.Show("Giá không hợp lệ!", "GO SALO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGia.Focus();
                return;
            }

            string loai = cboLoai.SelectedItem.ToString();
            string hinhAnh = selectedImageFileName ?? "";
            int trangThai = chkTrangThai.Checked ? 1 : 0;

            string query = $"UPDATE SanPham SET TenSP = N'{txtTenSP.Text.Trim()}', GiaBan = {giaBan}, " +
                          $"Loai = N'{loai}', MoTa = N'{txtMoTa.Text.Trim()}', HinhAnh = N'{hinhAnh}', " +
                          $"TrangThai = {trangThai} WHERE MaSP = {txtMaSP.Text}";

            try
            {
                db.ExecuteNonQuery(query);
                MessageBox.Show("Cập nhật sản phẩm thành công!", "GO SALO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSP.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "GO SALO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?","GO SALO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string query = $"UPDATE SanPham SET TrangThai = 0 WHERE MaSP = {txtMaSP.Text}";
                try
                {
                    db.ExecuteNonQuery(query);
                    MessageBox.Show("Xóa sản phẩm thành công!", "GO SALO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void grbThongTin_Enter(object sender, EventArgs e)
        {

        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grbDanhSach_Enter(object sender, EventArgs e)
        {

        }

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains('.') == false) return;
            if (e.KeyChar == (char)Keys.Back) return;
            e.Handled = true;
        }
    }
}
