namespace WindowsFormsApp1
{
    partial class frmSanPham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSanPham));
            this.grbDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.grbThongTin = new System.Windows.Forms.GroupBox();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button5 = new Guna.UI2.WinForms.Guna2Button();
            this.chkTrangThai = new System.Windows.Forms.CheckBox();
            this.picHinhAnh = new System.Windows.Forms.PictureBox();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.cboLoai = new System.Windows.Forms.ComboBox();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.lblLoai = new System.Windows.Forms.Label();
            this.lblGia = new System.Windows.Forms.Label();
            this.lblTenSP = new System.Windows.Forms.Label();
            this.lblMaSP = new System.Windows.Forms.Label();
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.grbDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.grbThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).BeginInit();
            this.SuspendLayout();
            // 
            // grbDanhSach
            // 
            this.grbDanhSach.Controls.Add(this.dgvSanPham);
            this.grbDanhSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDanhSach.Location = new System.Drawing.Point(13, 98);
            this.grbDanhSach.Margin = new System.Windows.Forms.Padding(4);
            this.grbDanhSach.Name = "grbDanhSach";
            this.grbDanhSach.Padding = new System.Windows.Forms.Padding(4);
            this.grbDanhSach.Size = new System.Drawing.Size(621, 627);
            this.grbDanhSach.TabIndex = 1;
            this.grbDanhSach.TabStop = false;
            this.grbDanhSach.Text = "Danh sách sản phẩm";
            this.grbDanhSach.Enter += new System.EventHandler(this.grbDanhSach_Enter);
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.AllowUserToAddRows = false;
            this.dgvSanPham.AllowUserToDeleteRows = false;
            this.dgvSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSanPham.BackgroundColor = System.Drawing.Color.White;
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSanPham.Location = new System.Drawing.Point(4, 23);
            this.dgvSanPham.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSanPham.MultiSelect = false;
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.ReadOnly = true;
            this.dgvSanPham.RowHeadersVisible = false;
            this.dgvSanPham.RowHeadersWidth = 51;
            this.dgvSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSanPham.Size = new System.Drawing.Size(613, 600);
            this.dgvSanPham.TabIndex = 0;
            this.dgvSanPham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPham_CellClick);
            this.dgvSanPham.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPham_CellContentClick);
            // 
            // grbThongTin
            // 
            this.grbThongTin.Controls.Add(this.guna2Button3);
            this.grbThongTin.Controls.Add(this.guna2Button2);
            this.grbThongTin.Controls.Add(this.guna2Button1);
            this.grbThongTin.Controls.Add(this.guna2Button5);
            this.grbThongTin.Controls.Add(this.chkTrangThai);
            this.grbThongTin.Controls.Add(this.picHinhAnh);
            this.grbThongTin.Controls.Add(this.btnChonAnh);
            this.grbThongTin.Controls.Add(this.cboLoai);
            this.grbThongTin.Controls.Add(this.txtMoTa);
            this.grbThongTin.Controls.Add(this.txtGia);
            this.grbThongTin.Controls.Add(this.txtTenSP);
            this.grbThongTin.Controls.Add(this.txtMaSP);
            this.grbThongTin.Controls.Add(this.lblMoTa);
            this.grbThongTin.Controls.Add(this.lblLoai);
            this.grbThongTin.Controls.Add(this.lblGia);
            this.grbThongTin.Controls.Add(this.lblTenSP);
            this.grbThongTin.Controls.Add(this.lblMaSP);
            this.grbThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbThongTin.Location = new System.Drawing.Point(642, 55);
            this.grbThongTin.Margin = new System.Windows.Forms.Padding(4);
            this.grbThongTin.Name = "grbThongTin";
            this.grbThongTin.Padding = new System.Windows.Forms.Padding(4);
            this.grbThongTin.Size = new System.Drawing.Size(504, 670);
            this.grbThongTin.TabIndex = 2;
            this.grbThongTin.TabStop = false;
            this.grbThongTin.Text = "Thông tin ";
            this.grbThongTin.Enter += new System.EventHandler(this.grbThongTin_Enter);
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
            this.guna2Button3.Location = new System.Drawing.Point(322, 584);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.Size = new System.Drawing.Size(127, 46);
            this.guna2Button3.TabIndex = 19;
            this.guna2Button3.Text = "Làm mới";
            this.guna2Button3.UseTransparentBackground = true;
            this.guna2Button3.Click += new System.EventHandler(this.guna2Button3_Click_1);
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
            this.guna2Button2.Location = new System.Drawing.Point(322, 522);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(127, 46);
            this.guna2Button2.TabIndex = 18;
            this.guna2Button2.Text = "Xóa";
            this.guna2Button2.UseTransparentBackground = true;
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click_1);
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
            this.guna2Button1.Location = new System.Drawing.Point(70, 584);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(141, 46);
            this.guna2Button1.TabIndex = 17;
            this.guna2Button1.Text = "Cập nhật";
            this.guna2Button1.UseTransparentBackground = true;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click_1);
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
            this.guna2Button5.Location = new System.Drawing.Point(70, 522);
            this.guna2Button5.Name = "guna2Button5";
            this.guna2Button5.Size = new System.Drawing.Size(141, 46);
            this.guna2Button5.TabIndex = 16;
            this.guna2Button5.Text = "Thêm";
            this.guna2Button5.UseTransparentBackground = true;
            this.guna2Button5.Click += new System.EventHandler(this.guna2Button5_Click);
            // 
            // chkTrangThai
            // 
            this.chkTrangThai.AutoSize = true;
            this.chkTrangThai.Checked = true;
            this.chkTrangThai.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrangThai.Location = new System.Drawing.Point(274, 130);
            this.chkTrangThai.Margin = new System.Windows.Forms.Padding(4);
            this.chkTrangThai.Name = "chkTrangThai";
            this.chkTrangThai.Size = new System.Drawing.Size(93, 24);
            this.chkTrangThai.TabIndex = 9;
            this.chkTrangThai.Text = "Còn bán";
            this.chkTrangThai.UseVisualStyleBackColor = true;
            // 
            // picHinhAnh
            // 
            this.picHinhAnh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picHinhAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picHinhAnh.Location = new System.Drawing.Point(18, 27);
            this.picHinhAnh.Margin = new System.Windows.Forms.Padding(4);
            this.picHinhAnh.Name = "picHinhAnh";
            this.picHinhAnh.Size = new System.Drawing.Size(212, 123);
            this.picHinhAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHinhAnh.TabIndex = 10;
            this.picHinhAnh.TabStop = false;
            // 
            // btnChonAnh
            // 
            this.btnChonAnh.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnChonAnh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChonAnh.ForeColor = System.Drawing.Color.White;
            this.btnChonAnh.Location = new System.Drawing.Point(265, 72);
            this.btnChonAnh.Margin = new System.Windows.Forms.Padding(4);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(157, 43);
            this.btnChonAnh.TabIndex = 11;
            this.btnChonAnh.Text = "Chọn ảnh";
            this.btnChonAnh.UseVisualStyleBackColor = false;
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);
            // 
            // cboLoai
            // 
            this.cboLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoai.FormattingEnabled = true;
            this.cboLoai.Location = new System.Drawing.Point(157, 345);
            this.cboLoai.Margin = new System.Windows.Forms.Padding(4);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(265, 28);
            this.cboLoai.TabIndex = 8;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(157, 399);
            this.txtMoTa.Margin = new System.Windows.Forms.Padding(4);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(265, 100);
            this.txtMoTa.TabIndex = 7;
            // 
            // txtGia
            // 
            this.txtGia.Location = new System.Drawing.Point(157, 285);
            this.txtGia.Margin = new System.Windows.Forms.Padding(4);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(265, 26);
            this.txtGia.TabIndex = 6;
            this.txtGia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGia_KeyPress);
            // 
            // txtTenSP
            // 
            this.txtTenSP.Location = new System.Drawing.Point(157, 230);
            this.txtTenSP.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(265, 26);
            this.txtTenSP.TabIndex = 5;
            // 
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(157, 177);
            this.txtMaSP.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.ReadOnly = true;
            this.txtMaSP.Size = new System.Drawing.Size(265, 26);
            this.txtMaSP.TabIndex = 4;
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Location = new System.Drawing.Point(74, 409);
            this.lblMoTa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(56, 20);
            this.lblMoTa.TabIndex = 3;
            this.lblMoTa.Text = "Mô tả:";
            // 
            // lblLoai
            // 
            this.lblLoai.AutoSize = true;
            this.lblLoai.Location = new System.Drawing.Point(74, 348);
            this.lblLoai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(46, 20);
            this.lblLoai.TabIndex = 2;
            this.lblLoai.Text = "Loại:";
            // 
            // lblGia
            // 
            this.lblGia.AutoSize = true;
            this.lblGia.Location = new System.Drawing.Point(80, 288);
            this.lblGia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(40, 20);
            this.lblGia.TabIndex = 1;
            this.lblGia.Text = "Giá:";
            // 
            // lblTenSP
            // 
            this.lblTenSP.AutoSize = true;
            this.lblTenSP.Location = new System.Drawing.Point(66, 236);
            this.lblTenSP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(69, 20);
            this.lblTenSP.TabIndex = 0;
            this.lblTenSP.Text = "Tên SP:";
            // 
            // lblMaSP
            // 
            this.lblMaSP.AutoSize = true;
            this.lblMaSP.Location = new System.Drawing.Point(66, 183);
            this.lblMaSP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaSP.Name = "lblMaSP";
            this.lblMaSP.Size = new System.Drawing.Size(64, 20);
            this.lblMaSP.TabIndex = 0;
            this.lblMaSP.Text = "Mã SP:";
            // 
            // guna2TextBox1
            // 
            this.guna2TextBox1.BorderRadius = 20;
            this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox1.DefaultText = "";
            this.guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.FillColor = System.Drawing.Color.WhiteSmoke;
            this.guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.IconLeft = ((System.Drawing.Image)(resources.GetObject("guna2TextBox1.IconLeft")));
            this.guna2TextBox1.Location = new System.Drawing.Point(12, 38);
            this.guna2TextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PlaceholderText = "";
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.Size = new System.Drawing.Size(613, 52);
            this.guna2TextBox1.TabIndex = 20;
            // 
            // frmSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.pngtree_chinese_style_ink_tea_tea_shop_home_picture_image_1031072;
            this.ClientSize = new System.Drawing.Size(1447, 849);
            this.Controls.Add(this.guna2TextBox1);
            this.Controls.Add(this.grbThongTin);
            this.Controls.Add(this.grbDanhSach);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSanPham";
            this.Text = "Quản lý sản phẩm";
            this.Load += new System.EventHandler(this.frmSanPham_Load);
            this.grbDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.grbThongTin.ResumeLayout(false);
            this.grbThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grbDanhSach;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.GroupBox grbThongTin;
        private System.Windows.Forms.Label lblMaSP;
        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.Label lblGia;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.ComboBox cboLoai;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.PictureBox picHinhAnh;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.CheckBox chkTrangThai;
        private Guna.UI2.WinForms.Guna2Button guna2Button5;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
    }
}
