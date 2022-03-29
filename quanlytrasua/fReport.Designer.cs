namespace quanlytrasua
{
    partial class fReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fReport));
            this.USP_GetlistbillbyDateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PHANMEMBANTRASUADataSet2 = new quanlytrasua.PHANMEMBANTRASUADataSet2();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.USP_GetlistbillbyDateTableAdapter = new quanlytrasua.PHANMEMBANTRASUADataSet2TableAdapters.USP_GetlistbillbyDateTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.USP_GetlistbillbyDateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PHANMEMBANTRASUADataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // USP_GetlistbillbyDateBindingSource
            // 
            this.USP_GetlistbillbyDateBindingSource.DataMember = "USP_GetlistbillbyDate";
            this.USP_GetlistbillbyDateBindingSource.DataSource = this.PHANMEMBANTRASUADataSet2;
            // 
            // PHANMEMBANTRASUADataSet2
            // 
            this.PHANMEMBANTRASUADataSet2.DataSetName = "PHANMEMBANTRASUADataSet2";
            this.PHANMEMBANTRASUADataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.USP_GetlistbillbyDateBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "quanlytrasua.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(651, 334);
            this.reportViewer1.TabIndex = 0;
            // 
            // USP_GetlistbillbyDateTableAdapter
            // 
            this.USP_GetlistbillbyDateTableAdapter.ClearBeforeFill = true;
            // 
            // fReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 334);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "fReport";
            this.Text = "Thống kê";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.fReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.USP_GetlistbillbyDateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PHANMEMBANTRASUADataSet2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource USP_GetlistbillbyDateBindingSource;
        private PHANMEMBANTRASUADataSet2 PHANMEMBANTRASUADataSet2;
        private PHANMEMBANTRASUADataSet2TableAdapters.USP_GetlistbillbyDateTableAdapter USP_GetlistbillbyDateTableAdapter;
    }
}