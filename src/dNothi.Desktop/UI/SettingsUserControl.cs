using dNothi.JsonParser.Entity;
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
    public partial class SettingsUserControl : UserControl
    {
        public SettingsUserControl()
        {
            InitializeComponent();
            BodyPanel.Visible = false;
        }

        private void btnNothiSettings_Click(object sender, EventArgs e)
        {
            btnNothiSettings.ForeColor = Color.White;
            nothiSliderPanel.BackColor = Color.FromArgb(27, 197, 189);
            if (!BodyPanel.Visible)
            {
                BodyPanel.Visible = true;
            }
            else
            {
                BodyPanel.Visible = false;
            }
        }

        private void BodyPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
        }
        public event EventHandler SettingsSaveButton;
        private void SaveButton_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.nothiInboxPagination = setpagination(cbxNothiInbox.SelectedIndex);
            settings.nothiSentPagination = setpagination(cbxNothiSent.SelectedIndex);
            settings.nothiAllPagination = setpagination(cbxNothiAll.SelectedIndex);
            settings.othersOfficeNothiInboxPagination = setpagination(cbxOthersOfficeNothiInbox.SelectedIndex);
            settings.othersOfficeNothiSentPagination = setpagination(cbxOthersOfficeNothiSent.SelectedIndex);

            if (this.SettingsSaveButton != null)
                this.SettingsSaveButton(settings, e);
        }
        public int setpagination(int index)
        {
            var i = 0;
            if (index == 0)
            {
                i = 10;
            }else if (index == 1)
            {
                i = 20;
            }else if (index == 2)
            {
                i = 50;
            }else if (index == 3)
            {
                i = 100;
            }
            return i;
        }
    }
}
