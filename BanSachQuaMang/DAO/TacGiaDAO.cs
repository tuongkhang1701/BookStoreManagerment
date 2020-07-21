using BanSachQuaMang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanSachQuaMang.DAO
{
    public class TacGiaDAO
    {
        private static TacGiaDAO instance;

        public static TacGiaDAO Instance 
        {
            get { if (instance == null) instance = new TacGiaDAO(); return TacGiaDAO.instance; }
            private set => instance = value; 
        }

        public List<TacGia> getTacGiaList()
        {
            List<TacGia> list = new List<TacGia>();

            string query = "select * from TacGia";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                TacGia tacgia = new TacGia(item);
                list.Add(tacgia);
            }

            return list;
        }
        public TacGia getTacGiaByID(int id)
        {
            TacGia tacGia = null;   
            string query = "select * from TacGia where IDTG = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows )
            {
                tacGia = new TacGia(item);
                return tacGia;
            }
            return tacGia;
        }
        public bool getTacGiaByName(string name)
        {
            int data = (int)DataProvider.Instance.ExecuteScalar("select COUNT(IDTG) from TacGia where TenTG = N'" + name + "'");


            return data > 0;
            
        }
        public bool insertTG(string name)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("insert into TacGia (TenTG) values (N'" + name + "')");
            return result > 0;
        }
        public List<TacGia> searchTGByUserName(string userName)
        {
            List<TacGia> list = new List<TacGia>();

            string query = string.Format("select * from TacGia where dbo.fuConvertToUnsign1(TenTG) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", userName);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                TacGia acc = new TacGia(item);
                list.Add(acc);
            }
            return list;
        }
        public bool editTG(int idTG, string tenTG)
        {
            string query = string.Format("UPDATE TacGia SET TenTG = N'{0}' WHERE IDTG = {1}", tenTG ,idTG);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool deleteBook(int id)
        {
            string query = "delete TacGia where IDTG = " + id;

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
