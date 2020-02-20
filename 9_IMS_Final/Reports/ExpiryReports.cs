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
            string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            MessageBox.Show("Expiry report for dates earlier than selected date!");
            
            this.reportViewer1.RefreshReport();
        }

        private void ExpiryReports_Load(object sender, EventArgs e)
        {
            
        }

        
    }
}
