using dNothi.Desktop.UI.Dak;
using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using dNothi.Services.NothiServices;
using dNothi.Services.UserServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI
{
    public partial class Note : Form
    {
        private DakUserParam _dakuserparam = new DakUserParam();
        
        NoteSaveDTO newnotedata = new NoteSaveDTO();
     
        NoteView newNoteView = new NoteView();

        NothiListRecordsDTO nothiListRecords = new NothiListRecordsDTO();
        IUserService _userService { get; set; }
        IOnucchedSave _onucchedSave { get; set; }
        IOnucchedDelete _onucchedDelete { get; set; }
        IOnumodonService _onumodonService { get; set; }
        INothiNoteTalikaServices _nothiNoteTalikaServices { get; set; }
        INothiPotrangshoServices _loadPotrangsho { get; set; }
        IAllPotroServices _allPotro { get; set; }
        IKhoshraPotroServices _khoshraPotro { get; set; }
        IKhoshraPotroWaitingServices _khoshraPotroWaiting { get; set; }
        IPotrojariServices _potrojariList { get; set; }
        INothijatoServices _nothijatoList { get; set; }
        INotePotrojariServices _notePotrojariList { get; set; }
        INoteKhshraWaitingListServices _noteKhshraWaitingList { get; set; }
        INoteKhoshraListServices _noteKhoshraList { get; set; }
        IOnuchhedListServices _onuchhedList { get; set; }
        ISingleOnucchedServices _singleOnucched { get; set; }
        INoteOnucchedRevertServices _noteOnucchedRevert { get; set; }
        public Note(IUserService userService, IOnucchedSave onucchedSave, IOnumodonService onumodonService, 
            IOnucchedDelete onucchedDelete, INothiNoteTalikaServices nothiNoteTalikaServices, INothiPotrangshoServices loadPotrangsho, IAllPotroServices allPotro,
            IKhoshraPotroServices khoshraPotro, IKhoshraPotroWaitingServices khoshraPotroWaiting, IPotrojariServices potrojariList, INothijatoServices nothijatoList,
            INotePotrojariServices notePotrojariList, INoteKhshraWaitingListServices noteKhshraWaitingList, INoteKhoshraListServices noteKhoshraList,
            IOnuchhedListServices onuchhedList, ISingleOnucchedServices singleOnucched, INoteOnucchedRevertServices noteOnucchedRevert)
        {
            _userService = userService;
            _onucchedSave = onucchedSave;
            _onucchedDelete=onucchedDelete;
            _onumodonService = onumodonService;
            _dakuserparam = _userService.GetLocalDakUserParam();
            _nothiNoteTalikaServices = nothiNoteTalikaServices;
            _loadPotrangsho = loadPotrangsho;
            _allPotro = allPotro;
            _khoshraPotro = khoshraPotro;
            _khoshraPotroWaiting = khoshraPotroWaiting;
            _potrojariList = potrojariList;
            _nothijatoList = nothijatoList;
            _notePotrojariList = notePotrojariList;
            _noteKhshraWaitingList = noteKhshraWaitingList;
            _noteKhoshraList = noteKhoshraList;
            _onuchhedList = onuchhedList;
            _singleOnucched = singleOnucched;
            _noteOnucchedRevert = noteOnucchedRevert;

            InitializeComponent();
            SetDefaultFont(this.Controls);
            tinyMceEditor.CreateEditor();
            cbxNothiType.SelectedIndex = 0;
            cbxNothiType.ItemHeight = 30;
            onuchhedheaderPnl.Hide();
            PnlSave.Visible = false;
            userNameLabel.Text = _dakuserparam.officer_name + "(" + _dakuserparam.designation_label + "," + _dakuserparam.unit_label + ")";
            loadPotrangshoNotePanel();
            loadPotrangshoNothiPanel();
        }
        public NothiListInboxNoteRecordsDTO _NoteAllListDataRecordDTO { get; set; }
        public NothiListInboxNoteRecordsDTO noteAllListDataRecordDTO { get { return _NoteAllListDataRecordDTO; } set { _NoteAllListDataRecordDTO = value; } }
        public void loadPotrangshoNothiPanel()
        {
            pnlNothi.Visible = false;
            pnlKhoshra.Visible = false;
            pnlKhoshraWaiting.Visible = false;
            pnlApproved.Visible = false;
            pnlAllPotro.Visible = false;
            pnlPotrojari.Visible = false;
            pnlNothijato.Visible = false;
            pnlNoNothi.Visible = true;
        }
        public void loadPotrangshoNotePanel()
        {
            pnlNoteKhoshra.Visible = false;
            pnlNoteKhoshraWaiting.Visible = false;
            lbNote.Visible = false;
            pnlNotePotrojari.Visible = false;
            pnlNoNote.Visible = true;
        }
        public void loadNoteData(NoteSaveDTO notedata)
        {
            newnotedata = notedata;
        }
        public void loadNothiInboxRecords(NothiListRecordsDTO nothiListRecordsDTO)
        {
            nothiListRecords = nothiListRecordsDTO;
            loadNothiPotrangsho(nothiListRecordsDTO);
        }
        public void loadNothiPotrangsho(NothiListRecordsDTO nothiListRecordsDTO)
        {
            DakUserParam dakuserparam = _dakuserparam;
            NothiPotrangshoResponse loadPotrangsho = _loadPotrangsho.GetNothiPotrangsho(dakuserparam, nothiListRecordsDTO);
            if (loadPotrangsho.status == "success")
            {
                if (loadPotrangsho.data.khoshra_potro>0 || loadPotrangsho.data.khoshra_waiting_for_approval>0 || loadPotrangsho.data.all_potro>0 ||
                    loadPotrangsho.data.potrojari>0 || loadPotrangsho.data.nothijato_potro>0 || loadPotrangsho.data.approved_potro>0)
                {
                    pnlNoNothi.Visible = false;
                    if(loadPotrangsho.data.khoshra_potro > 0)
                    {
                        pnlKhoshra.Visible = true;
                        lbKhoshra.Text = string.Concat(loadPotrangsho.data.khoshra_potro.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        pnlKhoshra.Visible = false;
                    }
                    if(loadPotrangsho.data.khoshra_waiting_for_approval > 0)
                    {
                        pnlKhoshraWaiting.Visible = true;
                        lbKhoshraWaiting.Text = string.Concat(loadPotrangsho.data.khoshra_waiting_for_approval.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        pnlKhoshraWaiting.Visible = false;
                    }
                    if(loadPotrangsho.data.all_potro > 0)
                    {
                        pnlAllPotro.Visible = true;
                        lbAllPotro.Text = string.Concat(loadPotrangsho.data.all_potro.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        pnlAllPotro.Visible = false;
                    }
                    if(loadPotrangsho.data.potrojari > 0)
                    {
                        pnlPotrojari.Visible = true;
                        lbPotrojari.Text = string.Concat(loadPotrangsho.data.potrojari.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        pnlPotrojari.Visible = false;
                    }
                    if(loadPotrangsho.data.nothijato_potro > 0)
                    {
                        pnlNothijato.Visible = true;
                        lbNothijato.Text = string.Concat(loadPotrangsho.data.nothijato_potro.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        pnlNothijato.Visible = false;
                    }
                    if(loadPotrangsho.data.approved_potro > 0)
                    {
                        pnlApproved.Visible = true;
                        lbApprovedPotro.Text = string.Concat(loadPotrangsho.data.approved_potro.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        pnlApproved.Visible = false;
                    }
                    pnlNothi.Visible = true;
                }
                else
                {
                    pnlNothi.Visible = false;
                    pnlKhoshra.Visible = false;
                    pnlKhoshraWaiting.Visible = false;
                    pnlApproved.Visible = false;
                    pnlAllPotro.Visible = false;
                    pnlPotrojari.Visible = false;
                    pnlNothijato.Visible = false;
                    pnlNoNothi.Visible = true;
                }
            }
        }
        public int loadNoteView(NoteView noteView)
        {
            NoteAllListResponse allNoteList = _nothiNoteTalikaServices.GetNoteListAll(_dakuserparam, nothiListRecords.id);
            var i = allNoteList.data.total_records;
            noteView.totalNothi = i.ToString();
         
            



            lbNothiType.Text = "বাছাইকৃত নোট (১)";
            noteViewFLP.Controls.Clear();
            newNoteView = noteView;

            noteViewFLP.Controls.Add(noteView);
            noteView.CheckBoxClick += delegate (object sender, EventArgs e) { checkBox_Change(_NoteAllListDataRecordDTO, newNoteView, newNoteView._checkBoxValue); };
            return i;
        }
        private string checkSub;
        private int checkNoteId;
        private void checkBox_Change(NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO, NoteView noteView, bool is_checked)
        {
            if (is_checked)
            {

                onucchedEditorPanel.Visible = true;
                onucchedActionPanel.Visible = true;
                onuchhedFLP.Visible = true;
                onuchhedPnl.Visible = true;
                noteSubjectPanel.Visible = true;
                tabButtonPanel.Visible = true;

                OnucchedListResponse onucchedList = _onuchhedList.GetAllOnucchedList(_dakuserparam, nothiListRecords.id, nothiListInboxNoteRecordsDTO.note.nothi_note_id);
                if (onucchedList.data.total_records > 0)
                {
                    onuchhedFLP.Visible = true;
                    onuchhedFLP.Controls.Clear();
                    foreach (OnucchedListDataRecordDTO onucchedsingleListRec in onucchedList.data.records)
                    {
                        SingleOnucchedResponse singleOnucched = _singleOnucched.GetSingleOnucched(_dakuserparam, nothiListRecords.id, nothiListInboxNoteRecordsDTO.note.nothi_note_id, onucchedsingleListRec.id);
                        if (singleOnucched.data.total_records > 0)
                        {
                            var rec = singleOnucched.data.records;
                            lbNoteTotl.Text = "নোটঃ " + nothiListInboxNoteRecordsDTO.note.note_subject;
                            lbNoteSubject.Text = nothiListInboxNoteRecordsDTO.note.note_subject_sub_text;
                            lbNothiLastDate.Text = nothiListInboxNoteRecordsDTO.to.issue_date;

                            onuchhedheaderPnl.Visible = false;
                            btnSave.Visible = false;
                            btnSaveArrow.Visible = false;
                            btnCancel.Visible = false;

                            //onuchhedheaderPnl.Visible = true;
                            //onuchhedFLP.Visible = true;
                            btnWriteOnuchhed.Visible = true;
                            btnSend.Visible = true;
                            onucchedEditorPanel.Visible = false;

                            var separateOnucched = UserControlFactory.Create<SeparateOnuchhed>();
                            separateOnucched.office = onucchedsingleListRec.employee_name + " " + onucchedsingleListRec.created;
                            separateOnucched.noteNo(lbNoteTotl.Text.Substring(lbNoteTotl.Text.IndexOf("টঃ") + 2), onucchedsingleListRec.onucched_no);
                            separateOnucched.createDate = onucchedsingleListRec.created;
                            try
                            {
                                separateOnucched.subjectBrowser = Encoding.UTF8.GetString(Convert.FromBase64String(rec[0].onucched.note_description));
                            }
                            catch
                            {

                            }
                            foreach (SingleOnucchedRecordSignatureDTO singleRecSignature in rec[0].signature)
                            {
                                separateOnucched.loadOnuchhedSignature(singleRecSignature);
                            }
                            onuchhedFLP.Controls.Add(separateOnucched);
                            if (nothiListInboxNoteRecordsDTO.note.can_revert == 1)
                            {
                                checkSub = nothiListInboxNoteRecordsDTO.note.note_subject_sub_text;
                                checkNoteId = nothiListInboxNoteRecordsDTO.note.nothi_note_id;
                                btnCanRevert.Visible = true;
                                btnWriteOnuchhed.Visible = false;
                                btnSend.Visible = false;
                                btnSave.Visible = false;
                                btnSaveArrow.Visible = false;
                                btnCancel.Visible = false;
                            }
                        }
                    }
                }

                if (nothiListInboxNoteRecordsDTO.note.khoshra_potro > 0 || nothiListInboxNoteRecordsDTO.note.khoshra_waiting_for_approval > 0 || nothiListInboxNoteRecordsDTO.note.potrojari > 0)
                {
                    pnlNoNote.Visible = false;

                    if (nothiListInboxNoteRecordsDTO.note.khoshra_waiting_for_approval > 0)
                    {
                        pnlNoteKhoshraWaiting.Visible = true;

                        lbNoteKhoshraWaiting.Text = string.Concat(nothiListInboxNoteRecordsDTO.note.khoshra_waiting_for_approval.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        pnlNoteKhoshraWaiting.Visible = false;
                    }

                    if (nothiListInboxNoteRecordsDTO.note.khoshra_potro > 0)
                    {
                        pnlNoteKhoshra.Visible = true;
                        lbNoteKhoshra.Text = string.Concat(nothiListInboxNoteRecordsDTO.note.khoshra_potro.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        pnlNoteKhoshra.Visible = false;
                    }
                    lbNote.Visible = true;
                    if (nothiListInboxNoteRecordsDTO.note.potrojari > 0)
                    {
                        pnlNotePotrojari.Visible = true;
                        lbNotePotrojari.Text = string.Concat(nothiListInboxNoteRecordsDTO.note.potrojari.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        pnlNotePotrojari.Visible = false;
                    }
                }
                else
                {
                    lbNoteTotl.Text = "নোটঃ " + nothiListInboxNoteRecordsDTO.note.note_subject;
                    lbNoteSubject.Text = nothiListInboxNoteRecordsDTO.note.note_subject_sub_text;
                    lbNothiLastDate.Text = nothiListInboxNoteRecordsDTO.nothi.nothi_created_date;

                    onuchhedheaderPnl.Visible = false;
                    onuchhedFLP.Visible = false;

                    lbNote.Visible = false;
                    pnlNoteKhoshra.Visible = false;
                    pnlNoteKhoshraWaiting.Visible = false;
                    pnlNotePotrojari.Visible = false;
                    pnlNoNote.Visible = true;

                    btnCanRevert.Visible = false;
                    btnWriteOnuchhed.Visible = false;
                    btnSend.Visible = false;

                    btnSave.Visible = true;
                    btnSaveArrow.Visible = true;
                    btnCancel.Visible = true;

                    onucchedEditorPanel.Visible = true;
                    panel22.Visible = true;
                    tinyMceEditor.Visible = true;
                    panel24.Visible = true;
                    panel28.Visible = true;
                    tinyMceEditor.HtmlContent = "";
                    fileAddFLP.Controls.Clear();
                    noteFileUploads.Clear();


                }

            }
            else
            {
                onucchedEditorPanel.Visible = false;
                onucchedActionPanel.Visible = false;
                onuchhedFLP.Controls.Clear();
                noteSubjectPanel.Visible = false;
                tabButtonPanel.Visible = false;
            }

        }

        private void checkBox_Click(NoteListDataRecordNoteDTO list, EventArgs e, NoteView noteView, bool _checkBoxValue)
        {
           if(_checkBoxValue)
            {


                onucchedEditorPanel.Visible = true;
                onucchedActionPanel.Visible = true;
                onuchhedFLP.Visible = true;
                onuchhedPnl.Visible = true;
                noteSubjectPanel.Visible = true;
                tabButtonPanel.Visible = true;


                OnucchedListResponse onucchedList = _onuchhedList.GetAllOnucchedList(_dakuserparam, nothiListRecords.id, list.nothi_note_id);
                if (onucchedList.data.total_records > 0)
                {
                   // onuchhedFLP.Visible = true;
                    onuchhedheaderPnl.Visible = false;
                    onuchhedFLP.Controls.Clear();
                    foreach(OnucchedListDataRecordDTO onucchedsingleListRec in onucchedList.data.records)
                    {
                        SingleOnucchedResponse singleOnucched = _singleOnucched.GetSingleOnucched(_dakuserparam, nothiListRecords.id, list.nothi_note_id, onucchedsingleListRec.id);
                        if (singleOnucched.data.total_records > 0)
                        {
                            var rec = singleOnucched.data.records;
                            lbNoteTotl.Text = "নোটঃ " + list.note_status;
                            lbNoteSubject.Text = list.note_subject_sub_text;
                            lbNothiLastDate.Text = list.date;

                            
                           

                            //onuchhedheaderPnl.Visible = true;
                            //onuchhedFLP.Visible = true;
                            //btnWriteOnuchhed.Visible = true;
                            //btnSend.Visible = true;
                            //onucchedEditorPanel.Visible = false;

                            var separateOnucched = UserControlFactory.Create<SeparateOnuchhed>();
                            separateOnucched.office = onucchedsingleListRec.employee_name + " " + onucchedsingleListRec.created;
                            separateOnucched.noteNo(lbNoteTotl.Text.Substring(lbNoteTotl.Text.IndexOf("টঃ") + 2), onucchedsingleListRec.onucched_no);
                            separateOnucched.createDate = onucchedsingleListRec.created;
                            try
                            {
                                separateOnucched.subjectBrowser = Encoding.UTF8.GetString(Convert.FromBase64String(rec[0].onucched.note_description));
                            }
                            catch
                            {

                            }
                            foreach (SingleOnucchedRecordSignatureDTO singleRecSignature in rec[0].signature)
                            {
                                separateOnucched.loadOnuchhedSignature(singleRecSignature);
                            }
                            onuchhedFLP.Controls.Add(separateOnucched);
                            if (list.can_revert == 1)
                            {
                                checkSub = list.note_subject_sub_text;
                                checkNoteId = list.nothi_note_id;
                                btnCanRevert.Visible = true;
                                btnWriteOnuchhed.Visible = false;
                                btnSend.Visible = false;
                                btnSave.Visible = false;
                                btnSaveArrow.Visible = false;
                                btnCancel.Visible = false;
                            }
                        }
                    }
                }

                if (list.khoshra_potro > 0 || list.khoshra_waiting_for_approval > 0 || list.potrojari > 0)
                {
                    pnlNoNote.Visible = false;

                    if (list.khoshra_waiting_for_approval > 0)
                    {
                        pnlNoteKhoshraWaiting.Visible = true;

                        lbNoteKhoshraWaiting.Text = string.Concat(list.khoshra_waiting_for_approval.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        pnlNoteKhoshraWaiting.Visible = false;
                    }

                    if (list.khoshra_potro > 0)
                    {
                        pnlNoteKhoshra.Visible = true;
                        lbNoteKhoshra.Text = string.Concat(list.khoshra_potro.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        pnlNoteKhoshra.Visible = false;
                    }
                    lbNote.Visible = true;
                    if (list.potrojari > 0)
                    {
                        pnlNotePotrojari.Visible = true;
                        lbNotePotrojari.Text = string.Concat(list.potrojari.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        pnlNotePotrojari.Visible = false;
                    }
                }
                else
                {
                    lbNoteTotl.Text = "নোটঃ " + list.note_status;
                    lbNoteSubject.Text = list.note_subject_sub_text;
                    lbNothiLastDate.Text = list.date;

                    onuchhedheaderPnl.Visible = false;
                    onuchhedFLP.Visible = false;

                    lbNote.Visible = false;
                    pnlNoteKhoshra.Visible = false;
                    pnlNoteKhoshraWaiting.Visible = false;
                    pnlNotePotrojari.Visible = false;
                    pnlNoNote.Visible = true;

                    btnCanRevert.Visible = false;
                    btnWriteOnuchhed.Visible = false;
                    btnSend.Visible = false;

                    btnSave.Visible = true;
                    btnSaveArrow.Visible = true;
                    btnCancel.Visible = true;

                    onucchedEditorPanel.Visible = true;
                    panel22.Visible = true;
                    tinyMceEditor.Visible = true;
                    panel24.Visible = true;
                    panel28.Visible = true;
                    tinyMceEditor.HtmlContent = "";
                    fileAddFLP.Controls.Clear();
                    noteFileUploads.Clear();


                }
            }
            else
            {
                onucchedEditorPanel.Visible = false;
                onucchedActionPanel.Visible = false;
                onuchhedFLP.Controls.Clear();
                noteSubjectPanel.Visible = false;
                tabButtonPanel.Visible = false;
            }
        }

        private string _nothiShakha;
        private string _nothiNo;
        private string _nothiSubject;
        private string _noteTotal;
        private string _office;
        private string _totalRange;

        [Category("Custom Props")]
        public string office
        {
            get { return _office; }
            set { _office = value; lbOffice.Text = value; }
        }

        [Category("Custom Props")]
        public string nothiShakha
        {
            get { return _nothiShakha; }
            set { _nothiShakha = value; lbNoteShakha.Text = value; }
        }

        [Category("Custom Props")]
        public string nothiNo
        {
            get { return _nothiNo; }
            set { _nothiNo = value; lbNothiNo.Text = value; }
        }

        [Category("Custom Props")]
        public string nothiSubject
        {
            get { return _nothiSubject; }
            set { _nothiSubject = value; lbSubject.Text = value; }
        }
        private string _nothiLastDate;
        private string _noteSubject;
        [Category("Custom Props")]
        public string noteTotal
        {
            get { return _noteTotal; }
            set { _noteTotal = value; 
                string vl = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0')));
                lbNoteTotl.Text = "নোটঃ " + vl;
                lbNoteTtl.Text = vl+ ".০"; }
        }
        public string totalRange
        {
            get { return _noteTotal; }
            set { _noteTotal = value;
                string vl = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0')));
                lbTotalRange.Text = vl+"-"+vl;}
        }

        [Category("Custom Props")]
        public string nothiLastDate
        {
            get { return _nothiLastDate; }
            set { _nothiLastDate = value; lbNothiLastDate.Text = value; }//string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }

        [Category("Custom Props")]
        public string noteSubject
        {
            get { return _noteSubject; }
            set { _noteSubject = value; lbNoteSubject.Text = value; }
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

        private void btnBack_MouseHover(object sender, EventArgs e)
        {
            btnBack.BackColor = Color.FromArgb(255, 168, 0);
            btnBack.ForeColor = Color.White;
        }

        private void btnBack_MouseLeave(object sender, EventArgs e)
        {
            btnBack.BackColor = Color.White;
            btnBack.ForeColor = Color.FromArgb(255, 168, 0);
        }

        private void fileUploadPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

        }
        public new event EventHandler Click
        {
            add
            {
                base.Click += value;
                foreach (Control control in Controls)
                {
                    control.Click += value;
                }
            }
            remove
            {
                base.Click -= value;
                foreach (Control control in Controls)
                {
                    control.Click -= value;
                }
            }
        }
        
        private void btnAllNothi_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<DakNothiteUposthapitoForm>();
            form.ShowDialog();
            
        }
        
        private void fileUploadPanel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnNewNote_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<CreateNewNotes>();
            form.ShowDialog();
            
        }

        private void cbxNothiType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = cbxNothiType.Items[cbxNothiType.SelectedIndex].ToString() ;
            if (selectedItem == "বাছাইকৃত নোট")
            {
                newNoteView.CheckBoxClick += delegate (object sender1, EventArgs e1) { checkBox_Change(_NoteAllListDataRecordDTO, newNoteView, newNoteView._checkBoxValue); };
                lbNothiType.Text = "বাছাইকৃত নোট (১)";
                noteViewFLP.Controls.Clear();
                noteViewFLP.Controls.Add(newNoteView);
                
            }
            else if(selectedItem == "আগত নোট")
            {
                noteViewFLP.Controls.Clear();
                NoteListResponse inboxNoteList = _nothiNoteTalikaServices.GetNoteListInbox(_dakuserparam, nothiListRecords.id);
                lbNothiType.Text = "আগত নোট ("+ string.Concat(inboxNoteList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0'))) + ")";
                if (inboxNoteList.data.records.Count>0)
                {

                    foreach (NoteListDataRecordDTO inboxList in inboxNoteList.data.records)
                    {
                        NoteView noteView = new NoteView();
                        noteView.totalNothi = inboxList.note.note_no.ToString();
                        if (inboxList.note.note_subject_sub_text == "")
                        {
                            noteView.noteSubject = inboxList.note.note_subject;
                        }
                        else
                        {
                            noteView.noteSubject = inboxList.note.note_subject_sub_text;
                        }

                        if(inboxList.note.nothi_note_id== newNoteView._nothiNoteID)
                        {
                            noteView.checkBox = "1";
                            checkBox_Change(_NoteAllListDataRecordDTO, newNoteView, true);
                        }
                        noteView.nothiNoteID = inboxList.note.nothi_note_id;
                        noteView.CheckBoxClick += delegate (object sender1, EventArgs e1) { checkBox_Click(sender1 as NoteListDataRecordNoteDTO, e1, newNoteView,noteView._checkBoxValue); };
                        noteView.nothiLastDate = inboxList.desk.issue_date;
                        noteView.nothivukto = inboxList.note.nothivukto_potro.ToString();
                        noteView.onucchedCount = inboxList.note.onucched_count.ToString();
                        noteView.potrojari = inboxList.note.potrojari.ToString();
                        noteView.approved = inboxList.note.approved_potro.ToString();
                        noteView.khoshraWaiting = inboxList.note.khoshra_waiting_for_approval.ToString();
                        noteView.khosraPotro = inboxList.note.khoshra_potro.ToString();
                        noteView.loadEyeIcon(inboxList.note.can_revert);
                        noteView.officerInfo = inboxList.desk.officer + "," +inboxList.desk.designation+","+inboxList.desk.office_unit+","+inboxList.desk.office;//nothiListRecords.office_name + "," + nothiListRecords.office_designation_name + "," + nothiListRecords.office_unit_name + "," + _dakuserparam.office_label;
                        noteViewFLP.Controls.Add(noteView);
                    }
                }
                else
                {
                    noteViewFLP.Controls.Clear();
                }
            }
            else if (selectedItem == "প্রেরিত নোট")
            {
                noteViewFLP.Controls.Clear();
                NoteListResponse sentNoteList = _nothiNoteTalikaServices.GetNoteListSent(_dakuserparam, nothiListRecords.id);
                lbNothiType.Text = "প্রেরিত নোট (" + string.Concat(sentNoteList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0'))) + ")";
                if (sentNoteList.data.records.Count > 0)
                {

                    foreach (NoteListDataRecordDTO sentList in sentNoteList.data.records)
                    {
                        NoteView noteView = new NoteView();
                        noteView.totalNothi = sentList.note.note_no.ToString();
                        if (sentList.note.note_subject_sub_text == "")
                        {
                            noteView.noteSubject = sentList.note.note_subject;
                        }
                        else
                        {
                            noteView.noteSubject = sentList.note.note_subject_sub_text;
                        }
                        if (sentList.note.nothi_note_id == newNoteView._nothiNoteID)
                        {
                            noteView.checkBox = "1";
                            checkBox_Change(_NoteAllListDataRecordDTO, newNoteView, true);
                        }
                        noteView.nothiNoteID = sentList.note.nothi_note_id;
                        noteView.CheckBoxClick += delegate (object sender1, EventArgs e1) { checkBox_Click(sender1 as NoteListDataRecordNoteDTO, e1, newNoteView, noteView._checkBoxValue); };
                        noteView.nothiLastDate = sentList.desk.issue_date; 
                        noteView.nothivukto = sentList.note.nothivukto_potro.ToString();
                        noteView.onucchedCount = sentList.note.onucched_count.ToString();
                        noteView.potrojari = sentList.note.potrojari.ToString();
                        noteView.approved = sentList.note.approved_potro.ToString();
                        noteView.khoshraWaiting = sentList.note.khoshra_waiting_for_approval.ToString();
                        noteView.khosraPotro = sentList.note.khoshra_potro.ToString();
                        noteView.loadEyeIcon(sentList.note.can_revert);
                        noteView.officerInfo = sentList.desk.officer + "," + sentList.desk.designation + "," + sentList.desk.office_unit + "," + sentList.desk.office;//nothiListRecords.office_name + "," + nothiListRecords.office_designation_name + "," + nothiListRecords.office_unit_name + "," + _dakuserparam.office_label;
                        noteViewFLP.Controls.Add(noteView);
                    }
                }
                else
                {
                    noteViewFLP.Controls.Clear();
                }
            }
            else if (selectedItem == "সকল নোট")
            {
                noteViewFLP.Controls.Clear();
                NoteAllListResponse allNoteList = _nothiNoteTalikaServices.GetNoteListAll(_dakuserparam, nothiListRecords.id);
                lbNothiType.Text = "সকল নোট (" + string.Concat(allNoteList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0'))) + ")";
                if (allNoteList.data.records.Count > 0)
                {

                    foreach (NoteAllListDataRecordDTO allList in allNoteList.data.records)
                    {
                        
                        if (allList.deskDtoList.Count > 0)
                        {
                            NoteView noteView = new NoteView();
                            noteView.totalNothi = allList.note.note_no.ToString();
                            if (allList.note.note_subject_sub_text == "")
                            {
                                noteView.noteSubject = allList.note.note_subject;
                            }
                            else
                            {
                                noteView.noteSubject = allList.note.note_subject_sub_text;
                            }
                            if (allList.note.nothi_note_id == newNoteView._nothiNoteID)
                            {
                                noteView.checkBox = "1";
                                checkBox_Change(_NoteAllListDataRecordDTO, newNoteView, true);
                            }
                            noteView.nothiNoteID = allList.note.nothi_note_id;
                            noteView.CheckBoxClick += delegate (object sender1, EventArgs e1) { checkBox_Click(sender1 as NoteListDataRecordNoteDTO, e1, newNoteView, noteView._checkBoxValue); };
                            noteView.nothiLastDate = allList.deskDtoList[0].issue_date;
                            noteView.nothivukto = allList.note.nothivukto_potro.ToString();
                            noteView.onucchedCount = allList.note.onucched_count.ToString();
                            noteView.potrojari = allList.note.potrojari.ToString();
                            noteView.approved = allList.note.approved_potro.ToString();
                            noteView.khoshraWaiting = allList.note.khoshra_waiting_for_approval.ToString();
                            noteView.khosraPotro = allList.note.khoshra_potro.ToString();
                            noteView.loadEyeIcon(allList.note.can_revert);
                            noteView.officerInfo = allList.deskDtoList[0].officer + "," + allList.deskDtoList[0].designation + "," + allList.deskDtoList[0].office_unit + "," + allList.deskDtoList[0].office;//nothiListRecords.office_name + "," + nothiListRecords.office_designation_name + "," + nothiListRecords.office_unit_name + "," + _dakuserparam.office_label;
                            noteViewFLP.Controls.Add(noteView);
                        }
                        else 
                        {
                            NoteViewNotInCurrentDesk noteViewNotInCurrentDesk = new NoteViewNotInCurrentDesk();
                            noteViewNotInCurrentDesk.totalNothi = allList.note.note_no.ToString();
                            noteViewNotInCurrentDesk.noteSubject = allList.note.note_subject_sub_text;
                            noteViewFLP.Controls.Add(noteViewNotInCurrentDesk);
                        }
                        
                    }
                }
                else
                {
                    noteViewFLP.Controls.Clear();
                }
            }
        }

        DakFileUploadParam _dakFileUploadParam = new DakFileUploadParam();
        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", "JPG", "PNG", ".PNG" };
        public static readonly List<string> PdfExtensions = new List<string> { ".PDF", "PDF", ".Doc", "Doc", ".Docx", "Docx", ".XLS", "XLS", ".CSV", "CSV", ".MP3", "MP3", ".M4p", "M4p", ".MP4", "MP4", ".PPT", "PPT", ".PPTX", "PPTX" };



        private void fileUploadPanel_Paint_3(object sender, PaintEventArgs e)
        {

        }
        int fileuploadDoneFlag = 0;
        List<NoteFileUpload> noteFileUploads = new List<NoteFileUpload>();
        private void fileUploadPanel_Click_1(object sender, EventArgs e)
        {

            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Files (*.jpg;*.PNG;*.PDF;*.Doc;*.Docx;*.XLS;*.CSV;*.PPT;*.PPTX;*.MP3;*.M4p;*.MP4;)|*.jpg;*.PNG;*.PDF;*.Doc;*.Docx;*.XLS;*.CSV;*.PPT;*.PPTX;*.MP3;*.M4p;*.MP4;";
            //opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                _dakFileUploadParam.user_file_name = new System.IO.FileInfo(opnfd.FileName).Name;



                //Read the contents of the file into a stream
                var fileStream = opnfd.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    _dakFileUploadParam.content = reader.ReadToEnd();
                }


                // _dakFileUploadParam.file_size_in_kb=opnfd.


                var size = new System.IO.FileInfo(opnfd.FileName).Length;

                _dakFileUploadParam.file_size_in_kb = size.ToString() + " KB";



                DakUploadedFileResponse dakUploadedFileResponse = new DakUploadedFileResponse();

                using (var form = FormFactory.Create<Dashboard>())
                {
                    dakUploadedFileResponse = form.UploadFile(_dakFileUploadParam);
                }

                if (dakUploadedFileResponse.status == "success")
                {
                    if (dakUploadedFileResponse.data.Count > 0)
                    {
                        fileuploadDoneFlag = 1;
                        //attachmentListFlowLayoutPanel.Controls.Clear();
                        NoteFileUpload noteFileUpload = new NoteFileUpload();
                        if (ImageExtensions.Contains(new System.IO.FileInfo(opnfd.FileName).Extension.ToUpperInvariant()))
                        {
                            noteFileUpload.imgSource = opnfd.FileName;
                            noteFileUpload.fileexension = dakUploadedFileResponse.data[0].file_size_in_kb;
                            noteFileUpload.attachmentName = dakUploadedFileResponse.data[0].user_file_name;
                            noteFileUploads.Add(noteFileUpload);
                            fileAddFLP.Controls.Add(noteFileUpload);
                            //dakUploadAttachmentTableRow.isAllowedforMulpotro = true;
                            //dakUploadAttachmentTableRow._isAllowedforOCR = true;

                            using (Image image = Image.FromFile(opnfd.FileName))
                            {
                                using (MemoryStream m = new MemoryStream())
                                {
                                    image.Save(m, image.RawFormat);
                                    byte[] imageBytes = m.ToArray();

                                    // Convert byte[] to Base64 String
                                    //noteFileUpload.imageBase64String = Convert.ToBase64String(imageBytes);

                                }
                            }




                        }
                        else if (PdfExtensions.Contains(new System.IO.FileInfo(opnfd.FileName).Extension.ToUpperInvariant()))
                        {
                            noteFileUpload.imgSource = "";
                            noteFileUpload.fileexension = dakUploadedFileResponse.data[0].file_size_in_kb;
                            noteFileUpload.attachmentName = dakUploadedFileResponse.data[0].user_file_name;
                            noteFileUploads.Add(noteFileUpload);
                            fileAddFLP.Controls.Add(noteFileUpload);

                        }
                        else
                        {
                            NoteFileDelete noteFileDelete = new NoteFileDelete();
                            noteFileDelete.attachmentName = dakUploadedFileResponse.data[0].user_file_name;
                            noteFileDelete.fileexension = dakUploadedFileResponse.data[0].file_size_in_kb;
                            noteFileUploads.Add(noteFileUpload);
                            //dakUploadAttachmentTableRow.isAllowedforMulpotro = false;
                        }



                        //dakUploadAttachmentTableRow.OCRButtonClick += delegate (object oCRSender, EventArgs oCREvent) { OCRControl_ButtonClick(sender, e, dakUploadAttachmentTableRow.imageBase64String, dakUploadAttachmentTableRow._dakAttachment, dakUploadAttachmentTableRow.fileexension); };
                        //dakUploadAttachmentTableRow.DeleteButtonClick += delegate (object deleteSender, EventArgs deleteeVent) { DeleteControl_ButtonClick(sender, e, dakUploadAttachmentTableRow._dakAttachment); };




                    }
                }

            }
        }
        List<DakUploadedFileResponse> onuchhedSaveWithAttachments = new List<DakUploadedFileResponse>();
        private void fileUploadButton_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            //opnfd.DefaultExt = "txt";
            opnfd.Filter = "Files (*.jpg;*.PNG;*.PDF;*.Doc;*.Docx;*.XLS;*.CSV;*.PPT;*.PPTX;*.MP3;*.M4p;*.MP4;)|*.jpg;*.PNG;*.PDF;*.Doc;*.Docx;*.XLS;*.CSV;*.PPT;*.PPTX;*.MP3;*.M4p;*.MP4;";
            //opnfd.Filter = "Pdf Files (*.PDF;)|*.PDF;";
            //opnfd.Filter = "Word Files ()|";
            //opnfd.Filter = "Excel Files ()|";
            //opnfd.Filter = "Excel Files ()|";
            //opnfd.Filter = "Audio Files ()|";
            //opnfd.Filter = "Video Files ()|";
            //opnfd.Filter = "ALL Files (*.*)|*.*";

            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                _dakFileUploadParam.user_file_name = new System.IO.FileInfo(opnfd.FileName).Name;



                //Read the contents of the file into a stream
                var fileStream = opnfd.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    _dakFileUploadParam.content = reader.ReadToEnd();
                }


                // _dakFileUploadParam.file_size_in_kb=opnfd.


                var size = new System.IO.FileInfo(opnfd.FileName).Length;

                _dakFileUploadParam.file_size_in_kb = size.ToString() + " KB";



                DakUploadedFileResponse dakUploadedFileResponse = new DakUploadedFileResponse();

                using (var form = FormFactory.Create<Dashboard>())
                {
                    dakUploadedFileResponse = form.UploadFile(_dakFileUploadParam);
                }

                if (dakUploadedFileResponse.status == "success")
                {
                    fileuploadDoneFlag = 1;
                    if (dakUploadedFileResponse.data.Count > 0)
                    {
                        //attachmentListFlowLayoutPanel.Controls.Clear();
                        NoteFileUpload noteFileUpload = new NoteFileUpload();
                        if (ImageExtensions.Contains(new System.IO.FileInfo(opnfd.FileName).Extension.ToUpperInvariant()))
                        {
                            noteFileUpload.imgSource = opnfd.FileName;
                            noteFileUpload.fileexension = dakUploadedFileResponse.data[0].file_size_in_kb;
                            noteFileUpload.attachmentName = dakUploadedFileResponse.data[0].user_file_name;
                            fileAddFLP.Controls.Add(noteFileUpload);
                            noteFileUploads.Add(noteFileUpload);
                            //dakUploadAttachmentTableRow.isAllowedforMulpotro = true;
                            //dakUploadAttachmentTableRow._isAllowedforOCR = true;

                            using (Image image = Image.FromFile(opnfd.FileName))
                            {
                                using (MemoryStream m = new MemoryStream())
                                {
                                    image.Save(m, image.RawFormat);
                                    byte[] imageBytes = m.ToArray();

                                    // Convert byte[] to Base64 String
                                    dakUploadedFileResponse.data[0].img_base64 = Convert.ToBase64String(imageBytes);

                                }
                            }


                        }
                        else if (PdfExtensions.Contains(new System.IO.FileInfo(opnfd.FileName).Extension.ToUpperInvariant()))
                        {
                            noteFileUpload.imgSource = "";
                            noteFileUpload.fileexension = dakUploadedFileResponse.data[0].file_size_in_kb;
                            noteFileUpload.attachmentName = dakUploadedFileResponse.data[0].user_file_name;
                            fileAddFLP.Controls.Add(noteFileUpload);
                            noteFileUploads.Add(noteFileUpload);

                        }
                        else
                        {
                            NoteFileDelete noteFileDelete = new NoteFileDelete();
                            noteFileDelete.attachmentName = dakUploadedFileResponse.data[0].user_file_name;
                            noteFileDelete.fileexension = dakUploadedFileResponse.data[0].file_size_in_kb;
                            fileAddFLP.Controls.Add(noteFileDelete);
                            //dakUploadAttachmentTableRow.isAllowedforMulpotro = false;
                        }



                        //dakUploadAttachmentTableRow.OCRButtonClick += delegate (object oCRSender, EventArgs oCREvent) { OCRControl_ButtonClick(sender, e, dakUploadAttachmentTableRow.imageBase64String, dakUploadAttachmentTableRow._dakAttachment, dakUploadAttachmentTableRow.fileexension); };
                        //dakUploadAttachmentTableRow.DeleteButtonClick += delegate (object deleteSender, EventArgs deleteeVent) { DeleteControl_ButtonClick(sender, e, dakUploadAttachmentTableRow._dakAttachment); };



                        onuchhedSaveWithAttachments.Add(dakUploadedFileResponse);
                    }
                }

            }
        }

        private void panel40_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Nothi>();
            form.ShowDialog();
        }
        int onuchhedint = 0;
        List<FileAttachment> fileAttachments = new List<FileAttachment>();
        
        public string getparagraphtext(string editortext)
        {
            Match m = Regex.Match(editortext, @"<p>\s*(.+?)\s*</p>");
            if (m.Success)
            {
                return m.Groups[1].Value;
            }
            else
                return "";
        }

        private void DeleteButton_Click(string onucchedId, EventArgs e, DakUserParam dakListUserParam, NothiListRecordsDTO nothiListRecords, NoteSaveDTO newnotedata)
        {
            var onucchedDelete = _onucchedDelete.GetNothiOnuchhedDelete(dakListUserParam, nothiListRecords, newnotedata, onucchedId);
            if (onucchedDelete.status == "success")
            {
                MessageBox.Show("সফলভাবে অনুচ্ছেদটি মুছে ফেলা হয়েছে");
                if (onuchhedint == 1)
                {
                    onuchhedheaderPnl.Visible = false;
                }
                onuchhedint--;
            }
      
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!PnlSave.Visible)
            {
                PnlSave.Visible = true;
                //PnlSave.designationLinkText = _dakuserparam.designation_label + "," + _dakuserparam.unit_label + "," + _dakuserparam.office_label;
            }
            else
            {
                PnlSave.Visible = false;
            }
        }

        private void btnSaveArrow_Click(object sender, EventArgs e)
        {
            if (!PnlSave.Visible)
            {
                PnlSave.Visible = true;
                //PnlSave.designationLinkText = _dakuserparam.designation_label + "," + _dakuserparam.unit_label + "," + _dakuserparam.office_label;
            }
            else
            {
                PnlSave.Visible = false;
            }
        }

        private void btnOnuchhedSave_Click(object sender, EventArgs e)
        {
            onuchhedFLP.Controls.Clear();
            PnlSave.Visible = false;
            string noteId = "0";
            if (updateNoteID > 0)
                noteId = updateNoteID.ToString();
            //string editortext = tinyMceEditor.HtmlContent;
            string editortext = getparagraphtext(tinyMceEditor.HtmlContent);

            if (editortext != "")
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(editortext);
                var encodedEditorText = System.Convert.ToBase64String(plainTextBytes);
                onuchhedheaderPnl.Visible = true;
                OnuchhedAdd onuchhed = new OnuchhedAdd();
                onuchhed.currentDate = DateTime.Now.ToString("dd");
                onuchhed.currentMonth = DateTime.Now.ToString("MM");
                onuchhed.currentYear = DateTime.Now.ToString("yyyy");
                onuchhed.noteOnuchhed = newNoteView.totalNothi;
                onuchhed.Onuchhed = onuchhedint.ToString();
                onuchhedint++;
                onuchhed.fileflag = 0;
                
                onuchhed.body = editortext;
                int i = 1;
                foreach (NoteFileUpload notefileupload in noteFileUploads)
                {
                    FileAttachment fileattachment = new FileAttachment();
                    fileattachment.attachmentName = notefileupload.attachmentName;
                    fileattachment.attachmentSize = notefileupload.fileexension;
                    fileAttachments.Add(fileattachment);

                    onuchhed.fileflag = 1;
                    onuchhed.getAttachment(notefileupload); onuchhed.file = i; i++;
                }
                DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();

                var onucchedSave = _onucchedSave.GetNothiOnuchhedSave(noteId, dakListUserParam, onuchhedSaveWithAttachments, nothiListRecords, newnotedata, encodedEditorText);
                
                if (onucchedSave.status == "success")
                {

                    onuchhedheaderPnl.Visible = true;
                    onuchhedFLP.Visible = true;

                    onuchhed.onucchedId = onucchedSave.data.id;
                    //panel22.Visible = false;
                    tinyMceEditor.Visible = false;
                    PnlSave.Visible = false;
                    panel24.Visible = false;
                    panel28.Visible = false;

                    btnCancel.Visible = false;
                    btnSave.Visible = false;
                    btnSaveArrow.Visible = false;

                    btnWriteOnuchhed.Visible = true;
                    btnSend.Visible = true;
                    tinyMceEditor.HtmlContent = "";
                    onuchhedFLP.Controls.Add(onuchhed);
                    fileAddFLP.Controls.Clear();
                    noteFileUploads.Clear();
                }
                else
                {
                    string message = "Error";
                    MessageBox.Show(message);
                }

                onuchhed.DeleteButtonClick += delegate (object sender1, EventArgs e1) { DeleteButton_Click(sender1.ToString(), e1, dakListUserParam, nothiListRecords, newnotedata ); };
                onuchhed.EditButtonClick += delegate (object sender1, EventArgs e1) { EditButton_Click(sender1 as NoteListDataRecordNoteDTO, e1, dakListUserParam, nothiListRecords, newnotedata ); };
                
            }
            else
            {
                string message = "অনুচ্ছেদ বডি দেওয়া হইনি";
                MessageBox.Show(message);
            }

            //tinyMceEditor.Controls.Clear();
        }

        private void btnSaveWithNewOnuchhed_Click(object sender, EventArgs e)
        {
            onuchhedFLP.Controls.Clear();
            PnlSave.Visible = false;
            string noteId = "0";
            if (updateNoteID > 0)
                noteId = updateNoteID.ToString();
            //string editortext = tinyMceEditor.HtmlContent;
            string editortext = getparagraphtext(tinyMceEditor.HtmlContent);

            if (editortext != "")
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(editortext);
                var encodedEditorText = System.Convert.ToBase64String(plainTextBytes);
                onuchhedheaderPnl.Visible = true;
                OnuchhedAdd onuchhed = new OnuchhedAdd();
                onuchhed.currentDate = DateTime.Now.ToString("dd");
                onuchhed.currentMonth = DateTime.Now.ToString("MM");
                onuchhed.currentYear = DateTime.Now.ToString("yyyy");
                onuchhed.noteOnuchhed = newNoteView.totalNothi;
                onuchhed.Onuchhed = onuchhedint.ToString();
                onuchhedint++;
                onuchhed.fileflag = 0;
                
                onuchhed.body = editortext;
                int i = 1;
                foreach (NoteFileUpload notefileupload in noteFileUploads)
                {
                    FileAttachment fileattachment = new FileAttachment();
                    fileattachment.attachmentName = notefileupload.attachmentName;
                    fileattachment.attachmentSize = notefileupload.fileexension;
                    fileAttachments.Add(fileattachment);

                    onuchhed.fileflag = 1;
                    onuchhed.getAttachment(notefileupload); onuchhed.file = i; i++;
                }
                DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();

                var onucchedSave = _onucchedSave.GetNothiOnuchhedSave(noteId, dakListUserParam, onuchhedSaveWithAttachments, nothiListRecords, newnotedata, encodedEditorText);
                if (onucchedSave.status == "success")
                {
                    onuchhedheaderPnl.Visible = true;
                    onuchhedFLP.Visible = true;

                    onuchhed.onucchedId = onucchedSave.data.id;
                    panel22.Visible = true;
                    tinyMceEditor.Visible = true;
                    panel24.Visible = true;
                    panel28.Visible = true;
                    tinyMceEditor.HtmlContent = "";
                    onuchhedFLP.Controls.Add(onuchhed);
                    fileAddFLP.Controls.Clear();
                    noteFileUploads.Clear();
                }
                else
                {
                    string message = "Error";
                    MessageBox.Show(message);
                }
                onuchhed.DeleteButtonClick += delegate (object sender1, EventArgs e1) { DeleteButton_Click(sender1.ToString(), e1, dakListUserParam, nothiListRecords, newnotedata); };
                onuchhed.EditButtonClick += delegate (object sender1, EventArgs e1) { EditButton_Click(sender1 as NoteListDataRecordNoteDTO, e1, dakListUserParam, nothiListRecords, newnotedata); };

            }
            else
            {
                string message = "অনুচ্ছেদ বডি দেওয়া হইনি";
                MessageBox.Show(message);
            }

            //tinyMceEditor.Controls.Clear();
        }
        private int updateNoteID;
        public void EditButton_Click(NoteListDataRecordNoteDTO noteListDataRecordNoteDTO, EventArgs e, DakUserParam dakListUserParam, NothiListRecordsDTO nothiListRecords, NoteSaveDTO newnotedata)
        {
            //onuchhed.onucchedId = onucchedSave.data.id;
            btnWriteOnuchhed.Visible = false;
            btnSend.Visible = false;
            btnSave.Visible = true;
            btnSaveArrow.Visible = true;
            btnCancel.Visible = true;
            panel22.Visible = true;
            tinyMceEditor.Visible = true;
            panel24.Visible = true;
            panel28.Visible = true;
            tinyMceEditor.HtmlContent = noteListDataRecordNoteDTO.note_subject;
            updateNoteID = noteListDataRecordNoteDTO.nothi_note_id;
            //onuchhedFLP.Controls.Add(onuchhed);
            fileAddFLP.Controls.Clear();
            noteFileUploads.Clear();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //panel22.Visible = false;
            tinyMceEditor.Visible = false;
            panel24.Visible = false;
            panel28.Visible = false;
            PnlSave.Visible = false;

            btnCancel.Visible = false;
            btnSave.Visible = false;
            btnSaveArrow.Visible = false;

            btnWriteOnuchhed.Visible = true;
            btnSend.Visible = true;
            fileAddFLP.Controls.Clear();
            noteFileUploads.Clear();
        }

        private void btnWriteOnuchhed_Click(object sender, EventArgs e)
        {
           
            btnWriteOnuchhed.Visible = false;
            btnSend.Visible = false;
            btnSave.Visible = true;
            btnSaveArrow.Visible = true;
            btnCancel.Visible = true;

            PnlSave.Visible = false;
            panel22.Visible = true;
            tinyMceEditor.Visible = true;
            panel24.Visible = true;
            panel28.Visible = true;
            tinyMceEditor.HtmlContent = "";
            fileAddFLP.Controls.Clear();
            noteFileUploads.Clear();
            onucchedEditorPanel.Visible = true;
        }

        private void iconButton20_Click(object sender, EventArgs e)
        {
            PnlSave.Visible = false;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();

            var onumodonList = _onumodonService.GetOnumodonMembers(dakListUserParam, nothiListRecords);
            if (onumodonList.status == "success")
            {
                if (onumodonList.data.records.Count > 0)
                {
                    
                    LoadOnumodonListinPanel(onumodonList.data.records);
                }
                
                //this.ShowDialog();
            }


            
        }
        public void LoadOnumodonListinPanel(List<onumodonDataRecordDTO> records)
        {
            var nothiType = UserControlFactory.Create<NothiNextStep>();
            nothiType.Visible = true;
            nothiType.Enabled = true;
            nothiType.noteTotal = newNoteView.totalNothi;
            nothiType.noteSubject = newNoteView.noteSubject;
            nothiType.loadNewNoteData(newnotedata);
            nothiType.loadlistInboxRecord(nothiListRecords);
            nothiType.Location = new System.Drawing.Point(903, 0);
            foreach (onumodonDataRecordDTO  record in records)
            {
                nothiType.loadFlowLayout(record);

            }
            this.Controls.Add(nothiType);
            nothiType.BringToFront();

            
        }
        designationSelect designationDetailsPanelNothi = new designationSelect();
        private void userNameLabel_Click(object sender, EventArgs e)
        {
            if (designationDetailsPanelNothi.Width == 428)
            {
                designationDetailsPanelNothi.Visible = true;
             //   designationDetailsPanelNothi.designationLinkText = _dakuserparam.designation_label + "," + _dakuserparam.unit_label + "," + _dakuserparam.office_label;
                designationDetailsPanelNothi.Location = new System.Drawing.Point(227 + 689, 60);
                Controls.Add(designationDetailsPanelNothi);
                designationDetailsPanelNothi.BringToFront();
                designationDetailsPanelNothi.Width = 427;

            }
            else
            {
                designationDetailsPanelNothi.Visible = false;
                designationDetailsPanelNothi.Width = 428;
            }
        }

        private void userPictureBox_Click(object sender, EventArgs e)
        {
            if (designationDetailsPanelNothi.Width == 428)
            {
                designationDetailsPanelNothi.Visible = true;
             //   designationDetailsPanelNothi.designationLinkText = _dakuserparam.designation_label + "," + _dakuserparam.unit_label + "," + _dakuserparam.office_label;
                designationDetailsPanelNothi.Location = new System.Drawing.Point(227 + 689, 60);
                Controls.Add(designationDetailsPanelNothi);
                designationDetailsPanelNothi.BringToFront();
                designationDetailsPanelNothi.Width = 427;

            }
            else
            {
                designationDetailsPanelNothi.Visible = false;
                designationDetailsPanelNothi.Width = 428;
            }
        }

        private void profilePanel_Click(object sender, EventArgs e)
        {
            if (designationDetailsPanelNothi.Width == 428)
            {
                designationDetailsPanelNothi.Visible = true;
             //   designationDetailsPanelNothi.designationLinkText = _dakuserparam.designation_label + "," + _dakuserparam.unit_label + "," + _dakuserparam.office_label;
                designationDetailsPanelNothi.Location = new System.Drawing.Point(227 + 689, 60);
                Controls.Add(designationDetailsPanelNothi);
                designationDetailsPanelNothi.BringToFront();
                designationDetailsPanelNothi.Width = 427;

            }
            else
            {
                designationDetailsPanelNothi.Visible = false;
                designationDetailsPanelNothi.Width = 428;
            }
        }

        private void dakModulePanel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Dashboard>();
            form.ShowDialog();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Dashboard>();
            form.ShowDialog();
        }

        private void dakModuleNameLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Dashboard>();
            form.ShowDialog();
        }

        private void moduleDakCountLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Dashboard>();
            form.ShowDialog();
        }

        private void nothiModulePanel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Nothi>();
            form.ShowDialog();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Nothi>();
            form.ShowDialog();
        }

        private void nothiModuleNameLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Nothi>();
            form.ShowDialog();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = FormFactory.Create<Nothi>();
            form.ShowDialog();
        }
        public static string Base64Decode1(string base64EncodedData)
        {
            string decodedString = base64EncodedData;
            try
            {
                byte[] data = Convert.FromBase64String(decodedString);
                decodedString = Encoding.UTF8.GetString(data);
                return decodedString;
            }
            catch
            {
                decodedString = decodedString.Replace('-', '+').Replace('_', '/').Replace(',', '=').Replace("&quot;", "");
                byte[] data = Convert.FromBase64String(decodedString);
                decodedString = Encoding.UTF8.GetString(data);// &quot;
                return decodedString;
            }
        }
        public void allNextButtonVisibilityOff()
        {
            btnKhshraNext.Visible = false;
            btnKhoshraWaitingNext.Visible = false;
            btnPotrojariNext.Visible = false;
            btnAllPotroNext.Visible = false;
            btnNothijatoNext.Visible = false;
        }
        public void allPreviousButtonVisibilityOff()
        {
            btnKhoshraPrevious.Visible = false;
            btnKhoshraWaitingPrevious.Visible = false;
            btnAllPotroPrevious.Visible = false;
            btnPotrojariPrevious.Visible = false;
            btnNothijatoPrevious.Visible = false;
        }
        public void allMulpotroButtonsVisibilityOff()
        {
            btnDraftHistory.Visible = false;
            btnClone.Visible = false;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            btnApprove.Visible = false;
            btnUnapprove.Visible = false;
            btnPotrojari.Visible = false;
            btnEndrosement.Visible = false;
            btnKhoshra.Visible = false;
            btnFullEditable.Visible = false;
            btnCustom.Visible = false;
        }
        public void allMulpotroButtonsVisibilityOn(int draft_history, int clone, int edit, int delete, 
            int approve, int unapprove, int potrojari, int endrosement, int khoshra, int fulleditable, int custom)
        {
            if (draft_history == 1)
            {
                btnDraftHistory.Visible = true;
            }
            if (clone == 1)
            {
                btnClone.Visible = true;
            }
            if (edit == 1)
            {
                btnEdit.Visible = true;
            }
            if (delete == 1)
            {
                btnDelete.Visible = true;
            }
            if (approve == 1)
            {
                btnApprove.Visible = true;
            }
            if (unapprove == 1)
            {
                btnUnapprove.Visible = true;
            }
            if (potrojari == 1)
            {
                btnPotrojari.Visible = true;
            }
            if (endrosement == 1)
            {
                btnEndrosement.Visible = true;
            }
            if (khoshra == 1)
            {
                btnKhoshra.Visible = true;
            }
            if (fulleditable == 1)
            {
                btnFullEditable.Visible = true;
            }
            if (custom == 1)
            {
                btnCustom.Visible = true;
            }
        }

        public void allLbelButtonPreviousColor()
        {
            lbKhoshra.BackColor = Color.Azure;
            lbKhoshra.ForeColor = Color.FromArgb(63, 66, 84);

            lbKhoshraWaiting.BackColor = Color.Azure;
            lbKhoshraWaiting.ForeColor = Color.FromArgb(63, 66, 84);

            lbApprovedPotro.BackColor = Color.Azure;
            lbApprovedPotro.ForeColor = Color.FromArgb(63, 66, 84);

            lbAllPotro.BackColor = Color.Azure;
            lbAllPotro.ForeColor = Color.FromArgb(63, 66, 84);

            lbPotrojari.BackColor = Color.Azure;
            lbPotrojari.ForeColor = Color.FromArgb(63, 66, 84);

            lbNothijato.BackColor = Color.Azure;
            lbNothijato.ForeColor = Color.FromArgb(63, 66, 84);
        }

        public void mulpotroOshongjuktiVisibilityOff()
        {
            //pnlMulPotroOShonjukti.Visible = false;
            lbMulPotroOShonjukti.Visible = false;
            btnMulPotroOShonjukti.Visible = false;
        }

        int i;
        AllPotroResponse allPotro = new AllPotroResponse();
        private void lbAllPotro_Click(object sender, EventArgs e)
        {
            allLbelButtonPreviousColor();
            lbAllPotro.BackColor = Color.FromArgb(14, 102, 98);
            lbAllPotro.ForeColor = Color.FromArgb(191, 239, 237);

            allNextButtonVisibilityOff();
            btnAllPotroNext.Visible = true;

            btnKhshraNext.Visible = false;
            allPotro = _allPotro.GetAllPotroInfo(_dakuserparam, nothiListRecords.id);
            if(allPotro.status == "success")
            {
                i = 0;
                int index=0;
                pnlPotrangshoDetails.Visible = true;
                if (allPotro.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    btnAllPotroNext.Visible = true;

                    allPreviousButtonVisibilityOff();

                    if (allPotro.data.records[i].basic.page_numbers.Contains(","))
                    {
                        index = allPotro.data.records[i].basic.page_numbers.IndexOf(",");
                    }
                    int totalLength = allPotro.data.records[i].basic.page_numbers.Length;
                    lbPotroSubject.Text = allPotro.data.records[i].basic.subject+ "(পাতা:" + string.Concat(allPotro.data.records[i].basic.page_numbers.Substring(0,index).ToString().Select(c => (char)('\u09E6' + c - '0')))  + "-"+ string.Concat(allPotro.data.records[i].basic.page_numbers.Substring(index+1).ToString().Select(c => (char)('\u09E6' + c - '0'))) + ")";
                    lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + allPotro.data.records[i].basic.due_date;
                    lbSubjectSmall.Text = "পত্র: " + allPotro.data.records[i].basic.subject;
                    if (allPotro.data.records[i].note_ownerDTOList.Count > 0)
                    {
                        lbNoteId.Text = "নোটঃ " + string.Concat(allPotro.data.records[i].note_ownerDTOList[0].note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    lbTotal.Text = "সর্বমোট: " + string.Concat(allPotro.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                    allMulpotroButtonsVisibilityOff();
                    int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                        endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                    foreach (string btnName in allPotro.data.records[i].mulpotro.buttons)
                    {
                        if (btnName == "draft_history")
                        {
                            draft_history = 1;
                        }
                        if (btnName == "clone")
                        {
                            clone = 1;
                        }
                        if (btnName == "edit")
                        {
                            edit = 1;
                        }
                        if (btnName == "delete")
                        {
                            delete = 1;
                        }
                        if (btnName == "approve")
                        {
                            approve = 1;
                        }
                        if (btnName == "unapprove")
                        {
                            unapprove = 1;
                        }
                        if (btnName == "potrojari")
                        {
                            potrojari = 1;
                        }
                        if (btnName == "endorsement")
                        {
                            endrosement = 1;
                        }
                        if (btnName == "khoshra")
                        {
                            khoshra = 1;
                        }
                        if (btnName == "full_editable")
                        {
                            fulleditable = 1;
                        }
                        if (btnName == "custom")
                        {
                            custom = 1;
                        }
                    }
                    allMulpotroButtonsVisibilityOn(draft_history, clone, edit, delete, approve, 
                        unapprove, potrojari, endrosement, khoshra, fulleditable, custom);

                    if (allPotro.data.records[i].mulpotro.is_main == 1)
                    {
                        pnlMulPotroOShonjukti.Visible = true;
                        lbMulPotroOShonjukti.Visible = true;
                        btnMulPotroOShonjukti.Visible = true;

                        btnMulPotroOShonjukti.Text = string.Concat(allPotro.data.records[i].basic.potro_pages.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        mulpotroOshongjuktiVisibilityOff();
                    }

                    totalRange = (i + 1).ToString();
                    if (allPotro.data.records[i].mulpotro.url != "")
                    {
                        picBoxFile.Visible = false;
                        khosraViewWebBrowser.Url = new Uri(allPotro.data.records[i].mulpotro.url);
                    }
                    else
                    {
                        picBoxFile.Controls.Clear();
                    }
                }
            }
            if (allPotro.data.total_records == i || allPotro.data.total_records -1 == i )
            {
                i = 0;
                allNextButtonVisibilityOff();
                allPreviousButtonVisibilityOff();

            }
        }

        private void btnAllPotroPrevious_Click(object sender, EventArgs e)
        {
            i--;
            if (i == 0)
            {
                int index = 0;
                pnlPotrangshoDetails.Visible = true;
                if (allPotro.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    btnAllPotroNext.Visible = true;

                    allPreviousButtonVisibilityOff();

                    if (allPotro.data.records[i].basic.page_numbers.Contains(","))
                    {
                        index = allPotro.data.records[i].basic.page_numbers.IndexOf(",");
                    }
                    int totalLength = allPotro.data.records[i].basic.page_numbers.Length;
                    lbPotroSubject.Text = allPotro.data.records[i].basic.subject + "(পাতা:" + string.Concat(allPotro.data.records[i].basic.page_numbers.Substring(0, index).ToString().Select(c => (char)('\u09E6' + c - '0'))) + "-" + string.Concat(allPotro.data.records[i].basic.page_numbers.Substring(index + 1).ToString().Select(c => (char)('\u09E6' + c - '0'))) + ")";
                    lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + allPotro.data.records[i].basic.due_date;
                    lbSubjectSmall.Text = "পত্র: " + allPotro.data.records[i].basic.subject;
                    if (allPotro.data.records[i].note_ownerDTOList.Count > 0)
                    {
                        lbNoteId.Text = "নোটঃ " + string.Concat(allPotro.data.records[i].note_ownerDTOList[0].note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    lbTotal.Text = "সর্বমোট: " + string.Concat(allPotro.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                    allMulpotroButtonsVisibilityOff();
                    int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                        endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                    foreach (string btnName in allPotro.data.records[i].mulpotro.buttons)
                    {
                        if (btnName == "draft_history")
                        {
                            draft_history = 1;
                        }
                        if (btnName == "clone")
                        {
                            clone = 1;
                        }
                        if (btnName == "edit")
                        {
                            edit = 1;
                        }
                        if (btnName == "delete")
                        {
                            delete = 1;
                        }
                        if (btnName == "approve")
                        {
                            approve = 1;
                        }
                        if (btnName == "unapprove")
                        {
                            unapprove = 1;
                        }
                        if (btnName == "potrojari")
                        {
                            potrojari = 1;
                        }
                        if (btnName == "endorsement")
                        {
                            endrosement = 1;
                        }
                        if (btnName == "khoshra")
                        {
                            khoshra = 1;
                        }
                        if (btnName == "full_editable")
                        {
                            fulleditable = 1;
                        }
                        if (btnName == "custom")
                        {
                            custom = 1;
                        }
                    }
                    allMulpotroButtonsVisibilityOn(draft_history, clone, edit, delete, approve,
                        unapprove, potrojari, endrosement, khoshra, fulleditable, custom);

                    if (allPotro.data.records[i].mulpotro.is_main == 1)
                    {
                        pnlMulPotroOShonjukti.Visible = true;
                        lbMulPotroOShonjukti.Visible = true;
                        btnMulPotroOShonjukti.Visible = true;

                        btnMulPotroOShonjukti.Text = string.Concat(allPotro.data.records[i].basic.potro_pages.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        mulpotroOshongjuktiVisibilityOff();
                    }

                    totalRange = (i + 1).ToString();
                    if (allPotro.data.records[i].mulpotro.url != "")
                    {
                        picBoxFile.Visible = false;
                        khosraViewWebBrowser.Url = new Uri(allPotro.data.records[i].mulpotro.url);
                    }
                    else
                    {
                        picBoxFile.Controls.Clear();
                    }
                }
            }
            if (allPotro.data.total_records != i && i > 0)
            {
                int index = 0;
                pnlPotrangshoDetails.Visible = true;
                if (allPotro.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    btnAllPotroNext.Visible = true;

                    allPreviousButtonVisibilityOff();
                    btnAllPotroPrevious.Visible = true;

                    if (allPotro.data.records[i].basic.page_numbers.Contains(","))
                    {
                        index = allPotro.data.records[i].basic.page_numbers.IndexOf(",");
                    }
                    int totalLength = allPotro.data.records[i].basic.page_numbers.Length;
                    lbPotroSubject.Text = allPotro.data.records[i].basic.subject + "(পাতা:" + string.Concat(allPotro.data.records[i].basic.page_numbers.Substring(0, index).ToString().Select(c => (char)('\u09E6' + c - '0'))) + "-" + string.Concat(allPotro.data.records[i].basic.page_numbers.Substring(index + 1).ToString().Select(c => (char)('\u09E6' + c - '0'))) + ")";
                    lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + allPotro.data.records[i].basic.due_date;
                    lbSubjectSmall.Text = "পত্র: " + allPotro.data.records[i].basic.subject;
                    if (allPotro.data.records[i].note_ownerDTOList.Count > 0)
                    {
                        lbNoteId.Text = "নোটঃ " + string.Concat(allPotro.data.records[i].note_ownerDTOList[0].note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    lbTotal.Text = "সর্বমোট: " + string.Concat(allPotro.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                    allMulpotroButtonsVisibilityOff();
                    int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                        endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                    foreach (string btnName in allPotro.data.records[i].mulpotro.buttons)
                    {
                        if (btnName == "draft_history")
                        {
                            draft_history = 1;
                        }
                        if (btnName == "clone")
                        {
                            clone = 1;
                        }
                        if (btnName == "edit")
                        {
                            edit = 1;
                        }
                        if (btnName == "delete")
                        {
                            delete = 1;
                        }
                        if (btnName == "approve")
                        {
                            approve = 1;
                        }
                        if (btnName == "unapprove")
                        {
                            unapprove = 1;
                        }
                        if (btnName == "potrojari")
                        {
                            potrojari = 1;
                        }
                        if (btnName == "endorsement")
                        {
                            endrosement = 1;
                        }
                        if (btnName == "khoshra")
                        {
                            khoshra = 1;
                        }
                        if (btnName == "full_editable")
                        {
                            fulleditable = 1;
                        }
                        if (btnName == "custom")
                        {
                            custom = 1;
                        }
                    }
                    allMulpotroButtonsVisibilityOn(draft_history, clone, edit, delete, approve,
                        unapprove, potrojari, endrosement, khoshra, fulleditable, custom);

                    if (allPotro.data.records[i].mulpotro.is_main == 1)
                    {
                        pnlMulPotroOShonjukti.Visible = true;
                        lbMulPotroOShonjukti.Visible = true;
                        btnMulPotroOShonjukti.Visible = true;

                        btnMulPotroOShonjukti.Text = string.Concat(allPotro.data.records[i].basic.potro_pages.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        mulpotroOshongjuktiVisibilityOff();
                    }

                    totalRange = (i + 1).ToString();
                    if (allPotro.data.records[i].mulpotro.url != "")
                    {
                        picBoxFile.Visible = false;
                        khosraViewWebBrowser.Url = new Uri(allPotro.data.records[i].mulpotro.url);
                    }
                    else
                    {
                        picBoxFile.Controls.Clear();
                    }
                }
            }
            if (allPotro.data.total_records < 0 || i < 0)
            {
                i = 0;
                allPreviousButtonVisibilityOff();
            }
        }
        private void btnAllPotroNext_Click(object sender, EventArgs e)
        {
            i++;
            if (allPotro.data.total_records != i && i > 0)
            {
                int index = 0;
                pnlPotrangshoDetails.Visible = true;
                if (allPotro.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    btnAllPotroNext.Visible = true;

                    allPreviousButtonVisibilityOff();
                    btnAllPotroPrevious.Visible = true;

                    if (allPotro.data.records[i].basic.page_numbers.Contains(","))
                    {
                        index = allPotro.data.records[i].basic.page_numbers.IndexOf(",");
                    }
                    int totalLength = allPotro.data.records[i].basic.page_numbers.Length;
                    lbPotroSubject.Text = allPotro.data.records[i].basic.subject + "(পাতা:" + string.Concat(allPotro.data.records[i].basic.page_numbers.Substring(0, index).ToString().Select(c => (char)('\u09E6' + c - '0'))) + "-" + string.Concat(allPotro.data.records[i].basic.page_numbers.Substring(index + 1).ToString().Select(c => (char)('\u09E6' + c - '0'))) + ")";
                    lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + allPotro.data.records[i].basic.due_date;
                    lbSubjectSmall.Text = "পত্র: " + allPotro.data.records[i].basic.subject;
                    if (allPotro.data.records[i].note_ownerDTOList.Count > 0)
                    {
                        lbNoteId.Text = "নোটঃ " + string.Concat(allPotro.data.records[i].note_ownerDTOList[0].note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    lbTotal.Text = "সর্বমোট: " + string.Concat(allPotro.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                    allMulpotroButtonsVisibilityOff();
                    int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                        endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                    foreach (string btnName in allPotro.data.records[i].mulpotro.buttons)
                    {
                        if (btnName == "draft_history")
                        {
                            draft_history = 1;
                        }
                        if (btnName == "clone")
                        {
                            clone = 1;
                        }
                        if (btnName == "edit")
                        {
                            edit = 1;
                        }
                        if (btnName == "delete")
                        {
                            delete = 1;
                        }
                        if (btnName == "approve")
                        {
                            approve = 1;
                        }
                        if (btnName == "unapprove")
                        {
                            unapprove = 1;
                        }
                        if (btnName == "potrojari")
                        {
                            potrojari = 1;
                        }
                        if (btnName == "endorsement")
                        {
                            endrosement = 1;
                        }
                        if (btnName == "khoshra")
                        {
                            khoshra = 1;
                        }
                        if (btnName == "full_editable")
                        {
                            fulleditable = 1;
                        }
                        if (btnName == "custom")
                        {
                            custom = 1;
                        }
                    }
                    allMulpotroButtonsVisibilityOn(draft_history, clone, edit, delete, approve,
                        unapprove, potrojari, endrosement, khoshra, fulleditable, custom);

                    if (allPotro.data.records[i].mulpotro.is_main == 1)
                    {
                        pnlMulPotroOShonjukti.Visible = true;
                        lbMulPotroOShonjukti.Visible = true;
                        btnMulPotroOShonjukti.Visible = true;

                        btnMulPotroOShonjukti.Text = string.Concat(allPotro.data.records[i].basic.potro_pages.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        mulpotroOshongjuktiVisibilityOff();
                    }

                    totalRange = (i + 1).ToString();
                    if (allPotro.data.records[i].mulpotro.url != "")
                    {
                        picBoxFile.Visible = false;
                        khosraViewWebBrowser.Url = new Uri(allPotro.data.records[i].mulpotro.url);
                    }
                    else
                    {
                        picBoxFile.Controls.Clear();
                    }
                }
            }
            if (allPotro.data.total_records == i || allPotro.data.total_records - 1 == i )
            {
                //i = 0;
                allNextButtonVisibilityOff();
            }

        }
        
        KhoshraPotroResponse khoshraPotro = new KhoshraPotroResponse();
        private void lbKhoshra_Click(object sender, EventArgs e)
        {
            allMulpotroButtonsVisibilityOff();

            allLbelButtonPreviousColor();
            lbKhoshra.BackColor = Color.FromArgb(14, 102, 98);
            lbKhoshra.ForeColor = Color.FromArgb(191, 239, 237);

            allNextButtonVisibilityOff();
            btnKhshraNext.Visible = true;

            khoshraPotro = _khoshraPotro.GetKhoshraPotroInfo(_dakuserparam, nothiListRecords.id);
            if (khoshraPotro.status == "success")
            {
                i = 0;
                pnlPotrangshoDetails.Visible = true;
                lbPotroSubject.Text = khoshraPotro.data.records[i].basic.potro_subject;
                lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + khoshraPotro.data.records[i].basic.created;
                lbNoteId.Text = "নোটঃ " + string.Concat(khoshraPotro.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                lbSubjectSmall.Text = "পত্র: " + khoshraPotro.data.records[i].basic.potro_subject;
                lbTotal.Text = "সর্বমোট: " + string.Concat(khoshraPotro.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                    endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                foreach (string btnName in khoshraPotro.data.records[i].mulpotro.buttons)
                {
                    if (btnName == "draft_history")
                    {
                        draft_history = 1;
                    }
                    if (btnName == "clone")
                    {
                        clone = 1;
                    }
                    if (btnName == "edit")
                    {
                        edit = 1;
                    }
                    if (btnName == "delete")
                    {
                        delete = 1;
                    }
                    if (btnName == "approve")
                    {
                        approve = 1;
                    }
                    if (btnName == "unapprove")
                    {
                        unapprove = 1;
                    }
                    if (btnName == "potrojari")
                    {
                        potrojari = 1;
                    }
                    if (btnName == "endorsement")
                    {
                        endrosement = 1;
                    }
                    if (btnName == "khoshra")
                    {
                        khoshra = 1;
                    }
                    if (btnName == "full_editable")
                    {
                        fulleditable = 1;
                    }
                    if (btnName == "custom")
                    {
                        custom = 1;
                    }
                }
                allMulpotroButtonsVisibilityOn(draft_history, clone, edit, delete, approve,
                    unapprove, potrojari, endrosement, khoshra, fulleditable, custom);
                mulpotroOshongjuktiVisibilityOff();

                totalRange = (i+1).ToString();
                picBoxFile.Visible = false;
                khosraViewWebBrowser.Visible = true;
                if (khosraViewWebBrowser.Document != null)
                {
                    khosraViewWebBrowser.Document.Write(string.Empty);
                }

                if(khoshraPotro.data.total_records>0)
                {
                    allNextButtonVisibilityOff();
                    btnKhshraNext.Visible = true;

                    allPreviousButtonVisibilityOff();

                    string DecodedString = khoshraPotro.data.records[0].mulpotro.potro_description;
                    khosraViewWebBrowser.DocumentText = Base64Decode1(DecodedString);
                }
                picBoxFile.Controls.Clear();
            }
            if (khoshraPotro.data.total_records == i || khoshraPotro.data.total_records - 1 == i )
            {
                i = 0;
                allPreviousButtonVisibilityOff();
                allNextButtonVisibilityOff();
            }
        }
        private void btnKhoshraPrevious_Click(object sender, EventArgs e)
        {
            i--;
            if (i == 0)
            {
                
                pnlPotrangshoDetails.Visible = true;
                lbPotroSubject.Text = khoshraPotro.data.records[i].basic.potro_subject;
                lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + khoshraPotro.data.records[i].basic.created;
                lbNoteId.Text = "নোটঃ " + string.Concat(khoshraPotro.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                lbSubjectSmall.Text = "পত্র: " + khoshraPotro.data.records[i].basic.potro_subject;
                lbTotal.Text = "সর্বমোট: " + string.Concat(khoshraPotro.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                allMulpotroButtonsVisibilityOff();
                int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                    endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                foreach (string btnName in khoshraPotro.data.records[i].mulpotro.buttons)
                {
                    if (btnName == "draft_history")
                    {
                        draft_history = 1;
                    }
                    if (btnName == "clone")
                    {
                        clone = 1;
                    }
                    if (btnName == "edit")
                    {
                        edit = 1;
                    }
                    if (btnName == "delete")
                    {
                        delete = 1;
                    }
                    if (btnName == "approve")
                    {
                        approve = 1;
                    }
                    if (btnName == "unapprove")
                    {
                        unapprove = 1;
                    }
                    if (btnName == "potrojari")
                    {
                        potrojari = 1;
                    }
                    if (btnName == "endorsement")
                    {
                        endrosement = 1;
                    }
                    if (btnName == "khoshra")
                    {
                        khoshra = 1;
                    }
                    if (btnName == "full_editable")
                    {
                        fulleditable = 1;
                    }
                    if (btnName == "custom")
                    {
                        custom = 1;
                    }
                }
                allMulpotroButtonsVisibilityOn(draft_history, clone, edit, delete, approve,
                    unapprove, potrojari, endrosement, khoshra, fulleditable, custom); 
                mulpotroOshongjuktiVisibilityOff();

                totalRange = (i + 1).ToString();
                picBoxFile.Visible = false;
                khosraViewWebBrowser.Visible = true;
                if (khosraViewWebBrowser.Document != null)
                {
                    khosraViewWebBrowser.Document.Write(string.Empty);
                }

                if (khoshraPotro.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    btnKhshraNext.Visible = true;

                    allPreviousButtonVisibilityOff();

                    string DecodedString = khoshraPotro.data.records[i].mulpotro.potro_description;
                    khosraViewWebBrowser.DocumentText = Base64Decode1(DecodedString);
                }
                picBoxFile.Controls.Clear();
            }
            if (khoshraPotro.data.total_records != i && i > 0)
            {
                pnlPotrangshoDetails.Visible = true;
                lbPotroSubject.Text = khoshraPotro.data.records[i].basic.potro_subject;
                lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + khoshraPotro.data.records[i].basic.created;
                lbNoteId.Text = "নোটঃ " + string.Concat(khoshraPotro.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                lbSubjectSmall.Text = "পত্র: " + khoshraPotro.data.records[i].basic.potro_subject;
                lbTotal.Text = "সর্বমোট: " + string.Concat(khoshraPotro.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                allMulpotroButtonsVisibilityOff();
                int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                    endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                foreach (string btnName in khoshraPotro.data.records[i].mulpotro.buttons)
                {
                    if (btnName == "draft_history")
                    {
                        draft_history = 1;
                    }
                    if (btnName == "clone")
                    {
                        clone = 1;
                    }
                    if (btnName == "edit")
                    {
                        edit = 1;
                    }
                    if (btnName == "delete")
                    {
                        delete = 1;
                    }
                    if (btnName == "approve")
                    {
                        approve = 1;
                    }
                    if (btnName == "unapprove")
                    {
                        unapprove = 1;
                    }
                    if (btnName == "potrojari")
                    {
                        potrojari = 1;
                    }
                    if (btnName == "endorsement")
                    {
                        endrosement = 1;
                    }
                    if (btnName == "khoshra")
                    {
                        khoshra = 1;
                    }
                    if (btnName == "full_editable")
                    {
                        fulleditable = 1;
                    }
                    if (btnName == "custom")
                    {
                        custom = 1;
                    }
                }
                allMulpotroButtonsVisibilityOn(draft_history, clone, edit, delete, approve,
                    unapprove, potrojari, endrosement, khoshra, fulleditable, custom); 
                mulpotroOshongjuktiVisibilityOff();
                totalRange = (i + 1).ToString();
                picBoxFile.Visible = false;
                khosraViewWebBrowser.Visible = true;
                if (khosraViewWebBrowser.Document != null)
                {
                    khosraViewWebBrowser.Document.Write(string.Empty);
                }

                if (khoshraPotro.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    btnKhshraNext.Visible = true;

                    allPreviousButtonVisibilityOff();
                    btnKhoshraPrevious.Visible = true;

                    string DecodedString = khoshraPotro.data.records[i].mulpotro.potro_description;
                    khosraViewWebBrowser.DocumentText = Base64Decode1(DecodedString);
                }
                picBoxFile.Controls.Clear();
            }
            if (khoshraPotro.data.total_records < 0 || i < 0)
            {
                i = 0;
                allPreviousButtonVisibilityOff(); 
                allMulpotroButtonsVisibilityOff();
            }
        }

        private void btnKhshraNext_Click(object sender, EventArgs e)
        {
            i++;
            if (khoshraPotro.data.total_records != i && i > 0)
            {
                pnlPotrangshoDetails.Visible = true;
                lbPotroSubject.Text = khoshraPotro.data.records[i].basic.potro_subject;
                lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + khoshraPotro.data.records[i].basic.created;
                lbNoteId.Text = "নোটঃ " + string.Concat(khoshraPotro.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                lbSubjectSmall.Text = "পত্র: " + khoshraPotro.data.records[i].basic.potro_subject;
                lbTotal.Text = "সর্বমোট: " + string.Concat(khoshraPotro.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                allMulpotroButtonsVisibilityOff();
                int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                    endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                foreach (string btnName in khoshraPotro.data.records[i].mulpotro.buttons)
                {
                    if (btnName == "draft_history")
                    {
                        draft_history = 1;
                    }
                    if (btnName == "clone")
                    {
                        clone = 1;
                    }
                    if (btnName == "edit")
                    {
                        edit = 1;
                    }
                    if (btnName == "delete")
                    {
                        delete = 1;
                    }
                    if (btnName == "approve")
                    {
                        approve = 1;
                    }
                    if (btnName == "unapprove")
                    {
                        unapprove = 1;
                    }
                    if (btnName == "potrojari")
                    {
                        potrojari = 1;
                    }
                    if (btnName == "endorsement")
                    {
                        endrosement = 1;
                    }
                    if (btnName == "khoshra")
                    {
                        khoshra = 1;
                    }
                    if (btnName == "full_editable")
                    {
                        fulleditable = 1;
                    }
                    if (btnName == "custom")
                    {
                        custom = 1;
                    }
                }
                allMulpotroButtonsVisibilityOn(draft_history, clone, edit, delete, approve,
                    unapprove, potrojari, endrosement, khoshra, fulleditable, custom); 
                mulpotroOshongjuktiVisibilityOff();
                totalRange = (i + 1).ToString();
                picBoxFile.Visible = false;
                khosraViewWebBrowser.Visible = true;
                if (khosraViewWebBrowser.Document != null)
                {
                    khosraViewWebBrowser.Document.Write(string.Empty);
                }

                if (khoshraPotro.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    btnKhshraNext.Visible = true;

                    allPreviousButtonVisibilityOff();
                    btnKhoshraPrevious.Visible = true;

                    string DecodedString = khoshraPotro.data.records[i].mulpotro.potro_description;
                    khosraViewWebBrowser.DocumentText = Base64Decode1(DecodedString);
                }
                picBoxFile.Controls.Clear();
            }
            if(khoshraPotro.data.total_records == i || khoshraPotro.data.total_records - 1 == i)
            {
                //i = 0;
                allNextButtonVisibilityOff();
                //allMulpotroButtonsVisibilityOff();
            }
        }
        KhoshraPotroWaitingResponse khoshraPotroWaiting = new KhoshraPotroWaitingResponse();
        private void lbKhoshraWaiting_Click(object sender, EventArgs e)
        {
            allLbelButtonPreviousColor();
            lbKhoshraWaiting.BackColor = Color.FromArgb(14, 102, 98);
            lbKhoshraWaiting.ForeColor = Color.FromArgb(191, 239, 237);

            allNextButtonVisibilityOff();
            btnKhoshraWaitingNext.Visible = true;

            khoshraPotroWaiting = _khoshraPotroWaiting.GetKhoshraPotroWaitingInfo(_dakuserparam, nothiListRecords.id);
            if (khoshraPotroWaiting.status == "success")
            {
                i = 0;
                pnlPotrangshoDetails.Visible = true;
                lbPotroSubject.Text = khoshraPotroWaiting.data.records[i].basic.potro_subject;
                lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + khoshraPotroWaiting.data.records[i].basic.created;
                lbNoteId.Text = "নোটঃ " + string.Concat(khoshraPotroWaiting.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                lbSubjectSmall.Text = "পত্র: " + khoshraPotroWaiting.data.records[i].basic.potro_subject;
                lbTotal.Text = "সর্বমোট: " + string.Concat(khoshraPotroWaiting.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                
                allMulpotroButtonsVisibilityOff();
                int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                    endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                foreach (string btnName in khoshraPotroWaiting.data.records[i].mulpotro.buttons)
                {
                    if (btnName == "draft_history")
                    {
                        draft_history = 1;
                    }
                    if (btnName == "clone")
                    {
                        clone = 1;
                    }
                    if (btnName == "edit")
                    {
                        edit = 1;
                    }
                    if (btnName == "delete")
                    {
                        delete = 1;
                    }
                    if (btnName == "approve")
                    {
                        approve = 1;
                    }
                    if (btnName == "unapprove")
                    {
                        unapprove = 1;
                    }
                    if (btnName == "potrojari")
                    {
                        potrojari = 1;
                    }
                    if (btnName == "endorsement")
                    {
                        endrosement = 1;
                    }
                    if (btnName == "khoshra")
                    {
                        khoshra = 1;
                    }
                    if (btnName == "full_editable")
                    {
                        fulleditable = 1;
                    }
                    if (btnName == "custom")
                    {
                        custom = 1;
                    }
                }
                allMulpotroButtonsVisibilityOn(draft_history, clone, edit, delete, approve,
                    unapprove, potrojari, endrosement, khoshra, fulleditable, custom); 
                mulpotroOshongjuktiVisibilityOff();
                totalRange = (i + 1).ToString();

                picBoxFile.Visible = false;
                khosraViewWebBrowser.Visible = true;
                if (khosraViewWebBrowser.Document != null)
                {
                    khosraViewWebBrowser.Document.Write(string.Empty);
                }

                if (khoshraPotroWaiting.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    btnKhoshraWaitingNext.Visible = true;

                    allPreviousButtonVisibilityOff();

                    string DecodedString = khoshraPotroWaiting.data.records[0].mulpotro.potro_description;
                    khosraViewWebBrowser.DocumentText = Base64Decode1(DecodedString);
                }
                picBoxFile.Controls.Clear();
            }
            if (khoshraPotroWaiting.data.total_records == i || khoshraPotroWaiting.data.total_records - 1 == i)
            {
                i = 0;
                allNextButtonVisibilityOff();
                allPreviousButtonVisibilityOff();
            }
        }
        private void btnKhoshraWaitingPrevious_Click(object sender, EventArgs e)
        {
            i--;
            if (i == 0)
            {
                pnlPotrangshoDetails.Visible = true;
                lbPotroSubject.Text = khoshraPotroWaiting.data.records[i].basic.potro_subject;
                lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + khoshraPotroWaiting.data.records[i].basic.created;
                lbNoteId.Text = "নোটঃ " + string.Concat(khoshraPotroWaiting.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                lbSubjectSmall.Text = "পত্র: " + khoshraPotroWaiting.data.records[i].basic.potro_subject;
                lbTotal.Text = "সর্বমোট: " + string.Concat(khoshraPotroWaiting.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                allMulpotroButtonsVisibilityOff();
                int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                    endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                foreach (string btnName in khoshraPotroWaiting.data.records[i].mulpotro.buttons)
                {
                    if (btnName == "draft_history")
                    {
                        draft_history = 1;
                    }
                    if (btnName == "clone")
                    {
                        clone = 1;
                    }
                    if (btnName == "edit")
                    {
                        edit = 1;
                    }
                    if (btnName == "delete")
                    {
                        delete = 1;
                    }
                    if (btnName == "approve")
                    {
                        approve = 1;
                    }
                    if (btnName == "unapprove")
                    {
                        unapprove = 1;
                    }
                    if (btnName == "potrojari")
                    {
                        potrojari = 1;
                    }
                    if (btnName == "endorsement")
                    {
                        endrosement = 1;
                    }
                    if (btnName == "khoshra")
                    {
                        khoshra = 1;
                    }
                    if (btnName == "full_editable")
                    {
                        fulleditable = 1;
                    }
                    if (btnName == "custom")
                    {
                        custom = 1;
                    }
                }
                allMulpotroButtonsVisibilityOn(draft_history, clone, edit, delete, approve,
                    unapprove, potrojari, endrosement, khoshra, fulleditable, custom); 
                mulpotroOshongjuktiVisibilityOff();
                totalRange = (i + 1).ToString();
                picBoxFile.Visible = false;
                khosraViewWebBrowser.Visible = true;
                if (khosraViewWebBrowser.Document != null)
                {
                    khosraViewWebBrowser.Document.Write(string.Empty);
                }

                if (khoshraPotroWaiting.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    btnKhoshraWaitingNext.Visible = true;

                    allPreviousButtonVisibilityOff();
                    
                    string DecodedString = khoshraPotroWaiting.data.records[i].mulpotro.potro_description;
                    khosraViewWebBrowser.DocumentText = Base64Decode1(DecodedString);
                }
                picBoxFile.Controls.Clear();
            }
            if (khoshraPotroWaiting.data.total_records != i && i > 0)
            {
                pnlPotrangshoDetails.Visible = true;
                lbPotroSubject.Text = khoshraPotroWaiting.data.records[i].basic.potro_subject;
                lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + khoshraPotroWaiting.data.records[i].basic.created;
                lbNoteId.Text = "নোটঃ " + string.Concat(khoshraPotroWaiting.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                lbSubjectSmall.Text = "পত্র: " + khoshraPotroWaiting.data.records[i].basic.potro_subject;
                lbTotal.Text = "সর্বমোট: " + string.Concat(khoshraPotroWaiting.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                allMulpotroButtonsVisibilityOff();
                int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                    endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                foreach (string btnName in khoshraPotroWaiting.data.records[i].mulpotro.buttons)
                {
                    if (btnName == "draft_history")
                    {
                        draft_history = 1;
                    }
                    if (btnName == "clone")
                    {
                        clone = 1;
                    }
                    if (btnName == "edit")
                    {
                        edit = 1;
                    }
                    if (btnName == "delete")
                    {
                        delete = 1;
                    }
                    if (btnName == "approve")
                    {
                        approve = 1;
                    }
                    if (btnName == "unapprove")
                    {
                        unapprove = 1;
                    }
                    if (btnName == "potrojari")
                    {
                        potrojari = 1;
                    }
                    if (btnName == "endorsement")
                    {
                        endrosement = 1;
                    }
                    if (btnName == "khoshra")
                    {
                        khoshra = 1;
                    }
                    if (btnName == "full_editable")
                    {
                        fulleditable = 1;
                    }
                    if (btnName == "custom")
                    {
                        custom = 1;
                    }
                }
                allMulpotroButtonsVisibilityOn(draft_history, clone, edit, delete, approve,
                    unapprove, potrojari, endrosement, khoshra, fulleditable, custom); 
                mulpotroOshongjuktiVisibilityOff();
                totalRange = (i + 1).ToString();
                picBoxFile.Visible = false;
                khosraViewWebBrowser.Visible = true;
                if (khosraViewWebBrowser.Document != null)
                {
                    khosraViewWebBrowser.Document.Write(string.Empty);
                }

                if (khoshraPotroWaiting.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    btnKhoshraWaitingNext.Visible = true;

                    allPreviousButtonVisibilityOff();
                    btnKhoshraWaitingPrevious.Visible = true;

                    string DecodedString = khoshraPotroWaiting.data.records[i].mulpotro.potro_description;
                    khosraViewWebBrowser.DocumentText = Base64Decode1(DecodedString);
                }
                picBoxFile.Controls.Clear();
            }
            if (khoshraPotroWaiting.data.total_records < 0 || i < 0)
            {
                i = 0;
                allPreviousButtonVisibilityOff();
            }
        }
        private void btnKhoshraWaitingNext_Click(object sender, EventArgs e)
        {
            i++;
            if (khoshraPotroWaiting.data.total_records != i && i > 0)
            {
                pnlPotrangshoDetails.Visible = true;
                lbPotroSubject.Text = khoshraPotroWaiting.data.records[i].basic.potro_subject;
                lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + khoshraPotroWaiting.data.records[i].basic.created;
                lbNoteId.Text = "নোটঃ " + string.Concat(khoshraPotroWaiting.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                lbSubjectSmall.Text = "পত্র: " + khoshraPotroWaiting.data.records[i].basic.potro_subject;
                lbTotal.Text = "সর্বমোট: " + string.Concat(khoshraPotroWaiting.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                allMulpotroButtonsVisibilityOff();
                int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                    endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                foreach (string btnName in khoshraPotroWaiting.data.records[i].mulpotro.buttons)
                {
                    if (btnName == "draft_history")
                    {
                        draft_history = 1;
                    }
                    if (btnName == "clone")
                    {
                        clone = 1;
                    }
                    if (btnName == "edit")
                    {
                        edit = 1;
                    }
                    if (btnName == "delete")
                    {
                        delete = 1;
                    }
                    if (btnName == "approve")
                    {
                        approve = 1;
                    }
                    if (btnName == "unapprove")
                    {
                        unapprove = 1;
                    }
                    if (btnName == "potrojari")
                    {
                        potrojari = 1;
                    }
                    if (btnName == "endorsement")
                    {
                        endrosement = 1;
                    }
                    if (btnName == "khoshra")
                    {
                        khoshra = 1;
                    }
                    if (btnName == "full_editable")
                    {
                        fulleditable = 1;
                    }
                    if (btnName == "custom")
                    {
                        custom = 1;
                    }
                }
                allMulpotroButtonsVisibilityOn(draft_history, clone, edit, delete, approve,
                    unapprove, potrojari, endrosement, khoshra, fulleditable, custom); 
                mulpotroOshongjuktiVisibilityOff();
                totalRange = (i + 1).ToString();
                picBoxFile.Visible = false;
                khosraViewWebBrowser.Visible = true;
                if (khosraViewWebBrowser.Document != null)
                {
                    khosraViewWebBrowser.Document.Write(string.Empty);
                }

                if (khoshraPotroWaiting.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    btnKhoshraWaitingNext.Visible = true;

                    allPreviousButtonVisibilityOff();
                    btnKhoshraWaitingPrevious.Visible = true;

                    string DecodedString = khoshraPotroWaiting.data.records[i].mulpotro.potro_description;
                    khosraViewWebBrowser.DocumentText = Base64Decode1(DecodedString);
                }
                picBoxFile.Controls.Clear();
            }
            if (khoshraPotroWaiting.data.total_records == i || khoshraPotroWaiting.data.total_records - 1 == i)
            {
                //i = 0;
                allNextButtonVisibilityOff();
            }
        }

        PotrojariResponse potrojariList = new PotrojariResponse();
        private void lbPotrojari_Click(object sender, EventArgs e)
        {
            allLbelButtonPreviousColor();
            lbPotrojari.BackColor = Color.FromArgb(14, 102, 98);
            lbPotrojari.ForeColor = Color.FromArgb(191, 239, 237);

            allNextButtonVisibilityOff();
            btnPotrojariNext.Visible = true;

            potrojariList = _potrojariList.GetPotrojariListInfo(_dakuserparam, nothiListRecords.id);
            if (potrojariList.status == "success")
            {
                i = 0;
                pnlPotrangshoDetails.Visible = true;
                lbPotroSubject.Text = potrojariList.data.records[i].basic.potro_subject;
                lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + potrojariList.data.records[i].basic.created;
                lbNoteId.Text = "নোটঃ " + string.Concat(potrojariList.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                lbSubjectSmall.Text = "পত্র: " + potrojariList.data.records[i].basic.potro_subject;
                lbTotal.Text = "সর্বমোট: " + string.Concat(potrojariList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                allMulpotroButtonsVisibilityOff();
                int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                    endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                foreach (string btnName in potrojariList.data.records[i].mulpotro.buttons)
                {
                    if (btnName == "draft_history")
                    {
                        draft_history = 1;
                    }
                    if (btnName == "clone")
                    {
                        clone = 1;
                    }
                    if (btnName == "edit")
                    {
                        edit = 1;
                    }
                    if (btnName == "delete")
                    {
                        delete = 1;
                    }
                    if (btnName == "approve")
                    {
                        approve = 1;
                    }
                    if (btnName == "unapprove")
                    {
                        unapprove = 1;
                    }
                    if (btnName == "potrojari")
                    {
                        potrojari = 1;
                    }
                    if (btnName == "endorsement")
                    {
                        endrosement = 1;
                    }
                    if (btnName == "khoshra")
                    {
                        khoshra = 1;
                    }
                    if (btnName == "full_editable")
                    {
                        fulleditable = 1;
                    }
                    if (btnName == "custom")
                    {
                        custom = 1;
                    }
                }
                allMulpotroButtonsVisibilityOn(draft_history, clone, edit, delete, approve,
                    unapprove, potrojari, endrosement, khoshra, fulleditable, custom);
                if (potrojariList.data.records[i].mulpotro.is_main == 1)
                {
                    pnlMulPotroOShonjukti.Visible = true;
                    lbMulPotroOShonjukti.Visible = true;
                    btnMulPotroOShonjukti.Visible = true;

                    btnMulPotroOShonjukti.Text = string.Concat(potrojariList.data.records[i].basic.potro_pages.ToString().Select(c => (char)('\u09E6' + c - '0')));
                }
                else
                {
                    mulpotroOshongjuktiVisibilityOff();
                }

                totalRange = (i + 1).ToString();

                picBoxFile.Visible = false;
                khosraViewWebBrowser.Visible = true;
                if (khosraViewWebBrowser.Document != null)
                {
                    khosraViewWebBrowser.Document.Write(string.Empty);
                }

                if (potrojariList.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    btnPotrojariNext.Visible = true;

                    allPreviousButtonVisibilityOff();

                    if (potrojariList.data.records[i].mulpotro.url != "")
                    {
                        picBoxFile.Visible = false;
                        khosraViewWebBrowser.Url = new Uri(potrojariList.data.records[i].mulpotro.url);
                    }
                    else
                    {
                        picBoxFile.Controls.Clear();
                    }
                }
            }
            if (potrojariList.data.total_records == i || potrojariList.data.total_records - 1 == i)
            {
                i = 0;
                allNextButtonVisibilityOff();
                allPreviousButtonVisibilityOff();
            }

        }
        private void btnPotrojariPrevious_Click(object sender, EventArgs e)
        {
            i--;
            if (i == 0)
            {
                pnlPotrangshoDetails.Visible = true;
                lbPotroSubject.Text = potrojariList.data.records[i].basic.potro_subject;
                lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + potrojariList.data.records[i].basic.created;
                lbNoteId.Text = "নোটঃ " + string.Concat(potrojariList.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                lbSubjectSmall.Text = "পত্র: " + potrojariList.data.records[i].basic.potro_subject;
                lbTotal.Text = "সর্বমোট: " + string.Concat(potrojariList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                allMulpotroButtonsVisibilityOff();
                int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                    endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                foreach (string btnName in potrojariList.data.records[i].mulpotro.buttons)
                {
                    if (btnName == "draft_history")
                    {
                        draft_history = 1;
                    }
                    if (btnName == "clone")
                    {
                        clone = 1;
                    }
                    if (btnName == "edit")
                    {
                        edit = 1;
                    }
                    if (btnName == "delete")
                    {
                        delete = 1;
                    }
                    if (btnName == "approve")
                    {
                        approve = 1;
                    }
                    if (btnName == "unapprove")
                    {
                        unapprove = 1;
                    }
                    if (btnName == "potrojari")
                    {
                        potrojari = 1;
                    }
                    if (btnName == "endorsement")
                    {
                        endrosement = 1;
                    }
                    if (btnName == "khoshra")
                    {
                        khoshra = 1;
                    }
                    if (btnName == "full_editable")
                    {
                        fulleditable = 1;
                    }
                    if (btnName == "custom")
                    {
                        custom = 1;
                    }
                }
                allMulpotroButtonsVisibilityOn(draft_history, clone, edit, delete, approve,
                    unapprove, potrojari, endrosement, khoshra, fulleditable, custom); 
                if (potrojariList.data.records[i].mulpotro.is_main == 1)
                {
                    pnlMulPotroOShonjukti.Visible = true;
                    lbMulPotroOShonjukti.Visible = true;
                    btnMulPotroOShonjukti.Visible = true;

                    btnMulPotroOShonjukti.Text = string.Concat(potrojariList.data.records[i].basic.potro_pages.ToString().Select(c => (char)('\u09E6' + c - '0')));
                }
                else
                {
                    mulpotroOshongjuktiVisibilityOff();
                }
                totalRange = (i + 1).ToString();

                picBoxFile.Visible = false;
                khosraViewWebBrowser.Visible = true;
                if (khosraViewWebBrowser.Document != null)
                {
                    khosraViewWebBrowser.Document.Write(string.Empty);
                }

                if (potrojariList.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    btnPotrojariNext.Visible = true;

                    allPreviousButtonVisibilityOff();

                    if (potrojariList.data.records[i].mulpotro.url != "")
                    {
                        picBoxFile.Visible = false;
                        khosraViewWebBrowser.Url = new Uri(potrojariList.data.records[i].mulpotro.url);
                    }
                    else
                    {
                        picBoxFile.Controls.Clear();
                    }
                }
            }
            if (potrojariList.data.total_records != i && i > 0)
            {
                pnlPotrangshoDetails.Visible = true;
                lbPotroSubject.Text = potrojariList.data.records[i].basic.potro_subject;
                lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + potrojariList.data.records[i].basic.created;
                lbNoteId.Text = "নোটঃ " + string.Concat(potrojariList.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                lbSubjectSmall.Text = "পত্র: " + potrojariList.data.records[i].basic.potro_subject;
                lbTotal.Text = "সর্বমোট: " + string.Concat(potrojariList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                allMulpotroButtonsVisibilityOff();
                int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                    endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                foreach (string btnName in potrojariList.data.records[i].mulpotro.buttons)
                {
                    if (btnName == "draft_history")
                    {
                        draft_history = 1;
                    }
                    if (btnName == "clone")
                    {
                        clone = 1;
                    }
                    if (btnName == "edit")
                    {
                        edit = 1;
                    }
                    if (btnName == "delete")
                    {
                        delete = 1;
                    }
                    if (btnName == "approve")
                    {
                        approve = 1;
                    }
                    if (btnName == "unapprove")
                    {
                        unapprove = 1;
                    }
                    if (btnName == "potrojari")
                    {
                        potrojari = 1;
                    }
                    if (btnName == "endorsement")
                    {
                        endrosement = 1;
                    }
                    if (btnName == "khoshra")
                    {
                        khoshra = 1;
                    }
                    if (btnName == "full_editable")
                    {
                        fulleditable = 1;
                    }
                    if (btnName == "custom")
                    {
                        custom = 1;
                    }
                }
                allMulpotroButtonsVisibilityOn(draft_history, clone, edit, delete, approve,
                    unapprove, potrojari, endrosement, khoshra, fulleditable, custom);
                if (potrojariList.data.records[i].mulpotro.is_main == 1)
                {
                    pnlMulPotroOShonjukti.Visible = true;
                    lbMulPotroOShonjukti.Visible = true;
                    btnMulPotroOShonjukti.Visible = true;

                    btnMulPotroOShonjukti.Text = string.Concat(potrojariList.data.records[i].basic.potro_pages.ToString().Select(c => (char)('\u09E6' + c - '0')));
                }
                else
                {
                    mulpotroOshongjuktiVisibilityOff();
                }
                totalRange = (i + 1).ToString();

                picBoxFile.Visible = false;
                khosraViewWebBrowser.Visible = true;
                if (khosraViewWebBrowser.Document != null)
                {
                    khosraViewWebBrowser.Document.Write(string.Empty);
                }

                if (potrojariList.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    btnPotrojariNext.Visible = true;

                    allPreviousButtonVisibilityOff();
                    btnPotrojariPrevious.Visible = true;

                    if (potrojariList.data.records[i].mulpotro.url != "")
                    {
                        picBoxFile.Visible = false;
                        khosraViewWebBrowser.Url = new Uri(potrojariList.data.records[i].mulpotro.url);
                    }
                    else
                    {
                        picBoxFile.Controls.Clear();
                    }
                }
            }
            if (potrojariList.data.total_records < 0 || i < 0)
            {
                i = 0;
                allPreviousButtonVisibilityOff();
            }
        }
        private void btnPotrojariNext_Click(object sender, EventArgs e)
        {
            i++;
            if (potrojariList.data.total_records != i && i > 0)
            {
                pnlPotrangshoDetails.Visible = true;
                lbPotroSubject.Text = potrojariList.data.records[i].basic.potro_subject;
                lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + potrojariList.data.records[i].basic.created;
                lbNoteId.Text = "নোটঃ " + string.Concat(potrojariList.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                lbSubjectSmall.Text = "পত্র: " + potrojariList.data.records[i].basic.potro_subject;
                lbTotal.Text = "সর্বমোট: " + string.Concat(potrojariList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                allMulpotroButtonsVisibilityOff();
                int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                    endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                foreach (string btnName in potrojariList.data.records[i].mulpotro.buttons)
                {
                    if (btnName == "draft_history")
                    {
                        draft_history = 1;
                    }
                    if (btnName == "clone")
                    {
                        clone = 1;
                    }
                    if (btnName == "edit")
                    {
                        edit = 1;
                    }
                    if (btnName == "delete")
                    {
                        delete = 1;
                    }
                    if (btnName == "approve")
                    {
                        approve = 1;
                    }
                    if (btnName == "unapprove")
                    {
                        unapprove = 1;
                    }
                    if (btnName == "potrojari")
                    {
                        potrojari = 1;
                    }
                    if (btnName == "endorsement")
                    {
                        endrosement = 1;
                    }
                    if (btnName == "khoshra")
                    {
                        khoshra = 1;
                    }
                    if (btnName == "full_editable")
                    {
                        fulleditable = 1;
                    }
                    if (btnName == "custom")
                    {
                        custom = 1;
                    }
                }
                allMulpotroButtonsVisibilityOn(draft_history, clone, edit, delete, approve,
                    unapprove, potrojari, endrosement, khoshra, fulleditable, custom);
                if (potrojariList.data.records[i].mulpotro.is_main == 1)
                {
                    pnlMulPotroOShonjukti.Visible = true;
                    lbMulPotroOShonjukti.Visible = true;
                    btnMulPotroOShonjukti.Visible = true;

                    btnMulPotroOShonjukti.Text = string.Concat(potrojariList.data.records[i].basic.potro_pages.ToString().Select(c => (char)('\u09E6' + c - '0')));
                }
                else
                {
                    mulpotroOshongjuktiVisibilityOff();
                }
                totalRange = (i + 1).ToString();

                picBoxFile.Visible = false;
                khosraViewWebBrowser.Visible = true;
                if (khosraViewWebBrowser.Document != null)
                {
                    khosraViewWebBrowser.Document.Write(string.Empty);
                }

                if (potrojariList.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    btnPotrojariNext.Visible = true;

                    allPreviousButtonVisibilityOff();
                    btnPotrojariPrevious.Visible = true;

                    if (potrojariList.data.records[i].mulpotro.url != "")
                    {
                        picBoxFile.Visible = false;
                        khosraViewWebBrowser.Url = new Uri(potrojariList.data.records[i].mulpotro.url);
                    }
                    else
                    {
                        picBoxFile.Controls.Clear();
                    }
                }
            }
            if (potrojariList.data.total_records == i || potrojariList.data.total_records - 1 == i)
            {
                //i = 0;
                allNextButtonVisibilityOff();
            }
        }
        NothijatoResponse nothijatoList = new NothijatoResponse();
        private void lbNothijato_Click(object sender, EventArgs e)
        {
            allLbelButtonPreviousColor();
            lbNothijato.BackColor = Color.FromArgb(14, 102, 98);
            lbNothijato.ForeColor = Color.FromArgb(191, 239, 237);

            allNextButtonVisibilityOff();
            btnNothijatoNext.Visible = true;

            nothijatoList = _nothijatoList.GetNothijatoListInfo(_dakuserparam, nothiListRecords.id);
            if (nothijatoList.status == "success")
            {
                i = 0;
                pnlPotrangshoDetails.Visible = true;
                lbPotroSubject.Text = nothijatoList.data.records[i].basic.potro_subject;
                lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + nothijatoList.data.records[i].basic.created;
                lbNoteId.Text = "নোটঃ " + string.Concat(nothijatoList.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                lbSubjectSmall.Text = "পত্র: " + nothijatoList.data.records[i].basic.potro_subject;
                lbTotal.Text = "সর্বমোট: " + string.Concat(nothijatoList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                totalRange = (i + 1).ToString();

                picBoxFile.Visible = false;
                khosraViewWebBrowser.Visible = true;
                if (khosraViewWebBrowser.Document != null)
                {
                    khosraViewWebBrowser.Document.Write(string.Empty);
                }

                if (nothijatoList.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    btnNothijatoNext.Visible = true;

                    allPreviousButtonVisibilityOff();

                    if (nothijatoList.data.records[i].mulpotro.url != "")
                    {
                        picBoxFile.Visible = false;
                        khosraViewWebBrowser.Url = new Uri(nothijatoList.data.records[i].mulpotro.url);
                    }
                    else
                    {
                        picBoxFile.Controls.Clear();
                    }
                }
            }
            if (nothijatoList.data.total_records == i || nothijatoList.data.total_records - 1 == i)
            {
                i = 0;
                allNextButtonVisibilityOff();
                allPreviousButtonVisibilityOff();
            }
        }

        private void btnNothijatoPrevious_Click(object sender, EventArgs e)
        {
            i--;
            if (i == 0)
            {
                pnlPotrangshoDetails.Visible = true;
                lbPotroSubject.Text = nothijatoList.data.records[i].basic.potro_subject;
                lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + nothijatoList.data.records[i].basic.created;
                lbNoteId.Text = "নোটঃ " + string.Concat(nothijatoList.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                lbSubjectSmall.Text = "পত্র: " + nothijatoList.data.records[i].basic.potro_subject;
                lbTotal.Text = "সর্বমোট: " + string.Concat(nothijatoList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                totalRange = (i + 1).ToString();

                picBoxFile.Visible = false;
                khosraViewWebBrowser.Visible = true;
                if (khosraViewWebBrowser.Document != null)
                {
                    khosraViewWebBrowser.Document.Write(string.Empty);
                }

                if (nothijatoList.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    btnNothijatoNext.Visible = true;

                    allPreviousButtonVisibilityOff();

                    if (nothijatoList.data.records[i].mulpotro.url != "")
                    {
                        picBoxFile.Visible = false;
                        khosraViewWebBrowser.Url = new Uri(nothijatoList.data.records[i].mulpotro.url);
                    }
                    else
                    {
                        picBoxFile.Controls.Clear();
                    }
                }
            }
            if (nothijatoList.data.total_records != i && i > 0)
            {
                pnlPotrangshoDetails.Visible = true;
                lbPotroSubject.Text = nothijatoList.data.records[i].basic.potro_subject;
                lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + nothijatoList.data.records[i].basic.created;
                lbNoteId.Text = "নোটঃ " + string.Concat(nothijatoList.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                lbSubjectSmall.Text = "পত্র: " + nothijatoList.data.records[i].basic.potro_subject;
                lbTotal.Text = "সর্বমোট: " + string.Concat(nothijatoList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                totalRange = (i + 1).ToString();

                picBoxFile.Visible = false;
                khosraViewWebBrowser.Visible = true;
                if (khosraViewWebBrowser.Document != null)
                {
                    khosraViewWebBrowser.Document.Write(string.Empty);
                }

                if (nothijatoList.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    btnNothijatoNext.Visible = true;

                    allPreviousButtonVisibilityOff();
                    btnNothijatoPrevious.Visible = true;

                    if (nothijatoList.data.records[i].mulpotro.url != "")
                    {
                        picBoxFile.Visible = false;
                        khosraViewWebBrowser.Url = new Uri(nothijatoList.data.records[i].mulpotro.url);
                    }
                    else
                    {
                        picBoxFile.Controls.Clear();
                    }
                }
            }
            if (nothijatoList.data.total_records < 0 || i < 0)
            {
                i = 0;
                allPreviousButtonVisibilityOff();
            }
        }
        private void btnNothijatoNext_Click(object sender, EventArgs e)
        {
            i++;
            if (nothijatoList.data.total_records != i && i > 0)
            {
                pnlPotrangshoDetails.Visible = true;
                lbPotroSubject.Text = nothijatoList.data.records[i].basic.potro_subject;
                lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + nothijatoList.data.records[i].basic.created;
                lbNoteId.Text = "নোটঃ " + string.Concat(nothijatoList.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                lbSubjectSmall.Text = "পত্র: " + nothijatoList.data.records[i].basic.potro_subject;
                lbTotal.Text = "সর্বমোট: " + string.Concat(nothijatoList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));
                totalRange = (i + 1).ToString();

                picBoxFile.Visible = false;
                khosraViewWebBrowser.Visible = true;
                if (khosraViewWebBrowser.Document != null)
                {
                    khosraViewWebBrowser.Document.Write(string.Empty);
                }

                if (nothijatoList.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    btnNothijatoNext.Visible = true;

                    allPreviousButtonVisibilityOff();
                    btnNothijatoPrevious.Visible = true;

                    if (nothijatoList.data.records[i].mulpotro.url != "")
                    {
                        picBoxFile.Visible = false;
                        khosraViewWebBrowser.Url = new Uri(nothijatoList.data.records[i].mulpotro.url);
                    }
                    else
                    {
                        picBoxFile.Controls.Clear();
                    }
                }
            }
            if (nothijatoList.data.total_records == i || nothijatoList.data.total_records - 1 == i)
            {
                //i = 0;
                allNextButtonVisibilityOff();
            }
        }

        private void lbNoteKhoshra_Click(object sender, EventArgs e)
        {
            lbNoteKhoshra.BackColor = Color.FromArgb(14, 102, 98);
            lbNoteKhoshra.ForeColor = Color.FromArgb(191, 239, 237);
            NoteKhoshraListResponse noteKhoshraList = _noteKhoshraList.GetnoteKhoshraListInfo(_dakuserparam, nothiListRecords.id, newnotedata.id);
            if (noteKhoshraList.status == "success")
            {

            }
        }

        private void lbNoteKhoshraWaiting_Click(object sender, EventArgs e)
        {
            lbNoteKhoshraWaiting.BackColor = Color.FromArgb(14, 102, 98);
            lbNoteKhoshraWaiting.ForeColor = Color.FromArgb(191, 239, 237);
            NoteKhshraWaitingListResponse noteKhshraWaitingList = _noteKhshraWaitingList.GetNoteKhshraWaitingListInfo(_dakuserparam, nothiListRecords.id, newnotedata.id);
            if (noteKhshraWaitingList.status == "success")
            {

            }
        }

        private void lbNotePotrojari_Click(object sender, EventArgs e)
        {
            lbNotePotrojari.BackColor = Color.FromArgb(14, 102, 98);
            lbNotePotrojari.ForeColor = Color.FromArgb(191, 239, 237);
            NotePotrojariResponse notePotrojariList = _notePotrojariList.GetPotrojariListInfo(_dakuserparam, nothiListRecords.id, newnotedata.id);
            if (notePotrojariList.status == "success")
            {

            }
        }

        private void btnCanRevert_Click(object sender, EventArgs e)
        {
            newnotedata.note_subject = checkSub;
            newnotedata.note_id = checkNoteId;
            NoteOnucchedRevertResPonse noteOnucchedRevert = _noteOnucchedRevert.GetNoteOnucchedRevert(_dakuserparam, nothiListRecords, newnotedata);
            if (noteOnucchedRevert.status == "success")
            {
                MessageBox.Show(noteOnucchedRevert.data);
                newNoteView.CheckBoxClick += delegate (object sender1, EventArgs e1) { checkBox_Change(_NoteAllListDataRecordDTO, newNoteView, newNoteView._checkBoxValue); };
                lbNothiType.Text = "বাছাইকৃত নোট (১)";
                noteViewFLP.Controls.Clear();
                newNoteView.checkcbNote();
                noteViewFLP.Controls.Add(newNoteView);

            }
        }

        private void pdfViewWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void Note_Load(object sender, EventArgs e)
        {
            checkBox_Change(_NoteAllListDataRecordDTO, newNoteView,true);
        }

        private void btnDraftHistory_MouseHover(object sender, EventArgs e)
        {
            btnDraftHistory.IconColor = Color.FromArgb(246, 78, 96);
            btnDraftHistory.BackColor = Color.FromArgb(228, 230, 239);
        }

        private void btnDraftHistory_MouseLeave(object sender, EventArgs e)
        {
            btnDraftHistory.IconColor = Color.FromArgb(54, 153, 255);
            btnDraftHistory.BackColor = Color.FromArgb(243, 246, 249);
        }

        private void btnClone_MouseHover(object sender, EventArgs e)
        {
            btnClone.IconColor = Color.FromArgb(246, 78, 96);
            btnClone.BackColor = Color.FromArgb(228, 230, 239);
        }

        private void btnClone_MouseLeave(object sender, EventArgs e)
        {
            btnClone.IconColor = Color.FromArgb(54, 153, 255);
            btnClone.BackColor = Color.FromArgb(243, 246, 249);
        }

        private void btnEdit_MouseHover(object sender, EventArgs e)
        {
            btnEdit.IconColor = Color.FromArgb(246, 78, 96);
            btnEdit.BackColor = Color.FromArgb(228, 230, 239);
        }

        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            btnEdit.IconColor = Color.FromArgb(54, 153, 255);
            btnEdit.BackColor = Color.FromArgb(243, 246, 249);
        }

        private void btnDelete_MouseHover(object sender, EventArgs e)
        {
            btnDelete.IconColor = Color.FromArgb(246, 78, 96);
            btnDelete.BackColor = Color.FromArgb(228, 230, 239);
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.IconColor = Color.FromArgb(54, 153, 255);
            btnDelete.BackColor = Color.FromArgb(243, 246, 249);
        }

        private void btnApprove_MouseHover(object sender, EventArgs e)
        {
            btnApprove.IconColor = Color.FromArgb(246, 78, 96);
            btnApprove.BackColor = Color.FromArgb(228, 230, 239);
        }

        private void btnApprove_MouseLeave(object sender, EventArgs e)
        {
            btnApprove.IconColor = Color.FromArgb(54, 153, 255);
            btnApprove.BackColor = Color.FromArgb(243, 246, 249);
        }

        private void btnUnapprove_MouseHover(object sender, EventArgs e)
        {
            btnUnapprove.IconColor = Color.FromArgb(246, 78, 96);
            btnUnapprove.BackColor = Color.FromArgb(228, 230, 239);
        }

        private void btnUnapprove_MouseLeave(object sender, EventArgs e)
        {
            btnUnapprove.IconColor = Color.FromArgb(54, 153, 255);
            btnUnapprove.BackColor = Color.FromArgb(243, 246, 249);
        }

        private void btnPotrojari_MouseHover(object sender, EventArgs e)
        {
            btnPotrojari.IconColor = Color.FromArgb(246, 78, 96);
            btnPotrojari.BackColor = Color.FromArgb(228, 230, 239);
        }

        private void btnPotrojari_MouseLeave(object sender, EventArgs e)
        {
            btnPotrojari.IconColor = Color.FromArgb(54, 153, 255);
            btnPotrojari.BackColor = Color.FromArgb(243, 246, 249);
        }

        private void btnEndrosement_MouseHover(object sender, EventArgs e)
        {
            btnEndrosement.IconColor = Color.FromArgb(246, 78, 96);
            btnEndrosement.BackColor = Color.FromArgb(228, 230, 239);
        }

        private void btnEndrosement_MouseLeave(object sender, EventArgs e)
        {
            btnEndrosement.IconColor = Color.FromArgb(54, 153, 255);
            btnEndrosement.BackColor = Color.FromArgb(243, 246, 249);
        }

        private void btnKhoshra_MouseHover(object sender, EventArgs e)
        {
            btnKhoshra.IconColor = Color.FromArgb(246, 78, 96);
            btnKhoshra.BackColor = Color.FromArgb(228, 230, 239);
        }

        private void btnKhoshra_MouseLeave(object sender, EventArgs e)
        {
            btnKhoshra.IconColor = Color.FromArgb(54, 153, 255);
            btnKhoshra.BackColor = Color.FromArgb(243, 246, 249);
        }

    }
}