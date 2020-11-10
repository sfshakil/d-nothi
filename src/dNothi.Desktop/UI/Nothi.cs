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
    public partial class Nothi : Form
    {
        public Nothi()
        {
            InitializeComponent();
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Nothi nothi = new Nothi();
            nothi.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.ShowDialog();

        }
        designationSelect ucdesignationSelect = new designationSelect();
        private void button15_Click(object sender, EventArgs e)
        {
            
           
            if (ucdesignationSelect.Width == 428)
            {
                ucdesignationSelect.Visible = true;
                ucdesignationSelect.Location = new System.Drawing.Point(227 + 689, 60);
                Controls.Add(ucdesignationSelect);
                ucdesignationSelect.BringToFront();
                ucdesignationSelect.Width = 427;
                button15.BackColor = Color.WhiteSmoke;
            }
            else
            {
                ucdesignationSelect.Visible = false;
                ucdesignationSelect.Width = 428;
            }

        }
    }
}
