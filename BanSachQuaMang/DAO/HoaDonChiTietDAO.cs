using BanSachQuaMang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanSachQuaMang.DAO
{
    public class HoaDonChiTietDAO
    {
        private static HoaDonChiTietDAO instance;

        public static HoaDonChiTietDAO Instance 
        {
            get 
            {
                if (instance == null) instance = new HoaDonChiTietDAO();
                return instance;
            }
            private set => instance = value;
        }
        public DataTable getInfoOfGioHang(string username)
        {
            
            string query = "select IDSach, SoLuong from GioHang where userName = N'" + username + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
           
            return data;
        }
        public bool insertHoaDonChiTiet(int idSach, int soLuong, int hoaDon, string username)
        {
            string query = string.Format("insert into HoaDonChiTiet(IDSach, SoLuong, IDHoaDon, userName) values({0}, {1}, {2}, N'{3}')", idSach, soLuong, hoaDon, username);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
