using CefSharp;
using CefSharp.WinForms;
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
            set { _nothiShaeredByMeRecord = value; }
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
    }
}
