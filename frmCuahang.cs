using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class frmCuahang : Form
    {
        private List<StoreData> allStores;
        private Panel normalPanel;

        public frmCuahang()
        {
            InitializeComponent();
            LoadData();
            this.Load += Form5_Load;
            this.Resize += (s, e) => { RefreshLayout(); };
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            normalPanel = new Panel();
            normalPanel.AutoScroll = true;
            normalPanel.BackColor = Color.White;
            normalPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            guna2Button4.HoverState.FillColor = Color.FromArgb(255, 228, 181);
            guna2Button5.HoverState.FillColor = Color.FromArgb(255, 228, 181);
            guna2Button6.HoverState.FillColor = Color.FromArgb(255, 228, 181);

            // 2. Đặt vị trí Panel
            normalPanel.Location = new Point(270,0);

            // 3. Tăng chiều cao (Height): Trừ hao ít hơn ở phía dưới (chỉ trừ 10px thay vì 50px)
            // Điều này giúp Panel kéo dài xuống tận đáy Form Trang Chủ
            normalPanel.Size = new Size(this.Width - 60, this.Height  +10);

            this.Controls.Add(normalPanel);
            normalPanel.BringToFront();

            LoadStoresToPanel(allStores);
        }

        private void RefreshLayout()
        {
            if (normalPanel != null)
            {
                int newItemWidth = normalPanel.Width - 25;
                foreach (Control ctrl in normalPanel.Controls)
                {
                    if (ctrl is StoreItem) ctrl.Width = newItemWidth;
                }
            }
        }

        private void LoadData()
        {
            allStores = new List<StoreData>
            {
                new StoreData { Name = "GO SAGO 66 Phú Mỹ", Address = "66 Phú Mỹ, Nam Từ Liêm, Hà Nội", OperatingHours = "9 giờ 00 - 22 giờ 00", PhoneNumber = "0846.095.147", MapUrl = "https://goo.gl/maps/1" },
                new StoreData { Name = "GO SAGO 31 Ngõ 8 Lê Quang Đạo", Address = "Số 31 Ngõ 8 Lê Quang Đạo, Nam Từ Liêm, Hà Nội", OperatingHours = "9 giờ 00 - 22 giờ 00", PhoneNumber = "0846.409.427", MapUrl = "https://goo.gl/maps/2" },
                new StoreData { Name = "GO SAGO 35 Phú Đô", Address = "35 Phú Đô, Mễ Trì, Nam Từ Liêm, Hà Nội", OperatingHours = "9 giờ 00 - 22 giờ 00", PhoneNumber = "0849.346.702", MapUrl = "https://goo.gl/maps/3" },
                new StoreData { Name = "GO SAGO 29 Nguyễn An Ninh", Address = "29 Nguyễn An Ninh, Tương Mai, Hoàng Mai, Hà Nội", OperatingHours = "9 giờ 00 - 22 giờ 00", PhoneNumber = "0846.363.271", MapUrl = "https://goo.gl/maps/4" }
            };
        }

        private void LoadStoresToPanel(List<StoreData> storesToDisplay)
        {
            normalPanel.Controls.Clear();
            int currentY = 0;
            int itemWidth = normalPanel.Width - 25;

            foreach (var store in storesToDisplay)
            {
                StoreItem itemUI = new StoreItem(store);
                itemUI.Width = itemWidth;
                itemUI.Location = new Point(0, currentY);
                itemUI.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

                normalPanel.Controls.Add(itemUI);

                // Giữ khoảng cách giữa các hàng vừa phải để hiện được nhiều hàng hơn cùng lúc
                currentY += itemUI.Height + 10;
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = guna2TextBox1.Text.Trim().ToLower();
            var filtered = allStores.Where(s => s.Name.ToLower().Contains(keyword) || s.Address.ToLower().Contains(keyword)).ToList();
            LoadStoresToPanel(filtered);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            frmTrangchu f2 = new frmTrangchu();
            //f2.FormClosed += (s, args) => this.Show();
            f2.Show();
            this.Hide();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load_1(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            frmKhuyenmai fs=new frmKhuyenmai();
            fs.Show();
            this.Hide();
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
    }

    public class StoreItem : UserControl
    {
        public StoreItem(StoreData store)
        {
            this.Height = 160;
            this.BackColor = Color.White;

            Label name = new Label { Text = "🧋 " + store.Name, Font = new Font("Segoe UI", 13, FontStyle.Bold), Location = new Point(20, 15), AutoSize = true };
            Label addr = new Label { Text = "📍 Địa chỉ: " + store.Address, Font = new Font("Segoe UI", 10), Location = new Point(25, 50), AutoSize = true, ForeColor = Color.Gray };
            Label time = new Label { Text = "⏰ Hoạt động: " + store.OperatingHours, Font = new Font("Segoe UI", 10), Location = new Point(25, 80), AutoSize = true, ForeColor = Color.Gray };
            Label phone = new Label { Text = "📞 Hotline: " + store.PhoneNumber, Font = new Font("Segoe UI", 10), Location = new Point(25, 110), AutoSize = true, ForeColor = Color.Gray };

            LinkLabel map = new LinkLabel { Text = "XEM BẢN ĐỒ 📍", Font = new Font("Segoe UI", 10, FontStyle.Bold), AutoSize = true, LinkColor = Color.DarkBlue, Anchor = AnchorStyles.Top | AnchorStyles.Right };

            this.Controls.AddRange(new Control[] { name, addr, time, phone, map });

            this.Resize += (s, e) => {
                map.Location = new Point(this.Width - map.Width - 20, 110);
            };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen p = new Pen(Color.Gainsboro, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash })
            {
                e.Graphics.DrawLine(p, 10, Height - 1, Width - 10, Height - 1);
            }
        }
    }

    public class StoreData
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string OperatingHours { get; set; }
        public string PhoneNumber { get; set; }
        public string MapUrl { get; set; }
    }
}