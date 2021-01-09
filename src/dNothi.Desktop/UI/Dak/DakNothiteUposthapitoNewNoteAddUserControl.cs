using System;
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
    public partial class DakNothiteUposthapitoNewNoteAddUserControl : Form
    {
        public string _noteSubject { get; set; } 
        public DakNothiteUposthapitoNewNoteAddUserControl()
        {
            InitializeComponent();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public event EventHandler SaveNoteButtonClick;
        private void saveNewNoteButton_Click(object sender, EventArgs e)
        {

            //DialogResult DialogResultSttring = MessageBox.Show("আপনি কি এই নোটে ডাকটি উপস্থাপন করতে চান ?\n",
            //                  "Conditional", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //if (DialogResultSttring == DialogResult.Yes)
            //{

                _noteSubject = newNoteTextBox.Text;
                 this.Hide();
                if (this.SaveNoteButtonClick != null)
                    this.SaveNoteButtonClick(sender, e);
            
        }
    }
}
