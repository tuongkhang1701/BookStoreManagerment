using BanSachQuaMang.DAO;
using BanSachQuaMang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        BindingSource tacGiaList = new BindingSource();
        BindingSource NCCList = new BindingSource();
        BindingSource CTPHList = new BindingSource();
        public Account loginAccount;

        public frmAdmin()
        {
            InitializeComponent();

            load();
        }
        void load()
        {
            dtgvAdmin.Anchor = AnchorStyles.Top;
            dtgvAdmin.Anchor = AnchorStyles.Left;
            dtgvAdmin.Dock = DockStyle.Fill;
            dtgvAdmin.DataSource = bookList;

            dtgvAccount.Anchor = AnchorStyles.Top;
            dtgvAccount.Anchor = AnchorStyles.Left;
            dtgvAccount.Dock = DockStyle.Fill;
            dtgvAccount.DataSource = accountList;

            dtgvTG.Anchor = AnchorStyles.Top;
            dtgvTG.Anchor = AnchorStyles.Left;
            dtgvTG.Dock = DockStyle.Fill;
            dtgvTG.DataSource = tacGiaList;

            dtgvNCC.Anchor = AnchorStyles.Top;
            dtgvNCC.Anchor = AnchorStyles.Left;
            dtgvNCC.Dock = DockStyle.Fill;
            dtgvNCC.DataSource = NCCList;

            dtgvCTPH.Anchor = AnchorStyles.Top;
            dtgvCTPH.Anchor = AnchorStyles.Left;
            dtgvCTPH.Dock = DockStyle.Fill;
            dtgvCTPH.DataSource = CTPHList;


            /*loadTacGia();
            loadNhaCungCap();
            loadCongTyPhatHanh();*/
            loadBookList();
            addBinding();

            loadTacGiaIntoCombobox(cbTacGia);
            loadNCCIntoCombobox(cbNCC);
            loadCTPHIntoCombobox(cbCTPH);

            loadAccountList();
            loadTypeIntoCombobox(cbAccountType);

            loadTacGiaList();

            loadNCCList();

            loadCTPHList();

        }


        #region Method Book
        List<Book> searchBookByName(string name)
        {
            List<Book> listBook = BookDAO.Instance.searchBookByName(name);
            return listBook;
        }

        void loadBookList()
        {

            /*CultureInfo culture = new CultureInfo("vi-VI");
            Thread.CurrentThread.CurrentCulture = culture;*/
            bookList.DataSource = BookDAO.Instance.loadBookList();


        }
        void addBinding()
        {
            //Binding Book
            txbBookName.DataBindings.Add(new Binding("Text", dtgvAdmin.DataSource, "NameBook", true, DataSourceUpdateMode.Never));
            txbIDAdmin.DataBindings.Add(new Binding("Text", dtgvAdmin.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbPrice.DataBindings.Add(new Binding("Text", dtgvAdmin.DataSource, "Price", true, DataSourceUpdateMode.Never));
            nmNumberPage.DataBindings.Add(new Binding("Value", dtgvAdmin.DataSource, "SoTrang", true, DataSourceUpdateMode.Never));

            //Binding Account
            txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "userName", true, DataSourceUpdateMode.Never));
            txbDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "displayName", true, DataSourceUpdateMode.Never));

            //Binding TacGia
            txbTG.DataBindings.Add(new Binding("Text", dtgvTG.DataSource, "TenTG", true, DataSourceUpdateMode.Never));

            ////Binding Nhà cung cấp
            txbNCC.DataBindings.Add(new Binding("Text", dtgvNCC.DataSource, "TenNCC", true, DataSourceUpdateMode.Never));

            ////Binding cÔNG TY PHÁT HÀNH
            txbCTPH.DataBindings.Add(new Binding("Text", dtgvCTPH.DataSource, "TenCongTy", true, DataSourceUpdateMode.Never));
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

            if (BookDAO.Instance.editBook(id, name, price, soTrang, idCongTy, idNCC, idTacGia))
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

        #endregion

        #region Methods Doanh Thu
        void showDoanhThu(DateTime fromDate, DateTime toDate)
        {
            dtgvDoanhThu.DataSource = HoaDonDAO.Intance.getDoanhThu(fromDate, toDate);
        }
        #endregion

        #region Event Doanh Thu

        private void btnBillView_Click(object sender, EventArgs e)
        {
            showDoanhThu(dtpkFromDate.Value, dtpkToDate.Value);
        }
        #endregion

        #region method TacGia
        void loadTacGiaList()
        {
            tacGiaList.DataSource = TacGiaDAO.Instance.getTacGiaList();
        }
        void addTacGia(string name)
        {
            if (TacGiaDAO.Instance.getTacGiaByName(name))
            {
                MessageBox.Show("Tên tác giả đã tồn tại, vui lòng nhập lại!");
            }
            else
            {
                if (TacGiaDAO.Instance.insertTG(name))
                {
                    MessageBox.Show("Thêm tác giả thành công!");
                    loadTacGiaList();
                }
                else
                    MessageBox.Show("Có lỗi xảy ra!");
            }
        }
        void searchTGByName(string name)
        {
            tacGiaList.DataSource = TacGiaDAO.Instance.searchTGByUserName(name);
        }
        #endregion

        #region Events Tác giả
        private void btnShowTG_Click(object sender, EventArgs e)
        {
            loadTacGiaList();
        }

        private void btnAddTG_Click(object sender, EventArgs e)
        {

            addTacGia(txbTG.Text);
        }

        private void btnSearchTG_Click(object sender, EventArgs e)
        {
            searchTGByName(txbSearchTG.Text);
        }
        private void btnDeleteTG_Click(object sender, EventArgs e)
        {
            int id = (int)dtgvTG.SelectedCells[0].OwningRow.Cells["IDTG"].Value;

            if (TacGiaDAO.Instance.deleteTG(id))
            {
                MessageBox.Show("Xóa tác giả thành công!");
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa!");
            }
            loadTacGiaList();
        }

        private void btnEditTG_Click(object sender, EventArgs e)
        {
            int id = (int)dtgvTG.SelectedCells[0].OwningRow.Cells["IDTG"].Value;
            string tenTG = txbTG.Text;

            if (TacGiaDAO.Instance.editTG(id, tenTG))
            {
                MessageBox.Show("Sửa tác giả thành công!");
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa!");
            }
            loadTacGiaList();
        }
        #endregion

        #region Methods Nhà cung cấp
        void loadNCCList()
        {
            NCCList.DataSource = NhaCungCapDAO.Instance.getNCCList();
        }
        void addNCC(string name)
        {
            if (NhaCungCapDAO.Instance.getNCCByName(name))
            {
                MessageBox.Show("Tên nhà cung cấp đã tồn tại, vui lòng nhập lại!");
            }
            else
            {
                if (NhaCungCapDAO.Instance.insertNCC(name))
                {
                    MessageBox.Show("Thêm tác giả thành công!");
                    loadNCCList();
                }
                else
                    MessageBox.Show("Có lỗi xảy ra!");
            }
        }
        void searchNCCByName(string name)
        {
            NCCList.DataSource = NhaCungCapDAO.Instance.searchNCCByUserName(name);
        }

        void deleteNCC(int id)
        {
            if (NhaCungCapDAO.Instance.deleteNCC(id))
            {
                MessageBox.Show("Xóa nhà cung cấp thành công!");
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa!");
            }
            loadNCCList();
        }

        #endregion

        #region Events NCC
        private void btnAddNCC_Click(object sender, EventArgs e)
        {
            string tenNCC = txbNCC.Text;
            addNCC(tenNCC);
        }

        private void btnDeleteNCC_Click(object sender, EventArgs e)
        {
            int id = (int)dtgvNCC.SelectedCells[0].OwningRow.Cells["IDCTPH"].Value;
            deleteNCC(id);
        }

        private void btnEditNCC_Click(object sender, EventArgs e)
        {
            int id = (int)dtgvNCC.SelectedCells[0].OwningRow.Cells["IDCTPH"].Value;
            string tenNCC = txbNCC.Text;

            if (NhaCungCapDAO.Instance.editNCC(id, tenNCC))
            {
                MessageBox.Show("Sửa tác giả thành công!");
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa!");
            }
            loadNCCList();
        }

        private void btnViewNCC_Click(object sender, EventArgs e)
        {
            loadNCCList();
        }

        private void btnSearchNCC_Click(object sender, EventArgs e)
        {
            string tenNCC = txbSearchNCC.Text;
            searchNCCByName(tenNCC);
        }

        #endregion

        #region Methods Công ty phát hành
        void loadCTPHList()
        {

            CTPHList.DataSource = CongTyPhatHanhDAO.Instance.getCTPHList();
        }
        void addCTPH(string name)
        {
            if (CongTyPhatHanhDAO.Instance.getCTPHByName(name))
            {
                MessageBox.Show("Tên nhà cung cấp đã tồn tại, vui lòng nhập lại!");
            }
            else
            {
                if (CongTyPhatHanhDAO.Instance.insertCTPH(name))
                {
                    MessageBox.Show("Thêm tác giả thành công!");
                    loadCTPHList();
                }
                else
                    MessageBox.Show("Có lỗi xảy ra!");
            }
        }
        void searchCTPHByName(string name)
        {
            CTPHList.DataSource = CongTyPhatHanhDAO.Instance.searchCTPHByUserName(name);
        }

        void deleteCTPH(int id)
        {
            if (CongTyPhatHanhDAO.Instance.deleteCTPH(id))
            {
                MessageBox.Show("Xóa công ty phát hành thành công!");
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa!");
            }
            loadCTPHList();
        }

        #endregion

        #region Events Công ty phát hành
        private void btnAddCTPH_Click(object sender, EventArgs e)
        {
            string tenCTPH = txbCTPH.Text;
            addCTPH(tenCTPH);
        }

        private void btnDeleteCTPH_Click(object sender, EventArgs e)
        {
            int id = (int)dtgvCTPH.SelectedCells[0].OwningRow.Cells["IDCongTy"].Value;
            deleteCTPH(id);
        }

        private void btnEditCTPH_Click(object sender, EventArgs e)
        {
            int id = (int)dtgvCTPH.SelectedCells[0].OwningRow.Cells["IDCongTy"].Value;
            string tenCTPH = txbCTPH.Text;

            if (CongTyPhatHanhDAO.Instance.editCTPH(id, tenCTPH))
            {
                MessageBox.Show("Sửa công ty phát hành thành công!");
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa!");
            }
            loadCTPHList();
        }

        private void btnViewCTPH_Click(object sender, EventArgs e)
        {
            loadCTPHList();
        }

        private void btnSearchCTPH_Click(object sender, EventArgs e)
        {
            string tenCTPH = txbSearchCTPH.Text;
            searchCTPHByName(tenCTPH);
        }
        #endregion

    }





}
