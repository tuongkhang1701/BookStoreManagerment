using BanSachQuaMang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanSachQuaMang.DAO
{
    public class GioHangDAO
    {
        private static GioHangDAO instance;

        public static GioHangDAO Instance 
        {
            get
            {
                if (instance == null) instance = new GioHangDAO();
                return GioHangDAO.instance;
            }
            private set => instance = value;
        }
        
        public int checkBagByUsername(string username)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from GioHang where userName = N'" + username + "'");

            if(data.Rows.Count > 0)
            {
                GioHang gh = new GioHang(data.Rows[0]);
                return gh.IDGioHang;
            }
            return -1;
        }
        public void insertBag(int idSach, int soLuong, string username)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBag @idSach , @soLuong , @username", new object[] {idSach, soLuong, username });
        }
        public void removeBag(int idSach, int soLuong, string username)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_RemoveBook @idSach , @soLuong , @username", new object[] { idSach, soLuong, username });
        }
        public bool deleteGioHang(string username)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("delete GioHang where userName = N'" + username + "'");
            return result > 0;
        }
    }
       
}
