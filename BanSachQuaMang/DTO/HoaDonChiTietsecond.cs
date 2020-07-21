using BanSachQuaMang.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanSachQuaMang.DTO
{
    public class HoaDonChiTietsecond
    {
        private int iDSach;
        private int soLuong;
        public HoaDonChiTietsecond(int idSach, int soLuong)
        {
            this.IDSach = idSach;
            this.SoLuong = soLuong;
        }
        public HoaDonChiTietsecond(DataRow row)
        {
            this.IDSach = (int)row["idSach"];
            this.SoLuong = (int)row["soLuong"];
        }

        public int IDSach { get => iDSach; set => iDSach = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
    }
}
