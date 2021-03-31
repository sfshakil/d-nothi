using dNothi.Desktop.UI.GuardFileUI.GuardFileUserControls;
using dNothi.Desktop.UI.OtherModule.GuardFileUserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.OtherModule
{
    public partial class GurdFileControl : Form
    {
        
        UCGuardFileTypes guardFileTypeuc = new UCGuardFileTypes();
        UCGuardFileList  guardFileListuc = new UCGuardFileList();
        UCGuardFileUpload guardFileUploaduc = new UCGuardFileUpload();
        public GurdFileControl()
        {
            InitializeComponent();
            guardFileTypeuc.Dock = DockStyle.Top;
            bodyPanel.Controls.Add(guardFileTypeuc);
            guardFileAddButton.Show();
        }

        
        private void guardFileTypeButton_Click(object sender, EventArgs e)
        {
            lablePageName.Text = "গার্ড ফাইলের ধরন";

            bodyPanel.Controls.Clear();
            bodyPanel.Controls.Add(guardFileTypeuc);
            guardFileTypeuc.Dock = DockStyle.Top;
            bodyPanel.Visible = true;
            guardFileListuc.Hide();
            guardFileUploaduc.Hide();
            guardFileTypeuc.Show();
            guardFileAddButton.Show();


            SelectThisButton(sender, e);
           // bodyPanel.Controls.Add(ucft);
        }

        private void SelectThisButton(object sender, EventArgs e)
        {
            foreach(Control control in menuTableLayoutPanel.Controls)
            {
                if(control is Button && control==sender)
                {
                    control.ForeColor = Color.FromArgb(78, 165, 254);
                    control.BackColor = Color.FromArgb(243, 246, 249);
                }
                else
                {
                    control.ForeColor = Color.FromArgb(97, 99, 114);
                    control.BackColor = Color.White;
                }

            }
        }

        private void guardFileListButton_Click(object sender, EventArgs e)
        {
            lablePageName.Text = "গার্ড ফাইল তালিকা";

            bodyPanel.Controls.Clear();
            bodyPanel.Controls.Add(guardFileListuc);
            guardFileListuc.Dock = DockStyle.Fill;
            bodyPanel.Visible = true;
            guardFileListuc.Show();
            guardFileUploaduc.Hide();
            guardFileTypeuc.Hide();

            guardFileAddButton.Hide();

            SelectThisButton(sender, e);
        }

        private void guardFileUploadButton_Click(object sender, EventArgs e)
        {
            lablePageName.Text = "আপলোড গার্ড ফাইল";

            bodyPanel.Controls.Clear();
            bodyPanel.Controls.Add(guardFileUploaduc);
            guardFileUploaduc.Dock = DockStyle.None;
            bodyPanel.Visible = true;
            guardFileListuc.Hide();
            guardFileUploaduc.Show();
            guardFileTypeuc.Hide();
           
           
            guardFileAddButton.Hide();
            SelectThisButton(sender, e);
        }

        private void moduleButton_Click(object sender, EventArgs e)
        {

            UIDesignCommonMethod.CallAllModulePanel(moduleButton, this);
        }

        private void bodyPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guardFileAddButton_Click(object sender, EventArgs e)
        {
           // newGuardFileTypepanel.Visible = true;
        }

        private void guardFileAddButton_Click_1(object sender, EventArgs e)
        {
            CreateGuardFileTypeForm createGuardFileTypeForm = new CreateGuardFileTypeForm();
            UIDesignCommonMethod.CalPopUpWindow(createGuardFileTypeForm, this);
        }

        private void dakModulePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DakDashboardClick(object sender, EventArgs e)
        {
            UIDesignCommonMethod.DakModuleClick(this);
        }

        private void Nothi_ModuleCLick(object sender, EventArgs e)
        {
            UIDesignCommonMethod.NothiModuleClick(this);
        }
    }
}
