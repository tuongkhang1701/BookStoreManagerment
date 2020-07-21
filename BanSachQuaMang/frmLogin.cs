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
    public partial class frmLogin : Form
    {
        #region Methods
        public frmLogin()
        {
            InitializeComponent();
        }
        bool Login(string userName, string passWord)
        {

            return AccountDAO.Instance.Login(userName, passWord);
        }
        
        #endregion

        #region Events
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình!","Thông báo", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes)
                e.Cancel = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string passWord = txbPassWord.Text;
            if (Login(userName, passWord)) {
                Account loginAccount = AccountDAO.Instance.getAccountByUserName(userName);
                frmHome home = new frmHome(loginAccount);
                this.Hide();
                home.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
            }
        }
        private void btnSignUp_Click(object sender, EventArgs e)
        {

        }




        #endregion

        private void linkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSighUp frm = new frmSighUp();
            this.Hide();
            frm.ShowDialog();
            this.Show();
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.BackColor = Color.FromArgb(43, 64, 44);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            panel3.BackColor = Color.FromArgb(43, 64, 44);
        }

        private void txbUserName_TextChanged(object sender, EventArgs e)
        {
            txbUserName.BackColor = Color.FromArgb(43, 64, 44);
        }
    }
}
