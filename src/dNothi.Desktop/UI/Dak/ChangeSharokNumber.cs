using System;
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
    public partial class ChangeSharokNumber : UserControl
    {
        public ChangeSharokNumber()
        {
            InitializeComponent();
        }


        public string _leftSharok { get; set; }
        public string leftSharok
        {
            get { return _leftSharok; }
            set
            {
                _leftSharok = value;
                lbNothiNoText.Text = value;
            }


        }
        public string _rightSharok { get; set; }
        public string rightSharok
        {
            get { return _rightSharok; }
            set
            {
                _rightSharok = value;
                lbNothilast4digit.Text = value;
            }


        }

        private void lbNothiNo_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            foreach (Form f in openForms)
            {
                if (f.Name != "Note")
                    f.Close();
            }
        }

        public event EventHandler SharokNoChangeButton;
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.SharokNoChangeButton != null)
            {
                rightSharok = lbNothilast4digit.Text;


                this.SharokNoChangeButton(sender, e);

                this.Parent.Hide();
            }
        }
    }
}
