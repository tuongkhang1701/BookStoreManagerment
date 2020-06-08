using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanSachQuaMang.DTO
{
    public class CongTyPhatHanh
    {
        public CongTyPhatHanh(int iDCongTy, string tenCongTy)
        {
            this.IDCongTy = iDCongTy;
            this.TenCongTy = tenCongTy;
        }

        public CongTyPhatHanh(DataRow row)
        {
            this.IDCongTy = (int)row["IDCongTy"];
            this.TenCongTy = row["TenCongTy"].ToString();
        }

        private int iDCongTy;
        private string tenCongTy;

        public int IDCongTy { get => iDCongTy; set => iDCongTy = value; }
        public string TenCongTy { get => tenCongTy; set => tenCongTy = value; }
    }
}
