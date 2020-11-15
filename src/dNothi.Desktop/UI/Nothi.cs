using dNothi.Desktop.UI.Dak;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.NothiServices;
using dNothi.Services.UserServices;
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
    public partial class Nothi : Form
    {
        IUserService _userService { get; set; }
        INothiInboxServices _nothiInbox { get; set; }
        INothiOutboxServices _nothiOutbox { get; set; }

        public Nothi(IUserService userService, INothiInboxServices nothiInbox, INothiOutboxServices nothiOutbox)
        {
            _userService = userService;
            _nothiInbox = nothiInbox;
            _nothiOutbox = nothiOutbox;
            InitializeComponent();
            LoadNothiInbox();
        }

        designationSelect ucdesignationSelect = new designationSelect();

        private void btnNothiInbox_Click(object sender, EventArgs e)
        {
            LoadNothiInbox();
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
                NothiInbox nothiInbox = new NothiInbox();
                nothiInbox.nothi = nothiListRecordsDTO.nothi_no + " " + nothiListRecordsDTO.subject;
                nothiInbox.shakha = nothiListRecordsDTO.office_unit_name;
                nothiInbox.totalnothi = "মোট নোটঃ " + nothiListRecordsDTO.note_count;
                nothiInbox.lastdate = "নোটের সর্বশেষ তারিখঃ " + nothiListRecordsDTO.last_note_date;
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

        private void btnNothiOutbox_Click(object sender, EventArgs e)
        {
            LoadNothiOutbox();
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
    }
    }
