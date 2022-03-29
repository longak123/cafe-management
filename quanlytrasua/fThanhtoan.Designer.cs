namespace quanlytrasua
{
    partial class fThanhtoan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fThanhtoan));
            this.USP_TableBillBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PHANMEMBANTRASUADataSet3 = new quanlytrasua.PHANMEMBANTRASUADataSet3();
            this.USP_GetlistcountFoodBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PHANMEMBANTRASUADataSet1 = new quanlytrasua.PHANMEMBANTRASUADataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.USP_GetlistcountFoodTableAdapter = new quanlytrasua.PHANMEMBANTRASUADataSet1TableAdapters.USP_GetlistcountFoodTableAdapter();
            this.USP_TableBillTableAdapter = new quanlytrasua.PHANMEMBANTRASUADataSet3TableAdapters.USP_TableBillTableAdapter();
            this.PHANMEMBANTRASUADataSet4 = new quanlytrasua.PHANMEMBANTRASUADataSet4();
            ((System.ComponentModel.ISupportInitialize)(this.USP_TableBillBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PHANMEMBANTRASUADataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_GetlistcountFoodBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PHANMEMBANTRASUADataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PHANMEMBANTRASUADataSet4)).BeginInit();
            this.SuspendLayout();
            // 
            // USP_TableBillBindingSource
            // 
            this.USP_TableBillBindingSource.DataMember = "USP_TableBill";
            this.USP_TableBillBindingSource.DataSource = this.PHANMEMBANTRASUADataSet3;
            // 
            // PHANMEMBANTRASUADataSet3
            // 
            this.PHANMEMBANTRASUADataSet3.DataSetName = "PHANMEMBANTRASUADataSet3";
            this.PHANMEMBANTRASUADataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // USP_GetlistcountFoodBindingSource
            // 
            this.USP_GetlistcountFoodBindingSource.DataMember = "USP_GetlistcountFood";
            this.USP_GetlistcountFoodBindingSource.DataSource = this.PHANMEMBANTRASUADataSet1;
            // 
            // PHANMEMBANTRASUADataSet1
            // 
            this.PHANMEMBANTRASUADataSet1.DataSetName = "PHANMEMBANTRASUADataSet1";
            this.PHANMEMBANTRASUADataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.USP_TableBillBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "quanlytrasua.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(625, 386);
            this.reportViewer1.TabIndex = 0;
            // 
            // USP_GetlistcountFoodTableAdapter
            // 
            this.USP_GetlistcountFoodTableAdapter.ClearBeforeFill = true;
            // 
            // USP_TableBillTableAdapter
            // 
            this.USP_TableBillTableAdapter.ClearBeforeFill = true;
            // 
            // PHANMEMBANTRASUADataSet4
            // 
            this.PHANMEMBANTRASUADataSet4.DataSetName = "PHANMEMBANTRASUADataSet4";
            this.PHANMEMBANTRASUADataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fThanhtoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 386);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fThanhtoan";
            this.Text = "Thanh Toán";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.fThanhtoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.USP_TableBillBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PHANMEMBANTRASUADataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_GetlistcountFoodBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PHANMEMBANTRASUADataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PHANMEMBANTRASUADataSet4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource USP_GetlistcountFoodBindingSource;
        private PHANMEMBANTRASUADataSet1 PHANMEMBANTRASUADataSet1;
        private PHANMEMBANTRASUADataSet1TableAdapters.USP_GetlistcountFoodTableAdapter USP_GetlistcountFoodTableAdapter;
        private System.Windows.Forms.BindingSource USP_TableBillBindingSource;
        private PHANMEMBANTRASUADataSet3 PHANMEMBANTRASUADataSet3;
        private PHANMEMBANTRASUADataSet3TableAdapters.USP_TableBillTableAdapter USP_TableBillTableAdapter;
        private PHANMEMBANTRASUADataSet4 PHANMEMBANTRASUADataSet4;

    }
}