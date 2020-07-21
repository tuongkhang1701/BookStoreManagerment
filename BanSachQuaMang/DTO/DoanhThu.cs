using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanSachQuaMang.DTO
{
    public class DoanhThu
    {
        private int iDHoaDon;
        private DateTime? ngayDat;
        private int tong;
        private string userName;

        public DoanhThu(int idHoaDon, DateTime? ngayDat, int tong, string username)
        {
            this.IDHoaDon = idHoaDon;
            this.NgayDat = ngayDat;
            this.Tong = tong;
            this.UserName = username;
        }

        public DoanhThu(DataRow row)
        {
            this.IDHoaDon = (int)row["idHoaDon"];
            this.NgayDat = (DateTime?)row["ngayDat"];
            this.Tong = (int)row["tong"];
            this.UserName = row["username"].ToString();
        }

        public int IDHoaDon { get => iDHoaDon; set => iDHoaDon = value; }
        public DateTime? NgayDat { get => ngayDat; set => ngayDat = value; }
        public int Tong { get => tong; set => tong = value; }
        public string UserName { get => userName; set => userName = value; }
    }
}
