﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Dak
{
    public partial class CreateNewNothiType : UserControl
    {
        public CreateNewNothiType()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnGuidelines_Click(object sender, EventArgs e)
        {
            NewNothiCreateGuidelines newguideline = new NewNothiCreateGuidelines();
            newguideline.ShowDialog();
        }
    }
}
