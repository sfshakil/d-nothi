﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.Services.UserServices;
using dNothi.Services.NothiServices;
using dNothi.JsonParser.Entity.Nothi;

namespace dNothi.Desktop.UI.Dak
{
    public partial class NothiInbox : UserControl
    {
        IUserService _userService { get; set; }
        INothiInboxNoteServices _nothiInboxNote { get; set; }

        private int originalWidth;
        private int originalHeight;
        public NothiInbox(IUserService userService, INothiInboxNoteServices nothiInboxNote)
        {
            _userService = userService;
            _nothiInboxNote = nothiInboxNote;
            InitializeComponent();
            originalWidth = this.Width;
            originalHeight = this.Height;
            pnlNewAllNote.Visible = false;
            newAllNoteFlowLayoutPanel.Visible = false;
            SetDefaultFont(this.Controls);
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
        private string _nothi;
        private string _nothiId;
        private string _shakha;
        private string _totalnothi;
        private string _lastdate;

        [Category("Custom Props")]
        public string nothi
        {
            get { return _nothi; }
            set { _nothi = value; lbNothi.Text = value; }
        }

        [Category("Custom Props")]
        public string nothiId
        {
            get { return _nothiId; }
            set { _nothiId = value; lbNothiId.Text = value; }
        }

        [Category("Custom Props")]
        public string shakha
        {
            get { return _shakha; }
            set { _shakha = value; lbShakha.Text = value; }
        }

        [Category("Custom Props")]
        public string totalnothi
        {
            get { return _totalnothi; }
            set { _totalnothi = value; lbTotalNothi.Text = "মোট নোটঃ " + string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); lbTotalNote.Text = "মোট নোটঃ " + string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))) ; }//"মোট নোটঃ " + string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }

        [Category("Custom Props")]
        public string lastdate
        {
            get { return _lastdate; }
            set { _lastdate = value; lbNoteLastDate.Text = value; }
        }

        private void iconButton3_Click_1(object sender, EventArgs e)
        {
            if (iconButton3.IconChar == FontAwesome.Sharp.IconChar.Plus)
            {
                int totalNote = Convert.ToInt32(totalnothi);
                this.Height = totalNote * 100 + originalHeight;
                this.Width = originalWidth;
                pnlNewAllNote.Visible = true;
                newAllNoteFlowLayoutPanel.Visible = true;
                iconButton3.IconChar = FontAwesome.Sharp.IconChar.Minus;
                iconButton3.IconColor = Color.White;
                iconButton3.BackColor = Color.FromArgb(27, 197, 189);
                loadnewAllNoteFlowLayoutPanel();
            }
            else
            {
                this.Height = originalHeight;
                this.Width = originalWidth;

                pnlNewAllNote.Visible = false;
                newAllNoteFlowLayoutPanel.Visible = false;

                iconButton3.IconChar = FontAwesome.Sharp.IconChar.Plus;
                iconButton3.IconColor = Color.White;
                iconButton3.BackColor = Color.FromArgb(27, 197, 189);
            }
        }
        private void loadnewAllNoteFlowLayoutPanel()
        {
            var eachNothiId = lbNothiId.Text;
            var nothiListUserParam = _userService.GetLocalDakUserParam();
            var nothiInboxNote = _nothiInboxNote.GetNothiInboxNote(nothiListUserParam, eachNothiId);

            if (nothiInboxNote.status == "success")
            {

                if (nothiInboxNote.data.records.Count > 0)
                {

                    LoadNothiNoteInboxinPanel(nothiInboxNote.data.records);

                }
            }
        }
        public void LoadNothiNoteInboxinPanel(List<NothiListInboxNoteRecordsDTO> nothiNoteInboxLists)
        {
            List<NothiNoteShomuho> nothiNoteShomuhos = new List<NothiNoteShomuho>();
            int i = 0;
            foreach (NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO in nothiNoteInboxLists)
            {
                var nothiNoteShomuho = UserControlFactory.Create<NothiNoteShomuho>();
                
                nothiNoteShomuho.note_ID = nothiListInboxNoteRecordsDTO.note.nothi_note_id.ToString();
                nothiNoteShomuho.noteSubText = nothiListInboxNoteRecordsDTO.note.note_subject_sub_text;
                nothiNoteShomuho.note_no = Convert.ToString(nothiListInboxNoteRecordsDTO.note.note_no);
                nothiNoteShomuho.noteIssueDate = nothiListInboxNoteRecordsDTO.desk.issue_date;
                nothiNoteShomuho.loadEyeIcon(nothiListInboxNoteRecordsDTO.note.can_revert);

                if (nothiListInboxNoteRecordsDTO.note.onucched_count>0)
                {
                    nothiNoteShomuho.onucched = nothiListInboxNoteRecordsDTO.note.onucched_count.ToString();
                }
                if (nothiListInboxNoteRecordsDTO.note.khoshra_potro > 0)
                {
                    nothiNoteShomuho.khosra = nothiListInboxNoteRecordsDTO.note.khoshra_potro.ToString();
                }
                if (nothiListInboxNoteRecordsDTO.note.khoshra_waiting_for_approval > 0)
                {
                    nothiNoteShomuho.khoshraWaiting = nothiListInboxNoteRecordsDTO.note.khoshra_waiting_for_approval.ToString();
                }
                if (nothiListInboxNoteRecordsDTO.note.note_subject != null && nothiListInboxNoteRecordsDTO.note.note_subject_sub_text != "")
                {
                    nothiNoteShomuho.note_subject = nothiListInboxNoteRecordsDTO.note.note_subject + " (" + nothiListInboxNoteRecordsDTO.note.note_subject_sub_text+")";
                }
                else
                {
                    nothiNoteShomuho.note_subject = nothiListInboxNoteRecordsDTO.note.note_subject;
                }
                if(nothiListInboxNoteRecordsDTO.desk.officer != null)
                {
                    nothiNoteShomuho.deskofficer = nothiListInboxNoteRecordsDTO.desk.officer;
                }
                else
                {
                    nothiNoteShomuho.deskofficer = " ";
                }
                if (nothiListInboxNoteRecordsDTO.to.officer != null && nothiListInboxNoteRecordsDTO.desk.officer != nothiListInboxNoteRecordsDTO.to.officer)
                {
                    nothiNoteShomuho.toofficer = nothiListInboxNoteRecordsDTO.to.officer;
                }
                else
                {
                    nothiNoteShomuho.toofficer = "";
                }
                i = i + 1;
                nothiNoteShomuhos.Add(nothiNoteShomuho);

            }
            newAllNoteFlowLayoutPanel.Controls.Clear();
            newAllNoteFlowLayoutPanel.AutoScroll = true;
            newAllNoteFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            newAllNoteFlowLayoutPanel.WrapContents = false;

            for (int j = 0; j <= nothiNoteShomuhos.Count - 1; j++)
            {
                newAllNoteFlowLayoutPanel.Controls.Add(nothiNoteShomuhos[j]);
            }

        }
        private void iconButton3_MouseHover_1(object sender, EventArgs e)
        {
            iconButton3.IconColor = Color.White;
            iconButton3.BackColor = Color.FromArgb(27, 197, 189);
        }

        private void iconButton3_MouseLeave_1(object sender, EventArgs e)
        {
            if (iconButton3.IconChar == FontAwesome.Sharp.IconChar.Plus)
            {
                iconButton3.IconColor = Color.FromArgb(27, 197, 189);
                iconButton3.BackColor = Color.FromArgb(201, 247, 245);

            }
        }
        public event EventHandler NothiOnumodonButtonClick;
        private void btnNothiInboxOnumodon_Click(object sender, EventArgs e)
        {
            if (this.NothiOnumodonButtonClick != null)
                this.NothiOnumodonButtonClick(sender, e);
            
            
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks button")]
        public event EventHandler NewNoteButtonClick;

        private void btnNewNote_Click(object sender, EventArgs e)
        {
            //var form = FormFactory.Create<CreateNewNotes>();
            //form.ShowDialog();
            if (this.NewNoteButtonClick != null)
                this.NewNoteButtonClick(sender, e);

        }
        
    }
}
