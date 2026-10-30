using System;
using System.Data;
using System.Data.SqlClient;

namespace Bai5_3.DAL
{
    public class CafeDAL
    {
        // 1. Lấy danh sách bàn
        public DataTable GetTableList()
        {
            return DatabaseHelper.ExecuteQuery("SELECT MaBan, TenBan, TrangThai FROM BanAn");
        }

        // 2. Lấy danh mục món
        public DataTable GetCategoryList()
        {
            return DatabaseHelper.ExecuteQuery("SELECT MaDanhMuc, TenDanhMuc FROM DanhMuc");
        }

        // 3. Lấy món theo danh mục
        public DataTable GetFoodByCategoryID(int maDanhMuc)
        {
            string query = "SELECT MaMon, TenMon, DonGia FROM MonAn WHERE MaDanhMuc = @MaDanhMuc";
            SqlParameter[] param = { new SqlParameter("@MaDanhMuc", maDanhMuc) };
            return DatabaseHelper.ExecuteQuery(query, param);
        }

        // 4. Lấy MaHoaDon chưa thanh toán của bàn (nếu có)
        public int GetUncheckBillIDByTableID(int maBan)
        {
            string query = "SELECT MaHoaDon FROM HoaDon WHERE MaBan = @MaBan AND TrangThai = 0";
            SqlParameter[] param = { new SqlParameter("@MaBan", maBan) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, param);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["MaHoaDon"]);
            }
            return -1;
        }

        // 5. Nạp danh sách món đã gọi của bàn lên DataGridView
        public DataTable GetBillDetailsByTableID(int maBan)
        {
            string query = @"SELECT m.TenMon, c.SoLuong, c.DonGia, (c.SoLuong * c.DonGia) AS ThanhTien 
                             FROM ChiTietHoaDon c
                             JOIN HoaDon h ON c.MaHoaDon = h.MaHoaDon
                             JOIN MonAn m ON c.MaMon = m.MaMon
                             WHERE h.MaBan = @MaBan AND h.TrangThai = 0";
            SqlParameter[] param = { new SqlParameter("@MaBan", maBan) };
            return DatabaseHelper.ExecuteQuery(query, param);
        }

        // 6. Thêm món vào bàn (Gọi món)
        public void AddFoodToTable(int maBan, int maMon, int soLuong, decimal donGia)
        {
            int billID = GetUncheckBillIDByTableID(maBan);

            // Nếu bàn chưa có hóa đơn tạm -> Tạo mới hóa đơn và đổi bàn sang "Có khách"
            if (billID == -1)
            {
                string insertBill = "INSERT INTO HoaDon (MaBan, GioVao, TrangThai) VALUES (@MaBan, GETDATE(), 0); SELECT SCOPE_IDENTITY();";
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(insertBill, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBan", maBan);
                        billID = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                DatabaseHelper.ExecuteNonQuery("UPDATE BanAn SET TrangThai = N'Có khách' WHERE MaBan = @MaBan",
                    new SqlParameter[] { new SqlParameter("@MaBan", maBan) });
            }

            // Kiểm tra món đã có trong hóa đơn chưa
            string checkExist = "SELECT SoLuong FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon AND MaMon = @MaMon";
            SqlParameter[] checkParams = {
                new SqlParameter("@MaHoaDon", billID),
                new SqlParameter("@MaMon", maMon)
            };
            DataTable dt = DatabaseHelper.ExecuteQuery(checkExist, checkParams);

            if (dt.Rows.Count > 0)
            {
                int currentQty = Convert.ToInt32(dt.Rows[0]["SoLuong"]);
                string updateQty = "UPDATE ChiTietHoaDon SET SoLuong = @SoLuong WHERE MaHoaDon = @MaHoaDon AND MaMon = @MaMon";
                SqlParameter[] updateParams = {
                    new SqlParameter("@SoLuong", currentQty + soLuong),
                    new SqlParameter("@MaHoaDon", billID),
                    new SqlParameter("@MaMon", maMon)
                };
                DatabaseHelper.ExecuteNonQuery(updateQty, updateParams);
            }
            else
            {
                string insertDetail = "INSERT INTO ChiTietHoaDon (MaHoaDon, MaMon, SoLuong, DonGia) VALUES (@MaHoaDon, @MaMon, @SoLuong, @DonGia)";
                SqlParameter[] insertParams = {
                    new SqlParameter("@MaHoaDon", billID),
                    new SqlParameter("@MaMon", maMon),
                    new SqlParameter("@SoLuong", soLuong),
                    new SqlParameter("@DonGia", donGia)
                };
                DatabaseHelper.ExecuteNonQuery(insertDetail, insertParams);
            }
        }

        // 7. Chức năng Thanh toán (Bắt buộc dùng SqlTransaction)
        public bool CheckOut(int maBan, decimal tongTien)
        {
            int billID = GetUncheckBillIDByTableID(maBan);
            if (billID == -1) return false;

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // 1. Cập nhật Hóa đơn
                    string updateBill = @"UPDATE HoaDon 
                                          SET GioRa = GETDATE(), TongTien = @TongTien, TrangThai = 1 
                                          WHERE MaHoaDon = @MaHoaDon";
                    using (SqlCommand cmdBill = new SqlCommand(updateBill, conn, trans))
                    {
                        cmdBill.Parameters.AddWithValue("@TongTien", tongTien);
                        cmdBill.Parameters.AddWithValue("@MaHoaDon", billID);
                        cmdBill.ExecuteNonQuery();
                    }

                    // 2. Chuyển trạng thái bàn về 'Trống'
                    string updateTable = "UPDATE BanAn SET TrangThai = N'Trống' WHERE MaBan = @MaBan";
                    using (SqlCommand cmdTable = new SqlCommand(updateTable, conn, trans))
                    {
                        cmdTable.Parameters.AddWithValue("@MaBan", maBan);
                        cmdTable.ExecuteNonQuery();
                    }

                    // Hoàn tất giao dịch
                    trans.Commit();
                    return true;
                }
                catch (Exception)
                {
                    trans.Rollback();
                    return false;
                }
            }
        }
    }
}