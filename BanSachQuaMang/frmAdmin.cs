using BanSachQuaMang.DAO;
using BanSachQuaMang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanSachQuaMang
{
    public partial class frmAdmin : Form
    {
        BindingSource bookList = new BindingSource();
        BindingSource accountList = new BindingSource();
        public Account loginAccount;

        #region Method Total
        public frmAdmin()
        {
            InitializeComponent();

            load();
        }
        void load()
        {
            dtgvAdmin.DataSource = bookList;
            dtgvAccount.DataSource = accountList;

            
            /*loadTacGia();
            loadNhaCungCap();
            loadCongTyPhatHanh();*/
            loadBookList();
            addBookBinding();

            loadTacGiaIntoCombobox(cbTacGia);
            loadNCCIntoCombobox(cbNCC);
            loadCTPHIntoCombobox(cbCTPH);

            loadAccountList();
            addAcountBinding();
            //loadType();
            loadTypeIntoCombobox(cbAccountType);

        }
        
        #endregion

        #region Method Book
        List<Book> searchBookByName(string name)
        {
            List<Book> listBook = BookDAO.Instance.searchBookByName(name);
            return listBook;
        }
        /*void loadTacGia()
        {
            List<TacGia> listTacGia = TacGiaDAO.Instance.getTacGiaList();
            cbTacGia.DataSource = listTacGia;
            cbTacGia.DisplayMember = "TenTG";
        }
        void loadNhaCungCap()
        {
            List<NhaCungCap> listNCC = NhaCungCapDAO.Instance.getNCCList();
            cbNCC.DataSource = listNCC;
            cbNCC.DisplayMember = "TenNCC";
        }
        void loadCongTyPhatHanh()
        {
            List<CongTyPhatHanh> CTPH = CongTyPhatHanhDAO.Instance.getCTPHList();
            cbCTPH.DataSource = CTPH;
            cbCTPH.DisplayMember = "TenCongTy";
        }*/
        void loadBookList()
        {

            /*CultureInfo culture = new CultureInfo("vi-VI");
            Thread.CurrentThread.CurrentCulture = culture;*/
            bookList.DataSource = BookDAO.Instance.loadBookList();


        }
        void addBookBinding()
        {
            txbBookName.DataBindings.Add(new Binding("Text", dtgvAdmin.DataSource, "NameBook", true, DataSourceUpdateMode.Never));
            txbIDAdmin.DataBindings.Add(new Binding("Text", dtgvAdmin.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbPrice.DataBindings.Add(new Binding("Text", dtgvAdmin.DataSource, "Price", true, DataSourceUpdateMode.Never));
            nmNumberPage.DataBindings.Add(new Binding("Value", dtgvAdmin.DataSource, "SoTrang", true, DataSourceUpdateMode.Never));
        }
        void loadTacGiaIntoCombobox(ComboBox cb)
        {
            cb.DataSource = TacGiaDAO.Instance.getTacGiaList();
            cb.DisplayMember = "TenTG";
        }
        void loadNCCIntoCombobox(ComboBox cb)
        {
            cb.DataSource = NhaCungCapDAO.Instance.getNCCList();
            cb.DisplayMember = "TenNCC";

        }
        void loadCTPHIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CongTyPhatHanhDAO.Instance.getCTPHList();
            cb.DisplayMember = "TenCongTy";
        }
        #endregion

        #region Event Book
        private void button1_Click(object sender, EventArgs e)
        {
            loadBookList();
        }
        private void txbIDAdmin_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgvAdmin.SelectedCells.Count > 0)
                {
                    //Combobox Tacgia
                    int idTG = (int)dtgvAdmin.SelectedCells[0].OwningRow.Cells["IDTG"].Value;

                    TacGia tacGia = TacGiaDAO.Instance.getTacGiaByID(idTG);

                    cbTacGia.SelectedItem = tacGia;

                    int indexTG = -1;
                    int iTG = 0;
                    foreach (TacGia item in cbTacGia.Items)
                    {
                        if (item.IDTG == tacGia.IDTG)
                        {
                            indexTG = iTG;
                            break;
                        }
                        iTG++;
                    }
                    cbTacGia.SelectedIndex = indexTG;

                    //Combobox NCC
                    int idNCC = (int)dtgvAdmin.SelectedCells[0].OwningRow.Cells["IDNCC"].Value;

                    NhaCungCap ncc = NhaCungCapDAO.Instance.getNCCByID(idNCC);
                    cbNCC.SelectedItem = ncc;

                    int indexNCC = -1;
                    int iNCC = 0;
                    foreach (NhaCungCap item in cbNCC.Items)
                    {
                        if (item.IDNCC == ncc.IDNCC)
                        {
                            indexNCC = iNCC;
                            break;
                        }
                        iNCC++;
                    }
                    cbNCC.SelectedIndex = indexNCC;

                    //Combobox CongTy
                    int idCT = (int)dtgvAdmin.SelectedCells[0].OwningRow.Cells["IDCongTy"].Value;
                    CongTyPhatHanh congTy = CongTyPhatHanhDAO.Instance.getCTPTByID(idCT);
                    cbCTPH.SelectedItem = congTy;

                    int indexCT = -1;
                    int iCT = 0;

                    foreach (CongTyPhatHanh item in cbCTPH.Items)
                    {
                        if (item.IDCongTy == congTy.IDCongTy)
                        {
                            indexCT = iCT;
                            break;
                        }
                        iCT++;
                    }
                    cbCTPH.SelectedIndex = indexCT;

                }
            }
            catch (Exception)
            {
            }

        }
        private void btnAddAdmin_Click(object sender, EventArgs e)
        {
            string name = txbBookName.Text;
            decimal price = Convert.ToDecimal(txbPrice.Text);
            int idCongTy = (cbCTPH.SelectedItem as CongTyPhatHanh).IDCongTy;
            int idNCC = (cbNCC.SelectedItem as NhaCungCap).IDNCC;
            int idTacGia = (cbTacGia.SelectedItem as TacGia).IDTG;
            int soTrang = (int)nmNumberPage.Value;

            if (BookDAO.Instance.addBook(name, price, soTrang, idCongTy, idNCC, idTacGia))
            {
                MessageBox.Show("Thêm thành công!");
                loadBookList();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm!");
            }

        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            string name = txbBookName.Text;
            decimal price = Convert.ToDecimal(txbPrice.Text);
            int idCongTy = (cbCTPH.SelectedItem as CongTyPhatHanh).IDCongTy;
            int idNCC = (cbNCC.SelectedItem as NhaCungCap).IDNCC;
            int idTacGia = (cbTacGia.SelectedItem as TacGia).IDTG;
            int soTrang = (int)nmNumberPage.Value;
            int id = Convert.ToInt32(txbIDAdmin.Text);

            if (BookDAO.Instance.editBook(id,name, price, soTrang, idCongTy, idNCC, idTacGia))
            {
                MessageBox.Show("Sửa thành công!");
                loadBookList();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi sửa!");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            int id = Convert.ToInt32(txbIDAdmin.Text);

            if (BookDAO.Instance.deleteBook(id))
            {
                MessageBox.Show("Xóa thành công!");
                loadBookList();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi xóa!");
            }
        }
        private void btnSearchAdmin_Click(object sender, EventArgs e)
        {
            bookList.DataSource = searchBookByName(txbSearchAdmin.Text);
        }

        //Tabpage Account



        #endregion

        #region Method Account
        /*void loadType()
        {
            List<AccountType> listType = AccountTypeDAO.Instance.getListAccType();
            cbAccountType.DataSource = listType;
            cbAccountType.DisplayMember = "Name";
        }*/
        void loadAccountList()
        {

            accountList.DataSource = AccountDAO.Instance.getAccountList();

            /*string query = "exec USP_GetAccountByUserName @userName";*/

            /*dtgvAccount.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] { userN });*/

        }
        void addAcountBinding()
        {
            txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "userName", true, DataSourceUpdateMode.Never));
            txbDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "displayName", true, DataSourceUpdateMode.Never));
        }
        void addAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.addAccount(userName, displayName, type))
            {
                MessageBox.Show("Thêm tài khoản thành công!");
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm!");
            }
            loadAccountList();
        }
        void deleteAccount(string userName)
        {
            if (this.loginAccount.UserName.Equals(userName))
            {
                MessageBox.Show("Hey man, đừng xóa chính bạn chứ.");
            }
            else
            {
                if (AccountDAO.Instance.deleteAccount(userName))
                {
                    MessageBox.Show("Xóa tài khoản thành công!");
                }
                else
                {
                    MessageBox.Show("Có lỗi khi xóa!");
                }
                loadAccountList();
            }
        }
        void editAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.editAccount(userName, displayName, type))
            {
                MessageBox.Show("Sửa tài khoản thành công!");
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa!");
            }
            loadAccountList();
        }
        void resetPass(string userName)
        {
            if (AccountDAO.Instance.resetPassWord(userName))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công!");
            }
            else
            {
                MessageBox.Show("Đặt mật khẩu thất bại!");
            }
        }
        void loadTypeIntoCombobox(ComboBox cb)
        {
            cb.DataSource = AccountTypeDAO.Instance.getListAccType();
            cb.DisplayMember = "Name";
        }
        List<Account> seachAccountByUserName(string userName)
        {
            List<Account> list = AccountDAO.Instance.searchAccoutByUserName(userName);
            return list;
        }
        #endregion

        #region Event Account

        private void btnViewAccount_Click(object sender, EventArgs e)
        {
            loadAccountList();
        }
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = (cbAccountType.SelectedItem as AccountType).Type;

            addAccount(userName, displayName, type);
            
        }
        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;

            deleteAccount(userName);
        }
        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = (cbAccountType.SelectedItem as AccountType).Type;

            editAccount(userName, displayName, type);
        }
        private void txbUserName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgvAccount.SelectedCells.Count > 0)
                {
                    int id = (int)dtgvAccount.SelectedCells[0].OwningRow.Cells["type"].Value;
                    AccountType at = AccountTypeDAO.Instance.getAccTypeByID(id);
                    cbAccountType.SelectedItem = at;
                    int index = -1;
                    int i = 0;

                    foreach (AccountType item in cbAccountType.Items)
                    {
                        if (item.Type == at.Type)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbAccountType.SelectedIndex = index;
                }
            }
            catch (Exception)
            {

               
            }
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            resetPass(userName);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {

            accountList.DataSource = seachAccountByUserName(txbSearch.Text);
        }

        private void tpControl_Click(object sender, EventArgs e)
        {

        }
    }
    #endregion


}
