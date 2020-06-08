using BanSachQuaMang.DAO;
using BanSachQuaMang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanSachQuaMang
{
    
    public partial class frmAccountProfile : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get => loginAccount;
            set
            {
                loginAccount = value;
                
            }
        }
        #region Các phương thức
        public frmAccountProfile(Account acc)
        {
            InitializeComponent();
            loginAccount = acc;
            changeAccount(loginAccount);
        }
        void changeAccount(Account acc)
        {
            txbUserName.Text = loginAccount.UserName;
            txbDisplayName.Text = loginAccount.DisplayName;
        }
        void updateAccount()
        {
            string displayName = txbDisplayName.Text;
            string passWord = txbPassWord.Text;
            string newPassWord = txbNewPW.Text;
            string reNewPassWord = txbReNewPW.Text;
            string userName = txbUserName.Text;
            if (!newPassWord.Equals(reNewPassWord))
            {
                MessageBox.Show("Mật khẩu nhập lại không chính xác!");
            }
            else
            {
                if (AccountDAO.Instance.updateAccount(userName, displayName, passWord, newPassWord))
                {
                    MessageBox.Show("Cập nhật thành công!");

                    if (eventUpdateAccount != null)
                    {
                        eventUpdateAccount(this, new AccountEvent(AccountDAO.Instance.getAccountByUserName(userName)));
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng điền chính xác mật khẩu!");
                }
            }
        }
        #endregion

        #region Các xử lí
        private event EventHandler<AccountEvent> eventUpdateAccount;
        public event EventHandler<AccountEvent> EventUpdateAccount
        {
            add
            {
                eventUpdateAccount += value; 
            }
            remove
            {
                eventUpdateAccount -= value;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateAccount();
        }

        #endregion


    }
    public class AccountEvent:EventArgs
    {
        private Account acc;

        public AccountEvent(Account acc)
        {
            this.Acc = acc;
        }
        public Account Acc { get => acc; set => acc = value; }
    }
}
