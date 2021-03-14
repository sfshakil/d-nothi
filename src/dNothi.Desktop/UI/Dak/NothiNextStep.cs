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
        public NothiNextStep(IUserService userService, IOnuchhedForwardService onuchhedForward)
        {
            _userService = userService;
            _onuchhedForward = onuchhedForward;
            InitializeComponent();
            SetDefaultFont(this.Controls);
        }

        public event EventHandler NoteDetailsButton;
        private void btnCross_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            { f.Hide(); }
            if (this.NoteDetailsButton != null)
                this.NoteDetailsButton(sender, e);

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
                        nothiOnumodonRow.level = group.Key.ToString();
                        nothiOnumodonRow.layerIndex = group.Key;
                        nothiOnumodonRow.isFromNothiNextStep = true;
                        nothiOnumodonRow.CheckBoxButton += delegate (object sender, EventArgs e) { CheckboxOfficer_ButtonClick(sender, e, nothiOnumodonRow._designationId, nothiOnumodonRow._isChecked); };







                    foreach (var officer in group)
                        {

                            nothiOnumodonRow.AddNewOfficerFromNothiNextStep(officer.officer, officer.designation_id, officer.designation + "," + officer.office_unit + "," + officer.nothi_office_name, officer.route_index);
                            

                        }

                    DesignationFLP.Controls.Add(nothiOnumodonRow);



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
                DesignationFLP.Controls.Add(nothiOnumodonRow);
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
        private void btnSend_Click(object sender, EventArgs e)
        {
            List<onumodonDataRecordDTO> newrecords = new List<onumodonDataRecordDTO>();
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();

            foreach (onumodonDataRecordDTO record in records)
            {
                if (record.extra == 1)
                {
                    newrecords.Add(record);
                }               

            }
            var onuchhedForwardResponse = _onuchhedForward.GetOnuchhedForwardResponse(dakListUserParam, newnotedata, nothiListRecord, newrecords);
            if (onuchhedForwardResponse.status == "success")
            {

                MessageBox.Show("প্রক্রিয়াটি সম্পন্ন হয়েছে");
                foreach (Form f in Application.OpenForms)
                { f.Hide(); }
                var form = FormFactory.Create<Nothi>();
                form.ShowDialog();

            }
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
            hideform.Size = this.Size;
            hideform.Opacity = .4;

            hideform.FormBorderStyle = FormBorderStyle.None;
            hideform.StartPosition = FormStartPosition.CenterScreen;
            hideform.Shown += delegate (object sr, EventArgs ev) { hideform_Shown(sr, ev, form); };
            hideform.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            NothiListRecordsDTO nothiListRecords = nothiListRecord;
            var form = FormFactory.Create<NothiOnumodonDesignationSeal>();
            form.nothiListRecordsDTO = nothiListRecord;
            form.GetNothiInboxRecords(nothiListRecords);
            CalPopUpWindow(form);
        }
    }
}
