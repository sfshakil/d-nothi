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
        private void DakModuleOff()
        {
            cbxDakInbox.Visible = false;
            cbxDakSent.Visible = false;
            cbxArchaiveDak.Visible = false;
            cbxNothijatoDak.Visible = false;
            cbxNothiteUposthapitoDak.Visible = false;

            SixthLabel.Visible = false;
            cbxKhoshra.Visible = false;
        }
        private void DakModuleOn()
        {
            cbxDakInbox.Visible = true;
            cbxDakSent.Visible = true;
            cbxArchaiveDak.Visible = true;
            cbxNothijatoDak.Visible = true;
            cbxNothiteUposthapitoDak.Visible = true;

            SixthLabel.Visible = true;
            cbxKhoshra.Visible = true;
        }
        private void NothiModuleOn()
        {
            cbxNothiInbox.Visible = true;
            cbxNothiSent.Visible = true;
            cbxNothiAll.Visible = true;
            cbxOthersOfficeNothiInbox.Visible = true;
            cbxOthersOfficeNothiSent.Visible = true;
        }
        private void NothiModuleOff()
        {
            cbxNothiInbox.Visible = false;
            cbxNothiSent.Visible = false;
            cbxNothiAll.Visible = false;
            cbxOthersOfficeNothiInbox.Visible = false;
            cbxOthersOfficeNothiSent.Visible = false;
        }
        private void SetLabelForNothi()
        {
            headingLabel.Text = "নথির পেইজে পেজিনেশন ব্যবস্থা";
            FirstLabel.Text = "আগত";
            SecondLabel.Text = "প্রেরিত";
            ThirdLabel.Text = "সকল";
            ThirdLabel.Font = new Font("SolaimanLipi", 12f);
            FourthLabel.Text = "অন্যান্য অফিসের \nআগত";
            FourthLabel.Font = new Font("SolaimanLipi", 8f);
            FifthLabel.Text = "অন্যান্য অফিসে \nপ্রেরিত";
            FifthLabel.Font = new Font("SolaimanLipi", 8f);
            //SixthLabel.Text = "আগত";
        }
        private void SetLabelForDak()
        {
            headingLabel.Text = "ডাকের পেইজে পেজিনেশন ব্যবস্থা";
            FirstLabel.Text = "আগত";
            SecondLabel.Text = "প্রেরিত";
            ThirdLabel.Text = "নথিতে উপস্থাপিত";
            ThirdLabel.Font = new Font("SolaimanLipi", 8f);
            FourthLabel.Text = "নথিজাত";
            FourthLabel.Font = new Font("SolaimanLipi", 12f);
            FifthLabel.Font = new Font("SolaimanLipi", 12f);
            FifthLabel.Text = "আর্কাইভ";
            SixthLabel.Text = "খসড়া";
        }
        private void btnNothiSettings_Click(object sender, EventArgs e)
        {
            btnNothiSettings.ForeColor = Color.White;
            btnDakSettings.ForeColor = Color.FromArgb(243, 246, 249);
            nothiSliderPanel.BackColor = Color.FromArgb(27, 197, 189);
            DakSliderPanel.BackColor = Color.White;
            
            SetLabelForNothi();
            NothiModuleOn();
            DakModuleOff();
            
            if (!BodyPanel.Visible)
            {
                BodyPanel.Visible = true;
            }
            else
            {
                BodyPanel.Visible = false;
            }
        }
        private void btnDakSettings_Click(object sender, EventArgs e)
        {
            btnDakSettings.ForeColor = Color.White;
            btnNothiSettings.ForeColor = Color.FromArgb(243, 246, 249);
            DakSliderPanel.BackColor = Color.FromArgb(27, 197, 189);
            nothiSliderPanel.BackColor = Color.White;

            SetLabelForDak();
            NothiModuleOff();
            DakModuleOn();

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
            this.Hide();
            Settings settings = new Settings();
            settings.nothiInboxPagination = setpagination(cbxNothiInbox.SelectedIndex);
            settings.nothiSentPagination = setpagination(cbxNothiSent.SelectedIndex);
            settings.nothiAllPagination = setpagination(cbxNothiAll.SelectedIndex);
            settings.othersOfficeNothiInboxPagination = setpagination(cbxOthersOfficeNothiInbox.SelectedIndex);
            settings.othersOfficeNothiSentPagination = setpagination(cbxOthersOfficeNothiSent.SelectedIndex);
            
            settings.dakInboxPagination = setpagination(cbxDakInbox.SelectedIndex);
            settings.dakSentPagination = setpagination(cbxDakSent.SelectedIndex);
            settings.dakNothiteUposthapitoPagination = setpagination(cbxNothiteUposthapitoDak.SelectedIndex);
            settings.dakNothijatoPagination = setpagination(cbxNothijatoDak.SelectedIndex);
            settings.dakArchaivePagination = setpagination(cbxArchaiveDak.SelectedIndex);
            settings.dakKhoshraPagination = setpagination(cbxKhoshra.SelectedIndex);

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
