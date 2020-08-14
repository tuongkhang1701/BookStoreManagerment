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

        public bool getNCCByName(string name)
        {
            int data = (int)DataProvider.Instance.ExecuteScalar("select COUNT(IDNCC) from NCC where TenNCC = N'" + name + "'");


            return data > 0;

        }

        public bool insertNCC(string name)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("insert into NCC (TenNCC) values (N'" + name + "')");
            return result > 0;
        }

        public bool editNCC(int idNCC, string tenNCC)
        {
            string query = string.Format("UPDATE NCC SET TenNCC = N'{0}' WHERE IDNCC = {1}", tenNCC, idNCC);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool deleteNCC(int id)
        {

            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_deleteNCC @idNCC ", new object[] { id });

            return result > 0;
        }

        public List<NhaCungCap> searchNCCByUserName(string userName)
        {
            List<NhaCungCap> list = new List<NhaCungCap>();

            string query = string.Format("select * from NCC where dbo.fuConvertToUnsign1(TenNCC) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", userName);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                NhaCungCap acc = new NhaCungCap(item);
                list.Add(acc);
            }
            return list;
        }
    }
}
