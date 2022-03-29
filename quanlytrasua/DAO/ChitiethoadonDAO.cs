using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlytrasua.DAO
{
    public class ChitiethoadonDAO
    {
        //tạo ra 1 model
        private static ChitiethoadonDAO instance;

        public static ChitiethoadonDAO Instance
        {
            get { if (instance == null) instance = new ChitiethoadonDAO(); return ChitiethoadonDAO.instance; }
            private set { ChitiethoadonDAO.instance = value; }
        }
        //thêm các thành phần vào chi tiết hóa đơn
        public ChitiethoadonDAO() { }
        public void InsertBillInfo(int idBill, int idFood, int count)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_InsertBillInfo @idBill , @idFood , @count", new object[] { idBill, idFood, count });
        }
        //xóa dữ liệu trong bảng chi tiết hóa đơn
        public bool delBillinfo()
        {
            string query = string.Format("DELETE CHITIETHOADON");
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public int GetMaxIDinfoBill()
        {
            try
            {
              int i = (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(MAHOADON) FROM CHITIETHOADON");
              return i;
            }
            catch
            {
                return 1;
            }
        }
    }
}
