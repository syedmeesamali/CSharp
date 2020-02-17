﻿using System;
using System.Windows.Forms;

namespace IMS_Final.Reports
{
    public partial class ExpiryReports : Form
    {
        public ExpiryReports()
        {
            InitializeComponent();
        }

        private void btnExpiryReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Expiry report for dates earlier than selected date!");
            this.reportViewer1.RefreshReport();
        }

        private void ExpiryReports_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stocksDBDataSet_StockinExpiry.StockinTableExpiry' table. You can move, or remove it, as needed.
            this.stockinTableExpiryTableAdapter.Fill(this.stocksDBDataSet_StockinExpiry.StockinTableExpiry);
            // TODO: This line of code loads data into the 'stocksDBDataSet_StockinExpiry.StockinTableExpiry' table. You can move, or remove it, as needed.
            this.stockinTableExpiryTableAdapter.Fill(this.stocksDBDataSet_StockinExpiry.StockinTableExpiry);
            // TODO: This line of code loads data into the 'stocksDBDataSetStockinExpiry.StockinTable' table. You can move, or remove it, as needed.
            string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            //this.stockinTableTableAdapter.Fill(this.stocksDBDataSet_StockinExpiry.StockinTable);
            // TODO: This line of code loads data into the 'stocksDBDataSet_Complete.StockinTable' table. You can move, or remove it, as needed.
        }

        
    }
}
