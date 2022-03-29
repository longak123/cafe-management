using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace quanlytrasua.DTO
{
        public class Account
        {
            private string userName;
            private string displayName;
            private string passWord;
            private int type;

            public Account(string _username, string _displayname, string _password, int _type)
            {
                this.UserName = _username;
                this.DisplayName = _displayname;
                this.PassWord = _password;
                this.Type = _type;
            }
            //lấy dữ liệu từ bảng tài khoản đổ vào các biến
            public Account(DataRow row)
            {
                this.UserName = row["TENTAIKHOAN"].ToString();
                this.DisplayName = row["TENHIENTHI"].ToString();
                this.PassWord = row["MATKHAU"].ToString();
                this.Type = (int)row["LOAITK"];
            }


            public string UserName
            {
                get
                {
                    return userName;
                }

                set
                {
                    userName = value;
                }
            }

            public string DisplayName
            {
                get
                {
                    return displayName;
                }

                set
                {
                    displayName = value;
                }
            }

            public string PassWord
            {
                get
                {
                    return passWord;
                }

                set
                {
                    passWord = value;
                }
            }

            public int Type
            {
                get
                {
                    return type;
                }

                set
                {
                    type = value;
                }
            }
        }
    }
