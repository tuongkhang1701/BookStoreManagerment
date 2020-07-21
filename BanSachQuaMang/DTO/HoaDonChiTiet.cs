using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanSachQuaMang.DTO
{
    public class HoaDonChiTiet
    {
        private int iDHDCT;
        private int iDSach;
        private int soLuong;
        private int iDHoaDon;

        public HoaDonChiTiet(int idHDCT, int idSach, int soLuong, int idHoaDon)
        {
            this.IDHDCT = idHDCT;
            this.IDSach = idSach;
            this.SoLuong = soLuong;
            this.IDHoaDon = idHoaDon;
        }
        public HoaDonChiTiet(DataRow row)
        {
            this.IDHDCT = (int)row["IDHDCT"];
            this.IDSach = (int)row["idSach"];
            this.SoLuong = (int)row["soLuong"];
            this.IDHoaDon = (int)row["idHoaDon"];
        }

        public int IDHDCT { get => iDHDCT; set => iDHDCT = value; }
        public int IDSach { get => iDSach; set => iDSach = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int IDHoaDon { get => iDHoaDon; set => iDHoaDon = value; }
    }
}
