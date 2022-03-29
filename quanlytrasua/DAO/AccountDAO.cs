using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using quanlytrasua.DTO;

namespace quanlytrasua.DAO
{
    class AccountDAO
    {
        // đặt ra một model
         private static AccountDAO instance;

        public static AccountDAO Instance// gọi phương thức toàn cục
        {
            get
            {
                if (instance == null) instance = new AccountDAO();//nếu instance không có thì instance được tạo
                return instance; // trả về instance
            }

            private set
            {
                instance = value;// truyền giấ trị vào trong instance
            }
        }

        private AccountDAO() { }//gọi ra phương thức không truyền tham số

        // hàm nhập tài khoản
        public bool Login(string username,string password)
        {
            string query = "USP_Login @userName , @passWord";//gọi ra proc trong database
            DataTable result = DataProvider.Instance.ExecuteQuery(query,new object[] { username,password});// thực hiện câu lệnh 
            return result.Rows.Count > 0;//trả về số dòng thực hiện đc lớn hơn 0
        }
        // cập nhật tài khoản
        public bool UpdateAccount(string userName, string displayName, string pass, string newPass)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @userName , @displayName , @password , @newPassword ", new object[] { userName, displayName, pass, newPass });//hàm cập nhật mật khẩu với các giá trị đưa vào
                return result >0; //trả về giá trị lớn hơn không
           
        }

        
        //lấy tài khoản bởi tên tài khoản
        public Account GetAccountByUserName(string username)
        {

            string query = " SELECT * FROM TAIKHOAN WHERE TENTAIKHOAN =  '" + username + "'";//lấy ra tài khoản bởi tên username
            DataTable data = DataProvider.Instance.ExecuteQuery(query);// đưa dữ liệu vào trong data

            foreach (DataRow item in data.Rows)//cho chạy các dòng trong data
            {
                return new  Account(item);// trả về một account mới chứa dữ liệu của data đó
            }
            return null;// trả về giá trị null
        }
        // lấy danh sách tài khoản
        public List<Account> Getlistaccount()
        {
            List<Account> listAccount = new List<Account>();// tạo một list account mới

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM TAIKHOAN");// lâý dữ liệu trong bảng tài khoản đổ vào data

            foreach (DataRow item in data.Rows)// cho chạy các dòng trong data
            {
               Account c = new Account(item);//đưa giá trị của dòng vào trong đối tượng account
               listAccount.Add(c);//đưa account vào trong list
            }

            return listAccount;//trả về danh sách account
        }
        // thêm tài khoản
        public bool InsertTK(string tentk, string tenhienthi, string matkhau,int loaitk)
        {

            string query = string.Format("INSERT TAIKHOAN ( TENTAIKHOAN, TENHIENTHI, MATKHAU,LOAITK ) VALUES  ( N'{0}', N'{1}', N'{2}',{3})", tentk, tenhienthi, matkhau,loaitk);// hàm thêm tài khoản vào trong csdl
            int result = DataProvider.Instance.ExecuteNonQuery(query);// trả về kết quả số đòng được thực hiện

            return result > 0;// trả về kết quả lớn hơn không
        }
        //cập nhật tài khoản
        public bool updateTK(string tentk, string tenhienthi, string matkhau,int loaitk)
        {

            string query = string.Format("UPDATE TENTK = N'{0}' ,TENHIENTHI = N'{1}', MATKHAU = N'{2}' where LOAITK = {3} ", tentk,tenhienthi, matkhau,loaitk);// hàm cập nhật tài khoản vào csdl
            int result = DataProvider.Instance.ExecuteNonQuery(query);// trả về kết quả số dòng thực hiện đc

            return result > 0;// trả về kết quả lớn hơn không 
        }
        //xóa tài khoản
        public bool DeleteTK( string tentk)
        {

            string query = string.Format(" Delete TAIKHOAN where TENTAIKHOAN = N'{0}' ", tentk);//xóa tài khoản khi có tên trùng với tên trong csdl
            int result = DataProvider.Instance.ExecuteNonQuery(query);// thực hiện câu lệnh trả ra kết quả số dòng thực hiện

            return result > 0;// trả về kết quả giá trị lớn hơn không
        }
        //xóa hết tài khoản nhân viên
        public bool Delallaccount()
        {
            string query = string.Format("delete TAIKHOAN where LOAITK = 0");// thực hiện câu lệnh xóa hết tài khoản loại 0 trong bảng
            int result = DataProvider.Instance.ExecuteNonQuery(query);// đưa ra kêt quả

            return result > 0;// trả về kết quả lớn hơn 0
        }


    }
}
