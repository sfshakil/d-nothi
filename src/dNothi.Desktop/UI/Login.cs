using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            select_UserID();

        }
        public void select_UserID()
        {
            this.button6.ForeColor = Color.Indigo;
            this.panel5.BackColor = Color.Indigo;
            this.button6.FlatAppearance.BorderColor = Color.Gainsboro;
            this.panel8.BackColor = Color.Gainsboro;
            this.button7.ForeColor = Color.Black;
            this.panel6.BackColor = Color.White;
            this.button7.FlatAppearance.BorderColor = Color.White;
            this.button8.ForeColor = Color.Black;
            this.panel7.BackColor = Color.White;
            this.button8.FlatAppearance.BorderColor = Color.White;
        }
        private void button6_MouseHover(object sender, EventArgs e)
        {
            this.button6.ForeColor = Color.Indigo;
            this.panel5.BackColor = Color.Indigo;
            this.button6.FlatAppearance.BorderColor = Color.Gainsboro;
        }

        private void button7_MouseHover(object sender, EventArgs e)
        {
            this.button7.ForeColor = Color.Indigo;
            this.panel6.BackColor = Color.Indigo;
            this.button7.FlatAppearance.BorderColor = Color.Gainsboro;
        }

        private void button8_MouseHover(object sender, EventArgs e)
        {
            this.button8.ForeColor = Color.Indigo;
            this.panel7.BackColor = Color.Indigo;
            this.button8.FlatAppearance.BorderColor = Color.Gainsboro;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.button6.ForeColor = Color.Indigo;
            this.panel5.BackColor = Color.Indigo;
            this.button6.FlatAppearance.BorderColor = Color.Gainsboro;
            this.panel8.BackColor = Color.Gainsboro;
            this.button7.ForeColor = Color.Black;
            this.panel6.BackColor = Color.White;
            this.button7.FlatAppearance.BorderColor = Color.White;
            this.button8.ForeColor = Color.Black;
            this.panel7.BackColor = Color.White;
            this.button8.FlatAppearance.BorderColor = Color.White;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.button6.ForeColor = Color.Black;
            this.panel5.BackColor = Color.White;
            this.button6.FlatAppearance.BorderColor = Color.White;
            this.panel8.BackColor = Color.Gainsboro;
            this.button7.ForeColor = Color.Indigo;
            this.panel6.BackColor = Color.Indigo;
            this.button7.FlatAppearance.BorderColor = Color.Gainsboro;
            this.button8.ForeColor = Color.Black;
            this.panel7.BackColor = Color.White;
            this.button8.FlatAppearance.BorderColor = Color.White;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.button6.ForeColor = Color.Black;
            this.panel5.BackColor = Color.White;
            this.button6.FlatAppearance.BorderColor = Color.White;
            this.panel8.BackColor = Color.Gainsboro;
            this.button7.ForeColor = Color.Black;
            this.panel6.BackColor = Color.White;
            this.button7.FlatAppearance.BorderColor = Color.White;
            this.button8.ForeColor = Color.Indigo;
            this.panel7.BackColor = Color.Indigo;
            this.button8.FlatAppearance.BorderColor = Color.Gainsboro;
        }

        private void xTextBox1_MouseHover(object sender, EventArgs e)
        {
            this.xTextBox1.Text = "";
        }

        private void xTextBox1_MouseLeave(object sender, EventArgs e)
        {
            this.xTextBox1.Text = "ইউজার আইডি";
        }

        private void label10_MouseHover(object sender, EventArgs e)
        {
            this.label10.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Underline);
        }

        private void label10_MouseLeave(object sender, EventArgs e)
        {
            this.label10.Font = new Font("Microsoft Sans Serif", 8);
        }
    }
}
