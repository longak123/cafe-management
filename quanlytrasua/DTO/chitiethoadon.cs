using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace quanlytrasua.DTO
{
    public class chitiethoadon
    {

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private int _MAHOADON;

        public int MAHOADON
        {
            get { return _MAHOADON; }
            set { _MAHOADON = value; }
        }
        private int _MADOUONG;

        public int MADOUONG
        {
            get { return _MADOUONG; }
            set { _MADOUONG = value; }
        }

     

        private int _SOLUONG;

        public int SOLUONG
        {
            get { return _SOLUONG; }
            set { _SOLUONG = value; }
        }

       

        public chitiethoadon(int id, int mahd, int madouong, int soluong)
        {
            this.ID = id;
            this.MAHOADON = mahd;
            this.MADOUONG = madouong;
            this.SOLUONG = soluong;
        }
        //lấy dữ liệu từ bảng chi tiết hóa đơn đổ vào các biến
        public chitiethoadon(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.MAHOADON = (int)row["MAHOADON"];
            this.MADOUONG = (int)row["MADU"];
            this.SOLUONG = (int)row["SOLUONG"];
        }
    }
}
