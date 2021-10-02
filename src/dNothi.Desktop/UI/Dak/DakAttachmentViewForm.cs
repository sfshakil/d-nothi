using dNothi.JsonParser.Entity.Dak;
using dNothi.Services.BasicService;
using dNothi.Services.UserServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.UI.Dak
{
    public partial class DakAttachmentViewForm : Form
    {
        private DakAttachmentResponse _dakAttachmentResponse;
        private string _subject;
        IBasicService _basicService;
        IUserService _userService;
        public DakAttachmentViewForm(IBasicService basicService, IUserService userService)
        {
            InitializeComponent();
            _basicService = basicService;
            _userService = userService;
        }

        public string subject { get { return _subject; } set { _subject = value; Subjectlabel.Text = Subjectlabel.Text + value; } }

        public DakAttachmentResponse dakAttachmentResponse
        {
            get { return _dakAttachmentResponse; }
            set
            {
                _dakAttachmentResponse = value;


                attachmentTableLayoutPanel.Controls.Clear();
                DakAttachmentListBodyUserControl detailsAttachmentListUserControl = new DakAttachmentListBodyUserControl();
                try
                {
                    detailsAttachmentListUserControl.dakSub = _subject;
                    detailsAttachmentListUserControl.dakAttachmentDTOs = _dakAttachmentResponse.data;
                    detailsAttachmentListUserControl.allAttachmentDownload += delegate (object s, EventArgs e) { detailsAttachmentListUserControl_allAttachmentClick(s, e, _dakAttachmentResponse.data); };
                    detailsAttachmentListUserControl.allattachmentdownloadlink = "";
                    detailsAttachmentListUserControl.Dock = DockStyle.Fill;
                    attachmentTableLayoutPanel.Controls.Add(detailsAttachmentListUserControl);
                }
                catch
                {

                }



            }
        }

        private void detailsAttachmentListUserControl_allAttachmentClick(object s, EventArgs e,List<DakAttachmentDTO> attchmentDTos)
        {
            
            var userparam = _userService.GetLocalDakUserParam();
            var response = _basicService.AllFileDownload(userparam, attchmentDTos);
            if(response.status=="success")
            {
                
                Download(response.data);
            }
            

        }
        public void Download(string remoteUri)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "ZIP files|*.zip";
            saveDialog.FilterIndex = 2;

            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (WebClient client = new WebClient())
                {
                    try
                    {
                       
                        Uri uri = new Uri(remoteUri);

                        //delegate method, which will be called after file download has been complete.
                        client.DownloadFileCompleted += new AsyncCompletedEventHandler(Extract);

                        // uri is the remote url where filed needs to be downloaded, and FilePath is the location where file to be saved
                        client.DownloadFileAsync(uri, saveDialog.FileName);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
               
            }
         
        }
        public void Extract(object sender, AsyncCompletedEventArgs e)
        {
            UIDesignCommonMethod.SuccessMessage("ফাইল ডাউনলোড করা সফল হয়েছে।");
        }
       
        private void DakAttachmentViewForm_Load(object sender, EventArgs e)
        {
            Screen scr = Screen.FromPoint(this.Location);
            this.Location = new Point(scr.WorkingArea.Right - this.Width, scr.WorkingArea.Top);
            SetDefaultFont(this.Controls);
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
                else
                {
                    MemoryFonts.AddMemoryFont(Properties.Resources.SolaimanLipi);
                    ctrl.Font = MemoryFonts.GetFont(0, ctrl.Font.Size);
                }




                SetDefaultFont(ctrl.Controls);
            }

        }

        private void closeButtonClick(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
