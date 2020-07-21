using BanSachQuaMang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanSachQuaMang.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance 
        {
            get {

                if (instance == null) instance = new MenuDAO();
                return instance;
            }
            private set => instance = value;
        }
        private MenuDAO() { }

        public List<Menu> getListMenuByUsername(string userName)
        {
            List<Menu> listMenu = new List<Menu>();
            string query = "select GH.IDSach, TenSach, DonGia, GH.SoLuong, S.DonGia * GH.SoLuong AS totalPrice from GioHang as GH, Sach AS S where GH.IDSach = S.IDSach AND GH.userName = N'" + userName + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                listMenu.Add(menu);
            }
            return listMenu;
        }
        public int getTotalPrice(string userName)
        {
            string query = "select SUM(GH.SoLuong * DonGia) AS totalPrice from GioHang as GH, Sach AS S where userName = N'" + userName + "' and GH.IDSach = S.IDSach";
            int data = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query).ToString());
            return data;
        }
    }
}
