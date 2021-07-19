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
    public partial class SetKarjodibosh : UserControl
    {
        public SetKarjodibosh()
        {
            InitializeComponent();
        }
        public event EventHandler KarjodiboshSaveButtonClick;
        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name=="")
                {
                    BeginInvoke((Action)(() => f.Hide()));
                }
                
            }
            var karjodibosh = txtKarjodibosh.Text;
            if (this.KarjodiboshSaveButtonClick != null)
                this.KarjodiboshSaveButtonClick(karjodibosh, e);
            
        }
    }
}
