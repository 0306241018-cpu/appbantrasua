using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmBaoCao : Form
    {
        private DatabaseHelper db;

        public frmBaoCao()
        {
            InitializeComponent();
            db = new DatabaseHelper();
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            LoadThongKe();
            LoadTop10SanPham();
        }

        private void LoadThongKe()
        {
            try
            {
                // 1. Doanh thu hôm nay (Sửa thành N'DaThanhToan')
                string queryHomNay = @"
                    SELECT ISNULL(SUM(TongTien), 0) 
                    FROM HoaDon 
                    WHERE CAST(NgayLap AS DATE) = CAST(GETDATE() AS DATE) 
                    AND TrangThai = N'DaThanhToan'";
                object resultHomNay = db.ExecuteScalar(queryHomNay);
                decimal doanhThuHomNay = (resultHomNay != null && resultHomNay != DBNull.Value) ? Convert.ToDecimal(resultHomNay) : 0;
                lblDoanhThuHomNay.Text = $"Doanh thu hôm nay: {doanhThuHomNay:N0} đ";

                // 2. Doanh thu tuần này (Sửa thành N'DaThanhToan' & Đổi NgayTao thành NgayLap)
                string queryTuan = @"
                    SELECT ISNULL(SUM(TongTien), 0) 
                    FROM HoaDon 
                    WHERE DATEPART(WEEK, NgayLap) = DATEPART(WEEK, GETDATE())
                    AND YEAR(NgayLap) = YEAR(GETDATE())
                    AND TrangThai = N'DaThanhToan'";
                object resultTuan = db.ExecuteScalar(queryTuan);
                decimal doanhThuTuan = (resultTuan != null && resultTuan != DBNull.Value) ? Convert.ToDecimal(resultTuan) : 0;
                lblDoanhThuTuan.Text = $"Doanh thu tuần này: {doanhThuTuan:N0} đ";

                // 3. Số lượng ly bán hôm nay (Sửa thành N'DaThanhToan')
                string queryLyHomNay = @"
                    SELECT ISNULL(SUM(SoLuong), 0) 
                    FROM ChiTietHoaDon ct 
                    INNER JOIN HoaDon hd ON ct.MaHD = hd.MaHD
                    WHERE CAST(hd.NgayLap AS DATE) = CAST(GETDATE() AS DATE)
                    AND hd.TrangThai = N'DaThanhToan'";
                object resultLyHomNay = db.ExecuteScalar(queryLyHomNay);
                int soLuongHomNay = (resultLyHomNay != null && resultLyHomNay != DBNull.Value) ? Convert.ToInt32(resultLyHomNay) : 0;
                lblSoLuongHomNay.Text = $"Số lượng ly bán hôm nay: {soLuongHomNay}";

                // 4. Tổng ly bán trong tuần (Sửa thành N'DaThanhToan')
                string queryLyTuan = @"
                    SELECT ISNULL(SUM(SoLuong), 0) 
                    FROM ChiTietHoaDon ct 
                    INNER JOIN HoaDon hd ON ct.MaHD = hd.MaHD
                    WHERE DATEPART(WEEK, hd.NgayLap) = DATEPART(WEEK, GETDATE())
                    AND YEAR(hd.NgayLap) = YEAR(GETDATE())
                    AND hd.TrangThai = N'DaThanhToan'";
                object resultLyTuan = db.ExecuteScalar(queryLyTuan);
                int tongLyTuan = (resultLyTuan != null && resultLyTuan != DBNull.Value) ? Convert.ToInt32(resultLyTuan) : 0;
                lblTongLyTuan.Text = $"Tổng ly bán trong tuần: {tongLyTuan}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTop10SanPham()
        {
            try
            {
                // Đã sửa hd.TrangThai = 1 thành hd.TrangThai = N'DaThanhToan'
                string query = @"
                    SELECT TOP 10 
                        sp.TenSP AS 'Sản phẩm',
                        SUM(ct.SoLuong) AS 'Số lượng bán',
                        SUM(ct.SoLuong * ct.DonGia) AS 'Doanh thu'
                    FROM ChiTietHoaDon ct
                    INNER JOIN SanPham sp ON ct.MaSP = sp.MaSP
                    INNER JOIN HoaDon hd ON ct.MaHD = hd.MaHD
                   WHERE hd.TrangThai = N'DaXong'
                    GROUP BY sp.TenSP
                    ORDER BY SUM(ct.SoLuong) DESC";

                DataTable dt = db.GetDataTable(query);
                dgvTopSanPham.DataSource = dt;

                // Format lại cột số cho đẹp
                if (dgvTopSanPham.Columns.Contains("Số lượng bán"))
                    dgvTopSanPham.Columns["Số lượng bán"].DefaultCellStyle.Format = "N0";
                if (dgvTopSanPham.Columns.Contains("Doanh thu"))
                    dgvTopSanPham.Columns["Doanh thu"].DefaultCellStyle.Format = "N0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải top 10: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        }
    }
