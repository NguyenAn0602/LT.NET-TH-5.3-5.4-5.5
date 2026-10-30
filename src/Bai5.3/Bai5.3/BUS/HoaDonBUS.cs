using System.Data;
using Bai5._3.DAL;

namespace Bai5._3.BUS
{
    public class HoaDonBUS
    {
        private HoaDonDAL hoaDonDAL = new HoaDonDAL();
        private BanAnDAL banAnDAL = new BanAnDAL();
        private MonAnDAL monAnDAL = new MonAnDAL();

        // Lấy danh sách món ăn đã gọi trong hóa đơn chưa thanh toán của bàn
        public DataTable GetBillByTable(int maBan)
        {
            return hoaDonDAL.GetBillByTable(maBan);
        }

        // Nghiệp vụ Thêm món vào bàn (Gọi món)
        public void ThemMonVaoBan(int maBan, int maMon, int soLuong)
        {
            // 1. Kiểm tra xem bàn đã có hóa đơn chưa thanh toán hay chưa
            int maHoaDon = hoaDonDAL.GetUncheckBillIdByTable(maBan);

            // 2. Nếu chưa có hóa đơn -> Tạo hóa đơn mới & chuyển bàn sang "Có khách"
            if (maHoaDon == -1)
            {
                maHoaDon = hoaDonDAL.InsertHoaDon(maBan);
                banAnDAL.UpdateTrangThaiBan(maBan, "Có khách");
            }

            // 3. Lấy đơn giá món và chèn vào chi tiết hóa đơn
            decimal donGia = monAnDAL.GetDonGiaMon(maMon);
            hoaDonDAL.InsertChiTietHoaDon(maHoaDon, maMon, soLuong, donGia);
        }

        // Nghiệp vụ Thanh toán hóa đơn (Sử dụng Transaction)
        public bool ThanhToan(int maBan, out decimal tongTien)
        {
            tongTien = 0;
            int maHoaDon = hoaDonDAL.GetUncheckBillIdByTable(maBan);

            if (maHoaDon == -1)
            {
                return false; // Bàn chưa có hóa đơn để thanh toán
            }

            // Gọi hàm thực thi Transaction ở tầng DAL
            return hoaDonDAL.ThanhToanTransaction(maHoaDon, maBan, out tongTien);
        }
    }
}