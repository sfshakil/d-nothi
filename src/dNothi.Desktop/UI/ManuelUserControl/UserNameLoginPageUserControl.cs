using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.ManuelUserControl
{
    public partial class UserNameLoginPageUserControl : UserControl
    {
        public UserNameLoginPageUserControl()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            var btn = new Button();
            btn.Size = new Size(33, txtUserNamePassword.ClientSize.Height + 2);
            btn.Location = new Point(txtUserNamePassword.ClientSize.Width - btn.Width, -1);
            btn.BringToFront();
            btn.Cursor = Cursors.Default;
            btn.Click += pasword_Show;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Image = Properties.Resources.icons8_eye_15;
            txtUserNamePassword.Controls.Add(btn);
            // Send EM_SETMARGINS to prevent text from disappearing underneath the button
            SendMessage(txtUserNamePassword.Handle, 0xd3, (IntPtr)2, (IntPtr)(btn.Width << 16));
            base.OnLoad(e);
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);


        private void pasword_Show(object sender, EventArgs e)
        {
            txtUserNamePassword.PasswordChar = txtUserNamePassword.PasswordChar == '\0' ? '●' : '\0';
        }

        private void txtUserNamePassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please Input Only English Character!");
            }
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
