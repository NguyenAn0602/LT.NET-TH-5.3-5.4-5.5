using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bai5_3.BUS;

namespace Bai5_3
{
    public partial class Form1 : Form
    {
        private readonly CafeBUS bus = new CafeBUS();
        private int currentTableID = -1;
        private string currentTableName = "";

        public Form1()
        {
            InitializeComponent();

            // Nạp dữ liệu khi mở Form
            LoadCategories();
            LoadTableLayout();
        }

        #region 1. Hiển thị sơ đồ bàn động (Button)
        public void LoadTableLayout()
        {
            flpTable.Controls.Clear();
            DataTable dt = bus.GetTableList();

            foreach (DataRow row in dt.Rows)
            {
                int maBan = Convert.ToInt32(row["MaBan"]);
                string tenBan = row["TenBan"].ToString();
                string trangThai = row["TrangThai"].ToString();

                Button btn = new Button
                {
                    Width = 100,
                    Height = 80,
                    Text = $"{tenBan}\n({trangThai})",
                    Tag = maBan,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    Margin = new Padding(8)
                };

                // Trống -> Xanh lá, Có khách -> Đỏ nhạt
                if (trangThai == "Trống")
                {
                    btn.BackColor = Color.LightGreen;
                }
                else
                {
                    btn.BackColor = Color.LightCoral;
                }

                btn.Click += BtnTable_Click;
                flpTable.Controls.Add(btn);
            }
        }

        // Chọn một bàn trên sơ đồ
        private void BtnTable_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            currentTableID = (int)btn.Tag;
            currentTableName = btn.Text.Split('\n')[0];
            this.Text = $"Quản lý POS Cafe - Đang chọn: {currentTableName}";

            ShowBill(currentTableID);
        }

        private void ShowBill(int maBan)
        {
            DataTable dt = bus.GetBillDetailsByTableID(maBan);
            dgvBill.DataSource = dt;

            // Đổi tiêu đề cột DataGridView cho đẹp
            if (dgvBill.Columns.Contains("TenMon")) dgvBill.Columns["TenMon"].HeaderText = "Tên món";
            if (dgvBill.Columns.Contains("SoLuong")) dgvBill.Columns["SoLuong"].HeaderText = "Số lượng";
            if (dgvBill.Columns.Contains("DonGia"))
            {
                dgvBill.Columns["DonGia"].HeaderText = "Đơn giá";
                dgvBill.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            }
            if (dgvBill.Columns.Contains("ThanhTien"))
            {
                dgvBill.Columns["ThanhTien"].HeaderText = "Thành tiền";
                dgvBill.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            }

            decimal total = 0;
            foreach (DataRow row in dt.Rows)
            {
                total += Convert.ToDecimal(row["ThanhTien"]);
            }
            lblTotal.Text = $"{total:N0} VNĐ";
            lblTotal.Tag = total;
        }
        #endregion

        #region 2. Nạp Danh mục & Thực đơn món
        private void LoadCategories()
        {
            DataTable dtCategory = bus.GetCategoryList();
            cboCategory.DataSource = dtCategory;
            cboCategory.DisplayMember = "TenDanhMuc";
            cboCategory.ValueMember = "MaDanhMuc";
        }

        // Đổi danh mục -> Tải lại danh sách món tương ứng
        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategory.SelectedValue != null && int.TryParse(cboCategory.SelectedValue.ToString(), out int maDanhMuc))
            {
                DataTable dtFood = bus.GetFoodByCategoryID(maDanhMuc);

                // Hỗ trợ cả 2 tên ComboBox nếu trên giao diện chưa đổi tên: cboFood hoặc comboBox1
                ComboBox targetComboBox = null;
                var fieldFood = this.GetType().GetField("cboFood", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                if (fieldFood != null)
                {
                    targetComboBox = fieldFood.GetValue(this) as ComboBox;
                }
                if (targetComboBox == null)
                {
                    targetComboBox = comboBox1;
                }

                if (targetComboBox != null)
                {
                    targetComboBox.DataSource = dtFood;
                    targetComboBox.DisplayMember = "TenMon";
                    targetComboBox.ValueMember = "MaMon";
                }
            }
        }
        #endregion

        #region 3. Thêm món (Gọi món)
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            if (currentTableID == -1)
            {
                MessageBox.Show("Vui lòng nhấp chọn một bàn trên sơ đồ trước khi thêm món!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy ComboBox món (cboFood hoặc comboBox1)
            ComboBox targetComboBox = null;
            var fieldFood = this.GetType().GetField("cboFood", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (fieldFood != null)
            {
                targetComboBox = fieldFood.GetValue(this) as ComboBox;
            }
            if (targetComboBox == null)
            {
                targetComboBox = comboBox1;
            }

            if (targetComboBox == null || targetComboBox.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn món ăn cần thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maMon = Convert.ToInt32(targetComboBox.SelectedValue);
            int soLuong = (int)nmFoodCount.Value;

            DataRowView rowView = targetComboBox.SelectedItem as DataRowView;
            if (rowView == null) return;
            decimal donGia = Convert.ToDecimal(rowView["DonGia"]);

            // Gọi qua tầng BUS
            bool success = bus.OrderFood(currentTableID, maMon, soLuong, donGia);
            if (success)
            {
                ShowBill(currentTableID);
                LoadTableLayout(); // Cập nhật lại màu bàn (chuyển sang đỏ/Có khách)
            }
        }
        #endregion

        #region 4. Thanh toán (SqlTransaction)
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (currentTableID == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn cần thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal total = lblTotal.Tag != null ? (decimal)lblTotal.Tag : 0;
            if (total == 0)
            {
                MessageBox.Show("Bàn này hiện chưa có món để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Xác nhận thanh toán cho {currentTableName}?\nTổng số tiền: {total:N0} VNĐ",
                "Xác nhận thanh toán",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                if (bus.CheckOut(currentTableID, total))
                {
                    MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowBill(currentTableID);
                    LoadTableLayout(); // Bàn chuyển về màu xanh (Trống)
                }
                else
                {
                    MessageBox.Show("Thanh toán thất bại, giao dịch đã được khôi phục!", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Các sự kiện giao diện phụ
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void nmFoodCount_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void flpTable_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion
    }
}