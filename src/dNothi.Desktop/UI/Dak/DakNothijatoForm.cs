using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.JsonParser.Entity.Dak;
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
    public partial class DakNothijatoForm : Form
    {
        IUserService _userService { get; set; }
        INothiInboxServices _nothiInbox { get; set; }
        INothiAllServices _nothiAll { get; set; }
        IDakNothijatoService _nothijatoService { get; set; }

        public string _dakSubject { get; set; }
        public bool _dakNothijatoLocally { get; set; }
        public NothijatoActionParam _nothiSelected { get; set; }

        INothiNoteTalikaServices _nothinotetalikaservices { get; set; }

        public DakUserParam _userParam = new DakUserParam();

        public DakNothijatoForm(IDakNothijatoService dakNothijatoService, IUserService userService, INothiAllServices nothiAll, INothiNoteTalikaServices nothiNoteTalikaServices,INothiInboxServices inboxServices)
        {
            _nothiInbox = inboxServices;
            _nothiAll = nothiAll;
            _nothijatoService = dakNothijatoService;
            _userService = userService;
            _nothinotetalikaservices = nothiNoteTalikaServices;
            _userParam = _userService.GetLocalDakUserParam();
            InitializeComponent();
            LoadNothiAll();
        }
        public int _dak_id;
        public string _dak_type;
        public int _is_copied_dak;

        public string dak_type
        {
            get { return _dak_type; }
            set { _dak_type = value; }
        }
        public int dakid
        {
            get { return _dak_id; }
            set { _dak_id = value; }
        }

        public int is_copied_dak
        {
            get { return _is_copied_dak; }
            set { _is_copied_dak = value; }
        }

        public string dakSubject { get { return _dakSubject; } set { _dakSubject = value; dakSubjectLabel.Text = value; } }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void LoadNothiInbox()
        {
            DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
            nothiListFlowLayoutPanel.Controls.Clear();
            var nothiInbox = _nothiInbox.GetNothiInbox(dakUserParam);
            if(nothiInbox != null)
            {
                if (nothiInbox.status == "success")
                {
                    //_nothiInbox.SaveOrUpdateNothiRecords(nothiInbox.data.records);

                    if (nothiInbox.data.records.Count > 0)
                    {

                        LoadNothiInboxinPanel(nothiInbox.data.records);

                    }
                }
            }

        }

        private void LoadNothiInboxinPanel(List<NothiListRecordsDTO> nothiLists)
        {
            List<DakModuleAgotoNothiList> nothiInboxs = new List<DakModuleAgotoNothiList>();
            int i = 0;
            foreach (NothiListRecordsDTO nothiListRecordsDTO in nothiLists)
            {
                var nothiInbox = UserControlFactory.Create<DakModuleAgotoNothiList>();
                nothiInbox.nothi = nothiListRecordsDTO.nothi_no + " " + nothiListRecordsDTO.subject;
                nothiInbox.shakha = nothiListRecordsDTO.office_unit_name;
                nothiInbox.totalnothi = "মোট নোটঃ " + nothiListRecordsDTO.note_count;
                nothiInbox.lastdate = "নোটের সর্বশেষ তারিখঃ " + nothiListRecordsDTO.last_note_date;
                nothiInbox.nothiId = Convert.ToString(nothiListRecordsDTO.id);
                nothiInbox.master_id = nothiListRecordsDTO.id.ToString();
                nothiInbox.nothi_id = nothiListRecordsDTO.id.ToString();
                nothiInbox.dak_id = _dak_id;
                nothiInbox.is_copied_dak = _is_copied_dak;
                nothiInbox._dak_type = _dak_type;
               

                NothiAllDTO nothiDTO = new NothiAllDTO();
                nothiDTO.id = Convert.ToInt32(nothiListRecordsDTO.id);
                nothiDTO.nothi_no = nothiListRecordsDTO.nothi_no;
                nothiDTO.office_unit_name = nothiListRecordsDTO.office_unit_name;
                nothiDTO.office_id = nothiListRecordsDTO.office_id;


                nothiInbox.NothijatoButton += delegate (object addSender, EventArgs addEvent) { Nothijato_ButtonClick(addSender, addEvent, nothiDTO); };
                nothiInbox.NothijatoButtonVisible = true;
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
        private void LoadNothiAll()
        {
            _userParam.limit = 10;
            _userParam.page = 1;
            nothiListFlowLayoutPanel.Controls.Clear();
            var nothiAll = _nothiAll.GetNothiAll(_userParam);

            if(nothiAll != null)
            {
                if (nothiAll.status == "success")
                {
                    if (nothiAll.data.records.Count > 0)
                    {
                        LoadNothiAllinPanel(nothiAll.data.records);
                    }

                }
            }
        }
        private void LoadNothiAllinPanel(List<NothiListAllRecordsDTO> nothiAllLists)
        {

            List<DakModuleSokolNothiListUserControl> nothiAlls = new List<DakModuleSokolNothiListUserControl>();
            int i = 0;
            foreach (NothiListAllRecordsDTO nothiAllListDTO in nothiAllLists)
            {
                var nothiAll = UserControlFactory.Create<DakModuleSokolNothiListUserControl>();

                if (nothiAllListDTO.desk != null)
                {

                    nothiAll.nothi = nothiAllListDTO.nothi.nothi_no + " " + nothiAllListDTO.nothi.subject;
                    nothiAll.shakha = "নথির শাখা: " + nothiAllListDTO.nothi.office_unit_name;
                    nothiAll.desk = "ডেস্ক: " + nothiAllListDTO.desk.note_count.ToString();

                    nothiAll.noteLastDate = "নোটের সর্বশেষ তারিখঃ " + nothiAllListDTO.nothi.last_note_date;
                    nothiAll.master_id = nothiAllListDTO.desk.nothi_master_id.ToString();

                    nothiAll.NothiteUposthaponButton += delegate (object addSender, EventArgs addEvent) { Nothijato_ButtonClick(addSender, addEvent, nothiAllListDTO.nothi); };

                    i = i + 1;

                }
                else
                {
                    //NothiAll nothiAll = new NothiAll();
                    nothiAll.nothi = nothiAllListDTO.nothi.nothi_no + " " + nothiAllListDTO.nothi.subject;
                    nothiAll.shakha = "নথির শাখা: " + nothiAllListDTO.nothi.office_unit_name;


                }
                if (nothiAllListDTO.status != null)
                {
                    nothiAll.noteTotal = nothiAllListDTO.status.total;
                    nothiAll.permitted = nothiAllListDTO.status.permitted;
                    nothiAll.onishponno = nothiAllListDTO.status.onishponno;
                    nothiAll.nishponno = nothiAllListDTO.status.nishponno;
                    nothiAll.archived = nothiAllListDTO.status.archived;
                   

                }
                else
                {
                    nothiAll.flag = 1;
                }


                nothiAll.nothi_id = nothiAllListDTO.nothi.id.ToString();
                nothiAll.dak_id = _dak_id;
                nothiAll.is_copied_dak = _is_copied_dak;
                nothiAll._dak_type = _dak_type;
                nothiAll.NothijatoButton += delegate (object addSender, EventArgs addEvent) { Nothijato_ButtonClick(addSender, addEvent, nothiAllListDTO.nothi); };
                nothiAll.NothijatoButtonVisible = true;
                nothiAll.master_id = nothiAllListDTO.nothi.id.ToString();

                nothiAlls.Add(nothiAll);
            }
            nothiListFlowLayoutPanel.Controls.Clear();


            for (int j = 0; j <= nothiAlls.Count - 1; j++)
            {
                nothiListFlowLayoutPanel.Controls.Add(nothiAlls[j]);
            }
        }


        public event EventHandler SucessfullyDakNothijato;
        public event EventHandler MultipleDakNothijato;
        private void Nothijato_ButtonClick(object addSender, EventArgs addEvent, NothiAllDTO nothiDTO)
        {

            NothijatoActionParam nothijatoActionParam = new NothijatoActionParam();
            nothijatoActionParam.nothi_id = nothiDTO.id.ToString();
            nothijatoActionParam.nothi_no = nothiDTO.nothi_no;
            nothijatoActionParam.nothi_office = nothiDTO.office_id.ToString();
            nothijatoActionParam.office_unit = nothiDTO.office_unit_name;



            _nothiSelected = nothijatoActionParam;
            if (_dak_id == 0)
            {
                if (this.MultipleDakNothijato != null)
                    this.MultipleDakNothijato(addSender, addEvent);
                this.Hide();
            }
            else
            {

                    ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
                    conditonBoxForm.message = "ডাকটি এই নথিতে নথিজাত করতে চান?";
                    conditonBoxForm.ShowDialog();




                    if (conditonBoxForm.Yes)
                    {


                        DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
                   



                    DakNothijatoResponse dakNothijatoResponse = _nothijatoService.GetDakNothijatoResponse(dakUserParam, nothijatoActionParam, _dak_id, _dak_type, _is_copied_dak);
                    if (dakNothijatoResponse.message == "Local")
                    {
                        _dakNothijatoLocally = true;
                        SuccessMessage("ইন্টারনেট সংযোগ ফিরে এলে এই ডাকটি নথিজাত করা হবে");

                        
                        if (this.SucessfullyDakNothijato != null)
                            this.SucessfullyDakNothijato(addSender, addEvent);
                        this.Hide();
                    }
                    else if (dakNothijatoResponse.status == "success")
                    {
                        _dakNothijatoLocally = false;
                        SuccessMessage(dakNothijatoResponse.data);
                        if (this.SucessfullyDakNothijato != null)
                            this.SucessfullyDakNothijato(addSender, addEvent);
                        this.Hide();
                    }
                    else
                    {
                        ErrorMessage(dakNothijatoResponse.message);
                    }
                }
            }
            
        }

        private void detailPanelDropDownButton_Click(object sender, EventArgs e)
        {
            if (detailsNothiSearcPanel.Visible)
            {
                detailsNothiSearcPanel.Visible = false;
            }
            else
            {
                detailsNothiSearcPanel.Visible = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DakNothivuktoForm_Load(object sender, EventArgs e)
        {
            Screen scr = Screen.FromPoint(this.Location);
            this.Location = new Point(scr.WorkingArea.Right - this.Width, scr.WorkingArea.Top);

        }

        private void BorderBlueColor(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

        }

        private void nothiTypeSelectSearchBox_Load(object sender, EventArgs e)
        {
            
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

        private void nothiTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (nothiTypeComboBox.SelectedItem.ToString() == "সকল নথি")
            {
                LoadNothiAll();
            }
            else if (nothiTypeComboBox.SelectedItem.ToString() == "অগত নথি")
            {
                LoadNothiInbox();
            }
        }
    }
}
