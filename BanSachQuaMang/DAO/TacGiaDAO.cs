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
    }
}
