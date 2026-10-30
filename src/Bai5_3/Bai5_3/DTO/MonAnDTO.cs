namespace Bai5_3.DTO
{
    public class MonAnDTO
    {
        public int MaMon { get; set; }
        public string TenMon { get; set; }
        public int MaDanhMuc { get; set; }
        public decimal DonGia { get; set; }

        public MonAnDTO() { }
        public MonAnDTO(int maMon, string tenMon, int maDanhMuc, decimal donGia)
        {
            MaMon = maMon;
            TenMon = tenMon;
            MaDanhMuc = maDanhMuc;
            DonGia = donGia;
        }
    }
}