using BanSachQuaMang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanSachQuaMang.DAO
{
    public class BookDAO
    {
        private  static BookDAO instance;

        public static BookDAO Instance 
        {
            get { if (instance == null) instance = new BookDAO(); return BookDAO.instance; }
            private set { BookDAO.instance = value; }
        }
        /*public static int Width = 590;
        public static int Height = 90;*/

        public List<Book> loadBookList() 
        {
            List<Book> bookList = new List<Book>();
            string query = "select * from Sach";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Book book = new Book(item);

                bookList.Add(book);
            }
            return bookList;
        }
        public bool addBook(string name, decimal price, int soTrang, int idCongTy, int idNCC, int idTacGia)
        {
            string query = string.Format("insert into Sach(TenSach, DonGia, SoTrang, IDCongTy, IDNCC, IDTG) values(N'{0}', {1}, {2}, {3}, {4}, {5})", name, price, soTrang, idCongTy, idNCC, idTacGia);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0; 
        }
        public bool editBook(int id, string name, decimal price, int soTrang, int idCongTy, int idNCC, int idTacGia)
        {
            string query = string.Format("update Sach set TenSach = N'{0}', DonGia = {1}, SoTrang = {2}, IDCongTy = {3}, IDNCC = {4}, IDTG = {5} where IDSach = {6}", name, price, soTrang, idCongTy, idNCC, idTacGia, id);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool deleteBook(int id)
        {
            string query = "delete Sach where IDSach = " + id;

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public List<Book> searchBookByName(string name)
        {
            List<Book> bookList = new List<Book>();
            string query = string.Format("select * from Sach where dbo.fuConvertToUnsign1(TenSach) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Book book = new Book(item);
                bookList.Add(book);

            }
            return bookList;
        }
    }
}
