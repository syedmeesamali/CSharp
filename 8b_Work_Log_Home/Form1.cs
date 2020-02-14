﻿using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Z.Dapper.Plus;

namespace Work_Log
{
    public partial class frmLogs : Form
    {
        public frmLogs()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DataTableCollection tableCollection;
        private void importExcelFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
                { Filter = "Excel 97-2003 workbooks|*.xls|Excel Workbook|*.xlsx" }) //Filter for the type of files to show
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK) //If result is OK
                    {
                        
                        using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                        {
                            using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))  //Create stream for data
                            {
                                DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                                {
                                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                                });
                                tableCollection = result.Tables;
                                cboSheets.Items.Clear(); // clear the combo box
                                foreach (DataTable table in tableCollection)
                                    cboSheets.Items.Add(table.TableName);  //Add names of sheets to combo box
                            }
                        }
                    } //If valid excel file
                }//Open excel file
        }//Import excel file button

        //Display the selected sheet in excel file loaded
        private void btnData_Click(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[cboSheets.SelectedItem.ToString()]; //Show the datagrid as per sheets
            //dataGridView1.DataSource = dt;
            if (dt != null)
            {
                List<Products> products = new List<Products>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Products prodList = new Products();
                    prodList.ID = i.ToString();
                    prodList.ProdID = dt.Rows[i]["ProdID"].ToString();
                    prodList.ProdName = dt.Rows[i]["ProdName"].ToString();
                    products.Add(prodList);
                }
                productsBindingSource.DataSource = products;

            }
        }

        private void frmLogs_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'masterDBDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.masterDBDataSet.Products);


        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DapperPlusManager.Entity<Products>().Table("Products");
                List<Products> products = productsBindingSource.DataSource as List<Products>;
                if (products != null)
                {
                    using(IDbConnection db = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\repos\CSharp\8_Work_Log\MasterDB.mdf;Integrated Security=True"))
                    {
                        db.BulkInsert(products);
                    }
                }
                MessageBox.Show("Finished!");
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void first100RecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 myform3 = new Form3();
            myform3.Visible = true;
        }

        private void aRecordsIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 myform = new Form2();
            myform.Visible = true;

        }

        
    }
}
