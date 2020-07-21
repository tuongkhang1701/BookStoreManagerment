using BanSachQuaMang.DAO;
using BanSachQuaMang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanSachQuaMang
{
    public partial class frmPayment : Form
    {
        #region Variables
        private Account loginAccount;

        public Account LoginAccount { get => loginAccount; set => loginAccount = value; }
        #endregion
        #region Methods
        public frmPayment(Account loginAccount)
        {
            InitializeComponent();
            this.LoginAccount = loginAccount;
        }
        public int CachTT()
        {
            if (rdCash.Checked)
                return 1;
            else
                return 2;
        }
        #endregion
        #region Events
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButtons.OK);
            if (eventLoadGioHang != null)
                eventLoadGioHang(this, new EventArgs());
            this.Close();
        }
        private event EventHandler eventLoadGioHang;
        public event EventHandler EventLoadGioHang
        {
            add { eventLoadGioHang += value; }
            remove { eventLoadGioHang -= value; }
        }
        #endregion
    }

}
