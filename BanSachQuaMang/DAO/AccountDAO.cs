using BanSachQuaMang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanSachQuaMang.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance 
        {
            get { if(instance == null) instance = new AccountDAO() ; return AccountDAO.instance; }
            set { AccountDAO.instance = value; }
        }
        public bool Login(string userName, string passWord)
        {
            string query = "EXEC USP_Login @userName , @passWord";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] {userName, passWord });

            return result.Rows.Count > 0;
        }
        public Account getAccountByUserName(string userName)
        {
            DataTable data =  DataProvider.Instance.ExecuteQuery("select * from Account where userName = '" + userName + "'");
            foreach (DataRow item in data.Rows)
            {
                Account acc = new Account(item);
                return acc;
            }
            return null;
        }
        public List<Account> searchAccoutByUserName(string userName)
        {
            List<Account> list = new List<Account>();

            string query = string.Format("select * from Account where dbo.fuConvertToUnsign1(UserName) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", userName);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Account acc = new Account(item);
                list.Add(acc);
            }
            return list;
        }
        public bool updateAccount(string userName, string displayName, string passWord, string newPass)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @userName , @passWord , @displayName , @newPassWord", new object[] {userName, displayName, passWord, newPass });

            return result > 0;
        }
        public DataTable getAccountList()
        {
            string query = "select userName , displayName, type from Account";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }
        public bool addAccount(string userName, string displayName, int type)
        {
            string query = string.Format("insert into  Account(userName, displayName, type) values (N'{0}', N'{1}', {2})", userName, displayName, type);
            
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool editAccount(string userName, string displayName, int type)
        {
            string query = string.Format("update Account set displayName = N'{1}', Type = {2} where userName = N'{0}'", userName, displayName, type);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;

        }
        public bool deleteAccount(string userName) 
        {
            string query = string.Format("delete Account where userName = N'{0}'", userName);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool resetPassWord(string userName)
        {
            string query = string.Format("update Account set passWord = N'0' where userName = N'{0}'", userName);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool signUpAccount(string userName, string passWord)
        {
            string query = string.Format("insert into Account(userName, passWord) values(N'{0}', N'{1}')", userName,passWord);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool testByUsername(string userName)
        {
            int result = (int)(DataProvider.Instance.ExecuteScalar(string.Format("select count(userName) from Account where userName = N'{0}'",userName)));

            return result > 0;
        }
    }
}
