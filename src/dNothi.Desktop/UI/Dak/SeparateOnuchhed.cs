using dNothi.Core.Entities;
using dNothi.Desktop.UI.CustomMessageBox;
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
using System.Web;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Dak
{
    public partial class SeparateOnuchhed : UserControl
    {
        private int originalWidth;
        private int originalHeight;
        INothiReviewerServices _nothiReviewerServices { get; set; }
        IUserService _userService { get; set; }
        public SeparateOnuchhed(INothiReviewerServices nothiReviewerServices, IUserService userService)
        {
            InitializeComponent();
            originalWidth = this.Width;
            originalHeight = this.Height;
            _nothiReviewerServices = nothiReviewerServices;
            _userService = userService;
            SetDefaultFont(this.Controls);
        }

        private string _createDate;
        private string _office;
        private string _subjectBrowser;
        private int _onucchedId;
        private string _totalFileNo;
        private int _shared_nothi_id;
        private string _note_onucched_status;
        private int _note_onucched_Potrojari;
        public int shared_nothi_id
        {
            get { return _shared_nothi_id; }
            set { _shared_nothi_id = value; }
        }
        public int note_onucched_Potrojari
        {
            get { return _note_onucched_Potrojari; }
            set { _note_onucched_Potrojari = value;

                if (_note_onucched_Potrojari > 0) 
                {
                    btnPotro.Visible = true;
                    MyToolTip.SetToolTip(btnPotro, "মোট "+ string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))) + "টি পত্র যুক্ত করা আছে");
                }
            } 
        }

        public string note_onucched_status
        {
            get { return _note_onucched_status; }
            set { _note_onucched_status = value; }
        }
        public void loadinLocal()
        {
            btnSchedule.Visible = true;
            btnDelete.Visible = false;
            btnKhosra.Visible = false;
        }
        public void lastopenOnuchhed()
        {
            int height = 0;
            if (SubjectBrowser.DocumentText != "" || SignatureFLP.Controls.Count > 0 || fileFLP.Controls.Count > 0)
            {
                if (SubjectBrowser.DocumentText != "")
                {
                    height += 174;
                }
                if (SignatureFLP.Controls.Count > 0)
                {
                    height += SignatureFLP.Size.Height;
                }
                if (fileFLP.Controls.Count > 0)
                {
                    filePnael.Size = fileHeaderPanel.Size + fileFLP.Size;
                    fileViewBodyPanel.Size = fileFLP.Size;
                    height += filePnael.Size.Height;
                }
                this.Height = originalHeight + height;
                this.Width = originalWidth;
            }
            else
            {

                this.Height = 174 + originalHeight;
                this.Width = originalWidth;
            }
            topPnl.Visible = true;
            middlePnl.Visible = true;
            SignatureFLP.Visible = true;
            SubjectBrowser.Visible = true;
            btnPlusSquare.IconChar = FontAwesome.Sharp.IconChar.MinusSquare;
        }
        public static readonly List<string> DOCExtensions = new List<string> { ".DOC", "DOC", ".DOCX", "DOCX" };
        public static readonly List<string> CSVExtensions = new List<string> { ".CSV", "CSV" };
        public static readonly List<string> MP4Extensions = new List<string> { ".MP4", "MP4" };
        public static readonly List<string> PDFExtensions = new List<string> { ".PDF", "PDF" };
        public static readonly List<string> XLSExtensions = new List<string> { ".XLS", "XLS", ".XLSX", "XLSX" };
        public void fileAddInFilePanel(AttachmentDTO attachment)
        {
            if (DOCExtensions.Contains(new System.IO.FileInfo(attachment.user_file_name).Extension.ToUpperInvariant()))
            {
                var fileusercontrol = UserControlFactory.Create<FileUserControl>();
                fileusercontrol.fileName = attachment.user_file_name;
                fileusercontrol.fileSize = attachment.file_size_in_kb.ToString();
                fileusercontrol.fileDownloadLink = attachment.download_url;
                fileusercontrol.fileViewLink = attachment.url;
                fileusercontrol.docExtension();
                UIDesignCommonMethod.AddRowinTable(fileFLP, fileusercontrol);
            }
            else if (CSVExtensions.Contains(new System.IO.FileInfo(attachment.user_file_name).Extension.ToUpperInvariant()))
            {
                var fileusercontrol = UserControlFactory.Create<FileUserControl>();
                fileusercontrol.fileName = attachment.user_file_name;
                fileusercontrol.fileSize = attachment.file_size_in_kb.ToString();
                fileusercontrol.fileDownloadLink = attachment.download_url;
                fileusercontrol.fileViewLink = attachment.url;
                fileusercontrol.csvExtension();
                UIDesignCommonMethod.AddRowinTable(fileFLP, fileusercontrol);
            }
            else if (MP4Extensions.Contains(new System.IO.FileInfo(attachment.user_file_name).Extension.ToUpperInvariant()))
            {
                var fileusercontrol = UserControlFactory.Create<FileUserControl>();
                fileusercontrol.fileName = attachment.user_file_name;
                fileusercontrol.fileSize = attachment.file_size_in_kb.ToString();
                fileusercontrol.fileDownloadLink = attachment.download_url;
                fileusercontrol.fileViewLink = attachment.url;
                fileusercontrol.mp4Extension();
                UIDesignCommonMethod.AddRowinTable(fileFLP, fileusercontrol);
            }
            else if (PDFExtensions.Contains(new System.IO.FileInfo(attachment.user_file_name).Extension.ToUpperInvariant()))
            {
                var fileusercontrol = UserControlFactory.Create<FileUserControl>();
                fileusercontrol.fileName = attachment.user_file_name;
                fileusercontrol.fileSize = attachment.file_size_in_kb.ToString();
                fileusercontrol.fileDownloadLink = attachment.download_url;
                fileusercontrol.fileViewLink = attachment.url;
                fileusercontrol.pdfExtension();
                UIDesignCommonMethod.AddRowinTable(fileFLP, fileusercontrol);
            }
            else if (XLSExtensions.Contains(new System.IO.FileInfo(attachment.user_file_name).Extension.ToUpperInvariant()))
            {
                var fileusercontrol = UserControlFactory.Create<FileUserControl>();
                fileusercontrol.fileName = attachment.user_file_name;
                fileusercontrol.fileSize = attachment.file_size_in_kb.ToString();
                fileusercontrol.fileDownloadLink = attachment.download_url;
                fileusercontrol.fileViewLink = attachment.url;
                fileusercontrol.xlsExtension();
                UIDesignCommonMethod.AddRowinTable(fileFLP, fileusercontrol);
            }
            else
            {
                var fileusercontrol = UserControlFactory.Create<FileUserControl>();
                fileusercontrol.fileName = attachment.user_file_name;
                fileusercontrol.fileSize = attachment.file_size_in_kb.ToString();
                fileusercontrol.fileDownloadLink = attachment.download_url;
                fileusercontrol.fileViewLink = attachment.url;
                UIDesignCommonMethod.AddRowinTable(fileFLP, fileusercontrol);
            }
            
        }
        public void filePnaeloff()
        {
            filePnael.Visible = false;
        }
        public void khoshrabuttonoff()
        {
            btnKhosra.Enabled = false;
        }
        [Category("Custom Props")]
        public string office
        {
            get { return _office; }
            set { _office = value; lbOffice.Text = "("+value+")"; }
        }
        public string totalFileNo
        {
            get { return _totalFileNo; }
            set { _totalFileNo = value; lbTotalFileNo.Text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); }
        }
        public int onucchedId
        {
            get { return _onucchedId; }
            set { _onucchedId = value; lbonucchedId.Text = value.ToString(); }
        }
        [Category("Custom Props")]
        public string createDate
        {
            get { return _createDate; }
            set { _createDate = value; lbCreateDate.Text = "("+value+")"; }
        }
        [Category("Custom Props")]
        public string subjectBrowser
        {
            get { return _subjectBrowser; }
            set { _subjectBrowser = value; SubjectBrowser.DocumentText = value;
            }
        }

        [Category("Custom Props")]
        public void noteNo(string int1,string int2)
        {
            int2 = string.Concat(int2.ToString().Select(c => (char)('\u09E6' + c - '0')));
            lbNoteNo.Text = int1 + '.'+ int2;
            lbOnucchedNo.Text = int1 + '.' + int2;
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

        private void btnPlusSquare_Click(object sender, EventArgs e)
        {
            int height = 0;
            if (btnPlusSquare.IconChar == FontAwesome.Sharp.IconChar.PlusSquare)
            {
                if(SubjectBrowser.DocumentText != "" || SignatureFLP.Controls.Count > 0 || fileFLP.Controls.Count>0)
                {
                    if (SubjectBrowser.DocumentText != "")
                    {
                        height += 174;
                    }
                    if (SignatureFLP.Controls.Count > 0)
                    {
                        height += SignatureFLP.Size.Height;
                    }
                    if (fileFLP.Controls.Count  > 0)
                    {
                        filePnael.Size = fileHeaderPanel.Size + fileFLP.Size;
                        fileViewBodyPanel.Size = fileFLP.Size;
                        height += filePnael.Size.Height;
                    }
                    this.Height =  originalHeight + height;
                    this.Width = originalWidth;
                }
                else
                {

                    this.Height = 174 + originalHeight;
                    this.Width = originalWidth;
                }
                topPnl.Visible = true;
                middlePnl.Visible = true;
                SignatureFLP.Visible = true;
                SubjectBrowser.Visible = true;
                btnPlusSquare.IconChar = FontAwesome.Sharp.IconChar.MinusSquare;
                
                //loadnewAllNoteFlowLayoutPanel();
            }
            else
            {
                this.Height = originalHeight;
                this.Width = originalWidth;

                topPnl.Visible = false;
                middlePnl.Visible = false;
                SignatureFLP.Visible = false;
                SubjectBrowser.Visible = false;

                btnPlusSquare.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
                
            }
        }
        public void ButtonVisibleFromKasra()
        {
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            btnKhosra.Visible = false;
        }
        public void loadOnuchhedSignature(SingleOnucchedRecordSignatureDTO singleRecSignature)
        {
            if(singleRecSignature.Signature1 != null || singleRecSignature.Signature2 != null || singleRecSignature.Signature3 != null || singleRecSignature.Signature4 != null)
            {
                var onucchedSignature = UserControlFactory.Create<OnucchedSignature>();
                if (singleRecSignature.Signature1 != null)
                {

                    onucchedSignature.showSignature1element();
                    onucchedSignature.SignatureDate1 = singleRecSignature.Signature1.signature_date;
                    onucchedSignature.EmployeeName1 = singleRecSignature.Signature1.employee_name;
                    onucchedSignature.EmployeeDesignation1 = singleRecSignature.Signature1.employee_designation;
                    if (singleRecSignature.Signature1.encode_sign != "")
                    {
                        var str = singleRecSignature.Signature1.encode_sign.Substring(singleRecSignature.Signature1.encode_sign.IndexOf(",") + 1);
                        try
                        {
                            onucchedSignature.pbSign1 = Convert.FromBase64String(str);
                        }
                        catch
                        {
                            var strtry = str.Substring(str.IndexOf(",") + 1);
                            onucchedSignature.pbSign1 = Convert.FromBase64String(strtry);
                        }
                        
                    }
                    

                }
                if (singleRecSignature.Signature2 != null)
                {
                    onucchedSignature.showSignature2element();
                    onucchedSignature.SignatureDate2 = singleRecSignature.Signature2.signature_date;
                    onucchedSignature.EmployeeName2 = singleRecSignature.Signature2.employee_name;
                    onucchedSignature.EmployeeDesignation2 = singleRecSignature.Signature2.employee_designation;
                    if (singleRecSignature.Signature2.encode_sign != "")
                    {
                        var str = singleRecSignature.Signature2.encode_sign.Substring(singleRecSignature.Signature2.encode_sign.IndexOf(",") + 1);
                        
                        try
                        {
                            onucchedSignature.pbSign2 = Convert.FromBase64String(str);
                        }
                        catch
                        {
                            var strtry = str.Substring(str.IndexOf(",") + 1);
                            onucchedSignature.pbSign2 = Convert.FromBase64String(strtry);
                        }
                    }
                }
                if (singleRecSignature.Signature3 != null)
                {
                    onucchedSignature.showSignature3element();
                    onucchedSignature.SignatureDate3 = singleRecSignature.Signature3.signature_date;
                    onucchedSignature.EmployeeName3 = singleRecSignature.Signature3.employee_name;
                    onucchedSignature.EmployeeDesignation3 = singleRecSignature.Signature3.employee_designation;
                    if (singleRecSignature.Signature3.encode_sign != "")
                    {
                        var str = singleRecSignature.Signature3.encode_sign.Substring(singleRecSignature.Signature3.encode_sign.IndexOf(",") + 1);
                        
                        try
                        {
                            onucchedSignature.pbSign3 = Convert.FromBase64String(str);
                        }
                        catch
                        {
                            var strtry = str.Substring(str.IndexOf(",") + 1);
                            onucchedSignature.pbSign3 = Convert.FromBase64String(strtry);
                        }
                    }
                    
                }
                if (singleRecSignature.Signature4 != null)
                {
                    onucchedSignature.showSignature4element();
                    onucchedSignature.SignatureDate4 = singleRecSignature.Signature4.signature_date;
                    onucchedSignature.EmployeeName4 = singleRecSignature.Signature4.employee_name;
                    onucchedSignature.EmployeeDesignation4 = singleRecSignature.Signature4.employee_designation;
                    if (singleRecSignature.Signature4.encode_sign != "")
                    {
                        var str = singleRecSignature.Signature4.encode_sign.Substring(singleRecSignature.Signature4.encode_sign.IndexOf(",") + 1);
                        
                        try
                        {
                            onucchedSignature.pbSign4 = Convert.FromBase64String(str);
                        }
                        catch
                        {
                            var strtry = str.Substring(str.IndexOf(",") + 1);
                            onucchedSignature.pbSign4 = Convert.FromBase64String(strtry);
                        }
                    }
                    
                }
                //SignatureFLP.Controls.Add(onucchedSignature);
                UIDesignCommonMethod.AddRowinTable(SignatureFLP, onucchedSignature);
            }
            

        }

        private void onuchhedheaderPnl_MouseHover(object sender, EventArgs e)
        {
            if (btnSchedule.Visible==true)
            {
                btnDelete.Visible = false;
                btnKhosra.Visible = false;
                btnEdit.Visible = false;
                btnShare.Visible = false;
            }
            else
            {
                if (note_onucched_status == "DRAFT")
                {
                    if (shared_nothi_id <= 0)
                    {
                        //all button visible
                        btnShare.Visible = true;
                        btnDelete.Visible = true;
                        btnKhosra.Visible = true;
                        btnEdit.Visible = true;
                    }
                    else
                    {
                        // only share button visible
                        shareLabel.Visible = true;
                        btnShare.Visible = true;
                        btnDelete.Visible = false;
                        btnKhosra.Visible = false;
                        btnEdit.Visible = false;
                    }
                }
                else
                {
                    // all button invisible
                    btnDelete.Visible = false;
                    btnKhosra.Visible = false;
                    btnEdit.Visible = false;
                    btnShare.Visible = false;
                }
                
            }
            
        }

        private void btnDelete_MouseHover(object sender, EventArgs e)
        {
            if (btnSchedule.Visible == true)
            {
                btnDelete.Visible = false;
            }
            else
            {
                btnDelete.Visible = true;
                btnDelete.IconColor = Color.Red;
            }
            
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            if (btnSchedule.Visible == true)
            {
                btnDelete.Visible = false;
            }
            else
            {
                btnDelete.IconColor = Color.FromArgb(54, 153, 255);
            }
        }
        public event EventHandler DeleteButtonClick;
        public event EventHandler KhoshraButtonClick;
        public event EventHandler EditButtonClick;
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string message = "আপনি অনুচ্ছেদটি মুছে ফেলতে চান?";
            ConditonBoxForm conditonBoxForm = new ConditonBoxForm();
            conditonBoxForm.message = message;
            conditonBoxForm.ShowDialog(this);
            if (conditonBoxForm.Yes)
            {
                if (this.DeleteButtonClick != null)
                    this.DeleteButtonClick(onucchedId, e);
            }
            
        }

        private void onuchhedheaderPnl_MouseLeave(object sender, EventArgs e)
        {
            //btnDelete.Visible = false;
        }

        private void SubjectBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            SubjectBrowser.Document.Body.Style = "font-size:10pt;";//font-family:SolaimanLipi;SubjectBrowser.Height = SubjectBrowser.Document.Body.ScrollRectangle.Height;
            //this.Height += SubjectBrowser.Document.Body.ScrollRectangle.Height;
            //SubjectBrowser.Height = SubjectBrowser.Document.Body.ScrollRectangle.Height;
        }

        private void btnKhosra_MouseHover(object sender, EventArgs e)
        {
            if (btnSchedule.Visible == true)
            {
                btnKhosra.Visible = false;
            }
            else
            {
                btnKhosra.Visible = true;
                btnKhosra.IconColor = Color.Red;
            }
        }

        private void btnKhosra_MouseLeave(object sender, EventArgs e)
        {
            if (btnSchedule.Visible == true)
            {
                btnKhosra.Visible = false;
            }
            else
            {
                btnKhosra.IconColor = Color.FromArgb(54, 153, 255);
            }
        }

        private void btnKhosra_Click(object sender, EventArgs e)
        {
            if (this.KhoshraButtonClick != null)
                this.KhoshraButtonClick(onucchedId, e);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OnuchhedSaveItemAction onuchhedEditItemAction = new OnuchhedSaveItemAction();
            onuchhedEditItemAction.onuchhedId = onucchedId.ToString();
            onuchhedEditItemAction.editorEncodedData = _subjectBrowser;

            if (this.EditButtonClick != null)
                this.EditButtonClick(onuchhedEditItemAction, e);
        }

        private void btnEdit_MouseHover(object sender, EventArgs e)
        {
            if (btnSchedule.Visible == true)
            {
                btnEdit.Visible = false;
            }
            else
            {
                btnEdit.Visible = true;
                btnEdit.IconColor = Color.Red;
            }
        }

        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            if (btnSchedule.Visible == true)
            {
                btnEdit.Visible = false;
            }
            else
            {
                btnEdit.IconColor = Color.FromArgb(54, 153, 255);
            }
        }

        private void SubjectBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (e.Url.AbsolutePath != "blank") 
            {
                SubjectBrowser.DocumentText = subjectBrowser;
                FileViewWebBrowser fileViewWebBrowser = new FileViewWebBrowser();
                fileViewWebBrowser.fileAddInWebBrowser(e.Url.AbsoluteUri, "");
                CalPopUpWindow(fileViewWebBrowser);
            }
        }
        private void CalPopUpWindow(Form form)
        {
            Form hideform = new Form();


            hideform.BackColor = Color.Black;
            hideform.Size = Screen.PrimaryScreen.WorkingArea.Size;
            hideform.Opacity = .4;

            hideform.FormBorderStyle = FormBorderStyle.None;
            hideform.StartPosition = FormStartPosition.CenterScreen;
            hideform.Shown += delegate (object sr, EventArgs ev) { hideform_Shown(sr, ev, form); };
            hideform.ShowDialog();
        }
        void hideform_Shown(object sender, EventArgs e, Form form)
        {

            form.ShowDialog();

            (sender as Form).Hide();

            // var parent = form.Parent as Form; if (parent != null) { parent.Hide(); }
        }

        private void btnShare_Click(object sender, EventArgs e)
        {
            var dakuserparam = _userService.GetLocalDakUserParam();
            var response = _nothiReviewerServices.GetNothiReviewer(dakuserparam,shared_nothi_id);
        }
    }
}
