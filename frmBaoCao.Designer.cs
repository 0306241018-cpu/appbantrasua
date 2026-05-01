namespace WindowsFormsApp1
{
    partial class frmBaoCao
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.grbThongBaoTien = new System.Windows.Forms.GroupBox();
            this.lblDoanhThuTuan = new System.Windows.Forms.Label();
            this.lblDoanhThuHomNay = new System.Windows.Forms.Label();
            this.grbSoLuongBan = new System.Windows.Forms.GroupBox();
            this.lblTongLyTuan = new System.Windows.Forms.Label();
            this.lblSoLuongHomNay = new System.Windows.Forms.Label();
            this.grbTop10 = new System.Windows.Forms.GroupBox();
            this.dgvTopSanPham = new System.Windows.Forms.DataGridView();
            this.grbThongBaoTien.SuspendLayout();
            this.grbSoLuongBan.SuspendLayout();
            this.grbTop10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // grbThongBaoTien
            // 
            this.grbThongBaoTien.Controls.Add(this.lblDoanhThuTuan);
            this.grbThongBaoTien.Controls.Add(this.lblDoanhThuHomNay);
            this.grbThongBaoTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbThongBaoTien.Location = new System.Drawing.Point(13, 12);
            this.grbThongBaoTien.Margin = new System.Windows.Forms.Padding(4);
            this.grbThongBaoTien.Name = "grbThongBaoTien";
            this.grbThongBaoTien.Padding = new System.Windows.Forms.Padding(4);
            this.grbThongBaoTien.Size = new System.Drawing.Size(533, 185);
            this.grbThongBaoTien.TabIndex = 0;
            this.grbThongBaoTien.TabStop = false;
            this.grbThongBaoTien.Text = "Thông báo Doanh thu";
            // 
            // lblDoanhThuTuan
            // 
            this.lblDoanhThuTuan.AutoSize = true;
            this.lblDoanhThuTuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoanhThuTuan.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblDoanhThuTuan.Location = new System.Drawing.Point(20, 105);
            this.lblDoanhThuTuan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDoanhThuTuan.Name = "lblDoanhThuTuan";
            this.lblDoanhThuTuan.Size = new System.Drawing.Size(283, 29);
            this.lblDoanhThuTuan.TabIndex = 1;
            this.lblDoanhThuTuan.Text = "Doanh thu tuần này: 0 đ";
            // 
            // lblDoanhThuHomNay
            // 
            this.lblDoanhThuHomNay.AutoSize = true;
            this.lblDoanhThuHomNay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoanhThuHomNay.ForeColor = System.Drawing.Color.Green;
            this.lblDoanhThuHomNay.Location = new System.Drawing.Point(20, 49);
            this.lblDoanhThuHomNay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDoanhThuHomNay.Name = "lblDoanhThuHomNay";
            this.lblDoanhThuHomNay.Size = new System.Drawing.Size(284, 29);
            this.lblDoanhThuHomNay.TabIndex = 0;
            this.lblDoanhThuHomNay.Text = "Doanh thu hôm nay: 0 đ";
            // 
            // grbSoLuongBan
            // 
            this.grbSoLuongBan.Controls.Add(this.lblTongLyTuan);
            this.grbSoLuongBan.Controls.Add(this.lblSoLuongHomNay);
            this.grbSoLuongBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbSoLuongBan.Location = new System.Drawing.Point(560, 12);
            this.grbSoLuongBan.Margin = new System.Windows.Forms.Padding(4);
            this.grbSoLuongBan.Name = "grbSoLuongBan";
            this.grbSoLuongBan.Padding = new System.Windows.Forms.Padding(4);
            this.grbSoLuongBan.Size = new System.Drawing.Size(533, 185);
            this.grbSoLuongBan.TabIndex = 1;
            this.grbSoLuongBan.TabStop = false;
            this.grbSoLuongBan.Text = "Thống kê Số lượng";
            // 
            // lblTongLyTuan
            // 
            this.lblTongLyTuan.AutoSize = true;
            this.lblTongLyTuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongLyTuan.ForeColor = System.Drawing.Color.Orange;
            this.lblTongLyTuan.Location = new System.Drawing.Point(20, 105);
            this.lblTongLyTuan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTongLyTuan.Name = "lblTongLyTuan";
            this.lblTongLyTuan.Size = new System.Drawing.Size(301, 29);
            this.lblTongLyTuan.TabIndex = 1;
            this.lblTongLyTuan.Text = "Tổng ly bán trong tuần: 0";
            // 
            // lblSoLuongHomNay
            // 
            this.lblSoLuongHomNay.AutoSize = true;
            this.lblSoLuongHomNay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuongHomNay.ForeColor = System.Drawing.Color.Purple;
            this.lblSoLuongHomNay.Location = new System.Drawing.Point(20, 49);
            this.lblSoLuongHomNay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSoLuongHomNay.Name = "lblSoLuongHomNay";
            this.lblSoLuongHomNay.Size = new System.Drawing.Size(325, 29);
            this.lblSoLuongHomNay.TabIndex = 0;
            this.lblSoLuongHomNay.Text = "Số lượng ly bán hôm nay: 0";
            // 
            // grbTop10
            // 
            this.grbTop10.Controls.Add(this.dgvTopSanPham);
            this.grbTop10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbTop10.Location = new System.Drawing.Point(13, 209);
            this.grbTop10.Margin = new System.Windows.Forms.Padding(4);
            this.grbTop10.Name = "grbTop10";
            this.grbTop10.Padding = new System.Windows.Forms.Padding(4);
            this.grbTop10.Size = new System.Drawing.Size(1080, 492);
            this.grbTop10.TabIndex = 2;
            this.grbTop10.TabStop = false;
            this.grbTop10.Text = "Top 10 sản phẩm bán chạy nhất";
            // 
            // dgvTopSanPham
            // 
            this.dgvTopSanPham.AllowUserToAddRows = false;
            this.dgvTopSanPham.AllowUserToDeleteRows = false;
            this.dgvTopSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopSanPham.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopSanPham.Location = new System.Drawing.Point(8, 27);
            this.dgvTopSanPham.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTopSanPham.MultiSelect = false;
            this.dgvTopSanPham.Name = "dgvTopSanPham";
            this.dgvTopSanPham.ReadOnly = true;
            this.dgvTopSanPham.RowHeadersVisible = false;
            this.dgvTopSanPham.RowHeadersWidth = 51;
            this.dgvTopSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopSanPham.Size = new System.Drawing.Size(1064, 458);
            this.dgvTopSanPham.TabIndex = 0;
            // 
            // frmBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.pngtree_chinese_style_ink_tea_tea_shop_home_picture_image_1031072;
            this.ClientSize = new System.Drawing.Size(1230, 714);
            this.Controls.Add(this.grbTop10);
            this.Controls.Add(this.grbSoLuongBan);
            this.Controls.Add(this.grbThongBaoTien);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBaoCao";
            this.Text = "Báo cáo thống kê";
            this.Load += new System.EventHandler(this.frmBaoCao_Load);
            this.grbThongBaoTien.ResumeLayout(false);
            this.grbThongBaoTien.PerformLayout();
            this.grbSoLuongBan.ResumeLayout(false);
            this.grbSoLuongBan.PerformLayout();
            this.grbTop10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSanPham)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbThongBaoTien;
        private System.Windows.Forms.Label lblDoanhThuHomNay;
        private System.Windows.Forms.Label lblDoanhThuTuan;
        private System.Windows.Forms.GroupBox grbSoLuongBan;
        private System.Windows.Forms.Label lblSoLuongHomNay;
        private System.Windows.Forms.Label lblTongLyTuan;
        private System.Windows.Forms.GroupBox grbTop10;
        private System.Windows.Forms.DataGridView dgvTopSanPham;
    }
}
