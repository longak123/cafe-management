using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using quanlytrasua.DAO;
using quanlytrasua.DTO;

namespace quanlytrasua
{
    public partial class flogin : Form
    {
        public flogin()
        {
            InitializeComponent();
        }
        //button đăng nhập
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtlogin.Text;
            string passWord = txtpass.Text;

            
            if (Login(userName, passWord))
            {
                Account accountLogin = AccountDAO.Instance.GetAccountByUserName(userName);
                fmenu f = new fmenu(accountLogin);
                this.Hide();
                f.ShowDialog();
        //        this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
            }
        }
        //hàm đăng nhập
        bool Login(string username, string password)
        {
            return AccountDAO.Instance.Login(username, password);
        }
        //hàm thoát
        private void btnExxit_Click(object sender, EventArgs e)
        {
          this.Close();
        }

        private void flogin_Load(object sender, EventArgs e)
        {

        }
        //sự kiện thoát khi nhấn button thoát
        

       

        private void raPass_CheckedChanged_1(object sender, EventArgs e)
        {
            txtpass.UseSystemPasswordChar = !txtpass.UseSystemPasswordChar;
        }

        
    }
}
