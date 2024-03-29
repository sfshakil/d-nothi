﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.CustomMessageBox
{
    public partial class UIFormValidationAlertMessageForm : Form
    {
        public bool _isSuccess;
       
        public UIFormValidationAlertMessageForm()
        {
           

          
            InitializeComponent();
        }
        public bool isSuccess { get { return _isSuccess; }
            set
            {
                _isSuccess = value;
                if (value)
                {

                    this.BackColor = Color.FromArgb(27, 197, 189);

                    checkIconPictureBox.Visible = true;
                    closeButton.Visible = false;
                    messageIconPictureBox.Visible = false;

                    
                }
                else
                {

                }
            }
        
        }
        public string _message { get; set; }


        public string message { get { return _message; } set { _message = value; messageLabel.Text = value; } }

        private void messageLabel_Click(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void UIFormValidationAlertMessageForm_Load(object sender, EventArgs e)
        {
            this.Width = tableLayoutPanel1.Width + 10;
            Screen scr = Screen.FromPoint(this.Location);
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Size.Width / 2) - (this.Size.Width / 2), scr.WorkingArea.Top);

            SetDefaultFont(this.Controls);
           
        }
        void SetDefaultFont(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {




                if (ctrl.Font.Style != FontStyle.Regular)
                {
                    MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                    ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size, ctrl.Font.Style);

                }
                else
                {
                    MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                    ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size);
                }




                SetDefaultFont(ctrl.Controls);
            }

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
