using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using quanlytrasua.DTO;

namespace quanlytrasua.DAO
{
    class CategoryDAO
    {
        // tạo ra model
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get
            {
                if (instance == null) instance = new CategoryDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private CategoryDAO() { }

        // lấy danh sách loại đồ uống
        public List<Category> GetListCategory()
        {
            List<Category> listCategory = new List<Category>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM LOAIDOUONG");

            foreach (DataRow item in data.Rows)
            {
                Category c = new Category(item);
                listCategory.Add(c);
            }

            return listCategory;
        }
        // lấy loại đồ uống bởi mã loại đồ uống
        public Category GetCategoryByID(int id)
        {
            Category category = null;

            string query = "SELECT * FROM LOAIDOUONG WHERE MALOAIDOUONG = '" + id + "'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
                return category;
            }

            return category;
        }
        // thêm loại đồ uống
        public bool InsertCategory(string name)
        {
            string query = string.Format("INSERT LOAIDOUONG (TENLOAI ) VALUES  (  N'{0}')", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        //cập nhật loại đồ uống
        public bool UpdateCategory( string name, int id)
        {
            string query = string.Format("UPDATE LOAIDOUONG SET TENLOAI = N'{0}' WHERE MALOAIDOUONG = {1}", name, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        //xóa loại đồ uống
        public bool DeleteCategory(int idCategory)
        {
            //BillInfoDAO.Instance.DeleteBillInfoByFoodID(idFood);

            string query = string.Format("Delete LOAIDOUONG where MALOAIDOUONG = {0}", idCategory);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        } 
        //xóa hết loại đồ uống
        public bool delallcategory()
        {
            string query = string.Format("Delete LOAIDOUONG ");
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

    }
}
