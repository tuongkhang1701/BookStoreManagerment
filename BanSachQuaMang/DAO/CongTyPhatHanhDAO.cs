using BanSachQuaMang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanSachQuaMang.DAO
{
    public class CongTyPhatHanhDAO
    {
        private static CongTyPhatHanhDAO instance;

        public static CongTyPhatHanhDAO Instance 
        {
            get { if (instance == null) instance = new CongTyPhatHanhDAO(); return CongTyPhatHanhDAO.instance; }
            private set => instance = value;
        }
        public List<CongTyPhatHanh> getCTPHList()
        {
            List<CongTyPhatHanh> list = new List<CongTyPhatHanh>();
            string query = "select * from CongTyPhatHanh";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach  (DataRow item in data.Rows)
            {
                CongTyPhatHanh ctph = new CongTyPhatHanh(item);
                list.Add(ctph);
            }

            return list;
        }
        public CongTyPhatHanh getCTPTByID(int id)
        {
            CongTyPhatHanh congTy = null;
            string query = "select * from CongTyPhatHanh where IDCongTy = " + id;
            
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                congTy = new CongTyPhatHanh(item);
                return congTy;
            }
            return congTy;
        }
    }
}
