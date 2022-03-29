using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace quanlytrasua.DTO
{
    class Category
    {
        private int iD;
        private string name;

        public Category(int _id, string _name)
        {
            this.ID = _id;
            this.Name = _name;
        }
        //lấy dữ liệu từ bảng loại đồ uống đổ vào các biến
        public Category(DataRow row)
        {
            this.ID = (int)row["MALOAIDOUONG"];
            this.Name = row["TENLOAI"].ToString();
        }

        public int ID
        {
            get
            {
                return iD;
            }

            set
            {
                iD = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
    }
}
