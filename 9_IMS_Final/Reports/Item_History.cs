﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace IMS_Final.Reports
{
    public partial class Item_History : Form
    {
        public Item_History()
        {
            InitializeComponent();
        }

        private void Item_History_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stocksDBDataSet_Products.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.stocksDBDataSet_Products.Products);

        }
        SqlDataAdapter adapt;
        DataTable dt;
        private void btnSummary_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(IMS_Final.Properties.Settings.Default.StocksDBConnectionString);
            conn.Open();
            string selectedItem = cboHistory.GetItemText(cboHistory.SelectedItem);
            adapt = new SqlDataAdapter("select sin.Prod_ID, sin.Prod_Name, format(sum(sin.Cost),'N2') as [Total Cost],  " +
                    "pr.Re_Order, sin.Expiry, sum(sin.Units) as [Units Bought], " +
                    " sum(sout.Pcs) as [Units Sold],  " +
                    "(sum(sin.Units) - sum(sout.Pcs)) as [Stock now] " +
                    "from StockinTable as sin " +
                    "inner join StockoutTable as sout " +
                    "on sout.Prod_Name = sin.Prod_Name " +
                    "inner join Products as pr " +
                    "on pr.Prod_Name = sin.Prod_Name " +
                    "where sin.Prod_Name = '" + selectedItem + "' " +
                    "group by sin.Prod_ID, sin.Prod_Name, pr.Re_Order, sin.Expiry ",conn);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 220;
            dataGridView1.Columns[2].Width = 70;
            dataGridView1.Columns[3].Width = 90;
            dataGridView1.Columns[4].Width = 90;
            dataGridView1.Columns[5].Width = 70;
            dataGridView1.Columns[6].Width = 80;
            dataGridView1.Columns[7].Width = 70;
            conn.Close();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(IMS_Final.Properties.Settings.Default.StocksDBConnectionString);
            conn.Open();
            string selectedItem = cboHistory.GetItemText(cboHistory.SelectedItem);
            adapt = new SqlDataAdapter("select sin.Prod_ID, sin.Prod_Name, format(sin.Cost,'N2') as [Cost], " +
                    "pr.Re_Order, sin.Expiry, sin.Sup_Name, sin.Units as [Units In], sin.Date as [Date Bought], " +
                    "sout.Pcs as [Sold], sout.Invoice as [Invoice Ref], sout.Date as [Date Sold], sout.Cust_Name " +
                    "from StockinTable as sin " +
                    "inner join StockoutTable as sout " +
                    "on sout.Prod_Name = sin.Prod_Name " +
                    "inner join Products as pr on pr.Prod_Name = sin.Prod_Name " +
                    "where sin.Prod_Name = '" + selectedItem + "' " , conn);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 50;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 70;
            dataGridView1.Columns[5].Width = 140;
            dataGridView1.Columns[6].Width = 50;
            dataGridView1.Columns[7].Width = 80;
            dataGridView1.Columns[8].Width = 50;
            dataGridView1.Columns[9].Width = 80;
            dataGridView1.Columns[10].Width = 80;
            dataGridView1.Columns[11].Width = 210;
            conn.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\StocksDB.mdf;Integrated Security=True");
                conn.Open();
                //adapt = new SqlDataAdapter("SELECT * FROM StockInTable WHERE Prod_Name like '" + txtSearch.Text + "%'", conn);
                adapt = new SqlDataAdapter("select sin.Prod_ID, sin.Prod_Name, format(sin.Cost,'N2') as [Cost], " +
                    "pr.Re_Order, sin.Expiry, sin.Sup_Name, sin.Units as [Units In], sin.Date as [Date Bought], " +
                    "sout.Pcs as [Sold], sout.Invoice as [Invoice Ref], sout.Date as [Date Sold], sout.Cust_Name " +
                    "from StockinTable as sin " +
                    "inner join StockoutTable as sout " +
                    "on sout.Prod_Name = sin.Prod_Name " +
                    "inner join Products as pr on pr.Prod_Name = sin.Prod_Name " +
                    "where sin.Prod_Name like '" + txtSearch.Text + "%'", conn);
                dt = new DataTable();
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            { MessageBox.Show("Some Issues with Query!", ex.ToString()); }
        }
    }
}