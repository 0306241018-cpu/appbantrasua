namespace WindowsFormsApp1
{
    partial class frmKhuyenMai
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
            this.grbDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvKhuyenMai = new System.Windows.Forms.DataGridView();
            this.grbThongTin = new System.Windows.Forms.GroupBox();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button5 = new Guna.UI2.WinForms.Guna2Button();
            this.picHinhAnh = new System.Windows.Forms.PictureBox();
            this.txtDieuKien = new System.Windows.Forms.TextBox();
            this.txtPhanTramGiam = new System.Windows.Forms.TextBox();
            this.txtTenKM = new System.Windows.Forms.TextBox();
            this.txtMaKM = new System.Windows.Forms.TextBox();
            this.lblDieuKien = new System.Windows.Forms.Label();
            this.lblPhanTramGiam = new System.Windows.Forms.Label();
            this.lblTenKM = new System.Windows.Forms.Label();
            this.lblMaKM = new System.Windows.Forms.Label();
            this.grbDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuyenMai)).BeginInit();
            this.grbThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).BeginInit();
            this.SuspendLayout();
            // 
            // grbDanhSach
            // 
            this.grbDanhSach.Controls.Add(this.dgvKhuyenMai);
            this.grbDanhSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDanhSach.Location = new System.Drawing.Point(15, 12);
            this.grbDanhSach.Margin = new System.Windows.Forms.Padding(4);
            this.grbDanhSach.Name = "grbDanhSach";
            this.grbDanhSach.Padding = new System.Windows.Forms.Padding(4);
            this.grbDanhSach.Size = new System.Drawing.Size(678, 677);
            this.grbDanhSach.TabIndex = 0;
            this.grbDanhSach.TabStop = false;
            this.grbDanhSach.Text = "Danh sách Khuyến mãi";
            // 
            // dgvKhuyenMai
            // 
            this.dgvKhuyenMai.AllowUserToAddRows = false;
            this.dgvKhuyenMai.AllowUserToDeleteRows = false;
            this.dgvKhuyenMai.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhuyenMai.BackgroundColor = System.Drawing.Color.White;
            this.dgvKhuyenMai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhuyenMai.Location = new System.Drawing.Point(8, 27);
            this.dgvKhuyenMai.Margin = new System.Windows.Forms.Padding(4);
            this.dgvKhuyenMai.MultiSelect = false;
            this.dgvKhuyenMai.Name = "dgvKhuyenMai";
            this.dgvKhuyenMai.ReadOnly = true;
            this.dgvKhuyenMai.RowHeadersVisible = false;
            this.dgvKhuyenMai.RowHeadersWidth = 51;
            this.dgvKhuyenMai.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhuyenMai.Size = new System.Drawing.Size(652, 642);
            this.dgvKhuyenMai.TabIndex = 0;
            this.dgvKhuyenMai.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhuyenMai_CellClick);
            // 
            // grbThongTin
            // 
            this.grbThongTin.Controls.Add(this.guna2Button2);
            this.grbThongTin.Controls.Add(this.guna2Button3);
            this.grbThongTin.Controls.Add(this.btnChonAnh);
            this.grbThongTin.Controls.Add(this.guna2Button1);
            this.grbThongTin.Controls.Add(this.guna2Button5);
            this.grbThongTin.Controls.Add(this.picHinhAnh);
            this.grbThongTin.Controls.Add(this.txtDieuKien);
            this.grbThongTin.Controls.Add(this.txtPhanTramGiam);
            this.grbThongTin.Controls.Add(this.txtTenKM);
            this.grbThongTin.Controls.Add(this.txtMaKM);
            this.grbThongTin.Controls.Add(this.lblDieuKien);
            this.grbThongTin.Controls.Add(this.lblPhanTramGiam);
            this.grbThongTin.Controls.Add(this.lblTenKM);
            this.grbThongTin.Controls.Add(this.lblMaKM);
            this.grbThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbThongTin.Location = new System.Drawing.Point(697, 13);
            this.grbThongTin.Margin = new System.Windows.Forms.Padding(4);
            this.grbThongTin.Name = "grbThongTin";
            this.grbThongTin.Padding = new System.Windows.Forms.Padding(4);
            this.grbThongTin.Size = new System.Drawing.Size(463, 683);
            this.grbThongTin.TabIndex = 1;
            this.grbThongTin.TabStop = false;
            this.grbThongTin.Text = "Thông tin khuyến mãi";
            this.grbThongTin.Enter += new System.EventHandler(this.grbThongTin_Enter);
            // 
            // guna2Button2
            // 
            this.guna2Button2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button2.BorderRadius = 20;
            this.guna2Button2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.NavajoWhite;
            this.guna2Button2.Font = new System.Drawing.Font("Times New Roman", 10.8F);
            this.guna2Button2.ForeColor = System.Drawing.Color.Black;
            this.guna2Button2.IndicateFocus = true;
            this.guna2Button2.Location = new System.Drawing.Point(297, 547);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(127, 46);
            this.guna2Button2.TabIndex = 19;
            this.guna2Button2.Text = "Xóa";
            this.guna2Button2.UseTransparentBackground = true;
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // guna2Button3
            // 
            this.guna2Button3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button3.BorderRadius = 20;
            this.guna2Button3.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.guna2Button3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button3.FillColor = System.Drawing.Color.NavajoWhite;
            this.guna2Button3.Font = new System.Drawing.Font("Times New Roman", 10.8F);
            this.guna2Button3.ForeColor = System.Drawing.Color.Black;
            this.guna2Button3.IndicateFocus = true;
            this.guna2Button3.Location = new System.Drawing.Point(297, 613);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.Size = new System.Drawing.Size(127, 46);
            this.guna2Button3.TabIndex = 21;
            this.guna2Button3.Text = "Làm mới";
            this.guna2Button3.UseTransparentBackground = true;
            this.guna2Button3.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // btnChonAnh
            // 
            this.btnChonAnh.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnChonAnh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChonAnh.ForeColor = System.Drawing.Color.White;
            this.btnChonAnh.Location = new System.Drawing.Point(263, 157);
            this.btnChonAnh.Margin = new System.Windows.Forms.Padding(4);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(136, 43);
            this.btnChonAnh.TabIndex = 13;
            this.btnChonAnh.Text = "Chọn ảnh";
            this.btnChonAnh.UseVisualStyleBackColor = false;
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click_1);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderRadius = 20;
            this.guna2Button1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.NavajoWhite;
            this.guna2Button1.Font = new System.Drawing.Font("Times New Roman", 10.8F);
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.IndicateFocus = true;
            this.guna2Button1.Location = new System.Drawing.Point(29, 613);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(141, 46);
            this.guna2Button1.TabIndex = 20;
            this.guna2Button1.Text = "Cập nhật";
            this.guna2Button1.UseTransparentBackground = true;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // guna2Button5
            // 
            this.guna2Button5.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button5.BorderRadius = 20;
            this.guna2Button5.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.guna2Button5.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button5.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button5.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button5.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button5.FillColor = System.Drawing.Color.NavajoWhite;
            this.guna2Button5.Font = new System.Drawing.Font("Times New Roman", 10.8F);
            this.guna2Button5.ForeColor = System.Drawing.Color.Black;
            this.guna2Button5.IndicateFocus = true;
            this.guna2Button5.Location = new System.Drawing.Point(29, 547);
            this.guna2Button5.Name = "guna2Button5";
            this.guna2Button5.Size = new System.Drawing.Size(141, 46);
            this.guna2Button5.TabIndex = 17;
            this.guna2Button5.Text = "Thêm";
            this.guna2Button5.UseTransparentBackground = true;
            this.guna2Button5.Click += new System.EventHandler(this.guna2Button5_Click);
            // 
            // picHinhAnh
            // 
            this.picHinhAnh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picHinhAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picHinhAnh.Location = new System.Drawing.Point(29, 127);
            this.picHinhAnh.Margin = new System.Windows.Forms.Padding(4);
            this.picHinhAnh.Name = "picHinhAnh";
            this.picHinhAnh.Size = new System.Drawing.Size(189, 108);
            this.picHinhAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHinhAnh.TabIndex = 12;
            this.picHinhAnh.TabStop = false;
            // 
            // txtDieuKien
            // 
            this.txtDieuKien.Location = new System.Drawing.Point(176, 449);
            this.txtDieuKien.Margin = new System.Windows.Forms.Padding(4);
            this.txtDieuKien.Name = "txtDieuKien";
            this.txtDieuKien.Size = new System.Drawing.Size(223, 26);
            this.txtDieuKien.TabIndex = 7;
            // 
            // txtPhanTramGiam
            // 
            this.txtPhanTramGiam.Location = new System.Drawing.Point(176, 399);
            this.txtPhanTramGiam.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhanTramGiam.Name = "txtPhanTramGiam";
            this.txtPhanTramGiam.Size = new System.Drawing.Size(223, 26);
            this.txtPhanTramGiam.TabIndex = 6;
            // 
            // txtTenKM
            // 
            this.txtTenKM.Location = new System.Drawing.Point(176, 348);
            this.txtTenKM.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenKM.Name = "txtTenKM";
            this.txtTenKM.Size = new System.Drawing.Size(223, 26);
            this.txtTenKM.TabIndex = 5;
            // 
            // txtMaKM
            // 
            this.txtMaKM.Location = new System.Drawing.Point(176, 292);
            this.txtMaKM.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaKM.Name = "txtMaKM";
            this.txtMaKM.ReadOnly = true;
            this.txtMaKM.Size = new System.Drawing.Size(223, 26);
            this.txtMaKM.TabIndex = 4;
            // 
            // lblDieuKien
            // 
            this.lblDieuKien.AutoSize = true;
            this.lblDieuKien.Location = new System.Drawing.Point(56, 455);
            this.lblDieuKien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDieuKien.Name = "lblDieuKien";
            this.lblDieuKien.Size = new System.Drawing.Size(83, 20);
            this.lblDieuKien.TabIndex = 3;
            this.lblDieuKien.Text = "Điều kiện:";
            // 
            // lblPhanTramGiam
            // 
            this.lblPhanTramGiam.AutoSize = true;
            this.lblPhanTramGiam.Location = new System.Drawing.Point(43, 405);
            this.lblPhanTramGiam.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhanTramGiam.Name = "lblPhanTramGiam";
            this.lblPhanTramGiam.Size = new System.Drawing.Size(101, 20);
            this.lblPhanTramGiam.TabIndex = 2;
            this.lblPhanTramGiam.Text = "% Giảm giá:";
            // 
            // lblTenKM
            // 
            this.lblTenKM.AutoSize = true;
            this.lblTenKM.Location = new System.Drawing.Point(67, 354);
            this.lblTenKM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTenKM.Name = "lblTenKM";
            this.lblTenKM.Size = new System.Drawing.Size(72, 20);
            this.lblTenKM.TabIndex = 1;
            this.lblTenKM.Text = "Tên KM:";
            // 
            // lblMaKM
            // 
            this.lblMaKM.AutoSize = true;
            this.lblMaKM.Location = new System.Drawing.Point(77, 292);
            this.lblMaKM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaKM.Name = "lblMaKM";
            this.lblMaKM.Size = new System.Drawing.Size(67, 20);
            this.lblMaKM.TabIndex = 0;
            this.lblMaKM.Text = "Mã KM:";
            // 
            // frmKhuyenMai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.pngtree_chinese_style_ink_tea_tea_shop_home_picture_image_1031072;
            this.ClientSize = new System.Drawing.Size(1327, 708);
            this.Controls.Add(this.grbThongTin);
            this.Controls.Add(this.grbDanhSach);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmKhuyenMai";
            this.Text = "Quản lý khuyến mãi";
            this.Load += new System.EventHandler(this.frmKhuyenMai_Load);
            this.grbDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuyenMai)).EndInit();
            this.grbThongTin.ResumeLayout(false);
            this.grbThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbDanhSach;
        private System.Windows.Forms.DataGridView dgvKhuyenMai;
        private System.Windows.Forms.GroupBox grbThongTin;
        private System.Windows.Forms.TextBox txtDieuKien;
        private System.Windows.Forms.TextBox txtPhanTramGiam;
        private System.Windows.Forms.TextBox txtTenKM;
        private System.Windows.Forms.TextBox txtMaKM;
        private System.Windows.Forms.Label lblDieuKien;
        private System.Windows.Forms.Label lblPhanTramGiam;
        private System.Windows.Forms.Label lblTenKM;
        private System.Windows.Forms.Label lblMaKM;
        private System.Windows.Forms.PictureBox picHinhAnh;
        private System.Windows.Forms.Button btnChonAnh;
        private Guna.UI2.WinForms.Guna2Button guna2Button5;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}
