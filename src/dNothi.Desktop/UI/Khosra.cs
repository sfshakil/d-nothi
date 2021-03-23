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

namespace dNothi.Desktop.UI
{
    public partial class Khosra : Form
    {
        IUserService _userService { get; set; }
        IDakForwardService _dakForwardService { get; set; }
        IKhasraTemplateService _khasraTemplateService { get; set; }
    
        public KhasraPotroTemplateResponse khasraPotroTemplateResponse { get; set; }
        public Khosra(IUserService userService, IKhasraTemplateService khasraTemplateService, IDakForwardService dakForwardService)
        {
            _userService = userService;
            _dakForwardService = dakForwardService;

            _khasraTemplateService = khasraTemplateService;
           
            InitializeComponent();
            tinyMceEditor.CreateEditor();
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
            DesignationSealListResponse designationSealListResponse = _dakForwardService.GetSealListResponse(_userService.GetLocalDakUserParam());
            _designationSealListResponse = designationSealListResponse;
            LoadDakPriority();
            LoadDakSecurity();

            templateListTableLayoutPanel.Controls.Clear();


            DakUserParam userParam = _userService.GetLocalDakUserParam();

            khasraPotroTemplateResponse = _khasraTemplateService.GetKhosraTemplate(userParam);


            if(khasraPotroTemplateResponse.status=="success")
            {
                if(khasraPotroTemplateResponse.data.Count>0)
                {
                    tinyMceEditor.CreateEditor();
                    tinyMceEditor.HtmlContent = khasraPotroTemplateResponse.data[0].html_content;

                    foreach (KhasraPotroTemplateDataDTO khasraPotroTemplateDataDTO in khasraPotroTemplateResponse.data)
                    {
                        KhosraTemplateButton khosraTemplateButton = new KhosraTemplateButton();
                        khosraTemplateButton.khasraPotroTemplateData = khasraPotroTemplateDataDTO;
                        khosraTemplateButton.TemplateClick += delegate (object se, EventArgs ve) { Template_CLick(khosraTemplateButton._khasraPotroTemplateData); };

                        khosraTemplateButton.Dock = DockStyle.Fill;

                        int row = templateListTableLayoutPanel.RowCount++;

                        templateListTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
                        if (row == 1)
                        {
                            row = templateListTableLayoutPanel.RowCount++;
                            templateListTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
                        }
                        templateListTableLayoutPanel.Controls.Add(khosraTemplateButton, 0, row);
                    }
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

        private void Template_CLick(KhasraPotroTemplateDataDTO khasraPotroTemplateData)
        {
            tinyMceEditor.HtmlContent = khasraPotroTemplateData.html_content;
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
            hideform.Opacity = .6;

            hideform.FormBorderStyle = FormBorderStyle.None;
            hideform.StartPosition = FormStartPosition.CenterScreen;
            hideform.Shown += delegate (object sr, EventArgs ev) { hideform_Shown(sr, ev, form); };
            hideform.ShowDialog();
        }



        public DesignationSealListResponse _designationSealListResponse { get; set; }
        private void onumodonkariOfficerSelectButton_Click(object sender, EventArgs e)
        {
            SelectOfficer(onumodonkariOfficerSelectButton,onumodonkariListPanel, onumodonkariEmptyPanel,onumodonkariListFlowLayoutPanel);
        }

        private void SelectOfficer(FontAwesome.Sharp.IconButton officerSelectButton, Panel officerListPanel, Panel officerEmptyPanel, FlowLayoutPanel officerListFlowLayoutPanel)
        {
            SelectOfficerForm selectOfficerForm = new SelectOfficerForm();


            selectOfficerForm.designationSealListResponse = _designationSealListResponse;

            selectOfficerForm.SaveButtonClick += delegate (object se, EventArgs ev) { SaveOfficerinOnumodonKariOfficerList(officerSelectButton,selectOfficerForm._selectedOfficerDesignations, officerListPanel, officerEmptyPanel, officerListFlowLayoutPanel); };

            CalPopUpWindow(selectOfficerForm);
        }

        private void SaveOfficerinOnumodonKariOfficerList(FontAwesome.Sharp.IconButton officerSelectButton, List<int> selectedOfficerDesignations, Panel officerListPanel, Panel officerEmptyPanel, FlowLayoutPanel officerListFlowLayoutPanel)
        {
            officerListFlowLayoutPanel.Controls.Clear();



            if (selectedOfficerDesignations.Count>0)
            {
                foreach(int id in selectedOfficerDesignations)
                {
                    var designationSeal = _designationSealListResponse.data.other_office.FirstOrDefault(a => a.designation_id == id);
                    if(designationSeal == null)
                    {
                         designationSeal = _designationSealListResponse.data.own_office.FirstOrDefault(a => a.designation_id == id);
                    }

                    if(designationSeal != null)
                    {
                        OfficerRowUserControl officerRowUserControl = new OfficerRowUserControl();
                        officerRowUserControl.officerName = designationSeal.NameWithDesignation;
                        officerRowUserControl.designationId = designationSeal.designation_id;
                        officerRowUserControl.Dock = DockStyle.Top;
                      //  officerRowUserControl.Width = onumodonkariListFlowLayoutPanel.Width - 30;
                        officerRowUserControl.DeleteButton += delegate (object se, EventArgs ev) {
                            ReloadOfficerList(officerSelectButton,officerListPanel, officerEmptyPanel, officerListFlowLayoutPanel);};

                        officerListFlowLayoutPanel.Controls.Add(officerRowUserControl);

                    }
                }
            }



            ReloadOfficerList(officerSelectButton,officerListPanel, officerEmptyPanel, officerListFlowLayoutPanel);



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


            officerSelectButton.IconChar = FontAwesome.Sharp.IconChar.CaretDown;
            onumodonkariListPanel.Visible = true;
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
    }
}
