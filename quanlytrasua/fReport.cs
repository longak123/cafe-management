using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlytrasua
{
    public partial class fReport : Form
    {
        private DateTime thoigian1;

        public DateTime Thoigian1
        {
            get { return thoigian1; }
            set { thoigian1 = value; }
        }
        private DateTime thoigian2;

        public DateTime Thoigian2
        {
            get { return thoigian2; }
            set { thoigian2 = value; }
        }
        private double tonghd;

        public double Tonghd
        {
            get { return tonghd; }
            set { tonghd = value; }
        }
        public fReport(DateTime tg1, DateTime tg2,double tong)
        {
            InitializeComponent();
            this.thoigian1 = tg1;
            this.thoigian2 = tg2;
            this.tonghd = tong;
        }

        private void fReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'PHANMEMBANTRASUADataSet2.USP_GetlistbillbyDate' table. You can move, or remove it, as needed.
            this.USP_GetlistbillbyDateTableAdapter.Fill(this.PHANMEMBANTRASUADataSet2.USP_GetlistbillbyDate,thoigian1,thoigian2);
            String.Format("{0:M/d/yyyy}", thoigian1);
            String.Format("{0:M/d/yyyy}", thoigian2);  
            ReportParameter time1 = new ReportParameter("TimeBf", thoigian1.ToString("dd/MM/yyyy"));
            reportViewer1.LocalReport.SetParameters(time1);
            ReportParameter time2 = new ReportParameter("TimeFr", thoigian2.ToString("dd/MM/yyyy"));
            reportViewer1.LocalReport.SetParameters(time2);
            ReportParameter tong = new ReportParameter("Tong", String.Format("{0:n0}",tonghd));// tonghd.ToString());
            reportViewer1.LocalReport.SetParameters(tong);
            //999999
            //999,999

            //1234.56
            //1,234.56
            this.reportViewer1.RefreshReport();
        }
    }
}
