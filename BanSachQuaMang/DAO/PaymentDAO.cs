using BanSachQuaMang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanSachQuaMang.DAO
{
    public class PaymentDAO
    {
        private static PaymentDAO instance;

        public static PaymentDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PaymentDAO();
                }
                return instance;
            }
            private set => instance = value;
        }

        public void thanhToan(string username, int idTT)
        {
            string query = string.Format("insert into HoaDonChiTiet(NgayDat, NgayGiaoDuKien, IDTT, userName) values(GETDATE(), GETDATE() + 3, {0}, N'{1}') ", idTT, username);
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        

    }
}
