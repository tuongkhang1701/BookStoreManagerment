using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanSachQuaMang.DTO
{
    public class Book
    {
        public Book(int id ,string nameBook, int soTrang, decimal price, string tenTG, string tenCongTy, string TenNCC, int soLuong)
        {
            this.iD = id;
            this.nameBook = nameBook;
            this.Price = price;
            this.SoTrang = soTrang;
            this.TenTG = tenTG;
            this.TenCongTy = tenCongTy;
            this.TenNCC = tenNCC;
            this.SoLuong = soLuong;
            /*this.IDTG = idTG;
            this.IDNCC = idNCC;
            this.IDCongTy = idCongTy;*/
        }

        public Book(DataRow row)
        {
            this.ID = (int)row["IDSach"];
            this.NameBook = row["TenSach"].ToString();
            this.Price = Convert.ToDecimal(row["DonGia"]);
            this.SoTrang = (int)row["SoTrang"];
            this.TenTG = row["TenTG"].ToString();
            this.TenCongTy = row["TenCongTy"].ToString();
            this.TenNCC = row["TenNCC"].ToString();
            this.SoLuong = (int)row["SoLuong"];
            /*this.IDTG = (int)row["IDTG"];
            this.IDNCC = (int)row["IDNCC"];
            this.IDCongTy = (int)row["IDCongTy"];*/

        }
        private string tenNCC;
        private string tenCongTy;
        private int soTrang;
        private string tenTG;
        private decimal price;
        private string nameBook;
        private int soLuong;
        private int iD;
        /*private int iDTG;
        private int iDNCC;
        private int iDCongTy;*/

        public int ID { get => iD; set => iD = value; }
        public string NameBook { get => nameBook; set => nameBook = value; }
        public decimal Price { get => price; set => price = value; }
        public string TenTG { get => tenTG; set => tenTG = value; }
        public int SoTrang { get => soTrang; set => soTrang = value; }
        /*public int IDTG { get => iDTG; set => iDTG = value; }
        public int IDNCC { get => iDNCC; set => iDNCC = value; }
        public int IDCongTy { get => iDCongTy; set => iDCongTy = value; }*/
        public string TenCongTy { get => tenCongTy; set => tenCongTy = value; }
        public string TenNCC { get => tenNCC; set => tenNCC = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
    }
}
