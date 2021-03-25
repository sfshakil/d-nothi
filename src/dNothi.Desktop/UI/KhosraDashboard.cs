using dNothi.Desktop.UI.Khosra_Potro;
using FontAwesome.Sharp;
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
    public partial class KhosraDashboard : Form
    {
        public KhosraDashboard()
        {
            InitializeComponent();
           
        }


        private void MakeThisPanelClicked(object sender)
        {
            Panel panel = sender as Panel;
            if(panel == null)
            {
                panel = (sender as Control).Parent as Panel;
            }


            foreach (Control control in menuTableLayoutPanel.Controls)
            {
                if (control is Panel)
                {
                    if (control == panel)
                    {
                        MakeClickUnClickButton(control, Color.FromArgb(243, 246, 249), Color.FromArgb(78, 165, 254));

                    }
                    else
                    {
                        if(control is Button)
                        {
                            listTypeLabel.Text = control.Text;
                        }
                        MakeClickUnClickButton(control, Color.FromArgb(254, 254, 254), Color.FromArgb(97, 99, 114));

                    }
                }
            }
        }

        private void MakeClickUnClickButton(Control control, Color backColor, Color foreColor)
        {
            control.BackColor = backColor;
            if (control.Controls.Count > 0)
            {
                foreach (Control c in control.Controls)
                {

                    c.ForeColor = foreColor;


                }
            }
        }

        private void draftPotroPanel_Click(object sender, EventArgs e)
        {
            MakeThisPanelClicked(sender);
            LoadFakeRow(true);
        }

        private void noteAttachmentKhosraButton_Click(object sender, EventArgs e)
        {
            MakeThisPanelClicked(sender);
            LoadFakeRow(false);
        }

        private void pendingApprovalPanel_Click(object sender, EventArgs e)
        {
            MakeThisPanelClicked(sender);
            LoadFakeRow(false);
        }

        private void pendingForwardPanel_Click(object sender, EventArgs e)
        {
            MakeThisPanelClicked(sender);
            LoadFakeRow(false);
        }

        private void jarikritoButton_Click(object sender, EventArgs e)
        {
            MakeThisPanelClicked(sender);
            LoadFakeRow(false);
        }

        private void moduleButton_Click(object sender, EventArgs e)
        {
            if(dakModulePanel.Visible)
            {
                dakModulePanel.Visible = false;
            }
            else
            {
                
                dakModulePanel.Visible = true;
                dakModulePanel.BringToFront();
            }
        }

        private void bodyPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void KhosraDashboard_Shown(object sender, EventArgs e)
        {
            LoadFakeRow(true); 
        }

        private void LoadFakeRow(bool v)
        {
            khosraListTableLayoutPanel.Controls.Clear();

            CommonKhosraRowUserControl commonKhosraRowUserControl = new CommonKhosraRowUserControl();

            commonKhosraRowUserControl.isDraft = v;


            UIDesignCommonMethod.AddRowinTable(khosraListTableLayoutPanel, commonKhosraRowUserControl);




            CommonKhosraRowUserControl commonKhosraRowUserControl2 = new CommonKhosraRowUserControl();

            commonKhosraRowUserControl2.isDraft = v;


            UIDesignCommonMethod.AddRowinTable(khosraListTableLayoutPanel, commonKhosraRowUserControl2);


            CommonKhosraRowUserControl commonKhosraRowUserControl3 = new CommonKhosraRowUserControl();

            commonKhosraRowUserControl3.isDraft = v;


            UIDesignCommonMethod.AddRowinTable(khosraListTableLayoutPanel, commonKhosraRowUserControl3);




            CommonKhosraRowUserControl commonKhosraRowUserControl4 = new CommonKhosraRowUserControl();

            commonKhosraRowUserControl4.isDraft = v;


            UIDesignCommonMethod.AddRowinTable(khosraListTableLayoutPanel, commonKhosraRowUserControl4);

        }
    }
}
