using BanSachQuaMang.DAO;
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
    public partial class frmSighUp : Form
    {

        #region Methods
        public frmSighUp()
        {
            InitializeComponent();
        }
        void signUp(string userName, string passWord, string rePassWord)
        {
            if (!AccountDAO.Instance.testByUsername(userName))
            {
                if (txbPassWord.Text != "" && txbRePW.Text != "")
                {




                    if (passWord.Equals(rePassWord))
                    {


                        if (AccountDAO.Instance.signUpAccount(userName, passWord))
                        {
                            MessageBox.Show("Đăng ký tài khoản thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Đăng ký thất bại");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu nhập lại không trùng khớp!");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ mật khẩu!");
                }
            
            }
            else
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!");
            }
        }
        void testByUsername(string userName)
        {
            if (AccountDAO.Instance.testByUsername(userName))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!");
            }
            else
            {
                MessageBox.Show("Tên đăng nhập này là của bạn!");
            }
        }



        #endregion
        #region Events

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSignUp_Click_1(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string passWord = txbPassWord.Text;
            string rePassWord = txbRePW.Text;
            signUp(userName, passWord, rePassWord);


        }
        #endregion

        private void btnTest_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            if (txbUserName.Text == "")
                MessageBox.Show("Vui lòng nhập tên đăng nhập!");
            else
                testByUsername(userName);
        }


    }
}
