namespace WindowsFormsApp1
{
    partial class frmTopping
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
            this.dgvTopping = new System.Windows.Forms.DataGridView();
            this.grbThongTin = new System.Windows.Forms.GroupBox();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.picHinhAnh = new System.Windows.Forms.PictureBox();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.txtTenTP = new System.Windows.Forms.TextBox();
            this.txtMaTP = new System.Windows.Forms.TextBox();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.lblGia = new System.Windows.Forms.Label();
            this.lblTenTP = new System.Windows.Forms.Label();
            this.lblMaTP = new System.Windows.Forms.Label();
            this.guna2Button5 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.grbDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopping)).BeginInit();
            this.grbThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).BeginInit();
            this.SuspendLayout();
            // 
            // grbDanhSach
            // 
            this.grbDanhSach.Controls.Add(this.dgvTopping);
            this.grbDanhSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDanhSach.Location = new System.Drawing.Point(13, 12);
            this.grbDanhSach.Margin = new System.Windows.Forms.Padding(4);
            this.grbDanhSach.Name = "grbDanhSach";
            this.grbDanhSach.Padding = new System.Windows.Forms.Padding(4);
            this.grbDanhSach.Size = new System.Drawing.Size(733, 677);
            this.grbDanhSach.TabIndex = 0;
            this.grbDanhSach.TabStop = false;
            this.grbDanhSach.Text = "Danh sách topping";
            // 
            // dgvTopping
            // 
            this.dgvTopping.AllowUserToAddRows = false;
            this.dgvTopping.AllowUserToDeleteRows = false;
            this.dgvTopping.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopping.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopping.Location = new System.Drawing.Point(4, 23);
            this.dgvTopping.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTopping.MultiSelect = false;
            this.dgvTopping.Name = "dgvTopping";
            this.dgvTopping.ReadOnly = true;
            this.dgvTopping.RowHeadersVisible = false;
            this.dgvTopping.RowHeadersWidth = 51;
            this.dgvTopping.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopping.Size = new System.Drawing.Size(725, 650);
            this.dgvTopping.TabIndex = 0;
            this.dgvTopping.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTopping_CellClick);
            // 
            // grbThongTin
            // 
            this.grbThongTin.Controls.Add(this.guna2Button3);
            this.grbThongTin.Controls.Add(this.picHinhAnh);
            this.grbThongTin.Controls.Add(this.btnChonAnh);
            this.grbThongTin.Controls.Add(this.guna2Button2);
            this.grbThongTin.Controls.Add(this.txtMoTa);
            this.grbThongTin.Controls.Add(this.txtGia);
            this.grbThongTin.Controls.Add(this.txtTenTP);
            this.grbThongTin.Controls.Add(this.txtMaTP);
            this.grbThongTin.Controls.Add(this.lblMoTa);
            this.grbThongTin.Controls.Add(this.lblGia);
            this.grbThongTin.Controls.Add(this.lblTenTP);
            this.grbThongTin.Controls.Add(this.lblMaTP);
            this.grbThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbThongTin.Location = new System.Drawing.Point(750, 13);
            this.grbThongTin.Margin = new System.Windows.Forms.Padding(4);
            this.grbThongTin.Name = "grbThongTin";
            this.grbThongTin.Padding = new System.Windows.Forms.Padding(4);
            this.grbThongTin.Size = new System.Drawing.Size(442, 677);
            this.grbThongTin.TabIndex = 1;
            this.grbThongTin.TabStop = false;
            this.grbThongTin.Text = "Thông tin topping";
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
            this.guna2Button3.Location = new System.Drawing.Point(243, 615);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.Size = new System.Drawing.Size(127, 46);
            this.guna2Button3.TabIndex = 22;
            this.guna2Button3.Text = "Làm mới";
            this.guna2Button3.UseTransparentBackground = true;
            this.guna2Button3.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // picHinhAnh
            // 
            this.picHinhAnh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picHinhAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picHinhAnh.Location = new System.Drawing.Point(30, 87);
            this.picHinhAnh.Margin = new System.Windows.Forms.Padding(4);
            this.picHinhAnh.Name = "picHinhAnh";
            this.picHinhAnh.Size = new System.Drawing.Size(194, 123);
            this.picHinhAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHinhAnh.TabIndex = 12;
            this.picHinhAnh.TabStop = false;
            // 
            // btnChonAnh
            // 
            this.btnChonAnh.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnChonAnh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChonAnh.ForeColor = System.Drawing.Color.White;
            this.btnChonAnh.Location = new System.Drawing.Point(232, 133);
            this.btnChonAnh.Margin = new System.Windows.Forms.Padding(4);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(122, 43);
            this.btnChonAnh.TabIndex = 13;
            this.btnChonAnh.Text = "Chọn ảnh";
            this.btnChonAnh.UseVisualStyleBackColor = false;
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);
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
            this.guna2Button2.Location = new System.Drawing.Point(243, 534);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(127, 46);
            this.guna2Button2.TabIndex = 20;
            this.guna2Button2.Text = "Xóa";
            this.guna2Button2.UseTransparentBackground = true;
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(102, 384);
            this.txtMoTa.Margin = new System.Windows.Forms.Padding(4);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(237, 81);
            this.txtMoTa.TabIndex = 7;
            // 
            // txtGia
            // 
            this.txtGia.Location = new System.Drawing.Point(102, 347);
            this.txtGia.Margin = new System.Windows.Forms.Padding(4);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(237, 26);
            this.txtGia.TabIndex = 6;
            this.txtGia.TextChanged += new System.EventHandler(this.txtGia_TextChanged);
            this.txtGia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGia_KeyPress);
            // 
            // txtTenTP
            // 
            this.txtTenTP.Location = new System.Drawing.Point(102, 303);
            this.txtTenTP.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenTP.Name = "txtTenTP";
            this.txtTenTP.Size = new System.Drawing.Size(237, 26);
            this.txtTenTP.TabIndex = 5;
            // 
            // txtMaTP
            // 
            this.txtMaTP.Location = new System.Drawing.Point(102, 256);
            this.txtMaTP.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaTP.Name = "txtMaTP";
            this.txtMaTP.ReadOnly = true;
            this.txtMaTP.Size = new System.Drawing.Size(237, 26);
            this.txtMaTP.TabIndex = 4;
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Location = new System.Drawing.Point(31, 387);
            this.lblMoTa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(56, 20);
            this.lblMoTa.TabIndex = 3;
            this.lblMoTa.Text = "Mô tả:";
            // 
            // lblGia
            // 
            this.lblGia.AutoSize = true;
            this.lblGia.Location = new System.Drawing.Point(31, 353);
            this.lblGia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(40, 20);
            this.lblGia.TabIndex = 2;
            this.lblGia.Text = "Giá:";
            // 
            // lblTenTP
            // 
            this.lblTenTP.AutoSize = true;
            this.lblTenTP.Location = new System.Drawing.Point(26, 309);
            this.lblTenTP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTenTP.Name = "lblTenTP";
            this.lblTenTP.Size = new System.Drawing.Size(68, 20);
            this.lblTenTP.TabIndex = 1;
            this.lblTenTP.Text = "Tên TP:";
            // 
            // lblMaTP
            // 
            this.lblMaTP.AutoSize = true;
            this.lblMaTP.Location = new System.Drawing.Point(26, 262);
            this.lblMaTP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaTP.Name = "lblMaTP";
            this.lblMaTP.Size = new System.Drawing.Size(63, 20);
            this.lblMaTP.TabIndex = 0;
            this.lblMaTP.Text = "Mã TP:";
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
            this.guna2Button5.Location = new System.Drawing.Point(780, 547);
            this.guna2Button5.Name = "guna2Button5";
            this.guna2Button5.Size = new System.Drawing.Size(141, 46);
            this.guna2Button5.TabIndex = 18;
            this.guna2Button5.Text = "Thêm";
            this.guna2Button5.UseTransparentBackground = true;
            this.guna2Button5.Click += new System.EventHandler(this.guna2Button5_Click);
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
            this.guna2Button1.Location = new System.Drawing.Point(780, 628);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(141, 46);
            this.guna2Button1.TabIndex = 21;
            this.guna2Button1.Text = "Cập nhật";
            this.guna2Button1.UseTransparentBackground = true;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // frmTopping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.pngtree_chinese_style_ink_tea_tea_shop_home_picture_image_1031072;
            this.ClientSize = new System.Drawing.Size(1252, 708);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.guna2Button5);
            this.Controls.Add(this.grbThongTin);
            this.Controls.Add(this.grbDanhSach);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTopping";
            this.Text = "Quản lý topping";
            this.Load += new System.EventHandler(this.frmTopping_Load);
            this.grbDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopping)).EndInit();
            this.grbThongTin.ResumeLayout(false);
            this.grbThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbDanhSach;
        private System.Windows.Forms.DataGridView dgvTopping;
        private System.Windows.Forms.GroupBox grbThongTin;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.TextBox txtTenTP;
        private System.Windows.Forms.TextBox txtMaTP;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblGia;
        private System.Windows.Forms.Label lblTenTP;
        private System.Windows.Forms.Label lblMaTP;
        private System.Windows.Forms.PictureBox picHinhAnh;
        private System.Windows.Forms.Button btnChonAnh;
        private Guna.UI2.WinForms.Guna2Button guna2Button5;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
    }
}
