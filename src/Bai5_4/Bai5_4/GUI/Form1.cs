using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bai5_4.BUS;
using Bai5_4.DTO;

namespace Bai5_4
{
    public partial class Form1 : Form
    {
        private readonly HotelBUS bus = new HotelBUS();
        private DataTable dtRooms;
        private string selectedRoom = "";

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitFilters();
            LoadServices();
            LoadRoomList();
        }

        #region 1. Khởi tạo bộ lọc & Nạp danh sách phòng (DataView / Disconnected)
        private void InitFilters()
        {
            cboFilterType.Items.Clear();
            cboFilterType.Items.AddRange(new object[] { "-- Tất cả loại --", "Đơn", "Đôi", "VIP" });
            cboFilterType.SelectedIndex = 0;

            cboFilterStatus.Items.Clear();
            cboFilterStatus.Items.AddRange(new object[] { "-- Tất cả trạng thái --", "Trống", "Đang ở", "Đang dọn dẹp" });
            cboFilterStatus.SelectedIndex = 0;
        }

        public void LoadRoomList()
        {
            dtRooms = bus.GetAllRooms();
            ApplyRoomFilter();
        }

        private void ApplyRoomFilter()
        {
            if (dtRooms == null) return;

            DataView dv = dtRooms.DefaultView;
            string filter = "1=1";

            if (cboFilterType.SelectedIndex > 0)
                filter += $" AND LoaiPhong = '{cboFilterType.SelectedItem}'";

            if (cboFilterStatus.SelectedIndex > 0)
                filter += $" AND TrangThai = '{cboFilterStatus.SelectedItem}'";

            dv.RowFilter = filter;
            dgvRooms.DataSource = dv;

            // Đổi tiêu đề hiển thị cột nếu cần
            if (dgvRooms.Columns.Contains("SoPhong")) dgvRooms.Columns["SoPhong"].HeaderText = "Số phòng";
            if (dgvRooms.Columns.Contains("LoaiPhong")) dgvRooms.Columns["LoaiPhong"].HeaderText = "Loại phòng";
            if (dgvRooms.Columns.Contains("GiaTheoGio"))
            {
                dgvRooms.Columns["GiaTheoGio"].HeaderText = "Giá/Giờ";
                dgvRooms.Columns["GiaTheoGio"].DefaultCellStyle.Format = "N0";
            }
            if (dgvRooms.Columns.Contains("TrangThai")) dgvRooms.Columns["TrangThai"].HeaderText = "Trạng thái";
        }

        private void cboFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyRoomFilter();
        }

        private void cboFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyRoomFilter();
        }
        #endregion

        #region 2. Chọn phòng trên bảng (dgvRooms)
        private void dgvRooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HandleRoomSelection(e.RowIndex);
        }

        // Hỗ trợ chọn dòng ở mọi vùng click
        private void dgvRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HandleRoomSelection(e.RowIndex);
        }

        private void HandleRoomSelection(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgvRooms.Rows.Count) return;

            DataGridViewRow row = dgvRooms.Rows[rowIndex];
            if (row.Cells["SoPhong"].Value == null) return;

            selectedRoom = row.Cells["SoPhong"].Value.ToString();
            string status = row.Cells["TrangThai"].Value.ToString();

            lblSelectedRoom.Text = $"Đang chọn: Phòng {selectedRoom} ({status})";

            if (status == "Đang ở")
            {
                LoadActiveRoomDetails(selectedRoom);
            }
            else
            {
                dgvServices.DataSource = null;
                lblCheckoutDetail.Text = "Thời gian: 0 giờ (0 đ) | Dịch vụ: 0 đ";
                lblCheckoutTotal.Text = "0 VNĐ";
            }
        }

        private void LoadActiveRoomDetails(string room)
        {
            int ticketID = bus.GetActiveTicketIDByRoom(room);
            if (ticketID != -1)
            {
                // Nạp chi tiết dịch vụ
                DataTable dtServices = bus.GetServiceDetailsByTicket(ticketID);
                dgvServices.DataSource = dtServices;

                if (dgvServices.Columns.Contains("TenDV")) dgvServices.Columns["TenDV"].HeaderText = "Tên dịch vụ";
                if (dgvServices.Columns.Contains("SoLuong")) dgvServices.Columns["SoLuong"].HeaderText = "Số lượng";
                if (dgvServices.Columns.Contains("DonGia"))
                {
                    dgvServices.Columns["DonGia"].HeaderText = "Đơn giá";
                    dgvServices.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                }
                if (dgvServices.Columns.Contains("ThanhTien"))
                {
                    dgvServices.Columns["ThanhTien"].HeaderText = "Thành tiền";
                    dgvServices.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                }

                // Cập nhật chi tiết tiền ở Tab 3
                bus.CalculateTotal(room, out _, out double soGio, out decimal tienPhong, out decimal tienDV);
                lblCheckoutDetail.Text = $"Thời gian: {soGio} giờ ({tienPhong:N0} đ) | Dịch vụ: {tienDV:N0} đ";
                lblCheckoutTotal.Text = $"{(tienPhong + tienDV):N0} VNĐ";
            }
        }
        #endregion

        #region 3. Tab 1: Check-in & Tra cứu CCCD
        private void btnSearchCCCD_Click(object sender, EventArgs e)
        {
            string cccd = txtCCCD.Text.Trim();
            if (string.IsNullOrEmpty(cccd))
            {
                MessageBox.Show("Vui lòng nhập số CCCD để tra cứu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KhachHangDTO kh = bus.GetCustomerByCCCD(cccd);
            if (kh != null)
            {
                txtCustomerName.Text = kh.HoTen;
                txtPhone.Text = kh.SoDienThoai;
                MessageBox.Show($"Tìm thấy khách hàng quen: {kh.HoTen}!", "Thông tin khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Khách hàng mới! Vui lòng nhập Họ tên và Số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCustomerName.Clear();
                txtPhone.Clear();
                txtCustomerName.Focus();
            }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedRoom))
            {
                MessageBox.Show("Vui lòng chọn một phòng trên danh sách trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = txtCustomerName.Text.Trim();
            string cccd = txtCCCD.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(cccd))
            {
                MessageBox.Show("Họ tên và CCCD không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bus.PerformCheckIn(selectedRoom, name, cccd, phone))
            {
                MessageBox.Show($"Check-in phòng {selectedRoom} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCustomerName.Clear();
                txtCCCD.Clear();
                txtPhone.Clear();
                LoadRoomList();
            }
            else
            {
                MessageBox.Show("Check-in thất bại! Phòng này có thể đang bận hoặc thông tin chưa hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 4. Tab 2: Gọi dịch vụ
        private void LoadServices()
        {
            cboService.DataSource = bus.GetAllServices();
            cboService.DisplayMember = "TenDV";
            cboService.ValueMember = "MaDV";
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedRoom))
            {
                MessageBox.Show("Vui lòng chọn phòng cần gọi dịch vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int ticketID = bus.GetActiveTicketIDByRoom(selectedRoom);
            if (ticketID == -1)
            {
                MessageBox.Show("Phòng này hiện chưa có khách lưu trú để gọi dịch vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboService.SelectedValue == null) return;
            int maDV = Convert.ToInt32(cboService.SelectedValue);
            int soLuong = (int)nmServiceCount.Value;

            if (bus.OrderService(ticketID, maDV, soLuong))
            {
                MessageBox.Show("Thêm dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadActiveRoomDetails(selectedRoom);
            }
        }
        #endregion

        #region 5. Tab 3: Check-out & Dọn phòng
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedRoom))
            {
                MessageBox.Show("Vui lòng chọn phòng cần trả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal total = bus.CalculateTotal(selectedRoom, out int ticketID, out double soGio, out decimal tienPhong, out decimal tienDV);
            if (ticketID == -1)
            {
                MessageBox.Show("Phòng này chưa có phiếu đặt phòng hoạt động!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Xác nhận trả phòng {selectedRoom}?\n" +
                $"- Thời gian ở: {soGio} giờ ({tienPhong:N0} đ)\n" +
                $"- Tiền dịch vụ: {tienDV:N0} đ\n" +
                $"-----------------------------\n" +
                $"Tổng cộng: {total:N0} VNĐ",
                "Xác nhận thanh toán & Trả phòng",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                if (bus.PerformCheckOut(ticketID, selectedRoom, total))
                {
                    MessageBox.Show("Thanh toán thành công! Trạng thái phòng chuyển sang 'Đang dọn dẹp'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRoomList();
                    dgvServices.DataSource = null;
                    lblCheckoutDetail.Text = "Thời gian: 0 giờ (0 đ) | Dịch vụ: 0 đ";
                    lblCheckoutTotal.Text = "0 VNĐ";
                }
                else
                {
                    MessageBox.Show("Thanh toán thất bại, giao dịch đã được khôi phục!", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCleanRoom_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedRoom))
            {
                MessageBox.Show("Vui lòng chọn một phòng cần đánh dấu đã dọn xong!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bus.CleanRoomComplete(selectedRoom);
            MessageBox.Show($"Phòng {selectedRoom} đã được dọn sạch và chuyển về trạng thái 'Trống'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadRoomList();
        }
        #endregion

        #region Các sự kiện giao diện phụ (Tránh lỗi liên kết Designer)
        private void lblSelectedRoom_Click(object sender, EventArgs e) { }
        private void tabPage1_Click(object sender, EventArgs e) { }
        private void txtCCCD_TextChanged(object sender, EventArgs e) { }
        private void txtCustomerName_TextChanged(object sender, EventArgs e) { }
        private void txtPhone_TextChanged(object sender, EventArgs e) { }
        private void cboService_SelectedIndexChanged(object sender, EventArgs e) { }
        private void nmServiceCount_ValueChanged(object sender, EventArgs e) { }
        private void dgvServices_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void lblCheckoutDetail_Click(object sender, EventArgs e) { }
        private void lblCheckoutTotal_Click(object sender, EventArgs e) { }
        #endregion
    }
}