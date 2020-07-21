using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanSachQuaMang.DTO
{
    public class HoaDon
    {
        private int iDHoaDon;
        private DateTime? ngayDat;
        private DateTime? ngayGiaoHang;
        private string cachTT;
        private string userName;

        public HoaDon(int idHoaDon, DateTime? ngayDat, DateTime? ngayGiaoHang, string cachTT)
        {
            this.IDHoaDon = idHoaDon;
            this.NgayDat = ngayDat;
            this.NgayGiaoHang = ngayGiaoHang;
            this.CachTT = cachTT;
            //this.UserName = username;
        }
        public HoaDon(DataRow row)
        {
            this.IDHoaDon = (int)row["idHoaDon"];
            this.NgayDat = (DateTime?)row["ngayDat"];
            this.NgayGiaoHang = (DateTime?)row["ngayGiaoHang"];
            this.CachTT = row["CachTT"].ToString();
            //this.UserName = row["username"].ToString();
        }


        public int IDHoaDon { get => iDHoaDon; set => iDHoaDon = value; }
        public DateTime? NgayDat { get => ngayDat; set => ngayDat = value; }
        public DateTime? NgayGiaoHang { get => ngayGiaoHang; set => ngayGiaoHang = value; }
        public string CachTT { get => cachTT; set => cachTT = value; }
        //public string UserName { get => userName; set => userName = value; }
    }
}
