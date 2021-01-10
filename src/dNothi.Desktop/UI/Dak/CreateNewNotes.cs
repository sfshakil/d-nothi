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
        }
        public string _noteSubject { get; set; }
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void saveNewNoteButton_Click(object sender, EventArgs e)
        {
            _noteSubject = newNoteTextBox.Text;
            this.Hide();
            var form = FormFactory.Create<Note>();
            form.ShowDialog();
        }
    }
}
