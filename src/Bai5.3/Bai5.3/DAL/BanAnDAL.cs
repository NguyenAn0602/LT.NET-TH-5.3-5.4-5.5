using System.Data;
using MySql.Data.MySqlClient;

namespace Bai5._3.DAL
{
    public class BanAnDAL : DatabaseAccess
    {
        public DataTable GetListBanAn()
        {
            string query = "SELECT * FROM BanAn";
            return ExecuteQuery(query);
        }

        public void UpdateTrangThaiBan(int maBan, string trangThai)
        {
            string query = "UPDATE BanAn SET TrangThai = @TrangThai WHERE MaBan = @MaBan";
            MySqlParameter[] p = {
                new MySqlParameter("@TrangThai", trangThai),
                new MySqlParameter("@MaBan", maBan)
            };
            ExecuteNonQuery(query, p);
        }
    }
}