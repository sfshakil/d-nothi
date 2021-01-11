﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Dak
{
    public partial class CreateNewNotes : Form
    {
        public CreateNewNotes()
        {
            InitializeComponent();
            SetDefaultFont(this.Controls);
        }
        void SetDefaultFont(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {

                MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size, ctrl.Font.Style);
                SetDefaultFont(ctrl.Controls);
            }

        }
        public string _noteSubject { get; set; }
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void saveNewNoteButton_Click(object sender, EventArgs e)
        {
            if (newNoteTextBox.Text != "")
            {
                this.Hide();
                var form = FormFactory.Create<Note>();
                form.ShowDialog();
            }
            else
            {
                string message = "নোটের বিষয় দেওয়া হইনি";
                MessageBox.Show(message);
            }
            
        }
    }
}
