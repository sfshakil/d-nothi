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
    public partial class PotrangshoPrapokerTalika : UserControl
    {
        public PotrangshoPrapokerTalika()
        {
            InitializeComponent();
            loadNoteMovement();
        }
        public void loadNoteMovement()
        {
            Prapok noteMovement = new Prapok();

            nothiTypeListFlowLayoutPanel.Controls.Add(noteMovement);
        }

        private void btnNothiTypeCross_Click(object sender, EventArgs e)
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
    }
}
