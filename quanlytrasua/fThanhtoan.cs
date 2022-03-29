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
using Microsoft.Reporting.WinForms;

namespace quanlytrasua
{
    public partial class fThanhtoan : Form
    {
        private float tong;

        public float Tong
        {
            get { return tong; }
            set { tong = value; }
        }
        public fThanhtoan(float tong)
        {
            InitializeComponent();
            this.tong = tong;
        }

        private void fThanhtoan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'PHANMEMBANTRASUADataSet3.USP_TableBill' table. You can move, or remove it, as needed.
            //this.USP_TableBillTableAdapter.Fill(this.PHANMEMBANTRASUADataSet3.USP_TableBill);
            // TODO: This line of code loads data into the 'PHANMEMBANTRASUADataSet1.USP_GetlistcountFood' table. You can move, or remove it, as needed.
            int i = HoadonDAO.Instance.GetMaxIDBill();
           // this.USP_GetlistcountFoodTableAdapter.Fill(this.PHANMEMBANTRASUADataSet1.USP_GetlistcountFood,i);
            this.USP_TableBillTableAdapter.Fill(this.PHANMEMBANTRASUADataSet3.USP_TableBill,i);
            ReportParameter rmp = new ReportParameter("tong",String.Format("{0:0,0 vnđ}",tong));
            reportViewer1.LocalReport.SetParameters(rmp);
            this.reportViewer1.RefreshReport();
        }
    }
}
