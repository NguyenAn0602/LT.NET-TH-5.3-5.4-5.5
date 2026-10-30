using System.Data;
using Bai5._3.DAL;

namespace Bai5._3.BUS
{
    public class MonAnBUS
    {
        private MonAnDAL monAnDAL = new MonAnDAL();

        // Lấy danh sách tất cả Danh mục món
        public DataTable GetListDanhMuc()
        {
            return monAnDAL.GetListDanhMuc();
        }

        // Lấy danh sách Món ăn theo Mã danh mục được chọn
        public DataTable GetListMonAnByDanhMuc(int maDanhMuc)
        {
            return monAnDAL.GetListMonAnByDanhMuc(maDanhMuc);
        }

        // Lấy đơn giá của một món ăn
        public decimal GetDonGiaMon(int maMon)
        {
            return monAnDAL.GetDonGiaMon(maMon);
        }
    }
}