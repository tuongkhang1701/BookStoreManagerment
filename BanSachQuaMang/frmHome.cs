using BanSachQuaMang.DAO;
using BanSachQuaMang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanSachQuaMang
{
    public partial class frmHome : Form
    {
        #region Variables
        private Account loginAccount;

        public Account LoginAccount 
        { 
            get => loginAccount;
            set 
            {
                loginAccount = value;
            } 
        }
        #endregion


        #region Methods
        public frmHome(Account acc)
        {
            InitializeComponent();

            this.loginAccount = acc;
            changeAccount(loginAccount.Type);
            loadBook();
            loadDemo();
            showGioHang();
            menuStrip1.Renderer = new renderer();
        }

        void changeAccount(int type)
        {
            adminToolStripMenuItem.Visible = type == 1;
            thôngTinTàiKhoảnToolStripMenuItem.Text += " (" + loginAccount.DisplayName + ")";
        }
        
        void loadBook()
        {
            
            List<Book> bookList = BookDAO.Instance.loadBookList();
            CultureInfo culture = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentCulture = culture;

            
        }
        
        void showGioHang()
        {
            dtgvBag.DataSource = MenuDAO.Instance.getListMenuByUsername(loginAccount.UserName);
            try
            {
                txbTotalPrice.Text = MenuDAO.Instance.getTotalPrice(loginAccount.UserName).ToString();
            }
            catch (Exception ex) { };
        }
        void ThanhToan()
        {
            frmPayment frm = new frmPayment(loginAccount);
            frm.EventLoadGioHang += Frm_EventLoadGioHang;
            frm.Show();
            HoaDonDAO.Intance.insertIntoHoaDon(frm.CachTT(), loginAccount.UserName);
            foreach (DataRow item in HoaDonChiTietDAO.Instance.getInfoOfGioHang(loginAccount.UserName).Rows)
            {
                HoaDonChiTietsecond hd = new HoaDonChiTietsecond(item);
                HoaDonChiTietDAO.Instance.insertHoaDonChiTiet(hd.IDSach,hd.SoLuong,HoaDonDAO.Intance.getMaxIDHoaDon(loginAccount.UserName), loginAccount.UserName);
            }
            GioHangDAO.Instance.deleteGioHang(loginAccount.UserName);
            
            
        }
        void showFormHistory()
        {
            frmHistory frm = new frmHistory(loginAccount);
            frm.ShowDialog();
        }
        

        void loadDemo()
        {

            dtgvDemo.DataSource = BookDAO.Instance.loadBookList();

        }
        #endregion
        #region Events
        private void Frm_EventLoadGioHang(object sender, EventArgs e)
        {
            dtgvBag.DataSource = MenuDAO.Instance.getListMenuByUsername(loginAccount.UserName);
        }
        private void trangChurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }



        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccountProfile frm = new frmAccountProfile(loginAccount);

            frm.EventUpdateAccount += Frm_EventUpdateAccount;
            
            frm.ShowDialog();
        }

        private void Frm_EventUpdateAccount(object sender, AccountEvent e)
        {
            thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản (" + e.Acc.DisplayName + ")";
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdmin frm = new frmAdmin();
            frm.loginAccount = loginAccount;
            frm.ShowDialog();
        }
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            int idSach = (int)dtgvDemo.SelectedCells[0].OwningRow.Cells["ID"].Value;
            int num = (int)nmCount.Value;

            int idBag = GioHangDAO.Instance.checkBagByUsername(loginAccount.UserName);
            if (idBag == -1)
            {
                GioHangDAO.Instance.insertBag(idSach, num, loginAccount.UserName);
            }
            else
            {
                GioHangDAO.Instance.insertBag(idSach, num, loginAccount.UserName);
            }
            showGioHang();
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            int idSach = (int)dtgvBag.SelectedCells[0].OwningRow.Cells["IDSach"].Value;
            int num = (int)nmCount.Value;
            int numreal = (int)dtgvBag.SelectedCells[0].OwningRow.Cells["SoLuong"].Value;
            int idBag = GioHangDAO.Instance.checkBagByUsername(loginAccount.UserName);
            if (numreal > num)
            {
                GioHangDAO.Instance.removeBag(idSach, num, loginAccount.UserName);
            }
            
            /*if (idBag == -1)
            {
                GioHangDAO.Instance.removeBag(idSach, num, loginAccount.UserName);
            }
            else
            {
                GioHangDAO.Instance.removeBag(idSach, num, loginAccount.UserName);
            }*/
            showGioHang();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            ThanhToan();
        }



        #endregion

        private void lịchSửĐơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showFormHistory();
        }
        //Change color menu
        private class renderer : ToolStripProfessionalRenderer
        {
            public renderer() : base(new cols()) { }
        }

        private class cols : ProfessionalColorTable
        {
            public override Color MenuItemSelected
            {
                // when the menu is selected
                get { return Color.DarkGreen; }
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.DarkGreen; }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.DarkGreen; }
            }
        }

    }
}
