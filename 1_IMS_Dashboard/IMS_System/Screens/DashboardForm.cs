﻿using IMS_System.Screens.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS_System.Screens
{
    public partial class DashboardForm : MetroFramework.Forms.MetroForm
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void cmdDefine_Click(object sender, EventArgs e)
        {
            this.Hide();
            DefineProducts dps = new DefineProducts();
            dps.Show();

        }
    }
}
