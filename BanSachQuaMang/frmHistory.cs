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
    public partial class frmHistory : Form
    {
        #region Variables
        private Account loginAccount;
        public Account LoginAccount { get => loginAccount; set => loginAccount = value; }
        #endregion

        #region Methods
        public frmHistory(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
            showHistory(loginAccount.UserName);
        }
        public void showHistory(string username)
        {
            dtgvHistory.DataSource = HoaDonDAO.Intance.getHistory(username);
        }
        void viewDetailHistory(int idHoaDon)
        {
            dtgvHistory.DataSource = HistoryDAO.Instance.getDetail(idHoaDon);
        }
        #endregion

        #region Events
        private void btnDetail_Click(object sender, EventArgs e)
        {
            int idHoaDon = (int)dtgvHistory.SelectedCells[0].OwningRow.Cells["IDHoaDon"].Value;

            viewDetailHistory(idHoaDon);
            btnBack.Visible = true;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            showHistory(loginAccount.UserName);
            btnBack.Visible = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


    }
}
