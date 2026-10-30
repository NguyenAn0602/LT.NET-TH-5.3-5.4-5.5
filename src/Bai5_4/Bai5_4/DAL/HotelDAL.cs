using System;
using System.Data;
using System.Data.SqlClient;
using Bai5_4.DTO;

namespace Bai5_4.DAL
{
    public class HotelDAL
    {
        // 1. Lấy danh sách tất cả phòng
        public DataTable GetAllRooms()
        {
            return DatabaseHelper.ExecuteQuery("SELECT SoPhong, LoaiPhong, GiaTheoGio, TrangThai FROM Phong");
        }

        // 2. Tra cứu khách hàng theo CCCD (SqlParameter chống SQL Injection)
        public KhachHangDTO GetCustomerByCCCD(string cccd)
        {
            string query = "SELECT MaKH, HoTen, CCCD, SoDienThoai FROM KhachHang WHERE CCCD = @CCCD";
            SqlParameter[] param = { new SqlParameter("@CCCD", cccd) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, param);

            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                return new KhachHangDTO(
                    Convert.ToInt32(r["MaKH"]),
                    r["HoTen"].ToString(),
                    r["CCCD"].ToString(),
                    r["SoDienThoai"].ToString()
                );
            }
            return null;
        }

        // 3. Thêm khách hàng mới và lấy MaKH sinh tự động
        public int InsertCustomer(KhachHangDTO kh)
        {
            string query = "INSERT INTO KhachHang (HoTen, CCCD, SoDienThoai) VALUES (@HoTen, @CCCD, @SDT); SELECT SCOPE_IDENTITY();";
            SqlParameter[] param = {
                new SqlParameter("@HoTen", kh.HoTen),
                new SqlParameter("@CCCD", kh.CCCD),
                new SqlParameter("@SDT", kh.SoDienThoai)
            };
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, param));
        }

        // 4. Lập phiếu nhận phòng (Check-in) & đổi trạng thái phòng sang "Đang ở"
        public bool CheckIn(string soPhong, int maKH)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    string insertPhieu = "INSERT INTO PhieuDatPhong (SoPhong, MaKH, NgayNhanPhong) VALUES (@SoPhong, @MaKH, GETDATE())";
                    using (SqlCommand cmd1 = new SqlCommand(insertPhieu, conn, trans))
                    {
                        cmd1.Parameters.AddWithValue("@SoPhong", soPhong);
                        cmd1.Parameters.AddWithValue("@MaKH", maKH);
                        cmd1.ExecuteNonQuery();
                    }

                    string updatePhong = "UPDATE Phong SET TrangThai = N'Đang ở' WHERE SoPhong = @SoPhong";
                    using (SqlCommand cmd2 = new SqlCommand(updatePhong, conn, trans))
                    {
                        cmd2.Parameters.AddWithValue("@SoPhong", soPhong);
                        cmd2.ExecuteNonQuery();
                    }

                    trans.Commit();
                    return true;
                }
                catch
                {
                    trans.Rollback();
                    return false;
                }
            }
        }

        // 5. Lấy mã phiếu đang ở của phòng
        public int GetActiveTicketIDByRoom(string soPhong)
        {
            string query = "SELECT MaPhieu FROM PhieuDatPhong WHERE SoPhong = @SoPhong AND NgayTraPhong IS NULL";
            SqlParameter[] param = { new SqlParameter("@SoPhong", soPhong) };
            object result = DatabaseHelper.ExecuteScalar(query, param);
            return result != null ? Convert.ToInt32(result) : -1;
        }

        // 6. Lấy danh sách dịch vụ
        public DataTable GetAllServices()
        {
            return DatabaseHelper.ExecuteQuery("SELECT MaDV, TenDV, DonGia FROM DichVu");
        }

        // 7. Thêm sử dụng dịch vụ vào phiếu
        public void AddServiceUsage(int maPhieu, int maDV, int soLuong)
        {
            string query = "INSERT INTO SuDungDichVu (MaPhieu, MaDV, SoLuong, ThoiGian) VALUES (@MaPhieu, @MaDV, @SoLuong, GETDATE())";
            SqlParameter[] param = {
                new SqlParameter("@MaPhieu", maPhieu),
                new SqlParameter("@MaDV", maDV),
                new SqlParameter("@SoLuong", soLuong)
            };
            DatabaseHelper.ExecuteNonQuery(query, param);
        }

        // 8. Lấy chi tiết dịch vụ đã dùng của phòng
        public DataTable GetServiceDetailsByTicket(int maPhieu)
        {
            string query = @"SELECT d.TenDV, s.SoLuong, d.DonGia, (s.SoLuong * d.DonGia) AS ThanhTien, s.ThoiGian
                             FROM SuDungDichVu s
                             JOIN DichVu d ON s.MaDV = d.MaDV
                             WHERE s.MaPhieu = @MaPhieu";
            SqlParameter[] param = { new SqlParameter("@MaPhieu", maPhieu) };
            return DatabaseHelper.ExecuteQuery(query, param);
        }

        // 9. Lấy thông tin ngày nhận phòng và đơn giá phòng
        public DataTable GetRoomCheckoutInfo(string soPhong)
        {
            string query = @"SELECT p.MaPhieu, p.NgayNhanPhong, ph.GiaTheoGio, k.HoTen
                             FROM PhieuDatPhong p
                             JOIN Phong ph ON p.SoPhong = ph.SoPhong
                             JOIN KhachHang k ON p.MaKH = k.MaKH
                             WHERE p.SoPhong = @SoPhong AND p.NgayTraPhong IS NULL";
            SqlParameter[] param = { new SqlParameter("@SoPhong", soPhong) };
            return DatabaseHelper.ExecuteQuery(query, param);
        }

        // 10. Check-out (Thực thi SqlTransaction)
        public bool CheckOut(int maPhieu, string soPhong, decimal tongTien)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // 1. Cập nhật phiếu trả phòng
                    string updateTicket = @"UPDATE PhieuDatPhong 
                                            SET NgayTraPhong = GETDATE(), TongTienThanhToan = @TongTien 
                                            WHERE MaPhieu = @MaPhieu";
                    using (SqlCommand cmd1 = new SqlCommand(updateTicket, conn, trans))
                    {
                        cmd1.Parameters.AddWithValue("@TongTien", tongTien);
                        cmd1.Parameters.AddWithValue("@MaPhieu", maPhieu);
                        cmd1.ExecuteNonQuery();
                    }

                    // 2. Chuyển phòng sang 'Đang dọn dẹp'
                    string updateRoom = "UPDATE Phong SET TrangThai = N'Đang dọn dẹp' WHERE SoPhong = @SoPhong";
                    using (SqlCommand cmd2 = new SqlCommand(updateRoom, conn, trans))
                    {
                        cmd2.Parameters.AddWithValue("@SoPhong", soPhong);
                        cmd2.ExecuteNonQuery();
                    }

                    trans.Commit();
                    return true;
                }
                catch
                {
                    trans.Rollback();
                    return false;
                }
            }
        }

        // 11. Chuyển trạng thái phòng từ 'Đang dọn dẹp' -> 'Trống'
        public void CleanRoomComplete(string soPhong)
        {
            DatabaseHelper.ExecuteNonQuery("UPDATE Phong SET TrangThai = N'Trống' WHERE SoPhong = @SoPhong",
                new SqlParameter[] { new SqlParameter("@SoPhong", soPhong) });
        }
    }
}