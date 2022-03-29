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
    
    public partial class fThongke : Form
    {
        private Account LoginAccount;
        public fThongke(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
            loadlistbillbyDate(dtp1.Value,dtp2.Value);
            loadtong();
        }
        public Account LoginAccount1
        {
            get { return LoginAccount; }
            set { LoginAccount = value; }
        }
        void loadlistbillbyDate(DateTime thoigian1, DateTime thoigian2)
        {

            if (HoadonDAO.Instance.getlistbillbyDate(thoigian1, thoigian2).Rows.Count != 0)
            {
                dgvhoadon.DataSource = HoadonDAO.Instance.getlistbillbyDate(thoigian1, thoigian2);
            }
            else
            {
                MessageBox.Show("ko có");
            }
        }
        //xem thoongs kee tuwf bill
        private void btnxem_Click(object sender, EventArgs e)
        {
            loadlistbillbyDate(dtp1.Value,dtp2.Value);
            loadtong();
            
        }
        //taoj form report
        private void btnreport_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            DateTime thoigian1 = dtp1.Value;
            DateTime thoigian2 = dtp2.Value;

            dt = HoadonDAO.Instance.getlistbillbyDate(thoigian1, thoigian2);
            double tong = HoadonDAO.Instance.SumBill(thoigian1, thoigian2);

            fReport f = new fReport(thoigian1,thoigian2,tong);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
        void loadtong()
        {
            DateTime thoigian1 = dtp1.Value;
            DateTime thoigian2 = dtp2.Value;
            double tong = HoadonDAO.Instance.SumBill(thoigian1,thoigian2);
            textBox1.Text = String.Format("{0:n0}", tong);
            }

        private void fThongke_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

            
        }
    }
    }

