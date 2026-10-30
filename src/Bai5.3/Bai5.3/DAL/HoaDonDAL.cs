using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Bai5._3.DAL
{
    public class HoaDonDAL : DatabaseAccess
    {
        // Lấy danh sách món ăn đã đặt của bàn (Hóa đơn chưa thanh toán)
        public DataTable GetBillByTable(int maBan)
        {
            string query = @"SELECT m.TenMon, ct.SoLuong, ct.DonGia, (ct.SoLuong * ct.DonGia) AS ThanhTien
                             FROM ChiTietHoaDon ct
                             JOIN HoaDon hd ON ct.MaHoaDon = hd.MaHoaDon
                             JOIN MonAn m ON ct.MaMon = m.MaMon
                             WHERE hd.MaBan = @MaBan AND hd.TrangThai = 0";
            MySqlParameter[] p = { new MySqlParameter("@MaBan", maBan) };
            return ExecuteQuery(query, p);
        }

        // Lấy Mã hóa đơn chưa thanh toán của bàn
        public int GetUncheckBillIdByTable(int maBan)
        {
            string query = "SELECT MaHoaDon FROM HoaDon WHERE MaBan = @MaBan AND TrangThai = 0";
            MySqlParameter[] p = { new MySqlParameter("@MaBan", maBan) };
            object result = ExecuteScalar(query, p);
            return result != null ? Convert.ToInt32(result) : -1;
        }

        // Tạo hóa đơn mới
        public int InsertHoaDon(int maBan)
        {
            string query = "INSERT INTO HoaDon (MaBan, GioVao, TrangThai) VALUES (@MaBan, NOW(), 0); SELECT LAST_INSERT_ID();";
            MySqlParameter[] p = { new MySqlParameter("@MaBan", maBan) };
            return Convert.ToInt32(ExecuteScalar(query, p));
        }

        // Thêm hoặc cập nhật số lượng món vào chi tiết hóa đơn
        public void InsertChiTietHoaDon(int maHoaDon, int maMon, int soLuong, decimal donGia)
        {
            string query = @"INSERT INTO ChiTietHoaDon (MaHoaDon, MaMon, SoLuong, DonGia) 
                             VALUES (@MaHoaDon, @MaMon, @SoLuong, @DonGia)
                             ON DUPLICATE KEY UPDATE SoLuong = SoLuong + VALUES(SoLuong);";
            MySqlParameter[] p = {
                new MySqlParameter("@MaHoaDon", maHoaDon),
                new MySqlParameter("@MaMon", maMon),
                new MySqlParameter("@SoLuong", soLuong),
                new MySqlParameter("@DonGia", donGia)
            };
            ExecuteNonQuery(query, p);
        }

        // THANH TOÁN SỬ DỤNG TRANSACTION ĐẢM BẢO ĐỒNG BỘ CSDL
        public bool ThanhToanTransaction(int maHoaDon, int maBan, out decimal tongTien)
        {
            tongTien = 0;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // 1. Tính tổng tiền hóa đơn
                    string sumQuery = "SELECT SUM(SoLuong * DonGia) FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon";
                    MySqlCommand cmdSum = new MySqlCommand(sumQuery, conn, trans);
                    cmdSum.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    tongTien = Convert.ToDecimal(cmdSum.ExecuteScalar());

                    // 2. Cập nhật Hóa đơn (GioRa, TongTien, TrangThai = 1)
                    string payQuery = "UPDATE HoaDon SET GioRa = NOW(), TongTien = @TongTien, TrangThai = 1 WHERE MaHoaDon = @MaHoaDon";
                    MySqlCommand cmdPay = new MySqlCommand(payQuery, conn, trans);
                    cmdPay.Parameters.AddWithValue("@TongTien", tongTien);
                    cmdPay.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    cmdPay.ExecuteNonQuery();

                    // 3. Chuyển trạng thái bàn về "Trống"
                    string resetTableQuery = "UPDATE BanAn SET TrangThai = 'Trống' WHERE MaBan = @MaBan";
                    MySqlCommand cmdTable = new MySqlCommand(resetTableQuery, conn, trans);
                    cmdTable.Parameters.AddWithValue("@MaBan", maBan);
                    cmdTable.ExecuteNonQuery();

                    trans.Commit(); // Hoàn tất Transaction
                    return true;
                }
                catch
                {
                    trans.Rollback(); // Hoàn tác nếu có lỗi
                    return false;
                }
            }
        }
    }
}