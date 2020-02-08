﻿using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml;

namespace IMS_Final
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        DataTableCollection tableCollection;
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void stockReportFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockReportsForm stockReportsForm = new StockReportsForm();
            stockReportsForm.Show();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            //DataTable dt = tableCollection[cboSheets.SelectedItem.ToString()]; //Show the datagrid as per sheets
            //dataGridView1.DataSource = dt;
        }

        private void importInvoiceExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()
            { Filter = "Excel 97-2003 workbooks|*.xlsx|Excel Workbook|*.xls" }) //Filter for the type of files to show
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK) //If result is OK
                {

                    FileInfo fileName = new FileInfo(openFileDialog.FileName);                        
                    using (ExcelPackage package = new ExcelPackage(fileName))
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                            int col = 2;
                            for (int row = 2; row < 5; row++)
                            {
                                listBox1.Items.Add(row);
                                listBox1.Items.Add(col);
                                listBox1.Items.Add(worksheet.Cells[row, col].Value);
                            }
                        }
                        
                        //using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))  //Create stream for data
                        //{
                        //    DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        //    {
                        //        ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                        //    });
                        //    tableCollection = result.Tables;
                        //    cboSheets.Items.Clear(); // clear the combo box
                        //    foreach (DataTable table in tableCollection)
                        //        cboSheets.Items.Add(table.TableName);  //Add names of sheets to combo box
                        //}
                    }
                }
        }
    }
}
