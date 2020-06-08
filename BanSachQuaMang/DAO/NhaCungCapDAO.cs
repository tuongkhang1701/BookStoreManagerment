using BanSachQuaMang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanSachQuaMang.DAO
{
    public class NhaCungCapDAO
    {
        private static NhaCungCapDAO instance;

        public static NhaCungCapDAO Instance 
        {
            get { if (instance == null) instance = new NhaCungCapDAO(); return NhaCungCapDAO.instance; }
            private set => instance = value;
        }
        public List<NhaCungCap> getNCCList()
        {
            List<NhaCungCap> list = new List<NhaCungCap>();

            string query = "select * from NCC";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach  (DataRow item in data.Rows)
            {
                NhaCungCap ncc = new NhaCungCap(item);
                list.Add(ncc);
            }

            return list;
        }
        public NhaCungCap getNCCByID(int id)
        {
            NhaCungCap ncc = null;

            string query = "select * from NCC where IDNCC = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach  (DataRow item in data.Rows)
            {
                ncc = new NhaCungCap(item);
                return ncc;
            }
            return ncc;
        }
    }
}
