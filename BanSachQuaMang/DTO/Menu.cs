using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanSachQuaMang.DTO
{
    public class Menu
    {
        private int iDSach;
        private string bookName;
        private int soLuong;
        private int price;
        private int totalPrice;

        public Menu(int idSach ,string bookName, int soLuong, int price, int totalPrice = 0)
        {
            this.IDSach = idSach;
            this.BookName = bookName;
            this.SoLuong = soLuong;
            this.Price = price;
            this.TotalPrice = totalPrice;
        }
        public Menu(DataRow row)
        {
            this.IDSach = (int)row["IDSach"];
            this.BookName = row["TenSach"].ToString();
            this.SoLuong = Convert.ToInt32(row["SoLuong"].ToString());
            this.Price = Convert.ToInt32(row["DonGia"].ToString());
            this.TotalPrice = Convert.ToInt32(row["totalPrice"].ToString());
        }

        public int IDSach { get => iDSach; set => iDSach = value; }
        public string BookName { get => bookName; set => bookName = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int Price { get => price; set => price = value; }
        public int TotalPrice { get => totalPrice; set => totalPrice = value; }

    }
}
