using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanSachQuaMang.DTO
{
    public class History
    {
        private string tenSach;
        private int soLuong;
        private int totalPrice;
        public History(string tenSach, int soLuong, int totalPrice)
        {
            this.TenSach = tenSach;
            this.SoLuong = soLuong;
            this.TotalPrice = totalPrice;
        }

        public History(DataRow row)
        {
            this.TenSach = row["TenSach"].ToString();
            this.SoLuong = (int)row["SoLuong"];
            this.TotalPrice = Convert.ToInt32(row["totalPrice"].ToString());
        }

        public string TenSach { get => tenSach; set => tenSach = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
