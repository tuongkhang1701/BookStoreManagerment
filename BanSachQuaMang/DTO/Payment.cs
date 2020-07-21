using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanSachQuaMang.DTO
{
    public class Payment
    {
        private int iDTT;
        private string cachTT;
        private Payment() { }
        public Payment(int idTT, string cachTT)
        {
            this.IDTT = idTT;
            this.CachTT = cachTT;
        }
        public Payment(DataRow row)
        {
            this.IDTT = (int)row["IDTT"];
            this.CachTT = row["CachTT"].ToString();
        }

        public int IDTT { get => iDTT; set => iDTT = value; }
        public string CachTT { get => cachTT; set => cachTT = value; }
    }
}
