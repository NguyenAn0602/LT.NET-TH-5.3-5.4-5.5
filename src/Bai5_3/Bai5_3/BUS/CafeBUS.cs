using System.Data;
using Bai5_3.DAL;

namespace Bai5_3.BUS
{
    public class CafeBUS
    {
        private CafeDAL dal = new CafeDAL();

        public DataTable GetTableList() => dal.GetTableList();
        public DataTable GetCategoryList() => dal.GetCategoryList();
        public DataTable GetFoodByCategoryID(int id) => dal.GetFoodByCategoryID(id);
        public DataTable GetBillDetailsByTableID(int maBan) => dal.GetBillDetailsByTableID(maBan);

        public bool OrderFood(int maBan, int maMon, int soLuong, decimal donGia)
        {
            if (maBan <= 0 || maMon <= 0 || soLuong <= 0) return false;
            dal.AddFoodToTable(maBan, maMon, soLuong, donGia);
            return true;
        }

        public bool CheckOut(int maBan, decimal tongTien)
        {
            if (maBan <= 0) return false;
            return dal.CheckOut(maBan, tongTien);
        }
    }
}