using BanSachQuaMang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanSachQuaMang.DAO
{
    public class HoaDonDAO
    {
        private static HoaDonDAO intance;

        public static HoaDonDAO Intance 
        {
            get 
            {
                if (intance == null) intance = new HoaDonDAO();
                return intance;
            }
            private set => intance = value;
        }
        public bool insertIntoHoaDon(int idTT, string username)
        {
            string query = string.Format("insert into HoaDon(NgayDat, NgayGiaoHang, IDTT, username) values(GETDATE(), GETDATE()+3, {0}, N'{1}')", idTT, username);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int getMaxIDHoaDon(string username)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(IDHoaDon) FROM HoaDon WHERE userName = N'" + username + "'");
            }
            catch
            {
                return 1;
            }

        }
        public List<HoaDon> getHistory(string username)
        {
            List<HoaDon> list = new List<HoaDon>();
            string query = "select IDHoaDon ,NgayDat, NgayGiaoHang, CachTT from HoaDon, ThanhToan where username = N'" + username + "' and ThanhToan.IDTT = HoaDon.IDTT ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                HoaDon hd = new HoaDon(item);
                list.Add(hd);
            }

            return list;
        }
        public DataTable getDoanhThu(DateTime fromDate, DateTime toDate)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC USP_getDoanhThu @fromDate , @toDate", new object[] {fromDate, toDate });
        }
    }
}
