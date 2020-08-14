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
        public bool getCTPHByName(string name)
        {
            int data = (int)DataProvider.Instance.ExecuteScalar("select COUNT(IDCongTy) from CongTyPhatHanh where TenCongTy = N'" + name + "'");


            return data > 0;

        }

        public bool insertCTPH(string name)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("insert into CongTyPhatHanh (TenCongTy) values (N'" + name + "')");
            return result > 0;
        }

        public bool editCTPH(int idCTPH, string tenCTPH)
        {
            string query = string.Format("UPDATE CongTyPhatHanh SET TenCongTy = N'{0}' WHERE IDCongTy = {1}", tenCTPH, idCTPH);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool deleteCTPH(int id)
        {

            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_deleteCTPH @idCTPH ", new object[] { id });

            return result > 0;
        }

        public List<CongTyPhatHanh> searchCTPHByUserName(string userName)
        {
            List<CongTyPhatHanh> list = new List<CongTyPhatHanh>();

            string query = string.Format("select * from CongTyPhatHanh where dbo.fuConvertToUnsign1(TenCongTy) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", userName);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                CongTyPhatHanh acc = new CongTyPhatHanh(item);
                list.Add(acc);
            }
            return list;
        }
    }
}
