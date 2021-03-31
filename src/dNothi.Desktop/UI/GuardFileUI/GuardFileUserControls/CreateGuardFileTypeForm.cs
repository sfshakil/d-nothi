using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.GuardFileUI.GuardFileUserControls
{
    public partial class CreateGuardFileTypeForm : Form
    {
        public CreateGuardFileTypeForm()
        {
            InitializeComponent();
        }

        private void Border_Color_Blue(object sender, PaintEventArgs e)
        {
            UIDesignCommonMethod.Border_Color_Blue(sender, e);
        }

        private void AddDesignationCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateGuardFileTypeForm_Load(object sender, EventArgs e)
        {

            Screen scr = Screen.FromPoint(this.Location);
            this.Location = new Point(scr.WorkingArea.Right - this.Width, scr.WorkingArea.Top);

            this.Height = scr.WorkingArea.Height;




        }
    }
}
