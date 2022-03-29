using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace quanlytrasua.DAO
{
    class DataProvider
    {
        // tạo ra một singal thon(biến toàn cục)
        private static DataProvider instance;
      //  string connectionSTR = @"workstation id=MiniTea.mssql.somee.com;packet size=4096;user id=dqhuy711_SQLLogin_1;pwd=mbf9zjp59v;data source=MiniTea.mssql.somee.com;persist security info=False;initial catalog=MiniTea";
        string connectionSTR = @"Data Source=.\SQLEXPRESS;Initial Catalog=PHANMEMBANTRASUA;Integrated Security=True";
        // Khởi tạo tính đóng gói : Ctrl + R + E
        public static DataProvider Instance
        {
            get
            {
                if(instance == null) { instance = new DataProvider(); };// nếu cái singal thon này null thì tạo một singal thon
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        // Tạo hàm dựng contructor
        private DataProvider()
        {

        }
        public DataTable ExecuteQuery(string query,object[] parameter = null)
        {
            DataTable data = new DataTable();
            //tạo ra một datatable
            using (SqlConnection connection = new SqlConnection(connectionSTR)) {
                connection.Open();
                // kết nối database và mở cổng kết nối
                SqlCommand command = new SqlCommand(query, connection);// lệnh để gọi vào trong database
                if(parameter != null)
                {// nếu parameter không null thì thực hiện
                    string[] listPara = query.Split(' ');// một danh sách đối tượng được ngăn cách bởi khoản không
                    int i = 0;
                    foreach(string item in listPara)
                    {
                        if (item.Contains('@'))// nếu có item có chưa @
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);// lệnh command sẽ add các thành phần này vào paramater
                            i++;
                        }
                    }
                }
                
                SqlDataAdapter adapter = new SqlDataAdapter(command);// lấy data từ lệnh command
                adapter.Fill(data);// sẽ bỏ dữ liệu vào datatable
                connection.Close();//đóng kết nối csdl

                
            }

            return data;// trả về dữ liệu datatable

        }

        // Đếm số dòng thành công
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;//khai báo biến data

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();//dòng lệnh đếm dố dòng thành công rồi bỏ vào data
                connection.Close();


            }

            return data;

        }
        // Trả về đối tượng cột đầu tiên của dòng
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;// khai báo đối tượng bằng 0

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteScalar();// thực hiện dòng lệnh trả về đối tượng đầu tiên của dòng
                connection.Close();
            }

            return data;
        }
    }
}
