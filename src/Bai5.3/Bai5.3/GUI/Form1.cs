using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Bai5._3.BUS; 

namespace Bai5._3
{
    public partial class Form1 : Form
    {
        private BanAnBUS banAnBUS = new BanAnBUS();
        private MonAnBUS monAnBUS = new MonAnBUS();
        private HoaDonBUS hoaDonBUS = new HoaDonBUS();

        private int currentTableId = -1;
        private string currentTableName = "";

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "HỆ THỐNG QUẢN LÝ QUÁN CAFE (POS CAFE SYSTEM)";

            LoadTableLayout();
            LoadCategories();
        }

        private void LoadTableLayout()
        {
            flpTableLayout.Controls.Clear();
            DataTable dtTables = banAnBUS.GetListBanAn(); 

            foreach (DataRow row in dtTables.Rows)
            {
                Button btn = new Button
                {
                    Width = 90,
                    Height = 80,
                    Text = $"{row["TenBan"]}\n({row["TrangThai"]})",
                    Tag = row["MaBan"],
                    Font = new Font("Segoe UI", 9, FontStyle.Bold)
                };

                string status = row["TrangThai"].ToString();
                btn.BackColor = (status == "Có khách") ? Color.LightCoral : Color.LightGreen;
                btn.Click += BtnTable_Click;

                flpTableLayout.Controls.Add(btn);
            }
        }
        private void BtnTable_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            currentTableId = Convert.ToInt32(btn.Tag);
            currentTableName = btn.Text.Split('\n')[0];
            lblSelectedTable.Text = $"Đang chọn: {currentTableName}";

            ShowBill(currentTableId);
        }
        private void ShowBill(int maBan)
        {
            DataTable dtBill = hoaDonBUS.GetBillByTable(maBan); 
            dgvBill.DataSource = dtBill;
            decimal totalPrice = 0;
            foreach (DataRow row in dtBill.Rows)
            {
                totalPrice += Convert.ToDecimal(row["ThanhTien"]);
            }
            txtTotalPrice.Text = totalPrice.ToString("N0") + " VNĐ";
        }
        private void LoadCategories()
        {
            DataTable dt = monAnBUS.GetListDanhMuc(); 
            cboCategory.DataSource = dt;
            cboCategory.DisplayMember = "TenDanhMuc";
            cboCategory.ValueMember = "MaDanhMuc";
            if (cboCategory.SelectedValue != null && cboCategory.SelectedValue is int)
            {
                int maDanhMuc = Convert.ToInt32(cboCategory.SelectedValue);
                cboFood.DataSource = monAnBUS.GetListMonAnByDanhMuc(maDanhMuc);
                cboFood.DisplayMember = "TenMon";
                cboFood.ValueMember = "MaMon";
            }
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategory.SelectedValue == null || !(cboCategory.SelectedValue is int)) return;

            int maDanhMuc = Convert.ToInt32(cboCategory.SelectedValue);
            cboFood.DataSource = monAnBUS.GetListMonAnByDanhMuc(maDanhMuc); 
            cboFood.DisplayMember = "TenMon";
            cboFood.ValueMember = "MaMon";
        }
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            if (currentTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn trên sơ đồ trước khi thêm món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboFood.SelectedValue == null) return;

            int maMon = Convert.ToInt32(cboFood.SelectedValue);
            int soLuong = (int)nmFoodCount.Value;

            hoaDonBUS.ThemMonVaoBan(currentTableId, maMon, soLuong);

            LoadTableLayout(); 
            ShowBill(currentTableId); 
        }
        private void btnPay_Click(object sender, EventArgs e)
        {
            if (currentTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn cần thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn thanh toán cho {currentTableName}?", "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                decimal tongTien = 0;
                bool isSuccess = hoaDonBUS.ThanhToan(currentTableId, out tongTien); 

                if (isSuccess)
                {
                    MessageBox.Show($"Thanh toán thành công cho {currentTableName}!\nTổng tiền: {tongTien:N0} VNĐ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTableLayout(); 
                    ShowBill(currentTableId); 
                }
                else
                {
                    MessageBox.Show("Bàn này hiện không có hóa đơn chưa thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void nmFoodCount_ValueChanged(object sender, EventArgs e) { }
        private void lblSelectedTable_Click(object sender, EventArgs e) { }
        private void cboFood_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dgvBill_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtTotalPrice_TextChanged(object sender, EventArgs e) { }
        private void flpTableLayout_Paint(object sender, PaintEventArgs e) { }
    }
}