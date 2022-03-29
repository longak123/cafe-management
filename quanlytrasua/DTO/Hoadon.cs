using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace quanlytrasua.DTO
{
    public class Hoadon
    {
        private int _MAHOADON;

        public int MAHOADON
        {
            get { return _MAHOADON; }
            set { _MAHOADON = value; }
        }
        //kiểu datetime
        private DateTime? _THOIGIAN;

        public DateTime? THOIGIAN
        {
            get { return _THOIGIAN; }
            set { _THOIGIAN = value; }
        }
        private float _TONG;

        public float TONG
        {
            get { return _TONG; }
            set { _TONG = value; }
        }
       
       
      
        public Hoadon(int mahd, DateTime? thoigian, float tong )
        {
            this.MAHOADON = mahd;
            this.THOIGIAN = thoigian;
            this.TONG = tong;
        }
        //lấy dữ liệu từ bảng hóa đơn đổ vào các biến
        public Hoadon(DataRow row)
        {
            this.MAHOADON = (int)row["MAHOADON"];
            this.THOIGIAN = (DateTime?)row["THOIGIAN"];
            this.TONG = (float)row["TONG"];
        }

    }
}
