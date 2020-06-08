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
        private Account loginAccount;

        public Account LoginAccount 
        { 
            get => loginAccount;
            set 
            {
                loginAccount = value;
            } 
        }

        public frmHome(Account acc)
        {
            InitializeComponent();

            this.loginAccount = acc;
            changeAccount(loginAccount.Type);
            loadBook();
        }
        
        #region Các phương thức
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
            foreach (Book item in bookList)
            {
                /*Button btn = new Button() {Width = BookDAO.Width, Height = BookDAO.Height };
                btn.Text = item.NameBook + Environment.NewLine + item.Price;*/

                /*CheckBox checkBox = new CheckBox() { Width = BookDAO.Width};
                checkBox.Text = item.NameBook + item.Price + Environment.NewLine;
                lvTT.Controls.Add(checkBox);*/

                ListViewItem listViewItem = new ListViewItem(item.NameBook);
                
                listViewItem.SubItems.Add(item.SoTrang.ToString());
                //listViewItem.SubItems.Add(item.TenTG);
                //listViewItem.SubItems.Add(item.TenCongTy);
                listViewItem.SubItems.Add(item.Price.ToString("c"));
                lvTT.Items.Add(listViewItem);


            }
            foreach (Book item in bookList)
            {
                
                ListViewItem listViewItem = new ListViewItem(item.NameBook);

                listViewItem.SubItems.Add(item.SoTrang.ToString());
                //listViewItem.SubItems.Add(item.TenTG);
                //listViewItem.SubItems.Add(item.TenCongTy);
                listViewItem.SubItems.Add(item.Price.ToString("c"));
                
                lvPDB.Items.Add(listViewItem);

            }
        }

        //tạm
        
        #endregion
        #region Các xử lí
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


        #endregion
    }
}
