using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanSachQuaMang.DTO
{
    public class AccountType
    {
        private int type;
        private string name;
        public AccountType(int type, string name)
        {
            this.Type = type;
            this.Name = name;
        }
        public AccountType(DataRow row)
        {
            this.Type = (int)row["type"];
            this.Name = row["Name"].ToString();
        }

        public int Type { get => type; set => type = value; }
        public string Name { get => name; set => name = value; }
    }
}
