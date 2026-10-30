using System;
using System.Data;
using Bai5_4.DAL;
using Bai5_4.DTO;

namespace Bai5_4.BUS
{
    public class HotelBUS
    {
        private HotelDAL dal = new HotelDAL();

        public DataTable GetAllRooms() => dal.GetAllRooms();
        public DataTable GetAllServices() => dal.GetAllServices();
        public KhachHangDTO GetCustomerByCCCD(string cccd) => dal.GetCustomerByCCCD(cccd);
        public int GetActiveTicketIDByRoom(string soPhong) => dal.GetActiveTicketIDByRoom(soPhong);
        public DataTable GetServiceDetailsByTicket(int maPhieu) => dal.GetServiceDetailsByTicket(maPhieu);
        public DataTable GetRoomCheckoutInfo(string soPhong) => dal.GetRoomCheckoutInfo(soPhong);
        public void CleanRoomComplete(string soPhong) => dal.CleanRoomComplete(soPhong);

        // Nghiệp vụ Check-in
        public bool PerformCheckIn(string soPhong, string hoTen, string cccd, string sdt)
        {
            if (string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(cccd)) return false;

            KhachHangDTO kh = dal.GetCustomerByCCCD(cccd);
            int maKH;
            if (kh == null)
            {
                maKH = dal.InsertCustomer(new KhachHangDTO(0, hoTen, cccd, sdt));
            }
            else
            {
                maKH = kh.MaKH;
            }

            return dal.CheckIn(soPhong, maKH);
        }

        // Nghiệp vụ Gọi dịch vụ
        public bool OrderService(int maPhieu, int maDV, int soLuong)
        {
            if (maPhieu <= 0 || maDV <= 0 || soLuong <= 0) return false;
            dal.AddServiceUsage(maPhieu, maDV, soLuong);
            return true;
        }

        // Nghiệp vụ Tính tiền & Check-out
        public decimal CalculateTotal(string soPhong, out int maPhieu, out double soGio, out decimal tienPhong, out decimal tienDichVu)
        {
            maPhieu = -1;
            soGio = 0;
            tienPhong = 0;
            tienDichVu = 0;

            DataTable dtRoom = dal.GetRoomCheckoutInfo(soPhong);
            if (dtRoom.Rows.Count == 0) return 0;

            maPhieu = Convert.ToInt32(dtRoom.Rows[0]["MaPhieu"]);
            DateTime ngayNhan = Convert.ToDateTime(dtRoom.Rows[0]["NgayNhanPhong"]);
            decimal giaGio = Convert.ToDecimal(dtRoom.Rows[0]["GiaTheoGio"]);

            TimeSpan duration = DateTime.Now - ngayNhan;
            // Tính tối thiểu 1 giờ, làm tròn lên theo giờ
            soGio = Math.Max(1.0, Math.Ceiling(duration.TotalHours));
            tienPhong = (decimal)soGio * giaGio;

            DataTable dtDV = dal.GetServiceDetailsByTicket(maPhieu);
            foreach (DataRow r in dtDV.Rows)
            {
                tienDichVu += Convert.ToDecimal(r["ThanhTien"]);
            }

            return tienPhong + tienDichVu;
        }

        public bool PerformCheckOut(int maPhieu, string soPhong, decimal tongTien)
        {
            return dal.CheckOut(maPhieu, soPhong, tongTien);
        }
    }
}