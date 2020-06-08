using BanSachQuaMang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanSachQuaMang.DAO
{
    public class AccountTypeDAO
    {
        private static AccountTypeDAO instance;

        public static AccountTypeDAO Instance 
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountTypeDAO();
                }
                return AccountTypeDAO.instance;
            }
            private set
            {
                instance = value;
            }
        }

        public List<AccountType> getListAccType ()
        {
            List<AccountType> list = new List<AccountType>();
            string query = "select * from AccountType";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                AccountType acc = new AccountType(item);
                list.Add(acc);
            }
            return list;
        }
        public AccountType getAccTypeByID(int id)
        {
            AccountType acc = null;
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from AccountType where Type = " + id);

            foreach (DataRow item in data.Rows)
            {
                acc = new AccountType(item);
                return acc;
            }
            return acc;
        }
    }
}
