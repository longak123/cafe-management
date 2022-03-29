using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlytrasua.DTO;
using System.Data;

namespace quanlytrasua.DAO
{
    public class HoadonDAO
    {
        //tạo ra một model
        private static HoadonDAO instance;

        public static HoadonDAO Instance
        {
            get { if (instance == null) instance = new HoadonDAO(); return HoadonDAO.instance; }
           private  set { HoadonDAO.instance = value; }
        }

        public HoadonDAO() { }
        //lấy danh sách hóa đơn
        public List<Hoadon> GetListHD()
        {
            List<Hoadon> list = new List<Hoadon>();

            string query = "select * from HOADON";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Hoadon hoadon = new Hoadon(item);
                list.Add(hoadon);
            }

            return list;
        }
        //thêm dữ kiện vào bill
        public bool InsertBill(float tong)
        {

            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBill @tong", new object[] { tong });

            return result > 0;
        }
        //lấy id hóa đơn cao nhất trong bảng hóa đơn
         public int GetMaxIDBill()
        {
             var a = DataProvider.Instance.ExecuteScalar("SELECT MAX(MAHOADON) FROM HOADON");
             if (a.ToString() == "")
             {
                 return 0;
             }
             else
             {
                 return (int)a;
             }
            
         
        }
        //lấy dữ liệu data theo ngày
        public DataTable getlistbillbyDate(DateTime thoigian1, DateTime thoigian2)
         {
            return  DataProvider.Instance.ExecuteQuery("exec USP_GetlistbillbyDate @thoigian1 = '" + thoigian1.ToString("yyyyMMdd") + "', @thoigian2 = '" + thoigian2.ToString("yyyyMMdd") + "'");
         }
        //xóa dữ liệu bảng hóa đơn
        public bool delBill()
        {
            string query = string.Format("DELETE HOADON");
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public double SumBill(DateTime thoigian1, DateTime thoigian2)
        {
            var a = DataProvider.Instance.ExecuteScalar("exec USP_TongHoaDon @thoigian1 ='" + thoigian1.ToString("yyyyMMdd") + "', @thoigian2 = '" + thoigian2.ToString("yyyyMMdd") + "'");
            if (a.ToString() == "")
            {
                return 0;
            }
            else
            {
                return (double)a;
            }
        }
    }
    
}
