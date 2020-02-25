﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace IMS_Final
{
    public partial class ProductListSearch : Form
    {
        public ProductListSearch()
        {
            InitializeComponent();
        }
        SqlDataAdapter adapt;
        DataTable dt;
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(IMS_Final.Properties.Settings.Default.StocksDBConnectionString);
                conn.Open();
                adapt = new SqlDataAdapter("SELECT * FROM Products WHERE Prod_Name like '" + txtSearch.Text + "%'", conn);
                dt = new DataTable();
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            { MessageBox.Show("Some Issues with Query!", ex.ToString()); }
        }

        private void txtProdID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(IMS_Final.Properties.Settings.Default.StocksDBConnectionString);
                conn.Open();
                adapt = new SqlDataAdapter("SELECT * FROM Products WHERE Prod_ID like '" + txtProdID.Text + "%'", conn);
                dt = new DataTable();
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            { MessageBox.Show("Some Issues with Query!", ex.ToString()); }
        }

        private void ProductListSearch_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(IMS_Final.Properties.Settings.Default.StocksDBConnectionString);
            conn.Open();
            adapt = new SqlDataAdapter("SELECT * FROM Products", conn);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[2].Width = 300;
            conn.Close();
        }
    }
}
