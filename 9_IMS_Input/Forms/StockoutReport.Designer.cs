﻿namespace IMS_Input
{
    partial class StockoutReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockoutReport));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.StocksDataSet = new IMS_Input.StocksDataSet();
            this.StockoutTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.StockoutTableTableAdapter = new IMS_Input.StocksDataSetTableAdapters.StockoutTableTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.StocksDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockoutTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.StockoutTableBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "IMS_Input.Stockout.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(820, 408);
            this.reportViewer1.TabIndex = 1;
            // 
            // StocksDataSet
            // 
            this.StocksDataSet.DataSetName = "StocksDataSet";
            this.StocksDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // StockoutTableBindingSource
            // 
            this.StockoutTableBindingSource.DataMember = "StockoutTable";
            this.StockoutTableBindingSource.DataSource = this.StocksDataSet;
            // 
            // StockoutTableTableAdapter
            // 
            this.StockoutTableTableAdapter.ClearBeforeFill = true;
            // 
            // StockoutReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 408);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StockoutReport";
            this.Text = "Stockout Report";
            this.Load += new System.EventHandler(this.StockoutReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StocksDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockoutTableBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource StockoutTableBindingSource;
        private StocksDataSet StocksDataSet;
        private StocksDataSetTableAdapters.StockoutTableTableAdapter StockoutTableTableAdapter;
    }
}