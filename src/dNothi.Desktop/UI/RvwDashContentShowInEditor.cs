using CefSharp;
using CefSharp.WinForms;
using dNothi.Desktop.UI.CustomMessageBox;
using dNothi.Desktop.UI.Dak;
using dNothi.JsonParser.Entity.Nothi;
using dNothi.Services.DakServices;
using dNothi.Services.NothiServices;
using dNothi.Services.UserServices;
using dNothi.Utility;
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
    public partial class RvwDashContentShowInEditor : Form
    {
        IUserService _userService { get; set; }
        INothiReviewerServices _nothiReviewerServices { get; set; }
        public WaitFormFunc WaitForm;
        ReviewDashBoardContentShare rvwDashBoardContentShare = UserControlFactory.Create<ReviewDashBoardContentShare>();
        public RvwDashContentShowInEditor(IUserService userService, INothiReviewerServices nothiReviewerServices)
        {
            _userService = userService;
            _nothiReviewerServices = nothiReviewerServices;
            InitializeComponent();
            WaitForm = new WaitFormFunc();


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
        //public ChromiumWebBrowser browser;

        private NothiShaeredByMeRecord _nothiShaeredByMeRecord;
        public NothiShaeredByMeRecord nothiShaeredByMeRecord
        {
            get { return _nothiShaeredByMeRecord; }
            set { _nothiShaeredByMeRecord = value;
                DakUserParam UserParam = _userService.GetLocalDakUserParam();
                lbNoteSubject.Text = "বিষয়ঃ " + _nothiShaeredByMeRecord.nothi.nothi_detail.note_subject;
                userNameLabel.Text = UserParam.officer+" ("+ UserParam.designation+", "+ UserParam.unit_label+")";
            }
        }
        public void loadEditorData()
        {
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            dakListUserParam.limit = 10;
            dakListUserParam.page = 1;
            NothiSharedEditorDataDTO response = _nothiReviewerServices.GetNothiSharedEditorData(dakListUserParam, _nothiShaeredByMeRecord.user.shared_nothi_id);
            if (response != null && response.status == "success")
            {
                var editorcontent = Encoding.UTF8.GetString(Convert.FromBase64String(response.data.shared_nothi.edited_content));
                string editortext = getparagraphtext(editorcontent);
                string addParagraphStartTag = "<p>";
                string addParagraphEndTag = "</p>";
                var allText = addParagraphStartTag + editortext + addParagraphEndTag;
                tinyMceEditor.ExecuteScriptAsync("SetContent", new object[] { allText });
                tinyMceEditor.ExecuteScriptAsync("tinyMCE.execCommand('mceFullScreen')");
            }
            else
            {
                tinyMceEditor.ExecuteScriptAsync("SetContent", new object[] { "" });
                tinyMceEditor.ExecuteScriptAsync("tinyMCE.execCommand('mceFullScreen')");
            }
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public string getparagraphtext(string editortext)
        {
            Match m = Regex.Match(editortext, @"<p>\s*(.+?)\s*</p>");
            if (m.Success)
            {
                return m.Groups[1].Value;
            }
            else
                return editortext;
        }

        private void tinyMceEditor_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            loadEditorData();
        }

        private void tinyMceEditor_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {

        }

        private void RvwDashContentShowInEditor_Load(object sender, EventArgs e)
        {
            CreateEditor();
        }

        private void ShareButton_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "ExtraPopUPWindow")
                {
                    BeginInvoke((Action)(() => f.Hide()));
                }

            }
            if (rvwDashBoardContentShare.Visible)
            {
                rvwDashBoardContentShare.Visible = false;
            }
            else
            {

                rvwDashBoardContentShare.Visible = true;
                rvwDashBoardContentShare.nothiSharedId = _nothiShaeredByMeRecord.user.shared_nothi_id;
                NextStepControlToForm(rvwDashBoardContentShare);
            }
        }
        public void NextStepControlToForm(Control control)
        {
            Form form = new Form();
            form.TopMost = true;
            form.TopMost = false;
            form.Name = "ExtraPopUPWindow";
            form.StartPosition = FormStartPosition.Manual;
            form.FormBorderStyle = FormBorderStyle.None;
            form.BackColor = Color.White;
            form.AutoSize = true;
            form.ShowInTaskbar = false;

            form.Location = new Point(Cursor.Position.X - control.Width, Cursor.Position.Y);
            control.Location = new System.Drawing.Point(0, 0);
            //form.Size = control.Size;
            form.Height = control.Height;
            form.Width = control.Width;
            control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            control.Height = form.Height;
            form.Controls.Add(control);
            form.Show();
        }
        public event EventHandler ReviewDashboardBack;
        private async void btnSave_Click(object sender, EventArgs e)
        {
            DakUserParam dakListUserParam = _userService.GetLocalDakUserParam();
            JavascriptResponse response1 = await tinyMceEditor.EvaluateScriptAsync("GetContent()");
            string sub = response1.Result.ToString();
            var paragraph = getparagraphtext(sub);
            var decodecontent = Base64Encode(paragraph);
            _nothiShaeredByMeRecord.nothi.onucched_subject = decodecontent;
            NothiSharedEditorDataSendDTO response = _nothiReviewerServices.GetNothiSharedEditorSaveData(dakListUserParam, _nothiShaeredByMeRecord);
            if (response != null && response.status == "success")
            {
                UIDesignCommonMethod.SuccessMessage("সফলভাবে প্রক্রিয়াটি সম্পন্ন হয়েছে");
                if (this.ReviewDashboardBack != null)
                    this.ReviewDashboardBack(sender, e);
                this.Hide();
            }
            else
            {
                UIDesignCommonMethod.ErrorMessage(response.status);
                this.Hide();
            }
        }
    }
}
