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
    public partial class fthongtintaikhoan : Form
    {
        //tạo ra đối tượng tài khoản
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }
        //đưa đối tượng tài khoản vào trong form
        public fthongtintaikhoan(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
        }
        //hàm thay đổi tài khoản
        void ChangeAccount(Account acc)
        {
            txttendangnhap.Text = LoginAccount.UserName;
           txttenhienthi.Text = LoginAccount.DisplayName;
        }
        //cập nhật tài khoản
        void UpdateAccountInfo()
        {
            string userName = txttendangnhap.Text;
            string password = txtmatkhau.Text;
            string newpass = txtmatkhaumoi.Text;
            string reenterPass = txtnhaplai.Text;
            string displayName = txttenhienthi.Text;

            if (!newpass.Equals(reenterPass))//check mật khẩu mới với lần nhập lại mật khẩu có giống không
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới!");
            }
            else//nếu giống thì thực hiện các nhiệm vụ cập nhật
            {
                if (AccountDAO.Instance.UpdateAccount(userName, displayName, password, newpass))
                {
                    MessageBox.Show("Cập nhật thành công");
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đúng mật khấu");
                }
            }
        }
        //button cập nhật
        private void btnupdate_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
            this.txtnhaplai.Clear();
            this.txtmatkhaumoi.Clear();
            this.txtmatkhau.Clear();
        }
        //button thoát
        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cPass_CheckedChanged(object sender, EventArgs e)
        {
            txtmatkhau.UseSystemPasswordChar =! txtmatkhau.UseSystemPasswordChar;
            txtmatkhaumoi.UseSystemPasswordChar = !txtmatkhaumoi.UseSystemPasswordChar;
            txtnhaplai.UseSystemPasswordChar = !txtnhaplai.UseSystemPasswordChar;
        }
    }
}
