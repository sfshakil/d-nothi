using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
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

namespace dNothi.Desktop.UI.Dak
{
    public partial class NothiNextStep : UserControl
    {
        IUserService _userService { get; set; }
        IOnuchhedForwardService _onuchhedForward { get; set; }
        INothiAllNoteServices _nothiAllNote { get; set; }
        public NothiNextStep(IUserService userService, IOnuchhedForwardService onuchhedForward, INothiAllNoteServices nothiAllNote)
        {
            _userService = userService;
            _onuchhedForward = onuchhedForward;
            _nothiAllNote = nothiAllNote;
            InitializeComponent();
            SetDefaultFont(this.Controls);
            cbxPriorityType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbxPriorityType.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public event EventHandler NoteDetailsButton;
        private void btnCross_Click(object sender, EventArgs e)
        {
            //foreach (Form f in Application.OpenForms)
            //{ f.Hide(); }
            //if (this.NoteDetailsButton != null)
            //    this.NoteDetailsButton(sender, e);
            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            foreach (Form f in openForms)
            {
                if (f.Name != "Note")
                    f.Close();
            }

        }
        void SetDefaultFont(System.Windows.Forms.Control.ControlCollection collection)
        {
            foreach (Control ctrl in collection)
            {
                if (ctrl.Font.Style != FontStyle.Regular)
                {
                    MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                    ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size, ctrl.Font.Style);
                }
                SetDefaultFont(ctrl.Controls);
            }

        }

        private string _noteTotal;
        private string _noteSubject;
        public string _noteID;

        [Category("Custom Props")]
        public string noteSubject
        {
            get { return _noteSubject; }
            set { _noteSubject = value; lbNoteSubject.Text = value; }
        }

        [Category("Custom Props")]
        public string noteTotal
        {
            get { return _noteTotal; }
            set { _noteTotal = value; lbTotalNothi.Text = value; }
        }
        int i = 1;
        int j = 1;
        List<onumodonDataRecordDTO> records = new List<onumodonDataRecordDTO>();

        public void GetNothiInboxRecords(List<onumodonDataRecordDTO> onumodonList)
        {


                 records = onumodonList;

                if (onumodonList.Count > 0)
                {
                    records = onumodonList.OrderByDescending(a => a.layer_index).ThenBy(a => a.route_index).ToList();
                    var groupLevel = records.GroupBy(a => a.layer_index);
                    foreach (var group in groupLevel)
                    {



                        NothiOnumodonLevel nothiOnumodonRow = new NothiOnumodonLevel();
                        
                        nothiOnumodonRow.layerIndex = group.Key;
                        nothiOnumodonRow.isFromNothiNextStep = true;
                        nothiOnumodonRow.CheckBoxButton += delegate (object sender, EventArgs e) { CheckboxOfficer_ButtonClick(sender, e, nothiOnumodonRow._designationId, nothiOnumodonRow._isChecked); };







                    foreach (var officer in group)
                        {

                            nothiOnumodonRow.AddNewOfficerFromNothiNextStep(officer.officer, officer.designation_id, officer.designation + "," + officer.office_unit + "," + officer.nothi_office_name, officer.route_index,0, officer.is_signatory);
                        nothiOnumodonRow.level = officer.layer_index.ToString();
                        nothiOnumodonRow.karjodibosh = officer.max_transaction_day.ToString();

                    }

                    UIDesignCommonMethod.AddRowinTable(nothiTalikaFlowLayoutPnl, nothiOnumodonRow);



                }
                }
              

            
        }


        public void loadFlowLayout(onumodonDataRecordDTO record)
        {
            records.Add(record);
            if (_userService.GetOfficeInfo().office_unit_id != record.office_unit_id && _userService.GetOfficeInfo().office_unit_organogram_id != record.designation_id)
            {
                NothiOnumodonLevel nothiOnumodonRow = new NothiOnumodonLevel();
             //   nothiOnumodonRow.name = record.officer;
           //     nothiOnumodonRow.designation = record.designation + "," + record.office_unit + "," + record.nothi_office_name;
              //  nothiOnumodonRow.level = i.ToString();
              //  nothiOnumodonRow.flag = 1;
                nothiOnumodonRow.CheckBoxButton += delegate (object sender, EventArgs e) { CheckboxOfficer_ButtonClick(sender, e, nothiOnumodonRow._designationId,nothiOnumodonRow._isChecked); };
                UIDesignCommonMethod.AddRowinTable(nothiTalikaFlowLayoutPnl, nothiOnumodonRow);
                i++;
            }
            
        }

        private void CheckboxOfficer_ButtonClick(object sender, EventArgs e, int designationId, bool isChecked)
        {
            if (isChecked)
            {
                records.FirstOrDefault(a => a.designation_id == designationId).extra = 1;
            }
            else
            {
                records.FirstOrDefault(a => a.designation_id == designationId).extra = 0;
            }
        }

        private void Checkbox_ButtonClick(object sender, EventArgs e, onumodonDataRecordDTO record)
        {
            var sen = (CheckBox)sender;
            if (sen.Checked == true)
            { record.extra = 1; }
            else
                record.extra = 0;

        }

        private void btnAllOnumodonkari_Click(object sender, EventArgs e)
        {
            ////DesignationFLP.Controls.Clear();
            ////foreach (onumodonDataRecordDTO record in records)
            ////{
            ////    NothiOnumodonLevel nothiOnumodonRow = new NothiOnumodonLevel();
            ////   // nothiOnumodonRow.name = record.officer;
            ////  //  nothiOnumodonRow.designation = record.designation + "," + record.office_unit + "," + record.nothi_office_name;
            //// //   nothiOnumodonRow.level = j.ToString();
            //// //   nothiOnumodonRow.flag = 1;
            ////    j++;
            ////    if (_userService.GetOfficeInfo().office_unit_id==record.office_unit_id && _userService.GetOfficeInfo().office_unit_organogram_id == record.designation_id)
            ////    {
            ////       // nothiOnumodonRow.flag = 2;
            ////    }
            ////    nothiOnumodonRow.CheckboxButtonClick += delegate (object sender1, EventArgs e1) { Checkbox_ButtonClick(sender1, e1, record); };
            ////    DesignationFLP.Controls.Add(nothiOnumodonRow);
            ////}
        }
        NoteSaveDTO newnotedata = new NoteSaveDTO();

        NothiListRecordsDTO nothiListRecord = new NothiListRecordsDTO();

        public void loadNewNoteData(NoteSaveDTO notedata)
        {
            newnotedata = notedata;
        }
        public NoteSaveDTO getNewNoteData()
        {
            return newnotedata;
        }
        public void loadlistInboxRecord(NothiListRecordsDTO nothiInboxRecord)
        {
            nothiListRecord = nothiInboxRecord;
        }
        public NothiListRecordsDTO getlistInboxRecord()
        {
            return nothiListRecord;
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
        
        NothiListRecordsDTO nothiList = new NothiListRecordsDTO();
        NoteView newNoteView ;

        public string _noteIdfromNothiInboxNoteShomuho;
        public string _nothiNo;
        public string _nothiShakha;
        public string _nothiSubject;
        public string _nothiLastDate;
        public string _office;
        NothiListInboxNoteRecordsDTO _NoteAllListDataRecordDTO = new NothiListInboxNoteRecordsDTO();
        public void loadNothiInbox(NothiListRecordsDTO nothiListRecordsDTO)
        {
            nothiList = nothiListRecordsDTO;
        }
        public void loadNoteview(NoteView noteView)
        {
            newNoteView = noteView;
        }
        public void loadNothiInbox(NothiListInboxNoteRecordsDTO noteAllListDataRecordDTO)
        {
            _NoteAllListDataRecordDTO = noteAllListDataRecordDTO;
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            var x = _NoteAllListDataRecordDTO;
            if (cbxPriorityType.SelectedItem == "জরুরি")
            {
                nothiListRecord.priority = "1";
            }
            else if(cbxPriorityType.SelectedItem == "অবিলম্বে")
            {
                nothiListRecord.priority = "2";
            }
            else if (cbxPriorityType.SelectedItem == "সর্বোচ্চ অগ্রাধিকার")
            {
                nothiListRecord.priority = "3";
            }
            else
            {
                nothiListRecord.priority = "0";
            }
            List<onumodonDataRecordDTO> newrecords = new List<onumodonDataRecordDTO>();
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();

            foreach (onumodonDataRecordDTO record in records)
            {
                if (record.extra == 1)
                {
                    newrecords.Add(record);
                }               

            }
            if (newrecords.Count == 0)
            {
                ErrorMessage("দয়া করে প্রাপক বাছাই করুন");
            }
            else
            {
                if (newnotedata.note_no == null)
                {
                    string english_text = string.Concat(_noteTotal.Select(c => (char)('0' + c - '\u09E6'))); // "1234567890"

                    int parsed_number = int.Parse(english_text); // 1234567890
                    newnotedata.note_no = parsed_number.ToString();
                    newnotedata.note_subject = _noteSubject;
                    newnotedata.nothi_id = Convert.ToInt32(nothiListRecord.id);
                    newnotedata.note_id = Convert.ToInt32(_noteID);
                }
                var onuchhedForwardResponse = _onuchhedForward.GetOnuchhedForwardResponse(dakListUserParam, newnotedata, nothiListRecord, newrecords);
                
                if (onuchhedForwardResponse.status == "success" && onuchhedForwardResponse.message != "Local")
                {
                    SuccessMessage("প্রক্রিয়াটি সম্পন্ন হয়েছে");
                    
                    foreach (Form f in Application.OpenForms)
                    { BeginInvoke((Action)(() => f.Hide())); }
                    loadNote();
                }
                else if (onuchhedForwardResponse.status == "success" && onuchhedForwardResponse.message == "Local")
                {
                    SuccessMessage("ইন্টারনেট সংযোগ ফিরে এলে নথিটি প্রেরণ করা হবে");
                    foreach (Form f in Application.OpenForms)
                    { BeginInvoke((Action)(() => f.Hide())); }
                    var form = FormFactory.Create<Nothi>();
                    BeginInvoke((Action)(() => form.ShowDialog()));
                }
                else
                {
                    ErrorMessage(onuchhedForwardResponse.message);
                }

            }
            
        }
        private void loadNote() 
        {
            var eachNothiId = _NoteAllListDataRecordDTO.nothi.id;
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
                nothi.LoadNothiOutboxButton(sender1, e1);
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


            form.loadNothiInboxRecords(nothiList);
            form.loadNoteView(newNoteView);
            form.noteTotal = noteTotal;
            form.loadCBXNothiType();
            BeginInvoke((Action)(() => form.ShowDialog()));
            form.Shown += delegate (object sr, EventArgs ev) { DoSomethingAsync(sr, ev); };
        }
        private void DoSomethingAsync(object sender, EventArgs e)
        {
            this.Hide();
        }
        void hideform_Shown(object sender, EventArgs e, Form form)
        {

            form.ShowDialog();

            (sender as Form).Hide();

            // var parent = form.Parent as Form; if (parent != null) { parent.Hide(); }
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
        //NothiNextStep nothiType = UserControlFactory.Create<NothiNextStep>();
        //public void loadNewNoteDataFromNote(NothiNextStep newNoteViewFromNote)
        //{
        //    nothiType = newNoteViewFromNote;
        //}
        NoteListDataRecordNoteDTO notelist = new NoteListDataRecordNoteDTO();
        public void loadNoteList(NoteListDataRecordNoteDTO notelistFromNote)
        {
            notelist = notelistFromNote;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            NothiListRecordsDTO nothiListRecords = nothiListRecord;
            //var x = _NoteAllListDataRecordDTO;
            //this.Hide();
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name != "Note") 
                { BeginInvoke((Action)(() => f.Hide())); }
            }

            var form = FormFactory.Create<NothiOnumodonDesignationSeal>();
            form.nothiListRecordsDTO = nothiListRecord;

            form.noteIdfromNothiInboxNoteShomuho = _noteIdfromNothiInboxNoteShomuho;

            form.nothiNo = _nothiNo;
            form.nothiShakha = _nothiShakha;
            form.nothiSubject = _nothiSubject;
            form.noteSubject = noteSubject;
            form.nothiLastDate = _nothiLastDate;
            form.noteAllListDataRecordDTO = _NoteAllListDataRecordDTO;

            form.office = _office;


            form.loadNothiInboxRecords(nothiList);
            form.loadNoteView(newNoteView);
            form.noteTotal = noteTotal;

            form.GetNothiInboxRecords(nothiListRecords,"Note", _noteID);
            //form.loadNewNoteDataFromNote(nothiType);
            form.loadNoteList(notelist);
            CalPopUpWindow(form);
        }

        private void searchOfficeDetailSearch_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(210, 234, 255), ButtonBorderStyle.Solid);
        }
    }
}
