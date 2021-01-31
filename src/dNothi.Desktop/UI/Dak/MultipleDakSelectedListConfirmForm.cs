using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dNothi.JsonParser.Entity.Dak_List_Inbox;
using dNothi.Services.UserServices;
using dNothi.Services.DakServices;
using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Nothi;

namespace dNothi.Desktop.UI.Dak
{
    public partial class MultipleDakSelectedListConfirmForm : UserControl
    {
        public bool isSuccesfullySaved;
        IUserService _userService { get; set; }

        private DakUserParam _dakuserparam = new DakUserParam();
        IDakKhosraService _dakkhosraservice { get; set; }
        IDakListService _dakListService { get; set; }
        IDakOutboxService _dakOutboxService { get; set; }
        IDakUploadService _dakuploadservice { get; set; }
        IDakInboxServices _dakInbox { get; set; }

        IDakArchiveService _dakArchiveService { get; set; }
        IDakNothijatoService _dakNothijatoService { get; set; }

        IDakNothivuktoService _dakNothivuktoService { get; set; }
        IDakListSortedService _dakListSortedService { get; set; }
        IDakForwardService _dakForwardService { get; set; }

        public NoteNothiDTO _noteSelected { get; set; }


        public NoteNothiDTO noteSelectedAssign { 
            get { return _noteSelected; } 
            set {
                _noteSelected = value;
                ConfirmationOn();
                nothiLabel.Text = value.subject;
                noteSubLabel.Text = value.note_subject;
                
                noteSubLabel.Visible = true;
                noteHeadLabel.Visible = true;


               

                nothiBranchLabel.Text = value.office_unit;
            } 
        } 
        public NothijatoActionParam _nothi { get; set; }


        public NothijatoActionParam nothiSelectedAssign { 
            get { return _nothi; } 
            set {
                _nothi = value;
                ConfirmationOn();
                nothiLabel.Text = value.nothi_no;
               


                nothiBranchLabel.Text = value.office_unit;
            } 
        }

        public MultipleDakSelectedListConfirmForm(IDakInboxServices dakInbox,
            IUserService userService,
            IDakOutboxService dakOutboxService,
            IDakNothivuktoService dakNothivuktoService,
            IDakArchiveService dakListArchiveService,
            IDakListService dakListService,
            IDakListSortedService dakListSortedService,
            IDakForwardService dakForwardService,
            IDakKhosraService dakKhosraService,
            IDakUploadService dakUploadService,
            IDakNothijatoService dakNothijatoService)
        {
            _dakNothivuktoService = dakNothivuktoService;
            _userService = userService;
            _dakOutboxService = dakOutboxService;
            _dakInbox = dakInbox;
            _dakArchiveService = dakListArchiveService;
            _dakNothijatoService = dakNothijatoService;
            _dakListService = dakListService;
            _dakListSortedService = dakListSortedService;
            _dakForwardService = dakForwardService;
            _dakkhosraservice = dakKhosraService;
            _dakuploadservice = dakUploadService;

            _dakuserparam = _userService.GetLocalDakUserParam();

            InitializeComponent();

           



        }
        public bool _isArchive { get; set; }

        public bool isArchive
        {
            get
            {
                return _isArchive;

            }
            set
            {
                _isArchive = value;
                if (value)
                {
                    ArchiveON();
                }
            }

        }

      

        public bool isDakForwardReturn
        {
            get
            {
                return _isForwarded;

            }
            set
            {
                _isForwarded = value;
                if (value)
                {
                    nothiPanel.Visible = false;
                    selectedDakListPanel.Visible = false;
                    confirmButton.Visible = false;
                    actionButton.Visible = false;
                }
            }

        }


        public bool _isNothijato { get; set; }

        public bool isNothijato
        {
            get
            {
                return _isNothijato;

            }
            set
            {
                _isNothijato = value;
                if (value)
                {
                    NothijatoON();
                }
            }

        }


        public bool _isNothivukto { get; set; }

        public bool isNothivukto { 
            get
            {
                return _isNothivukto;
             
            }
            set
            {
                _isNothivukto = value;
                if(value)
                {
                    NothivuktoON();
                }
            }
                
                }

        public bool _isForwarded { get; set; }

        public int _dakCount { get; set; }
        public int dakCount { get { return _dakCount; } set { _dakCount = value; selectedCount.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); } }



        public List<DakListRecordsDTO> _dakListRecordsDTO;
        public List<DakListRecordsDTO> _dakListResponse;

        public List<DakListRecordsDTO> dakListRecordsDTO
        {

            get { return _dakListRecordsDTO; }
            set
            {
                _dakListRecordsDTO = value;
                dakCount = value.Count;

                foreach (DakListRecordsDTO dakListRecordsDTO in value)
                {
                    MultipleSelectedDakListRow selectedDakListUserControl = new MultipleSelectedDakListRow();
                    selectedDakListUserControl.dakUserDTO = dakListRecordsDTO.dak_user;
                    selectedDakListUserControl.prerok = dakListRecordsDTO.movement_status.from.officer;
                    selectedDakListUserControl.DeleteDakFromList += delegate (object sender, EventArgs e) { DeleteDak(); };


                    dakListFlowLayoutPanel.Controls.Add(selectedDakListUserControl);



                }
            }

        }

        private void DeleteDak()
        {
            var dakInboxUserControls = dakListFlowLayoutPanel.Controls.OfType<MultipleSelectedDakListRow>().ToList();
            if (!dakInboxUserControls.Any(a=>a._isDeleted==false))
            {
                var parent = this.Parent as Form; if (parent != null) { parent.Hide(); }
            }
        }




        public int _totalRequest { get; set; }
        public int totalRequest { get { return _totalRequest; } set { _totalRequest = value; ResultPanelON(); selectedDakCount.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); } }


        public int _totalRequestFail { get; set; }
        public int totalRequestFail { get { return _totalRequestFail; } set { _totalRequestFail = value;if (value > 0) { ResultPanelON(); } if (value < _totalRequest) { isSuccesfullySaved = true; } failureDakCount.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); } }


        public int _totalNothivuktoRequest { get; set; }
        public int totalNothivuktoRequest { get { return _totalNothivuktoRequest; } set { _totalNothivuktoRequest = value; NothivuktoPanel.Visible = true;  nothivuktoDakCount.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); } }


        public int _totalArchiveRequest { get; set; }
        public int totalArchiveRequest { get { return _totalArchiveRequest; } set { _totalArchiveRequest = value; archivePanel.Visible = true; archiveHeadline.Visible = true; archiveDakCount.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); } }


        public int _totalNothijatoRequest { get; set; }
        public int totalNothijatoRequest { get { return _totalNothijatoRequest; } set { _totalNothijatoRequest = value; nothijatoPanel.Visible = true; nothijatoHeadline.Visible = true; nothijatoDakCount.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); } }


        public int _totalForwardRequest { get; set; }
        public int totalForwardRequest { get { return _totalForwardRequest; } set { _totalForwardRequest = value; _isForwarded = true; forwardPanel.Visible = true; forwardHeadline.Visible = true; forwardDakCount.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); } }


        public MultipleDakActionResultDakRowUserControl multiplaeDakActionResultAdd { get { return null; } set { failDakListFlowLayoutPanel.Controls.Add(value); } }
        private void ResultPanelON()
        {
            AllInvisible();
            resultCountPanel.Visible = true;
            failDakListFlowLayoutPanel.Visible = true;



        }

        private void NothivuktoON()
        {
            nothivuktoHeadline.Visible = true;
            actionButton.Click += NoteSelectButton_Click;
            confirmButton.Click += MultipleDakNothivukto;
            AllInvisible();
            ActionOn();

        }

        private void NothijatoON()
        {
            nothijatoHeadline.Visible = true;
            actionButton.Click += NothiSelectButton_Click;
            confirmButton.Click += MultipleDakNothijato;
            confirmButton.Text = "নথিজাত করুন";

            AllInvisible();
            ActionOn();

        }

        private void ArchiveON()
        {
            archiveHeadline.Visible = true;
            actionButton.Click += ArchiveButton_Click;


            actionButton.Text = "আর্কাইভ করুন";
            

            AllInvisible();
            ActionOn();

        }

        
        private void ConfirmationOn()
        {
            confirmButton.Visible = true;
            nothiPanel.Visible = true;
        }

        private void ActionOn()
        {
            selectedDakListPanel.Visible = true;
            actionButton.Visible = true;
        }

        private void AllInvisible()
        {
            selectedDakListPanel.Visible = false;
            nothiPanel.Visible = false;
            resultCountPanel.Visible = false;
            failDakListFlowLayoutPanel.Visible = false;
            confirmButton.Visible = false;
            actionButton.Visible = false;
        }

        private void NothiSelectButton_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<DakNothijatoForm>();
            form._dak_id = 0;
            form.MultipleDakNothijato += delegate (object snd, EventArgs eve) { MultipleDakNothijatoConfirm(form._nothiSelected); };

            form.ShowDialog();
        }

        private void MultipleDakNothijatoConfirm(NothijatoActionParam nothiSelected)
        {
            nothiSelectedAssign = nothiSelected;
            
        }

        public event EventHandler SucessfullyDakNothijato;
        private void MultipleDakNothijato(object sender, EventArgs e)
        {
            int _totalForwardRequest = 0;
            int _totalSuccessForwardRequest = 0;
            int _totalFailForwardRequest = 0;


            var dakListSelected = dakListFlowLayoutPanel.Controls.OfType<MultipleSelectedDakListRow>().ToList();

            if (dakListSelected.Count > 0)
            {
                var dakListSelectedFinal = dakListSelected.Where(a => a._isDeleted == false).ToList();

                if (dakListSelectedFinal.Count > 0)
                {
                    foreach (MultipleSelectedDakListRow dakSelected in dakListSelectedFinal)
                    {
                        _totalForwardRequest += 1;
                        DakNothijatoResponse dakNothijatoResponse = _dakNothijatoService.GetDakNothijatoResponse(_dakuserparam, _nothi, dakSelected.dakUserDTO.dak_id, dakSelected.dakUserDTO.dak_type, dakSelected.dakUserDTO.is_copied_dak);

                        if (dakNothijatoResponse.status == "success")
                        {
                            _totalSuccessForwardRequest += 1;
                        }
                        else
                        {
                            _totalFailForwardRequest += 1;

                            MultipleDakActionResultDakRowUserControl multipleDakActionResultDakRowUserControl = new MultipleDakActionResultDakRowUserControl();


                            multipleDakActionResultDakRowUserControl.dakUserDTO = dakSelected.dakUserDTO;
                            multipleDakActionResultDakRowUserControl.error = dakNothijatoResponse.data;
                            multipleDakActionResultDakRowUserControl.prerok = dakSelected._prerok;
                            failDakListFlowLayoutPanel.Controls.Add(multipleDakActionResultDakRowUserControl);

                        }


                    }
                }
            }


            totalRequest = _totalForwardRequest;
            totalRequestFail = _totalFailForwardRequest;
            totalNothijatoRequest = _totalSuccessForwardRequest;
        }

        private void NoteSelectButton_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<DakNothiteUposthapitoForm>();
            form._dak_id = 0;
            form.MultipleDakNothivukto += delegate (object snd, EventArgs eve) { MultipleDakNothivuktoConfirm(form._noteSelected,form._nothiName,form._nothiBranch); };


            form.ShowDialog();
        }

        private void MultipleDakNothivuktoConfirm(NoteNothiDTO noteSelected,string nothiName,string nothiBranch)
        {
            noteSelectedAssign = noteSelected;
            nothiBranchLabel.Text = nothiBranch;
            nothiLabel.Text = nothiName;
            
        }

        public event EventHandler SucessfullyDakNothivukto;
        private void MultipleDakNothivukto(object sender, EventArgs e)
        {
            int _totalForwardRequest = 0;
            int _totalSuccessForwardRequest = 0;
            int _totalFailForwardRequest = 0;


            var dakListSelected = dakListFlowLayoutPanel.Controls.OfType<MultipleSelectedDakListRow>().ToList();

            if (dakListSelected.Count > 0)
            {

                var dakListSelectedFinal = dakListSelected.Where(a => a._isDeleted == false).ToList();

                if (dakListSelectedFinal.Count > 0)
                {
                    foreach (MultipleSelectedDakListRow dakSelected in dakListSelectedFinal)
                    {
                        _totalForwardRequest += 1;

                        DakNothivuktoResponse dakNothivuktoResponse = _dakNothivuktoService.GetDakNothivuktoResponse(_dakuserparam, _noteSelected, dakSelected.dakUserDTO.dak_id, dakSelected.dakUserDTO.dak_type, dakSelected.dakUserDTO.is_copied_dak);
                        if (dakNothivuktoResponse.status == "success")
                        {
                            _totalSuccessForwardRequest += 1;
                        }
                        else
                        {
                            _totalFailForwardRequest += 1;

                            MultipleDakActionResultDakRowUserControl multipleDakActionResultDakRowUserControl = new MultipleDakActionResultDakRowUserControl();


                            multipleDakActionResultDakRowUserControl.dakUserDTO = dakSelected.dakUserDTO;
                            multipleDakActionResultDakRowUserControl.error = dakNothivuktoResponse.message;
                            multipleDakActionResultDakRowUserControl.prerok = dakSelected._prerok;
                            failDakListFlowLayoutPanel.Controls.Add(multipleDakActionResultDakRowUserControl);


                        }


                    }
                }
            }


            totalRequest = _totalForwardRequest;
            totalRequestFail = _totalFailForwardRequest;
            totalNothivuktoRequest = _totalSuccessForwardRequest;
        }


        public event EventHandler SucessfullyDakArchived;
        private void ArchiveButton_Click(object sender, EventArgs e)
        {


            int _totalForwardRequest = 0;
            int _totalSuccessForwardRequest = 0;
            int _totalFailForwardRequest = 0;


            var dakListSelected = dakListFlowLayoutPanel.Controls.OfType<MultipleSelectedDakListRow>().ToList();
           
            if (dakListSelected.Count > 0)
            {
                var dakListSelectedFinal = dakListSelected.Where(a=>a._isDeleted==false).ToList();

                if (dakListSelectedFinal.Count > 0)
                {
                    foreach (MultipleSelectedDakListRow dakSelected in dakListSelectedFinal)
                    {
                        _totalForwardRequest += 1;

                        DakArchiveResponse dakArchiveResponse = _dakArchiveService.GetDakArcivedResponse(_dakuserparam, dakSelected._dakUserDTO.dak_id, dakSelected._dakUserDTO.dak_type, dakSelected._dakUserDTO.is_copied_dak);
                        if (dakArchiveResponse.status == "success")
                        {
                            _totalSuccessForwardRequest += 1;
                           
                        }
                        else
                        {
                            _totalFailForwardRequest += 1;

                            MultipleDakActionResultDakRowUserControl multipleDakActionResultDakRowUserControl = new MultipleDakActionResultDakRowUserControl();


                            multipleDakActionResultDakRowUserControl.dakUserDTO = dakSelected.dakUserDTO;
                            multipleDakActionResultDakRowUserControl.error = dakArchiveResponse.data;
                            multipleDakActionResultDakRowUserControl.prerok = dakSelected._prerok;
                            failDakListFlowLayoutPanel.Controls.Add(multipleDakActionResultDakRowUserControl);

                        }


                    }
                }
            }


            totalRequest = _totalForwardRequest;
            totalRequestFail = _totalFailForwardRequest;
            totalArchiveRequest = _totalSuccessForwardRequest;
         
            




        }



        public event EventHandler SucessfullyDakForwarded;
        private void CloseButton_Click(object sender, EventArgs e)
        {
            if(isSuccesfullySaved && _isNothivukto)
            {
                if (this.SucessfullyDakNothivukto != null)
                    this.SucessfullyDakNothivukto(sender, e);
              
            }
            else if(isSuccesfullySaved && _isNothijato)
            {
                if (this.SucessfullyDakNothijato != null)
                    this.SucessfullyDakNothijato(sender, e);
            }
            else if (_isArchive && isSuccesfullySaved)
            {
                if (this.SucessfullyDakArchived != null)
                    this.SucessfullyDakArchived(sender, e);
            }

            else if (_isForwarded && isSuccesfullySaved)
            {
                if (this.SucessfullyDakForwarded != null)
                    this.SucessfullyDakForwarded(sender, e);
            }


            var parent = this.Parent as Form; if (parent != null) { parent.Hide(); }
        }

        private void BlueBorder(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

        }
    }
}
