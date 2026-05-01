using System;
using System.Data;
using System.Drawing; // Thêm thư viện này để dùng Image
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmTopping : Form
    {
        private DatabaseHelper db;
        private string imagesFolder = @"C:\Images_TraSua";
        private string selectedImageFileName = "";

        public frmTopping()
        {
            InitializeComponent();
            db = new DatabaseHelper();

            // Đảm bảo thư mục lưu ảnh tồn tại
            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }
        }

        private void frmTopping_Load(object sender, EventArgs e)
        {
            LoadData();
            ClearForm();
        }

        private void LoadData()
        {
            // Lấy thêm cột HinhAnh để xử lý
            string query = "SELECT MaTopping, TenTopping, Gia, MoTa, HinhAnh, TrangThai FROM Topping WHERE TrangThai = 1";
            DataTable dt = db.GetDataTable(query);
            dgvTopping.DataSource = dt;

            dgvTopping.Columns["MaTopping"].HeaderText = "Mã TP";
            dgvTopping.Columns["TenTopping"].HeaderText = "Tên topping";
            dgvTopping.Columns["Gia"].HeaderText = "Giá";
            dgvTopping.Columns["MoTa"].HeaderText = "Mô tả";
            dgvTopping.Columns["HinhAnh"].HeaderText = "Tên File Ảnh";
            dgvTopping.Columns["TrangThai"].Visible = false;

            dgvTopping.Columns["Gia"].DefaultCellStyle.Format = "N0";
        }

        private void ClearForm()
        {
            txtMaTP.Clear();
            txtTenTP.Clear();
            txtGia.Clear();
            txtMoTa.Clear();
            picHinhAnh.Image = null;
            selectedImageFileName = "";
            guna2Button5.Enabled = true;
            guna2Button1.DisabledState.FillColor = Color.Transparent;
            guna2Button2.DisabledState.FillColor = Color.Transparent;
            guna2Button1.Enabled = false;
            guna2Button2.Enabled = false;
            txtTenTP.Focus();
        }

        private void dgvTopping_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTopping.Rows[e.RowIndex];
                txtMaTP.Text = row.Cells["MaTopping"].Value.ToString();
                txtTenTP.Text = row.Cells["TenTopping"].Value.ToString();
                txtGia.Text = Convert.ToDecimal(row.Cells["Gia"].Value).ToString("N0");
                txtMoTa.Text = row.Cells["MoTa"].Value?.ToString() ?? "";

                // --- HIỂN THỊ ẢNH KHI CLICK ---
                selectedImageFileName = row.Cells["HinhAnh"].Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(selectedImageFileName))
                {
                    string fullPath = Path.Combine(imagesFolder, selectedImageFileName);
                    if (File.Exists(fullPath))
                    {
                        using (FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                        {
                            picHinhAnh.Image = Image.FromStream(fs);
                        }
                    }
                    else picHinhAnh.Image = null;
                }
                else picHinhAnh.Image = null;

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
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(sourcePath);
                        string destPath = Path.Combine(imagesFolder, fileName);

                        File.Copy(sourcePath, destPath, true);
                        selectedImageFileName = fileName;

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
            // ... (Phần validate Ten và Gia giữ nguyên như code của bạn) ...
            if (string.IsNullOrEmpty(txtTenTP.Text.Trim())) return;
            if (!decimal.TryParse(txtGia.Text.Replace(",", ""), out decimal gia)) return;

            // SỬA LỖI SQL INSERT: Đưa HinhAnh vào trong ngoặc VALUES
            string query = $@"INSERT INTO Topping (TenTopping, Gia, MoTa, HinhAnh, TrangThai) 
                             VALUES (N'{txtTenTP.Text.Trim()}', {gia}, N'{txtMoTa.Text.Trim()}', '{selectedImageFileName}', 1)";

            try
            {
                db.ExecuteNonQuery(query);
                MessageBox.Show("Thêm topping thành công!");
                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaTP.Text)) return;
            if (!decimal.TryParse(txtGia.Text.Replace(",", ""), out decimal gia)) return;

            // SỬA LỖI SQL UPDATE: Cập nhật thêm cột HinhAnh
            string query = $@"UPDATE Topping 
                             SET TenTopping = N'{txtTenTP.Text.Trim()}', 
                                 Gia = {gia}, 
                                 MoTa = N'{txtMoTa.Text.Trim()}', 
                                 HinhAnh = '{selectedImageFileName}' 
                             WHERE MaTopping = {txtMaTP.Text}";

            try
            {
                db.ExecuteNonQuery(query);
                MessageBox.Show("Cập nhật topping thành công!");
                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtMaTP.Text)) return;

            DialogResult result = MessageBox.Show("Xác nhận xóa?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string query = $"UPDATE Topping SET TrangThai = 0 WHERE MaTopping = {txtMaTP.Text}";
                try
                {
                    db.ExecuteNonQuery(query);
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                    ClearForm();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void txtGia_TextChanged(object sender, EventArgs e)
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

