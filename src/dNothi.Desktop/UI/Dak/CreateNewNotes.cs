using dNothi.Desktop.UI.CustomMessageBox;
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
        public string _nothiSubject;

        [Category("Custom Props")]
        public string nothiSubject
        {
            set { _nothiSubject = newNoteTextBox.Text; }
            
        }
        
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public void SuccessMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();

            successMessage.message = Message;
            successMessage.isSuccess = true;
            successMessage.Show();
            var t = Task.Delay(3000); //1 second/1000 ms
            t.Wait();
            successMessage.Hide();
        }
        public void ErrorMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();
            successMessage.message = Message;
            successMessage.Show();
            var t = Task.Delay(3000); //1 second/1000 ms
            t.Wait();
            successMessage.Hide();
            // successMessage.ShowDialog();

        }
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler SaveNewNoteButtonClick;
        private void saveNewNoteButton_Click(object sender, EventArgs e)
        {
            if (newNoteTextBox.Text != "")
            {
                this.Hide();
                if (this.SaveNewNoteButtonClick != null)
                    this.SaveNewNoteButtonClick(newNoteTextBox.Text, e);
            }
            else
            {
                string message = "নোটের বিষয় দেওয়া হইনি";
                ErrorMessage(message);
            }
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }
    }
}
