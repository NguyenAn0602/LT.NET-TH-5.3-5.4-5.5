using System.Data;
using Bai5._3.DAL;

namespace Bai5._3.BUS
{
    public class BanAnBUS
    {
        private BanAnDAL banAnDAL = new BanAnDAL();

        // Lấy toàn bộ danh sách bàn ăn
        public DataTable GetListBanAn()
        {
            return banAnDAL.GetListBanAn();
        }

        // Cập nhật trạng thái bàn ("Trống" hoặc "Có khách")
        public void UpdateTrangThaiBan(int maBan, string trangThai)
        {
            banAnDAL.UpdateTrangThaiBan(maBan, trangThai);
        }
    }
}