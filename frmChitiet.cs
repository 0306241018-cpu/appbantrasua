using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using static WindowsFormsApp2.frmTrangchu;

namespace WindowsFormsApp2
{
    public partial class frmChitiet : Form
    {
        // ===== BIẾN NHẬN DỮ LIỆU =====
        string _ten;
        int _gia;
        Image _hinh;
        string _mota;

        
        List<SanPham>gioHang ;
        List<SanPham> _ds = new List<SanPham>();
        // ===== CONSTRUCTOR =====
        public frmChitiet(string ten, int gia, Image hinh, string mota, List<SanPham> gioHang)
        {
            InitializeComponent();

            // Nhận dữ liệu
            this._ten = ten;
            this._gia = gia;
            this._hinh = hinh;
            this._mota = mota;

            // Nhận giỏ hàng
            this.gioHang = gioHang;
            this._ds = gioHang;

            // Load UI chi tiết (nếu có)
            LoadUI();

          
        }


        //public class BillItem
        //{
        //    public string Name { get; set; }
        //    public int Quantity { get; set; }
        //    public decimal Price { get; set; }
        //}
        //List<BillItem> bill = new List<BillItem>();
        //List<BillItem> gioHang = new List<BillItem>();

        // ===== LOAD UI =====
        private void LoadUI()
        {
            this.BackColor = Color.White;

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Padding = new Padding(10);
            this.WindowState = FormWindowState.Maximized;
            flowLayoutPanel1.Controls.Add(CreateCard(_ten, _gia, _hinh, _mota));
        }

        // ===== TẠO CARD =====
        private Control CreateCard(string ten, int gia, Image hinh, string mota)
        {
            Panel card = new Panel();
            card.Width = 950;
            card.Height = 650;
            card.BackColor = Color.White;
            card.Margin = new Padding(10);
            card.BorderStyle = BorderStyle.FixedSingle;

            // ẢNH
            PictureBox pic = new PictureBox();
            pic.Size = new Size(150, 150);
            pic.Location = new Point(10, 20);
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Image = hinh;

            // TÊN
            Label lblTen = new Label();
            lblTen.Text = ten;
            lblTen.Location = new Point(180, 20);
            lblTen.AutoSize = true;
            lblTen.Font = new Font("Segoe UI", 14, FontStyle.Bold);

            // GIÁ
            Label lblGia = new Label();
            lblGia.Text = gia.ToString("N0") + " VND";
            lblGia.Location = new Point(180, 60);
            lblGia.AutoSize = true;
            lblGia.Font = new Font("Segoe UI", 12);
            lblGia.ForeColor = Color.Red;

            // MÔ TẢ
            Label lblMoTa = new Label();
            lblMoTa.Text = mota;
            lblMoTa.Location = new Point(180, 100);
            lblMoTa.Size = new Size(500, 500);
            lblMoTa.Font = new Font("Segoe UI", 10);
            lblMoTa.ForeColor = Color.Gray;

            // ADD
            card.Controls.Add(pic);
            card.Controls.Add(lblTen);
            card.Controls.Add(lblGia);
            card.Controls.Add(lblMoTa);
            lblMoTa.AutoSize = false;
            return card;
        }

        // ===== QUAY LẠI =====
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmTrangchu f2 = new frmTrangchu();
            f2.FormClosed += (s, args) => this.Show();
            f2.Show();
            this.Hide();

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            guna2Button1.HoverState.FillColor = Color.FromArgb(255, 228, 181);
            guna2Button2.HoverState.FillColor = Color.FromArgb(255, 228, 181);
            guna2Button3.HoverState.FillColor = Color.FromArgb(255, 228, 181);
            guna2TextBox1.BorderRadius = 25;
            guna2TextBox1.PlaceholderText = "Tìm kiếm trà sữa ưa thích";

            guna2HtmlLabel1.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy");

        }



  



        private void guna2Button1_Click_2(object sender, EventArgs e)
        {
            frmTrangchu f2 = new frmTrangchu();
            //f2.FormClosed += (s, args) => this.Show();
            f2.Show();
            this.Hide();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            //listView1 = new ListView();
            //listView1.View = View.Details;
            //listView1.FullRowSelect = true;
            //listView1.GridLines = true;
            //listView1.Location = new Point(30, 80);
            //listView1.Size = new Size(420, 300);
            //listView1.BackColor = Color.FromArgb(240, 235, 200);
            //listView1.Columns.Add("Tên món", 150);
            //listView1.Columns.Add("SL", 50);
            //listView1.Columns.Add("Giá", 80);
            //listView1.Columns.Add("Tổng", 100);

            //this.Controls.Add(listView1);

        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void CapNhatDanhSach(List<SanPham> dsMoi)
        {
            this._ds = dsMoi; // Nhận danh sách mới nhất
         
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            frmCuahang frm5 = new frmCuahang();
            frm5.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            frmKhuyenmai frm5 = new frmKhuyenmai();
            frm5.Show();
            this.Hide();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}