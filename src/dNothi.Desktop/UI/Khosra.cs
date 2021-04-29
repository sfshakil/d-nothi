using dNothi.Desktop.UI.Khosra_Potro;
using dNothi.Desktop.UI.ManuelUserControl;
using dNothi.JsonParser.Entity.Dak;
using dNothi.JsonParser.Entity.Khosra;
using dNothi.Services.DakServices;
using dNothi.Services.KhasraService;
using dNothi.Services.UserServices;
using dNothi.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.IO;
using dNothi.Desktop.UI.Dak;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.JsonParser;
using HtmlAgilityPack;
using dNothi.Desktop.UI.CustomMessageBox;

namespace dNothi.Desktop.UI
{
    public partial class Khosra : Form
    {
        IUserService _userService { get; set; }
        IKhosraSaveService _khosraSaveService { get; set; }
        IDakForwardService _dakForwardService { get; set; }
        IKhasraTemplateService _khasraTemplateService { get; set; }

        public PrapokDTO _OnumodonOffice;
    
        public KhasraPotroTemplateResponse khasraPotroTemplateResponse { get; set; }
        public WaitFormFunc WaitForm;
        public Khosra(IKhosraSaveService khosraSaveService,IUserService userService, IKhasraTemplateService khasraTemplateService, IDakForwardService dakForwardService)
        {
            _khosraSaveService = khosraSaveService;

            _userService = userService;
            _dakForwardService = dakForwardService;
            _khasraTemplateService = khasraTemplateService;
            WaitForm = new WaitFormFunc();
            InitializeComponent();
            //WaitForm.Show(this);
           
            //CreateEditor();
          
           // WaitForm.Close();
        }

        private void CreateEditor()
        {
            if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"tinymce\js\tinymce\tinymce.min.js")))
            {
                tinyMceEditor.Load(@"file:///" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"tinymce/tinymce.htm").Replace('\\', '/'));
               
           
            }
            else
            {
                MessageBox.Show("Could not find the tinyMCE script directory. Please ensure the directory is in the same location as tinymce.htm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private string _nothiShakha;
        private string _nothiNo;
        private string _nothiSubject;


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
        private void Khosra_Shown(object sender, EventArgs e)
        {
            //khoshraBackgroundWorker.RunWorkerAsync();

            //tinyMceEditor.GetMainFrame().ExecuteScriptAsync("SetContent", new object[] { _khasraPotroTemplateData.html_content });
            //tinyMceEditor.GetMainFrame().ExecuteScriptAsync("tinyMCE.execCommand('mceFullScreen')");

        }

        private void Template_CLick(KhasraPotroTemplateDataDTO khasraPotroTemplateData)
        {

            if(_khasraPotroTemplateData.template_id != khasraPotroTemplateData.template_id)
            {
                _khasraPotroTemplateData = khasraPotroTemplateData;
                LoadNewTemplate();
            }

            tinyMceEditor.ExecuteScriptAsync("SetContent", new object[] { khasraPotroTemplateData.html_content });
            tinyMceEditor.ExecuteScriptAsync("tinyMCE.execCommand('mceFullScreen')");
           
        }

        private void Border_Color_Blue(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).ClientRectangle, Color.FromArgb(203, 225, 248), ButtonBorderStyle.Solid);

        }

        private void LoadDakPriority()
        {
            DakPriorityList dakPriorityList = new DakPriorityList(true);
            dakPriorityComboBox.DataSource = null;
           
            dakPriorityComboBox.DataSource = dakPriorityList._dakPriority.OrderBy(a => a._id).ToList();
            dakPriorityComboBox.DisplayMember = "_typeName";
            dakPriorityComboBox.ValueMember = "_id";
        }

        private void LoadDakSecurity()
        {
            DakSecurityList dakSecurityList = new DakSecurityList(true);
          
            dakSecrurityComboBox.DataSource = null;

            dakSecrurityComboBox.DataSource  = dakSecurityList._dakSecurities.OrderBy(a => a._id).ToList();
            dakSecrurityComboBox.DisplayMember = "_typeName";
           
            dakSecrurityComboBox.ValueMember = "_id";
          

        }

        private void onumodonkariListShowButton_Click(object sender, EventArgs e)
        {
            if (onumodonkariListShowButton.IconChar == FontAwesome.Sharp.IconChar.CaretRight)
            {

                ReloadOfficerList(onumodonkariListShowButton, onumodonkariListPanel,onumodonkariEmptyPanel,onumodonkariListFlowLayoutPanel);

            }


            else
            {
                onumodonkariListShowButton.IconChar = FontAwesome.Sharp.IconChar.CaretRight;
                onumodonkariListPanel.Visible = false;
            }
        }

        private void prapokListShowButton_Click(object sender, EventArgs e)
        {
            if (prapokListShowButton.IconChar == FontAwesome.Sharp.IconChar.CaretRight)
            {
                prapokListShowButton.IconChar = FontAwesome.Sharp.IconChar.CaretDown;

                if (prapokListFlowLayoutPanel.Controls.Count == 0)
                {
                    prapokEmptyPanel.Visible = true;
                }
                prapokListPanel.Visible = true;
            }
            else
            {
                prapokListShowButton.IconChar = FontAwesome.Sharp.IconChar.CaretRight;
                prapokListPanel.Visible = false;
            }
        }

        private void prerokListShowButton_Click(object sender, EventArgs e)
        {
            if (prerokListShowButton.IconChar == FontAwesome.Sharp.IconChar.CaretRight)
            {
                prerokListShowButton.IconChar = FontAwesome.Sharp.IconChar.CaretDown;

                if (prerokListFlowLayoutPanel.Controls.Count == 0)
                {
                    prerokEmptyPanel.Visible = true;
                }
                prerokListPanel.Visible = true;
            }
            else
            {
                prerokListShowButton.IconChar = FontAwesome.Sharp.IconChar.CaretRight;
                prerokListPanel.Visible = false;
            }
        }

        private void attentionListShowButton_Click(object sender, EventArgs e)
        {
            if (attentionListShowButton.IconChar == FontAwesome.Sharp.IconChar.CaretRight)
            {
                attentionListShowButton.IconChar = FontAwesome.Sharp.IconChar.CaretDown;

                if (attentionListFlowLayoutPanel.Controls.Count == 0)
                {
                    attentionEmptyPanel.Visible = true;
                }
                attentionListPanel.Visible = true;
            }
            else
            {
                attentionListShowButton.IconChar = FontAwesome.Sharp.IconChar.CaretRight;
                attentionListPanel.Visible = false;
            }
        }

        private void onulipiListShowButton_Click(object sender, EventArgs e)
        {
            if (onulipiListShowButton.IconChar == FontAwesome.Sharp.IconChar.CaretRight)
            {
                onulipiListShowButton.IconChar = FontAwesome.Sharp.IconChar.CaretDown;

                if (onulipiListFlowLayoutPanel.Controls.Count == 0)
                {
                    onulipiEmptyPanel.Visible = true;
                }
                onulipiListPanel.Visible = true;
            }
            else
            {
                onulipiListShowButton.IconChar = FontAwesome.Sharp.IconChar.CaretRight;
                onulipiListPanel.Visible = false;
            }
        }

        private void attentionSelectButtonPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        
       



        public DesignationSealListResponse _designationSealListResponse { get; set; }
        private void onumodonkariOfficerSelectButton_Click(object sender, EventArgs e)
        {
            SelectOfficer(onumodonkariOfficerSelectButton,onumodonkariListPanel, onumodonkariEmptyPanel,onumodonkariListFlowLayoutPanel);
        }

        private void SelectOfficer(FontAwesome.Sharp.IconButton officerSelectButton, Panel officerListPanel, Panel officerEmptyPanel, FlowLayoutPanel officerListFlowLayoutPanel)
        {
            SelectOfficerForm selectOfficerForm = new SelectOfficerForm();
            
            if(officerSelectButton == onumodonkariOfficerSelectButton || officerSelectButton== prerokListShowButton)
            {
                selectOfficerForm._isOneOfficerAllowed = true;
            }
               



        

            selectOfficerForm.designationSealListResponse = _designationSealListResponse;

            selectOfficerForm.SaveButtonClick += delegate (object se, EventArgs ev) { SaveOfficerinOnumodonKariOfficerList(officerSelectButton,selectOfficerForm._selectedOfficerDesignations, officerListPanel, officerEmptyPanel, officerListFlowLayoutPanel); };

            UIDesignCommonMethod.CalPopUpWindow(selectOfficerForm,this);
        }

        private void SaveOfficerinOnumodonKariOfficerList(FontAwesome.Sharp.IconButton officerSelectButton, List<int> selectedOfficerDesignations, Panel officerListPanel, Panel officerEmptyPanel, FlowLayoutPanel officerListFlowLayoutPanel)
        {
            officerListFlowLayoutPanel.Controls.Clear();



            if (selectedOfficerDesignations.Count > 0)
            {
                foreach (int id in selectedOfficerDesignations)
                {
                    var designationSeal = _designationSealListResponse.data.other_office.FirstOrDefault(a => a.designation_id == id);
                    if (designationSeal == null)
                    {
                        designationSeal = _designationSealListResponse.data.own_office.FirstOrDefault(a => a.designation_id == id);
                    }

                    if (designationSeal != null)
                    {
                        OfficerRowUserControl officerRowUserControl = new OfficerRowUserControl();
                        officerRowUserControl.officerName = designationSeal.NameWithDesignation;
                        officerRowUserControl.designationId = designationSeal.designation_id;
                        officerRowUserControl.officerInfo = designationSeal;
                        officerRowUserControl.Dock = DockStyle.Top;
                        //  officerRowUserControl.Width = onumodonkariListFlowLayoutPanel.Width - 30;
                        officerRowUserControl.DeleteButton += delegate (object se, EventArgs ev) {

                              ReloadOfficerList(officerSelectButton,officerListPanel, officerEmptyPanel, officerListFlowLayoutPanel);};

                            officerListFlowLayoutPanel.Controls.Add(officerRowUserControl);


                        
                    }
            



                   

                }
                ReloadOfficerList(officerSelectButton, officerListPanel, officerEmptyPanel, officerListFlowLayoutPanel);



            }
        }
        private void ReloadOfficerList(FontAwesome.Sharp.IconButton officerSelectButton, Panel onumodonkariListPanel, Panel onumodonkariEmptyPanel, FlowLayoutPanel onumodonkariListFlowLayoutPanel)
        {
            var officerList = onumodonkariListFlowLayoutPanel.Controls.OfType<OfficerRowUserControl>().Where(a => a.Hide != true).ToList();



            if (officerList.Count == 0)
            {
                onumodonkariEmptyPanel.Visible = true;
            }
            else
            {
                onumodonkariEmptyPanel.Visible = false;
            }

            if(officerSelectButton==onumodonkariOfficerSelectButton)
            {
                onumodonkariListShowButton.IconChar = FontAwesome.Sharp.IconChar.CaretDown;
                AddOnumodonOfficertoScript(officerList);
                

            }

            else if (officerSelectButton== prapokListShowButton)
            {
                prapokListShowButton.IconChar = FontAwesome.Sharp.IconChar.CaretDown;
                AddPrapokOfficerstoScript(officerList);


            }
            else if (officerSelectButton== prerokListShowButton)
            {
                prerokListShowButton.IconChar = FontAwesome.Sharp.IconChar.CaretDown;
                AddSenderOfficertoScript(officerList);


            }
            else if(officerSelectButton == attentionListShowButton)
            {
                attentionListShowButton.IconChar = FontAwesome.Sharp.IconChar.CaretDown;
                AddAttentionOfficersOfficertoScript(officerList);
            }
            else if(officerSelectButton == onulipiListShowButton)
            {
                onulipiListShowButton.IconChar = FontAwesome.Sharp.IconChar.CaretDown;
                AddOnulipiOfficersOfficertoScript(officerList);
            }

            onumodonkariListPanel.Visible = true;
        }

        public string onulipiofficersScript;
        public List<PrapokDTO> onulipiOfficers;
        private async void AddOnulipiOfficersOfficertoScript(List<OfficerRowUserControl> officerList)
        {
            if (_currentHtmlString == null || _currentHtmlString == "")
            {
                JavascriptResponse response = await tinyMceEditor.EvaluateScriptAsync("GetContent()");

                _currentHtmlString = response.Result.ToString();
            }

            // htmlString = htmlString.Replace(System.Environment.NewLine, "");

            if (officerList.Count > 0)
            {
                List<string> officerListString = new List<string>();
                onulipiOfficers = new List<PrapokDTO>();
                foreach (OfficerRowUserControl officerRowUserControl in officerList)
                {
                    onulipiOfficers.Add(officerRowUserControl.officerInfo);
                    officerListString.Add(officerRowUserControl.officerInfo.designation_bng + "," + officerRowUserControl.officerInfo.unit_name_bng + "," + officerRowUserControl.officerInfo.office_bng);

                }
                _currentHtmlString = _currentHtmlString.Replace(KhoshraTemplateHtmlStringChange.OnulipiDivHive, KhoshraTemplateHtmlStringChange.OnulipiDivShow);
                _currentHtmlString = _currentHtmlString.Replace(KhoshraTemplateHtmlStringChange.OnulipiNumAndDateHive, KhoshraTemplateHtmlStringChange.OnulipiNumAndDateShow);
               
                string officerListHtml =  KhoshraTemplateHtmlStringChange.AddOnulipiOfficerintheList(officerListString);

                if (onulipiofficersScript != null && onulipiofficersScript != "")
                {
                    _currentHtmlString = _currentHtmlString.Replace(onulipiofficersScript, officerListHtml);

                }
                else
                {
                    _currentHtmlString = _currentHtmlString.Replace(KhoshraTemplateHtmlStringChange.OnulipiListOriginal, officerListHtml);

                }

                onulipiofficersScript = officerListHtml;

            }
            else
            {

                attentionOfficers = null;
                _currentHtmlString = _currentHtmlString.Replace(KhoshraTemplateHtmlStringChange.OnulipiDivShow, KhoshraTemplateHtmlStringChange.OnulipiDivHive);
                _currentHtmlString = _currentHtmlString.Replace(KhoshraTemplateHtmlStringChange.OnulipiNumAndDateShow, KhoshraTemplateHtmlStringChange.OnulipiNumAndDateHive);
                if (onulipiofficersScript != null && onulipiofficersScript != "")
                {
                    _currentHtmlString = _currentHtmlString.Replace(onulipiofficersScript, KhoshraTemplateHtmlStringChange.OnulipiListOriginal);
                    onulipiofficersScript = "";
                }



            }
            _khasraPotroTemplateData.html_content = _currentHtmlString;

            Template_CLick(_khasraPotroTemplateData);
        }

        public string attentionofficersScript;
        public List<PrapokDTO> attentionOfficers;
        private async void AddAttentionOfficersOfficertoScript(List<OfficerRowUserControl> officerList)
        {
            if (_currentHtmlString == null || _currentHtmlString == "")
            {
                JavascriptResponse response = await tinyMceEditor.EvaluateScriptAsync("GetContent()");

                _currentHtmlString = response.Result.ToString();
            }

            // htmlString = htmlString.Replace(System.Environment.NewLine, "");

            if (officerList.Count > 0)
            {
                List<string> officerListString = new List<string>();
                attentionOfficers = new List<PrapokDTO>();
                foreach (OfficerRowUserControl officerRowUserControl in officerList)
                {
                    attentionOfficers.Add(officerRowUserControl.officerInfo);
                    officerListString.Add(officerRowUserControl.officerInfo.designation_bng + "," + officerRowUserControl.officerInfo.unit_name_bng + "," + officerRowUserControl.officerInfo.office_bng);

                }
                _currentHtmlString = _currentHtmlString.Replace(KhoshraTemplateHtmlStringChange.AttentionOfficerDivHide, KhoshraTemplateHtmlStringChange.AttentionOfficerDivShow);
                string officerListHtml = KhoshraTemplateHtmlStringChange.AttentionOfficerPOriginal + KhoshraTemplateHtmlStringChange.AddAttentionOfficerintheList(officerListString);

                if (attentionofficersScript != null && attentionofficersScript != "")
                {
                    _currentHtmlString = _currentHtmlString.Replace(attentionofficersScript, officerListHtml);

                }
                else
                {
                    _currentHtmlString = _currentHtmlString.Replace(KhoshraTemplateHtmlStringChange.AttentionOfficerPOriginal, officerListHtml);

                }

                attentionofficersScript = officerListHtml;

            }
            else
            {

                attentionOfficers = null;
                _currentHtmlString = _currentHtmlString.Replace(KhoshraTemplateHtmlStringChange.AttentionOfficerDivShow, KhoshraTemplateHtmlStringChange.AttentionOfficerDivHide);
                if (attentionofficersScript != null && attentionofficersScript != "")
                {
                    _currentHtmlString = _currentHtmlString.Replace(attentionofficersScript, KhoshraTemplateHtmlStringChange.AttentionOfficerPOriginal);
                    attentionofficersScript = "";
                }



            }
            _khasraPotroTemplateData.html_content = _currentHtmlString;

            Template_CLick(_khasraPotroTemplateData);
        }



        public string prapokofficersScript;
        public List<PrapokDTO> prapokOfficers;
        public string _currentHtmlString;


        private  void LoadNewTemplate()
        {
            prapokofficersScript = null;
            _currentHtmlString = null;
            prapokOfficers = null;
        }
        
        private async void AddPrapokOfficerstoScript(List<OfficerRowUserControl> officerList)
        {
            
            if (_currentHtmlString ==null || _currentHtmlString =="")
            {
                JavascriptResponse response = await tinyMceEditor.EvaluateScriptAsync("GetContent()");

                 _currentHtmlString = response.Result.ToString();
            }

            // htmlString = htmlString.Replace(System.Environment.NewLine, "");

            if (officerList.Count>0)
            {
                List<string> officerListString = new List<string>();
                prapokOfficers = new List<PrapokDTO>();
                foreach (OfficerRowUserControl officerRowUserControl in officerList)
                {
                    prapokOfficers.Add(officerRowUserControl.officerInfo);
                    officerListString.Add(officerRowUserControl.officerInfo.designation_bng + "," + officerRowUserControl.officerInfo.unit_name_bng + "," + officerRowUserControl.officerInfo.office_bng);

                }
                _currentHtmlString = _currentHtmlString.Replace(KhoshraTemplateHtmlStringChange.KhoshraReceivingdivHide, KhoshraTemplateHtmlStringChange.KhoshraReceivingdivShow);
                string officerListHtml = KhoshraTemplateHtmlStringChange.KhoshraReceivingTitleShow + KhoshraTemplateHtmlStringChange.AddReceiverintheList(officerListString);

                if (prapokofficersScript != null && prapokofficersScript != "")
                {
                    _currentHtmlString = _currentHtmlString.Replace(prapokofficersScript, officerListHtml);
                   
                }
                else
                {
                    _currentHtmlString = _currentHtmlString.Replace(KhoshraTemplateHtmlStringChange.KhoshraReceivingTitleHide, officerListHtml);

                }

                prapokofficersScript = officerListHtml;
                
            }
               else
                {

                   prapokOfficers = null;
                _currentHtmlString = _currentHtmlString.Replace(KhoshraTemplateHtmlStringChange.KhoshraReceivingdivShow,KhoshraTemplateHtmlStringChange.KhoshraReceivingdivHide);
                if (prapokofficersScript!=null && prapokofficersScript !="")
                {
                    _currentHtmlString = _currentHtmlString.Replace(prapokofficersScript, KhoshraTemplateHtmlStringChange.KhoshraReceivingTitleHide);
                    prapokofficersScript = "";
                }
                
                

                }
            _khasraPotroTemplateData.html_content =_currentHtmlString;

            Template_CLick(_khasraPotroTemplateData);

        }



        private string _onumodonOfficer;
        private string _onumodonDesignation;
        private string _onumodonPhone;
        private string _onumodonEmail;
        private string _onumodonFax;
        List<PrapokDTO> onumodonOfficer;
        private async void AddOnumodonOfficertoScript(List<OfficerRowUserControl> officerList)
        {

            if(_currentHtmlString == null || _currentHtmlString =="")
            {
                JavascriptResponse response = await tinyMceEditor.EvaluateScriptAsync("GetContent()");

                _currentHtmlString = response.Result.ToString();
            }


            if(officerList.Count>0)
            {
                onumodonOfficer = new List<PrapokDTO>();
                onumodonOfficer.Add(officerList[0]._officerInfo);
                string phone_Temp = KhoshraTemplateHtmlStringChange.onumodonkariPhoneNew(officerList[0]._officerInfo.personal_mobile);
                string Email_Temp = KhoshraTemplateHtmlStringChange.onumodonkariEmailNew(officerList[0]._officerInfo.personal_email);
                string Fax_Temp = KhoshraTemplateHtmlStringChange.onumodonkariFaxNew("");
                string Officer_Temp = KhoshraTemplateHtmlStringChange.onumodonkariOfficerNew(officerList[0]._officerInfo.officer_bng);
                string designation_Temp = KhoshraTemplateHtmlStringChange.onumodonkariDesignationNew(officerList[0]._officerInfo.designation_bng);


                if (_onumodonOfficer != null)
                {
                    _currentHtmlString = _currentHtmlString.Replace(_onumodonPhone, phone_Temp);
                    _currentHtmlString = _currentHtmlString.Replace(_onumodonEmail, Email_Temp);
                    _currentHtmlString = _currentHtmlString.Replace(_onumodonFax, Fax_Temp);
                    _currentHtmlString = _currentHtmlString.Replace(_onumodonOfficer, Officer_Temp);
                    _currentHtmlString = _currentHtmlString.Replace(_onumodonDesignation, designation_Temp);

                }
                else
                {


                   

                   _currentHtmlString= _currentHtmlString.Replace(KhoshraTemplateHtmlStringChange.onumodonkariPhoneOriginal, phone_Temp);
                    _currentHtmlString = _currentHtmlString.Replace(KhoshraTemplateHtmlStringChange.onumodonkariEmailOriginal, Email_Temp);
                    _currentHtmlString = _currentHtmlString.Replace(KhoshraTemplateHtmlStringChange.onumodonkariFaxOriginal, Fax_Temp);
                    _currentHtmlString = _currentHtmlString.Replace(KhoshraTemplateHtmlStringChange.onumodonkariOfficerOriginal, Officer_Temp);
                    _currentHtmlString = _currentHtmlString.Replace(KhoshraTemplateHtmlStringChange.onumodonkariDesignationOriginal, designation_Temp);

                }

                _onumodonPhone= phone_Temp;
                _onumodonEmail= Email_Temp;
                _onumodonFax= Fax_Temp;
                _onumodonOfficer= Officer_Temp;
                _onumodonDesignation= designation_Temp;


            }
            else
            {
                _currentHtmlString = _currentHtmlString.Replace(_onumodonDesignation, KhoshraTemplateHtmlStringChange.onumodonkariDesignationOriginal);
                _currentHtmlString = _currentHtmlString.Replace(_onumodonEmail, KhoshraTemplateHtmlStringChange.onumodonkariEmailOriginal);
                _currentHtmlString = _currentHtmlString.Replace(_onumodonFax, KhoshraTemplateHtmlStringChange.onumodonkariFaxOriginal);
                _currentHtmlString = _currentHtmlString.Replace(_onumodonOfficer, KhoshraTemplateHtmlStringChange.onumodonkariOfficerOriginal);
                _currentHtmlString = _currentHtmlString.Replace(_onumodonPhone, KhoshraTemplateHtmlStringChange.onumodonkariPhoneOriginal);

                _onumodonDesignation = null;
                _onumodonEmail = null;
                _onumodonFax = null;
                _onumodonOfficer = null;
                _onumodonPhone = null;

            }

            _khasraPotroTemplateData.html_content = _currentHtmlString;
            Template_CLick(_khasraPotroTemplateData);

        }

        private string _senderOfficer;
        private string _senderDesignation;
        List<PrapokDTO> senderOfficer;
        private async void AddSenderOfficertoScript(List<OfficerRowUserControl> officerList)
        {

            if (_currentHtmlString == null || _currentHtmlString == "")
            {
                JavascriptResponse response = await tinyMceEditor.EvaluateScriptAsync("GetContent()");

                _currentHtmlString = response.Result.ToString();
            }


            if (officerList.Count > 0)
            {
                senderOfficer = new List<PrapokDTO>();
                senderOfficer.Add(officerList[0]._officerInfo);

                _currentHtmlString = _currentHtmlString.Replace(KhoshraTemplateHtmlStringChange.PrerokHide, KhoshraTemplateHtmlStringChange.PrerokShow);

                string officer_Temp = KhoshraTemplateHtmlStringChange.PrerokOfficerNew(officerList[0]._officerInfo.officer_bng);
                string designation_Temp = KhoshraTemplateHtmlStringChange.PrerokDesignationNew(officerList[0]._officerInfo.designation_bng);



                if (_senderOfficer != null)
                {
                    _currentHtmlString= _currentHtmlString.Replace(_senderOfficer, officer_Temp);
                    _currentHtmlString= _currentHtmlString.Replace(_senderDesignation, designation_Temp);

                }
                else
                {
                    _currentHtmlString = _currentHtmlString.Replace(KhoshraTemplateHtmlStringChange.PrerokOfficerOriginal, officer_Temp);
                    _currentHtmlString = _currentHtmlString.Replace(KhoshraTemplateHtmlStringChange.PrerokDesignationOriginal, designation_Temp);

                }

                _senderOfficer = officer_Temp;
                _senderDesignation = designation_Temp;


            }
            else
            {
                _currentHtmlString = _currentHtmlString.Replace(_senderOfficer, KhoshraTemplateHtmlStringChange.PrerokOfficerOriginal);
                _currentHtmlString = _currentHtmlString.Replace(_senderDesignation, KhoshraTemplateHtmlStringChange.PrerokDesignationOriginal);
                _senderOfficer = null;
                _senderDesignation = null;
                _currentHtmlString = _currentHtmlString.Replace(KhoshraTemplateHtmlStringChange.PrerokShow, KhoshraTemplateHtmlStringChange.PrerokHide);

            }

            _khasraPotroTemplateData.html_content = _currentHtmlString;
            Template_CLick(_khasraPotroTemplateData);

        }

        public System.Windows.Forms.HtmlDocument GetHtmlDocument(string html)
        {
            WebBrowser browser = new WebBrowser();
            browser.ScriptErrorsSuppressed = true;
            browser.DocumentText = html;
            browser.Document.OpenNew(true);
            browser.Document.Write(html);
            browser.Refresh();
            return browser.Document;
        }

        private void prapokOfficerSelectButton_Click(object sender, EventArgs e)
        {
            SelectOfficer(prapokListShowButton, prapokListPanel, prapokEmptyPanel, prapokListFlowLayoutPanel);

        }

        private void prerokOfficerSelectButton_Click(object sender, EventArgs e)
        {
            SelectOfficer(prerokListShowButton,prerokListPanel, prerokEmptyPanel, prerokListFlowLayoutPanel);
        }

        private void attentionOfficerSelectButton_Click(object sender, EventArgs e)
        {
            SelectOfficer(attentionListShowButton, attentionListPanel, attentionEmptyPanel, attentionListFlowLayoutPanel);
        }

        private void onulipiOfficerSelectButton_Click(object sender, EventArgs e)
        {
            SelectOfficer(onulipiListShowButton, onulipiListPanel, onulipiEmptyPanel, onulipiListFlowLayoutPanel);
        }

        private void newAttachmentButton_Click(object sender, EventArgs e)
        {
            KhosraAttachmentForm khosraAttachmentForm = new KhosraAttachmentForm();
            UIDesignCommonMethod.CalPopUpWindow(khosraAttachmentForm, this);
        }

        private void khosraReviewButton_Click(object sender, EventArgs e)
        {
            SelectOfficersFormKhosraReview selectOfficerForm = new SelectOfficersFormKhosraReview();
            selectOfficerForm.designationSealListResponse = _designationSealListResponse;

            //selectOfficerForm.SaveButtonClick += delegate (object se, EventArgs ev) { SaveOfficerinOnumodonKariOfficerList(officerSelectButton, selectOfficerForm._selectedOfficerDesignations, officerListPanel, officerEmptyPanel, officerListFlowLayoutPanel); };

            UIDesignCommonMethod.CalPopUpWindow(selectOfficerForm, this);
        }
        public KhasraPotroTemplateDataDTO _khasraPotroTemplateData { get; set; }
        private void Khosra_Load(object sender, EventArgs e)
        {
           
            CreateEditor();
            DesignationSealListResponse designationSealListResponse = _dakForwardService.GetSealListResponse(_userService.GetLocalDakUserParam());
            _designationSealListResponse = designationSealListResponse;
            LoadDakPriority();
            LoadDakSecurity();

            templateListTableLayoutPanel.Controls.Clear();


            DakUserParam userParam = _userService.GetLocalDakUserParam();

            khasraPotroTemplateResponse = _khasraTemplateService.GetKhosraTemplate(userParam);
            
            templateListTableLayoutPanel.Controls.Clear();

            if (khasraPotroTemplateResponse.status == "success")
            {
                if (khasraPotroTemplateResponse.data.Count > 0)
                {
                   

                    int count = 0;
                    KhosraTemplateButton khosraTemplateButtonFake = new KhosraTemplateButton();
                    KhosraTemplateButton khosraTemplateButtonFake2 = new KhosraTemplateButton();
                    foreach (KhasraPotroTemplateDataDTO khasraPotroTemplateDataDTO in khasraPotroTemplateResponse.data)
                    {
                        
                        

                        KhosraTemplateButton khosraTemplateButton = new KhosraTemplateButton();
                        khosraTemplateButton.khasraPotroTemplateData = khasraPotroTemplateDataDTO;
                        khosraTemplateButton.TemplateClick += delegate (object se, EventArgs ve) { Template_CLick(khosraTemplateButton._khasraPotroTemplateData); };

                        if (count == 0)
                        {
                            _khasraPotroTemplateData = khasraPotroTemplateDataDTO;
                         
                           
                            khosraTemplateButtonFake.khasraPotroTemplateData = khasraPotroTemplateDataDTO;
                            khosraTemplateButtonFake.TemplateClick += delegate (object se, EventArgs ve) { Template_CLick(khosraTemplateButtonFake._khasraPotroTemplateData); };
                            UIDesignCommonMethod.AddRowinTable(templateListTableLayoutPanel, khosraTemplateButtonFake);
                            UIDesignCommonMethod.AddRowinTable(templateListTableLayoutPanel, khosraTemplateButtonFake2);




                        }

                        UIDesignCommonMethod.AddRowinTable(templateListTableLayoutPanel, khosraTemplateButton);
                        count += 1;
                    }
                  //  UIDesignCommonMethod.AddRowinTable(templateListTableLayoutPanel, khosraTemplateButtonFake);

                }
            }


            KhosraSelectedAttachmentRow khosraSelectedAttachmentRow = new KhosraSelectedAttachmentRow();
            khosraSelectedAttachmentRow.fileName = "৫৬.৪২.০০০০.০১০.২৫.০০৩.২১.২ - ২২ ফেব্রুয়ারি ২০২";

            UIDesignCommonMethod.AddRowinTable(selectedAttachmentTableLayoutPanel, khosraSelectedAttachmentRow);



            KhosraSelectedAttachmentRow khosraSelectedAttachmentRow2 = new KhosraSelectedAttachmentRow();
            khosraSelectedAttachmentRow2.fileName = "Potrojari_2021_65_02_2216139904184630293468.png";
            UIDesignCommonMethod.AddRowinTable(selectedAttachmentTableLayoutPanel, khosraSelectedAttachmentRow2);


            KhosraSelectedAttachmentRow khosraSelectedAttachmentRow3 = new KhosraSelectedAttachmentRow();
            khosraSelectedAttachmentRow3.fileName = "file_example_JPG_1MB.jpg";

            UIDesignCommonMethod.AddRowinTable(selectedAttachmentTableLayoutPanel, khosraSelectedAttachmentRow3);

        }

        private void tinyMceisLoaded()
        {
            throw new NotImplementedException();
        }

        private void nothiAllButton_Click(object sender, EventArgs e)
        {
            var form = FormFactory.Create<DakNothiteUposthapitoForm>();


            form.Khoshra();


            form.NothiKhosrajato += delegate (object snd, EventArgs eve) { NothiKhosrajato(form._noteSelected, form._nothiBranch, form._nothiName, form._nothiAllListDTO); };


            UIDesignCommonMethod.CalPopUpWindow(form,this);
        }
        private NoteNothiDTO _noteSelected;
        private NothiListAllRecordsDTO _nothiAllListDTO;

        private void NothiKhosrajato(NoteNothiDTO noteSelected, string nothiBranch, string nothiName, NothiListAllRecordsDTO nothiAllListDTO)
        {
            lbNoteShakha.Text = nothiBranch;
            lbNothiNo.Text = noteSelected.nothi_no;
            lbSubject.Text = nothiName;


            _noteSelected = noteSelected;
            _nothiAllListDTO = nothiAllListDTO;


            nothiNamePanel.Visible = true;
            noteDetailsButton.Visible = true;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }


        bool _isTinyMceEditorLoaded;
        private void khoshraBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            

            //try
            //{
            //    tinyMceEditor.Invoke(new MethodInvoker(delegate

            //    {
            //        tinyMceEditor.ExecuteScriptAsync("SetContent", new object[] { _khasraPotroTemplateData.html_content });
            //        tinyMceEditor.ExecuteScriptAsync("tinyMCE.execCommand('mceFullScreen')");
            //        _isTinyMceEditorLoaded = true;

            //    }));
            //}
            //catch
            //{
            //    _isTinyMceEditorLoaded = false;
            //}
        }

        private void khoshraBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if(tinyMceEditor.IsAccessible)
            {
                tinyMceEditor.ExecuteScriptAsync("SetContent", new object[] { _khasraPotroTemplateData.html_content });
                tinyMceEditor.ExecuteScriptAsync("tinyMCE.execCommand('mceFullScreen')");
            }
            else
            {
                khoshraBackgroundWorker.RunWorkerAsync();
            }

            //if (!khoshraBackgroundWorker.IsBusy && this.Visible && _isTinyMceEditorLoaded)
            //{

            //   
            //}
        }

        private void tinyMceEditor_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            if(!_isTinyMceEditorLoaded)
            {
                try
                {
                    tinyMceEditor.ExecuteScriptAsync("SetContent", new object[] { _khasraPotroTemplateData.html_content });
                    tinyMceEditor.ExecuteScriptAsync("tinyMCE.execCommand('mceFullScreen')");
                    _isTinyMceEditorLoaded = true;
                }
                catch
                {
                    _isTinyMceEditorLoaded = false;
                }
            }

        }

        private string _potrosub;
        private string _potrotype;
        private string _sarokNo;
        private async void saveButton_Click(object sender, EventArgs e)
        {
           


            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = "অপনি কি খসরা টি সংরক্ষণ চান?";
            conditonBoxForm.ShowDialog();

            if (conditonBoxForm.Yes)
            {
                JavascriptResponse response = await tinyMceEditor.EvaluateScriptAsync("GetContent()");

                _currentHtmlString = response.Result.ToString();



                DakUserParam dakUserParam = _userService.GetLocalDakUserParam();
                KhosraSaveParamPotro khosraSaveParamPotro = new KhosraSaveParamPotro();
                khosraSaveParamPotro.potrojari = new KhasraSaveParamPotrojari();
                //khosraSaveParamPotro.potrojari.attached_potro=


                khosraSaveParamPotro.potrojari.note_subject = _noteSelected.note_subject;
                khosraSaveParamPotro.potrojari.nothi_master_id = Convert.ToInt32(_noteSelected.nothi_id);
                khosraSaveParamPotro.potrojari.nothi_note_id = Convert.ToInt32(_noteSelected.note_id);



                khosraSaveParamPotro.potrojari.potro_description = ConversionMethod.Base64Encode(_currentHtmlString);
                khosraSaveParamPotro.potrojari.potro_priority_level = dakPriorityComboBox.SelectedIndex;
                khosraSaveParamPotro.potrojari.potro_security_level = dakSecrurityComboBox.SelectedIndex;

                khosraSaveParamPotro.potrojari.potro_subject = GetPotroSubjectFromHtmlString(_currentHtmlString);



                //khosraSaveParamPotro.potrojari.potro_subject=_khasraPotroTemplateData
                //khosraSaveParamPotro.potrojari.potro_type= _khasraPotroTemplateData.
                //khosraSaveParamPotro.potrojari.sarok_no=
                khosraSaveParamPotro.recipient = new KhosraSaveParamRecipent();

               
                AddOnumodontoParam(khosraSaveParamPotro);
                AddOnulipiParam(khosraSaveParamPotro);
                AddPrpoktoParam(khosraSaveParamPotro);
                AddSendertoParam(khosraSaveParamPotro);
                AddAttentiontoParam(khosraSaveParamPotro);



                KhosraSaveResponse khosraSaveResponse = _khosraSaveService.GetKhosraSaveResponse(dakUserParam, khosraSaveParamPotro);

            }


        }

        private string GetPotroSubjectFromHtmlString(string currentHtmlString)
        {




            string sub = "";

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(currentHtmlString);
            var td=doc.DocumentNode.Descendants("td").FirstOrDefault(d => d.GetAttributeValue("class", "").Contains("khoshra_subject"));
            sub = td.InnerText;

            




            return sub;

        }

        private void AddPrpoktoParam(KhosraSaveParamPotro khosraSaveParamPotro)
        {
            List<KhosraSaveParamOfficer> receivers = new List<KhosraSaveParamOfficer>();
            foreach(PrapokDTO prapokDTO in prapokOfficers)
            {
                KhosraSaveParamOfficer khosraSaveParamOfficer = new KhosraSaveParamOfficer();
                khosraSaveParamOfficer.designation_id = prapokDTO.designation_id.ToString();
                khosraSaveParamOfficer.designation = prapokDTO.designation;
                khosraSaveParamOfficer.office = prapokDTO.office;
                khosraSaveParamOfficer.officer = prapokDTO.officer;
                khosraSaveParamOfficer.officer_email = prapokDTO.personal_email;
                khosraSaveParamOfficer.officer_id = prapokDTO.officer_id.ToString();
                khosraSaveParamOfficer.office_unit = prapokDTO.office_unit_bng;
                khosraSaveParamOfficer.office_unit_id = prapokDTO.office_unit_id.ToString();

                receivers.Add(khosraSaveParamOfficer);

            }

            khosraSaveParamPotro.recipient.receiver = receivers.ToDictionary(a=>a.designation_id);
        }

        private void AddOnulipiParam(KhosraSaveParamPotro khosraSaveParamPotro)
        {
            List<KhosraSaveParamOfficer> receivers = new List<KhosraSaveParamOfficer>();
            foreach (PrapokDTO prapokDTO in onulipiOfficers)
            {
                KhosraSaveParamOfficer khosraSaveParamOfficer = new KhosraSaveParamOfficer();
                khosraSaveParamOfficer.designation_id = prapokDTO.designation_id.ToString();
                khosraSaveParamOfficer.designation = prapokDTO.designation;
                khosraSaveParamOfficer.office = prapokDTO.office;
                khosraSaveParamOfficer.officer = prapokDTO.officer;
                khosraSaveParamOfficer.officer_email = prapokDTO.personal_email;
                khosraSaveParamOfficer.officer_id = prapokDTO.officer_id.ToString();
                khosraSaveParamOfficer.office_unit = prapokDTO.office_unit_bng;
                khosraSaveParamOfficer.office_unit_id = prapokDTO.office_unit_id.ToString();

                receivers.Add(khosraSaveParamOfficer);

            }

            khosraSaveParamPotro.recipient.onulipi = receivers.ToDictionary(a => a.designation_id);
        }
        private void AddAttentiontoParam(KhosraSaveParamPotro khosraSaveParamPotro)
        {
            List<KhosraSaveParamOfficer> receivers = new List<KhosraSaveParamOfficer>();
            foreach (PrapokDTO prapokDTO in attentionOfficers)
            {
                KhosraSaveParamOfficer khosraSaveParamOfficer = new KhosraSaveParamOfficer();
                khosraSaveParamOfficer.designation_id = prapokDTO.designation_id.ToString();
                khosraSaveParamOfficer.designation = prapokDTO.designation;
                khosraSaveParamOfficer.office = prapokDTO.office;
                khosraSaveParamOfficer.officer = prapokDTO.officer;
                khosraSaveParamOfficer.officer_email = prapokDTO.personal_email;
                khosraSaveParamOfficer.officer_id = prapokDTO.officer_id.ToString();
                khosraSaveParamOfficer.office_unit = prapokDTO.office_unit_bng;
                khosraSaveParamOfficer.office_unit_id = prapokDTO.office_unit_id.ToString();

                receivers.Add(khosraSaveParamOfficer);

            }

            khosraSaveParamPotro.recipient.attention = receivers.ToDictionary(a => a.designation_id);
        }
        private void AddSendertoParam(KhosraSaveParamPotro khosraSaveParamPotro)
        {
            List<KhosraSaveParamOfficer> receivers = new List<KhosraSaveParamOfficer>();
            foreach (PrapokDTO prapokDTO in senderOfficer)
            {
                KhosraSaveParamOfficer khosraSaveParamOfficer = new KhosraSaveParamOfficer();
                khosraSaveParamOfficer.designation_id = prapokDTO.designation_id.ToString();
                khosraSaveParamOfficer.designation = prapokDTO.designation;
                khosraSaveParamOfficer.office = prapokDTO.office;
                khosraSaveParamOfficer.officer = prapokDTO.officer;
                khosraSaveParamOfficer.officer_email = prapokDTO.personal_email;
                khosraSaveParamOfficer.officer_id = prapokDTO.officer_id.ToString();
                khosraSaveParamOfficer.office_unit = prapokDTO.office_unit_bng;
                khosraSaveParamOfficer.office_unit_id = prapokDTO.office_unit_id.ToString();

                receivers.Add(khosraSaveParamOfficer);

            }

            khosraSaveParamPotro.recipient.sender = receivers.ToDictionary(a => a.designation_id);
        }
        private void AddOnumodontoParam(KhosraSaveParamPotro khosraSaveParamPotro)
        {
            List<KhosraSaveParamOfficer> receivers = new List<KhosraSaveParamOfficer>();
            foreach (PrapokDTO prapokDTO in onumodonOfficer)
            {
                KhosraSaveParamOfficer khosraSaveParamOfficer = new KhosraSaveParamOfficer();
                khosraSaveParamOfficer.designation_id = prapokDTO.designation_id.ToString();
                khosraSaveParamOfficer.designation = prapokDTO.designation;
                khosraSaveParamOfficer.office = prapokDTO.office;
                khosraSaveParamOfficer.officer = prapokDTO.officer;
                khosraSaveParamOfficer.officer_email = prapokDTO.personal_email;
                khosraSaveParamOfficer.officer_id = prapokDTO.officer_id.ToString();
                khosraSaveParamOfficer.office_unit = prapokDTO.office_unit_bng;
                khosraSaveParamOfficer.office_unit_id = prapokDTO.office_unit_id.ToString();

                receivers.Add(khosraSaveParamOfficer);

            }

            khosraSaveParamPotro.recipient.approver = receivers.ToDictionary(a => a.designation_id);
        }



    }
}
