using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace quanlytrasua.DTO
{

    public class Food
    {
        public int iD;
        public string name;
        public int iDCategory;
        public float price;

        public Food(int _id, string _name, int _idcategory, float _price)
        {
            this.ID = _id;
            this.Name = _name;
            this.IDCategory = _idcategory;
            this.Price = _price;
        }
        //lấy dữ liệu từ bảng đồ uống đổ vào các biến
        public Food(DataRow row)
        {
            this.ID = (int)row["MADU"];
            this.Name = row["TEN"].ToString();
            this.IDCategory = (int)row["MALOAIDOUONG"];
            this.Price = (float)Convert.ToDouble(row["GIA"].ToString());
        }

        public Food(DataRow row, string a)
        {
            this.Name = row["TEN"].ToString();
            this.Price = (float)Convert.ToDouble(row["GIA"].ToString());
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

        public int IDCategory
        {
            get
            {
                return iDCategory;
            }

            set
            {
                iDCategory = value;
            }
        }

        public float Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }
    }

    
}
