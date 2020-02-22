﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace IMS_Final.Reports
{
    public partial class StockReportSearch : Form
    {
        public StockReportSearch()
        {
            InitializeComponent();
        }
        SqlDataAdapter adapt;
        DataTable dt;
        private void StockReportSearch_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(IMS_Final.Properties.Settings.Default.StocksDBConnectionString);
            conn.Open();
            adapt = new SqlDataAdapter("select sin.Prod_ID, sin.Prod_Name, sin.Sup_ID, sin.Sup_Name, " +
            "sin.Units, format(sin.Cost, 'N2') as [Cost], sin.Expiry, pr.Re_Order from Products pr, StockinTable sin " +
            "where sin.Prod_Name = pr.Prod_Name", conn);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[2].Width = 50;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 50;
            dataGridView1.Columns[5].Width = 50;
            dataGridView1.Columns[6].Width = 120;
            dataGridView1.Columns[7].Width = 90;
            //dataGridView1.Columns[8].Width = 70;
            conn.Close();
        }
    }
}
