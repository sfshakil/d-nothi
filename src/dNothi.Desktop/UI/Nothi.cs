﻿using dNothi.Desktop.UI.Dak;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.NothiServices;
using dNothi.Services.UserServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI
{
    public partial class Nothi : Form
    {
        IUserService _userService { get; set; }
        INothiInboxServices _nothiInbox { get; set; }
        INothiOutboxServices _nothiOutbox { get; set; }

        INothiAllServices _nothiAll { get; set; }

        public Nothi(IUserService userService, INothiInboxServices nothiInbox, INothiOutboxServices nothiOutbox, INothiAllServices nothiAll)
        {
            _userService = userService;
            _nothiInbox = nothiInbox;
            _nothiOutbox = nothiOutbox;
            _nothiAll = nothiAll;
            InitializeComponent();
            LoadNothiInbox();
            ResetAllMenuButtonSelection();
            SetDefaultFont(this.Controls);
            SelectButton(btnNothiInbox);
            nothiDhoronSrchUC.Visible = true;
        }

        void SetDefaultFont(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {

                MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size, ctrl.Font.Style);
                SetDefaultFont(ctrl.Controls);
            }

        }
        private void btnNothiInbox_Click(object sender, EventArgs e)
        {
            
        }

        private void LoadNothiInbox()
        {
            var token = _userService.GetToken();
            var nothiInbox = _nothiInbox.GetNothiInbox(token);
            if (nothiInbox.status == "success")
            {
                _nothiInbox.SaveOrUpdateNothiRecords(nothiInbox.data.records);
                
                if (nothiInbox.data.records.Count > 0)
                {

                    LoadNothiInboxinPanel(nothiInbox.data.records);

                }
            }

        }

        private void LoadNothiInboxinPanel(List<NothiListRecordsDTO> nothiLists)
        {
            List<NothiInbox> nothiInboxs = new List<NothiInbox>();
            int i = 0;
            foreach (NothiListRecordsDTO nothiListRecordsDTO in nothiLists)
            {
                var nothiInbox = UserControlFactory.Create<NothiInbox>();
                nothiInbox.nothi = nothiListRecordsDTO.nothi_no + " " + nothiListRecordsDTO.subject;
                nothiInbox.shakha = nothiListRecordsDTO.office_unit_name;
                nothiInbox.totalnothi = "মোট নোটঃ " + nothiListRecordsDTO.note_count;
                nothiInbox.lastdate = "নোটের সর্বশেষ তারিখঃ " + nothiListRecordsDTO.last_note_date;
                nothiInbox.nothiId = Convert.ToString(nothiListRecordsDTO.id);

                i = i + 1;
                nothiInboxs.Add(nothiInbox);
            }
            nothiListFlowLayoutPanel.Controls.Clear();
            nothiListFlowLayoutPanel.AutoScroll = true;
            nothiListFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            nothiListFlowLayoutPanel.WrapContents = false;

            for (int j = 0; j <= nothiInboxs.Count - 1; j++)
            {
                nothiListFlowLayoutPanel.Controls.Add(nothiInboxs[j]);
            }
        }

        private void btnNothi_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<Nothi>();
            form.ShowDialog();
            
        }

        private void btnNothiIcon_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<Dashboard>();
            form.ShowDialog();
        }

        private void btnDak_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<Dashboard>();
            form.ShowDialog();
        }
        designationSelect ucdesignationSelect = new designationSelect();
        private void btnLogOutArrow_Click(object sender, EventArgs e)
        {
            if (ucdesignationSelect.Width == 428)
            {
                ucdesignationSelect.Visible = true;
                ucdesignationSelect.Location = new System.Drawing.Point(227 + 689, 60);
                Controls.Add(ucdesignationSelect);
                ucdesignationSelect.BringToFront();
                ucdesignationSelect.Width = 427;
                btnLogOutArrow.BackColor = Color.WhiteSmoke;
            }
            else
            {
                ucdesignationSelect.Visible = false;
                ucdesignationSelect.Width = 428;
            }
        }

        private void LoadNothiOutbox()
        {
            var token = _userService.GetToken();
            var nothiOutbox = _nothiOutbox.GetNothiOutbox(token);

            if (nothiOutbox.status == "success")
            {
                if (nothiOutbox.data.records.Count > 0)
                {
                    LoadNothiOutboxinPanel(nothiOutbox.data.records);
                }

            }
        }
        private void LoadNothiOutboxinPanel(List<NothiOutboxListRecordsDTO> nothiOutboxLists)
        {

            List<NothiOutbox> nothiOutboxs = new List<NothiOutbox>();
            int i = 0;
            foreach (NothiOutboxListRecordsDTO nothiOutboxListDTO in nothiOutboxLists)
            {
                NothiOutbox nothiOutbox = new NothiOutbox();
                nothiOutbox.nothi = nothiOutboxListDTO.nothi.nothi_no + " " + nothiOutboxListDTO.nothi.subject;
                nothiOutbox.shakha = nothiOutboxListDTO.nothi.office_unit_name;
                nothiOutbox.prapok = nothiOutboxListDTO.to.officer + " "+ nothiOutboxListDTO.to.designation +","+ nothiOutboxListDTO.to.office_unit +","+ nothiOutboxListDTO.to.office;
                nothiOutbox.bortomanDesk = nothiOutboxListDTO.desk.officer+" "+ nothiOutboxListDTO.desk.designation +","+ nothiOutboxListDTO.desk.office_unit +","+ nothiOutboxListDTO.desk.office;
                nothiOutbox.lastdate = "নোটের সর্বশেষ তারিখঃ " + nothiOutboxListDTO.nothi.last_note_date;
                i = i + 1;
                nothiOutboxs.Add(nothiOutbox);

            }
            nothiListFlowLayoutPanel.Controls.Clear();
            nothiListFlowLayoutPanel.AutoScroll = true;
            nothiListFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            nothiListFlowLayoutPanel.WrapContents = false;

            for (int j = 0; j <= nothiOutboxs.Count - 1; j++)
            {
                nothiListFlowLayoutPanel.Controls.Add(nothiOutboxs[j]);
            }
        }


        private void LoadNothiAll()
        {
            var token = _userService.GetToken();
            var nothiAll = _nothiAll.GetNothiAll(token);

            if (nothiAll.status == "success")
            {
                if (nothiAll.data.records.Count > 0)
                {
                    LoadNothiAllinPanel(nothiAll.data.records);
                }

            }
        }
        private void LoadNothiAllinPanel(List<NothiListAllRecordsDTO> nothiAllLists)
        {

            List<NothiAll> nothiAlls = new List<NothiAll>();
            int i = 0;
            foreach (NothiListAllRecordsDTO nothiAllListDTO in nothiAllLists)
            {
                if (nothiAllListDTO.desk != null && nothiAllListDTO.status != null)
                {
                    NothiAll nothiAll = new NothiAll();
                    nothiAll.nothi = nothiAllListDTO.nothi.nothi_no + " " + nothiAllListDTO.nothi.subject;
                    nothiAll.shakha = "নথির শাখা: " + nothiAllListDTO.nothi.office_unit_name;
                    nothiAll.desk = "ডেস্ক: " + nothiAllListDTO.desk.note_count.ToString();
                    nothiAll.noteTotal = nothiAllListDTO.status.total;
                    nothiAll.permitted = nothiAllListDTO.status.permitted;
                    nothiAll.onishponno = nothiAllListDTO.status.onishponno;
                    nothiAll.nishponno = nothiAllListDTO.status.nishponno;
                    nothiAll.archived = nothiAllListDTO.status.archived;
                    nothiAll.noteLastDate = "নোটের সর্বশেষ তারিখঃ " + nothiAllListDTO.nothi.last_note_date;
                    i = i + 1;
                    nothiAlls.Add(nothiAll);
                }
            }
            nothiListFlowLayoutPanel.Controls.Clear();
            nothiListFlowLayoutPanel.AutoScroll = true;
            nothiListFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            nothiListFlowLayoutPanel.WrapContents = false;

            for (int j = 0; j <= nothiAlls.Count - 1; j++)
            {
                nothiListFlowLayoutPanel.Controls.Add(nothiAlls[j]);
            }
        }

        private void btnGardFile_Click(object sender, EventArgs e)
        {
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);
        }
        private void ShowSubMenu(Panel gardFileDropDownPanel)
        {
            if (gardFileDropDownPanel.Visible == true)
            {
                gardFileDropDownPanel.Visible = false;
            }
            else
            {
                gardFileDropDownPanel.Visible = true;
            }
        }
        public dynamic newNothi = UserControlFactory.Create<NewNothi>();
        

        private void btnPotrojari_Click(object sender, EventArgs e)
        {
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);
            newNothi.Visible = false;
            nothiListFlowLayoutPanel.Visible = false;
            pnlNothiNoteTalika.Visible = false;
        }
        private void ResetAllMenuButtonSelection()
        {
            btnNothiInbox.BackColor = Color.White;
            btnNothiInbox.ForeColor = Color.Black;

            btnNothiOutbox.BackColor = Color.White;
            btnNothiOutbox.ForeColor = Color.Black;

            btnNothiAll.BackColor = Color.White;
            btnNothiAll.ForeColor = Color.Black;


            btnNewNothi.BackColor = Color.White;
            btnNewNothi.ForeColor = Color.Black;

        }
        private void SelectButton(Button button)
        {
            button.BackColor = Color.FromArgb(243, 246, 249);
            button.ForeColor = Color.FromArgb(78, 165, 254);
        }

        private void nothiModulePanel_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<Nothi>();
            form.ShowDialog();
        }

        private void dakModulePanel_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<Dashboard>();
            form.ShowDialog();
        }

        private void dakModulePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void nothiModulePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void detailPanelDropDownButton_Click(object sender, EventArgs e)
        {

        }

        private void detailPanelDropDownButton_MouseHover(object sender, EventArgs e)
        {
            ClickedDetaiPanleDropDownButtonStyle();
        }
        private void ClickedDetaiPanleDropDownButtonStyle()
        {
            detailPanelDropDownButton.IconColor = Color.White;
            detailPanelDropDownButton.BackColor = Color.FromArgb(136, 80, 250);
        }
        private void detailPanelDropDownButton_MouseLeave(object sender, EventArgs e)
        {
            NormalDetaiPanleDropDownButtonStyle();
        }
        private void NormalDetaiPanleDropDownButtonStyle()
        {
            if (detailsNothiSearcPanel.Visible)
            {
                ClickedDetaiPanleDropDownButtonStyle();

            }
            else
            {

                detailPanelDropDownButton.IconColor = Color.FromArgb(136, 80, 250);
                detailPanelDropDownButton.BackColor = Color.FromArgb(236, 227, 253);
            }

        }
        private void detailPanelDropDownButton_Click_1(object sender, EventArgs e)
        {
            if (detailsNothiSearcPanel.Visible == true)
            {
                detailsNothiSearcPanel.Visible = false;
            }
            else
            {
                detailsNothiSearcPanel.Visible = true;
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<Nothi>();
            form.ShowDialog();
        }

        private void nothiModuleNameLabel_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<Nothi>();
            form.ShowDialog();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<Nothi>();
            form.ShowDialog();
        }

        private void dakModulePanel_MouseHover(object sender, EventArgs e)
        {
            dakModulePanel.BackColor = Color.FromArgb(245, 245, 249);
            dakModuleNameLabel.ForeColor = Color.Blue;
        }

        private void dakModulePanel_MouseLeave(object sender, EventArgs e)
        {
            dakModulePanel.BackColor = Color.Transparent;
            dakModuleNameLabel.ForeColor = Color.Black;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<Dashboard>();
            form.ShowDialog();
        }

        private void dakModuleNameLabel_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<Dashboard>();
            form.ShowDialog();
        }

        private void moduleDakCountLabel_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<Dashboard>();
            form.ShowDialog();
        }

        private void iconButton1_MouseHover(object sender, EventArgs e)
        {
            dakModulePanel.BackColor = Color.FromArgb(245, 245, 249);
            dakModuleNameLabel.ForeColor = Color.Blue;
            
        }

        private void iconButton1_MouseLeave(object sender, EventArgs e)
        {
            dakModulePanel.BackColor = Color.Transparent;
            dakModuleNameLabel.ForeColor = Color.Black;
        }
        private void dakModuleNameLabel_MouseHover(object sender, EventArgs e)
        {
            dakModulePanel.BackColor = Color.FromArgb(245, 245, 249);
            dakModuleNameLabel.ForeColor = Color.Blue;
        }

        private void dakModuleNameLabel_MouseLeave(object sender, EventArgs e)
        {
            dakModulePanel.BackColor = Color.Transparent;
            dakModuleNameLabel.ForeColor = Color.Black;
        }

        private void moduleDakCountLabel_MouseHover(object sender, EventArgs e)
        {
            dakModulePanel.BackColor = Color.FromArgb(245, 245, 249);
            dakModuleNameLabel.ForeColor = Color.Blue;
        }

        private void moduleDakCountLabel_MouseLeave(object sender, EventArgs e)
        {
            dakModulePanel.BackColor = Color.Transparent;
            dakModuleNameLabel.ForeColor = Color.Black;
        }

        

        private void detailSearchStopButton_Click(object sender, EventArgs e)
        {
            if (detailsNothiSearcPanel.Visible == true)
            {
                detailsNothiSearcPanel.Visible = false;
            }
            else
            {
                detailsNothiSearcPanel.Visible = true;
            }
        }

        private void btnNothiInbox_Click_1(object sender, EventArgs e)
        {
            btnNewNothi.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiAll.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiOutbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiInbox.IconColor = Color.FromArgb(78, 165, 254);
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);
            nothiListFlowLayoutPanel.Visible = true;
            pnlNothiNoteTalika.Visible = true;
            newNothi.Visible = false;
            LoadNothiInbox();
        }

        private void btnNothiOutbox_Click(object sender, EventArgs e)
        {
            btnNothiInbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNewNothi.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiAll.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiOutbox.IconColor = Color.FromArgb(78, 165, 254);
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);
            nothiListFlowLayoutPanel.Visible = true;
            pnlNothiNoteTalika.Visible = true;
            newNothi.Visible = false;
            LoadNothiOutbox();
        }

        private void btnNothiAll_Click(object sender, EventArgs e)
        {
            btnNothiInbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiOutbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNewNothi.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiAll.IconColor = Color.FromArgb(78, 165, 254);
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);
            nothiListFlowLayoutPanel.Visible = true;
            pnlNothiNoteTalika.Visible = true;
            newNothi.Visible = false;
            LoadNothiAll();
        }

        private void btnNewNothi_Click(object sender, EventArgs e)
        {
            btnNothiInbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiOutbox.IconColor = Color.FromArgb(181, 181, 195);
            btnNothiAll.IconColor = Color.FromArgb(181, 181, 195);
            btnNewNothi.IconColor = Color.FromArgb(78, 165, 254);
            ResetAllMenuButtonSelection();
            SelectButton(sender as Button);
            newNothi.Visible = true;
            newNothi.Location = new System.Drawing.Point(233, 60);
            Controls.Add(newNothi);
            newNothi.BringToFront();
            newNothi.BackColor = Color.WhiteSmoke;
        }

    }
}
