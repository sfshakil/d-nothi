using CefSharp.WinForms;
using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.Desktop.CustomControl;
using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.Desktop.UI.Dak;
using dNothi.Desktop.UI.Khosra_Potro;
using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using dNothi.Services.NothiServices;
using dNothi.Services.UserServices;
using dNothi.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using dNothi.JsonParser.Entity.Khosra;
using dNothi.Services.KasaraPatraDashBoardService.Models;
using dNothi.Services.KasaraPatraDashBoardService;
using dNothi.Services.KhasraService;

namespace dNothi.Desktop.UI
{
    public partial class Note : Form
    {
        private DakUserParam _dakuserparam = new DakUserParam();

        private int current_potro_id = 0;
        private KhoshraPotroWaitinDataRecordDTO _khoshraPotroWaitinDataRecordDTO;
        private NoteKhoshraListDataRecordDTO _khoshraPotroDataRecordDTO;
        KhoshraPotroWaitinDataRecordMulpotroDTO khoshraPotroWaitinDataRecordMulpotroDTO { get; set; }
        IKasaraPatraDashBoardService _kasaraPatraDashBoardService { get; set; }

        NoteSaveDTO newnotedata = new NoteSaveDTO();

        NoteView newNoteView = new NoteView();

        NothiListRecordsDTO nothiListRecords = new NothiListRecordsDTO();
        IUserService _userService { get; set; }
        IKhosraSaveService _khosraSaveService { get; set; }
        IPotrojariServices _potrojariServices { get; set; }
        IOnucchedSave _onucchedSave { get; set; }
        IOnucchedDelete _onucchedDelete { get; set; }
        IOnumodonService _onumodonService { get; set; }
        INothiNoteTalikaServices _nothiNoteTalikaServices { get; set; }
        INothiPotrangshoServices _loadPotrangsho { get; set; }
        IAllPotroServices _allPotro { get; set; }
        IKhoshraPotroServices _khoshraPotro { get; set; }
        INothivuktoPotroServices _nothivuktoPotro { get; set; }
        IKhoshraPotroWaitingServices _khoshraPotroWaiting { get; set; }
        IPotrojariServices _potrojariList { get; set; }
        INothijatoServices _nothijatoList { get; set; }
        INotePotrojariServices _notePotrojariList { get; set; }
        INoteKhshraWaitingListServices _noteKhshraWaitingList { get; set; }
        INoteKhoshraListServices _noteKhoshraList { get; set; }
        IOnuchhedListServices _onuchhedList { get; set; }
        ISingleOnucchedServices _singleOnucched { get; set; }
        INoteOnucchedRevertServices _noteOnucchedRevert { get; set; }
        IOnucchedFileUploadService _onucchedFileUploadService { get; set; }
        INoteSaveService _noteSave { get; set; }
        INothiAllNoteServices _nothiAllNote { get; set; }
        IRepository<NoteSaveItemAction> _noteSaveItemAction;
        IRepository<OnuchhedSaveItemAction> _onuchhedSaveItemAction;
        IRepository<FileUploadAction> _fileUploadAction;

        public WaitFormFunc WaitForm;

        private int _noteFormHeight;
        private int _noteFormWidth;
        private int _collapseExpandeHeight;
        private int _collapseExpandeWidth;
        public Note(
        IPotrojariServices potrojariServices, IUserService userService, IOnucchedSave onucchedSave, IOnumodonService onumodonService,
            IOnucchedDelete onucchedDelete, INothiNoteTalikaServices nothiNoteTalikaServices, INothiPotrangshoServices loadPotrangsho, IAllPotroServices allPotro,
            IKhoshraPotroServices khoshraPotro, INothivuktoPotroServices nothivuktoPotro, IKhoshraPotroWaitingServices khoshraPotroWaiting, IPotrojariServices potrojariList, INothijatoServices nothijatoList,
            INotePotrojariServices notePotrojariList, INoteKhshraWaitingListServices noteKhshraWaitingList, INoteKhoshraListServices noteKhoshraList,
            IOnuchhedListServices onuchhedList, ISingleOnucchedServices singleOnucched, INoteOnucchedRevertServices noteOnucchedRevert, INoteSaveService noteSave, INothiAllNoteServices nothiAllNote,
            IOnucchedFileUploadService onucchedFileUploadService, IKhosraSaveService khosraSaveService,
        IRepository<NoteSaveItemAction> noteSaveItemAction, IRepository<OnuchhedSaveItemAction> onuchhedSaveItemAction, IRepository<FileUploadAction> fileUploadAction)
        {
            _kasaraPatraDashBoardService = new KararaPotroDashBoardServices();
            _potrojariServices = potrojariServices;
            _userService = userService;
            _onucchedSave = onucchedSave;
            _khosraSaveService = khosraSaveService;
            _onucchedDelete = onucchedDelete;
            _onumodonService = onumodonService;
            _dakuserparam = _userService.GetLocalDakUserParam();
            _nothiNoteTalikaServices = nothiNoteTalikaServices;
            _loadPotrangsho = loadPotrangsho;
            _allPotro = allPotro;
            _khoshraPotro = khoshraPotro;
            _nothivuktoPotro = nothivuktoPotro;
            _khoshraPotroWaiting = khoshraPotroWaiting;
            _potrojariList = potrojariList;
            _nothijatoList = nothijatoList;
            _notePotrojariList = notePotrojariList;
            _noteKhshraWaitingList = noteKhshraWaitingList;
            _noteKhoshraList = noteKhoshraList;
            _onuchhedList = onuchhedList;
            _singleOnucched = singleOnucched;
            _noteOnucchedRevert = noteOnucchedRevert;
            _noteSave = noteSave;
            _nothiAllNote = nothiAllNote;
            _onucchedFileUploadService = onucchedFileUploadService;
            _noteSaveItemAction = noteSaveItemAction;
            _onuchhedSaveItemAction = onuchhedSaveItemAction;
            _fileUploadAction = fileUploadAction;

            WaitForm = new WaitFormFunc();
            InitializeComponent();
            WaitForm.Show(this);
            SetDefaultFont(this.Controls);
            tinyMceEditor.CreateEditor();
            cbxNothiType.SelectedIndex = 0;
            cbxNothiType.ItemHeight = 30;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            PnlSave.Visible = false;
            userNameLabel.Text = _dakuserparam.officer_name + "(" + _dakuserparam.designation_label + "," + _dakuserparam.unit_label + ")";
            loadPotrangshoNotePanel();
            loadPotrangshoNothiPanel();
            loadCollapseExpandSize();
            WaitForm.Close();
        }
        public void loadCollapseExpandSize()
        {
            _noteFormHeight = this.Height;
            _noteFormWidth = this.Width;
            _collapseExpandeHeight = CollapseExpandPanel.Height;
            _collapseExpandeWidth = CollapseExpandPanel.Width;
        }
        public NothiListInboxNoteRecordsDTO _NoteAllListDataRecordDTO { get; set; }
        public NothiListInboxNoteRecordsDTO noteAllListDataRecordDTO
        {
            get { return _NoteAllListDataRecordDTO; }
            set
            {
                _NoteAllListDataRecordDTO = value;

                if (_NoteAllListDataRecordDTO.note.can_revert == 1)
                {
                    btnCanRevert.Visible = true;
                    checkSub = _NoteAllListDataRecordDTO.note.note_subject;
                    checkNoteId = _NoteAllListDataRecordDTO.note.nothi_note_id;
                }
                else
                {
                    btnCanRevert.Visible = false;
                }
                if (_NoteAllListDataRecordDTO.note.is_editable == 1)
                {
                    if (_NoteAllListDataRecordDTO.note.can_revert == 1)
                    {
                        btnWriteOnuchhed.Visible = false;
                        btnSend.Visible = false;
                    }
                    else
                    {
                        btnWriteOnuchhed.Visible = true;
                        btnSend.Visible = true;
                    }
                }
                else
                {
                    btnWriteOnuchhed.Visible = false;
                    btnSend.Visible = false;
                }
            }
        }
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
                if (loadPotrangsho.data.khoshra_potro > 0 || loadPotrangsho.data.khoshra_waiting_for_approval > 0 || loadPotrangsho.data.all_potro > 0 ||
                    loadPotrangsho.data.potrojari > 0 || loadPotrangsho.data.nothijato_potro > 0 || loadPotrangsho.data.approved_potro > 0 || loadPotrangsho.data.nothivukto_potro > 0)
                {
                    pnlNoNothi.Visible = false;
                    if (loadPotrangsho.data.khoshra_potro > 0)
                    {
                        pnlKhoshra.Visible = true;
                        lbKhoshra.Text = string.Concat(loadPotrangsho.data.khoshra_potro.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        pnlKhoshra.Visible = false;
                    }
                    if (loadPotrangsho.data.khoshra_waiting_for_approval > 0)
                    {
                        pnlKhoshraWaiting.Visible = true;
                        lbKhoshraWaiting.Text = string.Concat(loadPotrangsho.data.khoshra_waiting_for_approval.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        pnlKhoshraWaiting.Visible = false;
                    }
                    if (loadPotrangsho.data.all_potro > 0)
                    {
                        pnlAllPotro.Visible = true;
                        lbAllPotro.Text = string.Concat(loadPotrangsho.data.all_potro.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        pnlAllPotro.Visible = false;
                    }
                    if (loadPotrangsho.data.nothivukto_potro > 0)
                    {
                        pnlNothivuktoPotro.Visible = true;
                        lbNothivuktoPotro.Text = string.Concat(loadPotrangsho.data.nothivukto_potro.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        pnlNothivuktoPotro.Visible = false;
                    }
                    if (loadPotrangsho.data.potrojari > 0)
                    {
                        pnlPotrojari.Visible = true;
                        lbPotrojari.Text = string.Concat(loadPotrangsho.data.potrojari.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        pnlPotrojari.Visible = false;
                    }
                    if (loadPotrangsho.data.nothijato_potro > 0)
                    {
                        pnlNothijato.Visible = true;
                        lbNothijato.Text = string.Concat(loadPotrangsho.data.nothijato_potro.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        pnlNothijato.Visible = false;
                    }
                    if (loadPotrangsho.data.approved_potro > 0)
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
                    pnlNothivuktoPotro.Visible = false;
                    pnlNoNothi.Visible = true;
                }
            }
        }
        public void visibilityOFF()
        {
            btnSave.Visible = false;
            btnDecision.Visible = false;
            btnPotaka.Visible = false;
            btnGardFile.Visible = false;
            btnOnuchhed.Visible = false;
            btnShongjuktiRef.Visible = false;
            btnBibechhoPotro.Visible = false;
            btnSaveArrow.Visible = false;
            btnCancel.Visible = false;
        }
        public void visibilityON()
        {
            btnSave.Visible = true;
            btnDecision.Visible = true;
            btnPotaka.Visible = true;
            btnGardFile.Visible = true;
            btnOnuchhed.Visible = true;
            btnShongjuktiRef.Visible = true;
            btnBibechhoPotro.Visible = true;
            btnSaveArrow.Visible = true;
            btnCancel.Visible = true;
        }
        public void loadNotangsho_Potrangsho(NoteListDataRecordNoteDTO list)
        {
            try
            {
                notelist = list;
                NoteIdfromNothiInboxNoteShomuho.Text = list.nothi_note_id.ToString();
                //NoteAllListResponse allNoteList = _nothiNoteTalikaServices.GetNoteListAll(_dakuserparam, nothiListRecords.id);
                OnucchedListResponse onucchedList = _onuchhedList.GetAllOnucchedList(_dakuserparam, nothiListRecords.id, list.nothi_note_id);
                if (onucchedList.data == null || onucchedList.data.records.Count == 0)
                {
                    if (!InternetConnection.Check())
                    {
                        var onuchhedNo = "0";
                        onuchhedFLP.Visible = true;
                        onuchhedFLP.Controls.Clear();

                        List<OnuchhedSaveItemAction> onuchhedSaveItemActions = _onuchhedSaveItemAction.Table.Where(a => a.office_id == _dakuserparam.office_id && a.designation_id == _dakuserparam.designation_id).ToList();
                        if (onuchhedSaveItemActions != null && onuchhedSaveItemActions.Count > 0)
                        {
                            noteHeaderPanel.Width = 990;
                            noteHeaderPanel.Height = 426;
                            int flag = 0;
                            foreach (OnuchhedSaveItemAction onuchhedSaveItemAction in onuchhedSaveItemActions)
                            {

                                flag++;
                                lbNoteTotl1.Text = "নোটঃ " + list.note_status;
                                lbNoteSubject.Text = list.note_subject_sub_text;
                                lbNothiLastDate.Text = list.date;

                                visibilityOFF();

                                //onuchhedheaderPnl.Visible = true;
                                //onuchhedFLP.Visible = true;
                                btnWriteOnuchhed.Visible = true;
                                btnSend.Visible = true;
                                //panel14.Visible = false;
                                panel22.Visible = false;
                                tinyMceEditor.Visible = false;
                                panel24.Visible = false;
                                panel28.Visible = false;

                                NothiListRecordsDTO nothiListRecordsDTO = JsonConvert.DeserializeObject<NothiListRecordsDTO>(onuchhedSaveItemAction.nothiListRecordsDTOJson);
                                NoteSaveDTO newnotedata1 = JsonConvert.DeserializeObject<NoteSaveDTO>(onuchhedSaveItemAction.newnotedataJson);
                                if (nothiListRecordsDTO.id == nothiListRecords.id && list.nothi_note_id == newnotedata1.note_id)
                                {
                                    int onucchedNo = Convert.ToInt32(onuchhedNo);
                                    if (onuchhedFLP.Controls.Count == 0)
                                    {
                                        onucchedNo = 0;
                                    }
                                    else
                                    {
                                        onucchedNo++;
                                    }
                                    onuchhedNo = onucchedNo.ToString();
                                    DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                                    var separateOnucched = UserControlFactory.Create<SeparateOnuchhed>();
                                    List<DakUploadedFileResponse> onuchhedSaveWithAttachmentss = JsonConvert.DeserializeObject<List<DakUploadedFileResponse>>(onuchhedSaveItemAction.onuchhedSaveWithAttachmentsJson);
                                    if (onuchhedSaveWithAttachmentss.Count == 0)
                                    {
                                        separateOnucched.filePnaeloff();
                                    }
                                    onuchhedSaveWithAttachments.Clear();
                                    List<FileUploadAction> fileUploadActions = _fileUploadAction.Table.Where(a => a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id).ToList();
                                    if (fileUploadActions != null && fileUploadActions.Count > 0)
                                    {

                                        foreach (FileUploadAction fileUploadItemAction in fileUploadActions)
                                        {
                                            foreach (DakUploadedFileResponse dakUploadedFileResponses in onuchhedSaveWithAttachmentss)
                                            {
                                                if (fileUploadItemAction.Id == dakUploadedFileResponses.data[0].id)
                                                {
                                                    DakFileUploadParam dakFileUploadParam = JsonConvert.DeserializeObject<DakFileUploadParam>(fileUploadItemAction.dakFileUploadParamJson);
                                                    DakUploadedFileResponse dakUploadedFileResponse = new DakUploadedFileResponse();
                                                    dakUploadedFileResponse.data = new List<DakAttachmentDTO>();

                                                    DakAttachmentDTO dakAttachmentDTO = new DakAttachmentDTO();
                                                    dakAttachmentDTO.user_file_name = dakFileUploadParam.user_file_name;
                                                    dakAttachmentDTO.file_size_in_kb = dakFileUploadParam.file_size_in_kb;
                                                    dakAttachmentDTO.id = fileUploadItemAction.Id;

                                                    dakUploadedFileResponse.data.Add(dakAttachmentDTO);

                                                    onuchhedSaveWithAttachments.Add(dakUploadedFileResponse);
                                                }
                                            }

                                        }
                                    }
                                    //var separateOnucched = UserControlFactory.Create<SeparateOnuchhed>();
                                    if (onuchhedSaveWithAttachments.Count > 0)
                                    {
                                        separateOnucched.totalFileNo = onuchhedSaveWithAttachments.Count.ToString();
                                        foreach (DakUploadedFileResponse dakUploadedFileResponse in onuchhedSaveWithAttachments)
                                        {
                                            AttachmentDTO attachment = new AttachmentDTO();
                                            attachment.user_file_name = dakUploadedFileResponse.data[0].user_file_name;
                                            attachment.file_size_in_kb = dakUploadedFileResponse.data[0].file_size_in_kb;
                                            attachment.download_url = "";
                                            attachment.url = "";
                                            separateOnucched.fileAddInFilePanel(attachment);

                                        }
                                        onuchhedSaveWithAttachments.Clear();
                                    }
                                    else
                                    {
                                        separateOnucched.filePnaeloff();
                                    }
                                    separateOnucched.office = dakListUserParam.officer_name + " " + "১১/১/২১ ৪:০১ PM";
                                    separateOnucched.noteNo(lbNoteTotl1.Text.Substring(lbNoteTotl1.Text.IndexOf("টঃ") + 2), onuchhedNo);
                                    //separateOnucched.createDate = onucchedsingleListRec.created;
                                    separateOnucched.onucchedId = Convert.ToInt32(onuchhedSaveItemAction.Id);
                                    //separateOnucched.DeleteButtonClick += delegate (object sender1, EventArgs e1) { DeleteButton_Click(sender1.ToString(), e1, dakListUserParam, nothiListRecords, newnotedata); };
                                    try
                                    {
                                        separateOnucched.subjectBrowser = Encoding.UTF8.GetString(Convert.FromBase64String(onuchhedSaveItemAction.editorEncodedData));
                                    }
                                    catch
                                    {

                                    }
                                    if (onuchhedSaveItemActions.Count == flag)
                                    {
                                        separateOnucched.lastopenOnuchhed();
                                    }
                                    separateOnucched.loadinLocal();
                                    //onuchhedFLP.Controls.Add(separateOnucched); 
                                    UIDesignCommonMethod.AddRowinTable(onuchhedFLP, separateOnucched);
                                }
                            }
                        }
                        else
                        {
                            noteHeaderPanel.Width = 990;
                            noteHeaderPanel.Height = 81;
                            lbNoteTotl1.Text = "নোটঃ " + list.note_status;
                            lbNoteSubject.Text = list.note_subject_sub_text;
                            lbNothiLastDate.Text = list.date;

                            onuchhedFLP.Visible = false;

                            lbNote.Visible = false;
                            pnlNoteKhoshra.Visible = false;
                            pnlNoteKhoshraWaiting.Visible = false;
                            pnlNotePotrojari.Visible = false;
                            pnlNoNote.Visible = true;

                            btnCanRevert.Visible = false;
                            btnWriteOnuchhed.Visible = false;
                            btnSend.Visible = false;

                            visibilityON();

                            //panel14.Visible = true;
                            panel22.Visible = true;
                            tinyMceEditor.Visible = true;
                            panel28.Visible = true;
                            panel24.Visible = true;
                            panel22.SendToBack();
                            tinyMceEditor.HtmlContent = "";
                            fileAddFLP.Controls.Clear();
                            noteFileUploads.Clear();
                        }
                    }
                    else
                    {
                        noteHeaderPanel.Width = 990;
                        noteHeaderPanel.Height = 81;
                        lbNoteTotl1.Text = "নোটঃ " + list.note_status;
                        lbNoteSubject.Text = list.note_subject_sub_text;
                        lbNothiLastDate.Text = list.date;

                        onuchhedFLP.Visible = false;

                        lbNote.Visible = false;
                        pnlNoteKhoshra.Visible = false;
                        pnlNoteKhoshraWaiting.Visible = false;
                        pnlNotePotrojari.Visible = false;
                        pnlNoNote.Visible = true;

                        btnCanRevert.Visible = false;
                        btnWriteOnuchhed.Visible = false;
                        btnSend.Visible = false;

                        visibilityON();

                        //panel14.Visible = true;
                        panel22.Visible = true;
                        tinyMceEditor.Visible = true;
                        panel28.Visible = true;
                        panel24.Visible = true;
                        panel22.SendToBack();
                        tinyMceEditor.HtmlContent = "";
                        fileAddFLP.Controls.Clear();
                        noteFileUploads.Clear();
                    }
                }
                else
                {
                    if (onucchedList.data.total_records > 0)
                    {
                        int flag = 0;
                        onuchhedFLP.Visible = true;
                        onuchhedFLP.Controls.Clear();
                        noteHeaderPanel.Width = 990;
                        noteHeaderPanel.Height = 426;
                        var onuchhedNo = "0";
                        int totalOnuchhed = 0;
                        OnucchedListDataRecordDTO last = onucchedList.data.records.Last();
                        foreach (OnucchedListDataRecordDTO onucchedsingleListRec in onucchedList.data.records)
                        {
                            int[] sequence_onuchhed_id = onucchedsingleListRec.sequence_onucched_ids.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
                            int[] sequence_onuchhed_no = onucchedsingleListRec.onucched_no.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
                            totalOnuchhed = totalOnuchhed + sequence_onuchhed_no.Length;
                            var zip = sequence_onuchhed_id.Zip(sequence_onuchhed_no, (onuchhed_id, onuchhed_no) => new { onuchhed_id, onuchhed_no });
                            foreach (var z in zip)
                            {
                                flag++;
                                SingleOnucchedResponse singleOnucched = new SingleOnucchedResponse();
                                try
                                {
                                    singleOnucched = _singleOnucched.GetSingleOnucched(_dakuserparam, nothiListRecords.id, list.nothi_note_id, z.onuchhed_id);

                                }
                                catch
                                {
                                    continue;
                                }
                                if (singleOnucched.data.total_records > 0)
                                {
                                    var rec = singleOnucched.data.records;
                                    onuchhedNo = onucchedsingleListRec.onucched_no;
                                    lbNoteTotl1.Text = "নোটঃ " + list.note_status;
                                    lbNoteSubject.Text = list.note_subject_sub_text;
                                    lbNothiLastDate.Text = list.date;

                                    visibilityOFF();

                                    //onuchhedheaderPnl.Visible = true;
                                    //onuchhedFLP.Visible = true;
                                    //btnWriteOnuchhed.Visible = true;
                                    //btnSend.Visible = true;
                                    //panel14.Visible = false;
                                    panel22.Visible = false;
                                    tinyMceEditor.Visible = false;
                                    panel24.Visible = false;
                                    panel28.Visible = false;
                                    DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                                    var separateOnucched = UserControlFactory.Create<SeparateOnuchhed>();
                                    separateOnucched.office = onucchedsingleListRec.employee_name + " " + onucchedsingleListRec.created;

                                    if (rec[0].attachment.Count > 0)
                                    {
                                        separateOnucched.totalFileNo = rec[0].attachment.Count.ToString();
                                        foreach (AttachmentDTO attachment in rec[0].attachment)
                                        {
                                            separateOnucched.fileAddInFilePanel(attachment);

                                        }
                                    }
                                    else
                                    {
                                        separateOnucched.filePnaeloff();
                                    }

                                    separateOnucched.noteNo(lbNoteTotl1.Text.Substring(lbNoteTotl1.Text.IndexOf("টঃ") + 2), z.onuchhed_no.ToString());
                                    separateOnucched.createDate = onucchedsingleListRec.created;
                                    separateOnucched.onucchedId = z.onuchhed_id;
                                    separateOnucched.DeleteButtonClick += delegate (object sender1, EventArgs e1) { DeleteButton_Click(sender1.ToString(), e1, dakListUserParam, nothiListRecords, newnotedata); };
                                    separateOnucched.KhoshraButtonClick += delegate (object sender1, EventArgs e1) { KhoshraButton_Click(sender1.ToString(), e1); };
                                    separateOnucched.EditButtonClick += delegate (object sender1, EventArgs e1) { EditButton_Click(sender1 as OnuchhedSaveItemAction, e1); };
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

                                    if (totalOnuchhed == flag && onucchedsingleListRec.Equals(last))
                                    {
                                        separateOnucched.lastopenOnuchhed();
                                    }
                                    //onuchhedFLP.Controls.Add(separateOnucched);
                                    UIDesignCommonMethod.AddRowinTable(onuchhedFLP, separateOnucched);
                                    //if (list.can_revert == 1)
                                    //{
                                    //    checkSub = list.note_subject_sub_text;
                                    //    checkNoteId = list.nothi_note_id;
                                    //    btnCanRevert.Visible = true;
                                    //    btnWriteOnuchhed.Visible = false;
                                    //    btnSend.Visible = false;
                                    //    btnSave.Visible = false;
                                    //    btnSaveArrow.Visible = false;
                                    //    btnCancel.Visible = false;
                                    //}
                                    //else
                                    //{
                                    //    btnCanRevert.Visible = false;
                                    //}
                                }
                            }
                        }
                        //foreach (OnucchedListDataRecordDTO onucchedsingleListRec in onucchedList.data.records)
                        //{
                        //    flag++;
                        //    SingleOnucchedResponse singleOnucched = _singleOnucched.GetSingleOnucched(_dakuserparam, nothiListRecords.id, list.nothi_note_id, onucchedsingleListRec.id);
                        //    if (singleOnucched.data.total_records > 0)
                        //    {
                        //        var rec = singleOnucched.data.records;
                        //        onuchhedNo = onucchedsingleListRec.onucched_no;
                        //        lbNoteTotl1.Text = "নোটঃ " + list.note_status;
                        //        lbNoteSubject.Text = list.note_subject_sub_text;
                        //        lbNothiLastDate.Text = list.date;

                        //        btnSave.Visible = false;
                        //        btnSaveArrow.Visible = false;
                        //        btnCancel.Visible = false;

                        //        //onuchhedheaderPnl.Visible = true;
                        //        //onuchhedFLP.Visible = true;
                        //        btnWriteOnuchhed.Visible = true;
                        //        btnSend.Visible = true;
                        //        //panel14.Visible = false;
                        //        panel22.Visible = false;
                        //        tinyMceEditor.Visible = false;
                        //        panel24.Visible = false;
                        //        panel28.Visible = false;
                        //        DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                        //        var separateOnucched = UserControlFactory.Create<SeparateOnuchhed>();
                        //        separateOnucched.office = onucchedsingleListRec.employee_name + " " + onucchedsingleListRec.created;
                        //        separateOnucched.noteNo(lbNoteTotl1.Text.Substring(lbNoteTotl1.Text.IndexOf("টঃ") + 2), onucchedsingleListRec.onucched_no);
                        //        separateOnucched.createDate = onucchedsingleListRec.created;
                        //        separateOnucched.onucchedId = onucchedsingleListRec.id;
                        //        separateOnucched.DeleteButtonClick += delegate (object sender1, EventArgs e1) { DeleteButton_Click(sender1.ToString(), e1, dakListUserParam, nothiListRecords, newnotedata); };
                        //        try
                        //        {
                        //            separateOnucched.subjectBrowser = Encoding.UTF8.GetString(Convert.FromBase64String(rec[0].onucched.note_description));
                        //        }
                        //        catch
                        //        {

                        //        }
                        //        foreach (SingleOnucchedRecordSignatureDTO singleRecSignature in rec[0].signature)
                        //        {
                        //            separateOnucched.loadOnuchhedSignature(singleRecSignature);
                        //        }
                        //        if (onucchedList.data.total_records == flag)
                        //        {
                        //            separateOnucched.lastopenOnuchhed();
                        //        }
                        //        //onuchhedFLP.Controls.Add(separateOnucched);
                        //        UIDesignCommonMethod.AddRowinTable(onuchhedFLP, separateOnucched);
                        //        //if (list.can_revert == 1)
                        //        //{
                        //        //    checkSub = list.note_subject_sub_text;
                        //        //    checkNoteId = list.nothi_note_id;
                        //        //    btnCanRevert.Visible = true;
                        //        //    btnWriteOnuchhed.Visible = false;
                        //        //    btnSend.Visible = false;
                        //        //    btnSave.Visible = false;
                        //        //    btnSaveArrow.Visible = false;
                        //        //    btnCancel.Visible = false;
                        //        //}
                        //        //else
                        //        //{
                        //        //    btnCanRevert.Visible = false;
                        //        //}
                        //    }
                        //}
                        if (!InternetConnection.Check())
                        {
                            totalOnuchhed--;
                            List<OnuchhedSaveItemAction> onuchhedSaveItemActions = _onuchhedSaveItemAction.Table.Where(a => a.office_id == _dakuserparam.office_id && a.designation_id == _dakuserparam.designation_id).ToList();
                            if (onuchhedSaveItemActions != null && onuchhedSaveItemActions.Count > 0)
                            {

                                foreach (OnuchhedSaveItemAction onuchhedSaveItemAction in onuchhedSaveItemActions)
                                {
                                    NothiListRecordsDTO nothiListRecordsDTO = JsonConvert.DeserializeObject<NothiListRecordsDTO>(onuchhedSaveItemAction.nothiListRecordsDTOJson);
                                    NoteSaveDTO newnotedata1 = JsonConvert.DeserializeObject<NoteSaveDTO>(onuchhedSaveItemAction.newnotedataJson);
                                    //List<DakUploadedFileResponse> onuchhedSaveWithAttachments = JsonConvert.DeserializeObject<List<DakUploadedFileResponse>>(onuchhedSaveItemAction.onuchhedSaveWithAttachmentsJson);

                                    if (nothiListRecordsDTO.id == nothiListRecords.id && list.nothi_note_id == newnotedata1.note_id)
                                    {
                                        //int onucchedNo = Convert.ToInt32(onuchhedNo);
                                        if (onuchhedFLP.Controls.Count == 0)
                                        {
                                            totalOnuchhed = 0;
                                        }
                                        else
                                        {
                                            totalOnuchhed++;
                                        }
                                        //onuchhedNo = onucchedNo.ToString();
                                        DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                                        var separateOnucched = UserControlFactory.Create<SeparateOnuchhed>();
                                        List<DakUploadedFileResponse> onuchhedSaveWithAttachmentss = JsonConvert.DeserializeObject<List<DakUploadedFileResponse>>(onuchhedSaveItemAction.onuchhedSaveWithAttachmentsJson);
                                        if (onuchhedSaveWithAttachmentss.Count == 0)
                                        {
                                            separateOnucched.filePnaeloff();
                                        }
                                        onuchhedSaveWithAttachments.Clear();
                                        List<FileUploadAction> fileUploadActions = _fileUploadAction.Table.Where(a => a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id).ToList();
                                        if (fileUploadActions != null && fileUploadActions.Count > 0)
                                        {

                                            foreach (FileUploadAction fileUploadItemAction in fileUploadActions)
                                            {
                                                foreach (DakUploadedFileResponse dakUploadedFileResponses in onuchhedSaveWithAttachmentss)
                                                {
                                                    if (fileUploadItemAction.Id == dakUploadedFileResponses.data[0].id)
                                                    {
                                                        DakFileUploadParam dakFileUploadParam = JsonConvert.DeserializeObject<DakFileUploadParam>(fileUploadItemAction.dakFileUploadParamJson);
                                                        DakUploadedFileResponse dakUploadedFileResponse = new DakUploadedFileResponse();
                                                        dakUploadedFileResponse.data = new List<DakAttachmentDTO>();

                                                        DakAttachmentDTO dakAttachmentDTO = new DakAttachmentDTO();
                                                        dakAttachmentDTO.user_file_name = dakFileUploadParam.user_file_name;
                                                        dakAttachmentDTO.file_size_in_kb = dakFileUploadParam.file_size_in_kb;
                                                        dakAttachmentDTO.id = fileUploadItemAction.Id;

                                                        dakUploadedFileResponse.data.Add(dakAttachmentDTO);

                                                        onuchhedSaveWithAttachments.Add(dakUploadedFileResponse);
                                                    }
                                                }

                                            }
                                        }
                                        //var separateOnucched = UserControlFactory.Create<SeparateOnuchhed>();
                                        if (onuchhedSaveWithAttachments.Count > 0)
                                        {
                                            separateOnucched.totalFileNo = onuchhedSaveWithAttachments.Count.ToString();
                                            foreach (DakUploadedFileResponse dakUploadedFileResponse in onuchhedSaveWithAttachments)
                                            {
                                                AttachmentDTO attachment = new AttachmentDTO();
                                                attachment.user_file_name = dakUploadedFileResponse.data[0].user_file_name;
                                                attachment.file_size_in_kb = dakUploadedFileResponse.data[0].file_size_in_kb;
                                                attachment.download_url = "";
                                                attachment.url = "";
                                                separateOnucched.fileAddInFilePanel(attachment);

                                            }
                                            onuchhedSaveWithAttachments.Clear();
                                        }
                                        else
                                        {
                                            separateOnucched.filePnaeloff();
                                        }
                                        separateOnucched.office = dakListUserParam.officer_name + " " + "১১/১/২১ ৪:০১ PM";
                                        separateOnucched.noteNo(lbNoteTotl1.Text.Substring(lbNoteTotl1.Text.IndexOf("টঃ") + 2), totalOnuchhed.ToString());
                                        //separateOnucched.createDate = onucchedsingleListRec.created;
                                        separateOnucched.onucchedId = Convert.ToInt32(onuchhedSaveItemAction.Id);
                                        //separateOnucched.DeleteButtonClick += delegate (object sender1, EventArgs e1) { DeleteButton_Click(sender1.ToString(), e1, dakListUserParam, nothiListRecords, newnotedata); };
                                        try
                                        {
                                            separateOnucched.subjectBrowser = Encoding.UTF8.GetString(Convert.FromBase64String(onuchhedSaveItemAction.editorEncodedData));
                                        }
                                        catch
                                        {

                                        }
                                        separateOnucched.lastopenOnuchhed();
                                        separateOnucched.loadinLocal();
                                        //onuchhedFLP.Controls.Add(separateOnucched);
                                        UIDesignCommonMethod.AddRowinTable(onuchhedFLP, separateOnucched);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        noteHeaderPanel.Width = 990;
                        noteHeaderPanel.Height = 81;
                        lbNoteTotl1.Text = "নোটঃ " + list.note_status;
                        lbNoteSubject.Text = list.note_subject_sub_text;
                        lbNothiLastDate.Text = list.date;

                        onuchhedFLP.Visible = false;

                        lbNote.Visible = false;
                        pnlNoteKhoshra.Visible = false;
                        pnlNoteKhoshraWaiting.Visible = false;
                        pnlNotePotrojari.Visible = false;
                        pnlNoNote.Visible = true;

                        btnCanRevert.Visible = false;
                        btnWriteOnuchhed.Visible = false;
                        btnSend.Visible = false;

                        visibilityON();

                        //panel14.Visible = true;
                        panel22.Visible = true;
                        tinyMceEditor.Visible = true;
                        panel28.Visible = true;
                        panel24.Visible = true;
                        panel22.SendToBack();
                        tinyMceEditor.HtmlContent = "";
                        fileAddFLP.Controls.Clear();
                        noteFileUploads.Clear();


                    }
                }

                if (list.khoshra_potro > 0 || list.khoshra_waiting_for_approval > 0 || list.potrojari > 0 || list.nothivukto_potro > 0)
                {
                    pnlNoNote.Visible = false;
                    //lbNote.Visible = true;
                    if (list.khoshra_waiting_for_approval > 0)
                    {
                        pnlNoteKhoshraWaiting.Visible = true;
                        pnlNoteKhoshraWaiting.BringToFront();
                        lbNoteKhoshraWaiting.Text = string.Concat(list.khoshra_waiting_for_approval.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        pnlNoteKhoshraWaiting.Visible = false;
                    }
                    if (list.nothivukto_potro > 0)
                    {
                        pnlNoteNothivuktoPotro.Visible = true;
                        pnlNoteNothivuktoPotro.BringToFront();
                        lbNoteNothivuktoPotro.Text = string.Concat(list.nothivukto_potro.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        pnlNoteNothivuktoPotro.Visible = false;
                    }
                    //lbNote.Visible = true;
                    if (list.khoshra_potro > 0)
                    {
                        pnlNoteKhoshra.Visible = true;
                        //pnlNoteKhoshra.SendToBack();
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
                        pnlNotePotrojari.BringToFront();
                        lbNotePotrojari.Text = string.Concat(list.potrojari.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        pnlNotePotrojari.Visible = false;

                    }
                    //lbNote.Visible = true;
                }
                else
                {
                    pnlNoteKhoshraWaiting.Visible = false;
                    pnlNoteKhoshra.Visible = false;
                    pnlNotePotrojari.Visible = false;
                    pnlNoteNothivuktoPotro.Visible = false;
                    pnlNoNote.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message);
            }
        }
        public void loadNoteViewToNoPo(NoteView noteView)
        {
            NoteListDataRecordNoteDTO list = new NoteListDataRecordNoteDTO();
            list.nothi_note_id = noteView._nothiNoteID;
            list.note_status = string.Concat(noteView._totalNothi.ToString().Select(c => (char)('\u09E6' + c - '0')));
            list.note_subject_sub_text = noteView._noteSubject;
            list.date = noteView._nothiLastDate;
            list.khoshra_potro = Convert.ToInt32(noteView._khosraPotro);
            list.khoshra_waiting_for_approval = Convert.ToInt32(noteView._khoshraWaiting);
            list.potrojari = Convert.ToInt32(noteView._potrojari);
            list.nothivukto_potro = Convert.ToInt32(noteView.nothivukto);
            if (nothiListRecords.id > 0)
            {
                loadNotangsho_Potrangsho(list);
            }

        }

        public void loadNoteView(NoteView noteView)
        {
            //NoteAllListResponse allNoteList = _nothiNoteTalikaServices.GetNoteListAll(_dakuserparam, nothiListRecords.id);
            //var i = allNoteList.data.total_records;
            //noteView.totalNothi = i.ToString();

            lbNothiType.Text = "বাছাইকৃত নোট (১)";
            noteViewFLP.Controls.Clear();
            newNoteView = noteView;

            //noteViewFLP.Controls.Add(noteView);
            UIDesignCommonMethod.AddRowinTable(noteViewFLP, noteView);
            loadNoteViewToNoPo(noteView);

            noteView.CheckBoxClick += delegate (object sender, EventArgs e) { checkBox_Click(sender as NoteListDataRecordNoteDTO, e, newNoteView); };

            //return i;
        }
        private string checkSub;
        private int checkNoteId;
        NoteListDataRecordNoteDTO notelist = new NoteListDataRecordNoteDTO();
        private void checkBox_Click(NoteListDataRecordNoteDTO list, EventArgs e, NoteView noteView)
        {
            try
            {
                notelist = list;
                NoteIdfromNothiInboxNoteShomuho.Text = list.nothi_note_id.ToString();
                //NoteAllListResponse allNoteList = _nothiNoteTalikaServices.GetNoteListAll(_dakuserparam, nothiListRecords.id);
                OnucchedListResponse onucchedList = _onuchhedList.GetAllOnucchedList(_dakuserparam, nothiListRecords.id, list.nothi_note_id);
                if (onucchedList.data == null || onucchedList.data.records.Count == 0)
                {
                    if (!InternetConnection.Check())
                    {
                        var onuchhedNo = "0";
                        onuchhedFLP.Visible = true;
                        onuchhedFLP.Controls.Clear();

                        List<OnuchhedSaveItemAction> onuchhedSaveItemActions = _onuchhedSaveItemAction.Table.Where(a => a.office_id == _dakuserparam.office_id && a.designation_id == _dakuserparam.designation_id).ToList();
                        if (onuchhedSaveItemActions != null && onuchhedSaveItemActions.Count > 0)
                        {
                            int flag = 0;
                            foreach (OnuchhedSaveItemAction onuchhedSaveItemAction in onuchhedSaveItemActions)
                            {
                                flag++;
                                lbNoteTotl1.Text = "নোটঃ " + list.note_status;
                                lbNoteSubject.Text = list.note_subject_sub_text;
                                lbNothiLastDate.Text = list.date;

                                visibilityOFF();

                                //onuchhedheaderPnl.Visible = true;
                                //onuchhedFLP.Visible = true;
                                btnWriteOnuchhed.Visible = true;
                                btnSend.Visible = true;
                                //panel14.Visible = false;
                                panel22.Visible = false;
                                tinyMceEditor.Visible = false;
                                panel24.Visible = false;
                                panel28.Visible = false;

                                noteHeaderPanel.Width = 990;
                                noteHeaderPanel.Height = 426;

                                NothiListRecordsDTO nothiListRecordsDTO = JsonConvert.DeserializeObject<NothiListRecordsDTO>(onuchhedSaveItemAction.nothiListRecordsDTOJson);
                                NoteSaveDTO newnotedata1 = JsonConvert.DeserializeObject<NoteSaveDTO>(onuchhedSaveItemAction.newnotedataJson);
                                if (nothiListRecordsDTO.id == nothiListRecords.id && list.nothi_note_id == newnotedata1.note_id)
                                {
                                    int onucchedNo = Convert.ToInt32(onuchhedNo);
                                    if (onuchhedFLP.Controls.Count == 0)
                                    {
                                        onucchedNo = 0;
                                    }
                                    else
                                    {
                                        onucchedNo++;
                                    }
                                    onuchhedNo = onucchedNo.ToString();
                                    DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                                    var separateOnucched = UserControlFactory.Create<SeparateOnuchhed>();
                                    List<DakUploadedFileResponse> onuchhedSaveWithAttachmentss = JsonConvert.DeserializeObject<List<DakUploadedFileResponse>>(onuchhedSaveItemAction.onuchhedSaveWithAttachmentsJson);
                                    if (onuchhedSaveWithAttachmentss.Count == 0)
                                    {
                                        separateOnucched.filePnaeloff();
                                    }
                                    onuchhedSaveWithAttachments.Clear();
                                    List<FileUploadAction> fileUploadActions = _fileUploadAction.Table.Where(a => a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id).ToList();
                                    if (fileUploadActions != null && fileUploadActions.Count > 0)
                                    {

                                        foreach (FileUploadAction fileUploadItemAction in fileUploadActions)
                                        {
                                            foreach (DakUploadedFileResponse dakUploadedFileResponses in onuchhedSaveWithAttachmentss)
                                            {
                                                if (fileUploadItemAction.Id == dakUploadedFileResponses.data[0].id)
                                                {
                                                    DakFileUploadParam dakFileUploadParam = JsonConvert.DeserializeObject<DakFileUploadParam>(fileUploadItemAction.dakFileUploadParamJson);
                                                    DakUploadedFileResponse dakUploadedFileResponse = new DakUploadedFileResponse();
                                                    dakUploadedFileResponse.data = new List<DakAttachmentDTO>();

                                                    DakAttachmentDTO dakAttachmentDTO = new DakAttachmentDTO();
                                                    dakAttachmentDTO.user_file_name = dakFileUploadParam.user_file_name;
                                                    dakAttachmentDTO.file_size_in_kb = dakFileUploadParam.file_size_in_kb;
                                                    dakAttachmentDTO.id = fileUploadItemAction.Id;

                                                    dakUploadedFileResponse.data.Add(dakAttachmentDTO);

                                                    onuchhedSaveWithAttachments.Add(dakUploadedFileResponse);
                                                }
                                            }

                                        }
                                    }
                                    //var separateOnucched = UserControlFactory.Create<SeparateOnuchhed>();
                                    if (onuchhedSaveWithAttachments.Count > 0)
                                    {
                                        separateOnucched.totalFileNo = onuchhedSaveWithAttachments.Count.ToString();
                                        foreach (DakUploadedFileResponse dakUploadedFileResponse in onuchhedSaveWithAttachments)
                                        {
                                            AttachmentDTO attachment = new AttachmentDTO();
                                            attachment.user_file_name = dakUploadedFileResponse.data[0].user_file_name;
                                            attachment.file_size_in_kb = dakUploadedFileResponse.data[0].file_size_in_kb;
                                            attachment.download_url = "";
                                            attachment.url = "";
                                            separateOnucched.fileAddInFilePanel(attachment);

                                        }
                                        onuchhedSaveWithAttachments.Clear();
                                    }
                                    else
                                    {
                                        separateOnucched.filePnaeloff();
                                    }
                                    separateOnucched.office = dakListUserParam.officer_name + " " + "১১/১/২১ ৪:০১ PM";
                                    separateOnucched.noteNo(lbNoteTotl1.Text.Substring(lbNoteTotl1.Text.IndexOf("টঃ") + 2), onuchhedNo);
                                    //separateOnucched.createDate = onucchedsingleListRec.created;
                                    separateOnucched.onucchedId = Convert.ToInt32(onuchhedSaveItemAction.Id);
                                    //separateOnucched.DeleteButtonClick += delegate (object sender1, EventArgs e1) { DeleteButton_Click(sender1.ToString(), e1, dakListUserParam, nothiListRecords, newnotedata); };
                                    try
                                    {
                                        separateOnucched.subjectBrowser = Encoding.UTF8.GetString(Convert.FromBase64String(onuchhedSaveItemAction.editorEncodedData));
                                    }
                                    catch
                                    {

                                    }
                                    if (onuchhedSaveItemActions.Count == flag)
                                    {
                                        separateOnucched.lastopenOnuchhed();
                                    }
                                    separateOnucched.loadinLocal();
                                    //onuchhedFLP.Controls.Add(separateOnucched);
                                    UIDesignCommonMethod.AddRowinTable(onuchhedFLP, separateOnucched);
                                }
                            }
                        }
                        else
                        {
                            noteHeaderPanel.Width = 990;
                            noteHeaderPanel.Height = 81;
                            lbNoteTotl1.Text = "নোটঃ " + list.note_status;
                            lbNoteSubject.Text = list.note_subject_sub_text;
                            lbNothiLastDate.Text = list.date;

                            onuchhedFLP.Visible = false;

                            lbNote.Visible = false;
                            pnlNoteKhoshra.Visible = false;
                            pnlNoteKhoshraWaiting.Visible = false;
                            pnlNotePotrojari.Visible = false;
                            pnlNoNote.Visible = true;

                            btnCanRevert.Visible = false;
                            btnWriteOnuchhed.Visible = false;
                            btnSend.Visible = false;

                            visibilityON();

                            //panel14.Visible = true;
                            panel22.Visible = true;
                            tinyMceEditor.Visible = true;
                            panel28.Visible = true;
                            panel24.Visible = true;
                            panel22.SendToBack();
                            tinyMceEditor.HtmlContent = "";
                            fileAddFLP.Controls.Clear();
                            noteFileUploads.Clear();

                        }
                    }
                }
                else
                {
                    if (onucchedList.data.total_records > 0)
                    {
                        int flag = 0;
                        onuchhedFLP.Visible = true;
                        onuchhedFLP.Controls.Clear();
                        noteHeaderPanel.Width = 990;
                        noteHeaderPanel.Height = 426;
                        var onuchhedNo = "0";
                        int totalOnuchhed = 0;
                        var eachNothiId = nothiListRecords.id;
                        var nothiListUserParam = _userService.GetLocalDakUserParam();
                        string note_category = "all";
                        var nothiInboxNote = _nothiAllNote.GetNothiAllNote(nothiListUserParam, eachNothiId.ToString(), note_category);
                        if (nothiInboxNote.data.records.Count > 0)
                        {
                            foreach (NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO in nothiInboxNote.data.records)
                            {
                                if (nothiListInboxNoteRecordsDTO.note.nothi_note_id == list.nothi_note_id)
                                { _NoteAllListDataRecordDTO = nothiListInboxNoteRecordsDTO; }
                            }
                        }
                        if (_NoteAllListDataRecordDTO.note.can_revert == 1)
                        {
                            btnCanRevert.Visible = true;
                            checkSub = _NoteAllListDataRecordDTO.note.note_subject;
                            checkNoteId = _NoteAllListDataRecordDTO.note.nothi_note_id;
                        }
                        else { btnCanRevert.Visible = false; }
                        if (_NoteAllListDataRecordDTO.note.is_editable == 1)
                        {
                            if (_NoteAllListDataRecordDTO.note.can_revert == 1)
                            { btnWriteOnuchhed.Visible = false; btnSend.Visible = false; }
                            else { btnWriteOnuchhed.Visible = true; btnSend.Visible = true; }
                        }
                        else { btnWriteOnuchhed.Visible = false; btnSend.Visible = false; }
                        OnucchedListDataRecordDTO last = onucchedList.data.records.Last();
                        foreach (OnucchedListDataRecordDTO onucchedsingleListRec in onucchedList.data.records)
                        {
                            int[] sequence_onuchhed_id = onucchedsingleListRec.sequence_onucched_ids.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
                            int[] sequence_onuchhed_no = onucchedsingleListRec.onucched_no.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
                            totalOnuchhed = totalOnuchhed + sequence_onuchhed_no.Length;
                            var zip = sequence_onuchhed_id.Zip(sequence_onuchhed_no, (onuchhed_id, onuchhed_no) => new { onuchhed_id, onuchhed_no });
                            foreach (var z in zip)
                            {
                                flag++;
                                SingleOnucchedResponse singleOnucched = new SingleOnucchedResponse();
                                try
                                {
                                    singleOnucched = _singleOnucched.GetSingleOnucched(_dakuserparam, nothiListRecords.id, list.nothi_note_id, z.onuchhed_id);

                                }
                                catch
                                {
                                    continue;
                                }
                                if (singleOnucched.data.total_records > 0)
                                {
                                    var rec = singleOnucched.data.records;
                                    onuchhedNo = onucchedsingleListRec.onucched_no;
                                    lbNoteTotl1.Text = "নোটঃ " + list.note_status;
                                    lbNoteSubject.Text = list.note_subject_sub_text;
                                    lbNothiLastDate.Text = list.date;

                                    visibilityOFF();

                                    //onuchhedheaderPnl.Visible = true;
                                    //onuchhedFLP.Visible = true;
                                    //btnWriteOnuchhed.Visible = true;
                                    //btnSend.Visible = true;
                                    //panel14.Visible = false;
                                    panel22.Visible = false;
                                    tinyMceEditor.Visible = false;
                                    panel24.Visible = false;
                                    panel28.Visible = false;
                                    DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                                    var separateOnucched = UserControlFactory.Create<SeparateOnuchhed>();
                                    if (rec[0].attachment.Count > 0)
                                    {
                                        separateOnucched.totalFileNo = rec[0].attachment.Count.ToString();
                                        foreach (AttachmentDTO attachment in rec[0].attachment)
                                        {
                                            separateOnucched.fileAddInFilePanel(attachment);

                                        }
                                    }
                                    else
                                    {
                                        separateOnucched.filePnaeloff();
                                    }
                                    separateOnucched.office = onucchedsingleListRec.employee_name + " " + onucchedsingleListRec.created;
                                    separateOnucched.noteNo(lbNoteTotl1.Text.Substring(lbNoteTotl1.Text.IndexOf("টঃ") + 2), z.onuchhed_no.ToString());
                                    separateOnucched.createDate = onucchedsingleListRec.created;
                                    separateOnucched.onucchedId = z.onuchhed_id;
                                    separateOnucched.DeleteButtonClick += delegate (object sender1, EventArgs e1) { DeleteButton_Click(sender1.ToString(), e1, dakListUserParam, nothiListRecords, newnotedata); };
                                    separateOnucched.KhoshraButtonClick += delegate (object sender1, EventArgs e1) { KhoshraButton_Click(sender1.ToString(), e1); };
                                    separateOnucched.EditButtonClick += delegate (object sender1, EventArgs e1) { EditButton_Click(sender1 as OnuchhedSaveItemAction, e1); };
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

                                    if (totalOnuchhed == flag && onucchedsingleListRec.Equals(last))
                                    {
                                        separateOnucched.lastopenOnuchhed();
                                    }
                                    //onuchhedFLP.Controls.Add(separateOnucched);
                                    UIDesignCommonMethod.AddRowinTable(onuchhedFLP, separateOnucched);
                                    //if (list.can_revert == 1)
                                    //{
                                    //    checkSub = list.note_subject_sub_text;
                                    //    checkNoteId = list.nothi_note_id;
                                    //    btnCanRevert.Visible = true;
                                    //    btnWriteOnuchhed.Visible = false;
                                    //    btnSend.Visible = false;
                                    //    btnSave.Visible = false;
                                    //    btnSaveArrow.Visible = false;
                                    //    btnCancel.Visible = false;
                                    //}
                                    //else
                                    //{
                                    //    btnCanRevert.Visible = false;
                                    //}
                                }
                            }
                        }






                        if (!InternetConnection.Check())
                        {
                            totalOnuchhed--;
                            List<OnuchhedSaveItemAction> onuchhedSaveItemActions = _onuchhedSaveItemAction.Table.Where(a => a.office_id == _dakuserparam.office_id && a.designation_id == _dakuserparam.designation_id).ToList();
                            if (onuchhedSaveItemActions != null && onuchhedSaveItemActions.Count > 0)
                            {

                                foreach (OnuchhedSaveItemAction onuchhedSaveItemAction in onuchhedSaveItemActions)
                                {
                                    NothiListRecordsDTO nothiListRecordsDTO = JsonConvert.DeserializeObject<NothiListRecordsDTO>(onuchhedSaveItemAction.nothiListRecordsDTOJson);
                                    NoteSaveDTO newnotedata1 = JsonConvert.DeserializeObject<NoteSaveDTO>(onuchhedSaveItemAction.newnotedataJson);
                                    if (nothiListRecordsDTO.id == nothiListRecords.id && list.nothi_note_id == newnotedata1.note_id)
                                    {
                                        //int onucchedNo = Convert.ToInt32(onuchhedNo);
                                        if (onuchhedFLP.Controls.Count == 0)
                                        {
                                            totalOnuchhed = 0;
                                        }
                                        else
                                        {
                                            totalOnuchhed++;
                                        }
                                        //onuchhedNo = onucchedNo.ToString();
                                        DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                                        var separateOnucched = UserControlFactory.Create<SeparateOnuchhed>();
                                        List<DakUploadedFileResponse> onuchhedSaveWithAttachmentss = JsonConvert.DeserializeObject<List<DakUploadedFileResponse>>(onuchhedSaveItemAction.onuchhedSaveWithAttachmentsJson);
                                        if (onuchhedSaveWithAttachmentss.Count == 0)
                                        {
                                            separateOnucched.filePnaeloff();
                                        }
                                        onuchhedSaveWithAttachments.Clear();
                                        List<FileUploadAction> fileUploadActions = _fileUploadAction.Table.Where(a => a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id).ToList();
                                        if (fileUploadActions != null && fileUploadActions.Count > 0)
                                        {

                                            foreach (FileUploadAction fileUploadItemAction in fileUploadActions)
                                            {
                                                foreach (DakUploadedFileResponse dakUploadedFileResponses in onuchhedSaveWithAttachmentss)
                                                {
                                                    if (fileUploadItemAction.Id == dakUploadedFileResponses.data[0].id)
                                                    {
                                                        DakFileUploadParam dakFileUploadParam = JsonConvert.DeserializeObject<DakFileUploadParam>(fileUploadItemAction.dakFileUploadParamJson);
                                                        DakUploadedFileResponse dakUploadedFileResponse = new DakUploadedFileResponse();
                                                        dakUploadedFileResponse.data = new List<DakAttachmentDTO>();

                                                        DakAttachmentDTO dakAttachmentDTO = new DakAttachmentDTO();
                                                        dakAttachmentDTO.user_file_name = dakFileUploadParam.user_file_name;
                                                        dakAttachmentDTO.file_size_in_kb = dakFileUploadParam.file_size_in_kb;
                                                        dakAttachmentDTO.id = fileUploadItemAction.Id;

                                                        dakUploadedFileResponse.data.Add(dakAttachmentDTO);

                                                        onuchhedSaveWithAttachments.Add(dakUploadedFileResponse);
                                                    }
                                                }

                                            }
                                        }
                                        //var separateOnucched = UserControlFactory.Create<SeparateOnuchhed>();
                                        if (onuchhedSaveWithAttachments.Count > 0)
                                        {
                                            separateOnucched.totalFileNo = onuchhedSaveWithAttachments.Count.ToString();
                                            foreach (DakUploadedFileResponse dakUploadedFileResponse in onuchhedSaveWithAttachments)
                                            {
                                                AttachmentDTO attachment = new AttachmentDTO();
                                                attachment.user_file_name = dakUploadedFileResponse.data[0].user_file_name;
                                                attachment.file_size_in_kb = dakUploadedFileResponse.data[0].file_size_in_kb;
                                                attachment.download_url = "";
                                                attachment.url = "";
                                                separateOnucched.fileAddInFilePanel(attachment);

                                            }
                                            onuchhedSaveWithAttachments.Clear();
                                        }
                                        else
                                        {
                                            separateOnucched.filePnaeloff();
                                        }
                                        separateOnucched.office = dakListUserParam.officer_name + " " + "১১/১/২১ ৪:০১ PM";
                                        separateOnucched.noteNo(lbNoteTotl1.Text.Substring(lbNoteTotl1.Text.IndexOf("টঃ") + 2), totalOnuchhed.ToString());
                                        //separateOnucched.createDate = onucchedsingleListRec.created;
                                        separateOnucched.onucchedId = Convert.ToInt32(onuchhedSaveItemAction.Id);
                                        //separateOnucched.DeleteButtonClick += delegate (object sender1, EventArgs e1) { DeleteButton_Click(sender1.ToString(), e1, dakListUserParam, nothiListRecords, newnotedata); };
                                        try
                                        {
                                            separateOnucched.subjectBrowser = Encoding.UTF8.GetString(Convert.FromBase64String(onuchhedSaveItemAction.editorEncodedData));
                                        }
                                        catch
                                        {

                                        }
                                        separateOnucched.lastopenOnuchhed();
                                        separateOnucched.loadinLocal();
                                        //onuchhedFLP.Controls.Add(separateOnucched);
                                        UIDesignCommonMethod.AddRowinTable(onuchhedFLP, separateOnucched);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        noteHeaderPanel.Width = 990;
                        noteHeaderPanel.Height = 81;
                        lbNoteTotl1.Text = "নোটঃ " + list.note_status;
                        lbNoteSubject.Text = list.note_subject_sub_text;
                        lbNothiLastDate.Text = list.date;

                        onuchhedFLP.Visible = false;

                        lbNote.Visible = false;
                        pnlNoteKhoshra.Visible = false;
                        pnlNoteKhoshraWaiting.Visible = false;
                        pnlNotePotrojari.Visible = false;
                        pnlNoNote.Visible = true;

                        btnCanRevert.Visible = false;
                        btnWriteOnuchhed.Visible = false;
                        btnSend.Visible = false;

                        visibilityON();

                        //panel14.Visible = true;
                        panel22.Visible = true;
                        tinyMceEditor.Visible = true;
                        panel28.Visible = true;
                        panel24.Visible = true;
                        panel22.SendToBack();
                        tinyMceEditor.HtmlContent = "";
                        fileAddFLP.Controls.Clear();
                        noteFileUploads.Clear();


                    }
                }

                if (list.khoshra_potro > 0 || list.khoshra_waiting_for_approval > 0 || list.potrojari > 0 || list.nothivukto_potro > 0)
                {
                    pnlNoNote.Visible = false;
                    //lbNote.Visible = true;
                    if (list.khoshra_waiting_for_approval > 0)
                    {
                        pnlNoteKhoshraWaiting.Visible = true;
                        pnlNoteKhoshraWaiting.BringToFront();
                        lbNoteKhoshraWaiting.Text = string.Concat(list.khoshra_waiting_for_approval.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        pnlNoteKhoshraWaiting.Visible = false;
                    }
                    if (list.nothivukto_potro > 0)
                    {
                        pnlNoteNothivuktoPotro.Visible = true;
                        pnlNoteNothivuktoPotro.BringToFront();
                        lbNoteNothivuktoPotro.Text = string.Concat(list.nothivukto_potro.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        pnlNoteNothivuktoPotro.Visible = false;
                    }
                    //lbNote.Visible = true;
                    if (list.khoshra_potro > 0)
                    {
                        pnlNoteKhoshra.Visible = true;
                        //pnlNoteKhoshra.SendToBack();
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
                        pnlNotePotrojari.BringToFront();
                        lbNotePotrojari.Text = string.Concat(list.potrojari.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        pnlNotePotrojari.Visible = false;

                    }
                    //lbNote.Visible = true;
                }
                else
                {
                    pnlNoteKhoshraWaiting.Visible = false;
                    pnlNoteKhoshra.Visible = false;
                    pnlNotePotrojari.Visible = false;
                    pnlNoteNothivuktoPotro.Visible = false;
                    pnlNoNote.Visible = true;
                }

                //string str = list.note_status;
                //if (str == "System.Windows.Forms.CheckBox, CheckState: 0")
                //{
                //    NoteFullPanel.Hide();
                //    NoteFullPanel.Visible = false;
                //}
                //else
                //    NoteFullPanel.Visible = true;
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message);
            }

        }
        //private void checkBox_Click(NoteListDataRecordNoteDTO list, EventArgs e, NoteView noteView)
        //{
        //    try
        //    {
        //        notelist = list;
        //        NoteIdfromNothiInboxNoteShomuho.Text = list.nothi_note_id.ToString();
        //        //NoteAllListResponse allNoteList = _nothiNoteTalikaServices.GetNoteListAll(_dakuserparam, nothiListRecords.id);
        //        OnucchedListResponse onucchedList = _onuchhedList.GetAllOnucchedList(_dakuserparam, nothiListRecords.id, list.nothi_note_id);
        //        if (onucchedList.data == null)
        //        {
        //            if (!InternetConnection.Check())
        //            {
        //                var onuchhedNo = "0";
        //                onuchhedFLP.Visible = true;
        //                onuchhedFLP.Controls.Clear();

        //                List<OnuchhedSaveItemAction> onuchhedSaveItemActions = _onuchhedSaveItemAction.Table.Where(a => a.office_id == _dakuserparam.office_id && a.designation_id == _dakuserparam.designation_id).ToList();
        //                if (onuchhedSaveItemActions != null && onuchhedSaveItemActions.Count > 0)
        //                {
        //                    int flag = 0;
        //                    foreach (OnuchhedSaveItemAction onuchhedSaveItemAction in onuchhedSaveItemActions)
        //                    {
        //                        flag++;
        //                        lbNoteTotl1.Text = "নোটঃ " + list.note_status;
        //                        lbNoteSubject.Text = list.note_subject_sub_text;
        //                        lbNothiLastDate.Text = list.date;

        //                        btnSave.Visible = false;
        //                        btnSaveArrow.Visible = false;
        //                        btnCancel.Visible = false;

        //                        //onuchhedheaderPnl.Visible = true;
        //                        //onuchhedFLP.Visible = true;
        //                        btnWriteOnuchhed.Visible = true;
        //                        btnSend.Visible = true;
        //                        //panel14.Visible = false;
        //                        panel22.Visible = false;
        //                        tinyMceEditor.Visible = false;
        //                        panel24.Visible = false;
        //                        panel28.Visible = false;

        //                        noteHeaderPanel.Width = 990;
        //                        noteHeaderPanel.Height = 426;

        //                        NothiListRecordsDTO nothiListRecordsDTO = JsonConvert.DeserializeObject<NothiListRecordsDTO>(onuchhedSaveItemAction.nothiListRecordsDTOJson);
        //                        NoteSaveDTO newnotedata1 = JsonConvert.DeserializeObject<NoteSaveDTO>(onuchhedSaveItemAction.newnotedataJson);
        //                        if (nothiListRecordsDTO.id == nothiListRecords.id && list.nothi_note_id == newnotedata1.note_id)
        //                        {
        //                            int onucchedNo = Convert.ToInt32(onuchhedNo);
        //                            if (onuchhedFLP.Controls.Count == 0)
        //                            {
        //                                onucchedNo = 0;
        //                            }
        //                            else
        //                            {
        //                                onucchedNo++;
        //                            }
        //                            onuchhedNo = onucchedNo.ToString();
        //                            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
        //                            var separateOnucched = UserControlFactory.Create<SeparateOnuchhed>();

        //                            separateOnucched.office = dakListUserParam.officer_name + " " + "১১/১/২১ ৪:০১ PM";
        //                            separateOnucched.noteNo(lbNoteTotl1.Text.Substring(lbNoteTotl1.Text.IndexOf("টঃ") + 2), onuchhedNo);
        //                            //separateOnucched.createDate = onucchedsingleListRec.created;
        //                            separateOnucched.onucchedId = Convert.ToInt32(onuchhedSaveItemAction.Id);
        //                            //separateOnucched.DeleteButtonClick += delegate (object sender1, EventArgs e1) { DeleteButton_Click(sender1.ToString(), e1, dakListUserParam, nothiListRecords, newnotedata); };
        //                            try
        //                            {
        //                                separateOnucched.subjectBrowser = Encoding.UTF8.GetString(Convert.FromBase64String(onuchhedSaveItemAction.editorEncodedData));
        //                            }
        //                            catch
        //                            {

        //                            }
        //                            if (onuchhedSaveItemActions.Count == flag)
        //                            {
        //                                separateOnucched.lastopenOnuchhed();
        //                            }
        //                            separateOnucched.loadinLocal();
        //                            //onuchhedFLP.Controls.Add(separateOnucched);
        //                            UIDesignCommonMethod.AddRowinTable(onuchhedFLP, separateOnucched);
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    noteHeaderPanel.Width = 990;
        //                    noteHeaderPanel.Height = 426;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            if (onucchedList.data.total_records > 0)
        //            {
        //                int flag = 0;
        //                onuchhedFLP.Visible = true;
        //                onuchhedFLP.Controls.Clear();
        //                noteHeaderPanel.Width = 990;
        //                noteHeaderPanel.Height = 426;
        //                var onuchhedNo = "0";
        //                foreach (OnucchedListDataRecordDTO onucchedsingleListRec in onucchedList.data.records)
        //                {
        //                    flag++;
        //                    SingleOnucchedResponse singleOnucched = _singleOnucched.GetSingleOnucched(_dakuserparam, nothiListRecords.id, list.nothi_note_id, onucchedsingleListRec.id);
        //                    if (singleOnucched.data.total_records > 0)
        //                    {
        //                        var rec = singleOnucched.data.records;
        //                        onuchhedNo = onucchedsingleListRec.onucched_no;
        //                        lbNoteTotl1.Text = "নোটঃ " + list.note_status;
        //                        lbNoteSubject.Text = list.note_subject_sub_text;
        //                        lbNothiLastDate.Text = list.date;

        //                        btnSave.Visible = false;
        //                        btnSaveArrow.Visible = false;
        //                        btnCancel.Visible = false;

        //                        //onuchhedheaderPnl.Visible = true;
        //                        //onuchhedFLP.Visible = true;
        //                        btnWriteOnuchhed.Visible = true;
        //                        btnSend.Visible = true;
        //                        //panel14.Visible = false;
        //                        panel22.Visible = false;
        //                        tinyMceEditor.Visible = false;
        //                        panel24.Visible = false;
        //                        panel28.Visible = false;
        //                        DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
        //                        var separateOnucched = UserControlFactory.Create<SeparateOnuchhed>();
        //                        separateOnucched.office = onucchedsingleListRec.employee_name + " " + onucchedsingleListRec.created;
        //                        separateOnucched.noteNo(lbNoteTotl1.Text.Substring(lbNoteTotl1.Text.IndexOf("টঃ") + 2), onucchedsingleListRec.onucched_no);
        //                        separateOnucched.createDate = onucchedsingleListRec.created;
        //                        separateOnucched.onucchedId = onucchedsingleListRec.id;
        //                        separateOnucched.DeleteButtonClick += delegate (object sender1, EventArgs e1) { DeleteButton_Click(sender1.ToString(), e1, dakListUserParam, nothiListRecords, newnotedata); };
        //                        try
        //                        {
        //                            separateOnucched.subjectBrowser = Encoding.UTF8.GetString(Convert.FromBase64String(rec[0].onucched.note_description));
        //                        }
        //                        catch
        //                        {

        //                        }
        //                        foreach (SingleOnucchedRecordSignatureDTO singleRecSignature in rec[0].signature)
        //                        {
        //                            separateOnucched.loadOnuchhedSignature(singleRecSignature);
        //                        }
        //                        if (onucchedList.data.total_records == flag)
        //                        {
        //                            separateOnucched.lastopenOnuchhed();
        //                        }
        //                        //onuchhedFLP.Controls.Add(separateOnucched);
        //                        UIDesignCommonMethod.AddRowinTable(onuchhedFLP, separateOnucched);
        //                        //if (list.can_revert == 1)
        //                        //{
        //                        //    checkSub = list.note_subject_sub_text;
        //                        //    checkNoteId = list.nothi_note_id;
        //                        //    btnCanRevert.Visible = true;
        //                        //    btnWriteOnuchhed.Visible = false;
        //                        //    btnSend.Visible = false;
        //                        //    btnSave.Visible = false;
        //                        //    btnSaveArrow.Visible = false;
        //                        //    btnCancel.Visible = false;
        //                        //}
        //                        //else
        //                        //{
        //                        //    btnCanRevert.Visible = false;
        //                        //}
        //                    }
        //                }
        //                if (!InternetConnection.Check())
        //                {
        //                    List<OnuchhedSaveItemAction> onuchhedSaveItemActions = _onuchhedSaveItemAction.Table.Where(a => a.office_id == _dakuserparam.office_id && a.designation_id == _dakuserparam.designation_id).ToList();
        //                    if (onuchhedSaveItemActions != null && onuchhedSaveItemActions.Count > 0)
        //                    {

        //                        foreach (OnuchhedSaveItemAction onuchhedSaveItemAction in onuchhedSaveItemActions)
        //                        {
        //                            NothiListRecordsDTO nothiListRecordsDTO = JsonConvert.DeserializeObject<NothiListRecordsDTO>(onuchhedSaveItemAction.nothiListRecordsDTOJson);
        //                            NoteSaveDTO newnotedata1 = JsonConvert.DeserializeObject<NoteSaveDTO>(onuchhedSaveItemAction.newnotedataJson);
        //                            if (nothiListRecordsDTO.id == nothiListRecords.id && list.nothi_note_id == newnotedata1.note_id)
        //                            {
        //                                int onucchedNo = Convert.ToInt32(onuchhedNo);
        //                                if (onuchhedFLP.Controls.Count == 0)
        //                                {
        //                                    onucchedNo = 0;
        //                                }
        //                                else
        //                                {
        //                                    onucchedNo++;
        //                                }
        //                                onuchhedNo = onucchedNo.ToString();
        //                                DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
        //                                var separateOnucched = UserControlFactory.Create<SeparateOnuchhed>();

        //                                separateOnucched.office = dakListUserParam.officer_name + " " + "১১/১/২১ ৪:০১ PM";
        //                                separateOnucched.noteNo(lbNoteTotl1.Text.Substring(lbNoteTotl1.Text.IndexOf("টঃ") + 2), onuchhedNo);
        //                                //separateOnucched.createDate = onucchedsingleListRec.created;
        //                                separateOnucched.onucchedId = Convert.ToInt32(onuchhedSaveItemAction.Id);
        //                                //separateOnucched.DeleteButtonClick += delegate (object sender1, EventArgs e1) { DeleteButton_Click(sender1.ToString(), e1, dakListUserParam, nothiListRecords, newnotedata); };
        //                                try
        //                                {
        //                                    separateOnucched.subjectBrowser = Encoding.UTF8.GetString(Convert.FromBase64String(onuchhedSaveItemAction.editorEncodedData));
        //                                }
        //                                catch
        //                                {

        //                                }
        //                                separateOnucched.lastopenOnuchhed();
        //                                separateOnucched.loadinLocal();
        //                                //onuchhedFLP.Controls.Add(separateOnucched);
        //                                UIDesignCommonMethod.AddRowinTable(onuchhedFLP, separateOnucched);
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                noteHeaderPanel.Width = 990;
        //                noteHeaderPanel.Height = 81;
        //                lbNoteTotl1.Text = "নোটঃ " + list.note_status;
        //                lbNoteSubject.Text = list.note_subject_sub_text;
        //                lbNothiLastDate.Text = list.date;

        //                onuchhedFLP.Visible = false;

        //                lbNote.Visible = false;
        //                pnlNoteKhoshra.Visible = false;
        //                pnlNoteKhoshraWaiting.Visible = false;
        //                pnlNotePotrojari.Visible = false;
        //                pnlNoNote.Visible = true;

        //                btnCanRevert.Visible = false;
        //                btnWriteOnuchhed.Visible = false;
        //                btnSend.Visible = false;

        //                btnSave.Visible = true;
        //                btnSaveArrow.Visible = true;
        //                btnCancel.Visible = true;

        //                //panel14.Visible = true;
        //                panel22.Visible = true;
        //                tinyMceEditor.Visible = true;
        //                panel28.Visible = true;
        //                panel24.Visible = true;
        //                panel22.SendToBack();
        //                tinyMceEditor.HtmlContent = "";
        //                fileAddFLP.Controls.Clear();
        //                noteFileUploads.Clear();


        //            }
        //        }

        //        if (list.khoshra_potro > 0 || list.khoshra_waiting_for_approval > 0 || list.potrojari > 0 || list.nothivukto_potro > 0)
        //        {
        //            pnlNoNote.Visible = false;
        //            //lbNote.Visible = true;
        //            if (list.khoshra_waiting_for_approval > 0)
        //            {
        //                pnlNoteKhoshraWaiting.Visible = true;
        //                pnlNoteKhoshraWaiting.BringToFront();
        //                lbNoteKhoshraWaiting.Text = string.Concat(list.khoshra_waiting_for_approval.ToString().Select(c => (char)('\u09E6' + c - '0')));
        //            }
        //            else
        //            {
        //                pnlNoteKhoshraWaiting.Visible = false;
        //            }
        //            if (list.nothivukto_potro > 0)
        //            {
        //                pnlNoteNothivuktoPotro.Visible = true;
        //                pnlNoteNothivuktoPotro.BringToFront();
        //                lbNoteNothivuktoPotro.Text = string.Concat(list.nothivukto_potro.ToString().Select(c => (char)('\u09E6' + c - '0')));
        //            }
        //            else
        //            {
        //                pnlNoteNothivuktoPotro.Visible = false;
        //            }
        //            //lbNote.Visible = true;
        //            if (list.khoshra_potro > 0)
        //            {
        //                pnlNoteKhoshra.Visible = true;
        //                //pnlNoteKhoshra.SendToBack();
        //                lbNoteKhoshra.Text = string.Concat(list.khoshra_potro.ToString().Select(c => (char)('\u09E6' + c - '0')));
        //            }
        //            else
        //            {
        //                pnlNoteKhoshra.Visible = false;
        //            }
        //            lbNote.Visible = true;
        //            if (list.potrojari > 0)
        //            {
        //                pnlNotePotrojari.Visible = true;
        //                pnlNotePotrojari.BringToFront();
        //                lbNotePotrojari.Text = string.Concat(list.potrojari.ToString().Select(c => (char)('\u09E6' + c - '0')));
        //            }
        //            else
        //            {
        //                pnlNotePotrojari.Visible = false;

        //            }
        //            //lbNote.Visible = true;
        //        }
        //        else
        //        {
        //            pnlNoteKhoshraWaiting.Visible = false;
        //            pnlNoteKhoshra.Visible = false;
        //            pnlNotePotrojari.Visible = false;
        //            pnlNoteNothivuktoPotro.Visible = false;
        //            pnlNoNote.Visible = true;
        //        }

        //        //string str = list.note_status;
        //        //if (str == "System.Windows.Forms.CheckBox, CheckState: 0")
        //        //{
        //        //    NoteFullPanel.Hide();
        //        //    NoteFullPanel.Visible = false;
        //        //}
        //        //else
        //        //    NoteFullPanel.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
        //    }

        //}
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
                    int flag = 0;
                    onuchhedFLP.Visible = true;
                    onuchhedFLP.Controls.Clear();
                    noteHeaderPanel.Width = 990;
                    noteHeaderPanel.Height = 426;
                    foreach (OnucchedListDataRecordDTO onucchedsingleListRec in onucchedList.data.records)
                    {
                        flag++;
                        SingleOnucchedResponse singleOnucched = _singleOnucched.GetSingleOnucched(_dakuserparam, nothiListRecords.id, nothiListInboxNoteRecordsDTO.note.nothi_note_id, onucchedsingleListRec.id);
                        if (singleOnucched.data.total_records > 0)
                        {
                            var rec = singleOnucched.data.records;
                            //lbNoteTotl1.Text = "নোটঃ " + nothiListInboxNoteRecordsDTO.note.note_subject;
                            lbNoteSubject.Text = nothiListInboxNoteRecordsDTO.note.note_subject;
                            lbNothiLastDate.Text = nothiListInboxNoteRecordsDTO.to.issue_date;

                            visibilityOFF();

                            //onuchhedheaderPnl.Visible = true;
                            //onuchhedFLP.Visible = true;
                            btnWriteOnuchhed.Visible = true;
                            btnSend.Visible = true;
                            onucchedEditorPanel.Visible = false;
                            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                            var separateOnucched = UserControlFactory.Create<SeparateOnuchhed>();
                            if (rec[0].attachment.Count > 0)
                            {
                                separateOnucched.totalFileNo = rec[0].attachment.Count.ToString();
                                foreach (AttachmentDTO attachment in rec[0].attachment)
                                {
                                    separateOnucched.fileAddInFilePanel(attachment);

                                }
                            }
                            else
                            {
                                separateOnucched.filePnaeloff();
                            }
                            separateOnucched.office = onucchedsingleListRec.employee_name + " " + onucchedsingleListRec.created;
                            separateOnucched.noteNo(lbNoteTotl1.Text.Substring(lbNoteTotl1.Text.IndexOf("টঃ") + 2), onucchedsingleListRec.onucched_no);
                            separateOnucched.createDate = onucchedsingleListRec.created;
                            separateOnucched.onucchedId = onucchedsingleListRec.id;
                            separateOnucched.DeleteButtonClick += delegate (object sender1, EventArgs e1) { DeleteButton_Click(sender1.ToString(), e1, dakListUserParam, nothiListRecords, newnotedata); };
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
                            if (onucchedList.data.total_records == flag)
                            {
                                separateOnucched.lastopenOnuchhed();
                            }
                            onuchhedFLP.Controls.Add(separateOnucched);
                            UIDesignCommonMethod.AddRowinTable(onuchhedFLP, separateOnucched);
                            //if (nothiListInboxNoteRecordsDTO.note.can_revert == 1)
                            //{
                            //    checkSub = nothiListInboxNoteRecordsDTO.note.note_subject_sub_text;
                            //    checkNoteId = nothiListInboxNoteRecordsDTO.note.nothi_note_id;
                            //    btnCanRevert.Visible = true;
                            //    btnWriteOnuchhed.Visible = false;
                            //    btnSend.Visible = false;
                            //    btnSave.Visible = false;
                            //    btnSaveArrow.Visible = false;
                            //    btnCancel.Visible = false;
                            //}
                        }
                    }
                }
                else
                {
                    noteHeaderPanel.Width = 990;
                    noteHeaderPanel.Height = 81;
                    //lbNoteTotl1.Text = "নোটঃ " + nothiListInboxNoteRecordsDTO.note.note_subject;
                    lbNoteSubject.Text = nothiListInboxNoteRecordsDTO.note.note_subject;
                    lbNothiLastDate.Text = nothiListInboxNoteRecordsDTO.to.issue_date;

                    onuchhedFLP.Visible = false;

                    lbNote.Visible = false;
                    pnlNoteKhoshra.Visible = false;
                    pnlNoteKhoshraWaiting.Visible = false;
                    pnlNotePotrojari.Visible = false;
                    pnlNoNote.Visible = true;

                    btnCanRevert.Visible = false;
                    btnWriteOnuchhed.Visible = false;
                    btnSend.Visible = false;

                    visibilityON();

                    onucchedEditorPanel.Visible = true;
                    panel22.Visible = true;
                    tinyMceEditor.Visible = true;
                    panel28.Visible = true;
                    panel24.Visible = true;
                    panel22.SendToBack();
                    tinyMceEditor.HtmlContent = "";
                    fileAddFLP.Controls.Clear();
                    noteFileUploads.Clear();


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
            if (_checkBoxValue)
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
                    int flag = 0;
                    // onuchhedFLP.Visible = true;
                    onuchhedFLP.Controls.Clear();
                    noteHeaderPanel.Width = 990;
                    noteHeaderPanel.Height = 426;
                    foreach (OnucchedListDataRecordDTO onucchedsingleListRec in onucchedList.data.records)
                    {
                        flag++;
                        SingleOnucchedResponse singleOnucched = _singleOnucched.GetSingleOnucched(_dakuserparam, nothiListRecords.id, list.nothi_note_id, onucchedsingleListRec.id);
                        if (singleOnucched.data.total_records > 0)
                        {
                            var rec = singleOnucched.data.records;
                            lbNoteTotl1.Text = "নোটঃ " + list.note_status;
                            lbNoteSubject.Text = list.note_subject_sub_text;
                            lbNothiLastDate.Text = list.date;




                            //onuchhedheaderPnl.Visible = true;
                            //onuchhedFLP.Visible = true;
                            //btnWriteOnuchhed.Visible = true;
                            //btnSend.Visible = true;
                            //onucchedEditorPanel.Visible = false;
                            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                            var separateOnucched = UserControlFactory.Create<SeparateOnuchhed>();
                            if (rec[0].attachment.Count > 0)
                            {
                                separateOnucched.totalFileNo = rec[0].attachment.Count.ToString();
                                foreach (AttachmentDTO attachment in rec[0].attachment)
                                {
                                    separateOnucched.fileAddInFilePanel(attachment);

                                }
                            }
                            else
                            {
                                separateOnucched.filePnaeloff();
                            }
                            separateOnucched.office = onucchedsingleListRec.employee_name + " " + onucchedsingleListRec.created;
                            separateOnucched.noteNo(lbNoteTotl1.Text.Substring(lbNoteTotl1.Text.IndexOf("টঃ") + 2), onucchedsingleListRec.onucched_no);
                            separateOnucched.createDate = onucchedsingleListRec.created;
                            separateOnucched.onucchedId = onucchedsingleListRec.id;
                            separateOnucched.DeleteButtonClick += delegate (object sender1, EventArgs e1) { DeleteButton_Click(sender1.ToString(), e1, dakListUserParam, nothiListRecords, newnotedata); };
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
                            if (onucchedList.data.total_records == flag)
                            {
                                separateOnucched.lastopenOnuchhed();
                            }
                            //onuchhedFLP.Controls.Add(separateOnucched);
                            UIDesignCommonMethod.AddRowinTable(onuchhedFLP, separateOnucched);
                            //if (list.can_revert == 1)
                            //{
                            //    checkSub = list.note_subject_sub_text;
                            //    checkNoteId = list.nothi_note_id;
                            //    btnCanRevert.Visible = true;
                            //    btnWriteOnuchhed.Visible = false;
                            //    btnSend.Visible = false;
                            //    btnSave.Visible = false;
                            //    btnSaveArrow.Visible = false;
                            //    btnCancel.Visible = false;
                            //}
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

                    lbNote.Visible = true;
                    if (list.khoshra_potro > 0)
                    {
                        pnlNoteKhoshra.Visible = true;
                        lbNoteKhoshra.Text = string.Concat(list.khoshra_potro.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        pnlNoteKhoshra.Visible = false;
                    }
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
                    noteHeaderPanel.Width = 990;
                    noteHeaderPanel.Height = 81;
                    lbNoteTotl1.Text = "নোটঃ " + list.note_status;
                    lbNoteSubject.Text = list.note_subject_sub_text;
                    lbNothiLastDate.Text = list.date;

                    onuchhedFLP.Visible = false;

                    lbNote.Visible = false;
                    pnlNoteKhoshra.Visible = false;
                    pnlNoteKhoshraWaiting.Visible = false;
                    pnlNotePotrojari.Visible = false;
                    pnlNoNote.Visible = true;

                    btnCanRevert.Visible = false;
                    btnWriteOnuchhed.Visible = false;
                    btnSend.Visible = false;

                    visibilityON();

                    onucchedEditorPanel.Visible = true;
                    panel22.Visible = true;
                    tinyMceEditor.Visible = true;
                    panel28.Visible = true;
                    panel24.Visible = true;
                    panel22.SendToBack();
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
            set { _office = value; }
        }

        [Category("Custom Props")]
        public string nothiShakha
        {
            get { return _nothiShakha; }
            set { _nothiShakha = value; lbNoteShakha.Text = value + ";"; }
        }

        [Category("Custom Props")]
        public string nothiNo
        {
            get { return _nothiNo; }
            set { _nothiNo = value; lbNothiNo.Text = value + ";"; }
        }

        [Category("Custom Props")]
        public string nothiSubject
        {
            get { return _nothiSubject; }
            set { _nothiSubject = value; lbSubject.Text = value; }
        }
        private string _nothiLastDate;
        private string _noteSubject;
        private string _noteIdfromNothiInboxNoteShomuho;

        [Category("Custom Props")]
        public string noteIdfromNothiInboxNoteShomuho
        {
            get { return _noteIdfromNothiInboxNoteShomuho; }
            set
            {
                _noteIdfromNothiInboxNoteShomuho = value;
                NoteIdfromNothiInboxNoteShomuho.Text = value;
            }
        }
        [Category("Custom Props")]
        public string noteTotal
        {
            get { return _noteTotal; }
            set
            {
                _noteTotal = value;
                string vl = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0')));
                lbNoteTotl1.Text = "নোটঃ " + vl;
            }
        }
        public string totalRange
        {
            get { return _noteTotal; }
            set
            {
                _noteTotal = value;
                string vl = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0')));
                lbTotalRange.Text = vl + "-" + vl;
            }
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
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);
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
        void hideform_Shown(object sender, EventArgs e, Form form)
        {

            form.ShowDialog();

            (sender as Form).Hide();

            // var parent = form.Parent as Form; if (parent != null) { parent.Hide(); }
        }
        public Form AttachNothiTypeListControlToForm(Control control)
        {
            Form form = new Form();

            form.StartPosition = FormStartPosition.Manual;
            form.FormBorderStyle = FormBorderStyle.None;
            form.BackColor = Color.White;

            form.AutoSize = true;
            form.Location = new System.Drawing.Point(903, 0);
            control.Location = new System.Drawing.Point(0, 0);
            form.Size = control.Size;
            form.Controls.Add(control);
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            return form;
        }
        private void CalPopUpWindow(Form form)
        {
            Form hideform = new Form();


            hideform.BackColor = Color.Black;
            hideform.Size = Screen.PrimaryScreen.WorkingArea.Size;
            hideform.Opacity = .4;
            hideform.ShowInTaskbar = false;

            hideform.FormBorderStyle = FormBorderStyle.None;
            hideform.StartPosition = FormStartPosition.CenterScreen;
            hideform.Shown += delegate (object sr, EventArgs ev) { hideform_Shown(sr, ev, form); };
            hideform.ShowDialog();
        }
        private void btnAllNothi_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<DakNothiteUposthapitoForm>();
            form.Size = new System.Drawing.Size(form.Width, Screen.PrimaryScreen.WorkingArea.Height);
            form.StartPosition = FormStartPosition.Manual;
            form.FormBorderStyle = FormBorderStyle.None;
            form.BackColor = Color.White;
            form.Location = new System.Drawing.Point(Screen.PrimaryScreen.WorkingArea.Width - form.Width, 0);
            CalPopUpWindow(form);

        }

        private void fileUploadPanel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnNewNote_Click(object sender, EventArgs e)
        {
            NothiListRecordsDTO nothiNoteListRecords = nothiListRecords;
            var form = FormFactory.Create<CreateNewNotes>();

            form.SaveNewNoteButtonClick += delegate (object sender1, EventArgs e1) { SaveNewNote_ButtonClick(sender1, e1, nothiNoteListRecords); };
            //form.ShowDialog();

            CalPopUpWindow(form);

        }
        private void SaveNewNote_ButtonClick(object sender, EventArgs e, NothiListRecordsDTO nothiListRecordsDTO)
        {
            string noteSubject = sender.ToString();
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            var noteSave = _noteSave.GetNoteSave(dakListUserParam, nothiListRecordsDTO, noteSubject);

            if (noteSave.status == "success")
            {
                NoteSaveDTO notedata = noteSave.data;
                //this.Hide();

                var form = FormFactory.Create<Note>();
                _dakuserparam = _userService.GetLocalDakUserParam();

                NothiListRecordsDTO nothiListRecords = nothiListRecordsDTO;
                form.nothiNo = nothiListRecords.nothi_no;
                form.nothiShakha = nothiListRecords.office_unit_name + " " + _dakuserparam.office_label;
                form.nothiSubject = nothiListRecords.subject;
                form.noteSubject = sender.ToString();
                form.nothiLastDate = nothiListRecordsDTO.last_note_date;
                form.noteIdfromNothiInboxNoteShomuho = notedata.note_id.ToString();
                //var totalnothi = nothiListRecordsDTO.note_count; //nothiListInboxNoteRecordsDTO.note.note_no;
                //totalnothi.ToString();
                form.office = "( " + nothiListRecords.office_name + " " + nothiListRecordsDTO.last_note_date + ")";

                NoteView noteView = new NoteView();
                noteView.totalNothi = notedata.note_no.ToString();
                noteView.noteSubject = sender.ToString();
                noteView.nothiLastDate = nothiListRecordsDTO.last_note_date;
                noteView.officerInfo = _dakuserparam.officer + "," + nothiListRecords.office_designation_name + "," + nothiListRecords.office_unit_name + "," + _dakuserparam.office_label;
                noteView.checkBox = "1";
                noteView.nothiNoteID = notedata.note_id;

                //noteView.CheckBoxClick += delegate (object sender1, EventArgs e1) { checkBox_Click(sender1, e1,nothiListRecords); };
                form.loadNoteData(notedata);
                form.loadNothiInboxRecords(nothiListRecordsDTO);
                form.loadNoteView(noteView);
                form.noteTotal = notedata.note_no.ToString();


                form.TopMost = true;
                BeginInvoke((Action)(() => form.ShowDialog()));
                BeginInvoke((Action)(() => form.TopMost = false));
                form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };

            }
            else
            {
                ErrorMessage(noteSave.status + noteSave.message);
            }



        }
        public void loadCBXNothiType()
        {
            cbxNothiType.SelectedIndex = 2;

        }
        public void loadInboxCBXNothiType()
        {
            cbxNothiType.SelectedIndex = 1;

        }
        private void cbxNothiType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedItem = cbxNothiType.Items[cbxNothiType.SelectedIndex].ToString();
                if (selectedItem == "বাছাইকৃত নোট")
                {
                    newNoteView.CheckBoxClick += delegate (object sender1, EventArgs e1) { checkBox_Click(sender1 as NoteListDataRecordNoteDTO, e1, newNoteView); };
                    //newNoteView.CheckBoxClick += delegate (object sender1, EventArgs e1) { checkBox_Change(_NoteAllListDataRecordDTO, newNoteView, newNoteView._checkBoxValue); };
                    lbNothiType.Text = "বাছাইকৃত নোট (১)";
                    noteViewFLP.Controls.Clear();
                    //noteViewFLP.Controls.Add(newNoteView);
                    UIDesignCommonMethod.AddRowinTable(noteViewFLP, newNoteView);
                    //loadNoteViewToNoPo(newNoteView);
                    if (Convert.ToInt32(newNoteView.khosraPotro) > 0 || Convert.ToInt32(newNoteView.nothivukto) > 0 || Convert.ToInt32(newNoteView.khoshraWaiting) > 0 || Convert.ToInt32(newNoteView.potrojari) > 0)
                    {
                        pnlNoNote.Visible = false;
                        //lbNote.Visible = true;
                        if (Convert.ToInt32(newNoteView.khoshraWaiting) > 0)
                        {
                            pnlNoteKhoshraWaiting.Visible = true;
                            pnlNoteKhoshraWaiting.BringToFront();
                            lbNoteKhoshraWaiting.Text = string.Concat(newNoteView.khoshraWaiting.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        }
                        else
                        {
                            pnlNoteKhoshraWaiting.Visible = false;
                        }
                        if (Convert.ToInt32(newNoteView.nothivukto) > 0)
                        {
                            pnlNoteNothivuktoPotro.Visible = true;
                            pnlNoteNothivuktoPotro.BringToFront();
                            lbNoteNothivuktoPotro.Text = string.Concat(newNoteView.nothivukto.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        }
                        else
                        {
                            pnlNoteNothivuktoPotro.Visible = false;
                        }
                        //lbNote.Visible = true;
                        if (Convert.ToInt32(newNoteView.khosraPotro) > 0)
                        {
                            pnlNoteKhoshra.Visible = true;
                            //pnlNoteKhoshra.SendToBack();
                            lbNoteKhoshra.Text = string.Concat(newNoteView.khosraPotro.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        }
                        else
                        {
                            pnlNoteKhoshra.Visible = false;
                        }
                        lbNote.Visible = true;
                        if (Convert.ToInt32(newNoteView.potrojari) > 0)
                        {
                            pnlNotePotrojari.Visible = true;
                            pnlNotePotrojari.BringToFront();
                            lbNotePotrojari.Text = string.Concat(newNoteView.potrojari.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        }
                        else
                        {
                            pnlNotePotrojari.Visible = false;

                        }
                        //lbNote.Visible = true;
                    }
                    else
                    {
                        pnlNoteKhoshraWaiting.Visible = false;
                        pnlNoteKhoshra.Visible = false;
                        pnlNotePotrojari.Visible = false;
                        pnlNoteNothivuktoPotro.Visible = false;
                        pnlNoNote.Visible = true;
                    }
                }
                else if (selectedItem == "আগত নোট")
                {
                    noteViewFLP.Controls.Clear();
                    NoteListResponse inboxNoteList = _nothiNoteTalikaServices.GetNoteListInbox(_dakuserparam, nothiListRecords.id);
                    lbNothiType.Text = "আগত নোট (" + string.Concat(inboxNoteList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0'))) + ")";
                    if (inboxNoteList.data.records.Count > 0)
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

                            noteView.nothiNoteID = inboxList.note.nothi_note_id;
                            noteView.CheckBoxClick += delegate (object sender1, EventArgs e1) { checkBox_Click(sender1 as NoteListDataRecordNoteDTO, e1, newNoteView); };
                            //noteView.CheckBoxClick += delegate (object sender1, EventArgs e1) { checkBox_Click(sender1 as NoteListDataRecordNoteDTO, e1, newNoteView,noteView._checkBoxValue); };
                            noteView.nothiLastDate = inboxList.desk.issue_date;
                            noteView.nothivukto = inboxList.note.nothivukto_potro.ToString();
                            noteView.onucchedCount = inboxList.note.onucched_count.ToString();
                            noteView.potrojari = inboxList.note.potrojari.ToString();
                            noteView.approved = inboxList.note.approved_potro.ToString();
                            noteView.khoshraWaiting = inboxList.note.khoshra_waiting_for_approval.ToString();
                            noteView.khosraPotro = inboxList.note.khoshra_potro.ToString();
                            noteView.loadEyeIcon(inboxList.note.can_revert);
                            noteView.officerInfo = inboxList.desk.officer + "," + inboxList.desk.designation + "," + inboxList.desk.office_unit + "," + inboxList.desk.office;//nothiListRecords.office_name + "," + nothiListRecords.office_designation_name + "," + nothiListRecords.office_unit_name + "," + _dakuserparam.office_label;
                            //noteViewFLP.Controls.Add(noteView);
                            UIDesignCommonMethod.AddRowinTable(noteViewFLP, noteView);
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
                            noteView.nothiNoteID = sentList.note.nothi_note_id;
                            noteView.CheckBoxClick += delegate (object sender1, EventArgs e1) { checkBox_Click(sender1 as NoteListDataRecordNoteDTO, e1, newNoteView); };

                            //noteView.CheckBoxClick += delegate (object sender1, EventArgs e1) { checkBox_Click(sender1 as NoteListDataRecordNoteDTO, e1, newNoteView, noteView._checkBoxValue); };
                            noteView.nothiLastDate = sentList.desk.issue_date;
                            noteView.nothivukto = sentList.note.nothivukto_potro.ToString();
                            noteView.onucchedCount = sentList.note.onucched_count.ToString();
                            noteView.potrojari = sentList.note.potrojari.ToString();
                            noteView.approved = sentList.note.approved_potro.ToString();
                            noteView.khoshraWaiting = sentList.note.khoshra_waiting_for_approval.ToString();
                            noteView.khosraPotro = sentList.note.khoshra_potro.ToString();
                            noteView.loadEyeIcon(sentList.note.can_revert);
                            noteView.officerInfo = sentList.desk.officer + "," + sentList.desk.designation + "," + sentList.desk.office_unit + "," + sentList.desk.office;//nothiListRecords.office_name + "," + nothiListRecords.office_designation_name + "," + nothiListRecords.office_unit_name + "," + _dakuserparam.office_label;
                            //noteViewFLP.Controls.Add(noteView);
                            UIDesignCommonMethod.AddRowinTable(noteViewFLP, noteView);
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

                    if (!InternetConnection.Check())
                    {
                        DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
                        List<NoteSaveItemAction> noteSaveItemActions = _noteSaveItemAction.Table.Where(a => a.nothi_id == nothiListRecords.id && a.office_id == dakUserParam.office_id && a.designation_id == dakUserParam.designation_id).ToList();
                        if (noteSaveItemActions != null && noteSaveItemActions.Count > 0)
                        {
                            lbNothiType.Text = "সকল নোট (" + string.Concat(noteSaveItemActions.Count.ToString().Select(c => (char)('\u09E6' + c - '0'))) + ")";
                            foreach (NoteSaveItemAction noteSaveItemAction in noteSaveItemActions)
                            {
                                NoteView noteView = new NoteView();
                                noteView.totalNothi = noteSaveItemAction.Id.ToString();
                                noteView.noteSubject = noteSaveItemAction.noteSubject;
                                noteView.officerInfo = _dakuserparam.officer + "," + noteSaveItemAction.office_designation_name + "," + _dakuserparam.office_unit + "," + _dakuserparam.office_label;
                                //noteView.checkBox = "1";
                                noteView.nothiNoteID = Convert.ToInt32(noteSaveItemAction.Id);
                                //noteViewFLP.Controls.Add(noteView);
                                UIDesignCommonMethod.AddRowinTable(noteViewFLP, noteView);
                            }
                        }
                    }

                    NoteAllListResponse allNoteList = _nothiNoteTalikaServices.GetNoteListAll(_dakuserparam, nothiListRecords.id);

                    if (allNoteList.data.records.Count > 0)
                    {
                        lbNothiType.Text = "সকল নোট (" + string.Concat(allNoteList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0'))) + ")";
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
                                noteView.nothiNoteID = allList.note.nothi_note_id;
                                noteView.CheckBoxClick += delegate (object sender1, EventArgs e1) { checkBox_Click(sender1 as NoteListDataRecordNoteDTO, e1, newNoteView); };

                                //noteView.CheckBoxClick += delegate (object sender1, EventArgs e1) { checkBox_Click(sender1 as NoteListDataRecordNoteDTO, e1, newNoteView, noteView._checkBoxValue); };
                                noteView.nothiLastDate = allList.deskDtoList[0].issue_date;
                                noteView.nothivukto = allList.note.nothivukto_potro.ToString();
                                noteView.onucchedCount = allList.note.onucched_count.ToString();
                                noteView.potrojari = allList.note.potrojari.ToString();
                                noteView.approved = allList.note.approved_potro.ToString();
                                noteView.khoshraWaiting = allList.note.khoshra_waiting_for_approval.ToString();
                                noteView.khosraPotro = allList.note.khoshra_potro.ToString();
                                noteView.loadEyeIcon(allList.note.can_revert);
                                noteView.officerInfo = allList.deskDtoList[0].officer + "," + allList.deskDtoList[0].designation + "," + allList.deskDtoList[0].office_unit + "," + allList.deskDtoList[0].office;//nothiListRecords.office_name + "," + nothiListRecords.office_designation_name + "," + nothiListRecords.office_unit_name + "," + _dakuserparam.office_label;
                                //noteViewFLP.Controls.Add(noteView);
                                UIDesignCommonMethod.AddRowinTable(noteViewFLP, noteView);
                            }
                            else
                            {
                                NoteViewNotInCurrentDesk noteViewNotInCurrentDesk = new NoteViewNotInCurrentDesk();
                                noteViewNotInCurrentDesk.totalNothi = allList.note.note_no.ToString();
                                noteViewNotInCurrentDesk.noteSubject = allList.note.note_subject_sub_text;
                                //noteViewFLP.Controls.Add(noteViewNotInCurrentDesk);
                                UIDesignCommonMethod.AddRowinTable(noteViewFLP, noteViewNotInCurrentDesk);
                            }

                        }
                    }
                    else
                    {
                        noteViewFLP.Controls.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }
        }
        public void noteAllButtonClick(NothiListRecordsDTO nothiListRecords)
        {
            noteViewFLP.Controls.Clear();
            NoteAllListResponse allNoteList = _nothiNoteTalikaServices.GetNoteListAll(_dakuserparam, nothiListRecords.id);
            lbNothiType.Text = "সকল নোট (" + string.Concat(allNoteList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0'))) + ")";

            visibilityOFF();

            //onuchhedheaderPnl.Visible = true;
            //onuchhedFLP.Visible = true;
            //btnWriteOnuchhed.Visible = true;
            //btnSend.Visible = true;
            //panel14.Visible = false;
            panel22.Visible = false;
            tinyMceEditor.Visible = false;
            panel24.Visible = false;
            panel28.Visible = false;
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
                        noteView.nothiNoteID = allList.note.nothi_note_id;
                        noteView.CheckBoxClick += delegate (object sender1, EventArgs e1) { checkBox_Click(sender1 as NoteListDataRecordNoteDTO, e1, newNoteView); };

                        //noteView.CheckBoxClick += delegate (object sender1, EventArgs e1) { checkBox_Click(sender1 as NoteListDataRecordNoteDTO, e1, newNoteView, noteView._checkBoxValue); };
                        noteView.nothiLastDate = allList.deskDtoList[0].issue_date;
                        noteView.nothivukto = allList.note.nothivukto_potro.ToString();
                        noteView.onucchedCount = allList.note.onucched_count.ToString();
                        noteView.potrojari = allList.note.potrojari.ToString();
                        noteView.approved = allList.note.approved_potro.ToString();
                        noteView.khoshraWaiting = allList.note.khoshra_waiting_for_approval.ToString();
                        noteView.khosraPotro = allList.note.khoshra_potro.ToString();
                        noteView.loadEyeIcon(allList.note.can_revert);
                        noteView.officerInfo = allList.deskDtoList[0].officer + "," + allList.deskDtoList[0].designation + "," + allList.deskDtoList[0].office_unit + "," + allList.deskDtoList[0].office;//nothiListRecords.office_name + "," + nothiListRecords.office_designation_name + "," + nothiListRecords.office_unit_name + "," + _dakuserparam.office_label;
                        //noteViewFLP.Controls.Add(noteView);
                        UIDesignCommonMethod.AddRowinTable(noteViewFLP, noteView);
                    }
                    else
                    {
                        NoteViewNotInCurrentDesk noteViewNotInCurrentDesk = new NoteViewNotInCurrentDesk();
                        noteViewNotInCurrentDesk.totalNothi = allList.note.note_no.ToString();
                        noteViewNotInCurrentDesk.noteSubject = allList.note.note_subject_sub_text;
                        //noteViewFLP.Controls.Add(noteViewNotInCurrentDesk);
                        UIDesignCommonMethod.AddRowinTable(noteViewFLP, noteViewNotInCurrentDesk);
                    }

                }
            }
            else
            {
                noteViewFLP.Controls.Clear();
            }
        }

        DakFileUploadParam _dakFileUploadParam = new DakFileUploadParam();
        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", "JPG", "PNG", ".PNG", ".JPEG", "JPEG" };
        public static readonly List<string> PdfExtensions = new List<string> { ".PDF", "PDF", ".DOC", "DOC", ".DOCX", "DOCX", ".XLS", "XLS", ".XLSX", "XLSX", ".CSV", "CSV", ".MP3", "MP3", ".M4P", "M4P", ".MP4", "MP4", ".PPT", "PPT", ".PPTX", "PPTX" };



        private void fileUploadPanel_Paint_3(object sender, PaintEventArgs e)
        {

        }
        int fileuploadDoneFlag = 0;
        List<NoteFileUpload> noteFileUploads = new List<NoteFileUpload>();
        private void fileUploadPanel_Click_1(object sender, EventArgs e)
        {

        }


        List<DakUploadedFileResponse> onuchhedSaveWithAttachments = new List<DakUploadedFileResponse>();
        private void fileUploadButton_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            //opnfd.DefaultExt = "txt";
            opnfd.Filter = "Files (*.jpg;*.jpeg;*.PNG;*.PDF;*.Doc;*.Docx;*.XLS;*.XLSX;*.CSV;*.PPT;*.PPTX;*.MP3;*.M4p;*.MP4;)|*.jpg;*.jpeg;*.PNG;*.PDF;*.Doc;*.Docx;*.XLS;*.XLSX;*.CSV;*.PPT;*.PPTX;*.MP3;*.M4p;*.MP4;";
            //opnfd.Filter = "Pdf Files (*.PDF;)|*.PDF;";
            //opnfd.Filter = "Word Files ()|";
            //opnfd.Filter = "Excel Files ()|";
            //opnfd.Filter = "Excel Files ()|";
            //opnfd.Filter = "Audio Files ()|";
            //opnfd.Filter = "Video Files ()|";
            //opnfd.Filter = "ALL Files (*.*)|*.*";

            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                progressBar1.Visible = true;
                _dakFileUploadParam.user_file_name = new System.IO.FileInfo(opnfd.FileName).Name;
                _dakFileUploadParam.path = "Onucched";
                _dakFileUploadParam.model = "NothiOnucchedAttachments";

                //CreateProgressBar();

                //Read the contents of the file into a stream
                var fileStream = opnfd.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    Byte[] bytes = File.ReadAllBytes(opnfd.FileName);
                    _dakFileUploadParam.content = Convert.ToBase64String(bytes);
                }


                // _dakFileUploadParam.file_size_in_kb=opnfd.


                var size = new System.IO.FileInfo(opnfd.FileName).Length;
                if (size < 26214400)
                {
                    progressBar1.Value = 30;
                    double sizeKB = Convert.ToDouble(size) * 0.00097656;
                    _dakFileUploadParam.file_size_in_kb = sizeKB.ToString() + " KB";

                    DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();

                    DakUploadedFileResponse dakUploadedFileResponse = _onucchedFileUploadService.GetOnuchhedUploadedFile(dakListUserParam, _dakFileUploadParam);
                    if (!InternetConnection.Check() && dakUploadedFileResponse.status == "success" && dakUploadedFileResponse.message == "Local")
                    {
                        NoteFileUpload noteFileUpload = new NoteFileUpload();
                        if (ImageExtensions.Contains(new System.IO.FileInfo(opnfd.FileName).Extension.ToUpperInvariant()))
                        {
                            progressBar1.Value = 50;

                            noteFileUpload.imgSource = opnfd.FileName;
                            noteFileUpload.fileexension = _dakFileUploadParam.file_size_in_kb;
                            noteFileUpload.attachmentName = _dakFileUploadParam.user_file_name;
                            noteFileUpload.attachementId = dakUploadedFileResponse.data[0].id.ToString();
                            UIDesignCommonMethod.AddRowinTable(fileAddFLP, noteFileUpload);
                            //--fileAddFLP.Controls.Add(noteFileUpload);
                            //noteFileUploads.Add(noteFileUpload);


                        }
                        else if (PdfExtensions.Contains(new System.IO.FileInfo(opnfd.FileName).Extension.ToUpperInvariant()))
                        {
                            progressBar1.Value = 50;

                            //noteFileUpload.imgSource = "";
                            noteFileUpload.imageBoxOffFileShow("");
                            noteFileUpload.fileexension = _dakFileUploadParam.file_size_in_kb;
                            noteFileUpload.attachmentName = _dakFileUploadParam.user_file_name;
                            noteFileUpload.attachementId = dakUploadedFileResponse.data[0].id.ToString();
                            UIDesignCommonMethod.AddRowinTable(fileAddFLP, noteFileUpload);
                            //noteFileUploads.Add(noteFileUpload);

                        }
                        else
                        {
                            //NoteFileDelete noteFileDelete = new NoteFileDelete();
                            //noteFileDelete.attachmentName = _dakFileUploadParam.file_size_in_kb;
                            //noteFileDelete.fileexension = _dakFileUploadParam.user_file_name;
                            //UIDesignCommonMethod.AddRowinTable(fileAddFLP, noteFileDelete);
                            //--fileAddFLP.Controls.Add(noteFileDelete);
                            //dakUploadAttachmentTableRow.isAllowedforMulpotro = false;
                        }
                        //onuchhedSaveWithAttachments.Add(dakUploadedFileResponse);
                        progressBar1.Value = 70;
                    }
                    if (dakUploadedFileResponse.status == "success" && dakUploadedFileResponse.message != "Local")
                    {
                        fileuploadDoneFlag = 1;
                        if (dakUploadedFileResponse.data.Count > 0)
                        {
                            //attachmentListFlowLayoutPanel.Controls.Clear();
                            NoteFileUpload noteFileUpload = new NoteFileUpload();
                            if (ImageExtensions.Contains(new System.IO.FileInfo(opnfd.FileName).Extension.ToUpperInvariant()))
                            {
                                progressBar1.Value = 50;

                                noteFileUpload.imgSource = opnfd.FileName;
                                noteFileUpload.fileexension = dakUploadedFileResponse.data[0].file_size_in_kb;
                                noteFileUpload.attachmentName = dakUploadedFileResponse.data[0].user_file_name;
                                noteFileUpload.attachementId = dakUploadedFileResponse.data[0].id.ToString();
                                UIDesignCommonMethod.AddRowinTable(fileAddFLP, noteFileUpload);
                                //--fileAddFLP.Controls.Add(noteFileUpload);
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

                                onuchhedSaveWithAttachments.Add(dakUploadedFileResponse);
                            }
                            else if (PdfExtensions.Contains(new System.IO.FileInfo(opnfd.FileName).Extension.ToUpperInvariant()))
                            {
                                progressBar1.Value = 50;

                                //noteFileUpload.imgSource = "";
                                noteFileUpload.imageBoxOffFileShow(dakUploadedFileResponse.data[0].download_url);
                                noteFileUpload.fileexension = dakUploadedFileResponse.data[0].file_size_in_kb;
                                noteFileUpload.attachmentName = dakUploadedFileResponse.data[0].user_file_name;
                                noteFileUpload.attachementId = dakUploadedFileResponse.data[0].id.ToString();
                                UIDesignCommonMethod.AddRowinTable(fileAddFLP, noteFileUpload);
                                //--fileAddFLP.Controls.Add(noteFileUpload);
                                //noteFileUploads.Add(noteFileUpload);
                                onuchhedSaveWithAttachments.Add(dakUploadedFileResponse);
                            }
                            else
                            {
                                //NoteFileDelete noteFileDelete = new NoteFileDelete();
                                //noteFileDelete.attachmentName = dakUploadedFileResponse.data[0].user_file_name;
                                //noteFileDelete.fileexension = dakUploadedFileResponse.data[0].file_size_in_kb;
                                //UIDesignCommonMethod.AddRowinTable(fileAddFLP, noteFileDelete);
                                //--fileAddFLP.Controls.Add(noteFileDelete);
                                //dakUploadAttachmentTableRow.isAllowedforMulpotro = false;
                            }



                            //dakUploadAttachmentTableRow.OCRButtonClick += delegate (object oCRSender, EventArgs oCREvent) { OCRControl_ButtonClick(sender, e, dakUploadAttachmentTableRow.imageBase64String, dakUploadAttachmentTableRow._dakAttachment, dakUploadAttachmentTableRow.fileexension); };
                            //dakUploadAttachmentTableRow.DeleteButtonClick += delegate (object deleteSender, EventArgs deleteeVent) { DeleteControl_ButtonClick(sender, e, dakUploadAttachmentTableRow._dakAttachment); };


                            progressBar1.Value = 70;

                        }

                    }
                    progressBar1.Value = 100;
                    progressBar1.Visible = false;
                }
                else
                {
                    progressBar1.Visible = false;
                }


            }
        }

        private void panel40_Paint(object sender, PaintEventArgs e)
        {

        }

        public bool IskasaraDashBoard = false;
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (IskasaraDashBoard)
            {
                this.Close();
            }
            else
            {
                if (this.NoteBackButton != null)
                    this.NoteBackButton(sender, e);
                //foreach (Form f in Application.OpenForms)
                //{ BeginInvoke((Action)(() => f.Hide())); }
                //var form = FormFactory.Create<Nothi>();
                //form.TopMost = true;
                //BeginInvoke((Action)(() => form.ShowDialog()));
                //BeginInvoke((Action)(() => form.TopMost = false));
                //form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };
            }
        }
        public event EventHandler NoteBackButton;

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
        public void SuccessMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();

            successMessage.message = Message;
            successMessage.isSuccess = true;
            successMessage.Show();
            var t = Task.Delay(3000); //1 second/1000 ms
            t.Wait();
            successMessage.Hide();
        }
        public void ErrorMessage(string Message)
        {
            UIFormValidationAlertMessageForm successMessage = new UIFormValidationAlertMessageForm();
            successMessage.message = Message;
            successMessage.ShowDialog();

        }
        private void DeleteButton_Click(string onucchedId, EventArgs e, DakUserParam dakListUserParam, NothiListRecordsDTO nothiListRecords, NoteSaveDTO newnotedata)
        {
            newnotedata.note_id = Convert.ToInt32(NoteIdfromNothiInboxNoteShomuho.Text);
            var onucchedDelete = _onucchedDelete.GetNothiOnuchhedDelete(dakListUserParam, nothiListRecords, newnotedata, onucchedId);
            if (onucchedDelete.status == "success")
            {
                SuccessMessage(onucchedDelete.status + " " + onucchedDelete.message);
                loadAgainNote();
            }
            else
            {
                ErrorMessage(onucchedDelete.status + " " + onucchedDelete.message);
            }

        }
        public void loadAgainNote()
        {
            try
            {
                var list = notelist;
                NoteIdfromNothiInboxNoteShomuho.Text = list.nothi_note_id.ToString();
                //NoteAllListResponse allNoteList = _nothiNoteTalikaServices.GetNoteListAll(_dakuserparam, nothiListRecords.id);
                OnucchedListResponse onucchedList = _onuchhedList.GetAllOnucchedList(_dakuserparam, nothiListRecords.id, list.nothi_note_id);
                if (onucchedList == null)
                {
                    if (!InternetConnection.Check())
                    {
                        var onuchhedNo = "0";
                        onuchhedFLP.Visible = true;
                        onuchhedFLP.Controls.Clear();

                        List<OnuchhedSaveItemAction> onuchhedSaveItemActions = _onuchhedSaveItemAction.Table.Where(a => a.office_id == _dakuserparam.office_id && a.designation_id == _dakuserparam.designation_id).ToList();
                        if (onuchhedSaveItemActions != null && onuchhedSaveItemActions.Count > 0)
                        {
                            int flag = 0;
                            foreach (OnuchhedSaveItemAction onuchhedSaveItemAction in onuchhedSaveItemActions)
                            {
                                flag++;
                                lbNoteTotl1.Text = "নোটঃ " + list.note_status;
                                lbNoteSubject.Text = list.note_subject_sub_text;
                                lbNothiLastDate.Text = list.date;

                                visibilityOFF();

                                //onuchhedheaderPnl.Visible = true;
                                //onuchhedFLP.Visible = true;
                                btnWriteOnuchhed.Visible = true;
                                btnSend.Visible = true;
                                //panel14.Visible = false;
                                panel22.Visible = false;
                                tinyMceEditor.Visible = false;
                                panel24.Visible = false;
                                panel28.Visible = false;

                                noteHeaderPanel.Width = 990;
                                noteHeaderPanel.Height = 426;

                                NothiListRecordsDTO nothiListRecordsDTO = JsonConvert.DeserializeObject<NothiListRecordsDTO>(onuchhedSaveItemAction.nothiListRecordsDTOJson);
                                NoteSaveDTO newnotedata = JsonConvert.DeserializeObject<NoteSaveDTO>(onuchhedSaveItemAction.newnotedataJson);
                                if (nothiListRecordsDTO.id == nothiListRecords.id && list.nothi_note_id == newnotedata.note_id)
                                {
                                    int onucchedNo = Convert.ToInt32(onuchhedNo);
                                    if (onuchhedFLP.Controls.Count == 0)
                                    {
                                        onucchedNo = 0;
                                    }
                                    else
                                    {
                                        onucchedNo++;
                                    }
                                    onuchhedNo = onucchedNo.ToString();
                                    DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                                    var separateOnucched = UserControlFactory.Create<SeparateOnuchhed>();

                                    separateOnucched.office = dakListUserParam.officer_name + " " + "১১/১/২১ ৪:০১ PM";
                                    separateOnucched.noteNo(lbNoteTotl1.Text.Substring(lbNoteTotl1.Text.IndexOf("টঃ") + 2), onuchhedNo);
                                    //separateOnucched.createDate = onucchedsingleListRec.created;
                                    separateOnucched.onucchedId = Convert.ToInt32(onuchhedSaveItemAction.Id);
                                    //separateOnucched.DeleteButtonClick += delegate (object sender1, EventArgs e1) { DeleteButton_Click(sender1.ToString(), e1, dakListUserParam, nothiListRecords, newnotedata); };
                                    try
                                    {
                                        separateOnucched.subjectBrowser = Encoding.UTF8.GetString(Convert.FromBase64String(onuchhedSaveItemAction.editorEncodedData));
                                    }
                                    catch
                                    {

                                    }
                                    if (onuchhedSaveItemActions.Count == flag)
                                    {
                                        separateOnucched.lastopenOnuchhed();
                                    }
                                    separateOnucched.loadinLocal();
                                    //onuchhedFLP.Controls.Add(separateOnucched);
                                    UIDesignCommonMethod.AddRowinTable(onuchhedFLP, separateOnucched);
                                }
                            }
                        }
                        else
                        {
                            noteHeaderPanel.Width = 990;
                            noteHeaderPanel.Height = 426;
                        }
                    }
                }
                else
                {
                    if (onucchedList.data.total_records > 0)
                    {
                        int flag = 0;
                        onuchhedFLP.Visible = true;
                        onuchhedFLP.Controls.Clear();
                        noteHeaderPanel.Width = 990;
                        noteHeaderPanel.Height = 426;
                        var onuchhedNo = "0";
                        int totalOnuchhed = 0;
                        if (_NoteAllListDataRecordDTO.note.can_revert == 1)
                        {
                            btnCanRevert.Visible = true;
                            checkSub = _NoteAllListDataRecordDTO.note.note_subject;
                            checkNoteId = _NoteAllListDataRecordDTO.note.nothi_note_id;
                        }
                        else { btnCanRevert.Visible = false; }
                        if (_NoteAllListDataRecordDTO.note.is_editable == 1)
                        { btnWriteOnuchhed.Visible = true; btnSend.Visible = true; }
                        else { btnWriteOnuchhed.Visible = false; btnSend.Visible = false; }
                        OnucchedListDataRecordDTO last = onucchedList.data.records.Last();
                        foreach (OnucchedListDataRecordDTO onucchedsingleListRec in onucchedList.data.records)
                        {
                            int[] sequence_onuchhed_id = onucchedsingleListRec.sequence_onucched_ids.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
                            int[] sequence_onuchhed_no = onucchedsingleListRec.onucched_no.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
                            totalOnuchhed = totalOnuchhed + sequence_onuchhed_no.Length;
                            var zip = sequence_onuchhed_id.Zip(sequence_onuchhed_no, (onuchhed_id, onuchhed_no) => new { onuchhed_id, onuchhed_no });
                            foreach (var z in zip)
                            {
                                flag++;
                                SingleOnucchedResponse singleOnucched = new SingleOnucchedResponse();
                                try
                                {
                                    singleOnucched = _singleOnucched.GetSingleOnucched(_dakuserparam, nothiListRecords.id, list.nothi_note_id, z.onuchhed_id);

                                }
                                catch
                                {
                                    continue;
                                }
                                if (singleOnucched.data.total_records > 0)
                                {
                                    var rec = singleOnucched.data.records;
                                    onuchhedNo = onucchedsingleListRec.onucched_no;
                                    lbNoteTotl1.Text = "নোটঃ " + list.note_status;
                                    lbNoteSubject.Text = list.note_subject_sub_text;
                                    lbNothiLastDate.Text = list.date;

                                    visibilityOFF();

                                    //onuchhedheaderPnl.Visible = true;
                                    //onuchhedFLP.Visible = true;
                                    //btnWriteOnuchhed.Visible = true;
                                    //btnSend.Visible = true;
                                    //panel14.Visible = false;
                                    panel22.Visible = false;
                                    tinyMceEditor.Visible = false;
                                    panel24.Visible = false;
                                    panel28.Visible = false;
                                    DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                                    var separateOnucched = UserControlFactory.Create<SeparateOnuchhed>();
                                    if (rec[0].attachment.Count > 0)
                                    {
                                        separateOnucched.totalFileNo = rec[0].attachment.Count.ToString();
                                        foreach (AttachmentDTO attachment in rec[0].attachment)
                                        {
                                            separateOnucched.fileAddInFilePanel(attachment);

                                        }
                                    }
                                    else
                                    {
                                        separateOnucched.filePnaeloff();
                                    }
                                    separateOnucched.office = onucchedsingleListRec.employee_name + " " + onucchedsingleListRec.created;
                                    separateOnucched.noteNo(lbNoteTotl1.Text.Substring(lbNoteTotl1.Text.IndexOf("টঃ") + 2), z.onuchhed_no.ToString());
                                    separateOnucched.createDate = onucchedsingleListRec.created;
                                    separateOnucched.onucchedId = z.onuchhed_id;
                                    separateOnucched.DeleteButtonClick += delegate (object sender1, EventArgs e1) { DeleteButton_Click(sender1.ToString(), e1, dakListUserParam, nothiListRecords, newnotedata); };
                                    separateOnucched.KhoshraButtonClick += delegate (object sender1, EventArgs e1) { KhoshraButton_Click(sender1.ToString(), e1); };
                                    separateOnucched.EditButtonClick += delegate (object sender1, EventArgs e1) { EditButton_Click(sender1 as OnuchhedSaveItemAction, e1); };
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

                                    if (totalOnuchhed == flag && onucchedsingleListRec.Equals(last))
                                    {
                                        separateOnucched.lastopenOnuchhed();
                                    }
                                    //onuchhedFLP.Controls.Add(separateOnucched);
                                    UIDesignCommonMethod.AddRowinTable(onuchhedFLP, separateOnucched);
                                    //if (list.can_revert == 1)
                                    //{
                                    //    checkSub = list.note_subject_sub_text;
                                    //    checkNoteId = list.nothi_note_id;
                                    //    btnCanRevert.Visible = true;
                                    //    btnWriteOnuchhed.Visible = false;
                                    //    btnSend.Visible = false;
                                    //    btnSave.Visible = false;
                                    //    btnSaveArrow.Visible = false;
                                    //    btnCancel.Visible = false;
                                    //}
                                    //else
                                    //{
                                    //    btnCanRevert.Visible = false;
                                    //}
                                }
                            }
                        }






                        if (!InternetConnection.Check())
                        {
                            totalOnuchhed--;
                            List<OnuchhedSaveItemAction> onuchhedSaveItemActions = _onuchhedSaveItemAction.Table.Where(a => a.office_id == _dakuserparam.office_id && a.designation_id == _dakuserparam.designation_id).ToList();
                            if (onuchhedSaveItemActions != null && onuchhedSaveItemActions.Count > 0)
                            {

                                foreach (OnuchhedSaveItemAction onuchhedSaveItemAction in onuchhedSaveItemActions)
                                {
                                    NothiListRecordsDTO nothiListRecordsDTO = JsonConvert.DeserializeObject<NothiListRecordsDTO>(onuchhedSaveItemAction.nothiListRecordsDTOJson);
                                    NoteSaveDTO newnotedata1 = JsonConvert.DeserializeObject<NoteSaveDTO>(onuchhedSaveItemAction.newnotedataJson);
                                    if (nothiListRecordsDTO.id == nothiListRecords.id && list.nothi_note_id == newnotedata1.note_id)
                                    {
                                        //int onucchedNo = Convert.ToInt32(onuchhedNo);
                                        if (onuchhedFLP.Controls.Count == 0)
                                        {
                                            totalOnuchhed = 0;
                                        }
                                        else
                                        {
                                            totalOnuchhed++;
                                        }
                                        //onuchhedNo = onucchedNo.ToString();
                                        DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                                        var separateOnucched = UserControlFactory.Create<SeparateOnuchhed>();
                                        List<DakUploadedFileResponse> onuchhedSaveWithAttachmentss = JsonConvert.DeserializeObject<List<DakUploadedFileResponse>>(onuchhedSaveItemAction.onuchhedSaveWithAttachmentsJson);
                                        if (onuchhedSaveWithAttachmentss.Count == 0)
                                        {
                                            separateOnucched.filePnaeloff();
                                        }
                                        onuchhedSaveWithAttachments.Clear();
                                        List<FileUploadAction> fileUploadActions = _fileUploadAction.Table.Where(a => a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id).ToList();
                                        if (fileUploadActions != null && fileUploadActions.Count > 0)
                                        {

                                            foreach (FileUploadAction fileUploadItemAction in fileUploadActions)
                                            {
                                                foreach (DakUploadedFileResponse dakUploadedFileResponses in onuchhedSaveWithAttachmentss)
                                                {
                                                    if (fileUploadItemAction.Id == dakUploadedFileResponses.data[0].id)
                                                    {
                                                        DakFileUploadParam dakFileUploadParam = JsonConvert.DeserializeObject<DakFileUploadParam>(fileUploadItemAction.dakFileUploadParamJson);
                                                        DakUploadedFileResponse dakUploadedFileResponse = new DakUploadedFileResponse();
                                                        dakUploadedFileResponse.data = new List<DakAttachmentDTO>();

                                                        DakAttachmentDTO dakAttachmentDTO = new DakAttachmentDTO();
                                                        dakAttachmentDTO.user_file_name = dakFileUploadParam.user_file_name;
                                                        dakAttachmentDTO.file_size_in_kb = dakFileUploadParam.file_size_in_kb;
                                                        dakAttachmentDTO.id = fileUploadItemAction.Id;

                                                        dakUploadedFileResponse.data.Add(dakAttachmentDTO);

                                                        onuchhedSaveWithAttachments.Add(dakUploadedFileResponse);
                                                    }
                                                }

                                            }
                                        }
                                        //var separateOnucched = UserControlFactory.Create<SeparateOnuchhed>();
                                        if (onuchhedSaveWithAttachments.Count > 0)
                                        {
                                            separateOnucched.totalFileNo = onuchhedSaveWithAttachments.Count.ToString();
                                            foreach (DakUploadedFileResponse dakUploadedFileResponse in onuchhedSaveWithAttachments)
                                            {
                                                AttachmentDTO attachment = new AttachmentDTO();
                                                attachment.user_file_name = dakUploadedFileResponse.data[0].user_file_name;
                                                attachment.file_size_in_kb = dakUploadedFileResponse.data[0].file_size_in_kb;
                                                attachment.download_url = "";
                                                attachment.url = "";
                                                separateOnucched.fileAddInFilePanel(attachment);

                                            }
                                            onuchhedSaveWithAttachments.Clear();
                                        }
                                        else
                                        {
                                            separateOnucched.filePnaeloff();
                                        }
                                        separateOnucched.office = dakListUserParam.officer_name + " " + "১১/১/২১ ৪:০১ PM";
                                        separateOnucched.noteNo(lbNoteTotl1.Text.Substring(lbNoteTotl1.Text.IndexOf("টঃ") + 2), totalOnuchhed.ToString());
                                        //separateOnucched.createDate = onucchedsingleListRec.created;
                                        separateOnucched.onucchedId = Convert.ToInt32(onuchhedSaveItemAction.Id);
                                        //separateOnucched.DeleteButtonClick += delegate (object sender1, EventArgs e1) { DeleteButton_Click(sender1.ToString(), e1, dakListUserParam, nothiListRecords, newnotedata); };
                                        try
                                        {
                                            separateOnucched.subjectBrowser = Encoding.UTF8.GetString(Convert.FromBase64String(onuchhedSaveItemAction.editorEncodedData));
                                        }
                                        catch
                                        {

                                        }
                                        separateOnucched.lastopenOnuchhed();
                                        separateOnucched.loadinLocal();
                                        //onuchhedFLP.Controls.Add(separateOnucched);
                                        UIDesignCommonMethod.AddRowinTable(onuchhedFLP, separateOnucched);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        noteHeaderPanel.Width = 990;
                        noteHeaderPanel.Height = 81;
                        lbNoteTotl1.Text = "নোটঃ " + list.note_status;
                        lbNoteSubject.Text = list.note_subject_sub_text;
                        lbNothiLastDate.Text = list.date;

                        onuchhedFLP.Visible = false;

                        lbNote.Visible = false;
                        pnlNoteKhoshra.Visible = false;
                        pnlNoteKhoshraWaiting.Visible = false;
                        pnlNotePotrojari.Visible = false;
                        pnlNoNote.Visible = true;

                        btnCanRevert.Visible = false;
                        btnWriteOnuchhed.Visible = false;
                        btnSend.Visible = false;

                        visibilityON();

                        //panel14.Visible = true;
                        panel22.Visible = true;
                        tinyMceEditor.Visible = true;
                        panel28.Visible = true;
                        panel24.Visible = true;
                        panel22.SendToBack();
                        tinyMceEditor.HtmlContent = "";
                        fileAddFLP.Controls.Clear();
                        noteFileUploads.Clear();


                    }
                }

                if (list.khoshra_potro > 0 || list.khoshra_waiting_for_approval > 0 || list.potrojari > 0)
                {
                    pnlNoNote.Visible = false;
                    //lbNote.Visible = true;
                    if (list.khoshra_waiting_for_approval > 0)
                    {
                        pnlNoteKhoshraWaiting.Visible = true;
                        pnlNoteKhoshraWaiting.BringToFront();
                        lbNoteKhoshraWaiting.Text = string.Concat(list.khoshra_waiting_for_approval.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        pnlNoteKhoshraWaiting.Visible = false;
                    }

                    //lbNote.Visible = true;
                    if (list.khoshra_potro > 0)
                    {
                        pnlNoteKhoshra.Visible = true;
                        //pnlNoteKhoshra.SendToBack();
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
                        pnlNotePotrojari.BringToFront();
                        lbNotePotrojari.Text = string.Concat(list.potrojari.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        pnlNotePotrojari.Visible = false;

                    }
                    //lbNote.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message);
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!PnlSave.Visible)
            {
                PnlSave.Location = new System.Drawing.Point(pnlNoteList.Width + splitter1.Width + btnSave.Location.X,
                    panel2.Height + panel52.Height + panel15.Height + panel34.Height + noteTabpanel.Height + noteSubjectPanel.Height + panel59.Height + splitter3.Height + onucchedActionPanel.Height);
                //PnlSave.Anchor = AnchorStyles.None;
                PnlSave.Visible = true;
                PnlSave.BringToFront();
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
                PnlSave.Location = new System.Drawing.Point(pnlNoteList.Width + splitter1.Width + btnSave.Location.X,
                    panel2.Height + panel52.Height + panel15.Height + panel34.Height + noteTabpanel.Height + noteSubjectPanel.Height + panel59.Height + splitter3.Height + onucchedActionPanel.Height);
                //PnlSave.Anchor = AnchorStyles.None;
                PnlSave.Visible = true;
                PnlSave.BringToFront();
                //PnlSave.designationLinkText = _dakuserparam.designation_label + "," + _dakuserparam.unit_label + "," + _dakuserparam.office_label;
            }
            else
            {
                PnlSave.Visible = false;
            }
        }

        public string _saved_Onucched_Id;
        private void btnOnuchhedSave_Click(object sender, EventArgs e)
        {
            _saved_Onucched_Id = null;
            try
            {
                //onuchhedFLP.Controls.Clear();
                PnlSave.Visible = false;
                string onuchhedId = "0";
                if (updateOnuchhedId > 0)
                {
                    onuchhedId = updateOnuchhedId.ToString();
                    updateOnuchhedId = 0;
                }

                if (Convert.ToInt32(NoteIdfromNothiInboxNoteShomuho.Text) > 0)
                    newnotedata.note_id = Convert.ToInt32(NoteIdfromNothiInboxNoteShomuho.Text);
                //string editortext = tinyMceEditor.HtmlContent;
                string editortext = getparagraphtext(tinyMceEditor.HtmlContent);

                if (editortext != "")
                {
                    var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(editortext);
                    var encodedEditorText = System.Convert.ToBase64String(plainTextBytes);
                    //OnuchhedAdd onuchhed = new OnuchhedAdd();
                    //onuchhed.currentDate = DateTime.Now.ToString("dd");
                    //onuchhed.currentMonth = DateTime.Now.ToString("MM");
                    //onuchhed.currentYear = DateTime.Now.ToString("yyyy");
                    //onuchhed.noteOnuchhed = newNoteView.totalNothi;
                    //onuchhed.Onuchhed = onuchhedint.ToString();
                    //onuchhedint++;
                    //onuchhed.fileflag = 0;

                    //onuchhed.body = editortext;
                    int i = 1;
                    foreach (NoteFileUpload notefileupload in noteFileUploads)
                    {
                        FileAttachment fileattachment = new FileAttachment();
                        fileattachment.attachmentName = notefileupload.attachmentName;
                        fileattachment.attachmentSize = notefileupload.fileexension;
                        fileAttachments.Add(fileattachment);

                        //onuchhed.fileflag = 1;
                        //onuchhed.getAttachment(notefileupload); onuchhed.file = i; 
                        i++;
                    }
                    DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                    List<FileUploadAction> fileUploadActions = _fileUploadAction.Table.Where(a => a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id).ToList();
                    if (!InternetConnection.Check())
                    {
                        //onuchhedSaveWithAttachments.Clear();


                        if (fileUploadActions != null && fileUploadActions.Count > 0)
                        {
                            int countflag = fileAddFLP.Controls.Count;

                            for (int ij = 0; ij < fileUploadActions.Count; ij++)
                            {
                                if (countflag == fileUploadActions.Count)
                                {
                                    DakFileUploadParam dakFileUploadParam = JsonConvert.DeserializeObject<DakFileUploadParam>(fileUploadActions[ij].dakFileUploadParamJson);
                                    DakUploadedFileResponse dakUploadedFileResponse = new DakUploadedFileResponse();
                                    dakUploadedFileResponse.data = new List<DakAttachmentDTO>();

                                    DakAttachmentDTO dakAttachmentDTO = new DakAttachmentDTO();
                                    dakAttachmentDTO.user_file_name = dakFileUploadParam.user_file_name;
                                    dakAttachmentDTO.file_size_in_kb = dakFileUploadParam.file_size_in_kb;
                                    dakAttachmentDTO.id = fileUploadActions[ij].Id;

                                    dakUploadedFileResponse.data.Add(dakAttachmentDTO);

                                    onuchhedSaveWithAttachments.Add(dakUploadedFileResponse);
                                }
                                else if (ij < fileUploadActions.Count - countflag)
                                {
                                    continue;
                                }
                                else
                                {
                                    DakFileUploadParam dakFileUploadParam = JsonConvert.DeserializeObject<DakFileUploadParam>(fileUploadActions[ij].dakFileUploadParamJson);
                                    DakUploadedFileResponse dakUploadedFileResponse = new DakUploadedFileResponse();
                                    dakUploadedFileResponse.data = new List<DakAttachmentDTO>();

                                    DakAttachmentDTO dakAttachmentDTO = new DakAttachmentDTO();
                                    dakAttachmentDTO.user_file_name = dakFileUploadParam.user_file_name;
                                    dakAttachmentDTO.file_size_in_kb = dakFileUploadParam.file_size_in_kb;
                                    dakAttachmentDTO.id = fileUploadActions[ij].Id;

                                    dakUploadedFileResponse.data.Add(dakAttachmentDTO);

                                    onuchhedSaveWithAttachments.Add(dakUploadedFileResponse);
                                }
                            }
                        }
                    }
                    foreach (NoteFileUpload noteFileUpload in fileAddFLP.Controls)
                    {
                        foreach (DakUploadedFileResponse attachment in onuchhedSaveWithAttachments)
                        {
                            if (!InternetConnection.Check())
                            {
                                foreach (FileUploadAction a in fileUploadActions)
                                {
                                    if (a.Id == attachment.data[0].id && attachment.data[0].id == Convert.ToInt32(noteFileUpload.attachementId) && attachment.data[0].user_file_name != noteFileUpload.getNewAttachmentText())
                                    {
                                        attachment.data[0].user_file_name = noteFileUpload.getNewAttachmentText();

                                        DakFileUploadParam fileUpload = JsonConvert.DeserializeObject<DakFileUploadParam>(a.dakFileUploadParamJson);
                                        fileUpload.user_file_name = noteFileUpload.getNewAttachmentText();

                                        a.dakFileUploadParamJson = JsonConvert.SerializeObject(fileUpload);
                                        _fileUploadAction.Update(a);
                                    }
                                }
                            }
                            else
                            {
                                if (attachment.data[0].id == Convert.ToInt32(noteFileUpload.attachementId) && attachment.data[0].user_file_name != noteFileUpload.getNewAttachmentText())
                                {
                                    attachment.data[0].user_file_name = noteFileUpload.getNewAttachmentText();
                                }
                            }

                        }
                    }
                    var onucchedSave = _onucchedSave.GetNothiOnuchhedSave(onuchhedId, dakListUserParam, onuchhedSaveWithAttachments, nothiListRecords, newnotedata, encodedEditorText);
                    OnucchedListResponse onucchedList = _onuchhedList.GetAllOnucchedList(_dakuserparam, nothiListRecords.id, newnotedata.note_id);
                    if (onucchedSave.status == "success" && onucchedSave.message == "Local" && onucchedList.data == null || onucchedList.data.records.Count == 0)
                    {
                        onuchhedSaveWithAttachments.Clear();
                        if (!InternetConnection.Check())
                        {
                            List<OnuchhedSaveItemAction> onuchhedSaveItemActions = _onuchhedSaveItemAction.Table.Where(a => a.office_id == _dakuserparam.office_id && a.designation_id == _dakuserparam.designation_id).ToList();
                            if (onuchhedSaveItemActions != null && onuchhedSaveItemActions.Count > 0)
                            {
                                int flag = 0;
                                onuchhedFLP.Visible = true;
                                onuchhedFLP.Controls.Clear();

                                var onuchhedNo = "0";
                                foreach (OnuchhedSaveItemAction onuchhedSaveItemAction in onuchhedSaveItemActions)
                                {
                                    flag++;
                                    visibilityOFF();

                                    //onuchhedheaderPnl.Visible = true;
                                    //onuchhedFLP.Visible = true;
                                    btnWriteOnuchhed.Visible = true;
                                    btnSend.Visible = true;
                                    //panel14.Visible = false;
                                    panel22.Visible = false;
                                    tinyMceEditor.Visible = false;
                                    panel24.Visible = false;
                                    panel28.Visible = false;

                                    noteHeaderPanel.Width = 990;
                                    noteHeaderPanel.Height = 426;

                                    NothiListRecordsDTO nothiListRecordsDTO = JsonConvert.DeserializeObject<NothiListRecordsDTO>(onuchhedSaveItemAction.nothiListRecordsDTOJson);
                                    NoteSaveDTO newnotedata1 = JsonConvert.DeserializeObject<NoteSaveDTO>(onuchhedSaveItemAction.newnotedataJson);
                                    if (nothiListRecordsDTO.id == nothiListRecords.id && newnotedata.note_id == newnotedata1.note_id)
                                    {
                                        int onucchedNo = Convert.ToInt32(onuchhedNo);
                                        if (onuchhedFLP.Controls.Count == 0)
                                        {
                                            onucchedNo = 0;
                                        }
                                        else
                                        {
                                            onucchedNo++;
                                        }
                                        onuchhedNo = onucchedNo.ToString();
                                        //DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                                        var separateOnucched = UserControlFactory.Create<SeparateOnuchhed>();
                                        List<DakUploadedFileResponse> onuchhedSaveWithAttachmentss = JsonConvert.DeserializeObject<List<DakUploadedFileResponse>>(onuchhedSaveItemAction.onuchhedSaveWithAttachmentsJson);
                                        if (onuchhedSaveWithAttachmentss.Count == 0)
                                        {
                                            separateOnucched.filePnaeloff();
                                        }
                                        List<FileUploadAction> fileUploadActions1 = _fileUploadAction.Table.Where(a => a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id).ToList();
                                        if (fileUploadActions1 != null && fileUploadActions1.Count > 0)
                                        {

                                            foreach (FileUploadAction fileUploadItemAction in fileUploadActions1)
                                            {
                                                foreach (DakUploadedFileResponse dakUploadedFileResponses in onuchhedSaveWithAttachmentss)
                                                {
                                                    if (fileUploadItemAction.Id == dakUploadedFileResponses.data[0].id)
                                                    {
                                                        DakFileUploadParam dakFileUploadParam = JsonConvert.DeserializeObject<DakFileUploadParam>(fileUploadItemAction.dakFileUploadParamJson);
                                                        DakUploadedFileResponse dakUploadedFileResponse = new DakUploadedFileResponse();
                                                        dakUploadedFileResponse.data = new List<DakAttachmentDTO>();

                                                        DakAttachmentDTO dakAttachmentDTO = new DakAttachmentDTO();
                                                        dakAttachmentDTO.user_file_name = dakFileUploadParam.user_file_name;
                                                        dakAttachmentDTO.file_size_in_kb = dakFileUploadParam.file_size_in_kb;
                                                        dakAttachmentDTO.id = fileUploadItemAction.Id;

                                                        dakUploadedFileResponse.data.Add(dakAttachmentDTO);

                                                        onuchhedSaveWithAttachments.Add(dakUploadedFileResponse);
                                                    }
                                                }

                                            }
                                        }
                                        //var separateOnucched = UserControlFactory.Create<SeparateOnuchhed>();
                                        if (onuchhedSaveWithAttachments.Count > 0)
                                        {
                                            separateOnucched.totalFileNo = onuchhedSaveWithAttachments.Count.ToString();
                                            foreach (DakUploadedFileResponse dakUploadedFileResponse in onuchhedSaveWithAttachments)
                                            {
                                                AttachmentDTO attachment = new AttachmentDTO();
                                                attachment.user_file_name = dakUploadedFileResponse.data[0].user_file_name;
                                                attachment.file_size_in_kb = dakUploadedFileResponse.data[0].file_size_in_kb;
                                                attachment.download_url = "";
                                                attachment.url = "";
                                                separateOnucched.fileAddInFilePanel(attachment);

                                            }
                                            onuchhedSaveWithAttachments.Clear();
                                        }
                                        else
                                        {
                                            separateOnucched.filePnaeloff();
                                        }
                                        separateOnucched.office = dakListUserParam.officer_name + " " + "১১/১/২১ ৪:০১ PM";
                                        separateOnucched.noteNo(lbNoteTotl1.Text.Substring(lbNoteTotl1.Text.IndexOf("টঃ") + 2), onuchhedNo);
                                        //separateOnucched.createDate = onucchedsingleListRec.created;
                                        separateOnucched.onucchedId = Convert.ToInt32(onuchhedSaveItemAction.Id);
                                        //separateOnucched.DeleteButtonClick += delegate (object sender1, EventArgs e1) { DeleteButton_Click(sender1.ToString(), e1, dakListUserParam, nothiListRecords, newnotedata); };
                                        try
                                        {
                                            separateOnucched.subjectBrowser = Encoding.UTF8.GetString(Convert.FromBase64String(onuchhedSaveItemAction.editorEncodedData));
                                        }
                                        catch
                                        {

                                        }
                                        if (onuchhedSaveItemActions.Count == flag)
                                        {
                                            separateOnucched.lastopenOnuchhed();
                                        }
                                        separateOnucched.loadinLocal();
                                        //onuchhedFLP.Controls.Add(separateOnucched);
                                        UIDesignCommonMethod.AddRowinTable(onuchhedFLP, separateOnucched);
                                    }
                                }
                            }
                            else
                            {
                                noteHeaderPanel.Width = 990;
                                noteHeaderPanel.Height = 426;
                            }
                        }
                    }
                    else
                    {
                        if (onucchedSave.status == "success")
                        {
                            if (InternetConnection.Check())
                                _saved_Onucched_Id = onucchedSave.data.id;
                            onuchhedSaveWithAttachments.Clear();
                            //onuchhedheaderPnl.Visible = true;
                            //onuchhedFLP.Visible = true;

                            //onuchhed.onucchedId = onucchedSave.data.id;
                            ////panel22.Visible = false;
                            //tinyMceEditor.Visible = false;
                            //PnlSave.Visible = false;
                            //panel24.Visible = false;
                            //panel28.Visible = false;

                            //btnCancel.Visible = false;
                            //btnSave.Visible = false;
                            //btnSaveArrow.Visible = false;

                            //btnWriteOnuchhed.Visible = true;
                            //btnSend.Visible = true;
                            //tinyMceEditor.HtmlContent = "";
                            //onuchhedFLP.Controls.Add(onuchhed);
                            //fileAddFLP.Controls.Clear();
                            //noteFileUploads.Clear();

                            if (onucchedList.data.total_records > 0)
                            {
                                int flag = 0;
                                onuchhedFLP.Visible = true;
                                onuchhedFLP.Controls.Clear();
                                noteHeaderPanel.Width = 990;
                                noteHeaderPanel.Height = 426;
                                var onuchhedNo = "0";
                                int totalOnuchhed = 0;
                                if (_NoteAllListDataRecordDTO.note.can_revert == 1)
                                {
                                    btnCanRevert.Visible = true;
                                    checkSub = _NoteAllListDataRecordDTO.note.note_subject;
                                    checkNoteId = _NoteAllListDataRecordDTO.note.nothi_note_id;
                                }
                                else { btnCanRevert.Visible = false; }
                                if (_NoteAllListDataRecordDTO.note.is_editable == 1)
                                { btnWriteOnuchhed.Visible = true; btnSend.Visible = true; }
                                else { btnWriteOnuchhed.Visible = false; btnSend.Visible = false; }
                                OnucchedListDataRecordDTO last = onucchedList.data.records.Last();
                                foreach (OnucchedListDataRecordDTO onucchedsingleListRec in onucchedList.data.records)
                                {
                                    int[] sequence_onuchhed_id = onucchedsingleListRec.sequence_onucched_ids.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
                                    int[] sequence_onuchhed_no = onucchedsingleListRec.onucched_no.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
                                    totalOnuchhed = totalOnuchhed + sequence_onuchhed_no.Length;
                                    var zip = sequence_onuchhed_id.Zip(sequence_onuchhed_no, (onuchhed_id, onuchhed_no) => new { onuchhed_id, onuchhed_no });
                                    foreach (var z in zip)
                                    {
                                        flag++;
                                        SingleOnucchedResponse singleOnucched = new SingleOnucchedResponse();
                                        try
                                        {
                                            singleOnucched = _singleOnucched.GetSingleOnucched(_dakuserparam, nothiListRecords.id, newnotedata.note_id, z.onuchhed_id);

                                        }
                                        catch
                                        {
                                            continue;
                                        }
                                        if (singleOnucched.data.total_records > 0)
                                        {
                                            var rec = singleOnucched.data.records;

                                            visibilityOFF();

                                            //onuchhedheaderPnl.Visible = true;
                                            //onuchhedFLP.Visible = true;
                                            //btnWriteOnuchhed.Visible = true;
                                            //btnSend.Visible = true;
                                            //panel14.Visible = false;
                                            panel22.Visible = false;
                                            tinyMceEditor.Visible = false;
                                            panel24.Visible = false;
                                            panel28.Visible = false;
                                            //DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                                            var separateOnucched = UserControlFactory.Create<SeparateOnuchhed>();
                                            if (rec[0].attachment.Count > 0)
                                            {
                                                separateOnucched.totalFileNo = rec[0].attachment.Count.ToString();
                                                foreach (AttachmentDTO attachment in rec[0].attachment)
                                                {
                                                    separateOnucched.fileAddInFilePanel(attachment);

                                                }
                                            }
                                            else
                                            {
                                                separateOnucched.filePnaeloff();
                                            }
                                            separateOnucched.office = onucchedsingleListRec.employee_name + " " + onucchedsingleListRec.created;
                                            separateOnucched.noteNo(lbNoteTotl1.Text.Substring(lbNoteTotl1.Text.IndexOf("টঃ") + 2), z.onuchhed_no.ToString());
                                            separateOnucched.createDate = onucchedsingleListRec.created;
                                            separateOnucched.onucchedId = z.onuchhed_id;
                                            separateOnucched.DeleteButtonClick += delegate (object sender1, EventArgs e1) { DeleteButton_Click(sender1.ToString(), e1, dakListUserParam, nothiListRecords, newnotedata); };
                                            separateOnucched.KhoshraButtonClick += delegate (object sender1, EventArgs e1) { KhoshraButton_Click(sender1.ToString(), e1); };
                                            separateOnucched.EditButtonClick += delegate (object sender1, EventArgs e1) { EditButton_Click(sender1 as OnuchhedSaveItemAction, e1); };
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

                                            if (totalOnuchhed == flag && onucchedsingleListRec.Equals(last))
                                            {
                                                separateOnucched.lastopenOnuchhed();
                                            }
                                            //onuchhedFLP.Controls.Add(separateOnucched);
                                            UIDesignCommonMethod.AddRowinTable(onuchhedFLP, separateOnucched);
                                            //if (list.can_revert == 1)
                                            //{
                                            //    checkSub = list.note_subject_sub_text;
                                            //    checkNoteId = list.nothi_note_id;
                                            //    btnCanRevert.Visible = true;
                                            //    btnWriteOnuchhed.Visible = false;
                                            //    btnSend.Visible = false;
                                            //    btnSave.Visible = false;
                                            //    btnSaveArrow.Visible = false;
                                            //    btnCancel.Visible = false;
                                            //}
                                            //else
                                            //{
                                            //    btnCanRevert.Visible = false;
                                            //}
                                        }
                                    }
                                }
                                //foreach (OnucchedListDataRecordDTO onucchedsingleListRec in onucchedList.data.records)
                                //{
                                //    flag++;
                                //    SingleOnucchedResponse singleOnucched = _singleOnucched.GetSingleOnucched(_dakuserparam, nothiListRecords.id, newnotedata.note_id, onucchedsingleListRec.id);
                                //    if (singleOnucched.data.total_records > 0)
                                //    {
                                //        var rec = singleOnucched.data.records;
                                //        onuchhedNo = onucchedsingleListRec.onucched_no;
                                //        btnSave.Visible = false;
                                //        btnSaveArrow.Visible = false;
                                //        btnCancel.Visible = false;

                                //        //onuchhedheaderPnl.Visible = true;
                                //        //onuchhedFLP.Visible = true;
                                //        btnWriteOnuchhed.Visible = true;
                                //        btnSend.Visible = true;
                                //        //panel14.Visible = false;
                                //        panel22.Visible = false;
                                //        tinyMceEditor.Visible = false;
                                //        panel24.Visible = false;
                                //        panel28.Visible = false;

                                //        var separateOnucched = UserControlFactory.Create<SeparateOnuchhed>();
                                //        separateOnucched.office = onucchedsingleListRec.employee_name + " " + onucchedsingleListRec.created;
                                //        separateOnucched.noteNo(lbNoteTotl1.Text.Substring(lbNoteTotl1.Text.IndexOf("টঃ") + 2), onucchedsingleListRec.onucched_no);
                                //        separateOnucched.createDate = onucchedsingleListRec.created;
                                //        separateOnucched.onucchedId = onucchedsingleListRec.id;
                                //        separateOnucched.DeleteButtonClick += delegate (object sender1, EventArgs e1) { DeleteButton_Click(sender1.ToString(), e1, dakListUserParam, nothiListRecords, newnotedata); };
                                //        try
                                //        {
                                //            separateOnucched.subjectBrowser = Encoding.UTF8.GetString(Convert.FromBase64String(rec[0].onucched.note_description));
                                //        }
                                //        catch
                                //        {

                                //        }
                                //        foreach (SingleOnucchedRecordSignatureDTO singleRecSignature in rec[0].signature)
                                //        {
                                //            separateOnucched.loadOnuchhedSignature(singleRecSignature);
                                //        }
                                //        if (onucchedList.data.total_records == flag)
                                //        {
                                //            separateOnucched.lastopenOnuchhed();
                                //        }
                                //        //onuchhedFLP.Controls.Add(separateOnucched);
                                //        UIDesignCommonMethod.AddRowinTable(onuchhedFLP, separateOnucched);

                                //    }
                                //}

                                if (!InternetConnection.Check())
                                {
                                    totalOnuchhed--;
                                    List<OnuchhedSaveItemAction> onuchhedSaveItemActions = _onuchhedSaveItemAction.Table.Where(a => a.office_id == _dakuserparam.office_id && a.designation_id == _dakuserparam.designation_id).ToList();

                                    if (onuchhedSaveItemActions != null && onuchhedSaveItemActions.Count > 0)
                                    {
                                        foreach (OnuchhedSaveItemAction onuchhedSaveItemAction in onuchhedSaveItemActions)
                                        {
                                            NothiListRecordsDTO nothiListRecordsDTO = JsonConvert.DeserializeObject<NothiListRecordsDTO>(onuchhedSaveItemAction.nothiListRecordsDTOJson);
                                            NoteSaveDTO newnotedata1 = JsonConvert.DeserializeObject<NoteSaveDTO>(onuchhedSaveItemAction.newnotedataJson);
                                            if (nothiListRecordsDTO.id == nothiListRecords.id && newnotedata.note_id == newnotedata1.note_id)
                                            {
                                                int onucchedNo = Convert.ToInt32(onuchhedNo);

                                                if (onuchhedFLP.Controls.Count == 0)
                                                {
                                                    totalOnuchhed = 0;
                                                }
                                                else
                                                {
                                                    totalOnuchhed++;
                                                }
                                                onuchhedNo = onucchedNo.ToString();
                                                //DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                                                var separateOnucched = UserControlFactory.Create<SeparateOnuchhed>();
                                                List<DakUploadedFileResponse> onuchhedSaveWithAttachmentss = JsonConvert.DeserializeObject<List<DakUploadedFileResponse>>(onuchhedSaveItemAction.onuchhedSaveWithAttachmentsJson);
                                                if (onuchhedSaveWithAttachmentss.Count == 0)
                                                {
                                                    separateOnucched.filePnaeloff();
                                                }
                                                List<FileUploadAction> fileUploadActions1 = _fileUploadAction.Table.Where(a => a.office_id == dakListUserParam.office_id && a.designation_id == dakListUserParam.designation_id).ToList();
                                                if (fileUploadActions1 != null && fileUploadActions1.Count > 0)
                                                {

                                                    foreach (FileUploadAction fileUploadItemAction in fileUploadActions1)
                                                    {
                                                        foreach (DakUploadedFileResponse dakUploadedFileResponses in onuchhedSaveWithAttachmentss)
                                                        {
                                                            if (fileUploadItemAction.Id == dakUploadedFileResponses.data[0].id)
                                                            {
                                                                DakFileUploadParam dakFileUploadParam = JsonConvert.DeserializeObject<DakFileUploadParam>(fileUploadItemAction.dakFileUploadParamJson);
                                                                DakUploadedFileResponse dakUploadedFileResponse = new DakUploadedFileResponse();
                                                                dakUploadedFileResponse.data = new List<DakAttachmentDTO>();

                                                                DakAttachmentDTO dakAttachmentDTO = new DakAttachmentDTO();
                                                                dakAttachmentDTO.user_file_name = dakFileUploadParam.user_file_name;
                                                                dakAttachmentDTO.file_size_in_kb = dakFileUploadParam.file_size_in_kb;
                                                                dakAttachmentDTO.id = fileUploadItemAction.Id;

                                                                dakUploadedFileResponse.data.Add(dakAttachmentDTO);

                                                                onuchhedSaveWithAttachments.Add(dakUploadedFileResponse);
                                                            }
                                                        }

                                                    }
                                                }
                                                //var separateOnucched = UserControlFactory.Create<SeparateOnuchhed>();
                                                if (onuchhedSaveWithAttachments.Count > 0)
                                                {
                                                    separateOnucched.totalFileNo = onuchhedSaveWithAttachments.Count.ToString();
                                                    foreach (DakUploadedFileResponse dakUploadedFileResponse in onuchhedSaveWithAttachments)
                                                    {
                                                        AttachmentDTO attachment = new AttachmentDTO();
                                                        attachment.user_file_name = dakUploadedFileResponse.data[0].user_file_name;
                                                        attachment.file_size_in_kb = dakUploadedFileResponse.data[0].file_size_in_kb;
                                                        attachment.download_url = "";
                                                        attachment.url = "";
                                                        separateOnucched.fileAddInFilePanel(attachment);

                                                    }
                                                    onuchhedSaveWithAttachments.Clear();
                                                }
                                                else
                                                {
                                                    separateOnucched.filePnaeloff();
                                                }
                                                separateOnucched.office = dakListUserParam.officer_name + " " + "১১/১/২১ ৪:০১ PM";
                                                separateOnucched.noteNo(lbNoteTotl1.Text.Substring(lbNoteTotl1.Text.IndexOf("টঃ") + 2), totalOnuchhed.ToString());
                                                //separateOnucched.createDate = onucchedsingleListRec.created;
                                                separateOnucched.onucchedId = Convert.ToInt32(onuchhedSaveItemAction.Id);
                                                //separateOnucched.DeleteButtonClick += delegate (object sender1, EventArgs e1) { DeleteButton_Click(sender1.ToString(), e1, dakListUserParam, nothiListRecords, newnotedata); };
                                                try
                                                {
                                                    separateOnucched.subjectBrowser = Encoding.UTF8.GetString(Convert.FromBase64String(onuchhedSaveItemAction.editorEncodedData));
                                                }
                                                catch
                                                {

                                                }
                                                separateOnucched.lastopenOnuchhed();
                                                separateOnucched.loadinLocal();
                                                //onuchhedFLP.Controls.Add(separateOnucched);
                                                UIDesignCommonMethod.AddRowinTable(onuchhedFLP, separateOnucched);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                noteHeaderPanel.Width = 990;
                                noteHeaderPanel.Height = 81;
                                //string message = "Error";
                                ErrorMessage(onucchedList.message);
                            }

                        }
                        else
                        {
                            //string message = "Error";
                            onuchhedSaveWithAttachments.Clear();
                            ErrorMessage(onucchedSave.message);
                        }
                    }

                    //onuchhed
                    //onuchhed.EditButtonClick += delegate (object sender1, EventArgs e1) { EditButton_Click(sender1 as NoteListDataRecordNoteDTO, e1, dakListUserParam, nothiListRecords, newnotedata ); };

                }
                else
                {
                    string message = "অনুচ্ছেদ বডি দেওয়া হইনি";
                    ErrorMessage(message);
                }

                //tinyMceEditor.Controls.Clear();
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message);
            }
        }

        private void btnSaveWithNewOnuchhed_Click(object sender, EventArgs e)
        {
            btnOnuchhedSave_Click(sender, e);
            noteHeaderPanel.Width = 990;
            noteHeaderPanel.Height = 150;
            btnWriteOnuchhed.Visible = false;
            btnSend.Visible = false;
            visibilityON();

            PnlSave.Visible = false;
            panel22.Visible = true;
            tinyMceEditor.Visible = true;
            panel28.Visible = true;
            panel22.SendToBack();
            panel24.Visible = true;
            //panel24.SendToBack();
            tinyMceEditor.HtmlContent = "";
            fileAddFLP.Controls.Clear();
            noteFileUploads.Clear();
            onucchedEditorPanel.Visible = true;
        }
        private int updateOnuchhedId;
        public void EditButton_Click(NoteListDataRecordNoteDTO noteListDataRecordNoteDTO, EventArgs e, DakUserParam dakListUserParam, NothiListRecordsDTO nothiListRecords, NoteSaveDTO newnotedata)
        {
            //onuchhed.onucchedId = onucchedSave.data.id;
            btnWriteOnuchhed.Visible = false;
            btnSend.Visible = false;
            visibilityON();
            panel22.Visible = true;
            tinyMceEditor.Visible = true;
            panel28.Visible = true;
            panel24.Visible = true;
            panel22.SendToBack();
            tinyMceEditor.HtmlContent = noteListDataRecordNoteDTO.note_subject;
            updateOnuchhedId = noteListDataRecordNoteDTO.nothi_note_id; ///////////////////////////////////////////////////////////////////////Jhamela ache ekhane.(onuchhed ID boshate hobe ekhane)//////////////////////////////
            //onuchhedFLP.Controls.Add(onuchhed);
            fileAddFLP.Controls.Clear();
            noteFileUploads.Clear();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel22.Visible = false;
            tinyMceEditor.Visible = false;
            panel24.Visible = false;
            panel28.Visible = false;
            PnlSave.Visible = false;
            noteHeaderPanel.Width = 990;
            noteHeaderPanel.Height = 426;
            visibilityOFF();
            updateOnuchhedId = 0;
            onuchhedSaveWithAttachments.Clear();
            if (_NoteAllListDataRecordDTO.note.can_revert == 1)
            {
                btnCanRevert.Visible = true;
                checkSub = _NoteAllListDataRecordDTO.note.note_subject;
                checkNoteId = _NoteAllListDataRecordDTO.note.nothi_note_id;
            }
            else { btnCanRevert.Visible = false; }
            if (_NoteAllListDataRecordDTO.note.is_editable == 1)
            { btnWriteOnuchhed.Visible = true; btnSend.Visible = true; }
            else { btnWriteOnuchhed.Visible = false; btnSend.Visible = false; }
            fileAddFLP.Controls.Clear();
            noteFileUploads.Clear();
        }

        private void btnWriteOnuchhed_Click(object sender, EventArgs e)
        {
            noteHeaderPanel.Width = 990;
            noteHeaderPanel.Height = 150;
            btnWriteOnuchhed.Visible = false;
            btnSend.Visible = false;
            visibilityON();

            PnlSave.Visible = false;
            panel22.Visible = true;
            tinyMceEditor.Visible = true;
            panel28.Visible = true;
            panel22.SendToBack();
            panel24.Visible = true;
            //panel24.SendToBack();
            tinyMceEditor.HtmlContent = "";
            fileAddFLP.Controls.Clear();
            noteFileUploads.Clear();
            onucchedEditorPanel.Visible = true;
        }

        private void iconButton20_Click(object sender, EventArgs e)
        {
            PnlSave.Visible = false;
        }
        public void LoadOnumodonListinPanel(List<onumodonDataRecordDTO> records, NothiNextStep nns, NothiListRecordsDTO nothiListRecords,
            NoteListDataRecordNoteDTO notelist, string _noteIdfromNothiInboxNoteShomuho, string _nothiNo, string _nothiShakha, string _nothiSubject, string _nothiLastDate,
            NothiListInboxNoteRecordsDTO _NoteAllListDataRecordDTO, string _office, NoteView newNoteView)
        {
            this.Hide();

            var nothiType = UserControlFactory.Create<NothiNextStep>();

            nothiType.NoteDetailsButton += delegate (object sender, EventArgs e) { NoteDetails_ButtonClick(sender, e); };
            nothiType.Visible = true;
            nothiType.Enabled = true;
            nothiType.noteTotal = notelist.note_status;
            nothiType.noteSubject = notelist.note_subject_sub_text;
            nothiType._noteID = notelist.nothi_note_id.ToString();
            nothiType.loadNewNoteData(nns.getNewNoteData());
            nothiType.loadlistInboxRecord(nothiListRecords);

            nothiType.GetNothiInboxRecords(records);
            nothiType.loadNoteList(notelist);


            nothiType._noteIdfromNothiInboxNoteShomuho = _noteIdfromNothiInboxNoteShomuho;
            nothiType._nothiNo = _nothiNo;
            nothiType._nothiShakha = _nothiShakha;
            nothiType._nothiSubject = _nothiSubject;
            nothiType._nothiLastDate = _nothiLastDate;
            nothiType._office = _office;
            nothiType.loadNothiInbox(_NoteAllListDataRecordDTO);
            nothiType.loadNothiInbox(nothiListRecords);
            nothiType.loadNoteview(newNoteView);

            this.Controls.Add(nothiType);
            var form = NothiNextStepControlToForm(nothiType);
            CalPopUpWindow(form);

        }
        public void loadnothiListRecordsAndNothiTypeFromNothiOnumodonDesgSeal(NothiListRecordsDTO nothiListRecords, NothiNextStep nns, NoteListDataRecordNoteDTO notelist,
            string noteId, string _noteIdfromNothiInboxNoteShomuho, string _nothiNo, string _nothiShakha, string _nothiSubject, string _nothiLastDate,
            NothiListInboxNoteRecordsDTO _NoteAllListDataRecordDTO, string _office, NoteView newNoteView)
        {
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            var onumodonList = _onumodonService.GetNoteOnumodonMembers(dakListUserParam, nothiListRecords, noteId);
            if (onumodonList.status == "success")
            {
                if (onumodonList.data.records.Count > 0)
                {

                    LoadOnumodonListinPanel(onumodonList.data.records, nns, nothiListRecords, notelist,
                        _noteIdfromNothiInboxNoteShomuho, _nothiNo, _nothiShakha, _nothiSubject, _nothiLastDate, _NoteAllListDataRecordDTO, _office, newNoteView);
                }

                //this.ShowDialog();
            }
        }
        public void setStatus(string str)
        {
            lbOnlineorOfflineStatus.Text = str;
        }
        public void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbOnlineorOfflineStatus.Text == "offline")
                {
                    //ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
                    DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                    var onumodonList = _onumodonService.GetNoteOnumodonMembers(dakListUserParam, nothiListRecords, NoteIdfromNothiInboxNoteShomuho.Text);
                    var onumodonList1 = _onumodonService.GetOnumodonMembers(dakListUserParam, nothiListRecords);
                    if (onumodonList.status == "success" || onumodonList1.status == "success")
                    {

                        if (onumodonList.data != null)
                        {
                            if (onumodonList.data.records.Count > 0)
                            {
                                LoadOnumodonListinPanel(onumodonList.data.records);
                            }

                        }
                        else if (onumodonList1.data != null)
                        {
                            if (onumodonList1.data.records.Count > 0)
                            {
                                LoadOnumodonListinPanel(onumodonList1.data.records);
                            }

                        }

                        //this.ShowDialog();
                    }
                    else
                    {
                        ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
                    }
                }
                else
                {
                    if (!InternetConnection.Check())
                    {
                        DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                        var onumodonList = _onumodonService.GetNoteOnumodonMembers(dakListUserParam, nothiListRecords, NoteIdfromNothiInboxNoteShomuho.Text);
                        var onumodonList1 = _onumodonService.GetOnumodonMembers(dakListUserParam, nothiListRecords);
                        if (onumodonList.status == "success" || onumodonList1.status == "success")
                        {

                            if (onumodonList.data != null)
                            {
                                if (onumodonList.data.records.Count > 0)
                                {
                                    LoadOnumodonListinPanel(onumodonList.data.records);
                                }

                            }
                            else if (onumodonList1.data != null)
                            {
                                if (onumodonList1.data.records.Count > 0)
                                {
                                    LoadOnumodonListinPanel(onumodonList1.data.records);
                                }

                            }

                            //this.ShowDialog();
                        }
                        else
                        {
                            ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
                        }
                    }
                    else
                    {
                        DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                        //var onumodonList = _onumodonService.GetOnumodonMembers(dakListUserParam, nothiListRecords);
                        var onumodonList = _onumodonService.GetNoteOnumodonMembers(dakListUserParam, nothiListRecords, NoteIdfromNothiInboxNoteShomuho.Text);
                        if (onumodonList.status == "success")
                        {
                            if (onumodonList.data.records.Count > 0)
                            {

                                LoadOnumodonListinPanel(onumodonList.data.records);
                            }

                            //this.ShowDialog();
                        }
                        else
                        {
                            ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }

        }
        public event EventHandler NoteDetailsButton;
        private void NoteDetails_ButtonClick(object sender, EventArgs e)
        {
            if (this.NoteDetailsButton != null)
                this.NoteDetailsButton(sender, e);

        }

        public void LoadOnumodonListinPanel(List<onumodonDataRecordDTO> records)
        {
            var nothiType = UserControlFactory.Create<NothiNextStep>();

            nothiType.NoteDetailsButton += delegate (object sender, EventArgs e) { NoteDetails_ButtonClick(sender, e); };
            //nothiInbox.NoteDetailsButton += delegate (object sender, EventArgs e) { NoteDetails_ButtonClick(sender, e, nothiListRecordsDTO, nothiInbox._nothiListInboxNoteRecordsDTO); };
            nothiType.Visible = true;
            nothiType.Enabled = true;
            nothiType._noteID = _noteIdfromNothiInboxNoteShomuho;
            if (notelist.note_status != null || notelist.note_subject_sub_text != null)
            {
                nothiType.noteTotal = notelist.note_status;
                nothiType.noteSubject = notelist.note_subject_sub_text;
            }
            else
            {
                nothiType.noteTotal = lbNoteTotl1.Text.Substring(lbNoteTotl1.Text.IndexOf("টঃ") + 2);
                nothiType.noteSubject = lbNoteSubject.Text;
            }

            nothiType.loadNewNoteData(newnotedata);
            nothiType.loadlistInboxRecord(nothiListRecords);

            nothiType.GetNothiInboxRecords(records);
            nothiType.loadNoteList(notelist);
            nothiType._noteIdfromNothiInboxNoteShomuho = noteIdfromNothiInboxNoteShomuho;
            nothiType._nothiNo = nothiNo;
            nothiType._nothiShakha = nothiShakha;
            nothiType._nothiSubject = nothiSubject;
            nothiType._nothiLastDate = nothiLastDate;
            nothiType._office = office;
            nothiType.loadNothiInbox(_NoteAllListDataRecordDTO);
            nothiType.loadNothiInbox(nothiListRecords);
            nothiType.loadNoteview(newNoteView);

            this.Controls.Add(nothiType);
            var form = NothiNextStepControlToForm(nothiType);
            CalPopUpWindow(form);

        }
        public Form NothiNextStepControlToForm(Control control)
        {
            Form form = new Form();
            form.StartPosition = FormStartPosition.Manual;
            form.FormBorderStyle = FormBorderStyle.None;
            form.BackColor = Color.White;
            form.AutoSize = true;
            form.Location = new System.Drawing.Point(Screen.PrimaryScreen.WorkingArea.Width - control.Width, 0);
            control.Location = new System.Drawing.Point(0, 0);
            //form.Size = control.Size;
            form.Height = Screen.PrimaryScreen.WorkingArea.Height;
            form.Width = control.Width;
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            control.Height = form.Height;
            form.Controls.Add(control);
            return form;
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
            //this.Hide();
            var form = FormFactory.Create<Dashboard>();
            form.TopMost = true;
            BeginInvoke((Action)(() => form.ShowDialog()));
            BeginInvoke((Action)(() => form.TopMost = false));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            var form = FormFactory.Create<Dashboard>();
            form.TopMost = true;
            BeginInvoke((Action)(() => form.ShowDialog()));
            BeginInvoke((Action)(() => form.TopMost = false));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };
        }
        private void DoSomethingAsync(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void dakModuleNameLabel_Click(object sender, EventArgs e)
        {
            //this.Hide();
            var form = FormFactory.Create<Dashboard>();
            form.TopMost = true;
            BeginInvoke((Action)(() => form.ShowDialog()));
            BeginInvoke((Action)(() => form.TopMost = false));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };
        }

        private void moduleDakCountLabel_Click(object sender, EventArgs e)
        {
            //this.Hide();
            var form = FormFactory.Create<Dashboard>();
            form.TopMost = true;
            BeginInvoke((Action)(() => form.ShowDialog()));
            BeginInvoke((Action)(() => form.TopMost = false));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };
        }

        private void nothiModulePanel_Click(object sender, EventArgs e)
        {
            //this.Hide();
            var form = FormFactory.Create<Nothi>();
            form.TopMost = true;
            BeginInvoke((Action)(() => form.ShowDialog()));
            BeginInvoke((Action)(() => form.TopMost = false));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            var form = FormFactory.Create<Nothi>();
            form.TopMost = true;
            BeginInvoke((Action)(() => form.ShowDialog()));
            BeginInvoke((Action)(() => form.TopMost = false));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };
        }

        private void nothiModuleNameLabel_Click(object sender, EventArgs e)
        {
            //this.Hide();
            var form = FormFactory.Create<Nothi>();
            form.TopMost = true;
            BeginInvoke((Action)(() => form.ShowDialog()));
            BeginInvoke((Action)(() => form.TopMost = false));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };
        }

        private void label22_Click(object sender, EventArgs e)
        {
            //this.Hide();
            var form = FormFactory.Create<Nothi>();
            form.TopMost = true;
            BeginInvoke((Action)(() => form.ShowDialog()));
            BeginInvoke((Action)(() => form.TopMost = false));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };
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
            btnNothivuktoPotroNext.Visible = false;

            btnNoteKhoshraNext.Visible = false;
            NoteKhoshraWaitingNext.Visible = false;
            NotePotrojariNext.Visible = false;
            btnNoteNothivuktoPotroNext.Visible = false;
        }
        public void allPreviousButtonVisibilityOff()
        {
            btnKhoshraPrevious.Visible = false;
            btnKhoshraWaitingPrevious.Visible = false;
            btnAllPotroPrevious.Visible = false;
            btnPotrojariPrevious.Visible = false;
            btnNothijatoPrevious.Visible = false;
            btnNothivuktoPotroPrevious.Visible = false;

            btnNoteKhoshraPrevious.Visible = false;
            NoteKhoshraWaitingPrevious.Visible = false;
            NotePotrojariPrevious.Visible = false;
            btnNoteNothivuktoPotroPrevious.Visible = false;
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

            lbNothivuktoPotro.BackColor = Color.Azure;
            lbNothivuktoPotro.ForeColor = Color.FromArgb(63, 66, 84);

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

            lbNoteKhoshra.BackColor = Color.Azure;
            lbNoteKhoshra.ForeColor = Color.FromArgb(63, 66, 84);

            lbNoteNothivuktoPotro.BackColor = Color.Azure;
            lbNoteNothivuktoPotro.ForeColor = Color.FromArgb(63, 66, 84);

            lbNoteKhoshraWaiting.BackColor = Color.Azure;
            lbNoteKhoshraWaiting.ForeColor = Color.FromArgb(63, 66, 84);

            lbNotePotrojari.BackColor = Color.Azure;
            lbNotePotrojari.ForeColor = Color.FromArgb(63, 66, 84);

            lbNoteNothivuktoPotro.BackColor = Color.Azure;
            lbNoteNothivuktoPotro.ForeColor = Color.FromArgb(63, 66, 84);
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
            try
            {
                allLbelButtonPreviousColor();
                lbAllPotro.BackColor = Color.FromArgb(14, 102, 98);
                lbAllPotro.ForeColor = Color.FromArgb(191, 239, 237);

                allNextButtonVisibilityOff();
                btnAllPotroNext.Visible = true;

                allPotro = _allPotro.GetAllPotroInfo(_dakuserparam, nothiListRecords.id);
                if (allPotro.status == "success")
                {
                    i = 0;
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
                        foreach (string btnName in allPotro.data.records[i].mulpotro.buttonsDTOList)
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
                if (allPotro.data.total_records == i || allPotro.data.total_records - 1 == i)
                {
                    i = 0;
                    allNextButtonVisibilityOff();
                    allPreviousButtonVisibilityOff();

                }
            }
            catch (Exception ex)
            {
                ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
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
                    foreach (string btnName in allPotro.data.records[i].mulpotro.buttonsDTOList)
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
                    foreach (string btnName in allPotro.data.records[i].mulpotro.buttonsDTOList)
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
                    foreach (string btnName in allPotro.data.records[i].mulpotro.buttonsDTOList)
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
            if (allPotro.data.total_records == i || allPotro.data.total_records - 1 == i)
            {
                //i = 0;
                allNextButtonVisibilityOff();
            }

        }

        KhoshraPotroResponse khoshraPotro = new KhoshraPotroResponse();
        private void lbKhoshra_Click(object sender, EventArgs e)
        {
            try
            {
                _khoshraPotroWaitinDataRecordDTO = null;
                current_potro_id = 0;
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

                        string DecodedString = khoshraPotro.data.records[0].mulpotro.potro_description;
                        khosraViewWebBrowser.DocumentText = Base64Decode1(DecodedString);


                        current_potro_id = khoshraPotro.data.records[0].basic.id;
                        KhosraAttachmentButton(khoshraPotro.data.records[0].basic.potro_pages);
                        _khoshraPotroWaitinDataRecordDTO = null;

                        _khoshraPotroDataRecordDTO = GetNoteKhosraFromKhosra(khoshraPotro.data.records[0]);


                        khoshraPotroWaitinDataRecordMulpotroDTO = new KhoshraPotroWaitinDataRecordMulpotroDTO();
                        //  khoshraPotroWaitinDataRecordMulpotroDTO.buttonsDTOList = khoshraPotro.data.records[0].mulpotro.;
                        khoshraPotroWaitinDataRecordMulpotroDTO.buttons = khoshraPotro.data.records[0].mulpotro.buttons;
                        khoshraPotroWaitinDataRecordMulpotroDTO.id = khoshraPotro.data.records[0].mulpotro.id;
                        khoshraPotroWaitinDataRecordMulpotroDTO.potro_cover = khoshraPotro.data.records[0].mulpotro.potro_cover;
                        khoshraPotroWaitinDataRecordMulpotroDTO.potro_description = khoshraPotro.data.records[0].mulpotro.potro_description;




                    }
                    picBoxFile.Controls.Clear();
                }
                if (khoshraPotro.data.total_records == i || khoshraPotro.data.total_records - 1 == i)
                {
                    i = 0;
                    allPreviousButtonVisibilityOff();
                    allNextButtonVisibilityOff();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }

        }

        private NoteKhoshraListDataRecordDTO GetNoteKhosraFromKhosra(KhoshraPotroRecordsDTO khoshraPotroRecordsDTO)
        {
            NoteKhoshraListDataRecordDTO record = new NoteKhoshraListDataRecordDTO();

            record.basic = MappingModels.MapModel<KhoshraPotroRecordsBasicDTO, NoteKhoshraListDataRecordBasicDTO>(khoshraPotroRecordsDTO.basic);
            record.mulpotro = MappingModels.MapModel<KhoshraPotroRecordsMulpotroDTO, NoteKhoshraListDataRecordMulpotroDTO>(khoshraPotroRecordsDTO.mulpotro);
            record.note_onucched = MappingModels.MapModel<KhoshraPotroRecordsNoteOnucchedDTO, NoteKhoshraListDataRecordNoteOnucchedDTO>(khoshraPotroRecordsDTO.note_onucched);
            record.note_owner = MappingModels.MapModel<KhoshraPotroRecordsNoteOwnerDTO, NoteKhoshraListDataRecordNoteOwnerDTO>(khoshraPotroRecordsDTO.note_owner);
            return record;

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
            if (khoshraPotro.data.total_records == i || khoshraPotro.data.total_records - 1 == i)
            {
                //i = 0;
                allNextButtonVisibilityOff();
                //allMulpotroButtonsVisibilityOff();
            }
        }

        NothivuktoPotroResponse nothivuktoPotroResponse = new NothivuktoPotroResponse();
        private void lbNothivuktoPotro_Click(object sender, EventArgs e)
        {
            try
            {
                allLbelButtonPreviousColor();
                lbNothivuktoPotro.BackColor = Color.FromArgb(14, 102, 98);
                lbNothivuktoPotro.ForeColor = Color.FromArgb(191, 239, 237);

                allNextButtonVisibilityOff();
                btnNothivuktoPotroNext.Visible = true;

                nothivuktoPotroResponse = _nothivuktoPotro.GetNothivuktoPotroInfo(_dakuserparam, nothiListRecords.id);
                if (nothivuktoPotroResponse.status == "success")
                {
                    i = 0;
                    int index = 0;
                    pnlPotrangshoDetails.Visible = true;
                    if (nothivuktoPotroResponse.data.total_records > 0)
                    {
                        allNextButtonVisibilityOff();
                        btnNothivuktoPotroNext.Visible = true;

                        allPreviousButtonVisibilityOff();

                        if (nothivuktoPotroResponse.data.records[i].basic.page_numbers.Contains(","))
                        {
                            index = nothivuktoPotroResponse.data.records[i].basic.page_numbers.IndexOf(",");
                        }
                        int totalLength = nothivuktoPotroResponse.data.records[i].basic.page_numbers.Length;
                        lbPotroSubject.Text = nothivuktoPotroResponse.data.records[i].basic.subject + "(পাতা:" + string.Concat(nothivuktoPotroResponse.data.records[i].basic.page_numbers.Substring(0, index).ToString().Select(c => (char)('\u09E6' + c - '0'))) + "-" + string.Concat(nothivuktoPotroResponse.data.records[i].basic.page_numbers.Substring(index + 1).ToString().Select(c => (char)('\u09E6' + c - '0'))) + ")";
                        lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + nothivuktoPotroResponse.data.records[i].basic.due_date;
                        lbSubjectSmall.Text = "পত্র: " + nothivuktoPotroResponse.data.records[i].basic.subject;
                        lbNoteId.Text = "নোটঃ " + string.Concat(nothivuktoPotroResponse.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        lbTotal.Text = "সর্বমোট: " + string.Concat(nothivuktoPotroResponse.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                        allMulpotroButtonsVisibilityOff();
                        int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                            endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                        foreach (string btnName in nothivuktoPotroResponse.data.records[i].mulpotro.buttonsDTOList)
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

                        if (nothivuktoPotroResponse.data.records[i].mulpotro.is_main == 1)
                        {
                            pnlMulPotroOShonjukti.Visible = true;
                            lbMulPotroOShonjukti.Visible = true;
                            btnMulPotroOShonjukti.Visible = true;

                            btnMulPotroOShonjukti.Text = string.Concat(nothivuktoPotroResponse.data.records[i].basic.potro_pages.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        }
                        else
                        {
                            mulpotroOshongjuktiVisibilityOff();
                        }

                        totalRange = (i + 1).ToString();
                        if (nothivuktoPotroResponse.data.records[i].mulpotro.url != "")
                        {
                            picBoxFile.Visible = false;
                            khosraViewWebBrowser.Url = new Uri(nothivuktoPotroResponse.data.records[i].mulpotro.url);
                        }
                        else
                        {
                            picBoxFile.Controls.Clear();
                        }
                    }
                }
                if (nothivuktoPotroResponse.data.total_records == i || nothivuktoPotroResponse.data.total_records - 1 == i)
                {
                    i = 0;
                    allNextButtonVisibilityOff();
                    allPreviousButtonVisibilityOff();

                }
            }
            catch (Exception ex)
            {
                ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }

        }

        private void btnNothivuktoPotroNext_Click(object sender, EventArgs e)
        {
            i++;
            if (nothivuktoPotroResponse.data.total_records != i && i > 0)
            {
                int index = 0;
                pnlPotrangshoDetails.Visible = true;
                if (nothivuktoPotroResponse.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    btnNothivuktoPotroNext.Visible = true;

                    allPreviousButtonVisibilityOff();
                    btnNothivuktoPotroPrevious.Visible = true;

                    if (nothivuktoPotroResponse.data.records[i].basic.page_numbers.Contains(","))
                    {
                        index = nothivuktoPotroResponse.data.records[i].basic.page_numbers.IndexOf(",");
                    }
                    int totalLength = nothivuktoPotroResponse.data.records[i].basic.page_numbers.Length;
                    lbPotroSubject.Text = nothivuktoPotroResponse.data.records[i].basic.subject + "(পাতা:" + string.Concat(nothivuktoPotroResponse.data.records[i].basic.page_numbers.Substring(0, index).ToString().Select(c => (char)('\u09E6' + c - '0'))) + "-" + string.Concat(nothivuktoPotroResponse.data.records[i].basic.page_numbers.Substring(index + 1).ToString().Select(c => (char)('\u09E6' + c - '0'))) + ")";
                    lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + nothivuktoPotroResponse.data.records[i].basic.due_date;
                    lbSubjectSmall.Text = "পত্র: " + nothivuktoPotroResponse.data.records[i].basic.subject;
                    lbNoteId.Text = "নোটঃ " + string.Concat(nothivuktoPotroResponse.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    lbTotal.Text = "সর্বমোট: " + string.Concat(nothivuktoPotroResponse.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                    allMulpotroButtonsVisibilityOff();
                    int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                        endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                    foreach (string btnName in nothivuktoPotroResponse.data.records[i].mulpotro.buttonsDTOList)
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

                    if (nothivuktoPotroResponse.data.records[i].mulpotro.is_main == 1)
                    {
                        pnlMulPotroOShonjukti.Visible = true;
                        lbMulPotroOShonjukti.Visible = true;
                        btnMulPotroOShonjukti.Visible = true;

                        btnMulPotroOShonjukti.Text = string.Concat(nothivuktoPotroResponse.data.records[i].basic.potro_pages.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        mulpotroOshongjuktiVisibilityOff();
                    }

                    totalRange = (i + 1).ToString();
                    if (nothivuktoPotroResponse.data.records[i].mulpotro.url != "")
                    {
                        picBoxFile.Visible = false;
                        khosraViewWebBrowser.Url = new Uri(nothivuktoPotroResponse.data.records[i].mulpotro.url);
                    }
                    else
                    {
                        picBoxFile.Controls.Clear();
                    }
                }
            }
            if (nothivuktoPotroResponse.data.total_records == i || nothivuktoPotroResponse.data.total_records - 1 == i)
            {
                //i = 0;
                allNextButtonVisibilityOff();
            }
        }

        private void btnNothivuktoPotroPrevious_Click(object sender, EventArgs e)
        {
            i--;
            if (i == 0)
            {
                int index = 0;
                pnlPotrangshoDetails.Visible = true;
                if (nothivuktoPotroResponse.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    btnNothivuktoPotroNext.Visible = true;

                    allPreviousButtonVisibilityOff();

                    if (nothivuktoPotroResponse.data.records[i].basic.page_numbers.Contains(","))
                    {
                        index = nothivuktoPotroResponse.data.records[i].basic.page_numbers.IndexOf(",");
                    }
                    int totalLength = nothivuktoPotroResponse.data.records[i].basic.page_numbers.Length;
                    lbPotroSubject.Text = nothivuktoPotroResponse.data.records[i].basic.subject + "(পাতা:" + string.Concat(nothivuktoPotroResponse.data.records[i].basic.page_numbers.Substring(0, index).ToString().Select(c => (char)('\u09E6' + c - '0'))) + "-" + string.Concat(nothivuktoPotroResponse.data.records[i].basic.page_numbers.Substring(index + 1).ToString().Select(c => (char)('\u09E6' + c - '0'))) + ")";
                    lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + nothivuktoPotroResponse.data.records[i].basic.due_date;
                    lbSubjectSmall.Text = "পত্র: " + nothivuktoPotroResponse.data.records[i].basic.subject;
                    lbNoteId.Text = "নোটঃ " + string.Concat(nothivuktoPotroResponse.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    lbTotal.Text = "সর্বমোট: " + string.Concat(nothivuktoPotroResponse.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                    allMulpotroButtonsVisibilityOff();
                    int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                        endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                    foreach (string btnName in nothivuktoPotroResponse.data.records[i].mulpotro.buttonsDTOList)
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

                    if (nothivuktoPotroResponse.data.records[i].mulpotro.is_main == 1)
                    {
                        pnlMulPotroOShonjukti.Visible = true;
                        lbMulPotroOShonjukti.Visible = true;
                        btnMulPotroOShonjukti.Visible = true;

                        btnMulPotroOShonjukti.Text = string.Concat(nothivuktoPotroResponse.data.records[i].basic.potro_pages.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        mulpotroOshongjuktiVisibilityOff();
                    }

                    totalRange = (i + 1).ToString();
                    if (nothivuktoPotroResponse.data.records[i].mulpotro.url != "")
                    {
                        picBoxFile.Visible = false;
                        khosraViewWebBrowser.Url = new Uri(nothivuktoPotroResponse.data.records[i].mulpotro.url);
                    }
                    else
                    {
                        picBoxFile.Controls.Clear();
                    }
                }
            }
            if (nothivuktoPotroResponse.data.total_records != i && i > 0)
            {
                int index = 0;
                pnlPotrangshoDetails.Visible = true;
                if (nothivuktoPotroResponse.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    btnNothivuktoPotroNext.Visible = true;

                    allPreviousButtonVisibilityOff();
                    btnNothivuktoPotroPrevious.Visible = true;

                    if (nothivuktoPotroResponse.data.records[i].basic.page_numbers.Contains(","))
                    {
                        index = nothivuktoPotroResponse.data.records[i].basic.page_numbers.IndexOf(",");
                    }
                    int totalLength = nothivuktoPotroResponse.data.records[i].basic.page_numbers.Length;
                    lbPotroSubject.Text = nothivuktoPotroResponse.data.records[i].basic.subject + "(পাতা:" + string.Concat(nothivuktoPotroResponse.data.records[i].basic.page_numbers.Substring(0, index).ToString().Select(c => (char)('\u09E6' + c - '0'))) + "-" + string.Concat(nothivuktoPotroResponse.data.records[i].basic.page_numbers.Substring(index + 1).ToString().Select(c => (char)('\u09E6' + c - '0'))) + ")";
                    lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + nothivuktoPotroResponse.data.records[i].basic.due_date;
                    lbSubjectSmall.Text = "পত্র: " + nothivuktoPotroResponse.data.records[i].basic.subject;
                    lbNoteId.Text = "নোটঃ " + string.Concat(nothivuktoPotroResponse.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    lbTotal.Text = "সর্বমোট: " + string.Concat(nothivuktoPotroResponse.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                    allMulpotroButtonsVisibilityOff();
                    int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                        endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                    foreach (string btnName in nothivuktoPotroResponse.data.records[i].mulpotro.buttonsDTOList)
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

                    if (nothivuktoPotroResponse.data.records[i].mulpotro.is_main == 1)
                    {
                        pnlMulPotroOShonjukti.Visible = true;
                        lbMulPotroOShonjukti.Visible = true;
                        btnMulPotroOShonjukti.Visible = true;

                        btnMulPotroOShonjukti.Text = string.Concat(nothivuktoPotroResponse.data.records[i].basic.potro_pages.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        mulpotroOshongjuktiVisibilityOff();
                    }

                    totalRange = (i + 1).ToString();
                    if (nothivuktoPotroResponse.data.records[i].mulpotro.url != "")
                    {
                        picBoxFile.Visible = false;
                        khosraViewWebBrowser.Url = new Uri(nothivuktoPotroResponse.data.records[i].mulpotro.url);
                    }
                    else
                    {
                        picBoxFile.Controls.Clear();
                    }
                }
            }
            if (nothivuktoPotroResponse.data.total_records < 0 || i < 0)
            {
                i = 0;
                allPreviousButtonVisibilityOff();
            }
        }



        KhoshraPotroWaitingResponse khoshraPotroWaiting = new KhoshraPotroWaitingResponse();
        private void lbKhoshraWaiting_Click(object sender, EventArgs e)
        {
            KhosraWaitingLoad();

        }

        private void KhosraWaitingLoad()
        {
            try
            {
                current_potro_id = 0;
                _khoshraPotroWaitinDataRecordDTO = null;
                khoshraPotroWaitinDataRecordMulpotroDTO = null;
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
                    foreach (string btnName in khoshraPotroWaiting.data.records[i].mulpotro.buttonsDTOList)
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
                        current_potro_id = khoshraPotroWaiting.data.records[0].basic.id;
                        _khoshraPotroDataRecordDTO = null;
                        _khoshraPotroWaitinDataRecordDTO = khoshraPotroWaiting.data.records[0];
                        KhosraAttachmentButton(khoshraPotroWaiting.data.records[0].basic.potro_pages);
                        khoshraPotroWaitinDataRecordMulpotroDTO = khoshraPotroWaiting.data.records[0].mulpotro;
                        string DecodedString = khoshraPotroWaiting.data.records[0].mulpotro.potro_description;
                        khosraViewWebBrowser.DocumentText = Base64Decode1(DecodedString);
                        string htmlString = "<head><meta charset=\"UTF-8\"></head>" + Base64Decode1(DecodedString);

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
            catch (Exception ex)
            {
                ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
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
                foreach (string btnName in khoshraPotroWaiting.data.records[i].mulpotro.buttonsDTOList)
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
                foreach (string btnName in khoshraPotroWaiting.data.records[i].mulpotro.buttonsDTOList)
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
                foreach (string btnName in khoshraPotroWaiting.data.records[i].mulpotro.buttonsDTOList)
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
            try
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
                    foreach (string btnName in potrojariList.data.records[i].mulpotro.buttonsDTOList)
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
            catch (Exception ex)
            {
                ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
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
                foreach (string btnName in potrojariList.data.records[i].mulpotro.buttonsDTOList)
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
                foreach (string btnName in potrojariList.data.records[i].mulpotro.buttonsDTOList)
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
                foreach (string btnName in potrojariList.data.records[i].mulpotro.buttonsDTOList)
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
            try
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
            catch (Exception ex)
            {
                ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
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

        NoteKhoshraListResponse noteKhoshraList = new NoteKhoshraListResponse();
        private void lbNoteKhoshra_Click(object sender, EventArgs e)
        {
            try
            {
                _khoshraPotroWaitinDataRecordDTO = null;
                allLbelButtonPreviousColor();
                lbNoteKhoshra.BackColor = Color.FromArgb(14, 102, 98);
                lbNoteKhoshra.ForeColor = Color.FromArgb(191, 239, 237);

                allNextButtonVisibilityOff();
                btnNothijatoNext.Visible = true;
                noteKhoshraList = _noteKhoshraList.GetnoteKhoshraListInfo(_dakuserparam, nothiListRecords.id, notelist.nothi_note_id);
                if (noteKhoshraList.status == "success")
                {
                    i = 0;
                    pnlPotrangshoDetails.Visible = true;
                    lbPotroSubject.Text = noteKhoshraList.data.records[i].basic.potro_subject;
                    lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + noteKhoshraList.data.records[i].basic.created;
                    lbNoteId.Text = "নোটঃ " + string.Concat(noteKhoshraList.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    lbSubjectSmall.Text = "পত্র: " + noteKhoshraList.data.records[i].basic.potro_subject;
                    lbTotal.Text = "সর্বমোট: " + string.Concat(noteKhoshraList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                    allMulpotroButtonsVisibilityOff();
                    int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                        endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                    foreach (string btnName in noteKhoshraList.data.records[i].mulpotro.buttonsDTOList)
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

                    if (noteKhoshraList.data.total_records > 0)
                    {
                        allNextButtonVisibilityOff();
                        btnNoteKhoshraNext.Visible = true;

                        allPreviousButtonVisibilityOff();
                        string DecodedString = noteKhoshraList.data.records[i].mulpotro.potro_description;

                        khosraViewWebBrowser.DocumentText = Base64Decode1(DecodedString);

                        _khoshraPotroWaitinDataRecordDTO = null;
                        _khoshraPotroDataRecordDTO = noteKhoshraList.data.records[0];
                        KhosraAttachmentButton(noteKhoshraList.data.records[0].basic.potro_pages);
                        khoshraPotroWaitinDataRecordMulpotroDTO = new KhoshraPotroWaitinDataRecordMulpotroDTO();
                        khoshraPotroWaitinDataRecordMulpotroDTO.buttonsDTOList = noteKhoshraList.data.records[0].mulpotro.buttonsDTOList;
                        khoshraPotroWaitinDataRecordMulpotroDTO.buttons = noteKhoshraList.data.records[0].mulpotro.buttons;
                        khoshraPotroWaitinDataRecordMulpotroDTO.id = noteKhoshraList.data.records[0].mulpotro.id;
                        khoshraPotroWaitinDataRecordMulpotroDTO.potro_cover = noteKhoshraList.data.records[0].mulpotro.potro_cover;
                        khoshraPotroWaitinDataRecordMulpotroDTO.potro_description = noteKhoshraList.data.records[0].mulpotro.potro_description;


                    }
                }
                if (noteKhoshraList.data.total_records == i || noteKhoshraList.data.total_records - 1 == i)
                {
                    i = 0;
                    allNextButtonVisibilityOff();
                    allPreviousButtonVisibilityOff();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }


        }

        private void KhosraAttachmentButton(int attachment_count)
        {
            if (attachment_count > 0)
            {
                lbMulPotroOShonjukti.Visible = true;
                btnMulPotroOShonjukti.Visible = true;
                btnMulPotroOShonjukti.Text = ConversionMethod.EngDigittoBanDigit(attachment_count.ToString());
            }
            else
            {
                btnMulPotroOShonjukti.Visible = false;
                lbMulPotroOShonjukti.Visible = false;
            }
        }

        private void btnNoteKhoshraPrevious_Click(object sender, EventArgs e)
        {
            i--;
            if (i == 0)
            {
                pnlPotrangshoDetails.Visible = true;
                lbPotroSubject.Text = noteKhoshraList.data.records[i].basic.potro_subject;
                lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + noteKhoshraList.data.records[i].basic.created;
                lbNoteId.Text = "নোটঃ " + string.Concat(noteKhoshraList.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                lbSubjectSmall.Text = "পত্র: " + noteKhoshraList.data.records[i].basic.potro_subject;
                lbTotal.Text = "সর্বমোট: " + string.Concat(noteKhoshraList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                allMulpotroButtonsVisibilityOff();
                int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                    endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                foreach (string btnName in noteKhoshraList.data.records[i].mulpotro.buttonsDTOList)
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

                if (noteKhoshraList.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    btnNoteKhoshraNext.Visible = true;

                    allPreviousButtonVisibilityOff();
                    string DecodedString = noteKhoshraList.data.records[i].mulpotro.potro_description;
                    khosraViewWebBrowser.DocumentText = Base64Decode1(DecodedString);
                }
            }
            if (noteKhoshraList.data.total_records != i && i > 0)
            {
                pnlPotrangshoDetails.Visible = true;
                lbPotroSubject.Text = noteKhoshraList.data.records[i].basic.potro_subject;
                lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + noteKhoshraList.data.records[i].basic.created;
                lbNoteId.Text = "নোটঃ " + string.Concat(noteKhoshraList.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                lbSubjectSmall.Text = "পত্র: " + noteKhoshraList.data.records[i].basic.potro_subject;
                lbTotal.Text = "সর্বমোট: " + string.Concat(noteKhoshraList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                allMulpotroButtonsVisibilityOff();
                int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                    endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                foreach (string btnName in noteKhoshraList.data.records[i].mulpotro.buttonsDTOList)
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

                if (noteKhoshraList.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    btnNoteKhoshraNext.Visible = true;

                    allPreviousButtonVisibilityOff();
                    btnNoteKhoshraPrevious.Visible = true;

                    string DecodedString = noteKhoshraList.data.records[i].mulpotro.potro_description;
                    khosraViewWebBrowser.DocumentText = Base64Decode1(DecodedString);
                }
            }
            if (noteKhoshraList.data.total_records < 0 || i < 0)
            {
                i = 0;
                allPreviousButtonVisibilityOff();
            }
        }
        private void btnNoteKhoshraNext_Click(object sender, EventArgs e)
        {
            i++;
            if (noteKhoshraList.data.total_records != i && i > 0)
            {
                pnlPotrangshoDetails.Visible = true;
                lbPotroSubject.Text = noteKhoshraList.data.records[i].basic.potro_subject;
                lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + noteKhoshraList.data.records[i].basic.created;
                lbNoteId.Text = "নোটঃ " + string.Concat(noteKhoshraList.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                lbSubjectSmall.Text = "পত্র: " + noteKhoshraList.data.records[i].basic.potro_subject;
                lbTotal.Text = "সর্বমোট: " + string.Concat(noteKhoshraList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                allMulpotroButtonsVisibilityOff();
                int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                    endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                foreach (string btnName in noteKhoshraList.data.records[i].mulpotro.buttonsDTOList)
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

                if (noteKhoshraList.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    btnNoteKhoshraNext.Visible = true;

                    allPreviousButtonVisibilityOff();
                    btnNoteKhoshraPrevious.Visible = true;
                    string DecodedString = noteKhoshraList.data.records[i].mulpotro.potro_description;
                    khosraViewWebBrowser.DocumentText = Base64Decode1(DecodedString);
                }
            }
            if (noteKhoshraList.data.total_records == i || noteKhoshraList.data.total_records - 1 == i)
            {
                //i = 0;
                allNextButtonVisibilityOff();
            }
        }

        NoteKhshraWaitingListResponse noteKhshraWaitingList = new NoteKhshraWaitingListResponse();
        private void lbNoteKhoshraWaiting_Click(object sender, EventArgs e)
        {
            try
            {
                current_potro_id = 0;
                _khoshraPotroDataRecordDTO = null;
                _khoshraPotroWaitinDataRecordDTO = null;
                khoshraPotroWaitinDataRecordMulpotroDTO = null;

                allLbelButtonPreviousColor();
                lbNoteKhoshraWaiting.BackColor = Color.FromArgb(14, 102, 98);
                lbNoteKhoshraWaiting.ForeColor = Color.FromArgb(191, 239, 237);

                allNextButtonVisibilityOff();
                NoteKhoshraWaitingNext.Visible = true;
                noteKhshraWaitingList = _noteKhshraWaitingList.GetNoteKhshraWaitingListInfo(_dakuserparam, nothiListRecords.id, notelist.nothi_note_id);
                if (noteKhshraWaitingList.status == "success" && noteKhshraWaitingList.data.records.Count > 0)
                {
                    i = 0;
                    pnlPotrangshoDetails.Visible = true;
                    lbPotroSubject.Text = noteKhshraWaitingList.data.records[i].basic.potro_subject;
                    lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + noteKhshraWaitingList.data.records[i].basic.created;
                    lbNoteId.Text = "নোটঃ " + string.Concat(noteKhshraWaitingList.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    lbSubjectSmall.Text = "পত্র: " + noteKhshraWaitingList.data.records[i].basic.potro_subject;
                    lbTotal.Text = "সর্বমোট: " + string.Concat(noteKhshraWaitingList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                    allMulpotroButtonsVisibilityOff();
                    int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                        endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                    foreach (string btnName in noteKhshraWaitingList.data.records[i].mulpotro.buttonsDTOList)
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

                    if (noteKhshraWaitingList.data.total_records > 0)
                    {
                        allNextButtonVisibilityOff();
                        NoteKhoshraWaitingNext.Visible = true;

                        allPreviousButtonVisibilityOff();

                        // current_potro_id = noteKhshraWaitingList.data.records[0].basic.id;
                        _khoshraPotroWaitinDataRecordDTO = noteKhshraWaitingList.data.records[0];
                        khoshraPotroWaitinDataRecordMulpotroDTO = noteKhshraWaitingList.data.records[0].mulpotro;
                        KhosraAttachmentButton(noteKhshraWaitingList.data.records[0].basic.potro_pages);



                        if (noteKhshraWaitingList.data.records[i].mulpotro.potro_description != null)
                        {

                            string DecodedString = noteKhshraWaitingList.data.records[i].mulpotro.potro_description;
                            khosraViewWebBrowser.DocumentText = Base64Decode1(DecodedString);
                        }

                    }
                }

                if (noteKhshraWaitingList.data.total_records == i || noteKhshraWaitingList.data.total_records - 1 == i)
                {
                    i = 0;
                    allNextButtonVisibilityOff();
                    allPreviousButtonVisibilityOff();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }

        }
        private void NoteKhoshraWaitingPrevious_Click(object sender, EventArgs e)
        {
            i--;
            if (i == 0)
            {
                pnlPotrangshoDetails.Visible = true;
                lbPotroSubject.Text = noteKhshraWaitingList.data.records[i].basic.potro_subject;
                lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + noteKhshraWaitingList.data.records[i].basic.created;
                lbNoteId.Text = "নোটঃ " + string.Concat(noteKhshraWaitingList.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                lbSubjectSmall.Text = "পত্র: " + noteKhshraWaitingList.data.records[i].basic.potro_subject;
                lbTotal.Text = "সর্বমোট: " + string.Concat(noteKhshraWaitingList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                allMulpotroButtonsVisibilityOff();
                int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                    endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                foreach (string btnName in noteKhshraWaitingList.data.records[i].mulpotro.buttonsDTOList)
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

                if (noteKhshraWaitingList.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    NoteKhoshraWaitingNext.Visible = true;

                    allPreviousButtonVisibilityOff();
                    if (noteKhshraWaitingList.data.records[i].mulpotro.potro_description != null)
                    {
                        string DecodedString = noteKhshraWaitingList.data.records[i].mulpotro.potro_description;
                        khosraViewWebBrowser.DocumentText = Base64Decode1(DecodedString);
                    }
                }
            }
            if (noteKhshraWaitingList.data.total_records != i && i > 0)
            {
                pnlPotrangshoDetails.Visible = true;
                lbPotroSubject.Text = noteKhshraWaitingList.data.records[i].basic.potro_subject;
                lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + noteKhshraWaitingList.data.records[i].basic.created;
                lbNoteId.Text = "নোটঃ " + string.Concat(noteKhshraWaitingList.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                lbSubjectSmall.Text = "পত্র: " + noteKhshraWaitingList.data.records[i].basic.potro_subject;
                lbTotal.Text = "সর্বমোট: " + string.Concat(noteKhshraWaitingList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                allMulpotroButtonsVisibilityOff();
                int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                    endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                foreach (string btnName in noteKhshraWaitingList.data.records[i].mulpotro.buttonsDTOList)
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

                if (noteKhshraWaitingList.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    NoteKhoshraWaitingNext.Visible = true;

                    allPreviousButtonVisibilityOff();
                    NoteKhoshraWaitingPrevious.Visible = true;

                    if (noteKhshraWaitingList.data.records[i].mulpotro.potro_description != null)
                    {
                        string DecodedString = noteKhshraWaitingList.data.records[i].mulpotro.potro_description;
                        khosraViewWebBrowser.DocumentText = Base64Decode1(DecodedString);
                    }
                }
            }
            if (noteKhshraWaitingList.data.total_records < 0 || i < 0)
            {
                i = 0;
                allPreviousButtonVisibilityOff();
            }
        }
        private void NoteKhoshraWaitingNext_Click(object sender, EventArgs e)
        {
            i++;
            if (noteKhshraWaitingList.data.total_records != i && i > 0)
            {
                pnlPotrangshoDetails.Visible = true;
                lbPotroSubject.Text = noteKhshraWaitingList.data.records[i].basic.potro_subject;
                lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + noteKhshraWaitingList.data.records[i].basic.created;
                lbNoteId.Text = "নোটঃ " + string.Concat(noteKhshraWaitingList.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                lbSubjectSmall.Text = "পত্র: " + noteKhshraWaitingList.data.records[i].basic.potro_subject;
                lbTotal.Text = "সর্বমোট: " + string.Concat(noteKhshraWaitingList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                allMulpotroButtonsVisibilityOff();
                int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                    endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                foreach (string btnName in noteKhshraWaitingList.data.records[i].mulpotro.buttonsDTOList)
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

                if (noteKhshraWaitingList.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    NoteKhoshraWaitingNext.Visible = true;

                    allPreviousButtonVisibilityOff();
                    NoteKhoshraWaitingPrevious.Visible = true;

                    if (noteKhshraWaitingList.data.records[i].mulpotro.potro_description != null)
                    {
                        current_potro_id = noteKhshraWaitingList.data.records[i].basic.nothi_potro_id;
                        string DecodedString = noteKhshraWaitingList.data.records[i].mulpotro.potro_description;
                        khosraViewWebBrowser.DocumentText = Base64Decode1(DecodedString);
                    }
                }
            }
            if (noteKhshraWaitingList.data.total_records == i || noteKhshraWaitingList.data.total_records - 1 == i)
            {
                //i = 0;
                allNextButtonVisibilityOff();
            }
        }

        NotePotrojariResponse notePotrojariList = new NotePotrojariResponse();
        private void lbNotePotrojari_Click(object sender, EventArgs e)
        {
            try
            {
                current_potro_id = 0;
                allLbelButtonPreviousColor();
                lbNotePotrojari.BackColor = Color.FromArgb(14, 102, 98);
                lbNotePotrojari.ForeColor = Color.FromArgb(191, 239, 237);

                allNextButtonVisibilityOff();
                NotePotrojariNext.Visible = true;

                notePotrojariList = _notePotrojariList.GetPotrojariListInfo(_dakuserparam, nothiListRecords.id, notelist.nothi_note_id);
                if (notePotrojariList.status == "success")
                {
                    i = 0;
                    pnlPotrangshoDetails.Visible = true;
                    lbPotroSubject.Text = notePotrojariList.data.records[i].basic.potro_subject;
                    lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + notePotrojariList.data.records[i].basic.created;
                    lbNoteId.Text = "নোটঃ " + string.Concat(notePotrojariList.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    lbSubjectSmall.Text = "পত্র: " + notePotrojariList.data.records[i].basic.potro_subject;
                    lbTotal.Text = "সর্বমোট: " + string.Concat(notePotrojariList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                    allMulpotroButtonsVisibilityOff();
                    int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                        endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                    foreach (string btnName in notePotrojariList.data.records[i].mulpotro.buttonsDTOList)
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

                    if (notePotrojariList.data.total_records > 0)
                    {
                        allNextButtonVisibilityOff();
                        NotePotrojariNext.Visible = true;

                        allPreviousButtonVisibilityOff();

                        if (notePotrojariList.data.records[i].mulpotro.url != "")
                        {
                            picBoxFile.Visible = false;
                            khosraViewWebBrowser.Url = new Uri(notePotrojariList.data.records[i].mulpotro.url);
                        }
                        else
                        {
                            picBoxFile.Controls.Clear();
                        }

                    }
                }

                if (notePotrojariList.data.total_records == i || notePotrojariList.data.total_records - 1 == i)
                {
                    i = 0;
                    allNextButtonVisibilityOff();
                    allPreviousButtonVisibilityOff();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }

        }
        private void NotePotrojariPrevious_Click(object sender, EventArgs e)
        {
            i--;
            if (i == 0)
            {

                current_potro_id = 0;
                _khoshraPotroWaitinDataRecordDTO = null;
                khoshraPotroWaitinDataRecordMulpotroDTO = null;


                pnlPotrangshoDetails.Visible = true;
                lbPotroSubject.Text = notePotrojariList.data.records[i].basic.potro_subject;
                lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + notePotrojariList.data.records[i].basic.created;
                lbNoteId.Text = "নোটঃ " + string.Concat(notePotrojariList.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                lbSubjectSmall.Text = "পত্র: " + notePotrojariList.data.records[i].basic.potro_subject;
                lbTotal.Text = "সর্বমোট: " + string.Concat(notePotrojariList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                allMulpotroButtonsVisibilityOff();
                int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                    endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                foreach (string btnName in notePotrojariList.data.records[i].mulpotro.buttonsDTOList)
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

                if (notePotrojariList.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    NotePotrojariNext.Visible = true;

                    allPreviousButtonVisibilityOff();

                    if (notePotrojariList.data.records[i].mulpotro.url != "")
                    {
                        current_potro_id = noteKhshraWaitingList.data.records[0].basic.id;
                        _khoshraPotroWaitinDataRecordDTO = noteKhshraWaitingList.data.records[0];
                        khoshraPotroWaitinDataRecordMulpotroDTO = noteKhshraWaitingList.data.records[0].mulpotro;

                        picBoxFile.Visible = false;
                        khosraViewWebBrowser.Url = new Uri(notePotrojariList.data.records[i].mulpotro.url);
                    }
                    else
                    {
                        picBoxFile.Controls.Clear();
                    }

                }
            }
            if (notePotrojariList.data.total_records != i && i > 0)
            {
                pnlPotrangshoDetails.Visible = true;
                lbPotroSubject.Text = notePotrojariList.data.records[i].basic.potro_subject;
                lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + notePotrojariList.data.records[i].basic.created;
                lbNoteId.Text = "নোটঃ " + string.Concat(notePotrojariList.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                lbSubjectSmall.Text = "পত্র: " + notePotrojariList.data.records[i].basic.potro_subject;
                lbTotal.Text = "সর্বমোট: " + string.Concat(notePotrojariList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                allMulpotroButtonsVisibilityOff();
                int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                    endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                foreach (string btnName in notePotrojariList.data.records[i].mulpotro.buttonsDTOList)
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

                if (noteKhshraWaitingList.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    NotePotrojariNext.Visible = true;

                    allPreviousButtonVisibilityOff();
                    NotePotrojariPrevious.Visible = true;

                    if (notePotrojariList.data.records[i].mulpotro.url != "")
                    {
                        picBoxFile.Visible = false;
                        khosraViewWebBrowser.Url = new Uri(notePotrojariList.data.records[i].mulpotro.url);
                    }
                    else
                    {
                        picBoxFile.Controls.Clear();
                    }
                }
            }
            if (notePotrojariList.data.total_records < 0 || i < 0)
            {
                i = 0;
                allPreviousButtonVisibilityOff();
            }
        }
        private void NotePotrojariNext_Click(object sender, EventArgs e)
        {
            i++;
            if (notePotrojariList.data.total_records != i && i > 0)
            {
                current_potro_id = 0;
                _khoshraPotroWaitinDataRecordDTO = null;
                khoshraPotroWaitinDataRecordMulpotroDTO = null;



                pnlPotrangshoDetails.Visible = true;
                lbPotroSubject.Text = notePotrojariList.data.records[i].basic.potro_subject;
                lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + notePotrojariList.data.records[i].basic.created;
                lbNoteId.Text = "নোটঃ " + string.Concat(notePotrojariList.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                lbSubjectSmall.Text = "পত্র: " + notePotrojariList.data.records[i].basic.potro_subject;
                lbTotal.Text = "সর্বমোট: " + string.Concat(notePotrojariList.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                allMulpotroButtonsVisibilityOff();
                int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                    endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                foreach (string btnName in notePotrojariList.data.records[i].mulpotro.buttonsDTOList)
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

                if (noteKhshraWaitingList.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    NotePotrojariNext.Visible = true;

                    allPreviousButtonVisibilityOff();
                    NotePotrojariPrevious.Visible = true;

                    if (notePotrojariList.data.records[i].mulpotro.url != "")
                    {

                        current_potro_id = noteKhshraWaitingList.data.records[0].basic.id;
                        _khoshraPotroWaitinDataRecordDTO = noteKhshraWaitingList.data.records[0];
                        khoshraPotroWaitinDataRecordMulpotroDTO = noteKhshraWaitingList.data.records[0].mulpotro;

                        picBoxFile.Visible = false;
                        khosraViewWebBrowser.Url = new Uri(notePotrojariList.data.records[i].mulpotro.url);
                    }
                    else
                    {
                        picBoxFile.Controls.Clear();
                    }
                }
            }
            if (notePotrojariList.data.total_records == i || notePotrojariList.data.total_records - 1 == i)
            {
                //i = 0;
                allNextButtonVisibilityOff();
            }
        }

        NothivuktoPotroResponse noteNothivuktoPotroResponse = new NothivuktoPotroResponse();
        private void lbNoteNothivuktoPotro_Click(object sender, EventArgs e)
        {
            try
            {
                allLbelButtonPreviousColor();
                lbNoteNothivuktoPotro.BackColor = Color.FromArgb(14, 102, 98);
                lbNoteNothivuktoPotro.ForeColor = Color.FromArgb(191, 239, 237);

                allNextButtonVisibilityOff();
                btnNoteNothivuktoPotroNext.Visible = true;

                noteNothivuktoPotroResponse = _nothivuktoPotro.GetNoteNothivuktoPotroInfo(_dakuserparam, nothiListRecords.id, notelist.nothi_note_id);
                if (noteNothivuktoPotroResponse.status == "success")
                {
                    i = 0;
                    int index = 0;
                    pnlPotrangshoDetails.Visible = true;
                    if (noteNothivuktoPotroResponse.data.total_records > 0)
                    {
                        allNextButtonVisibilityOff();
                        btnNoteNothivuktoPotroNext.Visible = true;

                        allPreviousButtonVisibilityOff();

                        if (noteNothivuktoPotroResponse.data.records[i].basic.page_numbers.Contains(","))
                        {
                            index = noteNothivuktoPotroResponse.data.records[i].basic.page_numbers.IndexOf(",");
                        }
                        int totalLength = noteNothivuktoPotroResponse.data.records[i].basic.page_numbers.Length;
                        lbPotroSubject.Text = noteNothivuktoPotroResponse.data.records[i].basic.subject + "(পাতা:" + string.Concat(noteNothivuktoPotroResponse.data.records[i].basic.page_numbers.Substring(0, index).ToString().Select(c => (char)('\u09E6' + c - '0'))) + "-" + string.Concat(noteNothivuktoPotroResponse.data.records[i].basic.page_numbers.Substring(index + 1).ToString().Select(c => (char)('\u09E6' + c - '0'))) + ")";
                        lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + noteNothivuktoPotroResponse.data.records[i].basic.due_date;
                        lbSubjectSmall.Text = "পত্র: " + noteNothivuktoPotroResponse.data.records[i].basic.subject;
                        lbNoteId.Text = "নোটঃ " + string.Concat(noteNothivuktoPotroResponse.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        lbTotal.Text = "সর্বমোট: " + string.Concat(noteNothivuktoPotroResponse.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                        allMulpotroButtonsVisibilityOff();
                        int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                            endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                        foreach (string btnName in noteNothivuktoPotroResponse.data.records[i].mulpotro.buttonsDTOList)
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

                        if (noteNothivuktoPotroResponse.data.records[i].mulpotro.is_main == 1)
                        {
                            pnlMulPotroOShonjukti.Visible = true;
                            lbMulPotroOShonjukti.Visible = true;
                            btnMulPotroOShonjukti.Visible = true;

                            btnMulPotroOShonjukti.Text = string.Concat(noteNothivuktoPotroResponse.data.records[i].basic.potro_pages.ToString().Select(c => (char)('\u09E6' + c - '0')));
                        }
                        else
                        {
                            mulpotroOshongjuktiVisibilityOff();
                        }

                        totalRange = (i + 1).ToString();
                        if (noteNothivuktoPotroResponse.data.records[i].mulpotro.url != "")
                        {
                            picBoxFile.Visible = false;
                            khosraViewWebBrowser.Url = new Uri(noteNothivuktoPotroResponse.data.records[i].mulpotro.url);
                        }
                        else
                        {
                            picBoxFile.Controls.Clear();
                        }
                    }
                }
                if (noteNothivuktoPotroResponse.data.total_records == i || noteNothivuktoPotroResponse.data.total_records - 1 == i)
                {
                    i = 0;
                    allNextButtonVisibilityOff();
                    allPreviousButtonVisibilityOff();

                }
            }
            catch (Exception ex)
            {
                ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }
        }

        private void btnNoteNothivuktoPotroNext_Click(object sender, EventArgs e)
        {
            i++;
            if (noteNothivuktoPotroResponse.data.total_records != i && i > 0)
            {
                int index = 0;
                pnlPotrangshoDetails.Visible = true;
                if (noteNothivuktoPotroResponse.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    btnNoteNothivuktoPotroNext.Visible = true;

                    allPreviousButtonVisibilityOff();
                    btnNoteNothivuktoPotroPrevious.Visible = true;

                    if (noteNothivuktoPotroResponse.data.records[i].basic.page_numbers.Contains(","))
                    {
                        index = noteNothivuktoPotroResponse.data.records[i].basic.page_numbers.IndexOf(",");
                    }
                    int totalLength = noteNothivuktoPotroResponse.data.records[i].basic.page_numbers.Length;
                    lbPotroSubject.Text = noteNothivuktoPotroResponse.data.records[i].basic.subject + "(পাতা:" + string.Concat(noteNothivuktoPotroResponse.data.records[i].basic.page_numbers.Substring(0, index).ToString().Select(c => (char)('\u09E6' + c - '0'))) + "-" + string.Concat(noteNothivuktoPotroResponse.data.records[i].basic.page_numbers.Substring(index + 1).ToString().Select(c => (char)('\u09E6' + c - '0'))) + ")";
                    lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + noteNothivuktoPotroResponse.data.records[i].basic.due_date;
                    lbSubjectSmall.Text = "পত্র: " + noteNothivuktoPotroResponse.data.records[i].basic.subject;
                    lbNoteId.Text = "নোটঃ " + string.Concat(noteNothivuktoPotroResponse.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    lbTotal.Text = "সর্বমোট: " + string.Concat(noteNothivuktoPotroResponse.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                    allMulpotroButtonsVisibilityOff();
                    int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                        endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                    foreach (string btnName in noteNothivuktoPotroResponse.data.records[i].mulpotro.buttonsDTOList)
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

                    if (noteNothivuktoPotroResponse.data.records[i].mulpotro.is_main == 1)
                    {
                        pnlMulPotroOShonjukti.Visible = true;
                        lbMulPotroOShonjukti.Visible = true;
                        btnMulPotroOShonjukti.Visible = true;

                        btnMulPotroOShonjukti.Text = string.Concat(noteNothivuktoPotroResponse.data.records[i].basic.potro_pages.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        mulpotroOshongjuktiVisibilityOff();
                    }

                    totalRange = (i + 1).ToString();
                    if (noteNothivuktoPotroResponse.data.records[i].mulpotro.url != "")
                    {
                        picBoxFile.Visible = false;
                        khosraViewWebBrowser.Url = new Uri(noteNothivuktoPotroResponse.data.records[i].mulpotro.url);
                    }
                    else
                    {
                        picBoxFile.Controls.Clear();
                    }
                }
            }
            if (noteNothivuktoPotroResponse.data.total_records == i || noteNothivuktoPotroResponse.data.total_records - 1 == i)
            {
                //i = 0;
                allNextButtonVisibilityOff();
            }
        }

        private void btnNoteNothivuktoPotroPrevious_Click(object sender, EventArgs e)
        {
            i--;
            if (i == 0)
            {
                int index = 0;
                pnlPotrangshoDetails.Visible = true;
                if (noteNothivuktoPotroResponse.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    btnNoteNothivuktoPotroNext.Visible = true;

                    allPreviousButtonVisibilityOff();

                    if (noteNothivuktoPotroResponse.data.records[i].basic.page_numbers.Contains(","))
                    {
                        index = noteNothivuktoPotroResponse.data.records[i].basic.page_numbers.IndexOf(",");
                    }
                    int totalLength = noteNothivuktoPotroResponse.data.records[i].basic.page_numbers.Length;
                    lbPotroSubject.Text = noteNothivuktoPotroResponse.data.records[i].basic.subject + "(পাতা:" + string.Concat(noteNothivuktoPotroResponse.data.records[i].basic.page_numbers.Substring(0, index).ToString().Select(c => (char)('\u09E6' + c - '0'))) + "-" + string.Concat(noteNothivuktoPotroResponse.data.records[i].basic.page_numbers.Substring(index + 1).ToString().Select(c => (char)('\u09E6' + c - '0'))) + ")";
                    lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + noteNothivuktoPotroResponse.data.records[i].basic.due_date;
                    lbSubjectSmall.Text = "পত্র: " + noteNothivuktoPotroResponse.data.records[i].basic.subject;
                    lbNoteId.Text = "নোটঃ " + string.Concat(noteNothivuktoPotroResponse.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    lbTotal.Text = "সর্বমোট: " + string.Concat(noteNothivuktoPotroResponse.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                    allMulpotroButtonsVisibilityOff();
                    int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                        endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                    foreach (string btnName in noteNothivuktoPotroResponse.data.records[i].mulpotro.buttonsDTOList)
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

                    if (noteNothivuktoPotroResponse.data.records[i].mulpotro.is_main == 1)
                    {
                        pnlMulPotroOShonjukti.Visible = true;
                        lbMulPotroOShonjukti.Visible = true;
                        btnMulPotroOShonjukti.Visible = true;

                        btnMulPotroOShonjukti.Text = string.Concat(noteNothivuktoPotroResponse.data.records[i].basic.potro_pages.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        mulpotroOshongjuktiVisibilityOff();
                    }

                    totalRange = (i + 1).ToString();
                    if (noteNothivuktoPotroResponse.data.records[i].mulpotro.url != "")
                    {
                        picBoxFile.Visible = false;
                        khosraViewWebBrowser.Url = new Uri(noteNothivuktoPotroResponse.data.records[i].mulpotro.url);
                    }
                    else
                    {
                        picBoxFile.Controls.Clear();
                    }
                }
            }
            if (noteNothivuktoPotroResponse.data.total_records != i && i > 0)
            {
                int index = 0;
                pnlPotrangshoDetails.Visible = true;
                if (noteNothivuktoPotroResponse.data.total_records > 0)
                {
                    allNextButtonVisibilityOff();
                    btnNoteNothivuktoPotroNext.Visible = true;

                    allPreviousButtonVisibilityOff();
                    btnNoteNothivuktoPotroPrevious.Visible = true;

                    if (noteNothivuktoPotroResponse.data.records[i].basic.page_numbers.Contains(","))
                    {
                        index = noteNothivuktoPotroResponse.data.records[i].basic.page_numbers.IndexOf(",");
                    }
                    int totalLength = noteNothivuktoPotroResponse.data.records[i].basic.page_numbers.Length;
                    lbPotroSubject.Text = noteNothivuktoPotroResponse.data.records[i].basic.subject + "(পাতা:" + string.Concat(noteNothivuktoPotroResponse.data.records[i].basic.page_numbers.Substring(0, index).ToString().Select(c => (char)('\u09E6' + c - '0'))) + "-" + string.Concat(noteNothivuktoPotroResponse.data.records[i].basic.page_numbers.Substring(index + 1).ToString().Select(c => (char)('\u09E6' + c - '0'))) + ")";
                    lbLastIssueDate.Text = "সর্বশেষ মুদ্রণের তারিখ :" + noteNothivuktoPotroResponse.data.records[i].basic.due_date;
                    lbSubjectSmall.Text = "পত্র: " + noteNothivuktoPotroResponse.data.records[i].basic.subject;
                    lbNoteId.Text = "নোটঃ " + string.Concat(noteNothivuktoPotroResponse.data.records[i].note_owner.note_no.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    lbTotal.Text = "সর্বমোট: " + string.Concat(noteNothivuktoPotroResponse.data.total_records.ToString().Select(c => (char)('\u09E6' + c - '0')));

                    allMulpotroButtonsVisibilityOff();
                    int draft_history = 0, clone = 0, edit = 0, delete = 0, approve = 0, unapprove = 0, potrojari = 0,
                        endrosement = 0, khoshra = 0, fulleditable = 0, custom = 0;
                    foreach (string btnName in noteNothivuktoPotroResponse.data.records[i].mulpotro.buttonsDTOList)
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

                    if (noteNothivuktoPotroResponse.data.records[i].mulpotro.is_main == 1)
                    {
                        pnlMulPotroOShonjukti.Visible = true;
                        lbMulPotroOShonjukti.Visible = true;
                        btnMulPotroOShonjukti.Visible = true;

                        btnMulPotroOShonjukti.Text = string.Concat(noteNothivuktoPotroResponse.data.records[i].basic.potro_pages.ToString().Select(c => (char)('\u09E6' + c - '0')));
                    }
                    else
                    {
                        mulpotroOshongjuktiVisibilityOff();
                    }

                    totalRange = (i + 1).ToString();
                    if (noteNothivuktoPotroResponse.data.records[i].mulpotro.url != "")
                    {
                        picBoxFile.Visible = false;
                        khosraViewWebBrowser.Url = new Uri(noteNothivuktoPotroResponse.data.records[i].mulpotro.url);
                    }
                    else
                    {
                        picBoxFile.Controls.Clear();
                    }
                }
            }
            if (noteNothivuktoPotroResponse.data.total_records < 0 || i < 0)
            {
                i = 0;
                allPreviousButtonVisibilityOff();
            }
        }



        private void btnCanRevert_Click(object sender, EventArgs e)
        {
            newnotedata.note_subject = checkSub;
            newnotedata.note_id = checkNoteId;
            NoteOnucchedRevertResPonse noteOnucchedRevert = _noteOnucchedRevert.GetNoteOnucchedRevert(_dakuserparam, nothiListRecords, newnotedata);
            if (noteOnucchedRevert.status == "success")
            {
                SuccessMessage(noteOnucchedRevert.data);
                foreach (Form f in Application.OpenForms)
                { BeginInvoke((Action)(() => f.Hide())); }
                loadNote();
                //newNoteView.CheckBoxClick += delegate (object sender1, EventArgs e1) { checkBox_Click(sender1 as NoteListDataRecordNoteDTO, e1, newNoteView); };

                //newNoteView.CheckBoxClick += delegate (object sender1, EventArgs e1) { checkBox_Change(_NoteAllListDataRecordDTO, newNoteView, newNoteView._checkBoxValue); };
                //lbNothiType.Text = "বাছাইকৃত নোট (১)";
                //noteViewFLP.Controls.Clear();
                //newNoteView.checkcbNote();
                //noteViewFLP.Controls.Add(newNoteView);

            }
        }
        private void loadNote()
        {
            var eachNothiId = nothiListRecords.id;
            var nothiListUserParam = _userService.GetLocalDakUserParam();
            string note_category = "all";
            var nothiInboxNote = _nothiAllNote.GetNothiAllNote(nothiListUserParam, eachNothiId.ToString(), note_category);
            if (nothiInboxNote != null && nothiInboxNote.status == "success")
            {
                foreach (NothiListInboxNoteRecordsDTO nothiListInboxNoteRecordsDTO in nothiInboxNote.data.records)
                {
                    if (nothiListInboxNoteRecordsDTO.note.nothi_note_id == _NoteAllListDataRecordDTO.note.nothi_note_id)
                    { _NoteAllListDataRecordDTO = nothiListInboxNoteRecordsDTO; }
                }
            }
            var form = FormFactory.Create<Note>();
            form.NoteBackButton += delegate (object sender1, EventArgs e1) {
                foreach (Form f in Application.OpenForms)
                { BeginInvoke((Action)(() => f.Hide())); }
                var nothi = FormFactory.Create<Nothi>();
                nothi.TopMost = true;
                nothi.LoadNothiInboxButton(sender1, e1);
                BeginInvoke((Action)(() => nothi.ShowDialog()));
                BeginInvoke((Action)(() => nothi.TopMost = false));
                nothi.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };
            };
            form.noteIdfromNothiInboxNoteShomuho = _noteIdfromNothiInboxNoteShomuho;

            form.nothiNo = _nothiNo;
            form.nothiShakha = _nothiShakha;
            form.nothiSubject = _nothiSubject;
            form.noteSubject = noteSubject;
            form.nothiLastDate = _nothiLastDate;
            form.noteAllListDataRecordDTO = _NoteAllListDataRecordDTO;

            form.office = _office;


            form.loadNothiInboxRecords(nothiListRecords);
            form.loadNoteView(newNoteView);
            form.noteTotal = noteTotal;
            form.loadInboxCBXNothiType();
            form.TopMost = true;
            BeginInvoke((Action)(() => form.ShowDialog()));
            BeginInvoke((Action)(() => form.TopMost = false));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };
        }
        private void pdfViewWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void Note_Load(object sender, EventArgs e)
        {
            //
            //_Click(_NoteAllListDataRecordDTO, newNoteView);
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
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        private void nothiModulePanel_Paint(object sender, PaintEventArgs e)
        {
            //GraphicsPath path = Roundedrectangle.Create(0, 0, nothiModulePanel.Width - 2, nothiModulePanel.Height - 2);
            //e.Graphics.DrawPath(new Pen(Color.FromArgb(203, 225, 248)), path);
            //ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

            SolidBrush Brush = new SolidBrush(Color.FromArgb(245, 245, 249));
            GraphicsPath path = Roundedrectangle.Create(0, 0, nothiModulePanel.Width - 2, nothiModulePanel.Height - 2);
            e.Graphics.DrawPath(new Pen(Color.FromArgb(203, 225, 248)), path);
            GraphicsPath path1 = Roundedrectangle.Create(1, 1, nothiModulePanel.Width - 3, nothiModulePanel.Height - 3);
            e.Graphics.FillPath(Brush, path1);

        }

        private void userNameLabel_Click_1(object sender, EventArgs e)
        {
            if (designationDetailsPanelNothi.Width == 434 && !designationDetailsPanelNothi.Visible)
            {
                designationDetailsPanelNothi.Visible = true;
                //   designationDetailsPanelNothi.designationLinkText = _dakuserparam.designation_label + "," + _dakuserparam.unit_label + "," + _dakuserparam.office_label;
                designationDetailsPanelNothi.Location = new System.Drawing.Point(Screen.PrimaryScreen.WorkingArea.Width - designationDetailsPanelNothi.Width, profilePanel.Height);
                Controls.Add(designationDetailsPanelNothi);
                designationDetailsPanelNothi.BringToFront();
                designationDetailsPanelNothi.Width = 427;
                designationDetailsPanelNothi.officeInfos = _userService.GetAllLocalOfficeInfo();

            }
            else
            {
                designationDetailsPanelNothi.Visible = false;
                designationDetailsPanelNothi.Width = 434;
            }
        }

        private void userNameLabel_MouseHover(object sender, EventArgs e)
        {
            profilePanel.BackColor = Color.FromArgb(245, 245, 249);
        }

        private void userNameLabel_MouseLeave(object sender, EventArgs e)
        {
            profilePanel.BackColor = Color.Transparent;
        }


        private void iconButton18_MouseHover(object sender, EventArgs e)
        {
            iconButton18.IconColor = Color.FromArgb(246, 78, 96);
            iconButton18.BackColor = Color.FromArgb(228, 230, 239);
        }

        private void iconButton18_MouseLeave(object sender, EventArgs e)
        {
            iconButton18.IconColor = Color.FromArgb(54, 153, 255);
            iconButton18.BackColor = Color.FromArgb(243, 246, 249);
        }

        private void iconButton17_MouseHover(object sender, EventArgs e)
        {
            btnNothiNoteMovementList.IconColor = Color.FromArgb(246, 78, 96);
            btnNothiNoteMovementList.BackColor = Color.FromArgb(228, 230, 239);
        }

        private void iconButton17_MouseLeave(object sender, EventArgs e)
        {
            btnNothiNoteMovementList.IconColor = Color.FromArgb(54, 153, 255);
            btnNothiNoteMovementList.BackColor = Color.FromArgb(243, 246, 249);
        }

        private void iconButton16_MouseHover(object sender, EventArgs e)
        {
            iconButton16.IconColor = Color.FromArgb(246, 78, 96);
            iconButton16.BackColor = Color.FromArgb(228, 230, 239);
        }

        private void iconButton16_MouseLeave(object sender, EventArgs e)
        {
            iconButton16.IconColor = Color.FromArgb(54, 153, 255);
            iconButton16.BackColor = Color.FromArgb(243, 246, 249);
        }

        private void iconButton15_MouseHover(object sender, EventArgs e)
        {
            iconButton15.IconColor = Color.FromArgb(246, 78, 96);
            iconButton15.BackColor = Color.FromArgb(228, 230, 239);
        }

        private void iconButton15_MouseLeave(object sender, EventArgs e)
        {
            iconButton15.IconColor = Color.FromArgb(54, 153, 255);
            iconButton15.BackColor = Color.FromArgb(243, 246, 249);
        }

        private void iconButton13_MouseHover(object sender, EventArgs e)
        {
            btnNothiOnumodonList.IconColor = Color.FromArgb(246, 78, 96);
            btnNothiOnumodonList.BackColor = Color.FromArgb(228, 230, 239);
        }

        private void iconButton13_MouseLeave(object sender, EventArgs e)
        {
            btnNothiOnumodonList.IconColor = Color.FromArgb(54, 153, 255);
            btnNothiOnumodonList.BackColor = Color.FromArgb(243, 246, 249);
        }

        private void iconButton10_MouseHover(object sender, EventArgs e)
        {
            btnAllAttachement.IconColor = Color.FromArgb(246, 78, 96);
            btnAllAttachement.BackColor = Color.FromArgb(228, 230, 239);
        }

        private void iconButton10_MouseLeave(object sender, EventArgs e)
        {
            btnAllAttachement.IconColor = Color.FromArgb(54, 153, 255);
            btnAllAttachement.BackColor = Color.FromArgb(243, 246, 249);
        }

        private void iconButton3_MouseHover(object sender, EventArgs e)
        {
            btnCollapseExpand.IconColor = Color.FromArgb(246, 78, 96);
            btnCollapseExpand.BackColor = Color.FromArgb(228, 230, 239);
        }

        private void iconButton3_MouseLeave(object sender, EventArgs e)
        {
            btnCollapseExpand.IconColor = Color.FromArgb(54, 153, 255);
            btnCollapseExpand.BackColor = Color.FromArgb(243, 246, 249);
        }
        private static Pen _dashedPen = new Pen(Color.FromArgb(63, 66, 84), 1);

        private void splitter1_Paint(object sender, PaintEventArgs e)
        {
            Splitter s = sender as Splitter;
            int gripLineWidth = 9;
            _dashedPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            e.Graphics.DrawLine(_dashedPen, ((s.ClientRectangle.Width / 2) - (gripLineWidth / 2)), ((s.Height / 2) - 12) + s.Width / 2, ((s.ClientRectangle.Width / 2) + (gripLineWidth / 2)), ((s.Height / 2) - 12) + s.Width / 2);
            e.Graphics.DrawLine(_dashedPen, ((s.ClientRectangle.Width / 2) - (gripLineWidth / 2)), ((s.Height / 2) - 9) + s.Width / 2, ((s.ClientRectangle.Width / 2) + (gripLineWidth / 2)), ((s.Height / 2) - 9) + s.Width / 2);
            e.Graphics.DrawLine(_dashedPen, ((s.ClientRectangle.Width / 2) - (gripLineWidth / 2)), ((s.Height / 2) - 6) + s.Width / 2, ((s.ClientRectangle.Width / 2) + (gripLineWidth / 2)), ((s.Height / 2) - 6) + s.Width / 2);
            e.Graphics.DrawLine(_dashedPen, ((s.ClientRectangle.Width / 2) - (gripLineWidth / 2)), ((s.Height / 2) - 3) + s.Width / 2, ((s.ClientRectangle.Width / 2) + (gripLineWidth / 2)), ((s.Height / 2) - 3) + s.Width / 2);
            e.Graphics.DrawLine(_dashedPen, ((s.ClientRectangle.Width / 2) - (gripLineWidth / 2)), (s.Height / 2) + s.Width / 2, ((s.ClientRectangle.Width / 2) + (gripLineWidth / 2)), (s.Height / 2) + s.Width / 2);
            e.Graphics.DrawLine(_dashedPen, ((s.ClientRectangle.Width / 2) - (gripLineWidth / 2)), ((s.Height / 2) + 3) + s.Width / 2, ((s.ClientRectangle.Width / 2) + (gripLineWidth / 2)), ((s.Height / 2) + 3) + s.Width / 2);
            e.Graphics.DrawLine(_dashedPen, ((s.ClientRectangle.Width / 2) - (gripLineWidth / 2)), ((s.Height / 2) + 6) + s.Width / 2, ((s.ClientRectangle.Width / 2) + (gripLineWidth / 2)), ((s.Height / 2) + 6) + s.Width / 2);
            e.Graphics.DrawLine(_dashedPen, ((s.ClientRectangle.Width / 2) - (gripLineWidth / 2)), ((s.Height / 2) + 9) + s.Width / 2, ((s.ClientRectangle.Width / 2) + (gripLineWidth / 2)), ((s.Height / 2) + 9) + s.Width / 2);
            e.Graphics.DrawLine(_dashedPen, ((s.ClientRectangle.Width / 2) - (gripLineWidth / 2)), ((s.Height / 2) + 12) + s.Width / 2, ((s.ClientRectangle.Width / 2) + (gripLineWidth / 2)), ((s.Height / 2) + 12) + s.Width / 2);
        }

        private void splitter3_Paint(object sender, PaintEventArgs e)
        {
            Splitter s = sender as Splitter;
            int gripLineWidth = 9;
            _dashedPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            e.Graphics.DrawLine(_dashedPen, ((s.Width / 2) - 12) + s.Height / 2, ((s.ClientRectangle.Height / 2) - (gripLineWidth / 2)), ((s.Width / 2) - 12) + s.Height / 2, ((s.ClientRectangle.Height / 2) + (gripLineWidth / 2)));
            e.Graphics.DrawLine(_dashedPen, ((s.Width / 2) - 9) + s.Height / 2, ((s.ClientRectangle.Height / 2) - (gripLineWidth / 2)), ((s.Width / 2) - 9) + s.Height / 2, ((s.ClientRectangle.Height / 2) + (gripLineWidth / 2)));
            e.Graphics.DrawLine(_dashedPen, ((s.Width / 2) - 6) + s.Height / 2, ((s.ClientRectangle.Height / 2) - (gripLineWidth / 2)), ((s.Width / 2) - 6) + s.Height / 2, ((s.ClientRectangle.Height / 2) + (gripLineWidth / 2)));
            e.Graphics.DrawLine(_dashedPen, ((s.Width / 2) - 3) + s.Height / 2, ((s.ClientRectangle.Height / 2) - (gripLineWidth / 2)), ((s.Width / 2) - 3) + s.Height / 2, ((s.ClientRectangle.Height / 2) + (gripLineWidth / 2)));
            e.Graphics.DrawLine(_dashedPen, (s.Width / 2) + s.Height / 2, ((s.ClientRectangle.Height / 2) - (gripLineWidth / 2)), (s.Width / 2) + s.Height / 2, ((s.ClientRectangle.Height / 2) + (gripLineWidth / 2)));
            e.Graphics.DrawLine(_dashedPen, ((s.Width / 2) + 3) + s.Height / 2, ((s.ClientRectangle.Height / 2) - (gripLineWidth / 2)), ((s.Width / 2) + 3) + s.Height / 2, ((s.ClientRectangle.Height / 2) + (gripLineWidth / 2)));
            e.Graphics.DrawLine(_dashedPen, ((s.Width / 2) + 6) + s.Height / 2, ((s.ClientRectangle.Height / 2) - (gripLineWidth / 2)), ((s.Width / 2) + 6) + s.Height / 2, ((s.ClientRectangle.Height / 2) + (gripLineWidth / 2)));
            e.Graphics.DrawLine(_dashedPen, ((s.Width / 2) + 9) + s.Height / 2, ((s.ClientRectangle.Height / 2) - (gripLineWidth / 2)), ((s.Width / 2) + 9) + s.Height / 2, ((s.ClientRectangle.Height / 2) + (gripLineWidth / 2)));
            e.Graphics.DrawLine(_dashedPen, ((s.Width / 2) + 12) + s.Height / 2, ((s.ClientRectangle.Height / 2) - (gripLineWidth / 2)), ((s.Width / 2) + 12) + s.Height / 2, ((s.ClientRectangle.Height / 2) + (gripLineWidth / 2)));

        }
        public Form AttachNothiGuidelinesControlToForm(Control control)
        {
            Form form = new Form();

            form.StartPosition = FormStartPosition.Manual;
            form.FormBorderStyle = FormBorderStyle.None;
            form.BackColor = Color.White;

            form.AutoSize = true;
            form.Location = new System.Drawing.Point(785, 0);
            control.Location = new System.Drawing.Point(0, 0);
            form.Size = control.Size;
            form.Controls.Add(control);
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            return form;
        }
        public Form AttachPotrojariControlToForm(Control control)
        {
            Form form = new Form();

            form.StartPosition = FormStartPosition.Manual;
            form.FormBorderStyle = FormBorderStyle.None;
            form.BackColor = Color.White;

            form.AutoSize = true;
            form.Location = new System.Drawing.Point(233, 0);
            control.Location = new System.Drawing.Point(0, 0);
            form.Size = control.Size;
            form.Controls.Add(control);
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            return form;
        }
        private void btnNothiNoteMovementList_Click(object sender, EventArgs e)
        {
            NothiNoteMovementList form = new NothiNoteMovementList();
            var nothiNoteMovementListform = AttachNothiGuidelinesControlToForm(form);
            CalPopUpWindow(nothiNoteMovementListform);
        }

        private void btnAllAttachement_Click(object sender, EventArgs e)
        {
            NothiNoteAllAttachement form = new NothiNoteAllAttachement();
            var nothiNoteMovementListform = AttachNothiGuidelinesControlToForm(form);
            CalPopUpWindow(nothiNoteMovementListform);
        }

        private void btnCollapseExpand_Click(object sender, EventArgs e)
        {
            if (btnCollapseExpand.IconChar == FontAwesome.Sharp.IconChar.WindowMaximize)
            {
                noteTabpanel.Visible = false;
                panel2.Visible = false;
                pnlNoteList.Visible = false;
                panel15.Visible = false;
                potrangsoPanel.Visible = false;
                pnlNothiNoteTalika.Visible = false;
                CollapseExpandPanel.Size = this.Size;
                btnCollapseExpand.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            }
            else
            {
                noteTabpanel.Visible = true;
                panel2.Visible = true;
                pnlNoteList.Visible = true;
                panel15.Visible = true;
                potrangsoPanel.Visible = true;
                pnlNothiNoteTalika.Visible = true;
                CollapseExpandPanel.Height = _collapseExpandeHeight;
                CollapseExpandPanel.Width = _collapseExpandeWidth;
                btnCollapseExpand.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            }
        }

        private void btnNothiOnumodonList_Click(object sender, EventArgs e)
        {
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            var onumodonList = _onumodonService.GetOnumodonMembers(dakListUserParam, nothiListRecords);
            if (onumodonList.status == "success")
            {
                if (onumodonList.data.records.Count > 0)
                {
                    loadOnumodonList(onumodonList.data.records);
                }
            }
        }
        public void loadOnumodonList(List<onumodonDataRecordDTO> records)
        {
            OnumoditoPodobi onumoditoPodobi = new OnumoditoPodobi();
            onumoditoPodobi.GetNothiInboxRecords(records);
            var form = AttachNothiGuidelinesControlToForm(onumoditoPodobi);
            CalPopUpWindow(form);
        }

        private void btnPrapokerTalika_Click(object sender, EventArgs e)
        {
            if (_khoshraPotroWaitinDataRecordDTO != null)
            {
                current_potro_id = _khoshraPotroWaitinDataRecordDTO.basic.id;
            }
            else if (_khoshraPotroDataRecordDTO != null)
            {
                current_potro_id = _khoshraPotroDataRecordDTO.basic.id;
            }

            if (current_potro_id != 0)
            {
                DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                var prapakerTalika = _potrojariServices.GetPrapakerTalika(dakListUserParam, current_potro_id);
                if (prapakerTalika.status == "success")
                {

                    KhosraPrapokListViewForm khosraPrapokListViewForm = new KhosraPrapokListViewForm();
                    khosraPrapokListViewForm.prapakerTalika = prapakerTalika;
                    UIDesignCommonMethod.CalPopUpWindow(khosraPrapokListViewForm, this);
                }
            }

        }

        private void btnClone_Click(object sender, EventArgs e)
        {
            EditorCloneKhosra(true);
        }

        private void btnDraftHistory_Click(object sender, EventArgs e)
        {
            DraftHistory form = new DraftHistory();
            var nothiNoteMovementListform = AttachNothiGuidelinesControlToForm(form);
            CalPopUpWindow(nothiNoteMovementListform);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditorCloneKhosra(false);

        }

        private void btnPotrojari_Click(object sender, EventArgs e)
        {
            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = "আপনি কি পত্রটি জারি করতে চান?";
            conditonBoxForm.ShowDialog();
            if (conditonBoxForm.Yes)
            {
                Potrojari form = new Potrojari();
                form.loadPotrojariBrowser(khosraViewWebBrowser.DocumentText);
                form.PotrojariButtonClick += delegate (object ss, EventArgs ee) { SavePotrojari(form); };

                var nothiNoteMovementListform = AttachPotrojariControlToForm(form);


                CalPopUpWindow(nothiNoteMovementListform);
            }

        }

        private void SavePotrojari(Potrojari form)
        {
            if (_khoshraPotroDataRecordDTO != null)
            {
                _khoshraPotroWaitinDataRecordDTO = GetKhosraWaiting();
            }
            if (_khoshraPotroWaitinDataRecordDTO != null)
            {
                PotrojariParameter potrojariParameter = new PotrojariParameter();
                potrojariParameter.potrojari = new PotrojariSendInfo();
                // potrojariParameter.potrojari.attached_potro = _khoshraPotroWaitinDataRecordDTO.mulpotro.potro_description;
                potrojariParameter.potrojari.attachment_count = _khoshraPotroWaitinDataRecordDTO.basic.attachment_count.ToString();
                potrojariParameter.potrojari.cloned_potrojari_id = _khoshraPotroWaitinDataRecordDTO.basic.cloned_potrojari_id.ToString();
                potrojariParameter.potrojari.created = _khoshraPotroWaitinDataRecordDTO.basic.cloned_potrojari_id.ToString();
                potrojariParameter.potrojari.dak_id = _khoshraPotroWaitinDataRecordDTO.basic.dak_id.ToString();
                potrojariParameter.potrojari.dak_json = _khoshraPotroWaitinDataRecordDTO.basic.dak_json.ToString();
                potrojariParameter.potrojari.digital_sign = _khoshraPotroWaitinDataRecordDTO.basic.digital_sign.ToString();
                potrojariParameter.potrojari.draft_designation_id = _khoshraPotroWaitinDataRecordDTO.basic.draft_designation_id.ToString();
                potrojariParameter.potrojari.draft_designation_name = _khoshraPotroWaitinDataRecordDTO.basic.draft_designation_name.ToString();
                potrojariParameter.potrojari.draft_officer_id = _khoshraPotroWaitinDataRecordDTO.basic.draft_officer_id.ToString();
                potrojariParameter.potrojari.draft_officer_name = _khoshraPotroWaitinDataRecordDTO.basic.draft_officer_name.ToString();
                potrojariParameter.potrojari.draft_office_id = _khoshraPotroWaitinDataRecordDTO.basic.draft_office_id.ToString();
                potrojariParameter.potrojari.draft_office_name = _khoshraPotroWaitinDataRecordDTO.basic.draft_office_name.ToString();
                potrojariParameter.potrojari.draft_unit_id = _khoshraPotroWaitinDataRecordDTO.basic.draft_unit_id.ToString();
                potrojariParameter.potrojari.draft_unit_name = _khoshraPotroWaitinDataRecordDTO.basic.draft_unit_name.ToString();
                potrojariParameter.potrojari.id = _khoshraPotroWaitinDataRecordDTO.basic.id.ToString();
                potrojariParameter.potrojari.is_summary_nothi = _khoshraPotroWaitinDataRecordDTO.basic.is_summary_nothi.ToString();
                potrojariParameter.potrojari.last_update_date = _khoshraPotroWaitinDataRecordDTO.basic.last_update_date.ToString();

                potrojariParameter.potrojari.marginBottom = form._bottomMargin.ToString();
                potrojariParameter.potrojari.marginLeft = form._leftMargin.ToString();
                potrojariParameter.potrojari.marginRight = form._rightMargin.ToString();
                potrojariParameter.potrojari.marginTop = form._topMargin.ToString();


                potrojariParameter.potrojari.meta_data = _khoshraPotroWaitinDataRecordDTO.basic.meta_data.ToString();
                potrojariParameter.potrojari.modified = _khoshraPotroWaitinDataRecordDTO.basic.modified.ToString();
                potrojariParameter.potrojari.noter_potro_json = _khoshraPotroWaitinDataRecordDTO.basic.noter_potro_json.ToString();
                potrojariParameter.potrojari.note_json = _khoshraPotroWaitinDataRecordDTO.basic.note_json.ToString();
                potrojariParameter.potrojari.note_onucched_id = _khoshraPotroWaitinDataRecordDTO.basic.note_onucched_id.ToString();
                potrojariParameter.potrojari.nothi_master_id = _khoshraPotroWaitinDataRecordDTO.basic.nothi_master_id.ToString();
                potrojariParameter.potrojari.nothi_note_id = _khoshraPotroWaitinDataRecordDTO.basic.nothi_note_id.ToString();
                potrojariParameter.potrojari.nothi_potro_attachment_id = _khoshraPotroWaitinDataRecordDTO.basic.nothi_potro_attachment_id.ToString();
                potrojariParameter.potrojari.nothi_potro_id = _khoshraPotroWaitinDataRecordDTO.basic.nothi_potro_id.ToString();
                potrojariParameter.potrojari.onulipi_sent = _khoshraPotroWaitinDataRecordDTO.basic.cloned_potrojari_id.ToString();
                potrojariParameter.potrojari.orientation = form._pageLayout.ToString();
                potrojariParameter.potrojari.pageSize = form._pageSize.ToString();
                potrojariParameter.potrojari.page_numbers = _khoshraPotroWaitinDataRecordDTO.basic.page_numbers.ToString();
                potrojariParameter.potrojari.potrojari_date = _khoshraPotroWaitinDataRecordDTO.basic.potrojari_date.ToString();
                potrojariParameter.potrojari.potrojari_internal = _khoshraPotroWaitinDataRecordDTO.basic.potrojari_internal.ToString();
                potrojariParameter.potrojari.potrojari_language = _khoshraPotroWaitinDataRecordDTO.basic.potrojari_language.ToString();
                potrojariParameter.potrojari.potro_cover = _khoshraPotroWaitinDataRecordDTO.mulpotro.potro_cover.ToString();
                potrojariParameter.potrojari.potro_description = _khoshraPotroWaitinDataRecordDTO.mulpotro.potro_description.ToString();
                potrojariParameter.potrojari.potro_pages = _khoshraPotroWaitinDataRecordDTO.basic.potro_pages.ToString();
                potrojariParameter.potrojari.potro_status = _khoshraPotroWaitinDataRecordDTO.basic.potro_status.ToString();
                potrojariParameter.potrojari.potro_subject = _khoshraPotroWaitinDataRecordDTO.basic.potro_subject.ToString();
                potrojariParameter.potrojari.potro_type = _khoshraPotroWaitinDataRecordDTO.basic.potro_type.ToString();
                potrojariParameter.potrojari.receiver_sent = _khoshraPotroWaitinDataRecordDTO.basic.receiver_sent.ToString();
                potrojariParameter.potrojari.sarok_no = _khoshraPotroWaitinDataRecordDTO.basic.sarok_no.ToString();
                potrojariParameter.potrojari.shared_nothi_id = _khoshraPotroWaitinDataRecordDTO.basic.shared_nothi_id.ToString();
                potrojariParameter.potrojari.sign_info = _khoshraPotroWaitinDataRecordDTO.basic.sign_info.ToString();

                potrojariParameter.potrojari.potro_security_level = _khoshraPotroWaitinDataRecordDTO.basic.potro_security_level.ToString();
                potrojariParameter.potrojari.potro_priority_level = _khoshraPotroWaitinDataRecordDTO.basic.potro_priority_level.ToString();



                DakUserParam dakUserParam = _userService.GetLocalDakUserParam();


                var potrojariResponse = _potrojariServices.GetPotrojariResponse(dakUserParam, potrojariParameter);

                if (potrojariResponse != null && potrojariResponse.status == "success")
                {
                    UIDesignCommonMethod.SuccessMessage(potrojariResponse.data);
                    //loadPotrangshoNotePanel();
                    //loadPotrangshoNothiPanel();
                    //loadCollapseExpandSize();
                }



            }
        }

        private KhoshraPotroWaitinDataRecordDTO GetKhosraWaiting()
        {
            _khoshraPotroWaitinDataRecordDTO = new KhoshraPotroWaitinDataRecordDTO();
            _khoshraPotroWaitinDataRecordDTO.basic = MappingModels.MapModel<NoteKhoshraListDataRecordBasicDTO, KhoshraPotroWaitinDataRecordBasicDTO>(_khoshraPotroDataRecordDTO.basic);
            _khoshraPotroWaitinDataRecordDTO.mulpotro = MappingModels.MapModel<NoteKhoshraListDataRecordMulpotroDTO, KhoshraPotroWaitinDataRecordMulpotroDTO>(_khoshraPotroDataRecordDTO.mulpotro);
            _khoshraPotroWaitinDataRecordDTO.note_onucched = MappingModels.MapModel<NoteKhoshraListDataRecordNoteOnucchedDTO, KhoshraPotroWaitinDataRecordNoteOnucchedDTO>(_khoshraPotroDataRecordDTO.note_onucched);
            _khoshraPotroWaitinDataRecordDTO.note_owner = MappingModels.MapModel<NoteKhoshraListDataRecordNoteOwnerDTO, KhoshraPotroWaitinDataRecordNoteOwnerDTO>(_khoshraPotroDataRecordDTO.note_owner);

            return _khoshraPotroWaitinDataRecordDTO;
        }



        private void btnNothiPanelNothiCount_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush Brush = new SolidBrush(Color.FromArgb(255, 168, 0));
            GraphicsPath path = Roundedrectangle.Create(6, 7, label22.Width - 2, label22.Height - 2, 2);
            e.Graphics.DrawPath(new Pen(Color.FromArgb(255, 168, 0)), path);
            GraphicsPath path1 = Roundedrectangle.Create(6, 7, label22.Width - 2, label22.Height - 2, 2);
            e.Graphics.FillPath(Brush, path1);
        }

        private void lbApprovedPotro_Click(object sender, EventArgs e)
        {

        }

        private void noteBackGroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (InternetConnection.Check())
            {
                //_onucchedSave.SendNoteListFromLocal();

                if (onlineStatus.IconColor != Color.LimeGreen)
                {
                    if (IsHandleCreated)
                    {
                        onlineStatus.Invoke(new MethodInvoker(delegate
                        {
                            onlineStatus.IconColor = Color.LimeGreen;
                            MyToolTip.SetToolTip(onlineStatus, "Online");
                        }));
                    }
                    else
                    {

                    }

                }
            }
            else
            {
                if (IsHandleCreated)
                {
                    onlineStatus.Invoke(new MethodInvoker(delegate
                    {
                        onlineStatus.IconColor = Color.Silver;
                        MyToolTip.SetToolTip(onlineStatus, "Offline");
                    }));
                }
                else
                {

                }



            }
        }

        private void noteBackGroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!noteBackGroundWorker.IsBusy && this.Visible)
            {
                noteBackGroundWorker.RunWorkerAsync();
            }
        }

        private void Note_Load_1(object sender, EventArgs e)
        {
            label7.Text = UIDesignCommonMethod.copyRightLableText;
            noteBackGroundWorker.RunWorkerAsync();
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void btnUnapprove_Click(object sender, EventArgs e)
        {
            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = "আপনি কি পত্র থেকে অনুমোদন তুলে নিতে চান?";
            conditonBoxForm.ShowDialog();
            if (conditonBoxForm.Yes)
            {
                if (khoshraPotroWaitinDataRecordMulpotroDTO != null)
                {
                    DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();


                    var links = khosraViewWebBrowser.Document.GetElementsByTagName("img");

                    foreach (HtmlElement link in links)
                    {

                        if (link.GetAttribute("ClassName") == "khoshra_approver_signature")
                        {
                            link.SetAttribute("src", "../img/sign-1.png");
                        }
                    }
                    PotroApproveResponse khoshraUnapprovedResponse = new PotroApproveResponse();
                    if (_khoshraPotroWaitinDataRecordDTO == null)
                    {
                        _khoshraPotroDataRecordDTO.mulpotro.potro_description = ConversionMethod.Base64Encode(khosraViewWebBrowser.Document.Body.OuterHtml.ToString());
                        khoshraUnapprovedResponse = _potrojariServices.GetPotroOnumodonResponse(dakListUserParam, khoshraPotroWaitinDataRecordMulpotroDTO.id, _khoshraPotroDataRecordDTO.basic.potro_status, _khoshraPotroDataRecordDTO.mulpotro.potro_description);

                    }
                    else
                    {
                        _khoshraPotroWaitinDataRecordDTO.mulpotro.potro_description = ConversionMethod.Base64Encode(khosraViewWebBrowser.Document.Body.OuterHtml.ToString());
                        khoshraUnapprovedResponse = _potrojariServices.GetPotroOnumodonResponse(dakListUserParam, khoshraPotroWaitinDataRecordMulpotroDTO.id, _khoshraPotroWaitinDataRecordDTO.basic.potro_status, _khoshraPotroWaitinDataRecordDTO.mulpotro.potro_description);

                    }

                    if (khoshraUnapprovedResponse.status == "success")
                    {

                        UIDesignCommonMethod.SuccessMessage(khoshraUnapprovedResponse.data);

                        btnApprove.Visible = true;
                        btnUnapprove.Visible = false;
                        btnPotrojari.Visible = false;


                    }
                }
            }

        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = "আপনি কি পত্রটি অনুমোদন করতে চান??";
            conditonBoxForm.ShowDialog();
            if (conditonBoxForm.Yes)
            {
                if (khoshraPotroWaitinDataRecordMulpotroDTO != null)
                {
                    DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
                    var links = khosraViewWebBrowser.Document.GetElementsByTagName("img");

                    foreach (HtmlElement link in links)
                    {

                        if (link.GetAttribute("ClassName") == "khoshra_approver_signature")
                        {
                            link.SetAttribute("src", dakListUserParam.SignBase64);
                        }
                    }
                    PotroApproveResponse khoshraUnapprovedResponse = new PotroApproveResponse();

                    if (_khoshraPotroDataRecordDTO != null)
                    {
                        _khoshraPotroDataRecordDTO.mulpotro.potro_description = ConversionMethod.Base64Encode(khosraViewWebBrowser.Document.Body.OuterHtml.ToString());

                        khoshraUnapprovedResponse = _potrojariServices.GetPotroOnumodonResponse(dakListUserParam, khoshraPotroWaitinDataRecordMulpotroDTO.id, _khoshraPotroDataRecordDTO.basic.potro_status, _khoshraPotroDataRecordDTO.mulpotro.potro_description);

                    }
                    else if (_khoshraPotroWaitinDataRecordDTO == null)
                    {
                        _khoshraPotroWaitinDataRecordDTO.mulpotro.potro_description = ConversionMethod.Base64Encode(khosraViewWebBrowser.Document.Body.OuterHtml.ToString());

                        khoshraUnapprovedResponse = _potrojariServices.GetPotroOnumodonResponse(dakListUserParam, khoshraPotroWaitinDataRecordMulpotroDTO.id, _khoshraPotroWaitinDataRecordDTO.basic.potro_status, _khoshraPotroWaitinDataRecordDTO.mulpotro.potro_description);

                    }

                    if (khoshraUnapprovedResponse.status == "success")
                    {

                        UIDesignCommonMethod.SuccessMessage(khoshraUnapprovedResponse.data);
                        btnApprove.Visible = false;
                        btnUnapprove.Visible = true;
                        btnPotrojari.Visible = true;

                        //khosraViewWebBrowser.Document.Images.("img.khoshra_approver_signature")
                        // .SetAttribute("src", dakListUserParam.SignBase64);
                    }
                }
            }
        }

        private void label29_Click(object sender, EventArgs e)
        {

        }
        ModulePanelUserControl modulePanel = new ModulePanelUserControl();
        private void moduleButton_Click(object sender, EventArgs e)
        {
            if (modulePanel.Width == 334 && !modulePanel.Visible)
            {
                modulePanel.Visible = true;
                modulePanel.Location = new System.Drawing.Point(btnNothiIcon.Location.X + btnNothiIcon.Width + dakMenuButton.Width + dakModulePanel.Width + nothiModulePanel.Width, nothiModulePanel.Height - 10);
                Controls.Add(modulePanel);
                modulePanel.BringToFront();
                modulePanel.Width = 335;

            }
            else
            {
                modulePanel.Visible = false;
                modulePanel.Width = 334;
            }
        }
        Point lastPoint;

        public NoteListDataRecordNoteDTO _noteListDataRecordNoteDTO;
        public NothiListRecordsDTO _nothiListRecordsDTO;
        public NothiListInboxNoteRecordsDTO _nothiListInboxNoteRecordsDTO;

        private void splitter3_MouseMove(object sender, MouseEventArgs e)
        {
            PnlSave.Location = new System.Drawing.Point(pnlNoteList.Width + splitter1.Width + btnSave.Location.X,
                    panel2.Height + panel52.Height + panel15.Height + panel34.Height + noteTabpanel.Height + noteSubjectPanel.Height + panel59.Height + splitter3.Height + onucchedActionPanel.Height);
        }

        private void splitter3_MouseDown(object sender, MouseEventArgs e)
        {
            PnlSave.Location = new System.Drawing.Point(pnlNoteList.Width + splitter1.Width + btnSave.Location.X,
                    panel2.Height + panel52.Height + panel15.Height + panel34.Height + noteTabpanel.Height + noteSubjectPanel.Height + panel59.Height + splitter3.Height + onucchedActionPanel.Height);

        }

        private void splitter3_MouseMove(object sender, EventArgs e)
        {
            PnlSave.Location = new System.Drawing.Point(pnlNoteList.Width + splitter1.Width + btnSave.Location.X,
                    panel2.Height + panel52.Height + panel15.Height + panel34.Height + noteTabpanel.Height + noteSubjectPanel.Height + panel59.Height + splitter3.Height + onucchedActionPanel.Height);
        }

        private void btnSaveAndKhoshra_Click(object sender, EventArgs e)
        {
            btnOnuchhedSave_Click(sender, e);
            if (string.IsNullOrEmpty(_saved_Onucched_Id))
            {
                loadKhoshra(_saved_Onucched_Id);
            }

        }
        public void KhoshraButton_Click(string onucchedId, EventArgs e)
        {
            loadKhoshra(onucchedId);
        }
        public void EditButton_Click(OnuchhedSaveItemAction onucched, EventArgs e)
        {
            updateOnuchhedId = Convert.ToInt32(onucched.onuchhedId);
            noteHeaderPanel.Width = 990;
            noteHeaderPanel.Height = 150;
            btnWriteOnuchhed.Visible = false;
            btnSend.Visible = false;
            visibilityON();

            PnlSave.Visible = false;
            panel22.Visible = true;
            tinyMceEditor.Visible = true;
            panel28.Visible = true;
            panel22.SendToBack();
            panel24.Visible = true;
            //panel24.SendToBack();
            tinyMceEditor.HtmlContent = onucched.editorEncodedData;
            fileAddFLP.Controls.Clear();
            noteFileUploads.Clear();
            onucchedEditorPanel.Visible = true;
        }
        private void loadKhoshra(string onucchedId)
        {

            DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
            NoteNothiDTO noteNothiDTO = new NoteNothiDTO();
            NothiListAllRecordsDTO nothiListRecords = new NothiListAllRecordsDTO();

            (noteNothiDTO, nothiListRecords) = GetNothiAndNoteInfo();
            var form = FormFactory.Create<Khosra>();
            form.NothiKhosrajato(noteNothiDTO, lbNoteShakha.Text, lbSubject.Text, nothiListRecords);

            form._noteListDataRecordNoteDTO = _noteListDataRecordNoteDTO;
            form._nothiListRecordsDTO = _nothiListRecordsDTO;
            form._nothiListInboxNoteRecordsDTO = _nothiListInboxNoteRecordsDTO;
            form._note_onucched_id = Convert.ToInt32(onucchedId);

            //GetSarokNoResponse sarok_no = _khosraSaveService.GetSharokNoResponse(dakUserParam, Convert.ToInt32(noteNothiDTO.nothi_id), potrojari_id);
            //form.SetSarokNo(sarok_no.sarok_no);

            BeginInvoke((Action)(() => form.ShowDialog()));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };
        }

        private void btnDecision_Click(object sender, EventArgs e)
        {
            if (InternetConnection.Check())
            {
                WaitForm.Show(this);
                var nothiDecisionList = UserControlFactory.Create<NothiDecisionList>();
                nothiDecisionList.DecisionText += delegate (object sender1, EventArgs e1) { DecisionText_Click(sender1 as string, e1); };
                nothiDecisionList.loadRow();
                var form = NothiNextStepControlToForm(nothiDecisionList);
                WaitForm.Close();
                CalPopUpWindow(form);
            }
            else
            {
                ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }

        }
        private void DecisionText_Click(string text, EventArgs e1)
        {
            string editortext = getparagraphtext(tinyMceEditor.HtmlContent);
            editortext += " " + text;
            tinyMceEditor.HtmlContent = editortext;
        }
        private DakAttachmentResponse GetAllMulPattraAndSanjukti(KasaraPotro.Record kasaraPotro)
        {
            DakAttachmentResponse dakAttachmentResponse = new DakAttachmentResponse { data = null, status = null };
            var dakListUserParam = _userService.GetLocalDakUserParam();
            dakListUserParam.limit = 10;
            var noteAntarvuktaKasralist = _kasaraPatraDashBoardService.GetMulPattraAndSanjukti(dakListUserParam, kasaraPotro);
            if (noteAntarvuktaKasralist != null && noteAntarvuktaKasralist.status == "success")
            {
                dakAttachmentResponse = noteAntarvuktaKasralist;
            }
            return dakAttachmentResponse;
        }
        private void btnMulPotroOShonjukti_Click(object sender, EventArgs e)
        {
            KhosraAttachmentViewForm khosraAttachmentViewForm = new KhosraAttachmentViewForm();

            KasaraPotro.Record khoshraPotro = new KasaraPotro.Record();

            try
            {
                if (_khoshraPotroWaitinDataRecordDTO == null)
                {
                    _khoshraPotroWaitinDataRecordDTO = GetKhosraWaiting();
                }

                khoshraPotro = GetKhosra(_khoshraPotroWaitinDataRecordDTO);
                khosraAttachmentViewForm.dakAttachmentResponse = GetAllMulPattraAndSanjukti(khoshraPotro);

                UIDesignCommonMethod.CalPopUpWindow(khosraAttachmentViewForm, this);
            }
            catch
            {

            }





        }

        private KasaraPotro.Record GetKhosra(KhoshraPotroWaitinDataRecordDTO khoshraPotroWaitinDataRecordDTO)
        {
            KasaraPotro.Record record = new KasaraPotro.Record();

            record.Basic = MappingModels.MapModel<NoteKhoshraListDataRecordBasicDTO, KasaraPotro.Basic>(_khoshraPotroDataRecordDTO.basic);
            record.Mulpotro = MappingModels.MapModel<NoteKhoshraListDataRecordMulpotroDTO, KasaraPotro.Mulpotro>(_khoshraPotroDataRecordDTO.mulpotro);
            record.NoteOnucched = MappingModels.MapModel<NoteKhoshraListDataRecordNoteOnucchedDTO, KasaraPotro.NoteOnucched>(_khoshraPotroDataRecordDTO.note_onucched);
            record.NoteOwner = MappingModels.MapModel<NoteKhoshraListDataRecordNoteOwnerDTO, KasaraPotro.NoteOwner>(_khoshraPotroDataRecordDTO.note_owner);
            return record;
        }

        private void btnGardFile_Click(object sender, EventArgs e)
        {
            if (InternetConnection.Check())
            {
                WaitForm.Show(this);
                var nothiGaurdFileList = UserControlFactory.Create<NothiGaurdFileList>();
                nothiGaurdFileList.GaurdFileAttachment += delegate (object sender1, EventArgs e1) { GaurdFileText_Click(sender1 as GaurdFileRecord, e1); };
                var form = NothiNextStepControlToForm(nothiGaurdFileList);
                WaitForm.Close();
                CalPopUpWindow(form);
            }
            else
            {
                ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }

        }
        private void GaurdFileText_Click(GaurdFileRecord gaurdFileRecord, EventArgs e1)
        {
            string addParagraphStartTag = "<p>";
            string addParagraphEndTag = "</p>";
            string allText = "";
            string editortext = getparagraphtext(tinyMceEditor.HtmlContent);

            editortext += " " + "<a href=" + gaurdFileRecord.attachment.url + ">" + gaurdFileRecord.name_bng + "</a>";
            //string link = "https://dev.nothibs.tappware.com/api/content/view?token=NjBmMmYzMjNhNTk1MiZvZmZpY2VJZF82NV8yMDk%3D";
            //tinyMceEditor.HtmlContent = "<p><a href=" + link + ">Test</a></p>";
            allText = addParagraphStartTag + editortext + addParagraphEndTag;
            tinyMceEditor.HtmlContent = allText;
        }

        private void btnBibechhoPotro_Click(object sender, EventArgs e)
        {
            if (InternetConnection.Check())
            {
                WaitForm.Show(this);
                var nothiBibechhoPotroList = UserControlFactory.Create<NothiBibechhoPotroList>();
                nothiBibechhoPotroList.BibechhoPotroRecord += delegate (object sender1, EventArgs e1) { BibechhoPotroText_Click(sender1 as BibechhoPotroRecord, e1); };
                nothiBibechhoPotroList.nothi_id = nothiListRecords.id.ToString();
                nothiBibechhoPotroList.loadRow();
                var form = NothiNextStepControlToForm(nothiBibechhoPotroList);
                WaitForm.Close();
                CalPopUpWindow(form);
            }
            else
            {
                ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }

        }
        private void BibechhoPotroText_Click(BibechhoPotroRecord record, EventArgs e1)
        {
            string addParagraphStartTag = "<p>";
            string addParagraphEndTag = "</p>";
            string allText = "";
            string editortext = getparagraphtext(tinyMceEditor.HtmlContent);

            editortext += " " + "<a href=" + record.mulpotro.url + ">বিবেচ্য পত্র: " + record.basic.sarok_no + " ," + record.basic.subject + " সদয় দ্রষ্টব্য।</a>";
            allText = addParagraphStartTag + editortext + addParagraphEndTag;
            tinyMceEditor.HtmlContent = allText;
        }

        private void btnShongjuktiRef_Click(object sender, EventArgs e)
        {
            if (InternetConnection.Check())
            {
                //var str = onuchhedSaveWithAttachments;
                WaitForm.Show(this);
                var nothiDecisionList = UserControlFactory.Create<NothiDecisionList>();
                nothiDecisionList.labelText = "সংযুক্তি তালিকা";
                nothiDecisionList.AttachmentAdd += delegate (object sender1, EventArgs e1) { AttachmentAdd_Click(sender1 as DakAttachmentDTO, e1); };
                nothiDecisionList.loadRowAttachments(onuchhedSaveWithAttachments);
                var form = NothiNextStepControlToForm(nothiDecisionList);
                WaitForm.Close();
                CalPopUpWindow(form);
            }
            else
            {
                ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }

        }
        private void AttachmentAdd_Click(DakAttachmentDTO record, EventArgs e1)
        {
            string addParagraphStartTag = "<p>";
            string addParagraphEndTag = "</p>";
            string allText = "";
            string editortext = getparagraphtext(tinyMceEditor.HtmlContent);
            editortext += " " + "<a href=" + record.url + ">" + record.user_file_name + "</a>";
            allText = addParagraphStartTag + editortext + addParagraphEndTag;
            tinyMceEditor.HtmlContent = allText;
        }

        private void btnPotaka_Click(object sender, EventArgs e)
        {
            if (InternetConnection.Check())
            {
                WaitForm.Show(this);
                var nothiDecisionList = UserControlFactory.Create<NothiDecisionList>();
                nothiDecisionList.labelText = "পতাকা বাছাই করুন";
                nothiDecisionList.loadPotaka(nothiListRecords.id.ToString(), notelist.nothi_note_id.ToString());
                nothiDecisionList.PotakaAdd += delegate (object sender1, EventArgs e1) { PotakaAdd_Click(sender1 as PotakaListRecord, e1); };
                var form = NothiNextStepControlToForm(nothiDecisionList);
                WaitForm.Close();
                CalPopUpWindow(form);
            }
            else
            {
                ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }

        }
        private void PotakaAdd_Click(PotakaListRecord record, EventArgs e1)
        {
            string addParagraphStartTag = "<p>";
            string addParagraphEndTag = "</p>";
            string allText = "";
            string editortext = getparagraphtext(tinyMceEditor.HtmlContent);
            editortext += " " + "<a style= color:" + record.color + "; href=" + record.attachment.url + "> বিবেচ্য পতাকা: " + record.title + " সদয় দ্রষ্টব্য।</a>";
            allText = addParagraphStartTag + editortext + addParagraphEndTag;
            tinyMceEditor.HtmlContent = allText;
        }

        private void btnOnuchhed_Click(object sender, EventArgs e)
        {
            if (InternetConnection.Check())
            {
                WaitForm.Show(this);
                var nothiDecisionList = UserControlFactory.Create<NothiDecisionList>();
                nothiDecisionList.labelText = "অনুচ্ছেদ তালিকা";
                nothiDecisionList.loadOnuchhed(nothiListRecords.id.ToString());
                nothiDecisionList.OnuchhedAdd += delegate (object sender1, EventArgs e1) { OnuchhedAdd_Click(sender1 as string, e1); };
                var form = NothiNextStepControlToForm(nothiDecisionList);
                WaitForm.Close();
                CalPopUpWindow(form);
            }
            else
            {
                ErrorMessage("এই মুহুর্তে ইন্টারনেট সংযোগ স্থাপন করা সম্ভব হচ্ছেনা!");
            }

        }
        private void OnuchhedAdd_Click(string Text, EventArgs e1)
        {
            string addParagraphStartTag = "<p>";
            string addParagraphEndTag = "</p>";
            string allText = "";
            string editortext = getparagraphtext(tinyMceEditor.HtmlContent);
            editortext += Text + ",";
            allText = addParagraphStartTag + editortext + addParagraphEndTag;
            tinyMceEditor.HtmlContent = allText;
        }

        private void btnFullEditable_Click(object sender, EventArgs e)
        {
            EditorCloneKhosra(false);

        }

        private void EditorCloneKhosra(bool clone)
        {
            if (_khoshraPotroDataRecordDTO != null)
            {
                _khoshraPotroWaitinDataRecordDTO = GetKhosraWaiting();
            }
            if (_khoshraPotroWaitinDataRecordDTO != null)
            {
                NoteNothiDTO noteNothiDTO = new NoteNothiDTO();
                NothiListAllRecordsDTO nothiListRecords = new NothiListAllRecordsDTO();

                (noteNothiDTO, nothiListRecords) = GetNothiAndNoteInfo();


                var khosra = FormFactory.Create<Khosra>();
                var dakListUserParam = _userService.GetLocalDakUserParam();
                dakListUserParam.limit = 10;
                var prapakerTalika = _kasaraPatraDashBoardService.GetPrapakerTalika(dakListUserParam, _khoshraPotroWaitinDataRecordDTO.basic.id);
                KhasraPotroTemplateDataDTO khasraPotroTemplateData = new KhasraPotroTemplateDataDTO();
                if (_khoshraPotroWaitinDataRecordDTO.note_owner != null)
                {

                    khasraPotroTemplateData.potrojari_id = _khoshraPotroWaitinDataRecordDTO.note_owner.potrojari;
                    khosra.NothiKhosrajato(noteNothiDTO, lbNoteShakha.Text, lbSubject.Text, nothiListRecords);
                    khosra.SetSarokNo(_khoshraPotroWaitinDataRecordDTO.basic.sarok_no);
                }
                khosra._note_onucched_id = _khoshraPotroWaitinDataRecordDTO.note_onucched.id;

                if (clone)
                {
                    khosra._cloned_potrojari_id = _khoshraPotroWaitinDataRecordDTO.basic.id;
                }
                else
                {
                    khosra.draft_id = _khoshraPotroWaitinDataRecordDTO.basic.id;
                }


                khosra._noteListDataRecordNoteDTO = _noteListDataRecordNoteDTO;
                khosra._nothiListRecordsDTO = _nothiListRecordsDTO;
                khosra._nothiListInboxNoteRecordsDTO = _nothiListInboxNoteRecordsDTO;

                if (_khoshraPotroWaitinDataRecordDTO.basic.potro_pages > 0)
                {
                    var khoshraPotro = GetKhosra(_khoshraPotroWaitinDataRecordDTO);
                    var attachment = GetAllMulPattraAndSanjukti(khoshraPotro);

                    //_khoshraPotroWaitinDataRecordDTO
                    khosra.draftAttachmentDTOs = attachment != null ? attachment.data.Where(a => a.is_main != 1).ToList() : null;

                }

                khosra.kasaradashboardHtmlContent = Base64Conversion.Base64ToHtmlContent(_khoshraPotroWaitinDataRecordDTO.mulpotro.potro_description);


                khasraPotroTemplateData.template_id = _khoshraPotroWaitinDataRecordDTO.basic.potro_type;
                khasraPotroTemplateData.template_name = _khoshraPotroWaitinDataRecordDTO.mulpotro.potro_cover;

                khasraPotroTemplateData.html_content = Base64Conversion.Base64ToHtmlContent(_khoshraPotroWaitinDataRecordDTO.mulpotro.potro_description);

                khosra._khasraPotroTemplateData = khasraPotroTemplateData;



                if (prapakerTalika.status == "success")
                {


                    khosra.LoadAllDesignation();


                    khosra.onulipiOfficerDesignations = prapakerTalika.data.onulipi;
                    khosra.onumodanKariOfficerDesignations = prapakerTalika.data.approver;
                    khosra.prapakOfficerDesignations = prapakerTalika.data.receiver;
                    khosra.prerokOfficerDesignations = prapakerTalika.data.sender;
                    khosra.attensionOfficerDesignations = prapakerTalika.data.attention;
                }


                BeginInvoke((Action)(() => khosra.ShowDialog()));
                khosra.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };

            }
        }

        private (NoteNothiDTO noteNothiDTO, NothiListAllRecordsDTO nothiListRecords) GetNothiAndNoteInfo()
        {
            NoteNothiDTO noteNothiDTO = new NoteNothiDTO();
            noteNothiDTO.id = _NoteAllListDataRecordDTO.nothi.id;//nothiId
            noteNothiDTO.nothi_no = _NoteAllListDataRecordDTO.nothi.nothi_no;
            noteNothiDTO.note_no = _NoteAllListDataRecordDTO.note.note_no.ToString();
            noteNothiDTO.note_subject = _NoteAllListDataRecordDTO.note.note_subject;
            noteNothiDTO.note_id = _NoteAllListDataRecordDTO.note.nothi_note_id.ToString();

            NothiListAllRecordsDTO nothiListRecords = new NothiListAllRecordsDTO();

            NothiAllDTO nothiAllDTO = new NothiAllDTO();
            nothiAllDTO.id = _NoteAllListDataRecordDTO.nothi.id;
            nothiAllDTO.office_id = _NoteAllListDataRecordDTO.nothi.office_id;
            nothiAllDTO.office_name = _NoteAllListDataRecordDTO.nothi.office_name;
            nothiAllDTO.office_unit_id = _NoteAllListDataRecordDTO.nothi.office_unit_id;
            nothiAllDTO.office_unit_name = _NoteAllListDataRecordDTO.nothi.office_unit_name;
            nothiAllDTO.office_unit_organogram_id = _NoteAllListDataRecordDTO.nothi.office_unit_organogram_id;
            nothiAllDTO.office_designation_name = _NoteAllListDataRecordDTO.nothi.office_designation_name;
            nothiAllDTO.nothi_no = _NoteAllListDataRecordDTO.nothi.nothi_no;
            nothiAllDTO.subject = _NoteAllListDataRecordDTO.nothi.subject;
            nothiAllDTO.nothi_class = _NoteAllListDataRecordDTO.nothi.nothi_class;
            nothiAllDTO.modified = _NoteAllListDataRecordDTO.nothi.modified;

            nothiListRecords.nothi = nothiAllDTO;

            DeskAllDTO deskAllDTO = new DeskAllDTO();
            deskAllDTO.nothi_master_id = _NoteAllListDataRecordDTO.desk.nothi_master_id;
            deskAllDTO.issue_date = _NoteAllListDataRecordDTO.desk.issue_date;
            deskAllDTO.note_count = _NoteAllListDataRecordDTO.desk.note_count;
            deskAllDTO.note_current_status = _NoteAllListDataRecordDTO.desk.note_current_status;
            deskAllDTO.priority = _NoteAllListDataRecordDTO.desk.priority;

            nothiListRecords.desk = deskAllDTO;


            return (noteNothiDTO, nothiListRecords);
        }

        private void btnSaveAndSend_Click(object sender, EventArgs e)
        {
            btnOnuchhedSave_Click(sender, e);
            btnSend_Click(sender, e);
        }
    }
}