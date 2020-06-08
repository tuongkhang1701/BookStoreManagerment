using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanSachQuaMang.DTO
{
    public class TacGia
    {
        private int iDTG;
        private string tenTG;

        public TacGia(int iDTG, string tenTG)
        {
            this.iDTG = iDTG;
            this.TenTG = tenTG;
        }

        public TacGia(DataRow row)
        {
            this.IDTG = (int)row["IDTG"];
            this.TenTG = row["TenTG"].ToString();
        }

        public int IDTG { get => iDTG; set => iDTG = value; }
        public string TenTG { get => tenTG; set => tenTG = value; }
    }
}
