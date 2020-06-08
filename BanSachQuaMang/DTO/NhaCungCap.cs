using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanSachQuaMang.DTO
{
    public class NhaCungCap
    {
        public NhaCungCap(int idNCC, string tenNCC)
        {
            this.IDNCC = idNCC;
            this.TenNCC = tenNCC;
        }
        public NhaCungCap(DataRow row)
        {
            this.IDNCC = (int)row["IDNCC"];
            this.TenNCC = row["TenNCC"].ToString();
        }
        private int iDNCC;
        private string tenNCC;

        public int IDNCC { get => iDNCC; set => iDNCC = value; }
        public string TenNCC { get => tenNCC; set => tenNCC = value; }
    }
}
