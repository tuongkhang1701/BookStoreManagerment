using BanSachQuaMang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanSachQuaMang.DAO
{
    public class HistoryDAO
    {
        private static HistoryDAO instance;

        public static HistoryDAO Instance
        {
            get
            {
                if (instance == null) instance = new HistoryDAO();
                return instance;
            }
            private set => instance = value;
        }
        public List<History> getDetail(int idHoaDon)
        {
            List<History> list = new List<History>();
            string query = "select TenSach, HDCT.SoLuong, HDCT.SoLuong * S.DonGia AS totalPrice from HoaDonChiTiet as HDCT, Sach as S where HDCT.IDSach = S.IDSach and IDHoaDon = " + idHoaDon + "";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                History ht = new History(item);
                list.Add(ht);
            }
            return list;
        }

    }
}
