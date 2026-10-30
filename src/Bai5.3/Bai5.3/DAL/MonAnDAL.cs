using System.Data;
using MySql.Data.MySqlClient;

namespace Bai5._3.DAL
{
    public class MonAnDAL : DatabaseAccess
    {
        public DataTable GetListDanhMuc()
        {
            string query = "SELECT * FROM DanhMuc";
            return ExecuteQuery(query);
        }

        public DataTable GetListMonAnByDanhMuc(int maDanhMuc)
        {
            string query = "SELECT * FROM MonAn WHERE MaDanhMuc = @MaDanhMuc";
            MySqlParameter[] p = { new MySqlParameter("@MaDanhMuc", maDanhMuc) };
            return ExecuteQuery(query, p);
        }

        public decimal GetDonGiaMon(int maMon)
        {
            string query = "SELECT DonGia FROM MonAn WHERE MaMon = @MaMon";
            MySqlParameter[] p = { new MySqlParameter("@MaMon", maMon) };
            object result = ExecuteScalar(query, p);
            return result != null ? System.Convert.ToDecimal(result) : 0;
        }
    }
}