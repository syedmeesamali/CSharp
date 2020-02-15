﻿using IMS_Final.Reports;
using System;
using System.Windows.Forms;

namespace IMS_Final
{
    public partial class StockReportsForm : Form
    {
        public StockReportsForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product_Report product_Report = new Product_Report();
            product_Report.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExpiryReports expiryReports = new ExpiryReports();
            expiryReports.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CustomSearch customSearch = new CustomSearch();
            customSearch.Show();
        }

        private void StockReportsForm_Load(object sender, EventArgs e)
        {

        }

        private void btnFullReport_Click(object sender, EventArgs e)
        {
            ProductListSearch productListSearch = new ProductListSearch();
            productListSearch.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SalesSearch salesSearch = new SalesSearch();
            salesSearch.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet!", "Coming Soon");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet!", "Coming Soon");
        }
    }
}