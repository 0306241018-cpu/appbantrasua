using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmSanPham : Form
    {
        private DatabaseHelper db;
        private string selectedImageFileName = "";
        private string imagesFolder = Path.Combine(Application.StartupPath, "Images");

        public frmSanPham()
        {
            InitializeComponent();
            db = new DatabaseHelper();
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            // Tao thu muc Images neu chua co
            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }

            LoadLoaiSanPham();
            LoadData();
            ClearForm();
        }

        private void LoadLoaiSanPham()
        {
            string query = "SELECT DISTINCT Loai FROM SanPham WHERE Loai IS NOT NULL AND TrangThai = 1";
            DataTable dt = db.GetDataTable(query);

            cboLoai.Items.Clear();
            cboLoai.Items.Add("TraSua");
            cboLoai.Items.Add("NuocEp");
            cboLoai.Items.Add("SinhTo");
            cboLoai.Items.Add("CaPhe");
            cboLoai.Items.Add("Khac");

            foreach (DataRow row in dt.Rows)
            {
                string loai = row["Loai"].ToString();
                if (!cboLoai.Items.Contains(loai))
                {
                    cboLoai.Items.Add(loai);
                }
            }
            cboLoai.SelectedIndex = 0;
        }

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
            dgvSanPham.Columns["HinhAnh"].HeaderText = "Hình ảnh";
            dgvSanPham.Columns["TrangThai"].HeaderText = "Trạng thái";
            dgvSanPham.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
            dgvSanPham.Columns["HinhAnh"].Visible = false;
            dgvSanPham.Columns["TrangThai"].Visible = false;
        }

        private void ClearForm()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtGia.Clear();
            txtMoTa.Clear();
            cboLoai.SelectedIndex = 0;
            selectedImageFileName = "";
            picHinhAnh.Image = null;
            chkTrangThai.Checked = true;
            btnThem.Enabled = true;
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
            txtTenSP.Focus();
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];
                txtMaSP.Text = row.Cells["MaSP"].Value.ToString();
                txtTenSP.Text = row.Cells["TenSP"].Value.ToString();
                txtGia.Text = Convert.ToDecimal(row.Cells["GiaBan"].Value).ToString("N0");
                txtMoTa.Text = row.Cells["MoTa"].Value?.ToString() ?? "";
                string loai = row.Cells["Loai"].Value?.ToString() ?? "TraSua";
                selectedImageFileName = row.Cells["HinhAnh"].Value?.ToString() ?? "";

                for (int i = 0; i < cboLoai.Items.Count; i++)
                {
                    if (cboLoai.Items[i].ToString() == loai)
                    {
                        cboLoai.SelectedIndex = i;
                        break;
                    }
                }

                // Hien thi hinh anh
                LoadImage(selectedImageFileName);

                btnThem.Enabled = false;
                btnCapNhat.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void LoadImage(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                picHinhAnh.Image = null;
                return;
            }

            string imagePath = Path.Combine(imagesFolder, fileName);
            if (File.Exists(imagePath))
            {
                using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    picHinhAnh.Image = Image.FromStream(fs);
                }
            }
            else
            {
                picHinhAnh.Image = null;
            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";
                ofd.Title = "Chọn hình ảnh sản phẩm";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string sourcePath = ofd.FileName;
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(sourcePath);
                    string destPath = Path.Combine(imagesFolder, fileName);

                    try
                    {
                        // Tao thu muc neu chua ton tai
                        if (!Directory.Exists(imagesFolder))
                        {
                            Directory.CreateDirectory(imagesFolder);
                        }

                        // Copy file anh vao thu muc Images
                        File.Copy(sourcePath, destPath, true);

                        selectedImageFileName = fileName;

                        // Hien thi anh trong PictureBox
                        using (FileStream fs = new FileStream(destPath, FileMode.Open, FileAccess.Read))
                        {
                            picHinhAnh.Image = Image.FromStream(fs);
                        }

                        MessageBox.Show("Đã chọn ảnh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi chọn ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenSP.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSP.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtGia.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập giá sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGia.Focus();
                return;
            }

            if (!decimal.TryParse(txtGia.Text.Replace(",", ""), out decimal giaBan))
            {
                MessageBox.Show("Giá không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGia.Focus();
                return;
            }

            string loai = cboLoai.SelectedItem.ToString();
            string hinhAnh = selectedImageFileName ?? "";
            int trangThai = chkTrangThai.Checked ? 1 : 0;

            string query = $"INSERT INTO SanPham (TenSP, GiaGoc, GiaBan, Loai, MoTa, HinhAnh, TrangThai) " +
                          $"VALUES (N'{txtTenSP.Text.Trim()}', {giaBan}, {giaBan}, N'{loai}', N'{txtMoTa.Text.Trim()}', N'{hinhAnh}', {trangThai})";

            try
            {
                db.ExecuteNonQuery(query);
                MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSP.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtTenSP.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSP.Focus();
                return;
            }

            if (!decimal.TryParse(txtGia.Text.Replace(",", ""), out decimal giaBan))
            {
                MessageBox.Show("Giá không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSP.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string query = $"UPDATE SanPham SET TrangThai = 0 WHERE MaSP = {txtMaSP.Text}";
                try
                {
                    db.ExecuteNonQuery(query);
                    MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadData();
                return;
            }

            string query = $"SELECT MaSP, TenSP, GiaBan, Loai, MoTa, HinhAnh, TrangThai FROM SanPham " +
                          $"WHERE TrangThai = 1 AND TenSP LIKE N'%{keyword}%'";
            DataTable dt = db.GetDataTable(query);
            dgvSanPham.DataSource = dt;
        }
    }
}
