 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlytrasua.DTO;
using System.Data;


namespace quanlytrasua.DAO
{

    public class FoodDAO
    {
        // tạo ra model
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return FoodDAO.instance; }
            private set { FoodDAO.instance = value; }
        }

        private FoodDAO() { }

        /**
       * Hàm lấy danh sách món từ danh mục
       *@param id @id [ID Category]
       *@param Food @Food [Food] 
       *@param list @list [Food List] 
       *@return result
       */

        public List<Food> GetFoodByCategoryID(int id)
        {
            List<Food> list = new List<Food>();

            string query = "select * from DOUONG where MALOAIDOUONG = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return list;
        }


        /**
       * Hàm lấy danh sách món 
       *@param Food @Food [Food] 
       *@param list @list [Food List] 
       *@return result
       */

        public List<Food> GetListFood()
        {
            List<Food> list = new List<Food>();

            string query = "select * from DOUONG";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return list;
        }

        //hàm lấy ra danh sách đồ uống
        public int GetListFoodbyid()
        {
            List<Food> list = new List<Food>();

            string query = "select * from DOUONG";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return -1;
        }
        /**
* Hàm tìm kiếm món 
*@param name @name [Food Name] 
*@return result
*/

        public List<Food> SearchFoodByName(string name)
        {
            List<Food> list = new List<Food>();

            string query = string.Format("select * from DOUONG where [dbo].[fChuyenCoDauThanhKhongDau](TEN) like N'%' +N'{0}'+'%'  ", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return list;
        }

        /**
* Hàm thêm món 
*@param name @name [Food Name] 
*@param id @id [ID] 
*@param price @price [Price] 
*@return result
*/

        public bool InsertFood(string name, int id, float price)
        {
            string query = string.Format("INSERT DOUONG (TEN, MALOAIDOUONG,GIA ) VALUES  ( N'{0}', {1}, {2})", name, id, price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        /**
       * Hàm sửa món 
       *@param idFood @idFood [ID Food] 
       *@param name @name [Food Name] 
       *@param id @id [ID] 
       *@param price @price [Price] 
       *@return result
       */

        public bool UpdateFood(int idFood, string name, int id, float price)
        {
            string query = string.Format("UPDATE DOUONG SET TEN = N'{0}', MALOAIDOUONG = {1}, GIA = {2} WHERE MADU = {3}", name, id, price, idFood);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        /**
        * Hàm xóa món 
        *@param idFood @idFood [ID Food]    
        *@return result
        */


        public bool DeleteFood(int idFood)
        {
            //BillInfoDAO.Instance.DeleteBillInfoByFoodID(idFood);

            string query = string.Format("Delete DOUONG where MADU = {0}", idFood);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }


        // xóa hết tất cả các món
        public bool delallfood()
        {
            string query = string.Format("Delete DOUONG ");
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        //public static object Instance { get; set; }
    }
}

