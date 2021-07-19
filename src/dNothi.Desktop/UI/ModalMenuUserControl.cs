using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.Desktop.UI.OtherModule;
using dNothi.Desktop.UI.PotroJariGroups;

namespace dNothi.Desktop.UI
{
    public partial class ModalMenuUserControl : UserControl
    {
        public ModalMenuUserControl()
        {
            InitializeComponent();
        }
        
        private void DoSomethingAsync(object sender, EventArgs e)
        {
            this.Hide();
        }

        //private void potrojariButton_Click(object sender, EventArgs e)
        //{
        //    //this.Parent.Hide();
        //    foreach (Form f in Application.OpenForms)
        //    { BeginInvoke((Action)(() => f.Hide())); }

        //    PotrojariGroupForm potrojariGroup = FormFactory.Create<PotrojariGroupForm>();

        //    BeginInvoke((Action)(() => potrojariGroup.ShowDialog()));
        //    potrojariGroup.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };
        //}
        //potrojariGroup.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev);
        public event EventHandler noteEditButtonClick;
        public event EventHandler noteRemoveButtonClick;
        public event EventHandler noteOnumodanButtonClick;

        public void ButtonVisibility(bool onumodan,bool remove,bool sampadan)
        {

            noteEditButton.Visible = sampadan;
            noteOnumodanButton.Visible = onumodan;
            noteRemoveButton.Visible = remove;
        }
        private void noteEditButton_Click(object sender, EventArgs e)
        {
            if(this.noteEditButtonClick != null)
            {
                noteEditButtonClick(sender, e);
            }
        }

        private void noteRemoveButton_Click(object sender, EventArgs e)
        {
            if (this.noteRemoveButtonClick != null)
            {
                noteRemoveButtonClick(sender, e);
            }

        }

        private void noteOnumodanButton_Click(object sender, EventArgs e)
        {
            if (this.noteOnumodanButtonClick != null)
            {
                noteOnumodanButtonClick(sender, e);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
