using BanSachQuaMang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanSachQuaMang.DAO
{
    public class DoanhThuDAO
    {
        private static DoanhThuDAO instance;

        public static DoanhThuDAO Instance
        {
            get
            {
                if (instance == null) instance = new DoanhThuDAO();
                return instance;
            }
            private set => instance = value;
        }
        public List<DoanhThu> getDoanhThu(DateTime? fromDay, DateTime? toDay)
        {
            List<DoanhThu> list = new List<DoanhThu>();
            string query = "SELECT HD.IDHoaDon ,NgayDat ,SUM(S.DonGia * HDCT.SoLuong) AS Tong, HD.username FROM HoaDon AS HD, HoaDonChiTiet AS HDCT, Sach AS S where HDCT.IDHoaDon = HD.IDHoaDon AND S.IDSach = HDCT.IDSach AND NgayDat between '" + fromDay + "' and '" + toDay + "' group by HD.IDHoaDon, NgayDat, HD.username";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DoanhThu dt = new DoanhThu(item);
                list.Add(dt);
            }
            return list;
        }
    }
}
