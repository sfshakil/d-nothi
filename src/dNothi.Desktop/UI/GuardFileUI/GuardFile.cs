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
    public partial class GuardFile : Form
    {
        UCGuardFileTypes ucft = new UCGuardFileTypes();
        UCGuardFileList ucfl = new UCGuardFileList();
        UCGuardFileUpload ucfu = new UCGuardFileUpload();
        public GuardFile()
        {
            InitializeComponent();
            ucft.Dock = DockStyle.Fill;
            Bodypanel.Controls.Add(ucft);
        }

        private void btnNothiInbox_Click(object sender, EventArgs e)
        {
            lablePageName.Text = "গার্ড ফাইলের ধরন";

           
            Bodypanel.Controls.Add(ucft);
            Bodypanel.Controls.Clear();
            Bodypanel.Visible = true;
            ucfl.Hide();
            ucfu.Hide();
            ucft.Show();
            ucft.Dock = DockStyle.Fill;
            Bodypanel.Controls.Add(ucft);
           
        }

        private void btnGuardFileList_Click(object sender, EventArgs e)
        {
            lablePageName.Text = "গার্ড ফাইল তালিকা";
         
            Bodypanel.Controls.Clear();
            Bodypanel.Visible = true;
            ucfl.Show();
            ucfu.Hide();
            ucft.Hide();
            ucfl.Dock = DockStyle.Fill;
            Bodypanel.Controls.Add(ucfl);
          

        }

        private void btnUploadGuardFile_Click(object sender, EventArgs e)
        {
            lablePageName.Text = "আপলোড গার্ড ফাইল";
         
            Bodypanel.Controls.Clear();
            Bodypanel.Visible = true;
            ucfl.Hide();
            ucfu.Show();
            ucft.Hide();
            
            Bodypanel.Controls.Add(ucfu);
           

        }

    }
}
