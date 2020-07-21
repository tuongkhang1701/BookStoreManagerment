using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanSachQuaMang.DTO
{
    public class GioHang
    {
        private int iDGioHang;
        private int iDSach;
        //private string TenSach;
        private int SoLuong;

        public GioHang(int idGioHang, int idSach, int soLuong)
        {
            this.iDGioHang = idGioHang;
            this.iDSach = idSach;
            //this.TenSach = tenSach;
            this.SoLuong = soLuong;
        }
        public GioHang(DataRow row)
        {
            /*this.iDGioHang = (int)row["idGioHang"];
            this.iDSach = (int)row["idSach"];*/
            //this.TenSach = row["tenSach"].ToString();
            this.SoLuong = (int)row["soLuong"];
        }

        public int IDGioHang { get => iDGioHang; set => iDGioHang = value; }
        public int IDSach { get => iDSach; set => iDSach = value; }
        //public string TenSach1 { get => TenSach; set => TenSach = value; }
        public int SoLuong1 { get => SoLuong; set => SoLuong = value; }
    }
}
